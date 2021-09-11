Option Explicit On
Option Compare Text



Namespace AreaWorker

    Module Requester

        Private _LedgerSupportEngine As New TransactionChainLibrary.AreaLedger.LedgerSupportEngine

        Public Property workerOn As Boolean = False



        Private Function formalCheck(ByRef value As AreaFlow.RequestExtended) As Boolean
            Try
                value.requestPosition = AreaFlow.RequestExtended.EnumOperationFase.inFormalCheck

                Select Case value.requestCode
                    Case "a0x0" : Return AreaProtocol.A0x0.FormalCheck.verify(value.requestHash)
                End Select

                Return False
            Catch ex As Exception
                AreaCommon.log.track("Requester.formalCheck", "Error:" & ex.Message, "error")

                Return False
            End Try
        End Function

        Private Function sendBroadCastNotice(ByRef value As AreaFlow.RequestExtended) As Boolean
            Try
                Dim listSender As AreaCommon.Masternode.MasternodeSenders

                listSender = AreaCommon.Masternode.MasternodeSenders.createMasterNodeList()

                value.requestPosition = AreaFlow.RequestExtended.EnumOperationFase.duringSendingToTheNetwork

                If value.directRequest Then
                    AreaCommon.flow.addNewRequestToSend(value.requestCode, value.requestHash, AreaCommon.Masternode.MasternodeSenders.createMasterNodeList(), value)
                End If

                value.requestPosition = AreaFlow.RequestExtended.EnumOperationFase.requestProcessComplete

                Return True
            Catch ex As Exception
                AreaCommon.log.track("Requester.sendBroadCastNotice", "Error:" & ex.Message, "error")

                Return False
            End Try
        End Function

        Private Function notOldRequest(ByRef value As AreaFlow.RequestExtended) As Boolean
            Try
                value.requestPosition = AreaFlow.RequestExtended.EnumOperationFase.notOldRequestCheck

                Return Not _LedgerSupportEngine.foundRequestInLedger(value.requestHash)
            Catch ex As Exception
                AreaCommon.log.track("Requester.notOldRequest", "Error:" & ex.Message, "error")

                Return False
            End Try
        End Function


        Public Function work() As Boolean
            Try
                Dim item As AreaFlow.RequestExtended
                Dim proceed As Boolean = True

                AreaCommon.log.track("Requester.work", "Begin")

                workerOn = True

                _LedgerSupportEngine.log = AreaCommon.log

                _LedgerSupportEngine.identifyBlockChain = "B0"
                _LedgerSupportEngine.currentIdBlock = AreaCommon.state.currentBlockLedger.CurrentIdBlock
                _LedgerSupportEngine.currentIdVolume = AreaCommon.state.currentBlockLedger.CurrentIdVolume

                If (_LedgerSupportEngine.currentIdBlock = 0) Then
                    If (_LedgerSupportEngine.currentIdVolume = 0) Then
                        _LedgerSupportEngine.NoUsePrevious = True
                    Else
                        _LedgerSupportEngine.previousIdVolume = _LedgerSupportEngine.currentIdVolume - 1
                    End If
                Else
                    _LedgerSupportEngine.previousIdBlock = _LedgerSupportEngine.currentIdBlock
                End If

                _LedgerSupportEngine.init(AreaCommon.paths.workData.currentVolume.ledger, AreaCommon.paths.workData.previousVolume.ledger)

                Do While AreaCommon.flow.workerOn
                    item = AreaCommon.flow.getFirstRequestToSelect()

                    proceed = True

                    If (item.requestCode.Length > 0) Then
                        item.requesterProcedure = AreaFlow.RequestExtended.EnumOperationPosition.inWork
                        item.generalStatus = AreaFlow.RequestExtended.EnumOperationPosition.inWork

                        If proceed Then proceed = notOldRequest(item)
                        If proceed Then
                            If Not item.directRequest Then
                                proceed = AreaCommon.flow.addNewRequestToDownload(item.requestHash, item.externalSource)
                            End If
                        End If
                        If proceed Then proceed = formalCheck(item)
                        If proceed Then proceed = sendBroadCastNotice(item)

                        If proceed Then
                            item.requestPosition = AreaFlow.RequestExtended.EnumOperationPosition.completeWithPositiveResult
                        Else
                            item.requestPosition = AreaFlow.RequestExtended.EnumOperationPosition.completeWithNegativeResult
                        End If

                        item.dateSelected = CHCCommonLibrary.AreaEngine.Miscellaneous.timestampFromDateTime()

                        AreaCommon.flow.setRequestToProcess(item)
                    End If

                    item = Nothing

                    Threading.Thread.Sleep(10)
                Loop

                workerOn = False

                AreaCommon.log.track("Requester.work", "Complete")

                Return True
            Catch ex As Exception
                AreaCommon.log.track("Requester.work", "Error:" & ex.Message, "error")

                Return False
            End Try
        End Function

    End Module

End Namespace