Option Compare Text
Option Explicit On

' ****************************************
' Engine: Log Cache
' Release Engine: 1.0 
' 
' Date last successfully test: 05/02/2022
' ****************************************

Imports CHCModelsLibrary.AreaModel.Log



Namespace AreaEngine.Log

    ''' <summary>
    ''' This method provide to write into file
    ''' </summary>
    Friend Class TrackIOEngine

        Private Property _CurrentFileName As String = ""
        Private Property _LastWriteFileName As String = ""
        Private Property _ToWrite As New Concurrent.ConcurrentQueue(Of SingleActionApplication)
        Private Property _Settings As New TrackConfiguration

        Private Property _UseMainFile As Boolean = False
        Private Property _ChangeInBeginWrite As Boolean = False
        Private Property _ChangeInNormalMode As Boolean = False
        Private Property _ForceWriteFile As Boolean = False
        Private Property _StartWriteFile As Double = 0
        Private Property _NumRegistrationOnFile As Integer = 0

        ''' <summary>
        ''' This method provide to add a new action into memory list
        ''' </summary>
        ''' <param name="item"></param>
        ''' <returns></returns>
        Public Function addNewAction(ByVal item As SingleActionApplication) As Boolean
            Try
                _ToWrite.Enqueue(item)

                Return True
            Catch ex As Exception
            End Try

            Return False
        End Function

        ''' <summary>
        ''' This method provide to add a new file to index
        ''' </summary>
        Private Function addNewFileToIndex() As Boolean
            Try
                Dim indexFile As String = IO.Path.Combine(_Settings.pathFileLog, "index.dat")
                Dim currentFileName As String = IO.Path.GetFileName(_CurrentFileName).Replace(".log", "")

                If (currentFileName.CompareTo(_LastWriteFileName) <> 0) Then
                    Using fileData As IO.StreamWriter = IO.File.AppendText(indexFile)
                        fileData.WriteLine($"{currentFileName}|{Miscellaneous.timeStampFromDateTime()}")
                    End Using

                    _LastWriteFileName = currentFileName
                End If

                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to set a file name
        ''' </summary>
        ''' <returns></returns>
        Private Function setFileName() As Boolean
            Dim setFile As Boolean = False
            Dim newFile As String = ""

            If _ChangeInBeginWrite Then
                _StartWriteFile = Miscellaneous.timeStampFromDateTime()

                If Not IO.Directory.Exists(_Settings.pathFileLog) Then
                    IO.Directory.CreateDirectory(_Settings.pathFileLog)
                End If

                newFile = IO.Path.Combine(_Settings.pathFileLog, "main.log")
                _ChangeInBeginWrite = False

                If newFile.CompareTo(_CurrentFileName) <> 0 Then
                    _CurrentFileName = newFile
                End If

                Return True
            ElseIf _ChangeInNormalMode Then
                setFile = True

                _ChangeInNormalMode = False
            ElseIf (_Settings.changeNumberOfRegistrations > 0) And (_NumRegistrationOnFile > _Settings.changeNumberOfRegistrations) Then
                setFile = True
            ElseIf (_Settings.changeFileEvery > 0) And (Miscellaneous.timeStampFromDateTime() > _StartWriteFile + (CDec(_Settings.changeFileEvery) * 60 * 60 * 1000)) Then
                setFile = True
            ElseIf _ForceWriteFile Then
                Return True
            End If

            If setFile Then
                _StartWriteFile = Miscellaneous.timeStampFromDateTime()
                _NumRegistrationOnFile = 0

                If _UseMainFile Then
                    newFile = IO.Path.Combine(_Settings.pathFileLog, "execute-" & _StartWriteFile.ToString.Replace(",", "").Replace(".", "") & ".log")

                    If newFile.CompareTo(_CurrentFileName) <> 0 Then
                        _CurrentFileName = newFile
                    End If
                End If

                Return True
            Else
                If (_CurrentFileName.Length > 0) And _Settings.writeToFile Then
                    Return True
                End If

                Return False
            End If

        End Function

        ''' <summary>
        ''' This method provide to write the list into file
        ''' </summary>
        ''' <returns></returns>
        Public Function writeToFile() As Boolean
            Try
                Dim item As SingleActionApplication

                If (_Settings.pathFileLog.Length = 0) Then
                    Return True
                End If

                If Not setFileName() Or (_ToWrite.Count = 0) Then
                    Return False
                End If

                _UseMainFile = True

                addNewFileToIndex()

                Using fileData As IO.StreamWriter = IO.File.AppendText(_CurrentFileName)
                    Do While (_ToWrite.Count > 0)
#Disable Warning BC42030
                        If _ToWrite.TryDequeue(item) Then
#Enable Warning BC42030
                            fileData.WriteLine(item.toString())

                            _NumRegistrationOnFile += 1
                        End If
                    Loop
                End Using

                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to change the settings
        ''' </summary>
        ''' <param name="value"></param>
        ''' <returns></returns>
        Public Function changeSettings(ByVal value As TrackConfiguration) As Boolean
            Try
                _Settings = value

                If (value.pathFileLog.Length > 0) And Not _ChangeInBeginWrite Then
                    _ChangeInBeginWrite = True

                    writeToFile()
                End If

                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to change in bootstrap as a complete
        ''' </summary>
        ''' <returns></returns>
        Public Function changeInBootStrapComplete() As Boolean
            _ChangeInNormalMode = True

            If setFileName() Then
                _ForceWriteFile = True

                writeToFile()
            End If

            Return True
        End Function

        ''' <summary>
        ''' This method provide to force a write file
        ''' </summary>
        ''' <returns></returns>
        Public Function writeCacheToLogFile() As Boolean
            _ForceWriteFile = True

            writeToFile()

            _ForceWriteFile = True

            Return True
        End Function

    End Class

End Namespace
