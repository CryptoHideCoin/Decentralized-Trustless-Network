Option Compare Text
Option Explicit On

Imports CHCProtocolLibrary.AreaSystem
Imports CHCServerSupportLibrary.Support



Namespace AreaCommon


    Module moduleMain


        Public paths As New VirtualPathEngine
        Public log As New LogEngine
        Public logRotate As New LogRotateEngine
        Public counter As New CounterEngine
        Public registry As New RegistryEngine
        Public settings As New AppSettings
        Public state As New AppState








        ''' <summary>
        ''' This application provides to close application
        ''' </summary>
        Public Sub closeApplication(Optional ByVal NotWait As Boolean = False)

            Console.WriteLine("")
            Console.WriteLine("")

            If Not NotWait Then

                Console.Write("Press key to continue")
                Console.ReadKey()
                Console.WriteLine("")
                Console.WriteLine("")

            End If

            End

        End Sub



        Public Function refreshBatch(ByRef adapterLog As LogEngine) As Boolean

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