Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.Support
Imports CHCCommonLibrary.AreaEngine.DataFileManagement.XML
Imports CHCCommonLibrary.AreaEngine.Encryption




Namespace AreaProtocol

    Public Class A1x1

        Public Class RequestModel

            Public Property requestDateTimeStamp As Double = 0
            Public Property publicWalletAddressRequester As String = ""
            Public Property requestHash As String = ""
            Public Property signature As String = ""

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

            Inherits BaseFile(Of RequestModel)

        End Class

        Public Class RecoveryState

            Public Shared Function fromRequest(ByRef value As RequestModel, ByRef transactionChainRecord As CHCCommonLibrary.AreaCommon.Models.General.IdentifyLastTransaction) As Boolean

                With AreaCommon.state.runtimeState.getDataChain(value.chainName).description
                    .coordinate = transactionChainRecord.coordinate
                    .hash = transactionChainRecord.hash
                    .value = value.chainDescription
                End With

                Return True
            End Function

            Public Shared Function fromTransactionLedger(ByVal chainName As String, ByRef value As TransactionChainLibrary.AreaLedger.SingleTransactionLedger) As Boolean
                AreaCommon.state.runtimeState.getDataChain(chainName).description.value = value.detailInformation

                Return True
            End Function

        End Class

        Public Class Manager

            Private data As New RequestModel

            Public Property log As LogEngine
            Public Property currentService As CHCProtocolLibrary.AreaCommon.Models.Administration.ServiceStateResponse


            Private Function writeDataIntoLedger() As CHCCommonLibrary.AreaCommon.Models.General.IdentifyLastTransaction
                Try
                    With AreaCommon.state.currentBlockLedger.currentApprovedTransaction
                        .actionCode = "a1x1"
                        .registrationTimeStamp = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime
                        .detailInformation = data.chainDescription
                        .requesterPublicAddress = data.publicWalletAddressRequester
                        .requestHash = data.requestHash
                    End With

                    'If AreaCommon.state.currentBlockLedger.BlockComplete() Then
                    Return AreaCommon.state.currentBlockLedger.saveAndClean()
                    'End If
                Catch ex As Exception
                    currentService.currentAction.setError(Err.Number, ex.Message)

                    log.track("A1x1Manager.init", ex.Message, "fatal")
                End Try

                Return New CHCCommonLibrary.AreaCommon.Models.General.IdentifyLastTransaction
            End Function


            Public Function init(ByRef paths As CHCProtocolLibrary.AreaSystem.VirtualPathEngine, ByVal chainDescriptionParameter As String, ByVal publicWalletIdAddress As String, ByVal privateKeyRAW As String) As Boolean
                Try
                    Dim requestFileEngine As New FileEngine
                    Dim ledgerCoordinate As CHCCommonLibrary.AreaCommon.Models.General.IdentifyLastTransaction

                    log.track("A1x1Manager.init", "Begin")

                    currentService.currentAction.setAction("3x0002", "BuildManager - A1x1 - A1x1Manager")

                    If currentService.requestCancelCurrentRunCommand Then Return False

                    data.chainDescription = chainDescriptionParameter
                    data.publicWalletAddressRequester = publicWalletIdAddress
                    data.requestDateTimeStamp = CHCCommonLibrary.AreaEngine.Miscellaneous.timestampFromDateTime(Now)
                    data.requestHash = data.getHash
                    data.signature = CHCProtocolLibrary.AreaWallet.Support.WalletAddressEngine.createSignature(privateKeyRAW, data.requestHash)

                    requestFileEngine.data = data

                    requestFileEngine.fileName = IO.Path.Combine(AreaCommon.paths.workData.currentVolume.requests, data.requestHash & ".request")

                    If requestFileEngine.save() Then
                        log.track("A1x1Manager.init", "request - Saved")

                        ledgerCoordinate = writeDataIntoLedger()

                        If (ledgerCoordinate.coordinate.Length = 0) Then
                            currentService.currentAction.setError("-1", "Error during update ledger")
                            currentService.currentAction.reset()

                            log.track("A1x1Manager.init", "Error: Error during update ledger", "fatal")

                            Return False
                        End If

                        log.track("A1x1Manager.init", "Ledger updated")

                        If Not RecoveryState.fromRequest(data, ledgerCoordinate) Then
                            currentService.currentAction.setError("-1", "Error create state")
                            currentService.currentAction.reset()

                            log.track("A1x1Manager.init", "Error: Error during update State", "fatal")

                            Return False
                        End If

                        log.track("A1x1Manager.init", "State updated")

                        Return True
                    End If
                Catch ex As Exception
                    currentService.currentAction.setError(Err.Number, ex.Message)

                    log.track("A1x1Manager.init", ex.Message, "fatal")
                End Try

                Return False
            End Function

        End Class

    End Class

End Namespace
