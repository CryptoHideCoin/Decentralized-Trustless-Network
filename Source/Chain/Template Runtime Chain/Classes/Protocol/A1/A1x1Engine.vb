﻿Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.DataFileManagement
Imports CHCCommonLibrary.AreaEngine.Encryption




Namespace AreaProtocol

    Public Class A1x1

        Public Class RequestModel

            Inherits TransactionChainLibrary.AreaCommon.Request.RequestModel

            Public Property chainName As String = ""
            Public Property chainDescription As String = ""

            Public Overrides Function toString() As String
                Dim tmp As String = ""

                tmp += MyBase.toString()
                tmp += chainName
                tmp += chainDescription

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
                AreaCommon.state.runtimeState.getDataChain(value.chainName).description = value.chainDescription

                Return True
            End Function

            Public Shared Function fromTransactionLedger(ByVal chainName As String, ByRef value As TransactionChainLibrary.AreaLedger.LedgerEngine.SingleRecordLedger) As Boolean
                AreaCommon.state.runtimeState.getDataChain(chainName).description = value.detailInformation

                Return True
            End Function

        End Class

        Public Class Manager

            Private data As New RequestModel

            Public Property log As CHCServerSupportLibrary.Support.LogEngine
            Public Property serviceState As CHCProtocolLibrary.AreaCommon.Models.Administration.ServiceStateResponse


            Private Function writeDataIntoLedger() As Boolean
                Try
                    With AreaCommon.state.currentBlockLedger.currentRecord
                        .actionCode = "a1x1"
                        .approvedDate = CHCCommonLibrary.AreaEngine.Miscellaneous.timestampFromDateTime
                        .detailInformation = data.chainDescription
                        .requester = data.publicWalletAddressRequester
                        .requestHash = data.requestHash
                    End With

                    If AreaCommon.state.currentBlockLedger.BlockComplete() Then
                        Return AreaCommon.state.currentBlockLedger.saveAndClean()
                    End If

                    Return False
                Catch ex As Exception
                    serviceState.currentAction.setError(Err.Number, ex.Message)

                    log.track("A1x1Manager.init", "Error:" & ex.Message, "error")

                    Return False
                End Try
            End Function


            Public Function init(ByRef paths As CHCProtocolLibrary.AreaSystem.VirtualPathEngine, ByVal chainDescriptionParameter As String, ByVal publicWalletIdAddress As String, ByVal privateKeyRAW As String) As Boolean
                Try
                    Dim requestFileEngine As New FileEngine

                    log.track("A1x1Manager.init", "Begin")

                    serviceState.currentAction.setAction("3x0002", "BuildManager - A1x1 - A1x1Manager")

                    If serviceState.requestCancelCurrentRunCommand Then Return False

                    data.chainDescription = chainDescriptionParameter
                    data.publicWalletAddressRequester = publicWalletIdAddress
                    data.requestDateTimeStamp = CHCCommonLibrary.AreaEngine.Miscellaneous.timestampFromDateTime(Now)
                    data.requestHash = data.getHash
                    data.signature = CHCProtocolLibrary.AreaWallet.Support.WalletAddressEngine.createSignature(privateKeyRAW, data.requestHash)

                    requestFileEngine.data = data

                    requestFileEngine.fileName = IO.Path.Combine(paths.workData.messages, data.requestHash & ".request")

                    If requestFileEngine.save() Then
                        log.track("A1x1Manager.init", "request - Saved")

                        If Not writeDataIntoLedger() Then
                            serviceState.currentAction.setError("-1", "Error during update ledger")
                            serviceState.currentAction.reset()

                            log.track("A1x1Manager.init", "Error: Error during update ledger", "error")

                            Return False
                        End If

                        log.track("A1x1Manager.init", "Ledger updated")

                        If Not RecoveryState.fromRequest(data) Then
                            serviceState.currentAction.setError("-1", "Error create state")
                            serviceState.currentAction.reset()

                            log.track("A1x1Manager.init", "Error: Error during update State", "error")

                            Return False
                        End If

                        log.track("A1x1Manager.init", "State updated")

                        Return True
                    End If
                Catch ex As Exception
                    serviceState.currentAction.setError(Err.Number, ex.Message)

                    log.track("A1x1Manager.init", "Error:" & ex.Message, "error")
                End Try

                Return False
            End Function

        End Class

    End Class

End Namespace
