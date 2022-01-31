Option Compare Text
Option Explicit On





Namespace AreaCommon

    ''' <summary>
    ''' This enumeration contain the command managed of this application
    ''' </summary>
    Public Enum CommandEnumeration
        missing
        undefined
        force
    End Enum

    ''' <summary>
    ''' This class contain the information of a command line
    ''' </summary>
    Public Class CommandLineResponse

        Public Property haveParameter As Boolean = False
        Public Property serviceChain As String = ""
        Public Property dataPath As String = ""
        Public Property password As String = ""

    End Class

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
            If (key.Trim.Length = 0) Then
                Return CommandEnumeration.missing
            End If
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
                Case CommandEnumeration.missing : response = False
                Case CommandEnumeration.undefined : response = False
                Case CommandEnumeration.force : response = True
            End Select

            Return response
        End Function

    End Class

End Namespace
