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





Namespace AreaEngine.PerformanceProfile

    ''' <summary>
    ''' This method provide to manage a method information structure
    ''' </summary>
    Public Class MethodInformationEngine

        Inherits MethodInformation

        ''' <summary>
        ''' This method provide to add a new child method
        ''' </summary>
        ''' <param name="name"></param>
        ''' <returns></returns>
        Public Function addUse(ByVal name As String) As Boolean
            For Each singleCall In uses
                If (singleCall.CompareTo(name) = 0) Then
                    Return True
                End If
            Next

            Return True
        End Function

        ''' <summary>
        ''' This method provide to add a new parent method
        ''' </summary>
        ''' <param name="name"></param>
        ''' <returns></returns>
        Public Function addUsedIn(ByVal name As String) As Boolean
            For Each singleCall In usedFrom
                If (singleCall.CompareTo(name) = 0) Then
                    Return True
                End If
            Next

            Return True
        End Function

    End Class

    Public Class MethodListInformationsEngine

        Inherits MethodListInformations

        ''' <summary>
        ''' This method provide to retrieve the last method chain in the stack
        ''' </summary>
        ''' <returns></returns>
        Private Function getParentFromStack() As MethodInformationEngine
            Try
                If (stacks.Count = 0) Then
                    Return New MethodInformationEngine
                Else
                    If index.ContainsKey(stacks.Last) Then
                        Return index(stacks.Last)
                    Else
                        Return New MethodInformationEngine
                    End If
                End If
            Catch ex As Exception
                Return New MethodInformationEngine
            End Try
        End Function


        ''' <summary>
        ''' This method provide to manage enter to method procedure
        ''' </summary>
        ''' <param name="startAt"></param>
        ''' <param name="name"></param>
        ''' <returns></returns>
        Public Function enterIntoMethod(ByVal startAt As Double, ByVal name As String) As Boolean
            Try
                Dim methodData As MethodInformationEngine
                Dim parent As MethodInformationEngine = getParentFromStack()

                If index.ContainsKey(name) Then
                    methodData = index(name)
                Else
                    methodData = New MethodInformationEngine

                    methodData.name = name
                    methodData.maxDuring = startAt
                    methodData.minDuring = startAt
                    methodData.refDuring = startAt

                    methods.Add(methodData)

                    index.Add(name, methodData)
                End If

                methodData.lastStart = startAt

                If (parent.name.Length > 0) Then
                    methodData.addUsedIn(parent.name)

                    parent.addUse(name)
                End If

                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to manage exit to method procedure
        ''' </summary>
        ''' <param name="startAt"></param>
        ''' <param name="name"></param>
        ''' <returns></returns>
        Public Function exitFromMethod(ByVal startAt As Double, ByVal name As String) As Boolean
            Try
                Dim methodData As MethodInformation
                Dim durate As Double

                If index.ContainsKey(name) Then
                    methodData = index(name)

                    durate = startAt - methodData.lastStart

                    If (durate > methodData.maxDuring) Then
                        methodData.maxDuring = durate
                    End If
                    If (durate < methodData.minDuring) Then
                        methodData.minDuring = durate
                    End If

                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to track a new marker
        ''' </summary>
        ''' <param name="name"></param>
        ''' <returns></returns>
        Public Function trackMarker(ByVal name As String, ByVal startAt As Double) As Boolean
            Try
                Dim data As MarkersInformations

                If (markers.Count > 0) Then
                    data = markers.Last

                    data.durate = startAt - data.startAt
                End If

                data = New MarkersInformations

                data.name = name
                data.startAt = startAt

                markers.Add(data)

                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to rebuild the index of a method list
        ''' </summary>
        ''' <returns></returns>
        Public Function rebuildIndex() As Boolean
            Try
                For Each item In methods
                    index.Add(item.name, item)
                Next

                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

    End Class

    Public Class PerformanceProfileEngine

        Private Property _CompleteProfileName As String = ""

        Public Property Data As New MethodListInformationsEngine
        Public Property log As CHCCommonLibrary.AreaEngine.Log.TrackEngine



        ''' <summary>
        ''' This method provide to initialize the engine
        ''' </summary>
        ''' <param name="path"></param>
        ''' <returns></returns>
        Public Function init(ByVal pathProfile As String) As Boolean
            Try
                If IsNothing(log) Then Return False

                log.trackEnter("CHCProtocol.PerformanceProfileEngine.init")

                If Not IO.Directory.Exists(pathProfile) Then
                    IO.Directory.CreateDirectory(pathProfile)
                End If

                _CompleteProfileName = IO.Path.Combine(pathProfile, "Data.PerformanceProfile")

                If IO.File.Exists(_CompleteProfileName) Then
                    _Data = IOFast(Of MethodListInformations).read(_CompleteProfileName)

                    Return Data.rebuildIndex()
                Else
                    Return True
                End If
            Catch ex As Exception
                log.trackException("CHCProtocol.PerformanceProfileEngine.init", ex.Message)

                Return False
            Finally
                log.trackExit("CHCProtocol.PerformanceProfileEngine.init")
            End Try
        End Function

        ''' <summary>
        ''' This method provide to process file log
        ''' </summary>
        ''' <param name="minItem"></param>
        ''' <returns></returns>
        Private Function processFileLog(ByRef currentItem As CHCModelsLibrary.AreaModel.Log.LogListModel.SingleLogBlockModel, ByVal minItem As Double) As Boolean
            Try
                Dim engine As CHCCommonLibrary.AreaEngine.Log.LogBlockEngine
                Dim start As Boolean = False

                engine = New CHCCommonLibrary.AreaEngine.Log.LogBlockEngine

