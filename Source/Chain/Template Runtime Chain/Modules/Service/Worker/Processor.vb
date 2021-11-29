Option Explicit On
Option Compare Text





Namespace AreaWorker

    Module Processor

        Public Property workerOn As Boolean = False


        ''' <summary>
        ''' This method provide to execute a job of processor code action
        ''' </summary>
        ''' <returns></returns>
        '<DebuggerHiddenAttribute()>
        Public Function work() As Boolean
            Try
                Dim proceed As Boolean = True
                Dim item As New AreaFlow.RequestExtended

                AreaCommon.log.track("Processor.work", "Begin")

                workerOn = True

                Do While (AreaCommon.flow.workerOn And workerOn)
                    item = AreaCommon.flow.getFirstRequestToProcess()

                    If (item.dataCommon.hash.Length > 0) Then
                        AreaCommon.consensus.updateBulletin(item)
                    End If

                    AreaCommon.flow.removeOldRequest()
                    AreaCommon.flow.actionAfterAssessment()

                    Threading.Thread.Sleep(AreaCommon.support.timeSleep)
                Loop

                workerOn = False

                AreaCommon.log.track("Processor.work", "Complete")

                Return True
            Catch ex As Exception
                AreaCommon.log.track("Processor.work", ex.Message, "fatal")

                Return False
            End Try
        End Function

    End Module

End Namespace