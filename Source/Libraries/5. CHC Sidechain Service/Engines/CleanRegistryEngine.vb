Option Explicit On
Option Compare Text

Imports CHCModelsLibrary.AreaModel.Log








Namespace AreaEngine

    '''' <summary>
    '''' This class contain all element of engine clean of registry events
    '''' </summary>
    Public Class CleanRegistryEngine

        ''' <summary>
        ''' This method provide to delete all older registry events file
        ''' </summary>
        ''' <returns></returns>
        Public Function run() As Boolean
            Try
                AreaCommon.Main.environment.log.trackEnter("CleanRegistryEngine.run")

                If (AreaCommon.Main.serviceInformation.currentStatus <> CHCModelsLibrary.AreaModel.Information.InternalServiceInformation.EnumInternalServiceState.started) Then
                    Return False
                End If

                Dim limitTime As Double = CDbl(1000) * 60 * 60 * 24
                Dim fileData As IO.FileInfo
                Dim listFile As New List(Of String)

                Select Case AreaCommon.Main.environment.settings.autoMaintenance.registryRotate.keepLast
                    Case KeepEnum.lastMonth : limitTime = CDbl(limitTime) * 30
                    Case KeepEnum.lastWeek : limitTime = CDbl(limitTime) * 7
                    Case KeepEnum.lastYear : limitTime = CDbl(limitTime) * 365
                End Select

                limitTime = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime() - limitTime

                For Each singleFile In IO.Directory.GetFiles(AreaCommon.Main.environment.registry.path)
                    If (AreaCommon.Main.serviceInformation.currentStatus <> CHCModelsLibrary.AreaModel.Information.InternalServiceInformation.EnumInternalServiceState.started) Then
                        Return False
                    End If

                    fileData = New IO.FileInfo(singleFile)

                    If (CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime(fileData.LastWriteTimeUtc) < limitTime) Then
                        listFile.Add(singleFile)
                    End If
                Next

                For Each singleFile In listFile
                    If (AreaCommon.Main.serviceInformation.currentStatus <> CHCModelsLibrary.AreaModel.Information.InternalServiceInformation.EnumInternalServiceState.started) Then
                        Return False
                    End If

                    AreaCommon.Main.environment.log.track("CleanRegistryEngine.run", $"Delete file = {singleFile}")
                    IO.File.Delete(singleFile)
                Next

                AreaCommon.Main.environment.log.trackExit("CleanRegistryEngine.run")

                Return True
            Catch ex As Exception
                AreaCommon.Main.environment.log.trackException("CleanRegistryEngine.run", ex.Message)

                Return False
            End Try
        End Function

    End Class

End Namespace
