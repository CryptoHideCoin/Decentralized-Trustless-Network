Option Compare Text
Option Explicit On

Imports System.Web.Http



Namespace AreaCommon

    Module Controllers

        Private _controllerComplete As Boolean = False
        Private _portNumber As String = ""
        Private _servicePort As Boolean = False


        ''' <summary>
        ''' This method provide to start a webservice
        ''' </summary>
        Sub startWebService()

            log.track("Controllers.StartWebService", "Begin")

            Try
                Dim httpConfig As HttpSelfHostConfiguration

                If (_portNumber = "0") Then
                    httpConfig = New HttpSelfHostConfiguration("http://127.0.0.1")
                Else
                    httpConfig = New HttpSelfHostConfiguration("http://127.0.0.1:" & _portNumber)
                End If

                log.track("Controllers.StartWebService", "New Configuration Port " & _portNumber)

                If _servicePort Then
                    httpConfig.Routes.MapHttpRoute(name:="ServiceApi", routeTemplate:="api/" & settings.data.serviceId & "/service/{controller}")
                    httpConfig.Routes.MapHttpRoute(name:="SecurityApi", routeTemplate:="api/" & settings.data.serviceId & "/security/{controller}")
                    httpConfig.Routes.MapHttpRoute(name:="AdministrationApi", routeTemplate:="api/" & settings.data.serviceId & "/administration/{controller}")
                    httpConfig.Routes.MapHttpRoute(name:="AdministrationDoActionApi", routeTemplate:="api/" & settings.data.serviceId & "/administration/doAction/{controller}")
                Else
                    httpConfig.Routes.MapHttpRoute(name:="ServiceApi", routeTemplate:="api/" & settings.data.serviceId & "/service/{controller}")
                    httpConfig.Routes.MapHttpRoute(name:="QoSTicketApi", routeTemplate:="api/" & settings.data.serviceId & "/qos/{controller}")
                    httpConfig.Routes.MapHttpRoute(name:="SystemApi", routeTemplate:="api/v1.0/System/{controller}")
                    httpConfig.Routes.MapHttpRoute(name:="NetworkApi", routeTemplate:="api/" & settings.data.serviceId & "/network/{controller}")
                    httpConfig.Routes.MapHttpRoute(name:="RequestApi", routeTemplate:="api/" & settings.data.serviceId & "/request/{controller}")
                    httpConfig.Routes.MapHttpRoute(name:="NotifyRequestApi", routeTemplate:="api/" & settings.data.serviceId & "/notify/{controller}")
                End If

                log.track("Controllers.StartWebService", "Map route")

                Using server As New HttpSelfHostServer(httpConfig)
                    Try
                        log.track("Controllers.StartWebService", "Enter in the using")

                        server.OpenAsync().Wait()

                        log.track("Controllers.StartWebService", "WS Listen")
                        log.track("Controllers.StartWebService", "Webservice Run at " & _portNumber & " port")
                    Catch aggEx As AggregateException
                        log.track("Controllers.StartWebService", "Enable start a webservice; check admin authorizathion!", "fatal")

                        closeApplication()
                    End Try

                    _controllerComplete = True

                    Do
                        Application.DoEvents()
                        Threading.Thread.Sleep(AreaCommon.support.timeSleep)
                    Loop Until (state.service = CHCProtocolLibrary.AreaCommon.Models.Service.InformationResponseModel.EnumInternalServiceState.shutDown)

                    server.CloseAsync().Wait()
                    server.Dispose()

                    log.track("Controllers.StartWebService", "Close webservice at " & _portNumber & " port")

                End Using

                registry.addNew(CHCCommonLibrary.Support.RegistryEngine.RegistryData.TypeEvent.applicationShutdown)

                state.service = CHCProtocolLibrary.AreaCommon.Models.Service.InformationResponseModel.EnumInternalServiceState.starting
            Catch ex As Exception
                log.track("Controllers.StartWebService", "Enable start a webservice; check admin authorizathion - Error:" & ex.Message, "fatal")

                closeApplication()
            End Try

        End Sub


        ''' <summary>
        ''' This method provide to start a webservice in a new thread
        ''' </summary>
        Function webServiceThread(Optional ByVal useServicePort As Boolean = False) As Boolean

            log.track("Controllers.WebserviceThread", "Begin")

            Try
                Dim objWS As New Threading.Thread(AddressOf startWebService)

                If useServicePort Then
                    _portNumber = settings.data.servicePort
                    _servicePort = True
                Else
                    _portNumber = settings.data.publicPort
                    _servicePort = False
                End If

                objWS.Start()

                Do While Not _controllerComplete
                    Threading.Thread.Sleep(AreaCommon.support.timeSleep)
                    Application.DoEvents()
                Loop

                log.track("Controllers.WebserviceThread", "Completed")

                Return True
            Catch ex As Exception
                log.track("Controllers.WebserviceThread", ex.Message, "fatal")

                Return False
            End Try
        End Function

    End Module

End Namespace
