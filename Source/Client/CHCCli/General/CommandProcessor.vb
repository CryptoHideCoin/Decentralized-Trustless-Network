Option Compare Text
Option Explicit On





Namespace AreaCommon

    Public Enum CommandEnumeration
        undefined
        release
        help
    End Enum

    Public Class CommandProcessor

        Public command As New CommandArguments

        ''' <summary>
        ''' This method provide to execute a release command
        ''' </summary>
        ''' <returns></returns>
        Private Function executeRelease() As Boolean
            Console.Write(My.Application.Info.Version.ToString())

            Return True
        End Function


        ''' <summary>
        ''' This method provide to decode into command enumeration
        ''' </summary>
        ''' <param name="key"></param>
        ''' <returns></returns>
        Public Shared Function getCommandCode(ByVal key As String) As CommandEnumeration
            Select Case key.Trim()
                Case "release" : Return CommandEnumeration.release
                Case "help" : Return CommandEnumeration.help
                Case Else : Return CommandEnumeration.undefined
            End Select
        End Function

        ''' <summary>
        ''' This method provide to execute a command
        ''' </summary>
        ''' <returns></returns>
        Public Function execute() As Boolean
            Select Case command.code
                Case CommandEnumeration.undefined : Console.WriteLine()
                Case CommandEnumeration.release : Return executeRelease()
            End Select

            Return True
        End Function

    End Class

End Namespace
