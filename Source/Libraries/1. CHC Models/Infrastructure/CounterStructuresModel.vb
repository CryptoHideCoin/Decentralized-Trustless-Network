Option Compare Text
Option Explicit On

' ****************************************
' Engine: Counter Model
' Release Engine: 1.0 
' 
' Date last successfully test: 28/05/2022
' ****************************************

Imports CHCModelsLibrary.AreaModel.Network.Response



Namespace AreaModel.Counter

    ''' <summary>
    ''' This class contain a configuration of a Counter Rotate
    ''' </summary>
    Public Class CounterRotateConfig

        Public keepLast As Log.KeepEnum = Log.KeepEnum.lastWeek

    End Class

    ''' <summary>
    ''' This class contain all component of a Query Counter
    ''' </summary>
    Public Class QueryCounterFilter

        Public Enum CounterComponentEnumeration
            both
            onlyAPI
            onlyOther
        End Enum

        Public Property fromTimestamp As Double = 0
        Public Property toTimeStamp As Double = 0

        Public Property components As CounterComponentEnumeration = CounterComponentEnumeration.both

    End Class

    ''' <summary>
    ''' This class collect value data total
    ''' </summary>
    Public Class QuerySingleTotal

        Public Property onlyAPI As Integer = 0
        Public Property onlyOther As Integer = 0

        Public ReadOnly Property total As Integer
            Get
                Return onlyAPI + onlyOther
            End Get
        End Property

    End Class

    ''' <summary>
    ''' This class collect value data total
    ''' </summary>
    Public Class QuerySingleElement

        Public Property name As String = ""
        Public Property isAPI As Boolean = False
        Public Property total As Integer = 0

    End Class

    ''' <summary>
    ''' This class contain the timestamp element slot
    ''' </summary>
    Public Class QueryDetailData

        Public Property timestamp As Double = 0
        Public Property elements As New List(Of QuerySingleElement)

    End Class

    ''' <summary>
    ''' This class contain a slot detail data
    ''' </summary>
    Public Class SlotDetailValue

        Public Property timestamp As Double = 0
        Public Property value As New QuerySingleTotal

    End Class

    ''' <summary>
    ''' This class contain all information count of a result of query counter
    ''' </summary>
    Public Class QueryCounterResponseModel

        Inherits BaseRemoteResponse

        Public Property filter As New QueryCounterFilter
        Public Property totals As New QuerySingleTotal
        Public Property timeSlots As New List(Of SlotDetailValue)

    End Class

    ''' <summary>
    ''' This class contain all information count of a result of query counter data
    ''' </summary>
    Public Class QueryDataResponseModel

        Inherits BaseRemoteResponse

        Public Property filter As New QueryCounterFilter
        Public Property totals As New QuerySingleTotal
        Public Property timeSlot As New List(Of QueryDetailData)

    End Class

End Namespace
