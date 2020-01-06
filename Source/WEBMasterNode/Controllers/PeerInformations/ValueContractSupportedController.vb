Imports System.Web.Http






<RoutePrefix("api/v1/PeerInformation/CryptoAssetSupported")>
Public Class CryptoAssetSupportedController

    Inherits ApiController





    ' GET api/CryptoAssetSupported
    '<HttpGet> <Route("api/v1/PeerInformation/CryptoAssetSupported")>
    Public Function getValues() As IEnumerable(Of String)

        Return AreaCommon.cryptoAssetDefinitionManager.getUsedList()

    End Function

    ' GET api/CryptoAssetSupported/id
    '<HttpGet> <Route("api/v1/PeerInformation/CryptoAssetSupported")>
    Public Function getValue(ByVal id As String) As CHCDefinitionEngineLibrary.Models.CryptoAssetModel

        Return AreaCommon.cryptoAssetDefinitionManager.item(False, id)

    End Function



End Class