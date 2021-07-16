﻿Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.DataFileManagement
Imports CHCCommonLibrary.AreaEngine.Encryption




Namespace AreaProtocol

    Public Class A1x4

        Public Class PriceTableFile

            Inherits BaseFileDB(Of CHCProtocolLibrary.AreaCommon.Models.Network.ItemPriceTableListModel)

        End Class

        Public Class RequestModel

            Inherits TransactionChainLibrary.AreaCommon.Request.RequestModel

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

            Inherits BaseFileDB(Of RequestModel)

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

                        .priceLists.items.Add(item)
                    Next
                End With

                Return True
            End Function

            Public Shared Function fromTransactionLedger(ByVal chainName As String, ByVal statePath As String, ByRef data As TransactionChainLibrary.AreaLedger.LedgerEngine.SingleRecordLedger) As Boolean
                Try
                    Dim engine As New PriceTableFile

                    engine.fileName = IO.Path.Combine(statePath, "Contents", data.detailInformation & ".content")

                    If engine.read() Then
                        AreaCommon.state.runtimeState.getDataChain(chainName).priceLists = engine.data
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

            Public Property log As CHCServerSupportLibrary.Support.LogEngine
            Public Property serviceState As CHCProtocolLibrary.AreaCommon.Models.Administration.ServiceStateResponse


            Private Function writeDataContent(ByVal statePath As String, ByRef priceList As CHCProtocolLibrary.AreaCommon.Models.Network.ItemPriceTableListModel, ByVal priceListHash As String) As Boolean
                Try
                    Dim engine As New PriceTableFile

                    engine.data = priceList

                    engine.fileName = IO.Path.Combine(statePath, "Contents", priceListHash & ".content")

                    Return engine.save()
                Catch ex As Exception
                    serviceState.currentAction.setError(Err.Number, ex.Message)

                    log.track("A1x4Manager.init", "Error:" & ex.Message, "error")

                    Return False
                End Try
            End Function

            Private Function writeDataIntoLedger(ByVal statePath As String) As Boolean
                Try
                    With AreaCommon.state.currentBlockLedger.currentRecord
                        .actionCode = "a1x4"
                        .approvedDate = CHCCommonLibrary.AreaEngine.Miscellaneous.timestampFromDateTime()
                        .detailInformation = HashSHA.generateSHA256(data.priceList.getHash())
                        .requester = data.publicWalletAddressRequester
                        .requestHash = data.requestHash
                    End With

                    writeDataContent(statePath, data.priceList, AreaCommon.state.currentBlockLedger.currentRecord.detailInformation)

                    If AreaCommon.state.currentBlockLedger.BlockComplete() Then
                        Return AreaCommon.state.currentBlockLedger.saveAndClean()
                    End If

                    Return False
                Catch ex As Exception
                    serviceState.currentAction.setError(Err.Number, ex.Message)

                    log.track("A1x4Manager.init", "Error:" & ex.Message, "error")

                    Return False
                End Try
            End Function


            Public Function init(ByRef paths As CHCProtocolLibrary.AreaSystem.VirtualPathEngine, ByVal priceList As CHCProtocolLibrary.AreaCommon.Models.Network.ItemPriceTableListModel, ByVal publicWalletIdAddress As String, ByVal privateKeyRAW As String) As Boolean
                Try
                    Dim requestFileEngine As New FileEngine

                    log.track("A1x4Manager.init", "Begin")

                    serviceState.currentAction.setAction("3x0005", "BuildManager - A1x4 - A1x4Manager")

                    If serviceState.requestCancelCurrentRunCommand Then Return False

                    data.priceList = priceList
                    data.publicWalletAddressRequester = publicWalletIdAddress
                    data.requestDateTimeStamp = CHCCommonLibrary.AreaEngine.Miscellaneous.timestampFromDateTime()
                    data.requestHash = data.getHash
                    data.signature = CHCProtocolLibrary.AreaWallet.Support.WalletAddressEngine.createSignature(privateKeyRAW, data.requestHash)

                    requestFileEngine.data = data

                    requestFileEngine.fileName = IO.Path.Combine(paths.workData.messages, data.requestHash & ".request")

                    If requestFileEngine.save() Then
                        log.track("A0x4Manager.init", "request - Saved")

                        If Not writeDataIntoLedger(paths.workData.state) Then
                            serviceState.currentAction.setError("-1", "Error during update ledger")
                            serviceState.currentAction.reset()

                            log.track("A1x4Manager.init", "Error: Error during update ledger", "error")

                            Return False
                        End If

                        log.track("A0x4Manager.init", "Ledger updated")

                        If Not RecoveryState.fromRequest(data) Then
                            serviceState.currentAction.setError("-1", "Error during update State")
                            serviceState.currentAction.reset()

                            log.track("A1x4Manager.init", "Error: Error during update State", "error")

                            Return False
                        End If

                        log.track("A0x4Manager.init", "State updated")

                        Return True
                    End If
                Catch ex As Exception
                    serviceState.currentAction.setError(Err.Number, ex.Message)

                    log.track("A1x4Manager.init", "Error:" & ex.Message, "error")
                End Try

                Return False
            End Function

        End Class

    End Class

End Namespace
