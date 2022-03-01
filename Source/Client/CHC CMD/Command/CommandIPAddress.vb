Option Compare Text
Option Explicit On

Imports CHCCmd.AreaCommon.Models
Imports CHCCommonLibrary.AreaEngine.CommandLine




Namespace AreaCommon.Command

    ''' <summary>
    ''' This class manage the command IP Address 
    ''' </summary>
    Public Class CommandIPAddress : Implements CommandModel

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
            Console.WriteLine("Local IP Address = " & CHCSidechainServiceLibrary.AreaNetwork.Address.acquireLocalIP(False))
            Console.WriteLine("Public IP Address = " & CHCSidechainServiceLibrary.AreaNetwork.Address.acquirePublicIP)

            Return True
        End Function

    End Class

End Namespace
