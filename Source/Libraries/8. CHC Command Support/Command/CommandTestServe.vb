﻿Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.CommandLine
Imports CHCProtocolLibrary.AreaEngine.Service






Namespace AreaCommon.Command

    ''' <summary>
    ''' This class manage the command Test Serve 
    ''' </summary>
    Public Class CommandTestServe : Implements CommandModel

        Private Property _Command As CommandStructure

        Private WithEvents _EngineService As New AccessEngine

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
            Return _EngineService.Init(_Command, defaultParameters)
        End Function

        Private Sub _EngineService_LaunchIntegrityApplication(fileName As String) Handles _EngineService.LaunchIntegrityApplication
            RaiseEvent IntegrityApplication(fileName)
        End Sub

        Private Sub _EngineService_RaiseError(message As String) Handles _EngineService.RaiseError
            RaiseEvent RaiseError(message)
        End Sub

    End Class

End Namespace
