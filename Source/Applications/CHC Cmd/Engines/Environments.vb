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
        Public Property active As Boolean = False

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
        ''' This method provide to set a current a single environment
        ''' </summary>
        ''' <param name="name"></param>
        ''' <returns></returns>
        Public Function setCurrent(ByVal name As String) As Boolean
            Try
                name = name.ToLower()

                For Each item In data
                    If (item.name.ToLower.CompareTo(name) = 0) Then
                        item.active = True

                        Return True
                    End If
                Next
            Catch ex As Exception
            End Try

            Return False
        End Function

        ''' <summary>
        ''' This method provide to get a current environment
        ''' </summary>
        ''' <returns></returns>
        Public Function getCurrent() As String
            Try
                For Each item In data
                    If item.active Then
                        Return item.name
                    End If
                Next
            Catch ex As Exception
            End Try

            Return ""
        End Function

        ''' <summary>
        ''' This method provide to get a current environment path
        ''' </summary>
        ''' <returns></returns>
        Public Function getCurrentPath() As String
            Try
                For Each item In data
                    If item.active Then
                        Return item.path
                    End If
                Next
            Catch ex As Exception
            End Try

            Return ""
        End Function

        ''' <summary>
        ''' This method provide to add a new item into collection
        ''' </summary>
        ''' <param name="name"></param>
        ''' <param name="path"></param>
        ''' <returns></returns>
        Public Function addNew(ByVal name As String, ByVal path As String, ByVal active As Boolean) As Boolean
            Dim newItem As New EnvironmentData

            newItem.name = name
            newItem.path = path
            newItem.active = True

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
        Public Shared Function createNew(ByVal environmentFilePath As String, ByVal name As String, ByVal path As String, ByVal active As Boolean) As Boolean
            Try
                Dim collection = IOFast(Of EnvironmentCollection).read(environmentFilePath)
                Dim proceed As Boolean = True

                If proceed Then
                    proceed = collection.removeItem(name)
                End If
                If proceed Then
                    proceed = collection.addNew(name, path, active)
                End If
                If proceed Then
                    proceed = IOFast(Of EnvironmentCollection).save(environmentFilePath, collection)
                End If

                Return proceed
            Catch ex As Exception
                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to get a list of EnvironmentData
        ''' </summary>
        ''' <param name="environmentFilePath"></param>
        ''' <returns></returns>
        Public Shared Function getList(ByVal environmentFilePath As String) As List(Of EnvironmentData)
            Try
                Return IOFast(Of EnvironmentCollection).read(environmentFilePath).data
            Catch ex As Exception
                Return New List(Of EnvironmentData)
            End Try
        End Function

        ''' <summary>
        ''' This method provide to remove item from a collection
        ''' </summary>
        ''' <param name="environmentFilePath"></param>
        ''' <param name="name"></param>
        ''' <returns></returns>
        Public Shared Function removeItem(ByVal environmentFilePath As String, ByVal name As String) As Boolean
            Try
                Dim collection = IOFast(Of EnvironmentCollection).read(environmentFilePath)

                collection.removeItem(name)

                Return IOFast(Of EnvironmentCollection).save(environmentFilePath, collection)
            Catch ex As Exception
                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to set the current environment
        ''' </summary>
        ''' <param name="environmentFilePath"></param>
        ''' <param name="path"></param>
        ''' <returns></returns>
        Public Shared Function setCurrent(ByVal environmentFilePath As String, ByVal name As String) As Boolean
            Try
                Dim collection = IOFast(Of EnvironmentCollection).read(environmentFilePath)

                collection.setCurrent(name)

                Return IOFast(Of EnvironmentCollection).save(environmentFilePath, collection)
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Shared Function getCurrent(ByVal environmentFilePath As String) As String
            Try
                Dim collection = IOFast(Of EnvironmentCollection).read(environmentFilePath)

                Return collection.getCurrent()
            Catch ex As Exception
                Return ""
            End Try
        End Function

        Public Shared Function getCurrentPath(ByVal environmentFilePath As String) As String
            Try
                Dim collection = IOFast(Of EnvironmentCollection).read(environmentFilePath)

                Return collection.getCurrentPath()
            Catch ex As Exception
                Return ""
            End Try
        End Function

    End Class

    ''' <summary>
    ''' This class contain all element of a util repository
    ''' </summary>
    Public Class EnvironmentUtils

        ''' <summary>
        ''' This method provide to get a current environment
        ''' </summary>
        ''' <returns></returns>
        Public Shared Function getCurrentEnvironmentPath() As String
            Try
                Dim path As String = AreaEngine.EnvironmentRepositoryEngine.searchUserEnvironmentPath()
                Dim environmentRepositoryPath As String = IO.Path.Combine(path, "Environment.path")
                Dim environmentPath As String = ""

                If IO.File.Exists(environmentRepositoryPath) Then
                    environmentPath = IO.File.ReadAllText(environmentRepositoryPath)

                    environmentPath = IO.Path.Combine(environmentPath, "Environments.list")

                    Return AreaEngine.EnvironmentsEngine.getCurrentPath(environmentPath)
                End If
            Catch ex As Exception
            End Try

            Return ""
        End Function

    End Class

End Namespace
