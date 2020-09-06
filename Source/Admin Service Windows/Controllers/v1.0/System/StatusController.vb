Imports System.Web.Http



Namespace Controllers


    ' GET: api/v1.0/System/StatusServiceController
    ''' <summary>
    ''' This API permit a client to know if the Masternode is in work mode or not
    ''' </summary>
    <Route("SystemApi")>
    Public Class StatusServiceController

        Inherits ApiController



        Public Function GetValue(ByVal certificate As String) As AreaCommon.Models.General.StatusWorkModel

            Dim status As New AreaCommon.Models.General.StatusWorkModel

            If AreaSecurity.authorization.checkInAllCertification(certificate) Then

                If AreaCommon.state.currentApplication = AppState.enumStateApplication.inRunning Then

                    status.value = AreaCommon.Models.General.StatusWorkModel.EnumStatusWork.onWork

                Else

                    status.value = AreaCommon.Models.General.StatusWorkModel.EnumStatusWork.offWork

                End If

            Else

                status.value = AreaCommon.Models.General.StatusWorkModel.EnumStatusWork.unAuthorized

            End If

            Return status

        End Function


    End Class


End Namespace
