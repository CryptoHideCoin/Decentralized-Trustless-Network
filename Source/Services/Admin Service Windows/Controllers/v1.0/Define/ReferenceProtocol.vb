Option Compare Text
Option Explicit On

Imports System.Web.Http



Namespace Controllers


    ' GET: api/v1.0/Define/ReferenceProtocolsController
    ''' <summary>
    ''' ...
    ''' </summary>
    <Route("DefinitionApi")>
    Public Class ReferenceProtocolsController

        Inherits ApiController


        ' GET api/values
        Public Function getValues(ByVal certificate As String) As IEnumerable(Of AreaCommon.Models.Define.ItemKeyDescriptionModel)

            Return AreaController.getValues(certificate, AreaApplication.referenceProtocol)

        End Function


        ' GET api/values/5
        Public Function getValue(ByVal certificate As String, ByVal id As String) As AreaCommon.Models.Define.ReferenceProtocolResponseModel

            Return AreaController.getValue(certificate, id, AreaApplication.referenceProtocol, New AreaCommon.Models.Define.ReferenceProtocolResponseModel)

        End Function


        ' PUT api/values/5
        Public Function putValue(ByVal certificate As String, ByVal originalId As String, <FromBody()> ByVal value As AreaCommon.Models.Define.ReferenceProtocolBaseModel) As String

            Return AreaController.putValue(certificate, originalId, value, AreaApplication.referenceProtocol, New AreaCommon.Models.Define.ReferenceProtocolBaseModel)

        End Function


        ' DELETE api/values/5
        Public Function deleteValue(ByVal certificate As String, ByVal id As String) As String

            Return AreaController.deleteValue(certificate, id, AreaApplication.referenceProtocol)

        End Function


    End Class


End Namespace
