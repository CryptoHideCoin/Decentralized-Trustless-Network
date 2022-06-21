Option Explicit On
Option Compare Text

Imports CHCCommonLibrary.AreaEngine.CommandLine
Imports CHCCommonLibrary.AreaEngine.Parameters
Imports CHCCommonLibrary.AreaEngine.Communication
Imports CHCModelsLibrary.AreaModel.Network.Response
Imports CHCModelsLibrary.AreaModel.Administration.Security




Namespace AreaEngine.Service

    Public Class AccessEngine

        Public Class InputParameter

            Public Property service As String = ""
            Public Property dataPath As String = ""
            Public Property password As String = ""
            Public Property securityKey As String = ""
            Public Property address As String = ""

        End Class

        Public Class SettingParameter

            Public Property secureChannel As String = ""
            Public Property servicePort As String = ""
            Public Property serviceId As String = ""
            Public Property certificate As String = ""
            Public Property publicAddress As String = ""

        End Class

        Private Property _Path As New CHCProtocolLibrary.AreaSystem.VirtualPathEngine

        Public Property [input] As New InputParameter
        Public Property setting As New SettingParameter
        Private Property _AccessKey As String = ""
        Private Property _PrivateKeyRAW As String = ""

        Public Property command As CommandStructure
        Public Property defaultParameters As ParameterCollection
        Public Property parameterCommand As String = ""
        Public Property securityToken As String = ""

        Public Event RaiseError(ByVal message As String)
        Public Event LaunchIntegrityApplication(ByVal fileName As String)


        ''' <summary>
        ''' This method provide to read a single parameters (from a command line)
        ''' </summary>
        ''' <returns></returns>
        Private Function readParameters() As Boolean
            Try
                If _command.haveParameter("service") Then
                    [input].service = command.parameterValue("service")
                ElseIf (defaultParameters.getParameter("service").Length > 0) Then
                    [input].service = defaultParameters.getParameter("service")
                Else
                    RaiseEvent RaiseError("Service parameter not found!")

                    Return False
                End If
                If _command.haveParameter("dataPath") Then
                    [input].dataPath = command.parameterValue("dataPath")
                ElseIf (defaultParameters.getParameter("dataPath").Length > 0) Then
                    [input].dataPath = defaultParameters.getParameter("dataPath")
                Else
                    RaiseEvent RaiseError("DataPath parameter not found!")

                    Return False
                End If
                If command.haveParameter("password") Then
                    [input].password = command.parameterValue("password")
                ElseIf (defaultParameters.getParameter("password").Length > 0) Then
                    [input].password = defaultParameters.getParameter("password")
                End If
                If command.haveParameter("securityKey") Then
                    [input].securityKey = command.parameterValue("securityKey")
                End If
                If command.haveParameter("address") Then
                    [input].address = command.parameterValue("address")
                Else
                    [input].address = "localHost"
                End If

                Return True
            Catch ex As Exception
                RaiseEvent RaiseError($"Problem during execute readParameters")

                Return False
            End Try

        End Function

        ''' <summary>
        ''' This method provide to read a settings 
        ''' </summary>
        ''' <returns></returns>
        Private Function readSettings() As Boolean
            Try
                Dim completeFileName As String = ""
                Dim engine As New CHCProtocolLibrary.AreaEngine.Settings.SettingsEngine
#Disable Warning BC42024
                'Dim data As CHCModelsLibrary.AreaModel.Administration.Settings.SettingsSidechainServiceComplete
