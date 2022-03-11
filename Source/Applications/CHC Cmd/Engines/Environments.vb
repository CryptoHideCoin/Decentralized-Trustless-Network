Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.DataFileManagement.Json



Namespace AreaEngine

    ''' <summary>
    ''' This class contain the information of an environment
    ''' </summary>
    Public Class EnvironmentData

        Public Property name As String = ""
        Public Property path As String = ""

    End Class

    ''' <summary>
    ''' This class provide to manage an collection of environment path
    ''' </summary>
    Public Class EnvironmentCollection

        Public Property data As New List(Of EnvironmentData)

        ''' <summary>
        ''' This method provide to remove an element named "name" to the collection
        ''' </summary>
        ''' <param name="name"></param>
        ''' <returns></returns>
        Public Function removeItem(ByVal name As String) As Boolean
            Try
                Dim itemToDelete As EnvironmentData

                name = name.ToLower()

                For Each item In data
                    If item.name.ToLower.CompareTo(name) Then
                        itemToDelete = item

                        Exit For
                    End If
                Next

                If Not IsNothing(itemToDelete) Then
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
        Public Function addNew(ByVal name As String, ByVal path As String) As Boolean
            Dim newItem As New EnvironmentData

            newItem.name = name
            newItem.path = path

            data.Add(newItem)

            Return True
        End Function

    End Class

    ''' <summary>
    ''' This static class provide to manage an Environments list
    ''' </summary>
    Public Class EnvironmentsEngine

        ''' <summary>
        ''' This method provide to create and ad a new environment into the environment list
        ''' </summary>
        ''' <returns></returns>
        Public Shared Function createNewEnvironment(ByVal environmentFilePath As String, ByVal name As String, ByVal path As String) As Boolean
            Try
                Dim collection = IOFast(Of EnvironmentCollection).read(environmentFilePath)
                Dim proceed As Boolean = True

                If proceed Then
                    proceed = collection.removeItem(name)
                End If
                If proceed Then
                    proceed = collection.addNew(name, path)
                End If
                If proceed Then
                    proceed = IOFast(Of EnvironmentCollection).save(environmentFilePath, collection)
                End If

                Return proceed
            Catch ex As Exception
                Return False
            End Try
        End Function

    End Class

End Namespace
