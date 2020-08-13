Imports System.Web.Http



Namespace Controllers


    ' GET: api/v1.0/System/TestServiceController
    <Route("SystemApi")>
    Public Class TestServiceController

        Inherits ApiController




        Public Function GetValue() As Models.BooleanModel

            Return New Models.BooleanModel() With {.value = True}

        End Function


    End Class


End Namespace