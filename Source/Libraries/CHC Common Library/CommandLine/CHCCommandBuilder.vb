Option Compare Text
Option Explicit On

' ****************************************
' Engine: Commandline Engine
' Release Engine: 1.0 
' 
' Date last successfully test: 02/02/2022
' ****************************************






Namespace AreaEngine.CommandLine

    ''' <summary>
    ''' This class contain the contain structure of a commandline (command, arguments)
    ''' </summary>
    Public Class CommandStructure

        ''' <summary>
        ''' This class contain the element of a argument
        ''' </summary>
        Public Class SingleArgument
            Public Property key As String = ""
            Public Property value As String = ""
        End Class

        Private Property _CurrentParameter As SingleArgument

        Public Property code As String = ""
        Public Property parameters As New Dictionary(Of String, SingleArgument)

        ''' <summary>
        ''' This method provide to decode a command from a string
        ''' </summary>
        ''' <param name="value"></param>
        ''' <returns></returns>
        Public Function addNewParameter(ByVal value As String) As Boolean
            Try
                Dim separated() As String
                Dim newParameter As New SingleArgument

                _CurrentParameter = newParameter
                value = value.Substring(2)
                separated = value.Split(":")
                newParameter.key = separated(0)

                If parameters.ContainsKey(newParameter.key) Then
                    Return False
                End If

                If (separated.Count > 0) Then
                    If (newParameter.key.Length + 1 < value.Length) Then
                        newParameter.value = value.Substring(newParameter.key.Length + 1)
                    End If
                End If

                parameters.Add(newParameter.key, newParameter)

                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to add a string to last argument
        ''' </summary>
        ''' <param name="value"></param>
        ''' <returns></returns>
        Public Function addToLastParameter(ByVal value As String) As Boolean
            Try
                If IsNothing(_CurrentParameter) Then
                    Dim newParameter As New SingleArgument

                    newParameter.key = "(without key)"
                    newParameter.value = value

                    parameters.Add(newParameter.key, newParameter)
                Else
                    _CurrentParameter.value += " " & value
                End If

                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to check if exist the pause parameter 
        ''' </summary>
        ''' <returns></returns>
        Public Function haveParameter(ByVal name As String) As Boolean
            Try
                Return parameters.ContainsKey(name)
            Catch ex As Exception
                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method get a parameter value
        ''' </summary>
        ''' <param name="key"></param>
        ''' <returns></returns>
        Public Function parameterValue(ByVal key As String) As String
            Try
                If parameters.ContainsKey(key) Then
                    Return parameters(key).value
                Else
                    Return ""
                End If
            Catch ex As Exception
                Return ""
            End Try
        End Function

    End Class

    ''' <summary>
    ''' This class contain all method to decode a command line
    ''' </summary>
    Public Class CommandBuilder

        Public Property lastErrorDescription As String = ""

        ''' <summary>
        ''' This method provide to exam if is command or not
        ''' </summary>
        ''' <param name="value"></param>
        ''' <returns></returns>
        Private Function isCommand(ByVal value As String) As Boolean
            If value.StartsWith("-") And Not value.StartsWith("--") Then
                Return (value.Length > 1)
            Else
                Return False
            End If
        End Function

        ''' <summary>
        ''' This method provide to exam if is parameter or not
        ''' </summary>
        ''' <param name="value"></param>
        ''' <returns></returns>
        Private Function isParameter(ByVal value As String) As Boolean
            If value.StartsWith("--") Then
                Return (value.Length > 2)
            Else
                Return False
            End If
        End Function


        ''' <summary>
        ''' This method provide to run a split of a Commandline
        ''' </summary>
        ''' <param name="commandLine"></param>
        <DebuggerHiddenAttribute()> Public Function run() As CommandStructure
            Dim result As New CommandStructure
            Try
                For Each item In Environment.GetCommandLineArgs
                    If (item = IO.Path.Combine(My.Application.Info.DirectoryPath, My.Application.Info.AssemblyName & ".exe")) Or
                       (item = My.Application.Info.AssemblyName & ".exe") Or
                       (item = My.Application.Info.AssemblyName) Then
                        Continue For
                    Else
                        If isCommand(item) Then
                            If (result.code.Length > 0) Then
                                lastErrorDescription = "To more command"

                                Return New CommandStructure
                            Else
                                result.code = item.Substring(1).ToLower()
                            End If
                        Else
                            If isParameter(item) Then
                                result.addNewParameter(item)
                            Else
                                result.addToLastParameter(item)
                            End If
                        End If
                    End If
                Next
            Catch ex As Exception
                lastErrorDescription = ex.Message
            End Try

            Return result
        End Function

    End Class

End Namespace