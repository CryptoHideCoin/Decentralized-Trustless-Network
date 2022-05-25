Option Compare Text
Option Explicit On

' ****************************************
' Engine: Performance Profile Model
' Release Engine: 1.0 
' 
' Date last successfully test: 14/05/2022
' ****************************************

Imports CHCModelsLibrary.AreaModel.Network.Response



Namespace AreaModel.PerformanceProfile

    ''' <summary>
    ''' This class contain all collect all information of a Method execution
    ''' </summary>
    Public Class MethodInformations

        Public Property name As String = ""

        Public Property refDuring As Double = 0
        Public Property minDuring As Double = 0
        Public Property maxDuring As Double = 0

        Public Property usedCount As Integer = 0

        Public Property usedFrom As New List(Of String)
        Public Property uses As New List(Of String)

    End Class

    ''' <summary>
    ''' This class contain the information relative a method into stack owner
    ''' </summary>
    Public Class MethodStackInformation

        Public Property name As String = ""
        Public Property startAt As Double = 0

    End Class

    ''' <summary>
    ''' This class contain the information relative of a the stack of the owner
    ''' </summary>
    Public Class StackInformations

        Public Property ownerId As String = ""
        Public Property callStacks As New List(Of MethodStackInformation)

    End Class

    ''' <summary>
    ''' This class contain all element of marker information
    ''' </summary>
    Public Class MarkersInformations

        Public Property name As String = ""
        Public Property startAt As Double = 0
        Public Property durate As Double = 0

    End Class

    ''' <summary>
    ''' This class is a list of Method list informations
    ''' </summary>
    Public Class MethodListInformations

        Public Property lastFileUsed As String = ""
        Public Property lastPosition As Double = 0

        Public Property methods As New List(Of MethodInformations)
        Public Property markers As New List(Of MarkersInformations)

        Public Property ownerStacks As New List(Of StackInformations)

    End Class

    ''' <summary>
    ''' This class contain the information response model of Performance Profile List
    ''' </summary>
    Public Class PerformanceProfileListResponseModel

        Inherits BaseRemoteResponse

        Public Property value As New MethodListInformations

    End Class

End Namespace
