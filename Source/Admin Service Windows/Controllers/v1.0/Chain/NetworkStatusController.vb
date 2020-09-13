Imports System.Web.Http

Imports CHCCommonLibrary.AreaEngine.Communication
Imports CHCProtocolLibrary.AreaCommon.Models.Settings



Namespace Controllers


    ' GET: api/v1.0/Network/StatusController
    ''' <summary>
    ''' This API permit a client to know if the Masternode is in work mode or not
    ''' </summary>
    <Route("NetworkApi")>
    Public Class StatusController

        Inherits ApiController



        Private Function getDataFromRuntime() As AreaCommon.Models.Network.InfoNetworkModel

            Dim result As New AreaCommon.Models.Network.InfoNetworkModel

            Try

                If (AreaCommon.settings.data.serviceRuntime.url.Trim.Length > 0) Then

                    Dim remote As New ProxyWS(Of AreaCommon.Models.Network.InfoNetworkModel)

                    remote.url = AreaCommon.settings.data.serviceRuntime.composeURL("/api/v1.0/network/status/", True)

                    If (remote.getData() = "") Then
                        Return remote.data
                    Else
                        Throw New Exception("StatusController.getDataFromRuntime(): Error connection")
                    End If

                Else
                    Throw New Exception("StatusController.getDataFromRuntime(): data no set")
                End If

            Catch ex As Exception
                Throw New Exception("StatusController.getDataFromRuntime(): " & ex.Message, ex)
            End Try

        End Function



        Public Function GetValue(ByVal certificate As String) As AreaCommon.Models.Network.InfoNetworkModel

            Dim result As New AreaCommon.Models.Network.InfoNetworkModel

            Try

                If AreaSecurity.authorization.checkClientCertification(certificate) Then

                    If (AreaCommon.state.currentApplication = EnumStateApplication.inRunning) Then

                        Try

                            result = getDataFromRuntime()

                        Catch ex As Exception

                            result.currentStatus = AreaCommon.Models.Network.InfoNetworkModel.EnumNetworkStatus.off
                            result.protocolRelease = "n.a."
                            result.response.error = True
                            result.response.description = "Error = " & ex.Message
                            result.transactionChainName = "n.a."

                        End Try

                    Else

                        result.response.error = True
                        result.response.offline = True

                    End If

                Else

                    result.response.error = True
                    result.response.unAuthorized = True

                End If

            Catch ex As Exception

                result.response.error = True
                result.response.description = "Error = " & ex.Message

            End Try

            Return result

        End Function


    End Class


End Namespace

