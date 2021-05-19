Imports System.Web.Http

Imports CHCProtocolLibrary.AreaCommon.Models



Namespace Controllers


    ' GET: api/v1.0/System/TestServiceController
    <Route("SystemApi")>
    Public Class TestServiceController

        Inherits ApiController




        Public Function GetValue() As General.BooleanModel
            Return New General.BooleanModel() With {.value = True}
        End Function


    End Class


End Namespace