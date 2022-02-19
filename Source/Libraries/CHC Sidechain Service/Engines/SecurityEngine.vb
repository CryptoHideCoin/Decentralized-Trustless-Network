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
                Return (AreaCommon.Main.environment.settings.clientCertificate.CompareTo(value) = 0)
            Catch ex As Exception
                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to check a signature
        ''' </summary>
        ''' <param name="value"></param>
        ''' <returns></returns>
        Public Function checkSignature(ByVal value As String, Optional ByVal keyWord As String = "") As Boolean
            Try
                Dim publicAddress As String = AreaCommon.Main.environment.keys.administration.public

                publicAddress = WalletAddressEngine.SingleKeyPair.cleanAddress(publicAddress)

                If (keyWord.Length = 0) Then
                    keyWord = AreaCommon.Main.environment.settings.clientCertificate
                End If

                Return Encryption.Base58Signature.verifySignature(keyWord, publicAddress, value)
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
                Dim privateKeyRAW As String = AreaCommon.Main.environment.keys.identity.private

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
                Dim privateKeyRAW As String = AreaCommon.Main.environment.keys.identity.private

                If determinateHash Then
                    request.hash = request.getHash()
                End If

                request.signature = WalletAddressEngine.createSignature(privateKeyRAW, HashSHA.generateSHA256(request.ToString()))
            Catch ex As Exception
            End Try

            Return request
        End Function

        ''' <summary>
        ''' This method provide to create a signature from a single hash from Identity keypair
        ''' </summary>
        ''' <param name="hash"></param>
        ''' <returns></returns>
        Public Function createSignature(ByRef hash As String) As String
            Try
                Dim privateKeyRAW As String = AreaCommon.Main.environment.keys.identity.private

                Return WalletAddressEngine.createSignature(privateKeyRAW, hash)
            Catch ex As Exception
                Return ""
            End Try
        End Function

        ''' <summary>
        ''' This method provide to check a signature
        ''' </summary>
        ''' <param name="resultant"></param>
        ''' <param name="value"></param>
        ''' <param name="walletType"></param>
        ''' <returns></returns>
        Public Function checkSignature(ByVal resultant As String, ByVal value As String, ByVal walletType As AreaEngine.Keys.KeysEngine.KeyPair) As Boolean
            Try
                Dim publicAddress As String = walletType.public

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
                ''' TODO: Rebuild this code

                'If (netWorkHash.CompareTo(AreaCommon.state.runtimeState.activeNetwork.networkName.hash) = 0) Then
                '    If (chainHash.CompareTo(AreaCommon.state.runtimeState.activeChain.name.hash) = 0) Then
                '        Return True
                '    End If
                'End If

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
                ''' TODO: Review this code

                Return checkNetwork(request.networkHash, request.chainHash)
            Catch ex As Exception
                Return False
            End Try
        End Function

        ''' TODO: Move into Primary Library

        '''' <summary>
        '''' This method provide to complete a response
        '''' </summary>
        '''' <param name="value"></param>
        '''' <returns></returns>
        'Public Function completeResponse(ByRef value As Object, ByVal requestSignature As String) As Object
        '    Try
        '        Dim key As AreaEngine.Keys.KeysEngine.KeyPair = AreaCommon.Main.environment.keys.identity
        '        Dim privateKey As String = AreaCommon.Main.environment.keys.identity.private

        '        value.masterNodePublicAddress = AreaCommon.Main.environment.keys.identity.public
        '        value.integrityTransactionChain = AreaCommon.state.currentService.integrityTransactionChain
        '        value.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete
        '        value.responseTime = CHCCommonLibrary.AreaEngine.Miscellaneous.atMomentGMT()

        '        value.signature = WalletAddressEngine.createSignature(privateKey, HashSHA.generateSHA256(value.ToString()))
        '    Catch ex As Exception
        '    End Try

        '    Return value
        'End Function

        ''' <summary>
        ''' This method provide to change a certificate
        ''' </summary>
        ''' <param name="value"></param>
        ''' <returns></returns>
        Public Function changeCertificate(ByVal value As CHCProtocolLibrary.AreaCommon.Models.Security.changeCertificate) As Boolean
            Try
                AreaCommon.Main.environment.settings.clientCertificate = value.newCertificate

                If AreaCommon.Main.environment.saveSettings() Then
                    AreaCommon.Main.environment.log.trackIntoConsole("Admin certificate change")
                End If

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
        Public Function setIdentityKeyPair(ByVal value As AreaEngine.Keys.KeysEngine.KeyPair) As Boolean
            Try
                AreaCommon.Main.environment.keys.identity.private = value.private
                AreaCommon.Main.environment.keys.identity.public = value.public

                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

    End Module

End Namespace
