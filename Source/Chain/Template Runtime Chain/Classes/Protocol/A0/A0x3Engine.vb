Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.DataFileManagement
Imports CHCCommonLibrary.AreaEngine.Encryption




Namespace AreaProtocol

    Public Class A0x3

        Public Class PrimaryAssetFile

            Inherits BaseFileDB(Of CHCProtocolLibrary.AreaCommon.Models.Network.AssetModel)

        End Class

        Public Class RequestModel

            Inherits TransactionChainLibrary.AreaCommon.Request.RequestModel

            Public Property primaryAsset As New CHCProtocolLibrary.AreaCommon.Models.Network.AssetModel

            Public Overrides Function toString() As String
                Dim tmp As String = ""

                tmp += MyBase.toString()
                tmp += primaryAsset.toString()

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
                With AreaCommon.state.runtimeState.activeNetwork.primaryAssetData
                    .burnable = value.primaryAsset.burnable
                    .digit = value.primaryAsset.digit
                    .intervalStaking = value.primaryAsset.intervalStaking
                    .stakeable = value.primaryAsset.stakeable
                    .name = value.primaryAsset.name
                    .nameUnit = value.primaryAsset.nameUnit
                    .prestake = value.primaryAsset.prestake
                    .qtaInitialStake = value.primaryAsset.qtaInitialStake
                    .qtaTotal = value.primaryAsset.qtaTotal
                    .shortName = value.primaryAsset.shortName
                    .stakeable = value.primaryAsset.stakeable
                    .symbol = value.primaryAsset.symbol
                End With

                Return True
            End Function

            Public Shared Function fromTransactionLedger(ByVal statePath As String, ByRef data As TransactionChainLibrary.AreaLedger.LedgerEngine.SingleRecordLedger) As Boolean
                Try
                    Dim engine As New PrimaryAssetFile

                    engine.fileName = IO.Path.Combine(statePath, "Contents", data.detailInformation & ".content")

                    If engine.read() Then
                        AreaCommon.state.runtimeState.activeNetwork.primaryAssetData = engine.data
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


            Private Function writeDataContent(ByVal statePath As String, ByRef primaryAsset As CHCProtocolLibrary.AreaCommon.Models.Network.AssetModel, ByVal primaryAssetHash As String) As Boolean
                Try
                    Dim engine As New PrimaryAssetFile

                    engine.data = primaryAsset

                    engine.fileName = IO.Path.Combine(statePath, "Contents", primaryAssetHash & ".content")

                    Return engine.save()
                Catch ex As Exception
                    serviceState.currentAction.setError(Err.Number, ex.Message)

                    log.track("A0x3Manager.init", "Error:" & ex.Message, "error")

                    Return False
                End Try
            End Function

            Private Function writeDataIntoLedger(ByVal statePath As String) As Boolean
                Try
                    With AreaCommon.state.currentBlockLedger.currentRecord
                        .actionCode = "a0x3"
                        .approvedDate = CHCCommonLibrary.AreaEngine.Miscellaneous.timestampFromDateTime()
                        .detailInformation = HashSHA.generateSHA256(data.primaryAsset.getHash())
                        .requester = data.publicWalletAddressRequester
                        .requestHash = data.requestHash
                    End With

                    writeDataContent(statePath, data.primaryAsset, AreaCommon.state.currentBlockLedger.currentRecord.detailInformation)

                    If AreaCommon.state.currentBlockLedger.BlockComplete() Then
                        Return AreaCommon.state.currentBlockLedger.saveAndClean()
                    End If

                    Return False
                Catch ex As Exception
                    serviceState.currentAction.setError(Err.Number, ex.Message)

                    log.track("A0x3Manager.init", "Error:" & ex.Message, "error")

                    Return False
                End Try
            End Function


            Public Function init(ByRef paths As CHCProtocolLibrary.AreaSystem.VirtualPathEngine, ByVal primaryAsset As CHCProtocolLibrary.AreaCommon.Models.Network.AssetModel, ByVal publicWalletIdAddress As String, ByVal privateKeyRAW As String) As Boolean
                Try
                    Dim requestFileEngine As New FileEngine

                    log.track("A0x3Manager.init", "Begin")

                    serviceState.currentAction.setAction("1x0004", "BuildManager - A0x3 - A0x3Manager")

                    If serviceState.requestCancelCurrentRunCommand Then Return False

                    data.primaryAsset = primaryAsset
                    data.publicWalletAddressRequester = publicWalletIdAddress
                    data.requestDateTimeStamp = CHCCommonLibrary.AreaEngine.Miscellaneous.timestampFromDateTime()
                    data.requestHash = data.getHash
                    data.signature = CHCProtocolLibrary.AreaWallet.Support.WalletAddressEngine.createSignature(privateKeyRAW, data.requestHash)

                    requestFileEngine.data = data

                    requestFileEngine.fileName = IO.Path.Combine(paths.workData.messages, data.requestHash & ".request")

                    If requestFileEngine.save() Then
                        log.track("A0x3Manager.init", "request - Saved")

                        If Not writeDataIntoLedger(paths.workData.state) Then
                            serviceState.currentAction.setError("-1", "Error during update ledger")
                            serviceState.currentAction.reset()

                            log.track("A0x3Manager.init", "Error: Error during update ledger", "error")

                            Return False
                        End If

                        log.track("A0x3Manager.init", "Ledger updated")

                        If Not RecoveryState.fromRequest(data) Then
                            serviceState.currentAction.setError("-1", "Error during update State")
                            serviceState.currentAction.reset()

                            log.track("A0x3Manager.init", "Error: Error during update State", "error")

                            Return False
                        End If

                        log.track("A0x3Manager.init", "State updated")

                        Return True
                    End If
                Catch ex As Exception
                    serviceState.currentAction.setError(Err.Number, ex.Message)

                    log.track("A0x3Manager.init", "Error:" & ex.Message, "error")
                End Try

                Return False
            End Function

        End Class

    End Class

End Namespace
