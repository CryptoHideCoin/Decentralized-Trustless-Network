Option Explicit On
Option Compare Text



Namespace AreaWorker

    Module Requester

        Private _LedgerSupportEngine As New TransactionChainLibrary.AreaLedger.LedgerSupportEngine

        Public Property workerOn As Boolean = False



        ''' <summary>
        ''' This method provide to check of a formal content of a request
        ''' </summary>
        ''' <param name="value"></param>
        ''' <returns></returns>
        Private Function formalCheck(ByRef value As AreaFlow.RequestExtended) As Nullable(Of Boolean)
            Try
                AreaCommon.log.track("Requester.formalCheck", "Begin")

                Select Case value.dataCommon.requestCode
                    Case "a0x0" : Return AreaProtocol.A0x0.FormalCheck.verify(value.dataCommon.hash)
                    Case "a0x1" : Return AreaProtocol.A0x1.FormalCheck.verify(value.dataCommon.hash)
                    Case "a0x2" : Return AreaProtocol.A0x2.FormalCheck.verify(value.dataCommon.hash)
                    Case "a0x3" : Return AreaProtocol.A0x3.FormalCheck.verify(value.dataCommon.hash)
                    Case "a0x4" : Return AreaProtocol.A0x4.FormalCheck.verify(value.dataCommon.hash)
                    Case "a0x5" : Return AreaProtocol.A0x5.FormalCheck.verify(value.dataCommon.hash)
                    Case "a0x6" : Return AreaProtocol.A0x6.FormalCheck.verify(value.dataCommon.hash)
                    Case "a0x7" : Return AreaProtocol.A0x7.FormalCheck.verify(value.dataCommon.hash)
                End Select

                AreaCommon.log.track("Requester.formalCheck", "Complete")

                Return False
            Catch ex As Exception
                AreaCommon.log.track("Requester.formalCheck", ex.Message, "fatal")

                Return Nothing
            End Try
        End Function

        ''' <summary>
        ''' This method provide to send a broadcast notice to the network
        ''' </summary>
        ''' <param name="value"></param>
        ''' <returns></returns>
        Private Function sendBroadCastNotice(ByRef value As AreaFlow.RequestExtended) As Boolean
            Try
                Dim listSender As AreaCommon.Masternode.MasternodeSenders

                AreaCommon.log.track("Requester.sendBroadCastNotice", "Begin")

                listSender = AreaCommon.Masternode.MasternodeSenders.createMasterNodeList()

                If value.source.directRequest And (listSender.count > 0) Then
                    Return AreaCommon.flow.addNewRequestToSend(value.dataCommon.requestCode, value.dataCommon.hash, AreaCommon.Masternode.MasternodeSenders.createMasterNodeList(), value, 0)
                End If

                AreaCommon.log.track("Requester.sendBroadCastNotice", "Complete")

                Return True
            Catch ex As Exception
                AreaCommon.log.track("Requester.sendBroadCastNotice", ex.Message, "fatal")

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to check the a request is not in the archive
        ''' </summary>
        ''' <param name="value"></param>
        ''' <returns></returns>
        Private Function notOldRequest(ByRef value As AreaFlow.RequestExtended) As Boolean
            Try
                AreaCommon.log.track("Requester.notOldRequest", "Begin")

                Return Not _LedgerSupportEngine.foundRequestInLedger(value.dataCommon.hash)
            Catch ex As Exception
                AreaCommon.log.track("Requester.notOldRequest", ex.Message, "fatal")

                Return False
            Finally
                AreaCommon.log.track("Requester.notOldRequest", "Complete")
            End Try
        End Function

        ''' <summary>
        ''' This method provide to initialize a ledger db
        ''' </summary>
        ''' <returns></returns>
        Private Function ledgerInit() As Boolean
            Try
                AreaCommon.log.track("Requester.ledgerInit", "Begin")

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

                AreaCommon.log.track("Requester.ledgerInit", "Complete")

                Return True
            Catch ex As Exception
                AreaCommon.log.track("Requester.ledgerInit", ex.Message, "fatal")

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to start a requester work
        ''' </summary>
        ''' <returns></returns>
        '<DebuggerHiddenAttribute()>
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

                    If (item.dataCommon.requestCode.Length > 0) Then
                        item.position.request = AreaFlow.EnumOperationPosition.inWork

                        If proceed Then proceed = notOldRequest(item)
                        If proceed Then
                            formalCorrect = formalCheck(item)

                            proceed = Not IsNothing(formalCorrect)
                        End If
                        If proceed Then proceed = sendBroadCastNotice(item)

                        If proceed Then
                            If (formalCorrect = True) Then
                                item.position.request = AreaFlow.EnumOperationPosition.completeWithPositiveResult
                            Else
                                item.position.request = AreaFlow.EnumOperationPosition.completeWithNegativeResult
                            End If

                            If (item.position.request = AreaFlow.EnumOperationPosition.completeWithPositiveResult) Then
                                AreaCommon.flow.setRequestToVerify(item)
                            Else
                                AreaCommon.flow.setRequestProcessed(item)
                            End If
                        Else
                            item.position.request = AreaFlow.EnumOperationPosition.inError
                        End If
                    End If

                    item = Nothing

                    AreaCommon.flow.removeOldRequest()
                    AreaCommon.flow.manageCloseBlock()

                    Threading.Thread.Sleep(1)
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