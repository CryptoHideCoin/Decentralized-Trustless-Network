﻿Option Explicit On
Option Compare Text

Imports CHCModelsLibrary.AreaModel.Log


Namespace AreaEngine

    ''' <summary>
    ''' This method provide to Clean Old Log Instance
    ''' </summary>
    Public Class CleanOldLogInstanceEngine

        ''' <summary>
        ''' This method provide to delete a single directory
        ''' </summary>
        ''' <param name="path"></param>
        ''' <returns></returns>
        Private Function deleteDirectory(ByVal path As String) As Boolean
            Try
                Dim di As IO.DirectoryInfo = New IO.DirectoryInfo(path)

                For Each singleFile As IO.FileInfo In di.GetFiles()
                    singleFile.Delete()
                Next

                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to remove al folder of old log
        ''' </summary>
        ''' <returns></returns>
        Public Function run() As Boolean
            Try
                AreaCommon.Main.environment.log.trackEnter("CleanOldLogInstanceEngine.run")

                Dim path As String = AreaCommon.Main.environment.log.settings.pathFile
                Dim instanceID As String = AreaCommon.Main.environment.log.settings.instanceID
                Dim toDelete As New List(Of String)

                For Each singleDir As String In IO.Directory.GetDirectories(path)
                    If (singleDir.Contains(instanceID) = 0) Then
                        toDelete.Add(singleDir)
                    End If
                Next

                For Each singleDir In toDelete
                    If deleteDirectory(singleDir) Then
                        IO.Directory.Delete(singleDir, True)
                    End If
                Next

                Return True
            Catch ex As Exception
                AreaCommon.Main.environment.log.trackException("CleanOldLogInstanceEngine.run", ex.Message)

                Return False
            Finally
                AreaCommon.Main.environment.log.trackExit("CleanOldLogInstanceEngine.run")
            End Try
        End Function

    End Class

End Namespace
