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
        Public Function GetConnect(ByVal serviceAdministrative As Boolean, ByVal serviceEngine As Boolean, ByVal certificateValue As String) As Models.General.BooleanModel

            If serviceAdministrative Then

                If (AreaCommon.settings.data.certificateServiceAdmin.CompareTo(certificateValue) > 0) Then

                    AreaCommon.state.adminStateData.connection = True

                    Return New Models.General.BooleanModel() With {.value = True}

                End If

            End If

            If serviceEngine Then

                'If (AreaCommon.settings.data.certificateServiceRuntime.CompareTo(certificateValue) > 0) Then

                '    AreaCommon.state.engineConnection = True

                '    Return New Models.General.BooleanModel() With {.value = True}

                'End If

            End If

            Return New Models.General.BooleanModel() With {.value = False}

        End Function


    End Class


End Namespace