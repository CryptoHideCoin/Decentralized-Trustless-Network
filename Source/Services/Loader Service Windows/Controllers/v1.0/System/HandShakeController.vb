Option Compare Text
Option Explicit On

Imports System.Web.Http
Imports CHCProtocolLibrary.AreaCommon





Namespace Controllers


    ' GET: api/v1.0/System/HandShakeController
    <Route("SystemApi")>
    Public Class HandShakeController

        Inherits ApiController





        <Route("systemApi", Name:="handShake")>
        Public Function GetConnect(ByVal serviceName As String, ByVal certificateValue As String) As Models.General.BooleanModel

            Select Case serviceName.ToLower
                Case "admin"
                    If (AreaCommon.settings.data.serviceAdmin.certificate.CompareTo(certificateValue) > 0) Then
                        AreaCommon.state.adminStateData.connection = True

                        Return New Models.General.BooleanModel() With {.value = True}
                    End If
                Case "primaryservice"
                    'If (AreaCommon.settings.data.certificateServiceRuntime.CompareTo(certificateValue) > 0) Then

                    '    AreaCommon.state.engineConnection = True

                    '    Return New Models.General.BooleanModel() With {.value = True}

                    'End If
                Case "update"
                    If (AreaCommon.settings.data.upgradeCertificate.CompareTo(certificateValue) > 0) Then
                        AreaCommon.state.updateStateData.connection = True

                        Return New Models.General.BooleanModel() With {.value = True}
                    End If
            End Select

            Return New Models.General.BooleanModel() With {.value = False}

        End Function


    End Class


End Namespace