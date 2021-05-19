Option Compare Text
Option Explicit On

Imports System.Web.Http
Imports CHCProtocolLibrary.AreaCommon





Namespace Controllers


    ' GET: api/v1.0/Service/StatusController
    <Route("serviceApi")>
    Public Class StatusController

        Inherits ApiController





        <Route("serviceApi", Name:="status")>
        Public Function GetData(ByVal serviceName As String, ByVal certificateValue As String) As AppState.ServiceStatus

            Select Case serviceName.ToLower
                Case "admin"
                    If (AreaCommon.settings.data.serviceAdmin.certificate.CompareTo(certificateValue) > 0) Then
                        Return AreaCommon.state.adminStateData
                    End If
                Case "update"
                    If (AreaCommon.settings.data.upgradeCertificate.CompareTo(certificateValue) > 0) Then
                        Return AreaCommon.state.updateStateData
                    End If
                Case Else
                    For Each itemService In AreaCommon.state.serviceStateData
                        If (itemService.serviceName = serviceName) Then
                            Return itemService
                        End If
                    Next
            End Select

            Return New AppState.ServiceStatus

        End Function


    End Class


End Namespace

