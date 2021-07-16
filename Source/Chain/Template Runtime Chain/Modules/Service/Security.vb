Option Compare Text
Option Explicit On

Imports CHCBasicCryptographyLibrary.AreaEngine
Imports CHCProtocolLibrary.AreaWallet.Support



Namespace AreaSecurity


    Module authorization


        Public Function checkClientCertification(ByVal value As String) As Boolean
            Try
                Return (AreaCommon.settings.data.clientCertificate.CompareTo(value) = 0)
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function checkSignature(ByVal value As String) As Boolean
            Try
                Dim publicAddress As String = AreaCommon.state.keys.Key(TransactionChainLibrary.AreaEngine.KeyPair.KeysEngine.KeyPair.enumWalletType.administration).publicAddress

                publicAddress = WalletAddressEngine.SingleKeyPair.cleanAddress(publicAddress)

                Return Encryption.Base58Signature.verifySignature(AreaCommon.settings.data.clientCertificate, publicAddress, value)
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function checkSignature(ByVal resultant As String, ByVal value As String) As Boolean
            Try
                Dim publicAddress As String = AreaCommon.state.keys.key(TransactionChainLibrary.AreaEngine.KeyPair.KeysEngine.KeyPair.enumWalletType.administration).publicAddress

                publicAddress = WalletAddressEngine.SingleKeyPair.cleanAddress(publicAddress)

                Return Encryption.Base58Signature.verifySignature(resultant, publicAddress, value)
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function changeCertificate(ByVal value As CHCProtocolLibrary.AreaCommon.Models.Security.changeCertificate) As Boolean
            Try
                AreaCommon.settings.data.clientCertificate = value.newCertificate
                AreaCommon.settings.save()

                AreaCommon.log.trackIntoConsole("Admin certificate change")
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function


    End Module


End Namespace
