Option Compare Text
Option Explicit On

' ****************************************
' Engine: Performance Profile Engine
' Release Engine: 1.0 
' 
' Date last successfully test: 11/05/2022
' ****************************************

Imports CHCCommonLibrary.AreaEngine.DataFileManagement.XML
Imports CHCModelsLibrary.AreaModel.PerformanceProfile





Namespace AreaEngine.PerformanceProfile.Service

    ''' <summary>
    ''' This class contain all element to manage service of Performance Profile
    ''' </summary>
    Public Class PerformanceProfileService

        Private Property _CompleteProfileName As String = ""
        Private Property _OwnerId As String = "PerformanceProfile-" & Guid.NewGuid.ToString()

        Public Property engine As New Internal.MethodListInformationsEngine
        Public Property log As CHCCommonLibrary.AreaEngine.Log.TrackEngine



        ''' <summary>
        ''' This method provide to initialize the engine
        ''' </summary>
        ''' <param name="pathProfile"></param>
        ''' <returns></returns>
        Public Function init(ByVal pathProfile As String) As Boolean
            Try
                If Not IsNothing(log) Then
                    log.trackEnter("PerformanceProfileEngine.init", _OwnerId)
                End If

                If Not pathProfile.Contains("Data.PerformanceProfile") Then
                    If Not IO.Directory.Exists(pathProfile) Then
                        IO.Directory.CreateDirectory(pathProfile)
                    End If

                    _CompleteProfileName = IO.Path.Combine(pathProfile, "Data.PerformanceProfile")
                Else
                    _CompleteProfileName = pathProfile
                End If

                If IO.File.Exists(_CompleteProfileName) Then
                    Return engine.read(_CompleteProfileName)
                Else
                    Return True
                End If
            Catch ex As Exception
                If Not IsNothing(log) Then
                    log.trackException("PerformanceProfileEngine.init", _OwnerId, ex.Message)
                End If

                Return False
            Finally
                If Not IsNothing(log) Then
                    log.trackExit("PerformanceProfileEngine.init", _OwnerId)
                End If
            End Try
        End Function

        ''' <summary>
        ''' This method provide to process file log
        ''' </summary>
        ''' <param name="minItem"></param>
        ''' <returns></returns>
        Private Function processFileLog(ByRef currentItem As CHCModelsLibrary.AreaModel.Log.LogListModel.SingleLogBlockModel) As Boolean
            Try
                Dim blockLog As CHCCommonLibrary.AreaEngine.Log.LogBlockEngine
                Dim start As Boolean = False

                blockLog = New CHCCommonLibrary.AreaEngine.Log.LogBlockEngine

#If DEBUG Then
                blockLog.logFilePath = "E:\LegacyNetwork\System\Logs\SidechainService\956d98fe-1522-41fc-b1cf-21df1bfe3032"
#Else
                blockLog.logFilePath = log.settings.pathFileLog
#End If

                blockLog.logInstance = ""

                If blockLog.exist(currentItem.name) Then
                    For Each item In blockLog.read(currentItem.name)

                        If Not start Then
                            start = (item.instant > engine.data.lastPosition)
                        End If

                        If start Then
                            Select Case item.action
                                Case CHCModelsLibrary.AreaModel.Log.ActionEnumeration.enterIntoMethod
                                    engine.enterIntoMethod(item.owner, New CHCModelsLibrary.AreaModel.Log.LogListModel.SingleLogBlockModel With {.startAt = item.instant, .name = item.position})

                                Case CHCModelsLibrary.AreaModel.Log.ActionEnumeration.exitFromTheMethod
                                    If Not engine.exitFromMethod(item.owner, item.position, item.instant) Then
                                        log.trackException("MethodListInformations.processFileLog", _OwnerId, $"Method not enter: {item.position}")
                                    End If

                                Case CHCModelsLibrary.AreaModel.Log.ActionEnumeration.trackMarker
                                    engine.trackMarker(item.position, item.instant)
                            End Select

                            engine.data.lastPosition = item.instant
                        End If
                    Next
                End If

                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to compute the remain log file 
        ''' </summary>
        ''' <returns></returns>
        Public Function run() As Boolean
            Try
                Dim value As CHCModelsLibrary.AreaModel.Log.LogListModel
                Dim scanToFile As New List(Of CHCModelsLibrary.AreaModel.Log.LogListModel.SingleLogBlockModel)
                Dim fileToProcess As CHCModelsLibrary.AreaModel.Log.LogListModel.SingleLogBlockModel
                Dim previousFileToAdd As New CHCModelsLibrary.AreaModel.Log.LogListModel.SingleLogBlockModel

                If IsNothing(log) Then Return False

                log.trackEnter("PerformanceProfileEngine.run", _OwnerId)

                With New CHCCommonLibrary.AreaEngine.Log.LogBlockEngine()
#If DEBUG Then
                    .logFilePath = "E:\LegacyNetwork\System\Logs\SidechainService\956d98fe-1522-41fc-b1cf-21df1bfe3032"
#Else
                    .logFilePath = log.settings.pathFileLog
#End If
                    value = .readListLogFile()
                End With

                For Each item In value.items
                    If (item.startAt > engine.data.lastPosition) Then
                        scanToFile.Add(New CHCModelsLibrary.AreaModel.Log.LogListModel.SingleLogBlockModel With {.name = item.name, .startAt = item.startAt})
                    ElseIf (item.startAt > previousFileToAdd.startAt) Then
                        previousFileToAdd.startAt = item.startAt

                        previousFileToAdd.name = item.name
                    End If
                Next

                If (previousFileToAdd.startAt > 0) Then
                    scanToFile.Add(previousFileToAdd)
                End If

                Do While (scanToFile.Count > 0)
                    fileToProcess = New CHCModelsLibrary.AreaModel.Log.LogListModel.SingleLogBlockModel

                    For Each item In scanToFile
                        If (fileToProcess.startAt = 0) Or (fileToProcess.startAt > item.startAt) Then
                            fileToProcess = item
                        End If
                    Next

                    If Not processFileLog(fileToProcess) Then
                        log.trackException("PerformanceProfileEngine.run", _OwnerId, $"Problem during process file log {fileToProcess}")
                    End If

                    scanToFile.Remove(fileToProcess)
                Loop

                Return IOFast(Of MethodListInformations).save(_CompleteProfileName, engine.data)
            Catch ex As Exception
                log.trackException("PerformanceProfileEngine.run", _OwnerId, ex.Message)

                Return False
            Finally
                log.trackExit("PerformanceProfileEngine.run", _OwnerId)
            End Try
        End Function

    End Class

End Namespace
