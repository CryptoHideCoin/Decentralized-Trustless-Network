Option Explicit On
Option Compare Text




Namespace AreaWorker

    Module Verifier

        Public Property workerOn As Boolean = False


        ''' <summary>
        ''' This method provide to evaluate the request
        ''' </summary>
        ''' <param name="value"></param>
        ''' <returns></returns>
        Private Function evaluateTheRequest(ByRef value As AreaFlow.RequestExtended) As Boolean
            Try
                AreaCommon.log.track("Verifier.evaluateTheRequest", "Begin")

                Select Case value.dataCommon.type
                    Case "a0x0" : Return AreaProtocol.A0x0.FormalCheck.evaluate(value)
                    Case "a0x1" : Return AreaProtocol.A0x1.FormalCheck.evaluate(value)
                    Case "a0x2" : Return AreaProtocol.A0x2.FormalCheck.evaluate(value)
                    Case "a0x3" : Return AreaProtocol.A0x3.FormalCheck.evaluate(value)
                    Case "a0x4" : Return AreaProtocol.A0x4.FormalCheck.evaluate(value)
                    Case "a0x5" : Return AreaProtocol.A0x5.FormalCheck.evaluate(value)
                    Case "a0x6" : Return AreaProtocol.A0x6.FormalCheck.evaluate(value)
                    Case "a0x7" : Return AreaProtocol.A0x7.FormalCheck.evaluate(value)

                    Case "a1x0" : Return AreaProtocol.A1x0.FormalCheck.evaluate(value)
                    Case "a1x1" : Return AreaProtocol.A1x1.FormalCheck.evaluate(value)
                    Case "a1x2" : Return AreaProtocol.A1x2.FormalCheck.evaluate(value)
                    Case "a1x3" : Return AreaProtocol.A1x3.FormalCheck.evaluate(value)
                    Case "a1x4" : Return AreaProtocol.A1x4.FormalCheck.evaluate(value)
                    Case "a1x5" : Return AreaProtocol.A1x5.FormalCheck.evaluate(value)
                    Case "a1x6" : Return AreaProtocol.A1x6.FormalCheck.evaluate(value)
                    Case "a1x7" : Return AreaProtocol.A1x7.FormalCheck.evaluate(value)
                    Case "a1x8" : Return AreaProtocol.A1x8.FormalCheck.evaluate(value)
                    Case "a1x9" : Return AreaProtocol.A1x9.FormalCheck.evaluate(value)

                    Case "a2x0" : Return AreaProtocol.A2x0.FormalCheck.evaluate(value)

                        ''' BOOKMARK: Add in this point 6
                End Select

                AreaCommon.log.track("Verifier.evaluateTheRequest", "Completed")

                Return False
            Catch ex As Exception
                AreaCommon.log.track("Verifier.evaluateTheRequest", ex.Message, "fatal")

                Return Nothing
            End Try
        End Function

        ''' <summary>
        ''' This method provide to work verifier job
        ''' </summary>
        ''' <returns></returns>
        '<DebuggerHiddenAttribute()>
        Public Function work() As Boolean
            Try
                Dim item As AreaFlow.RequestExtended

                AreaCommon.log.track("Verifier.work", "Begin")

                workerOn = True

                Do While (AreaCommon.flow.workerOn And workerOn)
                    item = AreaCommon.flow.getFirstRequestToVerify()

                    If (item.dataCommon.hash.Length > 0) Then
                        item.position.verify = AreaFlow.EnumOperationPosition.inWork

                        If evaluateTheRequest(item) Then
                            item.evaluations.notExpressed = AreaCommon.flow.createEvaluationList()
                            item.evaluations.currentChainNodeTotalPower = item.evaluations.notExpressed.totalPower

                            If (item.position.verify = AreaFlow.EnumOperationPosition.inError) Then
                                item.evaluations.setAbstained(AreaCommon.state.network.publicAddressIdentity)
                            ElseIf (item.position.verify = AreaFlow.EnumOperationPosition.completeWithPositiveResult) Then
                                item.evaluations.setApproved(AreaCommon.state.network.publicAddressIdentity)
                            Else
                                item.evaluations.setRejected(AreaCommon.state.network.publicAddressIdentity)
                            End If

                            AreaCommon.flow.setRequestToProcess(item)
                        End If
                    End If

                    Threading.Thread.Sleep(AreaCommon.support.timeSleep)
                Loop

                workerOn = False

                AreaCommon.log.track("Verifier.work", "Completed")

                Return True
            Catch ex As Exception
                AreaCommon.log.track("Verifier.work", ex.Message, "fatal")

                Return False
            End Try
        End Function

    End Module

End Namespace