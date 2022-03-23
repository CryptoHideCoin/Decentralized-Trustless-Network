﻿Option Compare Text
Option Explicit On

Imports CHCCmd.AreaCommon.Models
Imports CHCCommonLibrary.AreaEngine.CommandLine








Namespace AreaCommon.Command

    ''' <summary>
    ''' This class manage the command Test Serve Response
    ''' </summary>
    Public Class CommandWrite : Implements CommandModel

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
            If _Command.haveParameter("message") Then
                Console.WriteLine(_Command.parameterValue("message"))

                Return True
            Else
                Console.WriteLine("Message missing!")

                Return False
            End If
        End Function

    End Class

End Namespace