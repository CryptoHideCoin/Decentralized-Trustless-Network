Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.Support
Imports CHCCommonLibrary.AreaEngine.DataFileManagement.XML
Imports CHCCommonLibrary.AreaEngine.Encryption




Namespace AreaProtocol

    Public Class A1x4

        Public Class PriceTableFile

            Inherits BaseFile(Of CHCProtocolLibrary.AreaCommon.Models.Network.ItemPriceTableListModel)

        End Class

        Public Class RequestModel

            Public Property requestDateTimeStamp As Double = 0
            Public Property publicWalletAddressRequester As String = ""
            Public Property requestHash As String = ""
            Public Property signature As String = ""

            Public Property chainName As String = ""
            Public Property priceList As New CHCProtocolLibrary.AreaCommon.Models.Network.ItemPriceTableListModel

            Public Overrides Function toString() As String
                Dim tmp As String = ""

                tmp += MyBase.toString()
                tmp += chainName
                tmp += priceList.toString()

                Return tmp
            End Function

            Public Function getHash() As String
                Return HashSHA.generateSHA256(Me.toString())
            End Function

        End Class

        Public Class FileEngine

            Inherits BaseFile(Of RequestModel)

        End Class

        Public Class RecoveryState

            Public Shared Function fromRequest(ByRef value As RequestModel) As Boolean
                Dim item As CHCProtocolLibrary.AreaCommon.Models.Network.ItemPriceTableModel

                With AreaCommon.state.runtimeState.getDataChain(value.chainName)
                    For Each price In value.priceList.items
                        item = New CHCProtocolLibrary.AreaCommon.Models.Network.ItemPriceTableModel

                        item.code = price.code
                        item.contribute = price.contribute
                        item.description = price.description

                        .priceLists.value.items.Add(item)
                    Next
                End With

                Return True
            End Function

            Public Shared Function fromTransactionLedger(ByVal chainName As String, ByVal statePath As String, ByRef data As TransactionChainLibrary.AreaLedger.SingleTransactionLedger) As Boolean
                Try
                    Dim engine As New PriceTableFile

                    engine.fileName = IO.Path.Combine(statePath, "Contents", data.detailInformation & ".content")

                    If engine.read() Then
                        AreaCommon.state.runtimeState.getDataChain(chainName).priceLists.value = engine.data
                    End If

                    engine.data = Nothing

                    engine = Nothing

                    Return True
                Catch ex As Exception
                    Return False
                End Try
            End Function

        End Class

        Public Class Manager

            Private data As New RequestModel

            Public Property log As LogEngine
            Public Property currentService As CHCProtocolLibrary.AreaCommon.Models.Administration.ServiceStateResponse


            Private Function writeDataContent(ByVal statePath As String, ByRef priceList As CHCProtocolLibrary.AreaCommon.Models.Network.ItemPriceTableListModel, ByVal priceListHash As String) As Boolean
                Try
                    Dim engine As New PriceTableFile

                    engine.data = priceList

                    engine.fileName = IO.Path.Combine(statePath, "Contents", priceListHash & ".content")

                    Return engine.save()
                Catch ex As Exception
                    currentService.currentAction.setError(Err.Number, ex.Message)

                    log.track("A1x4Manager.init", ex.Message, "fatal")

                    Return False
                End Try
            End Function

            Private Function writeDataIntoLedger(ByVal contentStatePath As String) As CHCCommonLibrary.AreaCommon.Models.General.IdentifyLastTransaction
                Try
                    With AreaCommon.state.currentBlockLedger.currentApprovedTransaction
                        .actionCode = "a1x4"
                        .registrationTimeStamp = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()
                        .detailInformation = HashSHA.generateSHA256(data.priceList.getHash())
                        .requesterPublicAddress = data.publicWalletAddressRequester
                        .requestHash = data.requestHash
                    End With

                    writeDataContent(contentStatePath, data.priceList, AreaCommon.state.currentBlockLedger.currentApprovedTransaction.detailInformation)

                    'If AreaCommon.state.currentBlockLedger.BlockComplete() Then
                    Return AreaCommon.state.currentBlockLedger.saveAndClean()
                    'End If
                Catch ex As Exception
                    currentService.currentAction.setError(Err.Number, ex.Message)

                    log.track("A1x4Manager.init", ex.Message, "fatal")
                End Try

                Return New CHCCommonLibrary.AreaCommon.Models.General.IdentifyLastTransaction
            End Function


            Public Function init(ByRef paths As CHCProtocolLibrary.AreaSystem.VirtualPathEngine, ByVal priceList As CHCProtocolLibrary.AreaCommon.Models.Network.ItemPriceTableListModel, ByVal publicWalletIdAddress As String, ByVal privateKeyRAW As String) As Boolean
                Try
                    Dim requestFileEngine As New FileEngine
                    Dim ledgerCoordinate As CHCCommonLibrary.AreaCommon.Models.General.IdentifyLastTransaction

                    log.track("A1x4Manager.init", "Begin")

                    currentService.currentAction.setAction("3x0005", "BuildManager - A1x4 - A1x4Manager")

                    If currentService.requestCancelCurrentRunCommand Then Return False

                    data.priceList = priceList
                    data.publicWalletAddressRequester = publicWalletIdAddress
                    data.requestDateTimeStamp = CHCCommonLibrary.AreaEngine.Miscellaneous.timestampFromDateTime()
                    data.requestHash = data.getHash
                    data.signature = CHCProtocolLibrary.AreaWallet.Support.WalletAddressEngine.createSignature(privateKeyRAW, data.requestHash)

                    requestFileEngine.data = data

                    requestFileEngine.fileName = IO.Path.Combine(AreaCommon.paths.workData.currentVolume.requests, data.requestHash & ".request")

                    If requestFileEngine.save() Then
                        log.track("A0x4Manager.init", "request - Saved")

                        ledgerCoordinate = writeDataIntoLedger(paths.workData.state.contents)

                        If (ledgerCoordinate.coordinate.Length = 0) Then
                            currentService.currentAction.setError("-1", "Error during update ledger")
                            currentService.currentAction.reset()

                            log.track("A1x4Manager.init", "Error: Error during update ledger", "fatal")

                            Return False
                        End If

                        log.track("A0x4Manager.init", "Ledger updated")

                        If Not RecoveryState.fromRequest(data) Then
                            currentService.currentAction.setError("-1", "Error during update State")
                            currentService.currentAction.reset()

                            log.track("A1x4Manager.init", "Error: Error during update State", "fatal")

                            Return False
                        End If

                        log.track("A0x4Manager.init", "State updated")

                        Return True
                    End If
                Catch ex As Exception
                    currentService.currentAction.setError(Err.Number, ex.Message)

                    log.track("A1x4Manager.init", ex.Message, "fatal")
                End Try

                Return False
            End Function

        End Class

    End Class

End Namespace
