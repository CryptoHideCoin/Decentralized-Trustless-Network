Option Explicit On
Option Compare Text




Namespace AreaWorker

    Module Verifier

        Public Property workerOn As Boolean = False

        Public Function work() As Boolean
            Try
                Dim item As AreaFlow.RequestExtended
                Dim proceed As Boolean = True

                AreaCommon.log.track("Verifier.work", "Begin")

                workerOn = True

                Do While AreaCommon.flow.workerOn
                    item = AreaCommon.flow.getFirstRequestToProcess()

                    If (item.requestHash.Length > 0) Then
                        proceed = True

                        If proceed Then proceed = AreaCommon.consensus.manageRequest(item)
                        If proceed Then
                            item.generalStatus = AreaFlow.RequestExtended.EnumOperationPosition.completeWithPositiveResult
                            item.requestPosition = AreaFlow.RequestExtended.EnumOperationFase.toRemove
                        End If

                        AreaCommon.flow.removeRequest(item)
                    End If

                    Threading.Thread.Sleep(10)
                Loop

                workerOn = False

                AreaCommon.log.track("Verifier.work", "Complete")

                Return True
            Catch ex As Exception
                AreaCommon.log.track("Verifier.work", "Error:" & ex.Message, "error")

                Return False
            End Try
        End Function


    End Module

End Namespace