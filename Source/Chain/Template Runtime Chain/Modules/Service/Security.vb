Option Compare Text
Option Explicit On

Imports CHCBasicCryptographyLibrary.AreaEngine
Imports CHCProtocolLibrary.AreaWallet.Support
Imports CHCCommonLibrary.AreaCommon.Models.General
Imports CHCCommonLibrary.AreaEngine.Encryption



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

        Public Function checkSignature(ByVal resultant As String, ByVal value As String, Optional ByVal walletType As TransactionChainLibrary.AreaEngine.KeyPair.KeysEngine.KeyPair.enumWalletType = TransactionChainLibrary.AreaEngine.KeyPair.KeysEngine.KeyPair.enumWalletType.administration) As Boolean
            Try
                Dim publicAddress As String = AreaCommon.state.keys.key(walletType).publicAddress

                publicAddress = WalletAddressEngine.SingleKeyPair.cleanAddress(publicAddress)

                Return Encryption.Base58Signature.verifySignature(resultant, publicAddress, value)
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function checkSignature(ByVal resultant As String, ByVal value As String, ByVal publicAddress As String) As Boolean
            Try
                publicAddress = WalletAddressEngine.SingleKeyPair.cleanAddress(publicAddress)

                Return Encryption.Base58Signature.verifySignature(resultant, publicAddress, value)
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function checkNetwork(ByVal netWorkHash As String, ByVal chainHash As String) As Boolean
            Try
                If (netWorkHash.CompareTo(AreaCommon.state.runtimeState.activeNetwork.networkName.recordHash) = 0) Then
                    If (chainHash.CompareTo(AreaCommon.state.runtimeState.activeChain.name.recordHash) = 0) Then
                        Return True
                    End If
                End If

                Return False
            Catch ex As Exception
                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to complete a response
        ''' </summary>
        ''' <param name="value"></param>
        ''' <returns></returns>
        Public Function completeResponse(ByRef value As Object, ByVal requestSignature As String) As Object
            Try
                Dim toString As String
                Dim toHash As String
                Dim key As TransactionChainLibrary.AreaEngine.KeyPair.KeysEngine.KeyPair = AreaCommon.state.keys.key(TransactionChainLibrary.AreaEngine.KeyPair.KeysEngine.KeyPair.enumWalletType.identity)
                Dim privateKey As String = key.privateKey

                value.masterNodePublicAddress = key.publicAddress
                value.integrityTransactionChain = AreaCommon.state.currentService.integrityTransactionChain
                value.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete
                value.responseTime = CHCCommonLibrary.AreaEngine.Miscellaneous.atMomentGMT()

                toString = RemoteResponse.determinateStringObject(value) & requestSignature
                toHash = HashSHA.generateSHA256(toString)

                value.signature = WalletAddressEngine.createSignature(privateKey, toHash)
            Catch ex As Exception
            End Try

            Return value
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

        Public Function setIdentityKeyPair(ByVal value As CHCProtocolLibrary.AreaCommon.Models.Security.setIdentityKeyPairModel) As Boolean
            Try
                AreaCommon.state.keys.addNew(TransactionChainLibrary.AreaEngine.KeyPair.KeysEngine.KeyPair.enumWalletType.identity, value.publicAddress, value.privateKey)

                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function


    End Module


End Namespace
