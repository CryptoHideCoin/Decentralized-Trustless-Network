'Option Compare Text
'Option Explicit On

'Imports CHCBasicCryptographyLibrary.AreaEngine
'Imports CHCCommonLibrary.AreaEngine.Miscellaneous







'Namespace AreaWallet.Support


'    Public Class WalletAddressEngine

'        Private Const charList As String = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz/*-+!£$%/()=-_#[],.;:\"

'        Public Shared ReadOnly Property baseAddr As String = "CWA:"
'        Public Shared ReadOnly Property closeAddr As String = "//"
'        Public Shared ReadOnly Property basePvt As String = "kpvt"
'        Public Shared ReadOnly Property closeBasePvt As String = "##"

'        Public Shared Property numCharMaxFormatPrivateKey As Integer = 256
'        Public Shared Property numCharFixPublicAddress As Integer = 98


'        Public Class SingleKeyPair

'            Public Property publicKey As String = ""
'            Public Property privateKey As String = ""



'            Public Sub generatePublicKey()
'                Try
'                    publicKey = Encryption.Base58Signature.getPublicKeyFromPrivateKeyEx(privateKey)
'                Catch ex As Exception
'                    Throw New Exception("SingleWallet.generatePublicAddress():" & ex.Message, ex)
'                End Try
'            End Sub

'            Public Sub decoreDataAddress(ByVal publicValue As String)
'                Try
'                    publicKey = baseAddr & publicValue & CheckSum.create(publicValue) & closeAddr
'                    privateKey = basePvt & privateKey & CheckSum.create(privateKey) & closeBasePvt
'                Catch ex As Exception
'                    Throw New Exception("SingleWallet.decoreDataWallet():" & ex.Message, ex)
'                End Try
'            End Sub


'            Public Shared Function startAllowed(ByVal value As String) As Boolean
'                Try
'                    Return value.StartsWith(basePvt)
'                Catch ex As Exception
'                    Throw New Exception("SingleWallet.startAllowed():" & ex.Message, ex)
'                End Try
'            End Function

'            Public Shared Function endAllowed(ByVal value As String) As Boolean
'                Try
'                    Return value.EndsWith(closeBasePvt)
'                Catch ex As Exception
'                    Throw New Exception("SingleWallet.endAllowed():" & ex.Message, ex)
'                End Try
'            End Function

'            Public Shared ReadOnly Property cleanAddress(ByVal addressValue As String) As String
'                Get
'                    If (addressValue.Length <= (baseAddr & closeAddr).Length) Then
'                        Return ""
'                    End If
'                    If (addressValue.StartsWith(baseAddr)) Then
'                        Dim completeAddress As String = addressValue.Substring(baseAddr.Length, addressValue.Length - baseAddr.Length - closeAddr.Length)
'                        Dim verifyAddressValue As CHCCommonLibrary.AreaEngine.Miscellaneous.CheckSum.CompleteStructure = CheckSum.verify(completeAddress)

'                        If verifyAddressValue.checkPositive Then
'                            Return verifyAddressValue.originalText
'                        Else
'                            Return ""
'                        End If
'                    Else
'                        Return addressValue
'                    End If
'                End Get
'            End Property

'            Public Shared Function checkFormatPublicAddress(ByVal value As String) As Boolean
'                If (value.Length <= (baseAddr & closeAddr).Length) Then
'                    Return True
'                End If

'                Return (value.StartsWith(baseAddr) And value.EndsWith(closeAddr))
'            End Function

'        End Class


'        Public Class KeyPairComplete

'            Public Property official As New SingleKeyPair
'            Public Property raw As New SingleKeyPair

'        End Class


'        Private Shared ReadOnly Property getFixCharLenght() As Byte
'            Get
'                Try
'                    Return (numCharMaxFormatPrivateKey - basePvt.Length - closeBasePvt.Length - 4)
'                Catch ex As Exception
'                    Throw New Exception("WalletComplete.getFixCharLenght():" & ex.Message, ex)
'                End Try
'            End Get
'        End Property

'        Public Shared ReadOnly Property charAllowed(ByVal charValue As Char) As Boolean
'            Get
'                Try
'                    Return (charList.IndexOf(charValue) > -1)
'                Catch ex As Exception
'                    Throw New Exception("WalletComplete.charAllowed():" & ex.Message, ex)
'                End Try
'            End Get
'        End Property


'        Public Shared Function createNew() As KeyPairComplete
'            Dim result As New KeyPairComplete

'            Try

