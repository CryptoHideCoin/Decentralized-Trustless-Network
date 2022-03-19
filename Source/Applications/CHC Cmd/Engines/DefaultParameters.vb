Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.DataFileManagement.Json



Namespace AreaEngine

    ''' <summary>
    ''' This class contain the information of a parameter
    ''' </summary>
    Public Class ParameterData

        Public Property name As String = ""
        Public Property value As String = ""

    End Class

    ''' <summary>
    ''' This class provide to manage an collection of parameter
    ''' </summary>
    Public Class ParameterCollection

        Friend Property completeArchiveFileName As String = ""

        Public Property data As New List(Of ParameterData)


        ''' <summary>
        ''' This method provide to remove an element named "name" to the collection
        ''' </summary>
        ''' <param name="name"></param>
        ''' <returns></returns>
        Public Function removeItem(ByVal name As String) As Boolean
            Try
                Dim itemToDelete As ParameterData

                name = name.ToLower()

                For Each item In data
                    If (item.name.ToLower.CompareTo(name) = 0) Then
                        itemToDelete = item

                        Exit For
                    End If
                Next

#Disable Warning BC42104
                If Not IsNothing(itemToDelete) Then
#Enable Warning BC42104
                    data.Remove(itemToDelete)
                End If

                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to add a new item into collection
        ''' </summary>
        ''' <param name="name"></param>
        ''' <param name="path"></param>
        ''' <returns></returns>
        Public Function addNew(ByVal name As String, ByVal value As String) As Boolean
            Dim newItem As New ParameterData

            newItem.name = name
            newItem.value = value

            data.Add(newItem)

            Return True
        End Function

        ''' <summary>
        ''' This method provide to get a parameter to the collection
        ''' </summary>
        ''' <param name="name"></param>
        ''' <returns></returns>
        Public Function getParameter(ByVal name As String) As String
            name = name.ToLower()

            For Each item In data
                If (item.name.ToLower.CompareTo(name) = 0) Then
                    Return item.value
                End If
            Next

            Return ""
        End Function

    End Class

    ''' <summary>
    ''' This static class provide to manage an Parameters list
    ''' </summary>
    Public Class ParametersEngine

        ''' <summary>
        ''' This method provide to create and ad a new parameter into the parameter's list
        ''' </summary>
        ''' <param name="parameterFilePath"></param>
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
