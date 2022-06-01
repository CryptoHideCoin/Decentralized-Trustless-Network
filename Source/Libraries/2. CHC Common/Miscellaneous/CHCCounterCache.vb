Option Explicit On
Option Compare Text

' ****************************************
' Engine: Counter manager
' Release Engine: 1.0 
' 
' Date last successfully test: 26/05/2022
' ****************************************

Imports CHCModelsLibrary.AreaModel.Log







Namespace Engine

    ''' <summary>
    ''' This class contain all element of API cache engine
    ''' </summary>
    Public Class CounterAPICacheEngine

        Public Event changeBlock(ByVal fromAPI As Boolean)


        ''' <summary>
        ''' This class contain the counter API structure
        ''' </summary>
        Public Class CounterCache

            Public Property name As String = ""
            Public Property access As Integer = 0

        End Class

        ''' <summary>
        ''' This class contain the main structure of Counter Block Cache
        ''' </summary>
        Public Class CounterBlockCache

            Public Property timeStart As Double = 0
            Public Property elements As New Dictionary(Of String, CounterCache)

        End Class

        Public Property currentAPIBlock As New CounterBlockCache
        Public Property currentWEBBlock As New CounterBlockCache
        Public Property previousAPIBlock As New CounterBlockCache
        Public Property previousWEBBlock As New CounterBlockCache

        Public Property timeSpan As Double = 0
        Public Property serviceActive As Boolean = False


        ''' <summary>
        ''' This method provide to add an a call API into cache structure
        ''' </summary>
        ''' <param name="name"></param>
        ''' <returns></returns>
        Public Function addNewCall(ByVal name As String, ByVal accessType As AccessTypeEnumeration) As Boolean
            Try
                Dim currentTime As Double = AreaEngine.Miscellaneous.timeStampFromDateTime()
                Dim newAPI As CounterCache
                Dim timeStartCurrentBlock As Double = 0
                Dim containsAPI As Boolean = False

                If (accessType = AccessTypeEnumeration.api) Then
                    timeStartCurrentBlock = currentAPIBlock.timeStart
                Else
                    timeStartCurrentBlock = currentWEBBlock.timeStart
                End If

                If (timeStartCurrentBlock = 0) Then
                    If (accessType = AccessTypeEnumeration.api) Then
                        currentAPIBlock.timeStart = currentTime
                    Else
                        currentWEBBlock.timeStart = currentTime
                    End If
                End If

                If (currentTime > timeStartCurrentBlock + timeSpan) Then
                    If (accessType = AccessTypeEnumeration.api) Then
                        previousAPIBlock = currentAPIBlock
                    Else
                        previousWEBBlock = currentWEBBlock
                    End If

                    If (accessType = AccessTypeEnumeration.api) Then
                        currentAPIBlock = New CounterBlockCache

                        currentAPIBlock.timeStart = currentTime
                    Else
                        currentWEBBlock = New CounterBlockCache

                        currentWEBBlock.timeStart = currentTime
                    End If

                    If ((accessType = AccessTypeEnumeration.api) And (previousAPIBlock.elements.Count > 0)) Or
                       ((accessType = AccessTypeEnumeration.web) And (previousWEBBlock.elements.Count > 0)) Then
                        RaiseEvent changeBlock((accessType = AccessTypeEnumeration.api))
                    End If
                End If

                If (accessType = AccessTypeEnumeration.api) Then
                    containsAPI = currentAPIBlock.elements.ContainsKey(name)
                Else
                    containsAPI = currentWEBBlock.elements.ContainsKey(name)
                End If

                If containsAPI Then
                    If (accessType = AccessTypeEnumeration.api) Then
                        newAPI = currentAPIBlock.elements(name)
                    Else
                        newAPI = currentWEBBlock.elements(name)
                    End If
                Else
                    newAPI = New CounterCache

                    newAPI.name = name

                    If (accessType = AccessTypeEnumeration.api) Then
                        currentAPIBlock.elements.Add(name, newAPI)
                    Else
                        currentWEBBlock.elements.Add(name, newAPI)
                    End If
                End If

                newAPI.access += 1

                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to flush a cache
        ''' </summary>
        ''' <returns></returns>
        Public Function flushCache() As Boolean
            previousAPIBlock = currentAPIBlock

            RaiseEvent changeBlock(True)

            previousWEBBlock = currentWEBBlock

            RaiseEvent changeBlock(False)

            Return True
        End Function

    End Class

End Namespace
