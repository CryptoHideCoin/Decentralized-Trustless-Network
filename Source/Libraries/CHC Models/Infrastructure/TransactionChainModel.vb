Option Compare Text
Option Explicit On

' ****************************************
' Engine: Log Model
' Release Engine: 1.0 
' 
' Date last successfully test: 21/02/2022
' ****************************************



Namespace AreaModel.Ledger

    ''' <summary>
    ''' This class provide to contain an essential data transaction
    ''' </summary>
    Public Class EssentialDataTransaction

        Public Property coordinate As String = ""
        Public Property hash As String = ""

        ''' <summary>
        ''' This static method provide to build a coordinate string
        ''' </summary>
        ''' <param name="blockChainId"></param>
        ''' <param name="volumeId"></param>
        ''' <param name="blockId"></param>
        ''' <param name="recordId"></param>
        ''' <returns></returns>
        Public Shared Function composeCoordinate(ByVal blockChainId As String, ByVal volumeId As String, ByVal blockId As String, Optional ByVal recordId As String = "") As String
            If (recordId.Length > 0) Then
                Return blockChainId & "-" & volumeId & "-" & blockId & "-" & recordId
            Else
                Return blockChainId & "-" & volumeId & "-" & blockId
            End If
        End Function

        ''' <summary>
        ''' This method provide to create a string cumulative of the important class member
        ''' </summary>
        ''' <returns></returns>
        Public Overrides Function toString() As String
            Return coordinate & hash
        End Function

    End Class

    ''' <summary>
    ''' This class contain all element identify the last transaction save into the ledger
    ''' </summary>
    Public Class IdentifyLastTransaction

        Inherits EssentialDataTransaction

        Public Property registrationTimeStamp As Double = 0
        Public Property progressiveHash As String = ""

        ''' <summary>
        ''' This method provide to create a string cumulative of the important class member
        ''' </summary>
        ''' <returns></returns>
        Public Overrides Function toString() As String
            Return MyBase.toString & progressiveHash
        End Function

        ''' <summary>
        ''' This method provide to clone all element of this object
        ''' </summary>
        ''' <returns></returns>
        Public Function clone() As IdentifyLastTransaction
            Return Me.MemberwiseClone()
        End Function

    End Class

End Namespace