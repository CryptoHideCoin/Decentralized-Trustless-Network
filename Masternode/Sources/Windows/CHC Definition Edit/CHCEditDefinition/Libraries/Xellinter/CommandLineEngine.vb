Option Compare Text
Option Explicit On


Namespace Xellinter.Utilities


    Public Class CommandLineParameters

        Public Class CommandLineParameter

            Public Property Token As String = ""
            Public Property Value As String = ""

        End Class



        Private m_dct_Parameter As New Dictionary(Of String, CommandLineParameter)



        ''' <summary>
        ''' This method provides to add a new token into list
        ''' </summary>
        ''' <param name="CommandToken"></param>
        ''' <param name="CommandValue"></param>
        Private Sub AddNewToken(ByVal CommandToken As String, ByVal CommandValue As String)

            Dim clsSingle As CommandLineParameter

            If m_dct_Parameter.ContainsKey(CommandToken) Then

                clsSingle = m_dct_Parameter(CommandToken)

            Else

                clsSingle = New CommandLineParameter

                clsSingle.Token = CommandToken

                m_dct_Parameter.Add(CommandToken, clsSingle)

            End If

            clsSingle.Value = CommandValue

        End Sub


        ''' <summary>
        ''' This method provides to check if exist an token into command line
        ''' </summary>
        ''' <param name="CommandToken"></param>
        ''' <returns></returns>
        Public Function Exist(ByVal CommandToken As String) As Boolean

            Return m_dct_Parameter.ContainsKey(CommandToken)

        End Function


        ''' <summary>
        ''' This method provides to return a value relative a CommandToken
        ''' </summary>
        ''' <param name="CommandToken"></param>
        ''' <returns></returns>
        Public Function GetValue(ByVal CommandToken As String) As String

            If m_dct_Parameter.ContainsKey(CommandToken) Then

                Return m_dct_Parameter(CommandToken).Value

            Else

                Return ""

            End If

        End Function


        ''' <summary>
        ''' This method provides to decode a command line
        ''' </summary>
        ''' <param name="CommandLine"></param>
        Public Sub Decode(ByVal CommandLine As String())

            Dim arrValues
            Dim strToken As String, strValue As String
            Dim strSingle As String

            If (CommandLine.Count > 1) Then

                For intC As Integer = 1 To CommandLine.Count - 1

                    strSingle = CommandLine(intC).Trim()

                    If (intC = CommandLine.Count - 1) Then

                        If (strSingle.Substring(strSingle.Length - 1) = Chr(34)) Then

                            strSingle = strSingle.Substring(0, strSingle.Length - 1)

                        End If

                    End If

                    arrValues = strSingle.Split(":")

                    strToken = arrValues(0)

                    If (strSingle.Length > strToken.Length) Then

                        strValue = strSingle.Substring(strToken.Length + 1)

                    Else

                        strValue = ""

                    End If

                    AddNewToken(strToken.Substring(0).ToLower(), strValue)

                Next

            End If

        End Sub


        ''' <summary>
        ''' This method provides to build an a command line
        ''' </summary>
        ''' <param name="strCommand"></param>
        ''' <param name="strDescription"></param>
        ''' <returns></returns>
        Private Function fnComposeCommand(ByVal strCommand As String, ByVal strDescription As String) As String

            Return "/" & strCommand & Space(20 - strCommand.Length) & strDescription & vbNewLine

        End Function


    End Class


End Namespace