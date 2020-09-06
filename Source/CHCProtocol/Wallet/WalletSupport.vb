Option Compare Text
Option Explicit On







Namespace AreaWallet.Support


    Public Class WalletAddressEngine

        Private Const charList As String = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz/*-+!£$%&/()=?-_#@[],.;:\"

        Public Shared ReadOnly Property baseAddr As String = "CHCDT"
        Public Shared ReadOnly Property closeAddr As String = "//"
        Public Shared ReadOnly Property basePvt As String = "kpvt"
        Public Shared ReadOnly Property closeBasePvt As String = "##"

        Public Shared Property numCharMaxFormatPrivateKey As Integer = 256
        Public Shared Property numCharFixPublicAddress As Integer = 95




        Public Class SingleWallet

            Public Property publicAddress As String = ""
            Public Property privateKey As String = ""




            Public Sub generatePublicAddress()

                Try

                    publicAddress = CHCEngine.Encryption.Base58Signature.getPublicKeyFromPrivateKeyEx(privateKey)

                Catch ex As Exception

                    Throw New Exception("SingleWallet.generatePublicAddress():" & ex.Message, ex)

                End Try

            End Sub

            Public Sub decoreDataWallet(ByVal publicValue As String)

                Try

                    publicAddress = baseAddr & publicValue & closeAddr
                    privateKey = basePvt & privateKey & closeBasePvt

                Catch ex As Exception

                    Throw New Exception("SingleWallet.decoreDataWallet():" & ex.Message, ex)

                End Try

            End Sub

            Public Shared Function startAllowed(ByVal value As String) As Boolean

                Try

                    Return value.StartsWith(basePvt)

                Catch ex As Exception

                    Throw New Exception("SingleWallet.startAllowed():" & ex.Message, ex)

                End Try

            End Function


            Public Shared Function endAllowed(ByVal value As String) As Boolean

                Try

                    Return value.EndsWith(closeBasePvt)

                Catch ex As Exception

                    Throw New Exception("SingleWallet.endAllowed():" & ex.Message, ex)

                End Try


            End Function


            Public Shared ReadOnly Property cleanAddress(ByVal addressValue As String) As String
                Get

                    If (addressValue.Length <= (baseAddr & closeAddr).Length) Then

                        Return ""

                    End If

                    If (addressValue.StartsWith(baseAddr)) Then

                        Return addressValue.Substring(baseAddr.Length, addressValue.Length - baseAddr.Length - closeAddr.Length)

                    Else

                        Return addressValue

                    End If

                End Get
            End Property


        End Class



        Public Class WalletComplete

            Public Property official As New SingleWallet
            Public Property raw As New SingleWallet

        End Class


        Private Shared ReadOnly Property getFixCharLenght() As Byte
            Get
                Try

                    Return (numCharMaxFormatPrivateKey - basePvt.Length - closeBasePvt.Length)

                Catch ex As Exception

                    Throw New Exception("WalletComplete.getFixCharLenght():" & ex.Message, ex)

                End Try

            End Get
        End Property


        Public Shared ReadOnly Property charAllowed(ByVal charValue As Char) As Boolean

            Get

                Try

                    Return (charList.IndexOf(charValue) > -1)

                Catch ex As Exception

                    Throw New Exception("WalletComplete.charAllowed():" & ex.Message, ex)

                End Try

            End Get

        End Property


        Public Shared Function createNew() As WalletComplete

            Dim result As New WalletComplete

            Try

                Dim rndChar As New Random(CInt(Date.Now.Ticks And &HFFFF))
                Dim index As Integer = 0

                For intC As Integer = 0 To getFixCharLenght() - 1

                    index = rndChar.Next(0, 62)

                    result.raw.privateKey += Right("0" & index.ToString.Trim(), 2)
                    result.official.privateKey += charList.Substring(index, 1)

                Next

                result.raw.generatePublicAddress()
                result.official.decoreDataWallet(result.raw.publicAddress)

            Catch ex As Exception

                Throw New Exception("WalletComplete.createNew():" & ex.Message, ex)

            End Try

            Return result

        End Function


        Private Shared Function createNew(ByVal privateKeyValue As String) As WalletComplete

            Dim result As New WalletComplete

            Try

                Dim index As Integer = 0

                result.official.privateKey = privateKeyValue

                If (privateKeyValue.Length <= (basePvt & closeBasePvt).Length) Then
                    Return result
                End If

                If (privateKeyValue.StartsWith(basePvt)) Then
                    privateKeyValue = privateKeyValue.Substring(basePvt.Length, privateKeyValue.Length - basePvt.Length - 2)
                End If

                For Each singleChar In privateKeyValue

                    If charAllowed(singleChar) Then

                        index = charList.IndexOf(singleChar)
                        result.raw.privateKey += Strings.Right("0" & index.ToString.Trim(), 2)

                    End If

                Next

                result.raw.publicAddress = CHCEngine.Encryption.Base58Signature.getPublicKeyFromPrivateKeyEx(result.raw.privateKey)
                result.official.decoreDataWallet(result.raw.publicAddress)

            Catch ex As Exception

                Throw New Exception("WalletComplete.createNew():" & ex.Message, ex)

            End Try

            Return result

        End Function


        Public Shared Function createNew(ByVal privateKeyValue As String, Optional ByVal fromRaw As Boolean = False) As WalletComplete

            Dim result As New WalletComplete

            Try

                If fromRaw Then

                    Dim index As Integer = 0
                    Dim doubleChar As String = ""
                    Dim value As Integer = 0

                    result.raw.privateKey = privateKeyValue

                    For Each singleChar In privateKeyValue

                        doubleChar += singleChar

                        If (doubleChar.Length = 2) Then

                            value = doubleChar
                            result.official.privateKey += charList.Substring(value, 1)
                            doubleChar = ""

                        End If

                    Next

                    result.official.privateKey = basePvt & result.official.privateKey & closeBasePvt
                    result.raw.publicAddress = CHCEngine.Encryption.Base58Signature.getPublicKeyFromPrivateKeyEx(result.raw.privateKey)
                    result.official.decoreDataWallet(result.raw.publicAddress)

                Else

                    result = createNew(privateKeyValue)

                End If

            Catch ex As Exception

                Throw New Exception("WalletComplete.createNew():" & ex.Message, ex)

            End Try

            Return result

        End Function


        Public Shared Function createSignature(ByVal privateKey As String, ByVal message As String) As String

            Try

                Dim privateRaw As String = ""

                If privateKey.StartsWith(basePvt) And privateKey.EndsWith(closeBasePvt) Then

                    With createNew(privateKey)

                        privateRaw = .raw.privateKey

                    End With

                Else

                    privateRaw = privateKey

                End If

                Return CHCEngine.Encryption.Base58Signature.getSignature(privateRaw, message)

            Catch ex As Exception

                Throw New Exception("WalletComplete.createSignature():" & ex.Message, ex)

            End Try


        End Function


        Public Shared Function verifySignature(ByVal publicAddress As String, ByVal message As String, ByVal signature As String) As Boolean

            Try

                Dim address As String = SingleWallet.cleanAddress(publicAddress)

                Return CHCEngine.Encryption.Base58Signature.verifySignature(message, address, signature)

            Catch ex As Exception

                Throw New Exception("WalletComplete.verifySignature():" & ex.Message, ex)

            End Try

        End Function


    End Class



    'Public Class KeyPair2

    '    Private Const charList As String = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz/*-+!£$%&/()=?-_#@[],.;:\"

    '    Public Shared ReadOnly Property baseAddr As String = ""
    '    Public Shared ReadOnly Property closeAddr As String = ""
    '    Public Shared ReadOnly Property basePvt As String = ""
    '    Public Shared ReadOnly Property closeBasePvt As String = ""

    '    Public Property publicKey As String = String.Empty
    '    Public Property privateKey As String = String.Empty

    '    Public Shared Property numCharFormatPrivateKey As Integer = 256
    '    Public Shared Property numCharPublicAddress As Integer = 95
    '    Public Shared Property numCharPrivateKey As Integer = 256







    '    Public Shared Function createNew() As KeyPair

    '        Dim key As New KeyPair

    '        Try

    '            Dim userPK As String = ""
    '            Dim internalPK As String = ""
    '            Dim rndChar As New Random(CInt(Date.Now.Ticks And &HFFFF))
    '            Dim index As Integer = 0

    '            For intC As Integer = 0 To 249

    '                index = rndChar.Next(0, 83)
    '                userPK += charList.Substring(index, 1)
    '                internalPK += Strings.Right("0" & index.ToString.Trim(), 2)

    '            Next

    '            'key.publicKey = baseAddr & CHCEngine.Encryption.Base58Signature.getPublicKeyFromPrivateKeyEx(internalPK) & closeAddr
    '            key.publicKey = CHCEngine.Encryption.Base58Signature.getPublicKeyFromPrivateKeyEx(internalPK)
    '            key.privateKey = userPK

    '        Catch ex As Exception

    '            Throw New Exception("Keypair.createNew():" & ex.Message, ex)

    '        End Try

    '        Return key

    '    End Function


    '    Public Shared Function createNew(ByVal seedValue As String) As KeyPair

    '        If seedValue.Length > 250 Then

    '            Throw New Exception("Keypair.createNew(): Seed overfloat")

    '            Return New KeyPair

    '        End If

    '        Dim key As New KeyPair

    '        Try

    '            Dim userPK As String = ""
    '            Dim internalPK As String = ""
    '            Dim rndChar As New Random(CInt(Date.Now.Ticks And &HFFFF))
    '            Dim index As Integer = 0

    '            For Each singleChar In seedValue

    '                If charAllowed(singleChar) Then

    '                    userPK += singleChar
    '                    index = charList.IndexOf(singleChar)
    '                    internalPK += Strings.Right("0" & index.ToString.Trim(), 2)

    '                End If

    '            Next

    '            key.publicKey = baseAddr & CHCEngine.Encryption.Base58Signature.getPublicKeyFromPrivateKeyEx(internalPK) & closeAddr
    '            key.privateKey = basePvt & userPK & closeBasePvt

    '        Catch ex As Exception

    '            Throw New Exception("Keypair.createNew():" & ex.Message, ex)

    '        End Try

    '        Return key

    '    End Function


    '    Public Shared Function generatePublicKeyFromPrivateKey(ByVal privateKey As String) As String

    '        Try

    '            Dim userPK As String = "", internalPK As String = ""
    '            Dim rndChar As New Random(CInt(Date.Now.Ticks And &HFFFF))
    '            Dim index As Integer = 0

    '            For Each key In privateKey

    '                index = charList.IndexOf(key)
    '                internalPK += Strings.Right("0" & index.ToString.Trim(), 2)

    '            Next

    '            Return baseAddr & CHCEngine.Encryption.Base58Signature.getPublicKeyFromPrivateKeyEx(internalPK) & closeAddr

    '        Catch ex As Exception

    '            Throw New Exception("Keypair.generatePublicKeyFromPrivateKey():" & ex.Message, ex)

    '        End Try

    '        Return ""

    '    End Function


    '    Public Shared Function generatePublicKeyFromPrivateRAW(ByVal value As String) As String

    '        Try

    '            Return CHCEngine.Encryption.Base58Signature.getPublicKeyFromPrivateKeyEx(value)

    '        Catch ex As Exception

    '            Throw New Exception("Keypair.generatePublicKeyFromPrivateRAW():" & ex.Message, ex)

    '        End Try

    '        Return ""

    '    End Function


    '    Public Shared Function generateKeyFromRaw(ByVal publicValue As String, ByVal privateValue As String) As KeyPair

    '        Dim key As New KeyPair

    '        Dim privateNumber As New Numerics.BigInteger

    '        If Not Numerics.BigInteger.TryParse(privateValue, privateNumber) Then

    '            Throw New Exception("Keypair.generateKeyFromRaw(): privateValue is not a numeric")

    '            Return key

    '        End If

    '        Try

    '            Dim doubleChar As String = ""
    '            Dim value As Integer = 0

    '            For Each singleChar In privateValue

    '                doubleChar += singleChar

    '                If (doubleChar.Length = 2) Then

    '                    value = doubleChar

    '                    key.privateKey += charList.Substring(value, 1)

    '                    doubleChar = ""

    '                End If

    '            Next

    '            key.publicKey = baseAddr & CHCEngine.Encryption.Base58Signature.getPublicKeyFromPrivateKeyEx(privateValue) & closeAddr
    '            key.privateKey = basePvt & key.privateKey & closeBasePvt

    '        Catch ex As Exception

    '            Throw New Exception("Keypair.generateKeyFromRaw():" & ex.Message, ex)

    '        End Try

    '        Return key

    '    End Function


    '    Public Shared Function getPrivateRawFromKey(ByVal value As String) As String

    '        Try

    '            Dim result As String = ""

    '            If (value.Length <= (basePvt & closeBasePvt).Length) Then

    '                Return value

    '            End If

    '            If (value.StartsWith(basePvt)) Then
    '                value = value.Substring(basePvt.Length, value.Length - basePvt.Length - 2)
    '            End If

    '            For Each value In value
    '                result += Strings.Right("0" & charList.IndexOf(value), 2)
    '            Next

    '            Return result

    '        Catch ex As Exception

    '            Throw New Exception("Keypair.getPrivateRawFromKey():" & ex.Message, ex)

    '        End Try

    '    End Function


    '    Public Shared Function getPublicRawFromComplete(ByVal value As String) As String

    '        Try

    '            Dim key As New KeyPair
    '            Dim internalPK As String = ""

    '            If (value.Length <= (baseAddr & closeAddr).Length) Then

    '                Return ""

    '            End If

    '            If (value.StartsWith(baseAddr)) Then
    '                Return value.Substring(baseAddr.Length, value.Length - baseAddr.Length - 2)
    '            End If

    '        Catch ex As Exception

    '            Throw New Exception("Keypair.getPublicRawFromComplete():" & ex.Message, ex)

    '        End Try

    '        Return ""

    '    End Function


    '    Public Shared Function decode(ByVal KEYEncrypted As KeyPair) As KeyPair

    '        Try

    '            Dim key As New KeyPair
    '            Dim internalPK As String = ""

    '            If (KEYEncrypted.publicKey.Length <= (baseAddr & closeAddr).Length) Or
    '               (KEYEncrypted.privateKey.Length <= (basePvt & closeBasePvt).Length) Then

    '                Return key

    '            End If

    '            If (KEYEncrypted.publicKey.StartsWith(baseAddr)) Then
    '                key.publicKey = KEYEncrypted.publicKey
    '            End If

    '            If (KEYEncrypted.privateKey.StartsWith(basePvt)) Then
    '                key.privateKey = KEYEncrypted.privateKey
    '            End If

    '            For Each value In key.privateKey
    '                internalPK += Strings.Right("0" & charList.IndexOf(value), 2)
    '            Next

    '            key.privateKey = internalPK

    '            Return key

    '        Catch ex As Exception

    '            Throw New Exception("Keypair.decode():" & ex.Message, ex)

    '        End Try

    '    End Function


    '    Public Shared Function startAllowed(ByVal value As String) As Boolean

    '        Return value.StartsWith(basePvt)

    '    End Function


    '    Public Shared Function endAllowed(ByVal value As String) As Boolean

    '        Return value.EndsWith(closeBasePvt)

    '    End Function


    '    Public Shared Function charAllowed(ByVal value As Char) As Boolean

    '        Return (charList.IndexOf(value) > -1)

    '    End Function


    'End Class


End Namespace