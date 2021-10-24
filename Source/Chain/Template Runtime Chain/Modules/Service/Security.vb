Option Compare Text
Option Explicit On

Imports CHCBasicCryptographyLibrary.AreaEngine
Imports CHCProtocolLibrary.AreaWallet.Support
Imports CHCCommonLibrary.AreaCommon.Models.General
Imports CHCCommonLibrary.AreaEngine.Encryption



Namespace AreaSecurity


    Module authorization

        ''' <summary>
        ''' This method provide to check a client certification
        ''' </summary>
        ''' <param name="value"></param>
        ''' <returns></returns>
        Public Function checkClientCertification(ByVal value As String) As Boolean
            Try
                Return (AreaCommon.settings.data.clientCertificate.CompareTo(value) = 0)
            Catch ex As Exception
                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to check a signature
        ''' </summary>
        ''' <param name="value"></param>
        ''' <returns></returns>
        Public Function checkSignature(ByVal value As String) As Boolean
            Try
                Dim publicAddress As String = AreaCommon.state.keys.Key(TransactionChainLibrary.AreaEngine.KeyPair.KeysEngine.KeyPair.enumWalletType.administration).publicAddress

                publicAddress = WalletAddressEngine.SingleKeyPair.cleanAddress(publicAddress)

                Return Encryption.Base58Signature.verifySignature(AreaCommon.settings.data.clientCertificate, publicAddress, value)
            Catch ex As Exception
                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to create a signature
        ''' </summary>
        ''' <param name="request"></param>
        ''' <returns></returns>
        Public Function createSignature(ByRef request As Object) As Object
            Try
                Dim privateKeyRAW As String = AreaCommon.state.keys.key(TransactionChainLibrary.AreaEngine.KeyPair.KeysEngine.KeyPair.enumWalletType.identity).privateKey

                request.hash = request.getHash()
                request.signature = WalletAddressEngine.createSignature(privateKeyRAW, request.hash)
            Catch ex As Exception
            End Try

            Return request
        End Function

        ''' <summary>
        ''' This method provide to create a signature
        ''' </summary>
        ''' <param name="request"></param>
        ''' <returns></returns>
        Public Function createSignature(ByRef request As Object, ByVal determinateHash As Boolean) As Object
            Try
                Dim privateKeyRAW As String = AreaCommon.state.keys.key(TransactionChainLibrary.AreaEngine.KeyPair.KeysEngine.KeyPair.enumWalletType.identity).privateKey

                request.signature = WalletAddressEngine.createSignature(privateKeyRAW, HashSHA.generateSHA256(request.ToString()))
            Catch ex As Exception
            End Try

            Return request
        End Function

        ''' <summary>
        ''' This method provide to check a signature
        ''' </summary>
        ''' <param name="resultant"></param>
        ''' <param name="value"></param>
        ''' <param name="walletType"></param>
        ''' <returns></returns>
        Public Function checkSignature(ByVal resultant As String, ByVal value As String, Optional ByVal walletType As TransactionChainLibrary.AreaEngine.KeyPair.KeysEngine.KeyPair.enumWalletType = TransactionChainLibrary.AreaEngine.KeyPair.KeysEngine.KeyPair.enumWalletType.administration) As Boolean
            Try
                Dim publicAddress As String = AreaCommon.state.keys.key(walletType).publicAddress

                publicAddress = WalletAddressEngine.SingleKeyPair.cleanAddress(publicAddress)

                Return Encryption.Base58Signature.verifySignature(resultant, publicAddress, value)
            Catch ex As Exception
                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to check a signature
        ''' </summary>
        ''' <param name="resultant"></param>
        ''' <param name="value"></param>
        ''' <param name="publicAddress"></param>
        ''' <returns></returns>
        Public Function checkSignature(ByVal resultant As String, ByVal value As String, ByVal publicAddress As String) As Boolean
            Try
                publicAddress = WalletAddressEngine.SingleKeyPair.cleanAddress(publicAddress)

                Return Encryption.Base58Signature.verifySignature(resultant, publicAddress, value)
            Catch ex As Exception
                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to check a network data
        ''' </summary>
        ''' <param name="netWorkHash"></param>
        ''' <param name="chainHash"></param>
        ''' <returns></returns>
        Public Function checkNetwork(ByVal netWorkHash As String, ByVal chainHash As String) As Boolean
            Try
                If (netWorkHash.CompareTo(AreaCommon.state.runtimeState.activeNetwork.networkName.hash) = 0) Then
                    If (chainHash.CompareTo(AreaCommon.state.runtimeState.activeChain.name.hash) = 0) Then
                        Return True
                    End If
                End If

                Return False
            Catch ex As Exception
                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to check a network data
        ''' </summary>
        ''' <param name="request"></param>
        ''' <returns></returns>
        Public Function checkNetwork(ByRef request As Object) As Boolean
            Try
                Return checkNetwork(request.networkHash, request.chainHash)
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
                Dim key As TransactionChainLibrary.AreaEngine.KeyPair.KeysEngine.KeyPair = AreaCommon.state.keys.key(TransactionChainLibrary.AreaEngine.KeyPair.KeysEngine.KeyPair.enumWalletType.identity)
                Dim privateKey As String = key.privateKey

                value.masterNodePublicAddress = key.publicAddress
                value.integrityTransactionChain = AreaCommon.state.currentService.integrityTransactionChain
                value.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete
                value.responseTime = CHCCommonLibrary.AreaEngine.Miscellaneous.atMomentGMT()

                value.signature = WalletAddressEngine.createSignature(privateKey, HashSHA.generateSHA256(value.ToString()))
            Catch ex As Exception
            End Try

            Return value
        End Function

        ''' <summary>
        ''' This method provide to change a certificate
        ''' </summary>
        ''' <param name="value"></param>
        ''' <returns></returns>
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

        ''' <summary>
        ''' This method provide to set identity key pair
        ''' </summary>
        ''' <param name="value"></param>
        ''' <returns></returns>
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
