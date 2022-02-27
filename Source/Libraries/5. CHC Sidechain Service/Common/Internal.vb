Option Compare Text
Option Explicit On

Imports CHCModels.AreaModel.Log








Namespace AreaAsynchronous

    Module Internal

        Friend Property instanceID As String = ""
        Friend Property keepFile As KeepEnum


        ''' <summary>
        ''' This method provide to execute a log clean 
        ''' </summary>
        ''' <returns></returns>
        Friend Function executeLogClean() As Boolean
            Dim engine As New AreaEngine.CleanLogEngine

            engine.instanceLog = instanceID
            engine.pathLog = AreaCommon.Main.environment.log.settings.pathFileLog
            engine.keepFile = keepFile

            Return engine.run
        End Function

    End Module

End Namespace
