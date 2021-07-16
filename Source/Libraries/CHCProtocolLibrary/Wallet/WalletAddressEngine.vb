Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.Encryption



Namespace AreaWallet.Support

    Public Class WalletAddressDataEngine

        Private Enum EnumPositionField
            name = 0
            authorizationKey = 2
            publicAddress = 4
            privateKey = 6
            note = 8
        End Enum


        Public Class WalletAddressData

            Public name As String = ""
            Public authorizationKey As String = ""
            Public publicRAWAddress As String = ""
            Public privateRAWKey As String = ""
            Public note As String = ""

        End Class

        Private Const separator As String = "=:-:="

        Public Property fileName As String = ""
        Public Property securityKey As String = ""
        Public Property data As New WalletAddressData


        Public Function load() As Boolean
            Dim dataFile As String
            Dim elements
            Dim privateNumber As New Numerics.BigInteger
            Try
                If (securityKey.Length > 0) Then
                    dataFile = AES.decrypt(IO.File.ReadAllText(fileName), securityKey())
                Else
                    dataFile = IO.File.ReadAllText(fileName)
                End If

                elements = dataFile.Split(separator)

                If (UBound(elements) = 8) Then
                    data.name = elements(EnumPositionField.name)
                    data.authorizationKey = elements(EnumPositionField.authorizationKey)
                    If Numerics.BigInteger.TryParse(elements(EnumPositionField.privateKey), privateNumber) Then
                        data.privateRAWKey = elements(EnumPositionField.privateKey)
                    End If
                    data.publicRAWAddress = elements(EnumPositionField.publicAddress)
                    data.note = elements(EnumPositionField.note)

                    Return True
                End If
                Return False
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function save() As Boolean
            Dim dataFile As String
            Try
                dataFile = data.name & separator & data.authorizationKey & separator & data.publicRAWAddress & separator & data.privateRAWKey & separator & data.note

                If (securityKey.Length > 0) Then
                    dataFile = AES.encrypt(dataFile, securityKey())
                End If

                IO.File.WriteAllText(fileName, dataFile)

                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

    End Class

End Namespace