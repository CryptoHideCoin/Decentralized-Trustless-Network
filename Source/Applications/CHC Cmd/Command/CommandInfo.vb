Option Compare Text
Option Explicit On

Imports CHCCmd.AreaCommon.Models
Imports CHCCommonLibrary.AreaEngine.CommandLine




Namespace AreaCommon.Command

    ''' <summary>
    ''' This class manage the command info 
    ''' </summary>
    Public Class CommandInfo : Implements CommandModel

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
            Console.WriteLine("Crypto Hide Coin Decentralized Trustless Network - Command Line Executor")
            Console.WriteLine("Free open source software")
            Console.WriteLine("(2022) Crypto Technology Alliances")
            Console.WriteLine("Release " & My.Application.Info.Version.ToString())

            Return True
        End Function

    End Class

End Namespace
