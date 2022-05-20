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
            Try
                currentNumJobInRun += 1

                AreaCommon.Main.environment.log.trackEnter("AreaAsynchronous.Internal.executeLogClean")

                Dim engine As New AreaEngine.CleanLogEngine

                Return engine.run
            Catch ex As Exception
                AreaCommon.Main.environment.log.trackException("AreaAsynchronous.Internal.executeLogClean", ex.Message)

                Return False
            Finally
                AreaCommon.Main.environment.log.trackExit("AreaAsynchronous.Internal.executeLogClean")

                currentNumJobInRun -= 1
            End Try
        End Function

        ''' <summary>
        ''' This method provide to execute a registry clean
        ''' </summary>
        ''' <returns></returns>
        Friend Function executeRegistryClean() As Boolean
            Try
                currentNumJobInRun += 1

                AreaCommon.Main.environment.log.trackEnter("AreaAsynchronous.Internal.executeRegistryClean")

                Dim engine As New AreaEngine.CleanRegistryEngine

                Return engine.run
            Catch ex As Exception
                AreaCommon.Main.environment.log.trackException("AreaAsynchronous.Internal.executeRegistryClean", ex.Message)

                Return False
            Finally
                AreaCommon.Main.environment.log.trackExit("AreaAsynchronous.Internal.executeRegistryClean")

                currentNumJobInRun -= 1
            End Try
        End Function

        ''' <summary>
        ''' This method provide to execute a performance profile
        ''' </summary>
        ''' <returns></returns>
        Friend Function executePerformanceProfile() As Boolean
            Try
                currentNumJobInRun += 1

                AreaCommon.Main.environment.log.trackEnter("AreaAsynchronous.Internal.executePerformanceProfile")

                Return AreaCommon.Main.environment.performanceProfile.run()
            Catch ex As Exception
                AreaCommon.Main.environment.log.trackException("AreaAsynchronous.Internal.executePerformanceProfile", ex.Message)

                Return False
            Finally
                AreaCommon.Main.environment.log.trackExit("AreaAsynchronous.Internal.executePerformanceProfile")

                currentNumJobInRun -= 1
            End Try
        End Function

        ''' <summary>
        ''' This method provide to execute an a old a log instance
        ''' </summary>
        ''' <returns></returns>
        Friend Function executeCleanOldLogInstance() As Boolean
            Try
                currentNumJobInRun += 1

                AreaCommon.Main.environment.log.trackEnter("AreaAsynchronous.Internal.executeCleanOldLogInstance")

                Dim engine As New AreaEngine.CleanOldLogInstanceEngine

                Return engine.run
            Catch ex As Exception
                AreaCommon.Main.environment.log.trackException("AreaAsynchronous.Internal.executeCleanOldLogInstance", ex.Message)

                Return False
            Finally
                AreaCommon.Main.environment.log.trackExit("AreaAsynchronous.Internal.executeCleanOldLogInstance")

                currentNumJobInRun -= 1
            End Try
        End Function

        ''' <summary>
        ''' This method provide to execute a shutdown of this service
        ''' </summary>
        ''' <returns></returns>
        Friend Function executeShutDown() As Boolean
            Try
                AreaCommon.Main.environment.log.trackEnter("AreaAsynchronous.Internal.executeShutDown")

                Do While (currentNumJobInRun > 0)
                    Threading.Thread.Sleep(100)
                Loop

                AreaCommon.Main.environment.log.trackIntoConsole("Service in switch off state")
                AreaCommon.Main.environment.log.track("AreaAsynchronous.Internal.executeShutDown", "Switch off state")

                Return True
            Catch ex As Exception
                AreaCommon.Main.environment.log.trackException("AreaAsynchronous.Internal.executeShutDown", ex.Message)

                Return False
            Finally
                AreaCommon.Main.environment.log.writeCacheToLogFile()
            End Try
        End Function

    End Module

End Namespace
