Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.Support
Imports CHCCommonLibrary.AreaEngine.DataFileManagement
Imports CHCCommonLibrary.AreaEngine.Encryption




Namespace AreaProtocol

    Public Class A1x3

        Public Class RequestModel

            Public Property requestDateTimeStamp As Double = 0
            Public Property publicWalletAddressRequester As String = ""
            Public Property requestHash As String = ""
            Public Property signature As String = ""

            Public Property chainName As String = ""
            Public Property additionalSetProtocol As String = ""

            Public Overrides Function toString() As String
                Dim tmp As String = ""

                tmp += MyBase.toString()
                tmp += chainName
                tmp += additionalSetProtocol

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
                AreaCommon.state.runtimeState.getDataChain(value.chainName).protocolSets.Add(value.additionalSetProtocol)

                Return True
            End Function

            Public Shared Function fromTransactionLedger(ByVal chainName As String, ByRef value As TransactionChainLibrary.AreaLedger.LedgerEngine.SingleRecordLedger) As Boolean
                AreaCommon.state.runtimeState.getDataChain(chainName).protocolSets.Add(value.detailInformation)

                Return True
            End Function

        End Class

        Public Class Manager

            Private data As New RequestModel

            Public Property log As LogEngine
            Public Property serviceState As CHCProtocolLibrary.AreaCommon.Models.Administration.ServiceStateResponse


            Private Function writeDataIntoLedger() As Boolean
                Try
                    With AreaCommon.state.currentBlockLedger.currentRecord
                        .actionCode = "a1x3"
                        .approvedDate = CHCCommonLibrary.AreaEngine.Miscellaneous.timestampFromDateTime
                        .detailInformation = data.additionalSetProtocol
                        .requester = data.publicWalletAddressRequester
                        .requestHash = data.requestHash
                    End With

                    If AreaCommon.state.currentBlockLedger.BlockComplete() Then
                        Return AreaCommon.state.currentBlockLedger.saveAndClean()
                    End If

                    Return False
                Catch ex As Exception
                    serviceState.currentAction.setError(Err.Number, ex.Message)

                    log.track("A1x3Manager.init", "Error:" & ex.Message, "error")

                    Return False
                End Try
            End Function


            Public Function init(ByRef paths As CHCProtocolLibrary.AreaSystem.VirtualPathEngine, ByVal setProtocolParameter As String, ByVal publicWalletIdAddress As String, ByVal privateKeyRAW As String) As Boolean
                Try
                    Dim requestFileEngine As New FileEngine

                    log.track("A1x3Manager.init", "Begin")

                    serviceState.currentAction.setAction("3x0004", "BuildManager - A1x3 - A1x3Manager")

                    If serviceState.requestCancelCurrentRunCommand Then Return False

                    data.additionalSetProtocol = setProtocolParameter
                    data.publicWalletAddressRequester = publicWalletIdAddress
                    data.requestDateTimeStamp = CHCCommonLibrary.AreaEngine.Miscellaneous.timestampFromDateTime(Now)
                    data.requestHash = data.getHash
                    data.signature = CHCProtocolLibrary.AreaWallet.Support.WalletAddressEngine.createSignature(privateKeyRAW, data.requestHash)

                    requestFileEngine.data = data

                    requestFileEngine.fileName = IO.Path.Combine(AreaCommon.paths.workData.currentVolume.requests, data.requestHash & ".request")

                    If requestFileEngine.save() Then
                        log.track("A1x3Manager.init", "request - Saved")

                        If Not writeDataIntoLedger() Then
                            serviceState.currentAction.setError("-1", "Error during update ledger")
                            serviceState.currentAction.reset()

                            log.track("A1x3Manager.init", "Error: Error during update ledger", "error")

                            Return False
                        End If

                        log.track("A1x3Manager.init", "Ledger updated")

                        If Not RecoveryState.fromRequest(data) Then
                            serviceState.currentAction.setError("-1", "Error create state")
                            serviceState.currentAction.reset()

                            log.track("A1x3Manager.init", "Error: Error during update State", "error")

                            Return False
                        End If

                        log.track("A1x3Manager.init", "State updated")

                        Return True
                    End If
                Catch ex As Exception
                    serviceState.currentAction.setError(Err.Number, ex.Message)

                    log.track("A1x3Manager.init", "Error:" & ex.Message, "error")
                End Try

                Return False
            End Function

        End Class

    End Class

End Namespace