#Enable Warning BC42024

                engine.dataPath = _Path.directoryData
                engine.serviceName = [input].service
                engine.password = [input].password

                Select Case engine.read()
                    Case CHCProtocolLibrary.AreaEngine.Settings.SettingsEngine.ResultReadSetting.fileNotFound
                        RaiseEvent RaiseError("Missing  setting's File ")

                        Return False
                    Case CHCProtocolLibrary.AreaEngine.Settings.SettingsEngine.ResultReadSetting.ReadError
                        RaiseEvent RaiseError("Error during read file")

                        Return False
                    Case CHCProtocolLibrary.AreaEngine.Settings.SettingsEngine.ResultReadSetting.Successfull
                        setting.secureChannel = engine.data.secureChannel
                        setting.servicePort = engine.data.servicePort
                        setting.serviceId = engine.data.serviceID
                        setting.certificate = engine.data.clientCertificate
                        setting.publicAddress = engine.data.publicAddress

                        If (engine.data.staticIP.Trim().Length > 0) Then
                            [input].address = engine.data.staticIP
                        End If

                        Return True
                End Select
            Catch ex As Exception
                RaiseEvent RaiseError($"Problem during execute readSettings - {ex.Message}")
            End Try

            Return False
        End Function

        ''' <summary>
        ''' This method provide to build an URL
        ''' </summary>
        ''' <param name="api"></param>
        ''' <returns></returns>
        Public Function buildURL(ByVal api As String) As String
            Dim url As String = ""
            Dim address As String = [input].address
            Try
                Dim proceed As Boolean = True

                If proceed Then
                    If setting.secureChannel Then
                        url += "https"
                    Else
                        url += "http"
                    End If
                End If
                If proceed Then
                    If (address.Length = 0) Then
                        address += "localhost:"
                    End If

                    address += ":" & setting.servicePort
                End If
                If proceed Then
                    url += "://" & address & "/api"
                End If
                If proceed Then
                    If (setting.serviceId.Length > 0) Then
                        url += "/" & setting.serviceId & api
                    Else
                        url += api
                    End If
                End If
            Catch ex As Exception
            End Try

            Return url
        End Function

        ''' <summary>
        ''' This method provide to test if service found
        ''' </summary>
        ''' <returns></returns>
        Public Function serviceFound() As Boolean
            Try
                Dim remote As New ProxyWS(Of BaseRemoteResponse)
                Dim proceed As Boolean = True

                If proceed Then
                    remote.url = buildURL("/service/test/")
                End If
                If proceed Then
                    proceed = (remote.getData() = "")
                Else
                    RaiseEvent RaiseError("Error during getData")
                End If
                If proceed Then
                    Return (remote.data.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete)
                End If

                Return proceed
            Catch exFile As System.IO.FileLoadException
                RaiseEvent LaunchIntegrityApplication(exFile.FileName)

                Return False
            Catch ex As Exception
                RaiseEvent RaiseError($"Error during serviceFound - {ex.Message}")

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to read a key parameter
        ''' </summary>
        ''' <returns></returns>
        Public Function readKeyPrivate(ByVal uuid As String) As String
            Try
                Dim engine As New CHCProtocolLibrary.AreaWallet.Support.WalletAddressDataEngine
                Dim dataLoaded As Boolean = False
                Dim securityValue As String = ""

                engine.fileName = IO.Path.Combine(_Path.keyStore, uuid, "walletAddress.private")

                If ([input].securityKey.Length > 0) Then
                    engine.securityKey = [input].securityKey
                End If

                If Not engine.load() Then
                    RaiseEvent RaiseError("Error during load keypair")

                    Return ""
                Else
                    Return CHCProtocolLibrary.AreaWallet.Support.WalletAddressEngine.createNew(engine.data.privateRAWKey, True).official.private
                End If
            Catch ex As Exception
                RaiseEvent RaiseError($"Error during read keypair private: {ex.Message}")

                Return ""
            End Try
        End Function

        ''' <summary>
        ''' This method sign a certificate with private key
        ''' </summary>
        ''' <returns></returns>
        Private Function signCertificate() As String
            Try
                If readAdminKeyStore() Then
                    Dim privateKey As String = _PrivateKeyRAW
                    Dim certificate As String = setting.certificate

                    Return CHCProtocolLibrary.AreaWallet.Support.WalletAddressEngine.createSignature(privateKey, certificate)
                Else
                    Return ""
                End If
            Catch ex As Exception
                RaiseEvent RaiseError($"Error during signCertificate: {ex.Message}")

                Return ""
            End Try
        End Function

        ''' <summary>
        ''' This method provide to read an admin keystore
        ''' </summary>
        ''' <returns></returns>
        Public Function readAdminKeyStore() As Boolean
            Try
                Dim uuidWallet As String = ""

                If (setting.publicAddress.Length >= 11) Then
                    If setting.publicAddress.StartsWith("keystoreid:") Then
                        Try
                            Dim keyStoreManager = New CHCProtocolLibrary.AreaWallet.Support.KeyStoreEngine

                            uuidWallet = setting.publicAddress.Substring(11)

                            keyStoreManager.fileName = IO.Path.Combine(_Path.keyStore, "keyAddress.list")

                            If keyStoreManager.read() Then
                                For Each item In keyStoreManager.data
                                    If (item.uuid.CompareTo(uuidWallet) = 0) Then
                                        _PrivateKeyRAW = readKeyPrivate(item.uuid)

                                        Return True
                                    End If
                                Next
                            End If
                        Catch ex As Exception
                            RaiseEvent RaiseError($"Error during Load data keyStore :{ex.Message}")

                            Return False
                        End Try
                    End If
                End If

                RaiseEvent RaiseError("Key private not disponible")

                Return True
            Catch ex As Exception
                RaiseEvent RaiseError($"Error during Load data information:{ex.Message}")

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to request the access key
        ''' </summary>
        ''' <returns></returns>
        Public Function getAccessKey() As Boolean
            Try
                Dim remote As New ProxyWS(Of ResponseRequestAccessKeyModel)
                Dim proceed As Boolean = True

                If proceed Then
                    remote.url = buildURL($"/administration/security/requestAccessKey/?signature={signCertificate()}")
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
                RaiseEvent RaiseError($"Error during getAccessKey - {ex.Message}")

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to request security token
        ''' </summary>
        ''' <returns></returns>
        Public Function getSecurityToken() As Boolean
            Try
                Dim remote As New ProxyWS(Of ResponseRequestAdminSecurityTokenModel)
                Dim proceed As Boolean = True

                If proceed Then
                    remote.url = buildURL($"/administration/security/requestAdminSecurityToken/?signature={CHCProtocolLibrary.AreaWallet.Support.WalletAddressEngine.createSignature(_PrivateKeyRAW, _AccessKey)}")
                End If
                If proceed Then
                    proceed = (remote.getData() = "")
                End If
                If proceed Then
                    proceed = (remote.data.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete)
                End If
                If proceed Then
                    _securityToken = remote.data.tokenValue

                    proceed = True
                End If

                Return proceed
            Catch ex As Exception
                RaiseEvent RaiseError($"Error during serviceFound - {ex.Message}")

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to manage a path
        ''' </summary>
        ''' <returns></returns>
        Public Function managePath() As Boolean
            Try
                If IO.Directory.Exists([input].dataPath) Then
                    _Path.directoryData = [input].dataPath

                    If _Path.init([input].service.Replace(" ", "")) Then
                        Return True
                    Else
                        RaiseEvent RaiseError($"Problem during build a Path")
                    End If
                Else
                    RaiseEvent RaiseError($"{[input].dataPath} not found.")
                End If

                Return False
            Catch ex As Exception
                RaiseEvent RaiseError($"An error occurrent during Bootstrap.managePath {Err.Description}")

                Return False
            End Try
        End Function


        ''' <summary>
        ''' This method provide to initialize the component
        ''' </summary>
        ''' <returns></returns>
        Public Function Init(ByRef command As CommandStructure, ByRef defaultParameters As ParameterCollection) As Boolean
            Dim proceed As Boolean = True

            If proceed Then
                _command = command
                _defaultParameters = defaultParameters
            End If
            If proceed Then
                proceed = readParameters()
            End If
            If proceed Then
                proceed = managePath()
            End If
            If proceed Then
                proceed = readSettings()
            End If
            If proceed Then
                If Not serviceFound() Then
                    RaiseEvent RaiseError(Chr(34) & [input].service & Chr(34) & " is not online")

                    proceed = False
                End If
            End If
            If proceed Then
                If Not getAccessKey() Then
                    RaiseEvent RaiseError("Problem during request an access key!")

                    proceed = False
                End If
            End If
            If proceed Then
                If Not getSecurityToken() Then
                    RaiseEvent RaiseError("Problem during request a security token!")

                    proceed = False
                End If
            End If

            Return proceed

        End Function

    End Class

End Namespace
