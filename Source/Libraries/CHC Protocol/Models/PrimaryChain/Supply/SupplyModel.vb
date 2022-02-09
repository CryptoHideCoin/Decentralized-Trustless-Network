Option Compare Text
Option Explicit On

' ****************************************
' File: Supply Model
' Release Engine: 1.0 
' 
' Date last successfully test: 04/01/2022
' ****************************************


Imports CHCCommonLibrary.AreaEngine.Encryption



Namespace AreaCommon.Models.Supply

    ''' <summary>
    ''' This class contain all element of a Coin Supply 
    ''' </summary>
    Public Class SupplyInformationModel

        Public Property total As Decimal = 0
        Public Property locked As Decimal = 0

        Public ReadOnly Property available As Decimal
            Get
                Return total - locked
            End Get
        End Property

        Public Property lastStake As Double = 0

        ''' <summary>
        ''' This method provide to create a string summary of the member of a class
        ''' </summary>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Public Overrides Function toString() As String
            Dim tmp As String = ""

            tmp += total.ToString()
            tmp += locked.ToString()
            tmp += lastStake.ToString()

            Return tmp
        End Function

        ''' <summary>
        ''' This method provide to get hash value from a string of a class
        ''' </summary>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Public Overridable Function getHash() As String
            Return HashSHA.generateSHA256(Me.toString())
        End Function

    End Class

End Namespace