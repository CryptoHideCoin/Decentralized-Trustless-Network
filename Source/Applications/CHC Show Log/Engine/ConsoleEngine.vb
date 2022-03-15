Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.CommandLine
Imports CHCCommonLibrary.AreaEngine.Communication
Imports CHCCommonLibrary.AreaEngine.DataFileManagement.Encrypted
Imports CHCProtocolLibrary.AreaWallet.Support
Imports CHCProtocolLibrary.AreaEngine.Keys
Imports CHCModels.AreaModel.Administration.Security
Imports CHCModels.AreaModel.Administration.Settings
Imports CHCModels.AreaModel.Network.Response
Imports CHCModels.AreaModel.Log





Namespace AreaCommon

    ''' <summary>
    ''' This static class run the application
    ''' </summary>
    Class ConsoleEngine

        Private Property _DataPath As String = ""
        Private Property _Service As String = ""
        Private Property _Password As String = ""
        Private Property _SecurityKey As String = ""
        Private Property _Address As String = ""
        Private Property _AccessKey As String = ""
        Private Property _SecurityToken As String = ""
        Private Property _Mode As String = "console"
        Private Property _Pause As Boolean = False
        Private Property _Keys As New KeysEngine

        Private Property _DataSettings As SettingsSidechainService


        ''' <summary>
        ''' This method provide to read a settings
        ''' </summary>
        ''' <returns></returns>
        Private Function readSettings() As Boolean
            Try
                Dim completeFileName As String = ""

                Dim engineFile As New BaseFile(Of SettingsSidechainService)

                completeFileName = IO.Path.Combine(_DataPath, "Settings")
                completeFileName = IO.Path.Combine(completeFileName, _Service & ".Settings")

                If Not IO.File.Exists(completeFileName) Then
                    Console.WriteLine(completeFileName & " not found.")

                    Return False
                End If

                If (_Password.Length > 0) Then
                    engineFile.cryptoKEY = _Password
                Else
                    engineFile.noCrypt = True
                End If

                engineFile.fileName = completeFileName

                If engineFile.read() Then
                    _DataSettings = engineFile.data

                    Return True
                Else
                    Console.WriteLine("Error during readSettings")

                    Return False
                End If
            Catch ex As Exception
                Console.WriteLine("Error during readSettings - " & ex.Message)

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to test a settings
        ''' </summary>
        ''' <param name="value"></param>
        ''' <returns></returns>
        Private Function manageParameters(ByRef value As CommandStructure) As Boolean
            Try
                If value.haveParameter("dataPath") Then
                    _DataPath = value.parameterValue("dataPath")
                End If
                If value.haveParameter("service") Then
                    _Service = value.parameterValue("service")
                End If
                If value.haveParameter("password") Then
                    _Password = value.parameterValue("password")
                End If
                If value.haveParameter("mode") Then
                    _Mode = value.parameterValue("mode")
                End If
                If value.haveParameter("securityKey") Then
                    _SecurityKey = value.parameterValue("securityKey")
                End If
                If value.haveParameter("address") Then
                    _Address = value.parameterValue("address")
                End If
                _Pause = value.haveParameter("pause")

                Return (_DataPath.Length > 0) And (_Service.Length > 0)
            Catch ex As Exception
                Console.WriteLine("Error during testSettings - " & ex.Message)

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to build a URL
        ''' </summary>
        ''' <param name="api"></param>
        ''' <returns></returns>
        Public Function buildURL(ByVal api As String) As String
            Dim url As String = ""
            Try
                Dim proceed As Boolean = True

                If proceed Then
                    If _DataSettings.secureChannel Then
                        url += "https"
                    Else
                        url += "http"
                    End If
                End If
                If proceed Then
                    If (_Address.Length = 0) Then
                        _Address += "localhost:" & _DataSettings.servicePort
                    End If
                End If
                If proceed Then
                    url += "://" & _Address & "/api"
                End If
                If proceed Then
                    If (_DataSettings.serviceID.Length > 0) Then
                        url += "/" & _DataSettings.serviceID & api
                    Else
                        url += api
                    End If
                End If
            Catch ex As Exception
            End Try

            Return url
        End Function

        ''' <summary>
        ''' This method provide to get a service
        ''' </summary>
        ''' <returns></returns>
        Private Function serviceFound() As Boolean
            Try
                Dim remote As New ProxyWS(Of RemoteResponse)
                Dim proceed As Boolean = True

                If proceed Then
                    remote.url = buildURL("/service/test/")
                End If
                If proceed Then
                    proceed = (remote.getData() = "")
                End If
                If proceed Then
                    Return (remote.data.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete)
                End If

                Return proceed
            Catch ex As Exception
                Console.WriteLine("Error during serviceFound - " & ex.Message)

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide a read a wallet address from file
        ''' </summary>
        ''' <param name="uuid"></param>
        ''' <returns></returns>
        Private Function readWalletAddress(ByVal uuid As String, ByVal pathKeyStore As String) As KeysEngine.KeyPair
            Try
                Dim engine As New WalletAddressDataEngine
                Dim dataLoaded As Boolean = False
                Dim securityValue As String = ""
                Dim result As New KeysEngine.KeyPair

                engine.fileName = IO.Path.Combine(pathKeyStore, uuid, "walletAddress.private")

                If (_SecurityKey.Length > 0) Then
                    engine.securityKey = _SecurityKey
                End If

                If Not engine.load() Then
                    Console.WriteLine("Error during load wallet")

                    Return New KeysEngine.KeyPair
                Else
                    With WalletAddressEngine.createNew(engine.data.privateRAWKey, True).raw
                        result.public = .publicKey
                        result.private = .privateKey
                    End With

                    Return result
                End If
            Catch ex As Exception
                Console.WriteLine("Error during read wallet address:" & ex.Message)

                Return New KeysEngine.KeyPair
            End Try
        End Function

        ''' <summary>
        ''' This method provide to Read Admin Keystore
        ''' </summary>
        ''' <returns></returns>
        Public Function readAdminKeyStore() As Boolean
            Try
                Dim uuidWallet As String = ""
                Dim pathKeyStore As String = IO.Path.Combine(_DataPath, "Keystore")

                If (_DataSettings.publicAddress.Length >= 11) Then
                    If _DataSettings.publicAddress.StartsWith("keystoreid:") Then
                        Try
                            Dim keyStoreManager = New KeyStoreEngine

                            uuidWallet = _DataSettings.publicAddress.Substring(11)

                            keyStoreManager.fileName = IO.Path.Combine(pathKeyStore, "keyAddress.list")

                            If keyStoreManager.read() Then
                                For Each item In keyStoreManager.data
                                    If (item.uuid.CompareTo(uuidWallet) = 0) Then
                                        _Keys.administration = readWalletAddress(item.uuid, pathKeyStore)

                                        Return (_Keys.administration.public.Length > 0)
                                    End If
                                Next
                            End If
                        Catch ex As Exception
                            Console.WriteLine("Error during Load data keyStore :" & ex.Message)

                            Return False
                        End Try
                    End If
                End If

                Console.WriteLine("Keypair not found")

                Return True
            Catch ex As Exception
                Console.WriteLine("Error during Load data information:" & ex.Message)

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method sign a certificate with private key
        ''' </summary>
        ''' <returns></returns>
        Private Function signCertificate() As String
            Try
                Dim privateKey As String = _Keys.administration.private
                Dim certificate As String = _DataSettings.clientCertificate

                Return WalletAddressEngine.createSignature(_Keys.administration.private, certificate)
            Catch ex As Exception
                Console.WriteLine("Error during signCertificate:" & ex.Message)

                Return ""
            End Try
        End Function

        ''' <summary>
        ''' This method sign an access key
        ''' </summary>
        ''' <returns></returns>
        Private Function signAccessKey() As String
            Try
                Dim privateKey As String = _Keys.administration.private

                Return WalletAddressEngine.createSignature(_Keys.administration.private, _AccessKey)
            Catch ex As Exception
                Console.WriteLine("Error during signAccessKey:" & ex.Message)

                Return ""
            End Try
        End Function

        ''' <summary>
        ''' This method provide to get an access key
        ''' </summary>
        ''' <returns></returns>
        Private Function getAccessKey() As Boolean
            Try
                Dim remote As New ProxyWS(Of ResponseRequestAccessKeyModel)
                Dim proceed As Boolean = True

                If proceed Then
                    remote.url = buildURL("/administration/security/requestAccessKey/?signature=" & signCertificate())
                End If
                If proceed Then
                    proceed = (remote.getData() = "")
                End If
                If proceed Then
                    proceed = (remote.data.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete)
                End If
                If proceed Then
                    _AccessKey = remote.data.accessKey

                    proceed = True
                End If

                Return proceed
            Catch ex As Exception
                Console.WriteLine("Error during getAccessKey - " & ex.Message)

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to get a security token
        ''' </summary>
        ''' <returns></returns>
        Private Function getSecurityToken() As Boolean
            Try
                Dim remote As New ProxyWS(Of ResponseRequestAdminSecurityTokenModel)
                Dim proceed As Boolean = True

                If proceed Then
                    remote.url = buildURL("/administration/security/requestAdminSecurityToken/?signature=" & signAccessKey())
                End If
                If proceed Then
                    proceed = (remote.getData() = "")
                End If
                If proceed Then
                    proceed = (remote.data.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete)
                End If
                If proceed Then
                    _SecurityToken = remote.data.tokenValue

                    proceed = True
                End If

                Return proceed
            Catch ex As Exception
                Console.WriteLine("Error during serviceFound - " & ex.Message)

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to read a remote log file
        ''' </summary>
        ''' <returns></returns>
        Private Function readLogFile() As Boolean
            Try
                Dim remote As New ProxyWS(Of LogStreamResponseModel)
                Dim proceed As Boolean = True

                If proceed Then
                    remote.url = buildURL("/administration/logStream/?securityToken=" & _SecurityToken & "&mode=" & IIf(_Mode.ToLower() = "console", "console", "full"))
                End If
                Do While proceed
                    If proceed Then
                        proceed = (remote.getData() = "")
                    End If
                    If proceed Then
                        proceed = (remote.data.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete)
                    End If
                    If proceed Then
                        For Each item In remote.data.value
                            If (_Mode.ToLower() = "console") Then
                                Console.WriteLine(item.message)
                            Else
                                Console.WriteLine(item.ToString(True))
                            End If
                        Next
                    End If
                Loop

                Return True
            Catch ex As Exception
                Console.WriteLine("Error during readLogFile - " & ex.Message)

                Return False
            End Try
        End Function


        ''' <summary>
        ''' This method provide to execute the code
        ''' </summary>
        ''' <param name="value"></param>
        ''' <returns></returns>
        Public Function execute(ByRef value As CommandStructure) As Boolean
            Dim proceed As Boolean = True

            If proceed Then
                proceed = manageParameters(value)
            End If
            If proceed Then
                proceed = readSettings()
            End If
            If proceed Then
                proceed = readAdminKeyStore()
            End If
            If proceed Then
                Do While Not serviceFound()
                    Console.Clear()
                    Console.WriteLine(CHCCommonLibrary.AreaEngine.Miscellaneous.atMomentGMT() & " - wait to start service " & _Service & "...")

                    Threading.Thread.Sleep(100)
                Loop
            End If
            If proceed Then
                Console.WriteLine("")
                Console.WriteLine("In connections...")

                proceed = getAccessKey()
            End If
            If proceed Then
                proceed = getSecurityToken()
            End If
            If proceed Then
                Console.Clear()

                readLogFile()

                If _Pause Then
                    Console.WriteLine("")
                    Console.WriteLine("Press a key to continue...")
                    Console.ReadKey()
                End If

                Return True
            Else
                Return False
            End If
        End Function

    End Class

End Namespace
