Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.CommandLine




Namespace AreaCommon.Command

    ''' <summary>
    ''' This class manage the command help plus
    ''' </summary>
    Public Class CommandHelpPlus : Implements CommandModel

        Private Property _Command As CommandStructure

        Public Event WriteLine(ByVal message As String) Implements CommandModel.WriteLine
        Public Event Process(ByVal applicationName As String, ByVal commandLine As String) Implements CommandModel.Process
        Public Event IntegrityApplication(ByVal fileName As String) Implements CommandModel.IntegrityApplication
        Public Event RaiseError(ByVal message As String) Implements CommandModel.RaiseError
        Public Event ReadKey() Implements CommandModel.ReadKey


        Private Property CommandModel_command As CommandStructure Implements CommandModel.command
            Get
                Return _Command
            End Get
            Set(value As CommandStructure)
                _Command = value
            End Set
        End Property

        Private Function CommandModel_run() As Boolean Implements CommandModel.run
            RaiseEvent WriteLine("Help plus list command")
            RaiseEvent WriteLine("======================")
            RaiseEvent WriteLine("")
            RaiseEvent WriteLine("-helpPlus                            Show this list")
            RaiseEvent WriteLine("-sideChainServiceSettings            Open a Chain Settings Editor")
            RaiseEvent WriteLine("   --service:                        Set a service name")
            RaiseEvent WriteLine("   --dataPath:                       Set a data path")
            RaiseEvent WriteLine("   --showAsFile                      Show the content in a notepad")
            RaiseEvent WriteLine("   --password:                       Set a password to decode")
            RaiseEvent WriteLine("General switch:")
            RaiseEvent WriteLine("   --pause:                          Wait a key press to close a chc command")
            RaiseEvent WriteLine("   --wait:                           Wait a specific interval time (in millisecond) to close a chc command")

            Return True
        End Function

    End Class

End Namespace
