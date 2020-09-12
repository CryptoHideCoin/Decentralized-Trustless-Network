Imports System.Web.Http



Namespace Controllers


    ' GET: api/v1.0/System/TestServiceController
    <Route("SystemApi")>
    Public Class TestServiceController

        Inherits ApiController




        Public Function GetValue() As AreaCommon.Models.General.BooleanModel

            Return New AreaCommon.Models.General.BooleanModel() With {.value = True}

        End Function


    End Class


End Namespace