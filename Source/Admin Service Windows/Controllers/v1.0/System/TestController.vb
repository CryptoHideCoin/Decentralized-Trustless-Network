Imports System.Web.Http



Namespace Controllers


    ' GET: api/v1.0/System/TestServiceController
    <Route("SystemApi")>
    Public Class TestServiceController

        Inherits ApiController


        Public Function GetValue() As Boolean

            Return True

        End Function


    End Class


End Namespace