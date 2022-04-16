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
        Private Property _ToWrite As New Concurrent.ConcurrentQueue(Of SingleActionApplication)
        Private Property _Settings As New TrackConfiguration

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
        ''' This method provide to set a file name
        ''' </summary>
        ''' <returns></returns>
        Private Function setFileName() As Boolean
            Dim setFile As Boolean = False

            If _ForceWriteFile Then
                Return True
            ElseIf _ChangeInBeginWrite Then
                IO.Directory.CreateDirectory(_Settings.pathFileLog)

                _CurrentFileName = IO.Path.Combine(_Settings.pathFileLog, "main.log")
                _ChangeInBeginWrite = False

                Return True
            ElseIf _ChangeInNormalMode Then
                setFile = True

                _ChangeInNormalMode = False
            ElseIf (_Settings.changeFileEvery > 0) And (_StartWriteFile + _Settings.changeFileEvery > Miscellaneous.timeStampFromDateTime()) Then
                setFile = True
            ElseIf (_Settings.changeNumberOfRegistrations > 0) And (_NumRegistrationOnFile > _Settings.changeNumberOfRegistrations) Then
                setFile = True
            End If

            If setFile Then
                _StartWriteFile = Miscellaneous.timeStampFromDateTime()
                _NumRegistrationOnFile = 0
                _CurrentFileName = IO.Path.Combine(_Settings.pathFileLog, "execute-" & _StartWriteFile.ToString.Replace(",", "").Replace(".", "") & ".log")

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

                If (_Settings.pathFile.Length = 0) Then
                    Return True
                End If

                If Not setFileName() Or (_ToWrite.Count = 0) Then
                    Return False
                End If

                Using fileData As IO.StreamWriter = IO.File.AppendText(_CurrentFileName)
                    Do While (_ToWrite.Count > 0)
#Disable Warning BC42030
                        If _ToWrite.TryDequeue(item) Then
#Enable Warning BC42030
                            fileData.WriteLine(item.toString())
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

                If (value.instanceID.Length > 0) And (value.pathFile.Length > 0) And Not _ChangeInBeginWrite Then
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
