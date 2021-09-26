Option Explicit On
Option Compare Text




Namespace AreaWorker

    Module Processor

        Public Property workerOn As Boolean = False


        Public Function work() As Boolean
            Try
                Dim itemsToWork As Dictionary(Of String, AreaFlow.RequestExtended)
                Dim proceed As Boolean = True

                AreaCommon.log.track("Processor.work", "Begin")

                workerOn = True

                Do While (AreaCommon.flow.workerOn And workerOn)

                    itemsToWork = AreaCommon.flow.getAllListToProcess()

                    For Each item As AreaFlow.RequestExtended In itemsToWork.Values

                        If Not item.notifyAssessmentAtNetwork Then
                            If AreaCommon.consensus.notifyAssessment(item) Then
                                item.notifyAssessmentAtNetwork = True
                            End If
                        End If
                        If Not item.notifySingleConsensusAtNetwork Then
                            If AreaCommon.consensus.bulletin.proposalsForApprovalData.requestHash.CompareTo(item.requestHash) = 0 Then
                                If AreaCommon.consensus.notifyAllNetworkExpressAssessment(item) Then
                                    item.notifySingleConsensusAtNetwork = True
                                End If
                            End If
                        End If

                    Next

                    AreaCommon.flow.removeOldRequest()

                    Threading.Thread.Sleep(5)
                Loop

                workerOn = False

                AreaCommon.log.track("Processor.work", "Complete")

                Return True
            Catch ex As Exception
                AreaCommon.log.track("Processor.work", "Error:" & ex.Message, "error")

                Return False
            End Try
        End Function

    End Module

End Namespace