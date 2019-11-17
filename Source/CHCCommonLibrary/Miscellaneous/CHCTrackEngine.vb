Option Compare Text
Option Explicit On






Namespace CHCEngines.Miscellaneous


    Public Class TrackExecution


        Private _Cache As New List(Of String)

        Private _CompleteFileName As String



        Public noTrack As Boolean = False








        Private Sub writeLogCache()

            Try

                If Not noTrack Then

                    Using FileData As IO.StreamWriter = IO.File.AppendText(_CompleteFileName)

                        For Each tmp In _Cache

                            FileData.WriteLine(tmp)

                        Next

                    End Using

                End If

            Catch ex As Exception

            End Try

        End Sub



        Public Function Init(ByVal dataPath As String) As Boolean

            Try

                _CompleteFileName = IO.Path.Combine(dataPath, "Logs")

                If Not IO.Directory.Exists(_CompleteFileName) Then

                    IO.Directory.CreateDirectory(_CompleteFileName)

                End If

                If _Cache.Count > 0 Then

                    writeLogCache()

                End If

                _Cache.Clear()

                Return True

            Catch ex As Exception

                Return False

            End Try

        End Function



        Public Sub Log(ByVal position As String, ByVal content As String)

            Try

                If Not noTrack Then

                    If IsNothing(_CompleteFileName) Then

                        _Cache.Add(atMomentGMT() & " - [" & position & "] - " & content)

                        Return

                    End If

                    Using FileData As IO.StreamWriter = IO.File.AppendText(_CompleteFileName)

                        FileData.WriteLine("{0} - {1} - [{2}] - {3}", atMomentGMT(), timestampFromDateTime(), position, content)

                    End Using

                End If

            Catch ex As Exception

            End Try

        End Sub



    End Class


End Namespace

