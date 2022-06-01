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

End Namespace
