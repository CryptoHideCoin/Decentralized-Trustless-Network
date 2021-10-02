Option Explicit On
Option Compare Text




Namespace AreaWorker

    Module RemoteVerifier

        Public Property workerOn As Boolean = False


        ''' <summary>
        ''' This method provide to execute a job of listen and process of a remote bulletin
        ''' </summary>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()>
        Public Function work() As Boolean
            Try
                Dim item As AreaConsensus.RequestProcess
                Dim proceed As Boolean = True

                AreaCommon.log.track("RemoteVerifier.work", "Begin")

                workerOn = True

                Do While (AreaCommon.flow.workerOn And workerOn)
                    item = AreaCommon.flow.getFirstRemoteBulletin()

                    If (item.hash.Length > 0) Then
                        AreaCommon.consensus.processRemoteNotify(item)
                    End If

                    Threading.Thread.Sleep(1)
                Loop

                workerOn = False

                AreaCommon.log.track("RemoteVerifier.work", "Complete")

                Return True
            Catch ex As Exception
                AreaCommon.log.track("RemoteVerifier.work", ex.Message, "fatal")

                Return False
            End Try
        End Function

    End Module

End Namespace