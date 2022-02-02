Option Explicit On
Option Compare Text

' ****************************************
' Engine: Log Rotate Engine
' Release Engine: 1.0 
' 
' Date last successfully test: 02/10/2021
' ****************************************


Imports System.Threading




Namespace Support

    ''' <summary>
    ''' This class manage a Rotate Log File
    ''' </summary>
    Public Class LogRotateEngine

        ''' <summary>
        ''' This class contain a configuration of a Log Rotate
        ''' </summary>
        Public Class LogRotateConfig

            Public Enum FrequencyEnum
                every12h
                everyDay
            End Enum

            Public Enum KeepEnum
                lastDay
                lastWeek
                lastMonth
                lastYear
            End Enum

            Public Enum KeepFileEnum
                nothingFiles
                onlyMainTracks
            End Enum

            Public frequency As FrequencyEnum
            Public keepLast As KeepEnum = KeepEnum.lastWeek
            Public keepFile As KeepFileEnum = KeepFileEnum.nothingFiles

        End Class

        Public Property lastClean As DateTime
        Public Property configuration As New LogRotateConfig
        Public Property path As String

        Private _Log As New LogEngine


        ''' <summary>
        ''' This method provide to test the execute moment
        ''' </summary>
        ''' <returns></returns>
        Private Function itsNow() As Boolean
            If (lastClean = DateTime.MinValue) Then
                Return True
            ElseIf (configuration.frequency = LogRotateConfig.FrequencyEnum.every12h) Then
                Return (Now.Subtract(lastClean).TotalHours >= 12)
            Else
                Return (Now.Subtract(lastClean).TotalHours >= 24)
            End If

            Return False
        End Function

        ''' <summary>
        ''' This method provide to run an asynchronus process
        ''' </summary>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Private Function runWork() As Boolean
            Try
                _Log.track("LogRotate.runWork", "Begin")

                Dim objAsynch As New Thread(AddressOf CHCModule.executeLogRotate)

                objAsynch.Start()

                Return True
            Catch ex As Exception
                _Log.track("LogRotate.runWork", ex.Message, "Fatal")

                Return False
            End Try
        End Function


        ''' <summary>
        ''' This method provide to run an engine
        ''' </summary>
        ''' <param name="log"></param>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Public Function run(ByRef log As LogEngine) As Boolean
            Try
                _Log = log

                _Log.track("LogRotate.run", "Begin")

                supportLogRotate = Me

                If itsNow() Then
                    _Log.track("LogRotate.run", "It's now")

                    runWork()

                    lastClean = Now
                End If

                _Log.track("LogRotate.run", "Complete")

                Return True
            Catch ex As Exception
                _Log.track("LogRotate.run", ex.Message, "Fatal")

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to run an execute work of an engine
        ''' </summary>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Public Function runExecuteWork() As Boolean
            Dim diff As Decimal = 0
            Dim toEliminate As Boolean = False

            Try
                _Log.track("LogRotate.runExecuteWork", "Begin")

                For Each logFile As IO.FileInfo In New IO.DirectoryInfo(path).GetFiles

                    If (IO.Path.GetExtension(logFile.Name) = ".track") Then

                        diff = Now.Subtract(logFile.LastWriteTime).TotalDays
                        toEliminate = 0

                        Select Case configuration.keepLast

                            Case LogRotateConfig.KeepEnum.lastDay : toEliminate = (diff >= 1)
                            Case LogRotateConfig.KeepEnum.lastMonth : toEliminate = (diff >= 30)
                            Case LogRotateConfig.KeepEnum.lastWeek : toEliminate = (diff >= 7)
                            Case Else : toEliminate = (diff >= 365)

                        End Select

                        If toEliminate Then

                            If (configuration.keepFile = LogRotateConfig.KeepFileEnum.nothingFiles) Then
                                IO.File.Delete(logFile.FullName)
                            Else
                                If (logFile.Name Like "Access-*") Then
                                    IO.File.Delete(logFile.FullName)
                                End If
                            End If

                        End If

                    End If

                Next

                _Log.track("LogRotate.runExecuteWork", "Complete")

                Return True
            Catch ex As Exception
                _Log.track("LogRotate.runExecuteWork", ex.Message, "Fatal")

                Return False
            End Try

        End Function

    End Class

End Namespace
