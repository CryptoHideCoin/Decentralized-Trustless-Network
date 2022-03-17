Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.CommandLine





Namespace AreaCommon

    ''' <summary>
    ''' This class contain the processor of a command line
    ''' </summary>
    Public Class CommandProcessor






        ''' <summary>
        ''' This method provide to execute a command
        ''' </summary>
        ''' <returns></returns>
        Public Function run() As Boolean
            Try
                Dim executor As New CommandExecutor

                executor.command = New CommandBuilder().run()

                Return executor.run()
            Catch ex As Exception
                CloseApplication(ex.Message)

                Return False
            End Try
        End Function

    End Class

End Namespace
