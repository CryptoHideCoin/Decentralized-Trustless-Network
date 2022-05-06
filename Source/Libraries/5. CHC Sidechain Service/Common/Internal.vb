Option Compare Text
Option Explicit On

Imports CHCModelsLibrary.AreaModel.Log








Namespace AreaAsynchronous

    Module Internal

        ''' <summary>
        ''' This method provide to execute a log clean 
        ''' </summary>
        ''' <returns></returns>
        Friend Function executeLogClean() As Boolean
            Try
                AreaCommon.Main.environment.log.trackEnter("AreaAsynchronous.Internal.executeLogClean")

                Dim engine As New AreaEngine.CleanLogEngine

                Return engine.run
            Catch ex As Exception
                AreaCommon.Main.environment.log.trackException("AreaAsynchronous.Internal.executeLogClean", ex.Message)

                Return False
            Finally
                AreaCommon.Main.environment.log.trackExit("AreaAsynchronous.Internal.executeLogClean")
            End Try
        End Function

        ''' <summary>
        ''' This method provide to execute an a old a log instance
        ''' </summary>
        ''' <returns></returns>
        Friend Function executeCleanOldLogInstance() As Boolean
            Try
                AreaCommon.Main.environment.log.trackEnter("AreaAsynchronous.Internal.executeCleanOldLogInstance")

                Dim engine As New AreaEngine.CleanOldLogInstanceEngine

                Return engine.run
            Catch ex As Exception
                AreaCommon.Main.environment.log.trackException("AreaAsynchronous.Internal.executeCleanOldLogInstance", ex.Message)

                Return False
            Finally
                AreaCommon.Main.environment.log.trackExit("AreaAsynchronous.Internal.executeCleanOldLogInstance")
            End Try
        End Function

    End Module

End Namespace
