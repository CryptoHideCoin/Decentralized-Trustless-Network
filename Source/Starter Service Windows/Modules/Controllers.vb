Option Compare Text
Option Explicit On

Imports System.Web.Http



Namespace AreaCommon


    Module Controllers


        ''' <summary>
        ''' This method provide to start a webservice
        ''' </summary>
        Sub startWebService()

            log.track("Controllers.StartWebService", "Begin")

            Try

                Dim httpConfig As HttpSelfHostConfiguration

                Dim strPort As String = settings.data.portNumber

                httpConfig = New HttpSelfHostConfiguration("http://127.0.0.1:" & strPort)

                log.track("Controllers.StartWebService", "New Configuration Port " & strPort)

                httpConfig.Routes.MapHttpRoute(name:="SystemApi", routeTemplate:="api/v1.0/System/{controller}")

                log.track("Controllers.StartWebService", "Map route")

                Using server As New HttpSelfHostServer(httpConfig)

                    Try

                        log.track("Controllers.StartWebService", "Enter in the using")

                        server.OpenAsync().Wait()

                        log.track("Controllers.StartWebService", "WS Listen")

                        log.track("Controllers.StartWebService", "Webservice Run at " & strPort & " port")

                    Catch aggEx As AggregateException

                        log.track("Controllers.StartWebService", "Enable start a webservice; check admin authorizathion - Error:" & aggEx.Message, "fatal")

                        CloseApplication()

                    End Try

                    Do
                        Application.DoEvents()
                    Loop Until (state.currentApplication = AppState.enumStateApplication.inShutDown)

                End Using

            Catch ex As Exception

                log.track("Controllers.StartWebService", "Enable start a webservice; check admin authorizathion - Error:" & ex.Message, "fatal")

                CloseApplication()

            End Try

        End Sub


        ''' <summary>
        ''' This method provide to start a webservice in a new thread
        ''' </summary>
        Function webserviceThread() As Boolean

            log.track("Controllers.WebserviceThread", "Begin")

            Try

                Dim objWS As New Threading.Thread(AddressOf startWebService)

                objWS.Start()

                Return True

            Catch ex As Exception

                log.track("Controllers.WebserviceThread", "Error:" & ex.Message, "fatal")

                Return False

            End Try

        End Function


    End Module


End Namespace
