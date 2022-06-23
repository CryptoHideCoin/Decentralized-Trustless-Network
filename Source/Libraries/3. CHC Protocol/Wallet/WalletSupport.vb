Option Compare Text
Option Explicit On

' ****************************************
' File: Wallet Support
' Release Engine: 1.0 
' 
' Date last successfully test: 03/10/2021
' ****************************************


Imports CHCBasicCryptographyLibrary.AreaEngine
Imports CHCCommonLibrary.AreaEngine.Miscellaneous







Namespace AreaWallet.Support

    ''' <summary>
    ''' This class is engine of Wallet Address
    ''' </summary>
    Public Class WalletAddressEngine

        Private Const charList As String = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz/*-+!£$%/()=-_#[],.;:\"

        Public Shared ReadOnly Property baseAddr As String = "CWA:"
        Public Shared ReadOnly Property closeAddr As String = "//"
        Public Shared ReadOnly Property basePvt As String = "kpvt"
        Public Shared ReadOnly Property closeBasePvt As String = "##"

        Public Shared Property numCharMaxFormatPrivateKey As Integer = 256
        Public Shared Property numCharFixPublicAddress As Integer = 98


        ''' <summary>
        ''' This method provide to generate a Official Private Key from a Private Key RAW
        ''' </summary>
        ''' <param name="privateKeyValue"></param>
        ''' <returns></returns>
        Private Shared Function generatePrivateKey(ByVal privateKeyValue As String) As String
            Try
                Dim index As Integer = 0
                Dim doubleChar As String = ""
                Dim value As Integer = 0
                Dim result As String = ""

                For Each singleChar In privateKeyValue
                    doubleChar += singleChar

                    If (doubleChar.Length = 2) Then
                        value = doubleChar
                        result += charList.Substring(value, 1)
                        doubleChar = ""
                    End If
                Next

                Return result
            Catch ex As Exception
                Return ""
            End Try
        End Function


        ''' <summary>
        ''' This class manage a single key pair
        ''' </summary>
        Public Class SingleKeyPair

            Inherits CHCCommonLibrary.AreaEngine.Keys.KeyPair


            ''' <summary>
            ''' This method provide to generate a Public Key from Private Key
            ''' </summary>
            <DebuggerHiddenAttribute()> Public Sub generatePublicKey()
                Try
                    Me.[public] = Encryption.Base58Signature.getPublicKeyFromPrivateKeyEx(Me.private)
                Catch ex As Exception
                    Throw New Exception("SingleWallet.generatePublicAddress():" & ex.Message, ex)
                End Try
            End Sub

            ''' <summary>
            ''' This method provide to decore a public key with suffix, checksum and prefix
            ''' </summary>
            ''' <param name="publicValue"></param>
            <DebuggerHiddenAttribute()> Public Sub decoreDataAddress(ByVal publicValue As String)
                Try
                    Me.[public] = baseAddr & publicValue & CheckSum.create(publicValue) & closeAddr
                    Me.private = basePvt & Me.private & CheckSum.create(Me.private) & closeBasePvt
                Catch ex As Exception
                    Throw New Exception("SingleWallet.decoreDataWallet():" & ex.Message, ex)
                End Try
            End Sub

            ''' <summary>
            ''' This method provide to check if the string start with a specific prefix 
            ''' </summary>
            ''' <param name="value"></param>
            ''' <returns></returns>
            <DebuggerHiddenAttribute()> Public Shared Function startAllowed(ByVal value As String) As Boolean
                Try
                    Return value.StartsWith(basePvt)
                Catch ex As Exception
                    Throw New Exception("SingleWallet.startAllowed():" & ex.Message, ex)
                End Try
            End Function

            ''' <summary>
            ''' This method provide to check if the string end with a specific suffix value
            ''' </summary>
            ''' <param name="value"></param>
            ''' <returns></returns>
            <DebuggerHiddenAttribute()> Public Shared Function endAllowed(ByVal value As String) As Boolean
                Try
                    Return value.EndsWith(closeBasePvt)
                Catch ex As Exception
                    Throw New Exception("SingleWallet.endAllowed():" & ex.Message, ex)
                End Try
            End Function

            ''' <summary>
            ''' This readonly property clean address from a decoration
            ''' </summary>
            ''' <param name="addressValue"></param>
            ''' <returns></returns>
            Public Shared ReadOnly Property cleanAddress(ByVal addressValue As String) As String
                Get
                    If (addressValue.Length <= (baseAddr & closeAddr).Length) Then
                        Return ""
                    End If
                    If (addressValue.StartsWith(baseAddr)) Then
                        Dim completeAddress As String = addressValue.Substring(baseAddr.Length, addressValue.Length - baseAddr.Length - closeAddr.Length)
                        Dim verifyAddressValue As CheckSum.CompleteStructure = CheckSum.verify(addressValue)

                        If verifyAddressValue.checkPositive Then
                            Return verifyAddressValue.originalText
                        Else
                            Return ""
                        End If
                    Else
                        Return addressValue
                    End If
                End Get
            End Property

            ''' <summary>
            ''' This method provide to check a format (decore) of a Public Address
            ''' </summary>
            ''' <param name="value"></param>
            ''' <returns></returns>
            <DebuggerHiddenAttribute()> Public Shared Function checkFormatPublicAddress(ByVal value As String) As Boolean
                If (value.Length <= (baseAddr & closeAddr).Length) Then
                    Return True
                End If

                Return (value.StartsWith(baseAddr) And value.EndsWith(closeAddr)) And (value.Length = (92 + baseAddr.Length + closeAddr.Length))
            End Function

            ''' <summary>
            ''' This method provide to extract a Privacy Key format clean from a decore private key
            ''' </summary>
            ''' <param name="value"></param>
            ''' <returns></returns>
            <DebuggerHiddenAttribute()> Public Shared Function extractPrivateKeyRAW(ByVal value As String) As String
                If (value.Trim.Length > 0) Then
                    If value.StartsWith(basePvt) And value.EndsWith(closeBasePvt) Then
                        Return value.Substring(basePvt.Length, value.Length - basePvt.Length - closeBasePvt.Length - 4)
                    Else
                        Return value
                    End If
                Else
                    Return ""
                End If
            End Function

        End Class

        ''' <summary>
        ''' This class contain a couple of a KeyPair (Official e RAW)
        ''' </summary>
        Public Class KeyPairComplete

            Public Property official As New SingleKeyPair
            Public Property raw As New SingleKeyPair

        End Class


        ''' <summary>
        ''' This method provide to get a exact char number lenght
        ''' </summary>
        ''' <returns></returns>
        Private Shared ReadOnly Property getFixCharLenght() As Byte
            Get
                Try
                    Return (numCharMaxFormatPrivateKey - basePvt.Length - closeBasePvt.Length - 4)
                Catch ex As Exception
                    Throw New Exception("WalletComplete.getFixCharLenght():" & ex.Message, ex)
                End Try
            End Get
        End Property

        ''' <summary>
        ''' This method provide to create a new KeyPair complete (Official, Raw) from a Private Key Official
        ''' </summary>
        ''' <param name="privateKeyValue"></param>
        ''' <returns></returns>
        Private Shared Function createNew(ByVal privateKeyValue As String) As KeyPairComplete
            Dim result As New KeyPairComplete
            Try
                Dim index As Integer = 0

                result.official.private = privateKeyValue

                If (privateKeyValue.Length <= (basePvt & closeBasePvt).Length) Then
                    Return result
                End If

                If (privateKeyValue.StartsWith(basePvt)) Then
                    privateKeyValue = privateKeyValue.Substring(basePvt.Length, privateKeyValue.Length - basePvt.Length - 6)
                End If

                For Each singleChar In privateKeyValue
                    If charAllowed(singleChar) Then
                        index = charList.IndexOf(singleChar)
                        result.raw.private += Strings.Right("0" & index.ToString.Trim(), 2)
                    End If
                Next

                result.official.private = privateKeyValue

                result.raw.public = Encryption.Base58Signature.getPublicKeyFromPrivateKeyEx(result.raw.private)
                result.official.decoreDataAddress(result.raw.public)
            Catch ex As Exception
                Throw New Exception("WalletComplete.createNew():" & ex.Message, ex)
            End Try

            Return result
        End Function


        ''' <summary>
        ''' This method provide to check if a char is ammitted in the rule
        ''' </summary>
        ''' <param name="charValue"></param>
        ''' <returns></returns>
        Public Shared ReadOnly Property charAllowed(ByVal charValue As Char) As Boolean
            Get
                Try
                    Return (charList.IndexOf(charValue) > -1)
                Catch ex As Exception
                    Throw New Exception("WalletComplete.charAllowed():" & ex.Message, ex)
                End Try
            End Get
        End Property

        ''' <summary>
        ''' This method provide to create a new KeyPair complete (Official, Raw)
        ''' </summary>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Public Shared Function createNew() As KeyPairComplete
            Dim result As New KeyPairComplete

            Try

                Dim rndChar As New Random(CInt(Date.Now.Ticks And &HFFFF))
                Dim index As Integer = 0

                For intC As Integer = 0 To getFixCharLenght() - 1

                    index = rndChar.Next(0, 62)

                    result.raw.private += Right("0" & index.ToString.Trim(), 2)
                    result.official.private += charList.Substring(index, 1)

                Next

                result.raw.generatePublicKey()
                result.official.decoreDataAddress(result.raw.public)

            Catch ex As Exception
                Throw New Exception("WalletComplete.createNew():" & ex.Message, ex)
            End Try

            Return result
        End Function

        ''' <summary>
        ''' This method provide to create a new KeyPair complete (Official, Raw) from Private Key (Official or Raw)
        ''' </summary>
        ''' <param name="privateKeyValue"></param>
        ''' <param name="fromRaw"></param>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Private Shared Function createNew(ByVal privateKeyValue As String, Optional ByVal fromRaw As Boolean = False) As KeyPairComplete
            Dim result As New KeyPairComplete
            Try
                If fromRaw Then
                    result.raw.private = privateKeyValue
                    result.official.private = generatePrivateKey(privateKeyValue)

                    result.raw.public = Encryption.Base58Signature.getPublicKeyFromPrivateKeyEx(result.raw.private)

                    result.official.decoreDataAddress(result.raw.public)
                Else
                    result = createNew(privateKeyValue)
                End If
            Catch ex As Exception
                Throw New Exception("WalletComplete.createNew():" & ex.Message, ex)
            End Try

            Return result
        End Function

        ''' <summary>
        ''' This method provide to create a new KeyPair complete (Official, Raw) from Privacy Key (Official or Raw) and force Public Address
        ''' </summary>
        ''' <param name="privateKeyValue"></param>
        ''' <param name="fromRaw"></param>
        ''' <param name="forcePublicAddress"></param>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Public Shared Function createNew(ByVal privateKeyValue As String, Optional ByVal fromRaw As Boolean = False, Optional ByVal forcePublicAddress As String = "") As KeyPairComplete
            Dim result As New KeyPairComplete
            Try
                If fromRaw Then
                    If (forcePublicAddress.Length > 0) Then
                        result.raw.private = privateKeyValue
                        result.official.private = generatePrivateKey(privateKeyValue)

                        result.raw.public = forcePublicAddress

                        result.official.decoreDataAddress(result.raw.public)
                    Else
                        result = createNew(privateKeyValue, True)
                    End If
                Else
                    result = createNew(privateKeyValue)
                End If
            Catch ex As Exception
                Throw New Exception("WalletComplete.createNew():" & ex.Message, ex)
            End Try

            Return result
        End Function

        ''' <summary>
        ''' This method provide to check a Private Key format official
        ''' </summary>
        ''' <param name="value"></param>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Public Shared Function checkPrivateKeyFormat(ByVal value As String) As Boolean
            Try
                Dim privateRaw As String = ""

                If (value.Length > 0) Then
                    Return value.StartsWith(basePvt) And value.EndsWith(closeBasePvt)
                Else
                    Return False
                End If
            Catch ex As Exception
                Throw New Exception("WalletComplete.checkPrivateKeyFormat():" & ex.Message, ex)
            End Try
        End Function

        ''' <summary>
        ''' This method provide to extract a Private Key Raw from a Official (decore) Private Key
        ''' </summary>
        ''' <param name="value"></param>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Public Shared Function extractPrivateKeyRAW(ByVal value As String) As String
            Try
                Dim privateRaw As String = ""

                If (value.Length > 0) Then
                    If value.StartsWith(basePvt) And value.EndsWith(closeBasePvt) Then

                        If CheckSum.verify(value).checkPositive Then
                            privateRaw = createNew(value).raw.private
                        End If
                    Else
                        privateRaw = value
                    End If
                End If

                Return privateRaw
            Catch ex As Exception
                Throw New Exception("WalletComplete.extractPrivateKeyRAW():" & ex.Message, ex)
            End Try
        End Function

        ''' <summary>
        ''' This method provide to create a signature from a Private Key and a message
        ''' </summary>
        ''' <param name="privateKey"></param>
        ''' <param name="message"></param>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Public Shared Function createSignature(ByVal privateKey As String, ByVal message As String) As String
            Try
                Dim privateRaw As String = extractPrivateKeyRAW(privateKey)

                Return Encryption.Base58Signature.getSignature(privateRaw, message)
            Catch ex As Exception
                Throw New Exception("WalletComplete.createSignature():" & ex.Message, ex)
            End Try
        End Function

        ''' <summary>
        ''' This method provide to check a signature of a message with an official Public Address 
        ''' </summary>
        ''' <param name="publicAddress"></param>
        ''' <param name="message"></param>
        ''' <param name="signature"></param>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Public Shared Function verifySignature(ByVal publicAddress As String, ByVal message As String, ByVal signature As String) As Boolean
            Try
                Dim address As String = SingleKeyPair.cleanAddress(publicAddress)

                Return Encryption.Base58Signature.verifySignature(message, address, signature)
            Catch ex As Exception
                Throw New Exception("WalletComplete.verifySignature():" & ex.Message, ex)
            End Try
        End Function

    End Class

End Namespace
