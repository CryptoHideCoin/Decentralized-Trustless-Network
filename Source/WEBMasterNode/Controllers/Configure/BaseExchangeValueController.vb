Imports System.Net
Imports System.Web.Http
Imports System.Web
Imports CHCCommonLibrary.CHCEngines.Base.CHCStringExtensions






<RoutePrefix("api/v1/Configuration/ContractOfValueArchive")>
Public Class ContractOfValueArchiveController

    Inherits ApiController





    ' GET api/ContractOfValueArchive
    '<HttpGet> <Route("api/v1/Configuration/ContractOfValueArchive")>
    Public Function getValues() As IEnumerable(Of String)

        Return AreaCommon.contractsOfValueManager.getList()

    End Function



    ' GET api/ContractOfValueArchive/name
    '<HttpGet> <Route("api/v1/Configuration/ContractOfValueArchive")>
    Public Function getValue(ByVal name As String) As CHCContractOfValueEngineLibrary.Models.ContractOfValueModel

        Return AreaCommon.contractsOfValueManager.item(True, HttpUtility.UrlDecode(name))

    End Function



    ' POST api/ContractOfValueArchive
    '<HttpGet> <Route("api/v1/Configuration/ContractOfValueArchive")>
    Public Sub postValue(<FromBody()> ByVal value As CHCContractOfValueEngineLibrary.Models.ContractOfValueRequestModel)

        value.symbol.decodeSymbol()

        AreaCommon.contractsOfValueManager.addNew(value)

    End Sub



    ' PUT api/ContractOfValueArchive/name
    '<HttpGet> <Route("api/v1/Configuration/ContractOfValueArchive")>
    Public Sub putValue(ByVal name As String, <FromBody()> ByVal value As CHCContractOfValueEngineLibrary.Models.ContractOfValueRequestModel)

        value.symbol.decodeSymbol()

        AreaCommon.contractsOfValueManager.update(name, value)

    End Sub



    ' DELETE api/ContractOfValueArchive/name
    '<HttpGet> <Route("api/v1/Configuration/ContractOfValueArchive")>
    Public Sub deleteValue(ByVal name As String)

        AreaCommon.contractsOfValueManager.delete(name)

    End Sub


End Class
