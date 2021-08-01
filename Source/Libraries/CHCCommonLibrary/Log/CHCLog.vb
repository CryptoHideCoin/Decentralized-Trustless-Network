Option Explicit On
Option Compare Text

Imports CHCCommonLibrary.AreaEngine.Miscellaneous






Namespace Support


    Public Class LogEngine

        Public Enum TrackRuntimeModeEnum
            dontTrack
            trackOnlyMain
            trackAllRuntime
        End Enum

        Public Class TrackData
            Public istant As String
            Public dateTime As String
            Public messageType As String
            Public position As String
            Public content As String
        End Class


        Private _cache As New List(Of String)
        Private _path As String
        Private _lastInfoTrack As String
        Private _called As Boolean = False
        Private _registry As RegistryEngine
        Private _CurrentPage As String = ""



        Public noSave As Boolean = False
        Public noPrintConsole As Boolean = False
        Public useCache As Boolean = True
        Public dimPageConsoleGUI As Integer = 0
        Public completeFileName As String
        Public objectConsoleGUI As Object = Nothing
        Public objectActionGUI As Object = Nothing

        Public ReadOnly Property called() As Boolean
            Get
                Return _called
            End Get
        End Property




        ''' <summary>
        ''' This method provide to write into a console GUI
        ''' </summary>
        ''' <param name="rowTmp"></param>
        Private Sub writeConsoleGUI(Optional ByVal rowTmp As String = "")
            Try
                If Not IsNothing(objectConsoleGUI) And (_cache.Count > 0) Then
                    If (rowTmp.Length > 0) Then
                        _cache.Add(rowTmp)
                    End If

                    If (_cache.Count > 50) Then
                        _cache.RemoveRange(0, _cache.Count - 50)
                    End If

                    objectConsoleGUI.text = String.Join(vbCrLf, _cache)

                    objectConsoleGUI.SelectionLength = 0
                End If
            Catch ex As Exception
            End Try
        End Sub


        ''' <summary>
        ''' This method provide to flush a cache
        ''' </summary>
        Private Sub flushCache()
            Try
                If Not noSave Then
                    Using fileData As IO.StreamWriter = IO.File.AppendText(completeFileName)
                        For Each strTmp In _cache
                            fileData.WriteLine(strTmp)
                        Next
                    End Using
                End If

                writeConsoleGUI()
            Catch ex As Exception
            End Try
        End Sub


        ''' <summary>
        ''' This method provide to initialize the log component
        ''' </summary>
        ''' <param name="basePath"></param>
        ''' <param name="fileName"></param>
        ''' <param name="registryPointer"></param>
        ''' <returns></returns>
        Public Function init(ByVal basePath As String, Optional ByVal fileName As String = "Main", Optional ByVal registryPointer As Support.RegistryEngine = Nothing) As Boolean
            Try
                _registry = registryPointer

                If fileName = "main" Then fileName += "-" & Now.ToUniversalTime().ToString("yyyy-MM-dd") & ".track"

                _path = basePath
                completeFileName = IO.Path.Combine(basePath, fileName)

                If Not IO.Directory.Exists(_path) Then IO.Directory.CreateDirectory(_path)

                If (_cache.Count > 0) Then flushCache()

                useCache = False

                If IsNothing(objectConsoleGUI) Then _cache.Clear()

                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function


        ''' <summary>
        ''' This method to provide to track a specific message
        ''' </summary>
        ''' <param name="position"></param>
        ''' <param name="content"></param>
        ''' <param name="messageType"></param>
        Public Sub track(ByVal position As String, ByVal content As String, Optional ByVal messageType As String = "info", Optional ByVal printIntoConsole As Boolean = False)
            Try
                _lastInfoTrack = timestampFromDateTime() & "|" & atMomentGMT() & "|" & messageType & "|" & position & "|" & content

                If IsNothing(completeFileName) And useCache Then
                    _cache.Add(_lastInfoTrack)

                    Return
                End If

                If Not noSave Then
                    Using fileData As IO.StreamWriter = IO.File.AppendText(completeFileName)
                        fileData.WriteLine(_lastInfoTrack)
                    End Using
                End If

                If printIntoConsole Or (messageType = "fatal") Then
                    Console.WriteLine(_lastInfoTrack)
                End If

                writeConsoleGUI(_lastInfoTrack)

                If (messageType = "fatal") Then
                    If Not IsNothing(_registry) Then
                        _registry.addNew(RegistryEngine.RegistryData.TypeEvent.applicationError, content, completeFileName)
                    End If
                End If
            Catch ex As Exception
            End Try
        End Sub


        ''' <summary>
        ''' This method provide to track into console
        ''' </summary>
        ''' <param name="message"></param>
        Public Sub trackIntoConsole(Optional ByVal message As String = "")
            Try
                If Not noPrintConsole Then
                    Console.WriteLine(message)
                End If
            Catch ex As Exception
            End Try
        End Sub


        ''' <summary>
        ''' This method provide to return a Last Track of log
        ''' </summary>
        ''' <returns></returns>
        Public Function getLastTrack() As TrackData
            Dim tmp = _lastInfoTrack.Split("|")
            Dim result As New TrackData

            If (tmp.Count > 0) Then
                result.istant = tmp(0)
                result.dateTime = tmp(1)
                result.messageType = tmp(2)
                result.position = tmp(3)
                result.content = tmp(4)
            End If

            Return result
        End Function


        ''' <summary>
        ''' This method provide to create an access Log
        ''' </summary>
        ''' <returns></returns>
        Public Function createAccess() As LogEngine
            Dim tmp As New LogEngine

            tmp.init(_path, "Access-" & Now.ToUniversalTime().ToString("yyyyMMdd") & "-" & Guid.NewGuid().ToString() & ".track")

            _called = True

            Return tmp
        End Function

    End Class

End Namespace

