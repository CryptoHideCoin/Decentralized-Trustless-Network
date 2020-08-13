Imports System.Web.Http



Namespace Controllers


    ' GET: api/v1.0/System/HandShakeController
    <Route("SystemApi")>
    Public Class HandShakeController

        Inherits ApiController





        <Route("systemApi", Name:="handShake")>
        Public Function GetConnect(ByVal serviceAdministrative As Boolean, ByVal serviceEngine As Boolean, ByVal certificateValue As String) As Models.BooleanModel

            If serviceAdministrative Then

                If (AreaCommon.settings.data.certificateMasternodeAdmin.CompareTo(certificateValue) > 0) Then

                    AreaCommon.state.adminConnection = True

                    Return New Models.BooleanModel() With {.value = True}

                End If

            End If

            If serviceEngine Then

                If (AreaCommon.settings.data.certificateMasternodeRuntime.CompareTo(certificateValue) > 0) Then

                    AreaCommon.state.engineConnection = True

                    Return New Models.BooleanModel() With {.value = True}

                End If

            End If

            Return New Models.BooleanModel() With {.value = False}

        End Function


    End Class


End Namespace