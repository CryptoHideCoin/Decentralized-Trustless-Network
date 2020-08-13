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






        ''' <summary>
        ''' This application provides to close application
        ''' </summary>
        Public Sub closeApplication(Optional ByVal notWait As Boolean = False)

            Console.WriteLine("")
            Console.WriteLine("")

            If Not notWait Then

                Console.Write("Press key to continue")
                Console.ReadKey()
                Console.WriteLine("")
                Console.WriteLine("")

            End If

            End

        End Sub


        ''' <summary>
        ''' This method provide to run an external application with parameters
        ''' </summary>
        ''' <param name="applicationName"></param>
        ''' <param name="parameterValue"></param>
        Public Sub executeExternalApplication(ByVal applicationName As String, Optional ByVal parameterValue As String = "")

            Try

                Shell(applicationName & " " & parameterValue, AppWinStyle.NormalFocus)

            Catch ex As Exception

                log.track("moduleMain.ExecuteExternalApplication", "Enable start a webservice; check admin authorizathion - Error:" & ex.Message, "fatal")

            End Try

        End Sub


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