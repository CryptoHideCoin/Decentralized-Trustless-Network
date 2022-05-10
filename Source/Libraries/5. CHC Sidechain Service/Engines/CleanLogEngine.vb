Option Explicit On
Option Compare Text

Imports CHCModelsLibrary.AreaModel.Log








Namespace AreaEngine

    '''' <summary>
    '''' This class contain all element of engine clean of log
    '''' </summary>
    Public Class CleanLogEngine

        ''' <summary>
        ''' This method provide to delete all older log file
        ''' </summary>
        ''' <returns></returns>
        Public Function run() As Boolean
            Try
                AreaCommon.Main.environment.log.trackEnter("CleanLogEngine.run")

                Dim limitTime As Double = CDbl(1000) * 60 * 60 * 24
                Dim blockEngine As New CHCCommonLibrary.AreaEngine.Log.LogBlockEngine
                Dim testFile As Boolean
                Dim listFile As New List(Of LogListModel.SingleLogBlockModel)

                Select Case AreaCommon.Main.environment.settings.autoMaintenance.trackLogRotate.keepLast
                    Case KeepEnum.lastMonth : limitTime = CDbl(limitTime) * 30
                    Case KeepEnum.lastWeek : limitTime = CDbl(limitTime) * 7
                    Case KeepEnum.lastYear : limitTime = CDbl(limitTime) * 365
                End Select

                limitTime = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime() - limitTime

                blockEngine.logFilePath = AreaCommon.Main.environment.log.settings.pathFile
                blockEngine.logInstance = AreaCommon.Main.environment.log.settings.instanceID

                listFile = blockEngine.readListLogFile().items

                For Each singleFile In listFile
                    testFile = False

                    If (AreaCommon.Main.environment.settings.autoMaintenance.trackLogRotate.keepFile = LogRotateConfig.KeepFileEnum.onlyMainTracks) Then
                        testFile = (singleFile.name.Contains("main.log") <> 0)
                    Else
                        testFile = True
                    End If

                    If testFile Then
                        If (singleFile.startAt < limitTime) And (blockEngine.readListLogFile.items.Count > 1) Then
                            blockEngine.delete(singleFile.name)

                            AreaCommon.Main.environment.log.track("CleanLogEngine.run", $"Delete file = {singleFile.name}")
                        End If
                    End If
                Next

                AreaCommon.Main.environment.log.trackExit("CleanLogEngine.run")

                Return True
            Catch ex As Exception
                AreaCommon.Main.environment.log.trackException("CleanLogEngine.run", ex.Message)

                Return False
            End Try
        End Function

    End Class

End Namespace
