Option Compare Text
Option Explicit On

Imports CHCCmd.AreaCommon.Models
Imports CHCCommonLibrary.AreaEngine.CommandLine




Namespace AreaCommon.Command

    ''' <summary>
    ''' This class manage the command Update System Date
    ''' </summary>
    Public Class CommandUpdateSystemDate : Implements CommandModel

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
                Process.Start("CMD", "/C net start w32time & w32tm /resync /force")
                Console.WriteLine("System date updated")

                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

    End Class

End Namespace
