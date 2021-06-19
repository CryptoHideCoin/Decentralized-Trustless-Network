Option Explicit On
Option Compare Text


Namespace AreaEngine.KeyPair

    Public Class KeysEngine

        Public Class KeyPair

            Public Enum enumWalletType
                notDefined
                administration
                identity
                warranty
                refund
            End Enum

            Public Property walletType As enumWalletType = enumWalletType.notDefined
            Public Property publicAddress As String = ""
            Public Property privateKey As String = ""

        End Class

        Private _keys As New Dictionary(Of KeyPair.enumWalletType, KeyPair)


        Public Function addNew(ByVal typeKey As KeyPair.enumWalletType, ByVal publicWalletID As String, ByVal privateWalletKey As String) As KeyPair
            Dim result As New KeyPair

            Try
                result.walletType = typeKey
                result.publicAddress = publicWalletID
                result.privateKey = privateWalletKey

                _keys.Add(typeKey, result)
            Catch ex As Exception
            End Try

            Return result
        End Function


        Public Function key(ByVal typeKey As KeyPair.enumWalletType) As KeyPair
            Try
                If _keys.ContainsKey(typeKey) Then
                    Return _keys(typeKey)
                End If
            Catch ex As Exception
            End Try

            Return New KeyPair
        End Function


    End Class

End Namespace