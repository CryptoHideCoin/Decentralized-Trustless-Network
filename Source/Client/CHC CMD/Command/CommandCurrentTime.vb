Option Compare Text
Option Explicit On

Imports CHCCmd.AreaCommon.Models
Imports CHCCommonLibrary.AreaEngine.CommandLine




Namespace AreaCommon.Command

    ''' <summary>
    ''' This class manage the command Current Time 
    ''' </summary>
    Public Class CommandCurrentTime : Implements CommandModel

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
                Console.WriteLine("Local time = " & Now.ToString())
                Console.WriteLine("GMT time   = " & CHCCommonLibrary.AreaEngine.Miscellaneous.atMomentGMT)
                Console.WriteLine("Timestamp  = " & CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime)

                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

    End Class

End Namespace

