Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.CommandLine








Namespace AreaCommon.Command

    ''' <summary>
    ''' This class manage the command Test Serve Response
    ''' </summary>
    Public Class CommandWrite : Implements CommandModel

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
            If _Command.haveParameter("message") Then
                RaiseEvent WriteLine(_Command.parameterValue("message"))

                Return True
            Else
                RaiseEvent WriteLine("Message missing!")

                Return False
            End If
        End Function

    End Class

End Namespace
