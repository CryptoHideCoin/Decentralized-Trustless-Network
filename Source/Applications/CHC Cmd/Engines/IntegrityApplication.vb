Option Compare Text
Option Explicit On



''' <summary>
''' This class contain all element of check integrity
''' </summary>
Public Class IntegrityApplication

    ''' <summary>
    ''' This method provide to check all this application
    ''' </summary>
    ''' <returns></returns>
    Public Function run() As Boolean
        Try
            Dim fileName As String

            For Each singleFile In IO.Directory.GetFiles(IO.Directory.GetCurrentDirectory)
                fileName = New IO.FileInfo(singleFile).Name

                Select Case fileName.ToLower()
                    Case "Newtonsoft.Json.dll".ToLower()
#If DEBUG Then
                        If (FileVersionInfo.GetVersionInfo(singleFile).ProductMajorPart <> 6) Then
#Else
                            If (FileVersionInfo.GetVersionInfo(singleFile).ProductMajorPart <> 6) Then
#End If
                            Console.WriteLine("the 'Newtonsoft.Json.dll' release is wrong. Current is " & FileVersionInfo.GetVersionInfo(singleFile).ProductVersion)
                        End If
                End Select

            Next

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

End Class
