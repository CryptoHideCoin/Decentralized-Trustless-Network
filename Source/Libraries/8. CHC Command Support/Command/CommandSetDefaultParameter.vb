Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.CommandLine




Namespace AreaCommon.Command

    ''' <summary>
    ''' This class manage the command a Set Default Parameter
    ''' </summary>
    Public Class CommandSetDefaultParameter : Implements CommandModel

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
            Try
                Dim value As String

                If Not _Command.haveParameter("name") Then
                    RaiseEvent WriteLine("Error: name missing")

                    Return False
                End If
                If Not _Command.haveParameter("value") Then
#Disable Warning BC42016
                    If (_Command.parameterValue("value").ToLower.Contains("datapath") = 0) Then
#Enable Warning BC42016
                        value = AreaEngine.EnvironmentUtils.getCurrentEnvironmentPath()
                    Else
                        RaiseEvent WriteLine("Error: value missing")

                        Return False
                    End If
                Else
                    value = _Command.parameterValue("value")
                End If

                If AreaEngine.ParametersEngine.createNew(_Command.parameterValue("name"), value) Then
                    RaiseEvent WriteLine("Default parameter set")
                Else
                    RaiseEvent WriteLine("Error: environment not found")
                End If

                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

    End Class

End Namespace
