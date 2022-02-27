Option Explicit On
Option Compare Text

Imports CHCModels.AreaModel.Log








Namespace AreaEngine

    ''' <summary>
    ''' This class contain all element of engine clean of log
    ''' </summary>
    Public Class CleanLogEngine

        Public Property instanceLog As String = ""
        Public Property pathLog As String = ""
        Public Property keepFile As KeepEnum


        ''' <summary>
        ''' This method provide to clean a log instance
        ''' </summary>
        ''' <param name="specificPathLog"></param>
        ''' <returns></returns>
        Private Function cleanLogInstance(ByVal specificPathLog As String) As Boolean
            Try
                Dim path As String = IO.Path.Combine(pathLog, specificPathLog)
                Dim diff As Decimal = 0
                Dim toEliminate As Boolean = False

                For Each logFile As IO.FileInfo In New IO.DirectoryInfo(path).GetFiles
                    If (IO.Path.GetExtension(logFile.Name) = ".track") Then

                        diff = Now.Subtract(logFile.LastWriteTime).TotalDays
                        toEliminate = 0

                        Select Case keepFile

                            Case KeepEnum.lastDay : toEliminate = (diff >= 1)
                            Case KeepEnum.lastMonth : toEliminate = (diff >= 30)
                            Case KeepEnum.lastWeek : toEliminate = (diff >= 7)
                            Case Else : toEliminate = (diff >= 365)

                        End Select

                        If toEliminate Then
                            IO.File.Delete(logFile.FullName)
                        End If
                    End If
                Next

                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function


        ''' <summary>
        ''' This method provide to delete all older log file
        ''' </summary>
        ''' <returns></returns>
        Public Function run() As Boolean
            Try
                If (instanceLog.Length > 0) Then
                    Return cleanLogInstance(instanceLog)
                Else
                    For Each instance As IO.FileInfo In New IO.DirectoryInfo(pathLog).GetFiles
                        If (instance.Attributes = IO.FileAttributes.Directory) Then
                            If Not cleanLogInstance(instance.Name) Then
                                Return False
                            End If
                        End If
                    Next

                    Return True
                End If
            Catch ex As Exception
                Return False
            End Try
        End Function

    End Class

End Namespace
