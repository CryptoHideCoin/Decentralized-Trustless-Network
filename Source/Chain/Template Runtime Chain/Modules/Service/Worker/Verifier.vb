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

                Select Case value.dataCommon.requestCode
                    Case "a0x0" : Return AreaProtocol.A0x0.FormalCheck.evaluate(value)
                End Select

                AreaCommon.log.track("Verifier.evaluateTheRequest", "Complete")

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
                            item.evaluations.currentChainNodeTotalVotes = item.evaluations.notExpressed.totalValuePoints
                            item.evaluations.haveNewerForConsensus = True

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

                    Threading.Thread.Sleep(1)
                Loop

                workerOn = False

                AreaCommon.log.track("Verifier.work", "Complete")

                Return True
            Catch ex As Exception
                AreaCommon.log.track("Verifier.work", ex.Message, "fatal")

                Return False
            End Try
        End Function


    End Module

End Namespace