#If DEBUG Then
                engine.logFilePath = "E:\LegacyNetwork\System\Logs\SidechainService\toElaborate"

                Return True
#Else
                engine.logFilePath = log.settings.pathFileLog
#End If

                engine.logInstance = ""

                If engine.exist(currentItem.name) Then
                    For Each item In engine.read(currentItem.name)

                        If Not start Then
                            start = (item.instant > minItem)
                        End If

                        If start Then
                            Select Case item.action
                                Case CHCModelsLibrary.AreaModel.Log.ActionEnumeration.enterIntoMethod : _Data.enterIntoMethod(item.instant, item.position)
                                Case CHCModelsLibrary.AreaModel.Log.ActionEnumeration.exitFromTheMethod
                                    If Not _Data.exitFromMethod(item.instant, item.position) Then
                                        log.trackException("MethodListInformations.processFileLog", $"Method not enter: {item.position}")
                                    End If
                                Case CHCModelsLibrary.AreaModel.Log.ActionEnumeration.trackMarker
                                    _Data.trackMarker(item.position, item.instant)
                            End Select
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
                Dim minItem As CHCModelsLibrary.AreaModel.Log.LogListModel.SingleLogBlockModel
                Dim maxFile As Double = 0
                Dim fileName As String = ""

                If IsNothing(log) Then Return False

                log.trackEnter("CHCProtocol.PerformanceProfileEngine.run")

                With New CHCCommonLibrary.AreaEngine.Log.LogBlockEngine()
#If DEBUG Then
                    .logFilePath = "E:\LegacyNetwork\System\Logs\SidechainService\toElaborate"
#Else
                    .logFilePath = log.settings.pathFileLog
#End If

                    value = .readListLogFile()
                End With

                For Each item In value.items
                    If (item.startAt > _Data.lastPosition) Then
                        scanToFile.Add(New CHCModelsLibrary.AreaModel.Log.LogListModel.SingleLogBlockModel With {.name = item.name, .startAt = item.startAt})
                    End If
                Next

                For Each item In value.items
                    If (item.startAt < _Data.lastPosition) Then
                        If (maxFile = 0) Or (item.startAt > maxFile) Then
                            maxFile = item.startAt

                            fileName = item.name
                        End If
                    End If
                Next

                If (maxFile > 0) Then
                    scanToFile.Add(New CHCModelsLibrary.AreaModel.Log.LogListModel.SingleLogBlockModel With {.name = fileName, .startAt = maxFile})
                End If

                Do While (scanToFile.Count > 0)
                    For Each item In scanToFile
                        If IsNothing(minItem) Then
                            minItem = item
                        ElseIf (minItem.startAt > item.startAt) Then
                            minItem = item
                        End If
                    Next

                    processFileLog(minItem, _Data.lastPosition)

                    scanToFile.Remove(minItem)
                Loop

                Return IOFast(Of MethodListInformations).save(_CompleteProfileName, _Data)
            Catch ex As Exception
                log.trackException("CHCProtocol.PerformanceProfileEngine.run", ex.Message)

                Return False
            Finally
                log.trackExit("CHCProtocol.PerformanceProfileEngine.run")
            End Try
        End Function

    End Class

End Namespace
