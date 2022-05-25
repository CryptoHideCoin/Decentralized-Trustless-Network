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

        Private Property _controllerComplete As Boolean = False
        Private Property _controllerInError As Boolean = False

        Public Property portNumber As String = ""


        ''' <summary>
        ''' This method provide to start a webservice
        ''' </summary>
        Sub startWebService()
            Try
                Dim httpConfig As HttpSelfHostConfiguration
                Dim serviceID As String = ""

                If (portNumber = "0") Then
                    httpConfig = New HttpSelfHostConfiguration("http://127.0.0.1")
                Else
                    httpConfig = New HttpSelfHostConfiguration("http://127.0.0.1:" & portNumber)
                End If

                If (environment.settings.serviceID.Length > 0) Then
                    serviceID = environment.settings.serviceID & "/"
                End If

                httpConfig.Routes.MapHttpRoute(name:="ServiceApi", routeTemplate:="api/" & serviceID & "service/{controller}")
                httpConfig.Routes.MapHttpRoute(name:="AdministrationApi", routeTemplate:="api/" & serviceID & "administration/{controller}")
                httpConfig.Routes.MapHttpRoute(name:="SecurityApi", routeTemplate:="api/" & serviceID & "administration/security/{controller}")
                httpConfig.Routes.MapHttpRoute(name:="LWMLinkedApi", routeTemplate:="api/" & serviceID & "linked/{controller}")

                Using server As New HttpSelfHostServer(httpConfig)
                    Try
                        server.OpenAsync().Wait()
                    Catch aggEx As AggregateException
                        MessageBox.Show("Problem with startWebService - Enable start a webservice; check admin authorizathion! " & aggEx.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try

                    _controllerComplete = True

                    Do
                        Application.DoEvents()
                        Threading.Thread.Sleep(environment.support.timeSleep)
                    Loop Until (serviceInformation.currentStatus = InternalServiceInformation.EnumInternalServiceState.shutDown)

                    server.CloseAsync().Wait()
                    server.Dispose()

                End Using

                serviceInformation.currentStatus = InternalServiceInformation.EnumInternalServiceState.swithOff
            Catch exFile As system.io.FileLoadException
                environment.log.trackException("Controllers.StartWebService", "Main", $"Problem with dll release - {exFile.Message}")

                IntegrityApplication.executeRepairNewton(exFile.FileName)

                _controllerInError = True
            Catch ex As Exception
                _controllerInError = True

                MessageBox.Show("Problem with startWebService " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End Sub

        ''' <summary>
        ''' This method provide to start a webservice in a new thread
        ''' </summary>
        Function webServiceThread() As Boolean
            Try
                Dim objWS As New Threading.Thread(AddressOf startWebService)

                _portNumber = CHCSidechainServiceLibrary.AreaCommon.Main.environment.settings.servicePort

                objWS.Start()

                Do While Not _controllerComplete And Not _controllerInError
                    Threading.Thread.Sleep(environment.support.timeSleep)
                    Application.DoEvents()
                Loop

                If _controllerComplete Then
                    serviceInformation.currentStatus = InternalServiceInformation.EnumInternalServiceState.started
                End If

                Return True
            Catch ex As Exception
                MessageBox.Show("Problem with webServiceThread " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                Return False
            End Try
        End Function

    End Module

End Namespace
