Option Compare Text
Option Explicit On







Namespace AreaAsynchronous

    Module Internal

        Public Property currentNumJobInRun As Integer = 0


        ''' <summary>
        ''' This method provide to execute a log clean 
        ''' </summary>
        ''' <returns></returns>
        Friend Function executeLogClean() As Boolean
            Dim ownerId As String = "LogClean-" & Guid.NewGuid.ToString

            Try
                currentNumJobInRun += 1

                AreaCommon.Main.environment.log.trackEnter("AreaAsynchronous.Internal.executeLogClean", ownerId)

                Dim engine As New AreaEngine.CleanLogEngine

                engine.ownerId = ownerId

                Return engine.run
            Catch ex As Exception
                AreaCommon.Main.environment.log.trackException("AreaAsynchronous.Internal.executeLogClean", ownerId, ex.Message)

                Return False
            Finally
                AreaCommon.Main.environment.log.trackExit("AreaAsynchronous.Internal.executeLogClean", ownerId)

                currentNumJobInRun -= 1
            End Try
        End Function

        ''' <summary>
        ''' This method provide to execute a registry clean
        ''' </summary>
        ''' <returns></returns>
        Friend Function executeRegistryClean() As Boolean
            Dim ownerId As String = "RegistryClean-" & Guid.NewGuid.ToString

            Try
                currentNumJobInRun += 1

                AreaCommon.Main.environment.log.trackEnter("AreaAsynchronous.Internal.executeRegistryClean", ownerId)

                Dim engine As New AreaEngine.CleanRegistryEngine

                engine.ownerId = ownerId

                Return engine.run
            Catch ex As Exception
                AreaCommon.Main.environment.log.trackException("AreaAsynchronous.Internal.executeRegistryClean", ownerId, ex.Message)

                Return False
            Finally
                AreaCommon.Main.environment.log.trackExit("AreaAsynchronous.Internal.executeRegistryClean", ownerId)

                currentNumJobInRun -= 1
            End Try
        End Function

        ''' <summary>
        ''' This method provide to execute a performance profile
        ''' </summary>
        ''' <returns></returns>
        Friend Function executePerformanceProfile() As Boolean
            Dim ownerId As String = "PerformanceProfile-" & Guid.NewGuid.ToString

            Try
                currentNumJobInRun += 1

                AreaCommon.Main.environment.log.trackEnter("AreaAsynchronous.Internal.executePerformanceProfile", ownerId)

                Return AreaCommon.Main.environment.performanceProfile.run()
            Catch ex As Exception
                AreaCommon.Main.environment.log.trackException("AreaAsynchronous.Internal.executePerformanceProfile", ownerId, ex.Message)

                Return False
            Finally
                AreaCommon.Main.environment.log.trackExit("AreaAsynchronous.Internal.executePerformanceProfile", ownerId)

                currentNumJobInRun -= 1
            End Try
        End Function

        ''' <summary>
        ''' This method provide to execute an a old a log instance
        ''' </summary>
        ''' <returns></returns>
        Friend Function executeCleanOldLogInstance() As Boolean
            Dim ownerId As String = "CleanOldLogInstance-" & Guid.NewGuid.ToString

            Try
                currentNumJobInRun += 1

                AreaCommon.Main.environment.log.trackEnter("AreaAsynchronous.Internal.executeCleanOldLogInstance", ownerId)

                Dim engine As New AreaEngine.CleanOldLogInstanceEngine

                engine.ownerId = ownerId

                Return engine.run
            Catch ex As Exception
                AreaCommon.Main.environment.log.trackException("AreaAsynchronous.Internal.executeCleanOldLogInstance", ownerId, ex.Message)

                Return False
            Finally
                AreaCommon.Main.environment.log.trackExit("AreaAsynchronous.Internal.executeCleanOldLogInstance", ownerId)

                currentNumJobInRun -= 1
            End Try
        End Function

        ''' <summary>
        ''' This method provide to execute a shutdown of this service
        ''' </summary>
        ''' <returns></returns>
        Friend Function executeShutDown() As Boolean
            Dim ownerId As String = "ShutDown-" & Guid.NewGuid.ToString

            Try
                AreaCommon.Main.environment.log.trackEnter("AreaAsynchronous.Internal.executeShutDown", ownerId)

                Do While (currentNumJobInRun > 0)
                    Threading.Thread.Sleep(100)
                Loop

                AreaCommon.Main.environment.log.trackIntoConsole("Service in switch off state")
                AreaCommon.Main.environment.log.track("AreaAsynchronous.Internal.executeShutDown", ownerId, "Switch off state")

                Return True
            Catch ex As Exception
                AreaCommon.Main.environment.log.trackException("AreaAsynchronous.Internal.executeShutDown", ownerId, ex.Message)

                Return False
            Finally
                AreaCommon.Main.environment.log.writeCacheToLogFile()
            End Try
        End Function

    End Module

End Namespace
