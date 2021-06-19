'Option Compare Text
'Option Explicit On

'Imports CHCCommonLibrary.AreaEngine.Encryption


'Public Class WalletAddressEngine

'    Public Class WalletAddressData

'        Public name As String = ""
'        Public authorizationKey As String = ""
'        Public privateRAWKey As String = ""

'    End Class

'    Private Const separator As String = "=:-:="

'    Public Property fileName As String = ""
'    Public Property securityKey As String = ""
'    Public Property data As New WalletAddressData


'    Public Function load() As Boolean
'        Dim dataFile As String
'        Dim elements
'        Dim privateNumber As New Numerics.BigInteger
'        Try
'            If (securityKey.Length > 0) Then
'                dataFile = AES.decrypt(IO.File.ReadAllText(fileName), securityKey())
'            Else
'                dataFile = IO.File.ReadAllText(fileName)
'            End If

'            elements = dataFile.Split(separator)

'            If (UBound(elements) > 1) Then
'                data.name = elements(0)
'                data.authorizationKey = elements(2)

'                If Numerics.BigInteger.TryParse(elements(4), privateNumber) Then
'                    data.privateRAWKey = elements(4)
'                End If

'                Return True
'            Else
'                Return False
'            End If
'        Catch ex As Exception
'            Return False
'        End Try
'    End Function

'    Public Function save() As Boolean
'        Dim dataFile As String
'        Try
'            dataFile = data.name & separator & data.authorizationKey & separator & data.privateRAWKey

'            If (securityKey.Length > 0) Then
'                dataFile = AES.encrypt(dataFile, securityKey())
'            End If

'            IO.File.WriteAllText(fileName, dataFile)

'            Return True
'        Catch ex As Exception
'            Return False
'        End Try
'    End Function

'End Class
