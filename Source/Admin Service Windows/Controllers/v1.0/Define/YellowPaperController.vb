Option Compare Text
Option Explicit On

Imports System.Web.Http



Namespace Controllers


    ' GET: api/v1.0/Define/YellowPapersController
    ''' <summary>
    ''' ...
    ''' </summary>
    <Route("DefinitionApi")>
    Public Class YellowPapersController

        Inherits ApiController


        ' GET api/values
        Public Function getValues(ByVal certificate As String) As IEnumerable(Of AreaCommon.Models.Define.ItemKeyDescriptionModel)

            Return AreaController.getValues(certificate, AreaApplication.yellowPapers)

        End Function


        ' GET api/values/5
        Public Function getValue(ByVal certificate As String, ByVal id As String) As AreaCommon.Models.Define.GenericPaperResponseModel

            Return AreaController.getValue(certificate, id, AreaApplication.yellowPapers, New AreaCommon.Models.Define.GenericPaperResponseModel)

        End Function


        ' PUT api/values/5
        Public Function putValue(ByVal certificate As String, ByVal originalId As String, <FromBody()> ByVal value As AreaCommon.Models.Define.GenericPaperModel) As String

            Return AreaController.putValue(certificate, originalId, value, AreaApplication.yellowPapers, New AreaCommon.Models.Define.GenericPaperResponseModel)

        End Function


        ' DELETE api/values/5
        Public Function deleteValue(ByVal certificate As String, ByVal id As String) As String

            Return AreaController.deleteValue(certificate, id, AreaApplication.yellowPapers)

        End Function


    End Class


End Namespace


