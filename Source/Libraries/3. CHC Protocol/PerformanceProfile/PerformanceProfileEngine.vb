Option Compare Text
Option Explicit On

' ****************************************
' Engine: Performance Profile Engine
' Release Engine: 1.0 
' 
' Date last successfully test: 11/05/2022
' ****************************************

Imports CHCCommonLibrary.AreaEngine.DataFileManagement.XML
Imports CHCModelsLibrary.AreaModel.PerformanceProfile





Namespace AreaEngine.PerformanceProfile.Internal

    ''' <summary>
    ''' This class contain all element of manage Stack data
    ''' </summary>
    Public Class StackInformationEngine

        Public Property ownerStacks As New List(Of StackInformations)

        ''' <summary>
        ''' This method provide to add a method into stack and return a parent
        ''' </summary>
        ''' <param name="ownerId"></param>
        ''' <param name="methodName"></param>
        ''' <param name="startAt"></param>
        ''' <returns></returns>
        Public Function addMethod(ByVal ownerId As String, ByVal methodName As String, ByVal startAt As Double) As String
            Try
                Dim ownerStack As StackInformations
                Dim parent As String

                For Each item In ownerStacks
                    If (item.ownerId.ToLower().CompareTo(ownerId.ToLower()) = 0) Then
                        ownerStack = item

                        Exit For
                    End If
                Next

#Disable Warning BC42104
                If IsNothing(ownerStack) Then
#Enable Warning BC42104
                    ownerStack = New StackInformations

                    ownerStack.ownerId = ownerId

                    ownerStacks.Add(ownerStack)
                End If

                If (ownerStack.callStacks.Count = 0) Then
                    parent = ""
                Else
                    parent = ownerStack.callStacks.Last.name
                End If

                ownerStack.callStacks.Add(New MethodStackInformation With {.name = methodName, .startAt = startAt})

                Return parent
            Catch ex As Exception
                Return ""
            End Try
        End Function

        ''' <summary>
        ''' This method provide to remove an element to the stack if it is correct
        ''' </summary>
        ''' <param name="ownerId"></param>
        ''' <param name="methodName"></param>
        ''' <returns></returns>
        Public Function remove(ByVal ownerId As String, ByVal methodName As String, ByVal completeAt As Double) As Double
            Try
                Dim ownerStack As StackInformations
                Dim data As MethodStackInformation

                For Each item In ownerStacks
                    If (item.ownerId.ToLower.CompareTo(ownerId.ToLower()) = 0) Then
                        ownerStack = item

                        Exit For
                    End If
                Next

#Disable Warning BC42104
                If IsNothing(ownerStack) Then
#Enable Warning BC42104
                    Return -1
                End If

                If (ownerStack.callStacks.Count = 0) Then
                    Return -1
                Else
                    If (ownerStack.callStacks.Last.name.ToLower().CompareTo(methodName.ToLower) = 0) Then
                        data = ownerStack.callStacks.Last

                        ownerStack.callStacks.Remove(data)

                        If (ownerStacks.Count = 0) Then
                            ownerStacks.Remove(ownerStack)
                        End If

                        Return CDbl(completeAt) - data.startAt
                    End If
                End If

                Return 0
            Catch ex As Exception
                Return -1
            End Try
        End Function

    End Class

    ''' <summary>
    ''' This class contain all element method information engine
    ''' </summary>
    Public Class MethodListInformationsEngine

        Private Property _Index As New Dictionary(Of String, MethodInformations)

        Public Property data As New MethodListInformations
        Public Property stackEngine As New StackInformationEngine



        ''' <summary>
        ''' This method provide to add a new child method
        ''' </summary>
        ''' <param name="name"></param>
        ''' <param name="value"></param>
        ''' <returns></returns>
        Public Function addUseMethod(ByVal name As String, ByRef value As MethodInformations) As Boolean
            For Each singleCall In value.uses
                If (singleCall.ToLower().CompareTo(name.ToLower()) = 0) Then
                    Return True
                End If
            Next

            value.uses.Add(name)

            Return True
        End Function

        ''' <summary>
        ''' This method provide to add a new parent method
        ''' </summary>
        ''' <param name="name"></param>
        ''' <param name="value"></param>
        ''' <returns></returns>
        Public Function addUsedInMethod(ByVal name As String, ByRef value As MethodInformations) As Boolean
            For Each singleCall In value.usedFrom
                If (singleCall.ToLower().CompareTo(name.ToLower()) = 0) Then
                    Return True
                End If
            Next

            value.usedFrom.Add(name)

            Return True
        End Function

        ''' <summary>
        ''' This method provide to manage enter to method procedure
        ''' </summary>
        ''' <param name="startAt"></param>
        ''' <param name="name"></param>
        ''' <returns></returns>
        Public Function enterIntoMethod(ByVal ownerId As String, ByVal item As CHCModelsLibrary.AreaModel.Log.LogListModel.SingleLogBlockModel) As Boolean
            Try
                Dim methodData As MethodInformations
                Dim parent As String = ""

                If _Index.ContainsKey(item.name) Then
                    methodData = _Index(item.name)
                Else
                    methodData = New MethodInformations

                    methodData.name = item.name

                    data.methods.Add(methodData)
                    _Index.Add(item.name, methodData)
                End If

                methodData.usedCount += 1

                parent = stackEngine.addMethod(ownerId, item.name, item.startAt)

                If (parent.Length > 0) Then
                    addUsedInMethod(parent, methodData)

                    If _Index.ContainsKey(parent) Then
                        addUseMethod(methodData.name, _Index(parent))
                    End If
                End If

                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to manage exit to method procedure
        ''' </summary>
        ''' <param name="startAt"></param>
        ''' <param name="name"></param>
        ''' <returns></returns>
        Public Function exitFromMethod(ByVal ownerId As String, ByVal name As String, ByVal completeAt As Double) As Boolean
            Try
                Dim during As Double = stackEngine.remove(ownerId, name, completeAt)

                If (during <> -1) Then
                    Dim methodData As MethodInformations
                    Dim durate As Double

                    If _Index.ContainsKey(name) Then
                        methodData = _Index(name)

                        If (methodData.refDuring = 0) Then
                            methodData.refDuring = during
                            methodData.maxDuring = during
                            methodData.minDuring = during
                        Else
                            If (durate > methodData.maxDuring) Then
                                methodData.maxDuring = durate
                            End If
                            If (durate < methodData.minDuring) Then
                                methodData.minDuring = durate
                            End If
                        End If

                        Return True
                    Else
                        Return False
                    End If
                Else
                    Return False

                End If
            Catch ex As Exception
                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to track a new marker
        ''' </summary>
        ''' <param name="name"></param>
        ''' <param name="startAt"></param>
        ''' <returns></returns>
        Public Function trackMarker(ByVal name As String, ByVal startAt As Double) As Boolean
            Try
                Dim marker As MarkersInformations

                If (data.markers.Count > 0) Then
                    marker = data.markers.Last

                    marker.durate = CDbl(startAt) - marker.startAt
                End If

                marker = New MarkersInformations

                marker.name = name
                marker.startAt = startAt

                data.markers.Add(marker)

                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to rebuild the index of a method list
        ''' </summary>
        ''' <returns></returns>
        Private Function rebuildIndex() As Boolean
            Try
                For Each item In data.methods
                    _Index.Add(item.name, item)
                Next

                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function read(ByVal completeFileName As String) As Boolean
            data = IOFast(Of MethodListInformations).read(completeFileName)

            If rebuildIndex() Then
                stackEngine.ownerStacks = data.ownerStacks

                Return True
            End If

            Return False
        End Function

    End Class

End Namespace
