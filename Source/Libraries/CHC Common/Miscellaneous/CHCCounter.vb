Option Explicit On
Option Compare Text

' ****************************************
' Engine: Counter manager
' Release Engine: 1.0 
' 
' Date last successfully test: 02/10/2021
' ****************************************


Imports CHCCommonLibrary.AreaEngine.DataFileManagement.XML





Namespace Support

    ''' <summary>
    ''' This class manage a counter of the access
    ''' </summary>
    Public Class CounterEngine

        Inherits BaseFile(Of List(Of CounterData))

        ''' <summary>
        ''' This class contain a property of a single counter
        ''' </summary>
        Public Class CounterData

            Public counterName As String = ""
            Public value As Integer = 1

        End Class


        Private _path As String
        Private _LastDate As String
        Private _keyAdverts As New Dictionary(Of String, CounterData)
        Private _logEngine As LogEngine


        Public noSave As Boolean = False




        ''' <summary>
        ''' This method provide to manage log with optional adapter
        ''' </summary>
        ''' <param name="position"></param>
        ''' <param name="content"></param>
        ''' <param name="messageType"></param>
        ''' <param name="adapterLog"></param>
        Private Sub trackLog(ByVal position As String, ByVal content As String, Optional ByVal messageType As String = "info", Optional ByVal adapterLog As Support.LogEngine = Nothing)
            If Not IsNothing(adapterLog) Then
                adapterLog.track(position, content, messageType)
            ElseIf Not IsNothing(_logEngine) Then
                _logEngine.track(position, content, messageType)
            End If
        End Sub

        ''' <summary>
        ''' This method provide to rebuild a complete list
        ''' </summary>
        ''' <returns></returns>
        Private Function rebuildIndex(Optional adapterLog As Support.LogEngine = Nothing) As Boolean
            Try
                trackLog("Advertisements.rebuildIndex", "Begin", , adapterLog)

                _keyAdverts = New Dictionary(Of String, CounterData)

                trackLog("CounterEngine.rebuildIndex", "new Dictionary", , adapterLog)

                For Each item In data
                    _keyAdverts.Add(item.counterName, item)
                Next

                trackLog("CounterEngine.rebuildIndex", "For...each completed", , adapterLog)

                Return True
            Catch ex As Exception
                trackLog("CounterEngine.rebuildIndex", ex.Message, "Fatal", adapterLog)

                Return False
            End Try
        End Function


        ''' <summary>
        ''' This method provide to initialize the engine
        ''' </summary>
        ''' <param name="path"></param>
        ''' <param name="useLogEngineAccess"></param>
        ''' <param name="adapterLog"></param>
        ''' <returns></returns>
        Public Function init(ByVal path As String, Optional ByVal useLogEngineAccess As Boolean = False, Optional adapterLog As Support.LogEngine = Nothing) As Boolean
            If useLogEngineAccess Then
                adapterLog = _logEngine.createAccess()
            End If

            Try
                trackLog("CounterEngine.init", "Begin",, adapterLog)

                _path = path

                If Not IO.Directory.Exists(_path) Then
                    trackLog("CounterEngine.init", "The path not exist = " & path,, adapterLog)

                    IO.Directory.CreateDirectory(_path)
                End If

                _LastDate = Now.ToUniversalTime().ToString("yyyyMMdd")

                Return read()
            Catch ex As Exception
                trackLog("CounterEngine.init", ex.Message, "Fatal", adapterLog)
            Finally
                trackLog("CounterEngine.init", "Completed",, adapterLog)
            End Try

            Return True
        End Function

        ''' <summary>
        ''' This method provide to increase a specific counter
        ''' </summary>
        ''' <param name="counterName"></param>
        ''' <param name="useLogEngineAccess"></param>
        ''' <param name="adapterLog"></param>
        ''' <returns></returns>
        Public Function increase(ByVal counterName As String, Optional ByVal useLogEngineAccess As Boolean = False, Optional adapterLog As Support.LogEngine = Nothing) As Boolean
            If useLogEngineAccess Then
                adapterLog = _logEngine.createAccess()
            End If

            Try
                trackLog("CounterEngine.increase", "Begin",, adapterLog)

                If (Now.ToUniversalTime().ToString("yyyyMMdd") <> _LastDate) Then
                    trackLog("CounterEngine.increase", "Change data",, adapterLog)

                    If (MyBase.data.Count > 0) Then
                        trackLog("CounterEngine.increase", "Prepare flush old data",, adapterLog)

                        Me.Save(, adapterLog)

                        trackLog("CounterEngine.increase", "Data flushed",, adapterLog)

                        MyBase.data.Clear()

                        _keyAdverts = New Dictionary(Of String, CounterData)

                        trackLog("CounterEngine.increase", "New data created",, adapterLog)
                    End If

                    _LastDate = Now.ToUniversalTime().ToString("yyyyMMdd")
                End If

                If _keyAdverts.ContainsKey(counterName) Then
                    _keyAdverts.Item(counterName).value += 1
                Else
                    Dim tmp As New CounterData

                    trackLog("CounterEngine.increase", "Build new counter",, adapterLog)

                    tmp.counterName = counterName

                    MyBase.data.Add(tmp)

                    _keyAdverts.Add(tmp.counterName, tmp)
                End If

                Return True
            Catch ex As Exception
                trackLog("CounterEngine.increase", ex.Message, "Fatal", adapterLog)
            Finally
                trackLog("CounterEngine.increase", "Completed",, adapterLog)
            End Try

            Return False
        End Function

        ''' <summary>
        ''' This method provide to read the counter incomplete
        ''' </summary>
        ''' <param name="forceDate"></param>
        ''' <param name="useLogEngineAccess"></param>
        ''' <param name="adapterLog"></param>
        ''' <returns></returns>
        Public Overloads Function read(Optional forceDate As String = "", Optional ByVal useLogEngineAccess As Boolean = False, Optional adapterLog As Support.LogEngine = Nothing) As Boolean
            If useLogEngineAccess Then
                adapterLog = _logEngine.createAccess()
            End If

            Try
                trackLog("CounterEngine.read", "Begin",, adapterLog)

                If (forceDate.Length = 0) Then
                    forceDate = Now.ToUniversalTime().ToString("yyyyMMdd")
                End If

                _LastDate = forceDate

                MyBase.fileName = IO.Path.Combine(_path, forceDate & ".counter")

                trackLog("CounterEngine.read", "fileName = " & MyBase.fileName,, adapterLog)

                If MyBase.read() Then
                    rebuildIndex(adapterLog)
                End If
            Catch ex As Exception
                trackLog("Advertisements.read", ex.Message, "Fatal", adapterLog)
            Finally
                trackLog("CounterEngine.read", "Completed",, adapterLog)
            End Try

            Return False
        End Function

        ''' <summary>
        ''' This method provide to save a counter incomplete into file
        ''' </summary>
        ''' <param name="useLogEngineAccess"></param>
        ''' <param name="adapterLog"></param>
        ''' <returns></returns>
        Public Overloads Function Save(Optional ByVal useLogEngineAccess As Boolean = False, Optional adapterLog As Support.LogEngine = Nothing) As Boolean
            If useLogEngineAccess Then
                adapterLog = _logEngine.createAccess()
            End If

            Try
                trackLog("CounterEngine.save", "Begin",, adapterLog)

                MyBase.fileName = IO.Path.Combine(_path, _LastDate & ".counter")

                Return MyBase.save()
            Catch ex As Exception
                trackLog("Advertisements.save", ex.Message, "Fatal", adapterLog)
            Finally
                trackLog("CounterEngine.save", "Completed",, adapterLog)
            End Try

            Return False
        End Function

    End Class

End Namespace