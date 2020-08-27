Imports System.Web.Http



Namespace Controllers


    ' GET: api/v1.0/Chain/MasternodeInfoController
    <Route("ChainApi")>
    Public Class MasternodeInfoController

        Inherits ApiController




        Public Function GetValue() As AreaChain.NodesEngine.NodeInformation

            Dim result As New AreaChain.NodesEngine.NodeInformation

            Try

                If AreaCommon.settings.data.intranetMode Then

                    result.address = AreaCommon.state.localIpAddress

                Else

                    result.address = AreaCommon.state.publicIpAddress

                End If

                result.associatedWalletAddress = AreaCommon.settings.data.walletAddress
                result.virtualName = AreaCommon.settings.data.virtualName

                For Each item In AreaCommon.settings.data.services

                    result.serviceList.Add(item)

                Next

                result.configureTransactionDefinitionID = AreaCommon.state.transactionChainConfigID
                result.masternodeConnectedChainStartUp = AreaCommon.state.connectedMoment
                result.warrantyCoin = 0

            Catch ex As Exception

            End Try

            Return result

        End Function


    End Class


End Namespace

