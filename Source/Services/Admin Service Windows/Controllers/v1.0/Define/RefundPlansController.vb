Option Compare Text
Option Explicit On

Imports System.Web.Http



Namespace Controllers


    ' GET: api/v1.0/Define/RefundPlansController
    ''' <summary>
    ''' ...
    ''' </summary>
    <Route("DefinitionApi")>
    Public Class RefundPlansController

        Inherits ApiController


        ' GET api/values
        Public Function getValues(ByVal certificate As String) As IEnumerable(Of AreaCommon.Models.Define.ItemKeyDescriptionModel)

            Return AreaController.getValues(certificate, AreaApplication.refundPlans)

        End Function


        ' GET api/values/5
        Public Function getValue(ByVal certificate As String, ByVal id As String) As AreaCommon.Models.Define.RefundPlanResponseModel

            Return AreaController.getValue(certificate, id, AreaApplication.refundPlans, New AreaCommon.Models.Define.RefundPlanResponseModel)

        End Function


        ' PUT api/values/5
        Public Function putValue(ByVal certificate As String, ByVal originalId As String, <FromBody()> ByVal value As AreaCommon.Models.Define.RefundPlanBaseModel) As String

            Return AreaController.putValue(certificate, originalId, value, AreaApplication.refundPlans, New AreaCommon.Models.Define.RefundPlanResponseModel)

        End Function


        ' DELETE api/values/5
        Public Function deleteValue(ByVal certificate As String, ByVal id As String) As String

            Return AreaController.deleteValue(certificate, id, AreaApplication.refundPlans)

        End Function


    End Class


End Namespace