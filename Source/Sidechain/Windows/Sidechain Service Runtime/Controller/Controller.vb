Option Compare Text
Option Explicit On

Imports System.Web.Http
Imports System.Web.Http.SelfHost
Imports CHCSidechainServiceLibrary.AreaCommon.Main
Imports CHCModelsLibrary.AreaModel.Information



Namespace AreaCommon

    ''' <summary>
    ''' This static class contain the element of webservice component
    ''' </summary>
    Module Controllers

        Private _controllerComplete As Boolean = False
        Private _controllerInError As Boolean = False
        Private _portNumber As String = ""
        Private _servicePort As Boolean = False


        ''' <summary>
        ''' This method provide to start a webservice
        ''' </summary>
        Sub startWebService()
            environment.log.trackEnter("Controllers.StartWebService", "Begin")

            Try
                Dim httpConfig As HttpSelfHostConfiguration
                Dim serviceID As String = ""

                If (_portNumber = "0") Then
                    httpConfig = New HttpSelfHostConfiguration("http://127.0.0.1")
                Else
                    httpConfig = New HttpSelfHostConfiguration("http://127.0.0.1:" & _portNumber)
                End If

                If (environment.settings.serviceID.Length > 0) Then
                    serviceID = environment.settings.serviceID & "/"
                End If

                environment.log.track("Controllers.StartWebService", "New Configuration Port " & _portNumber)

                If _servicePort Then
                    httpConfig.Routes.MapHttpRoute(name:="ServiceApi", routeTemplate:="api/" & serviceID & "service/{controller}")
                    httpConfig.Routes.MapHttpRoute(name:="SecurityApi", routeTemplate:="api/" & serviceID & "administration/security/{controller}")
                    httpConfig.Routes.MapHttpRoute(name:="MaintenanceApi", routeTemplate:="api/" & serviceID & "administration/maintenance/{controller}")
                    httpConfig.Routes.MapHttpRoute(name:="AdministrationApi", routeTemplate:="api/" & serviceID & "administration/{controller}")
                    httpConfig.Routes.MapHttpRoute(name:="AdministrationDoActionApi", routeTemplate:="api/" & serviceID & "administration/doAction/{controller}")
                Else
                    httpConfig.Routes.MapHttpRoute(name:="ServiceApi", routeTemplate:="api/" & serviceID & "service/{controller}")
                    httpConfig.Routes.MapHttpRoute(name:="QoSTicketApi", routeTemplate:="api/" & serviceID & "qos/{controller}")
                    httpConfig.Routes.MapHttpRoute(name:="SystemApi", routeTemplate:="api/v1.0/System/{controller}")
                    httpConfig.Routes.MapHttpRoute(name:="LedgerApi", routeTemplate:="api/" & serviceID & "ledger/{controller}")
                    httpConfig.Routes.MapHttpRoute(name:="ChainApi", routeTemplate:="api/" & serviceID & "chain/{controller}")
                    httpConfig.Routes.MapHttpRoute(name:="SupplyApi", routeTemplate:="api/" & serviceID & "supply/{controller}")
                    httpConfig.Routes.MapHttpRoute(name:="NetworkApi", routeTemplate:="api/" & serviceID & "network/{controller}")
                    httpConfig.Routes.MapHttpRoute(name:="RequestApi", routeTemplate:="api/" & serviceID & "request/{controller}")
                    httpConfig.Routes.MapHttpRoute(name:="NotifyRequestApi", routeTemplate:="api/" & serviceID & "notify/{controller}")
                End If

                environment.log.track("Controllers.StartWebService", "Map route")

                Using server As New HttpSelfHostServer(httpConfig)
                    Try
                        environment.log.track("Controllers.StartWebService", "Enter in the using")

                        server.OpenAsync().Wait()

                        environment.log.track("Controllers.StartWebService", "WS Listen")
                        environment.log.track("Controllers.StartWebService", "Webservice Run at " & _portNumber & " port")
                    Catch aggEx As AggregateException
                        If (TypeName(aggEx.InnerException).ToLower.CompareTo("AddressAlreadyInUseException".ToLower) = 0) Then
                            environment.log.trackException("Controllers.StartWebService", "Service in use")

                            environment.log.writeCacheToLogFile()

                            End
                        End If
                        environment.log.trackException("Controllers.StartWebService", "Enable start a webservice; check admin authorizathion!")
                    End Try

                    _controllerComplete = True

                    Do
                        Application.DoEvents()
                        Threading.Thread.Sleep(environment.support.timeSleep)
                    Loop Until (serviceInformation.currentStatus = InternalServiceInformation.EnumInternalServiceState.shutDown)

                    server.CloseAsync().Wait()
                    server.Dispose()

                    environment.log.track("Controllers.StartWebService", "Close webservice at " & _portNumber & " port")

                End Using

                environment.registry.addNew(CHCModelsLibrary.AreaModel.Registry.RegistryData.TypeEvent.applicationShutdown)

                serviceInformation.currentStatus = InternalServiceInformation.EnumInternalServiceState.swithOff

                environment.log.track("Controllers.StartWebService", "Service Off")
            Catch exFile As system.io.FileLoadException
                environment.log.trackException("Controllers.StartWebService", $"Problem with dll release - {exFile.Message}")

                IntegrityApplication.executeRepairNewton(exFile.FileName)

                _controllerInError = True
            Catch ex As Exception
                environment.log.trackException("Controllers.StartWebService", "Enable start a webservice; check admin authorizathion - Error:" & ex.Message)

                _controllerInError = True
            End Try

        End Sub

        ''' <summary>
        ''' This method provide to start a webservice in a new thread
        ''' </summary>
        Function webServiceThread(Optional ByVal useServicePort As Boolean = False) As Boolean
            environment.log.trackEnter("Controllers.WebserviceThread")

            Try
                Dim objWS As New Threading.Thread(AddressOf startWebService)

                If useServicePort Then
                    _portNumber = environment.settings.servicePort
                    _servicePort = True
                Else
                    _portNumber = environment.settings.publicPort
                    _servicePort = False
                End If

                objWS.Start()

                Do While Not _controllerComplete And Not _controllerInError
                    Threading.Thread.Sleep(environment.support.timeSleep)

                    Application.DoEvents()
                Loop

                If _controllerComplete Then
                    serviceInformation.currentStatus = InternalServiceInformation.EnumInternalServiceState.started
                End If

                environment.log.trackExit("Controllers.WebserviceThread")

                Return True
            Catch ex As Exception
                environment.log.trackException("Controllers.WebserviceThread", ex.Message)

                Return False
            End Try
        End Function

    End Module

End Namespace
