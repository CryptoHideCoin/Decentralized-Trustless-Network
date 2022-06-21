Option Compare Text
Option Explicit On




Namespace AreaEngine.Parameters

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

        Public Property completeArchiveFileName As String = ""

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

End Namespace
