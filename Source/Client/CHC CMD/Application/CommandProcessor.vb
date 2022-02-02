Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.CommandLine





Namespace AreaCommon

    ''' <summary>
    ''' This class contain the processor of a command line
    ''' </summary>
    Public Class CommandProcessor

        Private Const _doubleQuotationMarks As String = Chr(34) & Chr(34)
        Private Const _commandRelease As String = "release"
        Private Const _commandInfo As String = "info"
        Private Const _commandHelp As String = "help"
        Private Const _commandUpdateSystemDate As String = "updateSystemDate"
        Private Const _commandCurrentTime As String = "currentTime"
        Private Const _commandChainServiceSettings As String = "chainServiceSettings"


        Public Property command As New CommandStructure



        ''' <summary>
        ''' This method provide to execute a command
        ''' </summary>
        ''' <returns></returns>
        Public Function run(ByVal value As String) As Boolean
            Dim response As Boolean
            Dim classSupport As Models.CommandModel

            Dim engine As New CommandBuilder

            value = value.Split(_doubleQuotationMarks)(2).Trim()

            command = engine.run(value)

            Select Case command.code
                Case _commandRelease.ToLower : classSupport = New Command.CommandRelease
                Case _commandInfo.ToLower : classSupport = New Command.CommandInfo
                Case _commandHelp.ToLower : classSupport = New Command.CommandHelp
                Case _commandUpdateSystemDate.ToLower() : classSupport = New Command.CommandUpdateSystemDate
                Case _commandCurrentTime.ToLower() : classSupport = New Command.CommandCurrentTime
                Case _commandChainServiceSettings.ToLower() : classSupport = New Command.CommandChainServiceSettings

                Case Else
                    Console.WriteLine()
                    Return False
            End Select

            classSupport.command = command

            response = classSupport.run()

            If response Then
                If command.haveParameter("pause") Then
                    Console.WriteLine("")
                    Console.WriteLine("Press a key to continue")
                    Console.ReadKey()
                End If
            End If

            Return response
        End Function

    End Class

End Namespace
