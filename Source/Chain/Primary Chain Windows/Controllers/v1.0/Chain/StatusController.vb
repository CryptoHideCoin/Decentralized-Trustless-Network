Option Compare Text
Option Explicit On


Imports System.Web.Http
Imports CHCProtocolLibrary.AreaCommon.Models.Settings



Namespace Controllers


    ' GET: api/v1.0/Network/StatusController
    ''' <summary>
    ''' This API permit a client to know if the Masternode is in work mode or not
    ''' </summary>
    <Route("NetworkApi")>
    Public Class StatusController

        Inherits ApiController




        Public Function GetValue(ByVal certificate As String) As AreaCommon.Models.Network.NetworkModel

            Dim result As New AreaCommon.Models.Network.NetworkModel

            Try

                If AreaSecurity.authorization.checkAdminCertification(certificate) Then

                    If (AreaCommon.state.stateApplication = EnumStateApplication.inRunning) Then

                        Try

                            With result

                                .currentStatus = AreaCommon.Models.Network.NetworkModel.EnumNetworkStatus.off
                                .protocolRelease = "to define"
                                .transactionChainName = "to define"

                            End With

                        Catch ex As Exception

                            result.currentStatus = AreaCommon.Models.Network.NetworkModel.EnumNetworkStatus.off
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

