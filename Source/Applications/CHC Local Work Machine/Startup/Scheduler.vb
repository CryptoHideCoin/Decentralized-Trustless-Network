Option Compare Text
Option Explicit On

Imports CHCModelsLibrary.AreaModel.Administration.Security
Imports CHCModelsLibrary.AreaModel.Administration.Settings
Imports CHCModelsLibrary.AreaModel.Information
Imports CHCModelsLibrary.AreaModel.Network.Response
Imports CHCCommonLibrary.AreaEngine.Communication
Imports CHCProtocolLibrary.AreaWallet.Support
Imports CHCProtocolLibrary.AreaEngine.Keys




Namespace AreaCommon.Startup

    Module Scheduler

        ''' <summary>
        ''' This method provide to build a URL
        ''' </summary>
        ''' <param name="api"></param>
        ''' <param name="ipAddress"></param>
        ''' <returns></returns>
        Private Function buildURL(ByVal api As String, ByRef config As SettingsSidechainServiceComplete) As String
            Dim ipAddress As String = "localhost:" & config.servicePort
            Dim url As String = ""
            Try
                Dim proceed As Boolean = True

                If proceed Then
                    If config.secureChannel Then
                        url += "https"
                    Else
                        url += "http"
                    End If
                End If
                If proceed Then
                    url += "://" & ipAddress & "/api"
                End If
                If proceed Then
                    If (config.serviceID.Length > 0) Then
                        url += "/" & config.serviceID & api
                    Else
                        url += api
                    End If
                End If
            Catch ex As Exception
            End Try

            Return url
        End Function

        ''' <summary>
        ''' This method provide to test service
        ''' </summary>
        ''' <param name="config"></param>
        ''' <returns></returns>
        Private Function testService(ByRef config As SettingsSidechainServiceComplete) As Boolean
            Try
                Dim remote As New ProxyWS(Of RemoteResponse)
                Dim proceed As Boolean = True

                If proceed Then
                    remote.url = buildURL("/service/test/", config)
                End If
                If proceed Then
                    proceed = (remote.getData() = "")
                End If
                If proceed Then
                    Return (remote.data.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete)
                End If

                Return proceed
            Catch exFile As System.IO.FileLoadException
                IntegrityApplication.executeRepairNewton(exFile.FileName)

                Return False
            Catch ex As Exception
                Console.WriteLine("Error during serviceFound - " & ex.Message)

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method sign a certificate with private key
        ''' </summary>
        ''' <returns></returns>
        Private Function signCertificate(ByVal item As GeneralModel.ServiceData) As String
            Try
                Dim privateKey As String = item.keys.private
                Dim certificate As String = item.configuration.clientCertificate

                Return WalletAddressEngine.createSignature(item.keys.private, certificate)
            Catch ex As Exception
                Console.WriteLine("Error during signCertificate:" & ex.Message)

                Return ""
            End Try
        End Function

        ''' <summary>
        ''' This method provide to sign an access key
        ''' </summary>
        ''' <returns></returns>
        Private Function signAccessKey(ByVal accessKey As String, ByVal item As GeneralModel.ServiceData) As String
            Try
                Dim privateKey As String = item.keys.private

                Return WalletAddressEngine.createSignature(privateKey, accessKey)
            Catch ex As Exception
                Console.WriteLine("Error during signAccessKey:" & ex.Message)

                Return ""
            End Try
        End Function

        ''' <summary>
        ''' This method provide to get an access key
        ''' </summary>
        ''' <returns></returns>
        Private Function getAccessKey(ByRef accessKey As String, ByVal item As GeneralModel.ServiceData) As Boolean
            Try
                Dim remote As New ProxyWS(Of ResponseRequestAccessKeyModel)
                Dim proceed As Boolean = True

                If proceed Then
                    remote.url = buildURL("/administration/security/requestAccessKey/?signature=" & signCertificate(item), item.configuration)
                End If
                If proceed Then
                    proceed = (remote.getData() = "")
                End If
                If proceed Then
                    proceed = (remote.data.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete)
                End If
                If proceed Then
                    accessKey = remote.data.accessKey

                    proceed = True
                End If

                Return proceed
            Catch ex As Exception
                Console.WriteLine("Error during getAccessKey - " & ex.Message)

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

                If (CHCSidechainServiceLibrary.AreaCommon.Main.securityKey.Length > 0) Then
                    engine.securityKey = CHCSidechainServiceLibrary.AreaCommon.Main.securityKey
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
        Public Function readAdminKeyStore(ByVal data As GeneralModel.ServiceData) As KeysEngine.KeyPair
            Try
                Dim uuidWallet As String = ""
                Dim pathKeyStore As String = CHCSidechainServiceLibrary.AreaCommon.Main.environment.paths.keyStore

                If (data.configuration.publicAddress.Length >= 11) Then
                    If data.configuration.publicAddress.StartsWith("keystoreid:") Then
                        Try
                            Dim keyStoreManager = New KeyStoreEngine

                            uuidWallet = data.configuration.publicAddress.Substring(11)

                            keyStoreManager.fileName = IO.Path.Combine(pathKeyStore, "keyAddress.list")

                            If keyStoreManager.read() Then
                                For Each item In keyStoreManager.data
                                    If (item.uuid.CompareTo(uuidWallet) = 0) Then
                                        Return readWalletAddress(item.uuid, pathKeyStore)
                                    End If
                                Next
                            End If
                        Catch ex As Exception
                            Console.WriteLine("Error during Load data keyStore :" & ex.Message)

                            Return New KeysEngine.KeyPair
                        End Try
                    End If
                End If

                Console.WriteLine("Keypair not found")
            Catch ex As Exception
                Console.WriteLine("Error during Load data information:" & ex.Message)
            End Try

            Return New KeysEngine.KeyPair
        End Function

        ''' <summary>
        ''' This method provide to get a security token
        ''' </summary>
        ''' <returns></returns>
        Private Function getSecurityToken(ByVal accessKey As String, ByVal item As GeneralModel.ServiceData) As Boolean
            Try
                Dim remote As New ProxyWS(Of ResponseRequestAdminSecurityTokenModel)
                Dim proceed As Boolean = True

                If proceed Then
                    remote.url = buildURL("/administration/security/requestAdminSecurityToken/?signature=" & signAccessKey(accessKey, item), item.configuration)
                End If
                If proceed Then
                    proceed = (remote.getData() = "")
                End If
                If proceed Then
                    proceed = (remote.data.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete)
                End If
                If proceed Then
                    item.securityToken = remote.data.tokenValue

                    proceed = True
                End If

                Return proceed
            Catch ex As Exception
                Console.WriteLine("Error during serviceFound - " & ex.Message)

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to get a service state
        ''' </summary>
        ''' <param name="item"></param>
        ''' <returns></returns>
        Private Function getServiceState(ByVal item As GeneralModel.ServiceData) As Boolean
            Try
                Dim remote As New ProxyWS(Of InformationResponseModel)
                Dim proceed As Boolean = True

                If proceed Then
                    remote.url = buildURL("/service/information/?securityToken=" & item.securityToken, item.configuration)
                End If
                If proceed Then
                    proceed = (remote.getData() = "")
                End If
                If proceed Then
                    proceed = (remote.data.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete)
                End If
                If proceed Then
                    Select Case remote.data.value.currentStatus
                        Case InternalServiceInformation.EnumInternalServiceState.shutDown : item.status = "Shutdown"
                        Case InternalServiceInformation.EnumInternalServiceState.started : item.status = "Started"
                        Case InternalServiceInformation.EnumInternalServiceState.starting : item.status = "Starting"
                        Case InternalServiceInformation.EnumInternalServiceState.swithOff : item.status = "Switch off"
                        Case InternalServiceInformation.EnumInternalServiceState.waitToMaintenance : item.status = "Wait to Maintenance"
                        Case Else : item.status = "Indeterminable"
                    End Select
                End If

                Return True
            Catch exFile As system.io.FileLoadException
                IntegrityApplication.executeRepairNewton(exFile.FileName)

                Return False
            Catch ex As Exception
                Console.WriteLine("Error during getServiceState - " & ex.Message)

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to update the service state
        ''' </summary>
        ''' <param name="item"></param>
        ''' <returns></returns>
        Private Function updateStateService(ByVal item As GeneralModel.ServiceData) As Boolean
            Dim proceed As Boolean = True
            Try
                Dim accessKey As String = ""

                If proceed Then
                    proceed = testService(item.configuration)
                End If
                If item.securityToken.Length = 0 Then
                    If proceed Then
                        proceed = getAccessKey(accessKey, item)
                    End If
                    If proceed Then
                        proceed = getSecurityToken(accessKey, item)
                    End If
                End If
                If proceed Then
                    proceed = getServiceState(item)
                End If

                Return proceed
            Catch ex As Exception
                Console.WriteLine("Error during updateStateService - " & ex.Message)

                proceed = False
            End Try

            Return proceed
        End Function

        ''' <summary>
        ''' This method provide to refresh and connect this agent to every service
        ''' </summary>
        Sub startServiceProcessor()
            Try
                Dim response As CHCSidechainServiceLibrary.AreaChain.Runtime.Models.ResponseIOOperation
                Dim data As GeneralModel.ServiceData
                Dim toRemove As List(Of GeneralModel.ServiceData)
                Dim noAdd As Boolean = False
                Dim snapShotToRegister As New List(Of CHCModelsLibrary.AreaModel.Service.MinimalDataToRegister)

                Do
                    Main.schedulerInWorking = True

                    If Not IsNothing(Main.interfaceEntryPoint) Then
                        Main.interfaceEntryPoint.notifyStartUpdate()
                    End If

                    Application.DoEvents()

                    Main.notAddInScheduler = True

                    snapShotToRegister = Main.serviceToRegister
                    Main.serviceToRegister = New List(Of CHCModelsLibrary.AreaModel.Service.MinimalDataToRegister)

                    Main.notAddInScheduler = False

                    For Each item In snapShotToRegister
                        noAdd = False

                        For Each itemService In Main.settingList.Values
                            If (itemService.configuration.sideChainName.Contains(item.service) = 0) Then
                                noAdd = True

                                Exit For
                            End If
                        Next

                        If Not noAdd Then
                            response = CHCSidechainServiceLibrary.AreaChain.Runtime.Models.EnvironmentModel.readSettings(item.service, True)

                            If response.successful Then
                                If testService(response.settings) Then
                                    data = New GeneralModel.ServiceData With {.configuration = response.settings}

                                    data.keys = readAdminKeyStore(data)

                                    Main.settingList.Add(response.settings.sideChainName, data)

                                    If Not IsNothing(Main.interfaceEntryPoint) Then
                                        Main.interfaceEntryPoint.notifyAddNewService(response.settings.internalName)
                                    End If
                                End If
                            End If
                        End If

                        Threading.Thread.Sleep(100)
                        Application.DoEvents()
                    Next

                    toRemove = New List(Of GeneralModel.ServiceData)

                    For Each item In Main.settingList
                        If Not updateStateService(item.Value) Then
                            toRemove.Add(item.Value)
                        End If

                        Threading.Thread.Sleep(100)
                        Application.DoEvents()
                    Next

                    For Each item In toRemove
                        If Not IsNothing(Main.interfaceEntryPoint) Then
                            Main.interfaceEntryPoint.notifyRemoveService(item.configuration.internalName)
                        End If

                        Main.settingList.Remove(item.configuration.sideChainName)
                    Next

                    toRemove = Nothing

                    Main.schedulerInWorking = False
                    If Not IsNothing(Main.interfaceEntryPoint) Then
                        Main.interfaceEntryPoint.notifyInIdle()
                    End If

                    Application.DoEvents()
                    Threading.Thread.Sleep(10000)
                Loop Until (CHCSidechainServiceLibrary.AreaCommon.Main.serviceInformation.currentStatus <> InternalServiceInformation.EnumInternalServiceState.started)
            Catch ex As Exception
                MessageBox.Show("Problem with startServiceProcessor " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        ''' <summary>
        ''' This method provide to start all maintenance service
        ''' </summary>
        ''' <returns></returns>
        Public Function run() As Boolean
            Try
                Dim objWS As New Threading.Thread(AddressOf startServiceProcessor)

                objWS.Start()

                Return True
            Catch ex As Exception
                MessageBox.Show("Problem with Scheduler " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                Return False
            End Try
        End Function

    End Module

End Namespace
