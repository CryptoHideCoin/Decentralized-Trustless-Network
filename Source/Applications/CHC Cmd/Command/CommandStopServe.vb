Option Compare Text
Option Explicit On

Imports CHCCmd.AreaCommon.Models
Imports CHCModels.AreaModel.Administration.Security
Imports CHCModels.AreaModel.Administration.Settings
Imports CHCModels.AreaModel.Network.Response
Imports CHCCommonLibrary.AreaEngine.DataFileManagement.Encrypted
Imports CHCCommonLibrary.AreaEngine.CommandLine
Imports CHCCommonLibrary.AreaEngine.Communication
Imports CHCProtocolLibrary.AreaSystem
Imports CHCProtocolLibrary.AreaWallet.Support





Namespace AreaCommon.Command

    ''' <summary>
    ''' This class manage the command Stop Serve 
    ''' </summary>
    Public Class CommandStopServe : Implements CommandModel

        Private Property _Command As CommandStructure

        Private Property _Path As New VirtualPathEngine

        Private Property _ParameterService As String = ""
        Private Property _ParameterDataPath As String = ""
        Private Property _ParameterPassword As String = ""
        Private Property _ParameterSecurityKey As String = ""
        Private Property _ParameterAddress As String = ""

        Private Property _SettingSecureChannel As Boolean = False
        Private Property _SettingServicePort As Integer = 0
        Private Property _SettingServiceID As String = ""
        Private Property _SettingCertificate As String = ""
        Private Property _SettingPublicAddress As String = ""

        Private Property _AccessKey As String = ""
        Private Property _SecurityToken As String = ""
        Private Property _PrivateKeyRAW As String = ""


        Private Property CommandModel_command As CommandStructure Implements CommandModel.command
            Get
                Return _Command
            End Get
            Set(value As CommandStructure)
                _Command = value
            End Set
        End Property

        ''' <summary>
        ''' This method provide to read a parameters
        ''' </summary>
        ''' <returns></returns>
        Private Function readParameters() As Boolean
            Try
                If _Command.haveParameter("service") Then
                    _ParameterService = _Command.parameterValue("service")
                ElseIf (ApplicationCommon.defaultParameters.getParameter("service").Length > 0) Then
                    _ParameterService = ApplicationCommon.defaultParameters.getParameter("service")
                Else
                    Console.WriteLine("Service parameter not found!")

                    Return False
                End If
                If _Command.haveParameter("dataPath") Then
                    _ParameterDataPath = _Command.parameterValue("dataPath")
                ElseIf (ApplicationCommon.defaultParameters.getParameter("dataPath").Length > 0) Then
                    _ParameterDataPath = ApplicationCommon.defaultParameters.getParameter("dataPath")
                Else
                    Console.WriteLine("DataPath parameter not found!")

                    Return False
                End If
                If _Command.haveParameter("password") Then
                    _ParameterPassword = _Command.parameterValue("password")
                ElseIf (ApplicationCommon.defaultParameters.getParameter("password").Length > 0) Then
                    _ParameterPassword = ApplicationCommon.defaultParameters.getParameter("password")
                End If
                If _Command.haveParameter("securityKey") Then
                    _ParameterSecurityKey = _Command.parameterValue("securityKey")
                End If
                If _Command.haveParameter("address") Then
                    _ParameterAddress = _Command.parameterValue("address")
                Else
                    _ParameterAddress = "localHost"
                End If

                Return True
            Catch ex As Exception
                Console.WriteLine("Problem during execute readParameters")

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
                Dim engineFile As New BaseFile(Of SettingsSidechainService)

                completeFileName = IO.Path.Combine(_Path.settings, _ParameterService & ".Settings")

                If Not IO.File.Exists(completeFileName) Then
                    Console.WriteLine("Missing file settings")

                    Return False
                End If

                If (_ParameterPassword.Length > 0) Then
                    engineFile.cryptoKEY = _ParameterPassword
                Else
                    engineFile.noCrypt = True
                End If

                engineFile.fileName = completeFileName

                If engineFile.read() Then
                    _SettingSecureChannel = engineFile.data.secureChannel
                    _SettingServicePort = engineFile.data.servicePort
                    _SettingServiceID = engineFile.data.serviceID
                    _SettingCertificate = engineFile.data.clientCertificate
                    _SettingPublicAddress = engineFile.data.publicAddress
                Else
                    Console.WriteLine("Error during read file")
                End If

                If IsNothing(engineFile.data) Then
                    Console.WriteLine("Error during read file e/o parameter")

                    Return False
                End If

                Return True
            Catch ex As Exception
                Console.WriteLine("Problem during execute readSettings")

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to build a URL
        ''' </summary>
        ''' <param name="api"></param>
        ''' <param name="ipAddress"></param>
        ''' <returns></returns>
        Private Function buildURL(ByVal api As String) As String
            Dim url As String = ""
            Dim address As String = _ParameterAddress
            Try
                Dim proceed As Boolean = True

                If proceed Then
                    If _SettingSecureChannel Then
                        url += "https"
                    Else
                        url += "http"
                    End If
                End If
                If proceed Then
                    If (address.Length = 0) Then
                        address += "localhost:"
                    End If

                    address += ":" & _SettingServicePort
                End If
                If proceed Then
                    url += "://" & address & "/api"
                End If
                If proceed Then
                    If (_SettingServiceID.Length > 0) Then
                        url += "/" & _SettingServiceID & api
                    Else
                        url += api
                    End If
                End If
            Catch ex As Exception
            End Try

            Return url
        End Function

        ''' <summary>
        ''' This method provide to test service found
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
                Else
                    Console.WriteLine("Error during getData")
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
        ''' This method sign a certificate with private key
        ''' </summary>
        ''' <returns></returns>
        Private Function signCertificate() As String
            Try
                If readAdminKeyStore() Then
                    Dim privateKey As String = _PrivateKeyRAW
                    Dim certificate As String = _SettingCertificate

                    Return WalletAddressEngine.createSignature(privateKey, certificate)
                Else
                    Return ""
                End If
            Catch ex As Exception
                Console.WriteLine("Error during signCertificate:" & ex.Message)

                Return ""
            End Try
        End Function

        ''' <summary>
        ''' This method provide a read a wallet address from file
        ''' </summary>
        ''' <param name="uuid"></param>
        ''' <param name="keyStoreSecurityKey"></param>
        ''' <returns></returns>
        Private Function readKeyPrivate(ByVal uuid As String) As String
            Try
                Dim engine As New WalletAddressDataEngine
                Dim dataLoaded As Boolean = False
                Dim securityValue As String = ""

                engine.fileName = IO.Path.Combine(_Path.keyStore, uuid, "walletAddress.private")

                If (_ParameterSecurityKey.Length > 0) Then
                    engine.securityKey = _ParameterSecurityKey
                End If

                If Not engine.load() Then
                    Console.WriteLine("Error during load keypair")

                    Return ""
                Else
                    Return WalletAddressEngine.createNew(engine.data.privateRAWKey, True).official.privateKey
                End If
            Catch ex As Exception
                Console.WriteLine("Error during read keypair private:" & ex.Message)

                Return ""
            End Try
        End Function

        ''' <summary>
        ''' This method provide to Read Admin Keystore
        ''' </summary>
        ''' <returns></returns>
        Public Function readAdminKeyStore() As Boolean
            Try
                Dim uuidWallet As String = ""

                If (_SettingPublicAddress.Length >= 11) Then
                    If _SettingPublicAddress.StartsWith("keystoreid:") Then
                        Try
                            Dim keyStoreManager = New KeyStoreEngine

                            uuidWallet = _SettingPublicAddress.Substring(11)

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
                            Console.WriteLine("Error during Load data keyStore :" & ex.Message)

                            Return False
                        End Try
                    End If
                End If

                Console.WriteLine("Key private not disponible")

                Return True
            Catch ex As Exception
                Console.WriteLine("Error during Load data information:" & ex.Message)

                Return False
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
        ''' This method provide to manage a path
        ''' </summary>
        ''' <param name="problemDescription"></param>
        ''' <returns></returns>
        Public Function managePath() As Boolean
            Try
                If IO.Directory.Exists(_ParameterDataPath) Then
                    _Path.directoryData = _ParameterDataPath

                    If _Path.init(VirtualPathEngine.EnumSystemType.runTime) Then
                        Return True
                    Else
                        Console.WriteLine("Problem during build a Path")
                    End If
                Else
                    Console.WriteLine(_ParameterDataPath & " not found.")
                End If

                Return False
            Catch ex As Exception
                Console.WriteLine("An error occurrent during Bootstrap.managePath " & Err.Description)

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
                    remote.url = buildURL("/administration/security/requestAdminSecurityToken/?signature=" & WalletAddressEngine.createSignature(_PrivateKeyRAW, _AccessKey))
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
        ''' This method provide to stop a serve
        ''' </summary>
        ''' <returns></returns>
        Private Function stopServe() As Boolean
            Try
                Dim remote As New ProxyWS(Of BaseRemoteResponse)
                Dim proceed As Boolean = True

                If proceed Then
                    remote.url = buildURL("/administration/setPowerOff/?securityToken=" & _SecurityToken)
                End If
                If proceed Then
                    proceed = (remote.sendData("PUT") = "")
                End If
                If proceed Then
                    proceed = (remote.remoteResponse.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete)
                End If

                Return proceed
            Catch ex As Exception
                Console.WriteLine("Error during stopServe - " & ex.Message)

                Return False
            End Try
        End Function

        Private Function CommandModel_run() As Boolean Implements CommandModel.run
            Try
                Dim accessKey As String = ""
                Dim proceed As Boolean = True

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
                        Console.WriteLine(Chr(34) & _ParameterService & Chr(34) & " is not online")

                        proceed = False
                    End If
                End If
                If proceed Then
                    If Not getAccessKey() Then
                        Console.WriteLine("Problem during request an access key!")

                        proceed = False
                    End If
                End If
                If proceed Then
                    If Not getSecurityToken() Then
                        Console.WriteLine("Problem during request a security token!")

                        proceed = False
                    End If
                End If
                If proceed Then
                    If stopServe() Then
                        Console.WriteLine(Chr(34) & _ParameterService & Chr(34) & " command STOP sended!")
                    Else
                        Console.WriteLine("Problem during execute Stop Server command!")

                        proceed = False
                    End If
                End If

                Return proceed
            Catch ex As Exception
                Return False
            End Try
        End Function

    End Class

End Namespace
