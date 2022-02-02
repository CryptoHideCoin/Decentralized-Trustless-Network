Option Compare Text
Option Explicit On





Namespace AreaCommon.CommandLine

    ''' <summary>
    ''' This enumeration contain the command of this application
    ''' </summary>
    Public Enum CommandEnumeration
        undefined
        parameter
    End Enum

    ''' <summary>
    ''' This class contain the processor of a command line
    ''' </summary>
    Public Class CommandProcessor

        Public Property command As New CommandArguments



        ''' <summary>
        ''' This method provide to decode into command enumeration
        ''' </summary>
        ''' <param name="key"></param>
        ''' <returns></returns>
        Public Shared Function getCommandCode(ByVal key As String) As CommandEnumeration
            Select Case key.ToLower.Trim()
                Case "parameter" : Return CommandEnumeration.parameter
                Case Else : Return CommandEnumeration.undefined
            End Select
        End Function

        ''' <summary>
        ''' This method provide to execute a command
        ''' </summary>
        ''' <returns></returns>
        Public Function execute() As Boolean
            Dim response As Boolean = False

            Select Case command.code
                Case CommandEnumeration.undefined : response = False
                Case CommandEnumeration.parameter : response = True
            End Select

            Return response
        End Function

    End Class

End Namespace
