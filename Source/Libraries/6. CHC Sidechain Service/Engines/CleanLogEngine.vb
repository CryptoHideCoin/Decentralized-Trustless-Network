Option Explicit On
Option Compare Text

Imports CHCModelsLibrary.AreaModel.Log








Namespace AreaEngine

    '''' <summary>
    '''' This class contain all element of engine clean of log
    '''' </summary>
    Public Class CleanLogEngine

        Public Property ownerId As String = ""

        ''' <summary>
        ''' This method provide to delete all older log file
        ''' </summary>
        ''' <returns></returns>
        Public Function run() As Boolean
            Try
                AreaCommon.Main.environment.log.trackEnter("CleanLogEngine.run", ownerID)

                If (AreaCommon.Main.serviceInformation.currentStatus <> CHCModelsLibrary.AreaModel.Information.InternalServiceInformation.EnumInternalServiceState.started) Then
                    Return False
                End If

                Dim limitTime As Double = CDbl(1000) * 60 * 60 * 24
                Dim blockEngine As New CHCCommonLibrary.AreaEngine.Log.LogBlockEngine
                Dim testFile As Boolean
                Dim listFile As New List(Of LogListModel.SingleLogBlockModel)

                Select Case AreaCommon.Main.environment.settings.autoMaintenance.trackLogRotate.keepLast
                    Case KeepEnum.lastWeek : limitTime = CDbl(limitTime) * 7
                    Case KeepEnum.lastMonth : limitTime = CDbl(limitTime) * 30
                    Case KeepEnum.lastYear : limitTime = CDbl(limitTime) * 365
                End Select

                limitTime = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime() - limitTime

                blockEngine.logFilePath = AreaCommon.Main.environment.log.settings.pathFile

#If DEBUG Then
                blockEngine.logInstance = "toElaborate"
#Else
                blockEngine.logInstance = AreaCommon.Main.environment.log.settings.instanceID
#End If

                listFile = blockEngine.readListLogFile().items

                For Each singleFile In listFile
                    If (AreaCommon.Main.serviceInformation.currentStatus <> CHCModelsLibrary.AreaModel.Information.InternalServiceInformation.EnumInternalServiceState.started) Then
                        Return False
                    End If

                    testFile = False

                    If (AreaCommon.Main.environment.settings.autoMaintenance.trackLogRotate.keepFile = LogRotateConfig.KeepFileEnum.onlyMainTracks) Then
                        testFile = (singleFile.name.Contains("main") = 0)
                    Else
                        testFile = True
                    End If

                    If testFile Then
                        If (singleFile.startAt < limitTime) And (blockEngine.readListLogFile.items.Count > 1) Then
                            blockEngine.delete(singleFile.name)

                            AreaCommon.Main.environment.log.track("CleanLogEngine.run", ownerID, $"Delete file = {singleFile.name}")
                        End If
                    End If
                Next

                Return True
            Catch ex As Exception
                AreaCommon.Main.environment.log.trackException("CleanLogEngine.run", ownerID, ex.Message)

                Return False

            Finally
                AreaCommon.Main.environment.log.trackExit("CleanLogEngine.run", ownerID)
            End Try
        End Function

    End Class

End Namespace