'                Dim rndChar As New Random(CInt(Date.Now.Ticks And &HFFFF))
'                Dim index As Integer = 0

'                For intC As Integer = 0 To getFixCharLenght() - 1

'                    index = rndChar.Next(0, 62)

'                    result.raw.privateKey += Right("0" & index.ToString.Trim(), 2)
'                    result.official.privateKey += charList.Substring(index, 1)

'                Next

'                result.raw.generatePublicKey()
'                result.official.decoreDataAddress(result.raw.publicKey)

'            Catch ex As Exception
'                Throw New Exception("WalletComplete.createNew():" & ex.Message, ex)
'            End Try

'            Return result
'        End Function

'        Private Shared Function createNew(ByVal privateKeyValue As String) As KeyPairComplete
'            Dim result As New KeyPairComplete

'            Try

'                Dim index As Integer = 0

'                result.official.privateKey = privateKeyValue

'                If (privateKeyValue.Length <= (basePvt & closeBasePvt).Length) Then
'                    Return result
'                End If

'                If (privateKeyValue.StartsWith(basePvt)) Then
'                    privateKeyValue = privateKeyValue.Substring(basePvt.Length, privateKeyValue.Length - basePvt.Length - 2)
'                End If

'                For Each singleChar In privateKeyValue

'                    If charAllowed(singleChar) Then

'                        index = charList.IndexOf(singleChar)
'                        result.raw.privateKey += Strings.Right("0" & index.ToString.Trim(), 2)

'                    End If

'                Next

'                result.raw.publicKey = Encryption.Base58Signature.getPublicKeyFromPrivateKeyEx(result.raw.privateKey)
'                result.official.decoreDataAddress(result.raw.publicKey)

'            Catch ex As Exception
'                Throw New Exception("WalletComplete.createNew():" & ex.Message, ex)
'            End Try

'            Return result
'        End Function

'        Public Shared Function createNew(ByVal privateKeyValue As String, Optional ByVal fromRaw As Boolean = False) As KeyPairComplete
'            Dim result As New KeyPairComplete

'            Try

'                If fromRaw Then

'                    Dim index As Integer = 0
'                    Dim doubleChar As String = ""
'                    Dim value As Integer = 0

'                    result.raw.privateKey = privateKeyValue

'                    For Each singleChar In privateKeyValue
'                        doubleChar += singleChar

'                        If (doubleChar.Length = 2) Then

'                            value = doubleChar
'                            result.official.privateKey += charList.Substring(value, 1)
'                            doubleChar = ""

'                        End If
'                    Next

'                    result.raw.publicKey = Encryption.Base58Signature.getPublicKeyFromPrivateKeyEx(result.raw.privateKey)

'                    result.official.decoreDataAddress(result.raw.publicKey)
'                Else
'                    result = createNew(privateKeyValue)
'                End If

'            Catch ex As Exception
'                Throw New Exception("WalletComplete.createNew():" & ex.Message, ex)
'            End Try

'            Return result
'        End Function

'        Public Shared Function checkPrivateKeyFormat(ByVal value As String) As String
'            Try
'                Dim privateRaw As String = ""

'                If (value.Length > 0) Then
'                    If value.StartsWith(basePvt) And value.EndsWith(closeBasePvt) Then

'                        If CheckSum.verify(value).checkPositive Then
'                            privateRaw = createNew(value).raw.privateKey
'                        End If
'                    Else
'                        privateRaw = value
'                    End If
'                End If

'                Return privateRaw
'            Catch ex As Exception
'                Throw New Exception("WalletComplete.checkPrivateKeyFormat():" & ex.Message, ex)
'            End Try
'        End Function

'        Public Shared Function createSignature(ByVal privateKey As String, ByVal message As String) As String
'            Try
'                Dim privateRaw As String = checkPrivateKeyFormat(privateKey)

'                Return Encryption.Base58Signature.getSignature(privateRaw, message)
'            Catch ex As Exception
'                Throw New Exception("WalletComplete.createSignature():" & ex.Message, ex)
'            End Try
'        End Function

'        Public Shared Function verifySignature(ByVal publicAddress As String, ByVal message As String, ByVal signature As String) As Boolean
'            Try
'                Dim address As String = SingleKeyPair.cleanAddress(publicAddress)

'                Return Encryption.Base58Signature.verifySignature(message, address, signature)
'            Catch ex As Exception
'                Throw New Exception("WalletComplete.verifySignature():" & ex.Message, ex)
'            End Try
'        End Function

'    End Class



'End Namespace