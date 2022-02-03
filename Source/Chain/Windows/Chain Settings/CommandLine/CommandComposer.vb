'Option Compare Text
'Option Explicit On





'Namespace AreaCommon

'    ''' <summary>
'    ''' This class contain the command arguments
'    ''' </summary>
'    Public Class CommandArguments

'        ''' <summary>
'        ''' This class contain the element of a argument
'        ''' </summary>
'        Public Class SingleArgument

'            Public Property key As String = ""
'            Public Property value As String = ""

'        End Class

'        Private Property currentParameter As SingleArgument

'        Public Property code As CommandEnumeration = CommandEnumeration.undefined
'        Public Property parameters As New Dictionary(Of String, SingleArgument)


'        ''' <summary>
'        ''' This method provide to decode a command from a string   
'        ''' </summary>
'        ''' <param name="value"></param>
'        ''' <returns></returns>
'        Public Function extractCodeFromString(ByVal value As String) As Boolean
'            Try
'                value = value.Substring(1)

'                code = CommandProcessor.getCommandCode(value)

'                Return (code <> CommandEnumeration.undefined)
'            Catch ex As Exception
'                Return False
'            End Try
'        End Function

'        ''' <summary>
'        ''' This method provide to decode a command from a string
'        ''' </summary>
'        ''' <param name="value"></param>
'        ''' <returns></returns>
'        Public Function addNewParameter(ByVal value As String) As Boolean
'            Try
'                Dim separated() As String
'                Dim newParameter As New SingleArgument

'                currentParameter = newParameter

'                value = value.Substring(2)

'                separated = value.Split(":")

'                newParameter.key = separated(0)

'                If parameters.ContainsKey(newParameter.key) Then
'                    Return False
'                End If

'                If (separated.Count > 0) Then
'                    If (newParameter.key.Length + 1 < value.Length) Then
'                        newParameter.value = value.Substring(newParameter.key.Length + 1)
'                    End If
'                End If

'                parameters.Add(newParameter.key, newParameter)

'                Return True
'            Catch ex As Exception
'                Return False
'            End Try
'        End Function

'        ''' <summary>
'        ''' This method provide to add a string to last argument
'        ''' </summary>
'        ''' <param name="value"></param>
'        ''' <returns></returns>
'        Public Function addToLastParameter(ByVal value As String) As Boolean
'            Try
'                If IsNothing(currentParameter) Then
'                    Dim newParameter As New SingleArgument

'                    newParameter.key = "(without key)"
'                    newParameter.value = value

'                    parameters.Add(newParameter.key, newParameter)
'                Else
'                    currentParameter.value += " " & value
'                End If

'                Return True
'            Catch ex As Exception
'                Return False
'            End Try
'        End Function

'        ''' <summary>
'        ''' This method provide to check if exist the pause parameter 
'        ''' </summary>
'        ''' <returns></returns>
'        Public Function haveParameter(ByVal value As String) As Boolean
'            Try
'                Return parameters.ContainsKey(value)
'            Catch ex As Exception
'                Return False
'            End Try
'        End Function

'        ''' <summary>
'        ''' This method get a parameter value
'        ''' </summary>
'        ''' <param name="key"></param>
'        ''' <returns></returns>
'        Public Function parameterValue(ByVal key As String) As String
'            Try
'                If parameters.ContainsKey(key) Then
'                    Return parameters(key).value
'                Else
'                    Return ""
'                End If
'            Catch ex As Exception
'                Return ""
'            End Try
'        End Function

'    End Class

'    ''' <summary>
'    ''' This class contain all method to composer a command 
'    ''' </summary>
'    Public Class CommandComposer

'        ''' <summary>
'        ''' This method provide to exam if is command or not
'        ''' </summary>
'        ''' <param name="value"></param>
'        ''' <returns></returns>
'        Private Function isCommand(ByVal value As String) As Boolean
'            If value.StartsWith("-") And Not value.StartsWith("--") Then
'                Return (value.Length > 1)
'            Else
'                Return False
'            End If
'        End Function

'        ''' <summary>
'        ''' This method provide to exam if is parameter or not
'        ''' </summary>
'        ''' <param name="value"></param>
'        ''' <returns></returns>
'        Private Function isParameter(ByVal value As String) As Boolean
'            If value.StartsWith("--") Then
'                Return (value.Length > 2)
'            Else
'                Return False
'            End If
'        End Function


'        ''' <summary>
'        ''' This method provide to build a command list with arguments
'        ''' </summary>
'        ''' <param name="elements"></param>
'        ''' <returns></returns>
'        Public Function run(ByRef elements As List(Of String)) As CommandArguments
'            Dim result As New CommandArguments
'            Try
'                For Each item In elements
'                    If isCommand(item) Then
'                        If (result.code <> CommandEnumeration.undefined) Then
'                            Return New CommandArguments
'                        Else
'                            If Not result.extractCodeFromString(item) Then
'                                Return New CommandArguments
'                            End If
'                        End If
'                    Else
'                        If isParameter(item) Then
'                            result.addNewParameter(item)
'                        Else
'                            result.addToLastParameter(item)
'                        End If
'                    End If
'                Next

'                If (result.code = CommandEnumeration.undefined) And (elements.Count > 0) Then
'                    Return New CommandArguments
'                End If
'            Catch ex As Exception
'                Return New CommandArguments
'            End Try

'            Return result
'        End Function

'    End Class

'End Namespace
