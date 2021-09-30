Option Explicit On
Option Compare Text



Namespace AreaWorker

    Module Requester

        Private _LedgerSupportEngine As New TransactionChainLibrary.AreaLedger.LedgerSupportEngine

        Public Property workerOn As Boolean = False



        Private Function formalCheck(ByRef value As AreaFlow.RequestExtended) As Nullable(Of Boolean)
            Try
                Select Case value.requestCode
                    Case "a0x0" : Return AreaProtocol.A0x0.FormalCheck.verify(value.requestHash)
                End Select

                Return False
            Catch ex As Exception
                AreaCommon.log.track("Requester.formalCheck", ex.Message, "fatal")

                Return Nothing
            End Try
        End Function

        Private Function sendBroadCastNotice(ByRef value As AreaFlow.RequestExtended) As Boolean
            Try
                Dim listSender As AreaCommon.Masternode.MasternodeSenders

                listSender = AreaCommon.Masternode.MasternodeSenders.createMasterNodeList()

                If value.directRequest And (listSender.count > 0) Then
                    AreaCommon.flow.addNewRequestToSend(value.requestCode, value.requestHash, AreaCommon.Masternode.MasternodeSenders.createMasterNodeList(), value, 0)
                End If

                Return True
            Catch ex As Exception
                AreaCommon.log.track("Requester.sendBroadCastNotice", ex.Message, "fatal")

                Return False
            End Try
        End Function

        Private Function notOldRequest(ByRef value As AreaFlow.RequestExtended) As Boolean
            Try
                Return Not _LedgerSupportEngine.foundRequestInLedger(value.requestHash)
            Catch ex As Exception
                AreaCommon.log.track("Requester.notOldRequest", ex.Message, "fatal")

                Return False
            End Try
        End Function

        Private Function ledgerInit() As Boolean
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

            Return True
        End Function


        Public Function work() As Boolean
            Try
                Dim item As AreaFlow.RequestExtended
                Dim proceed As Boolean = True
                Dim formalCorrect As Nullable(Of Boolean)

                AreaCommon.log.track("Requester.work", "Begin")

                workerOn = True

                ledgerInit()

                Do While (AreaCommon.flow.workerOn And workerOn)
                    item = AreaCommon.flow.getFirstRequestToSelect()

                    proceed = True
                    formalCorrect = Nothing

                    If (item.requestCode.Length > 0) Then
                        item.requestPosition = AreaFlow.RequestExtended.EnumOperationPosition.inWork
                        item.generalStatus = AreaFlow.RequestExtended.EnumOperationPosition.inWork

                        If proceed Then proceed = notOldRequest(item)
                        If proceed Then
                            formalCorrect = formalCheck(item)

                            proceed = Not IsNothing(formalCorrect)
                        End If
                        If proceed Then proceed = sendBroadCastNotice(item)

                        If proceed Then
                            If (formalCorrect = True) Then
                                item.requestPosition = AreaFlow.RequestExtended.EnumOperationPosition.completeWithPositiveResult
                            Else
                                item.requestPosition = AreaFlow.RequestExtended.EnumOperationPosition.completeWithNegativeResult
                            End If

                            item.dateSelected = CHCCommonLibrary.AreaEngine.Miscellaneous.timestampFromDateTime()

                            If item.requestPosition = AreaFlow.RequestExtended.EnumOperationPosition.completeWithPositiveResult Then
                                AreaCommon.flow.setRequestToVerify(item)
                            Else
                                AreaCommon.flow.setRequestProcessed(item)
                            End If
                        Else
                            item.requestPosition = AreaFlow.RequestExtended.EnumOperationPosition.inError
                        End If
                    End If

                    item = Nothing

                    AreaCommon.flow.removeOldRequest()
                    AreaCommon.flow.manageCloseBlock()

                    Threading.Thread.Sleep(5)
                Loop

                workerOn = False

                AreaCommon.log.track("Requester.work", "Complete")

                Return True
            Catch ex As Exception
                AreaCommon.log.track("Requester.work", ex.Message, "fatal")

                Return False
            End Try
        End Function

    End Module

End Namespace