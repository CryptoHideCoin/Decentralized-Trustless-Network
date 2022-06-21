Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.CommandLine




Namespace AreaCommon.Command

    ''' <summary>
    ''' This class manage the command Current Time 
    ''' </summary>
    Public Class CommandWait : Implements Models.CommandModel

        Private Property _Command As CommandStructure

        Public Event WriteLine(ByVal message As String) Implements Models.CommandModel.WriteLine
        Public Event Process(ByVal applicationName As String, ByVal commandLine As String) Implements Models.CommandModel.Process
        Public Event IntegrityApplication(ByVal fileName As String) Implements Models.CommandModel.IntegrityApplication
        Public Event RaiseError(ByVal message As String) Implements Models.CommandModel.RaiseError
        Public Event ReadKey() Implements Models.CommandModel.ReadKey


        Private Property CommandModel_command As CommandStructure Implements Models.CommandModel.command
            Get
                Return _Command
            End Get
            Set(value As CommandStructure)
                _Command = value
            End Set
        End Property

        Private Function CommandModel_run() As Boolean Implements Models.CommandModel.run
            Try
                Dim pauseValue As Integer = 5000

                If _Command.haveParameter("durate") Then
                    If IsNumeric(_Command.parameterValue("durate")) Then
#Disable Warning BC42016
                        pauseValue = _Command.parameterValue("durate")
#Enable Warning BC42016
                    End If
                End If

                Threading.Thread.Sleep(pauseValue)

                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

    End Class

End Namespace
