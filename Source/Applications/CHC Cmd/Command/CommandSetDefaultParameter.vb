Option Compare Text
Option Explicit On

Imports CHCCmd.AreaCommon.Models
Imports CHCCommonLibrary.AreaEngine.CommandLine




Namespace AreaCommon.Command

    ''' <summary>
    ''' This class manage the command a Set Default Parameter
    ''' </summary>
    Public Class CommandSetDefaultParameter : Implements CommandModel

        Private Property _Command As CommandStructure

        Private Property CommandModel_command As CommandStructure Implements CommandModel.command
            Get
                Return _Command
            End Get
            Set(value As CommandStructure)
                _Command = value
            End Set
        End Property

        Private Function CommandModel_run() As Boolean Implements CommandModel.run
            Try
                If Not _Command.haveParameter("name") Then
                    Console.WriteLine("Error: name missing")

                    Return False
                End If
                If Not _Command.haveParameter("value") Then
                    Console.WriteLine("Error: value missing")

                    Return False
                End If

                If AreaEngine.ParametersEngine.createNew(_Command.parameterValue("name"), _Command.parameterValue("value")) Then
                    Console.WriteLine("Default parameter set")
                Else
                    Console.WriteLine("Error: environment not found")
                End If

                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

    End Class

End Namespace
