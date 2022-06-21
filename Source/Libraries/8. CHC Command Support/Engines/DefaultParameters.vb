Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.DataFileManagement.Json
Imports CHCCommonLibrary.AreaEngine.Parameters



Namespace AreaEngine

    ''' <summary>
    ''' This static class provide to manage an Parameters list
    ''' </summary>
    Public Class ParametersEngine

        ''' <summary>
        ''' This method provide to create and ad a new parameter into the parameter's list
        ''' </summary>
        ''' <param name="name"></param>
        ''' <param name="value"></param>
        ''' <returns></returns>
        Public Shared Function createNew(ByVal name As String, ByVal value As String) As Boolean
            Try
                Dim collection As ParameterCollection = IOFast(Of ParameterCollection).read(ApplicationCommon.defaultParameters.completeArchiveFileName)
                Dim proceed As Boolean = True

                If proceed Then
                    proceed = collection.removeItem(name)
                End If
                If proceed Then
                    proceed = collection.addNew(name, value)
                End If
                If proceed Then
                    proceed = IOFast(Of ParameterCollection).save(ApplicationCommon.defaultParameters.completeArchiveFileName, collection)
                End If

                Return proceed
            Catch ex As Exception
                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to remove item from a collection
        ''' </summary>
        ''' <param name="parameterFilePath"></param>
        ''' <param name="name"></param>
        ''' <returns></returns>
        Public Shared Function removeItem(ByVal parameterFilePath As String, ByVal name As String) As Boolean
            Try
                Dim collection = IOFast(Of ParameterCollection).read(parameterFilePath)

                collection.removeItem(name)

                Return IOFast(Of ParameterCollection).save(parameterFilePath, collection)
            Catch ex As Exception
                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to initialize the parameter's engine
        ''' </summary>
        ''' <returns></returns>
        Public Shared Function init() As Boolean
            Try
                Dim path As String = EnvironmentRepositoryEngine.searchUserEnvironmentPath()
                Dim environmentRepositoryPath As String = IO.Path.Combine(path, "Environment.path")

                If IO.File.Exists(environmentRepositoryPath) Then
                    Dim environmentPath As String = IO.File.ReadAllText(environmentRepositoryPath)
                    Dim parameterCompleteFile As String = IO.Path.Combine(environmentPath, "Parameters.default")

                    If IO.File.Exists(parameterCompleteFile) Then
                        ApplicationCommon.defaultParameters = IOFast(Of ParameterCollection).read(parameterCompleteFile)
                    End If

                    ApplicationCommon.defaultParameters.completeArchiveFileName = parameterCompleteFile

                    Return True
                End If
            Catch ex As Exception
                Console.WriteLine("Error: problem during init ParametersEngine")
            End Try

            Return False
        End Function

    End Class

End Namespace
