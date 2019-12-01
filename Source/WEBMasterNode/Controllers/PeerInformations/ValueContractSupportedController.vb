Imports System.Web.Http






<RoutePrefix("api/v1/PeerInformation/ValueContractSupported")>
Public Class ValueContractSupportedController

    Inherits ApiController





    ' GET api/ValueContractSupported
    '<HttpGet> <Route("api/v1/PeerInformation/ValueContractSupported")>
    Public Function getValues() As IEnumerable(Of String)

        Return AreaCommon.contractsOfValueManager.getUsedList()

    End Function

    ' GET api/ValueContractSupported/id
    '<HttpGet> <Route("api/v1/PeerInformation/ValueContractSupported")>
    Public Function getValue(ByVal id As String) As CHCContractOfValueEngineLibrary.Models.ContractOfValueModel

        Return AreaCommon.contractsOfValueManager.item(False, id)

    End Function



End Class