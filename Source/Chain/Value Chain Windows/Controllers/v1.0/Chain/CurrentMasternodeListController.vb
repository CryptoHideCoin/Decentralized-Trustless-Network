Imports System.Web.Http



Namespace Controllers


    ' GET: api/v1.0/Chain/CurrentMasternodeListController
    <Route("ChainApi")>
    Public Class CurrentMasternodeListController

        Inherits ApiController




        Public Function GetValue() As List(Of AreaChain.NodeList.NodeAtom)

            Return AreaCommon.nodes.toChainServiceList()

        End Function


    End Class


End Namespace
