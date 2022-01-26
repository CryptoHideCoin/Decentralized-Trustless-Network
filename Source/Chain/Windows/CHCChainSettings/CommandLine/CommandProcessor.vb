Option Compare Text
Option Explicit On





Namespace AreaCommon

    Public Enum CommandEnumeration
        undefined
        force
    End Enum

    Public Class CommandLineResponse

        Public Property haveParameter As Boolean = False
        Public Property chain As String = ""
        Public Property dataPath As String = ""

    End Class

        Public Class CommandProcessor

        Public command As New CommandArguments


        ''' <summary>
        ''' This method provide to decode into command enumeration
        ''' </summary>
        ''' <param name="key"></param>
        ''' <returns></returns>
        Public Shared Function getCommandCode(ByVal key As String) As CommandEnumeration
            Select Case key.Trim.ToLower()
                Case "force" : Return CommandEnumeration.force
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
                Case CommandEnumeration.force : response = True
            End Select

            Return response
        End Function

    End Class

End Namespace
