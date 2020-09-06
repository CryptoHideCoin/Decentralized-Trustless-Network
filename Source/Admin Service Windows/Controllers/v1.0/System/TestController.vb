Imports System.Web.Http



Namespace Controllers


    ' GET: api/v1.0/System/TestServiceController
    ''' <summary>
    ''' This API permit a client application of know if the masternode is alive
    ''' </summary>
    <Route("SystemApi")>
    Public Class TestServiceController

        Inherits ApiController


        Public Function GetValue() As AreaCommon.Models.General.BooleanModel

            Dim result As New AreaCommon.Models.General.BooleanModel

            result.value = True

            Return result

        End Function


    End Class


End Namespace