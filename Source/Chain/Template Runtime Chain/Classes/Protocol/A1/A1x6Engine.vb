Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.DataFileManagement
Imports CHCCommonLibrary.AreaEngine.Encryption




Namespace AreaProtocol

    Public Class A1x6

        Public Class RequestModel

            Inherits TransactionChainLibrary.AreaCommon.Request.RequestModel

            Public Property chainName As String = ""
            Public Property generalConditionsDocument As String = ""

            Public Overrides Function toString() As String
                Dim tmp As String = ""

                tmp += MyBase.toString()
                tmp += chainName
                tmp += GeneralConditionsDocument

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
                AreaCommon.state.runtimeState.getDataChain(value.chainName).policyPrivacy = value.generalConditionsDocument

                Return True
            End Function

            Public Shared Function fromTransactionLedger(ByVal statePath As String, ByVal chainName As String, ByRef data As TransactionChainLibrary.AreaLedger.LedgerEngine.SingleRecordLedger) As Boolean
                Try
                    AreaCommon.state.runtimeState.activeChains(chainName).generalCondition = TransactionChainLibrary.AreaEngine.Ledger.State.StateEngine.readContentFromFile(statePath, data.detailInformation)

                    Return True
                Catch ex As Exception
                    Return False
                End Try

                Return True
            End Function

        End Class

        Public Class Manager

            Private data As New RequestModel

            Public Property log As CHCServerSupportLibrary.Support.LogEngine
            Public Property serviceState As CHCProtocolLibrary.AreaCommon.Models.Administration.ServiceStateResponse


            Private Function writeDataIntoLedger(ByVal statePath As String) As Boolean
                Try
                    With AreaCommon.state.currentBlockLedger.currentRecord
                        .actionCode = "a1x6"
                        .approvedDate = CHCCommonLibrary.AreaEngine.Miscellaneous.timestampFromDateTime
                        .detailInformation = HashSHA.generateSHA256(data.generalConditionsDocument)
                        .requester = data.publicWalletAddressRequester
                        .requestHash = data.requestHash
                    End With

                    TransactionChainLibrary.AreaEngine.Ledger.State.StateEngine.writeDataContent(statePath, data.generalConditionsDocument, AreaCommon.state.currentBlockLedger.currentRecord.detailInformation)

                    If AreaCommon.state.currentBlockLedger.BlockComplete() Then
                        Return AreaCommon.state.currentBlockLedger.saveAndClean()
                    End If

                    Return False
                Catch ex As Exception
                    serviceState.currentAction.setError(Err.Number, ex.Message)

                    log.track("A1x6Manager.init", "Error:" & ex.Message, "error")

                    Return False
                End Try
            End Function


            Public Function init(ByRef paths As CHCProtocolLibrary.AreaSystem.VirtualPathEngine, ByVal generalConditionParameter As String, ByVal publicWalletIdAddress As String, ByVal privateKeyRAW As String) As Boolean
                Try
                    Dim requestFileEngine As New FileEngine

                    log.track("A1x6Manager.init", "Begin")

                    serviceState.currentAction.setAction("3x0005", "BuildManager - A1x6 - A1x6Manager")

                    If serviceState.requestCancelCurrentRunCommand Then Return False

                    data.generalConditionsDocument = generalConditionParameter
                    data.publicWalletAddressRequester = publicWalletIdAddress
                    data.requestDateTimeStamp = CHCCommonLibrary.AreaEngine.Miscellaneous.timestampFromDateTime()
                    data.requestHash = data.getHash
                    data.signature = CHCProtocolLibrary.AreaWallet.Support.WalletAddressEngine.createSignature(privateKeyRAW, data.requestHash)

                    requestFileEngine.data = data

                    requestFileEngine.fileName = IO.Path.Combine(paths.workData.messages, data.requestHash & ".request")

                    If requestFileEngine.save() Then
                        log.track("A1x6Manager.init", "request - Saved")

                        If Not writeDataIntoLedger(paths.workData.state) Then
                            serviceState.currentAction.setError("-1", "Error during update ledger")
                            serviceState.currentAction.reset()

                            log.track("A1x6Manager.init", "Error: Error during update ledger", "error")

                            Return False
                        End If

                        log.track("A1x6Manager.init", "Ledger updated")

                        If Not RecoveryState.fromRequest(data) Then
                            serviceState.currentAction.setError("-1", "Error create state")
                            serviceState.currentAction.reset()

                            log.track("A1x6Manager.init", "Error: Error during update State", "error")

                            Return False
                        End If

                        log.track("A1x6Manager.init", "State updated")

                        Return True
                    End If
                Catch ex As Exception
                    serviceState.currentAction.setError(Err.Number, ex.Message)

                    log.track("A1x6Manager.init", "Error:" & ex.Message, "error")
                End Try

                Return False
            End Function

        End Class

    End Class

End Namespace
