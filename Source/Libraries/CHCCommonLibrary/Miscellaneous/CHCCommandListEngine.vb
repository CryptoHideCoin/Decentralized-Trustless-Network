Option Compare Text
Option Explicit On

' ****************************************
' Engine: Commandline parameter manager
' Release Engine: 1.0 
' 
' Date last successfully test: 02/10/2021
' ****************************************






Namespace AreaEngine.Miscellaneous

    ''' <summary>
    ''' This class manage a command line parameters
    ''' </summary>
    Public Class CommandLineParameters

        ''' <summary>
        ''' This class contain a property of command line
        ''' </summary>
        Public Class CommandLineParameter

            Public Property token As String = ""
            Public Property value As String = ""

        End Class


        Private _Parameter As New Dictionary(Of String, CommandLineParameter)




        ''' <summary>
        ''' This method provides to build an a command line
        ''' </summary>
        ''' <param name="command"></param>
        ''' <param name="description"></param>
        ''' <returns></returns>
        Private Function composeCommand(ByVal command As String, ByVal description As String) As String
            Return "/" & command & Space(20 - command.Length) & description & vbNewLine
        End Function

        ''' <summary>
        ''' This method provides to add a new token into list
        ''' </summary>
        ''' <param name="CommandToken"></param>
        ''' <param name="CommandValue"></param>
        Private Sub addNewToken(ByVal commandToken As String, ByVal commandValue As String)
            Dim singleElement As CommandLineParameter

            If _Parameter.ContainsKey(commandToken) Then
                singleElement = _Parameter(commandToken)
            Else
                singleElement = New CommandLineParameter

                singleElement.token = commandToken

                _Parameter.Add(commandToken, singleElement)
            End If

            singleElement.value = commandValue
        End Sub


        ''' <summary>
        ''' This method provides to check if exist an token into command line
        ''' </summary>
        ''' <param name="CommandToken"></param>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Public Function exist(ByVal CommandToken As String) As Boolean
            Return _Parameter.ContainsKey(CommandToken)
        End Function

        ''' <summary>
        ''' This method provides to return a value relative a CommandToken
        ''' </summary>
        ''' <param name="CommandToken"></param>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Public Function GetValue(ByVal CommandToken As String) As String
            If _Parameter.ContainsKey(CommandToken) Then
                Return _Parameter(CommandToken).value
            Else
                Return ""
            End If
        End Function

        ''' <summary>
        ''' This method provides to decode a command line
        ''' </summary>
        ''' <param name="CommandLine"></param>
        <DebuggerHiddenAttribute()> Public Sub decode(ByVal commandLine As String())
            Dim values
            Dim token As String, value As String
            Dim singleElement As String

            If (commandLine.Count > 1) Then
                For intC As Integer = 1 To commandLine.Count - 1
                    singleElement = commandLine(intC).Trim()

                    If (intC = commandLine.Count - 1) Then
                        If (singleElement.Substring(singleElement.Length - 1) = Chr(34)) Then
                            singleElement = singleElement.Substring(0, singleElement.Length - 1)
                        End If
                    End If

                    values = singleElement.Split(":")
                    token = values(0)

                    If (singleElement.Length > token.Length) Then
                        value = singleElement.Substring(token.Length + 1)
                    Else
                        value = ""
                    End If

                    addNewToken(token.Substring(0).ToLower(), value)
                Next
            End If
        End Sub

    End Class

End Namespace