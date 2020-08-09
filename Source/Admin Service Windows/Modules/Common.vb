Option Compare Text
Option Explicit On



Namespace AreaCommon


    Module moduleMain


        Public paths As New AreaSystem.Paths
        Public log As New CHCServerSupport.Support.LogEngine
        Public logRotate As New CHCServerSupport.Support.LogRotateEngine
        Public counter As New CHCServerSupport.Support.CounterEngine
        Public registry As New CHCServerSupport.Support.RegistryEngine
        Public settings As New AppSettings
        Public state As New AppState







        Public Function refreshBatch(ByRef adapterLog As CHCServerSupport.Support.LogEngine) As Boolean

            Try

                adapterLog.track("moduleMain.refreshBatch", "Begin")

                Return logRotate.run(adapterLog)

            Catch ex As Exception

                adapterLog.track("moduleMain.refreshBatch", "Error:" & ex.Message, "Fatal")

                Return False

            Finally

                adapterLog.track("moduleMain.refreshBatch", "Complete")

            End Try

        End Function


    End Module


End Namespace