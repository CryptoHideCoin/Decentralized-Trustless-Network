Option Compare Text
Option Explicit On



Namespace AreaEngine

    Public Class EnvironmentRepositoryEngine

        ''' <summary>
        ''' This method provide to test write a path
        ''' </summary>
        ''' <param name="path"></param>
        ''' <returns></returns>
        Private Shared Function trySearchPath(ByVal path As String) As Boolean
            path = IO.Path.Combine(path, "environment.path")

            Try
                Return IO.File.Exists(path)
            Catch ex As Exception
            End Try

            Return False
        End Function

        ''' <summary>
        ''' This method search define path
        ''' </summary>
        ''' <returns></returns>
        Public Shared Function searchUserEnvironmentPath() As String
            Dim found As Boolean = False
            Dim path As String = ""

            Try
                If Not found Then
#If DEBUG Then
                    path = "E:\CryptoHideCoinDTN\Binary\Applications\Console\CHC Cmd"
#Else
                path = Environment.CurrentDirectory
#End If
                    found = trySearchPath(path)
                End If
                If Not found Then
                    path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)

                    found = trySearchPath(path)
                End If
                If Not found Then
                    path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)

                    found = trySearchPath(path)
                End If

                If found Then
                    Return path
                End If
            Catch ex As Exception
            End Try

            Return ""
        End Function

    End Class

End Namespace
