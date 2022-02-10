Imports System.Web.Http

Imports CHCProtocolLibrary.AreaCommon.Models.Settings



Namespace Controllers


    ' GET: api/v1.0/System/MasternodeInfoController
    <Route("SystemApi")>
    Public Class MasternodeInfoController

        Inherits ApiController




        Public Function GetValue() As AreaChain.NodesEngine.NodeInformation

            Dim result As New AreaChain.NodesEngine.NodeInformation

            Try

                If (AreaCommon.state.stateApplication = EnumStateApplication.inRunning) Then

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

                Else
                    result.response.error = True
                    result.response.offline = True
                End If

            Catch ex As Exception
                result.response.error = True
                result.response.offline = True
            End Try

            Return result

        End Function


    End Class


End Namespace

