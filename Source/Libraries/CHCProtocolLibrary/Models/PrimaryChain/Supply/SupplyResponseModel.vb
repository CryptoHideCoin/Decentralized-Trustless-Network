Option Compare Text
Option Explicit On

' ****************************************
' File: Supply Response Model
' Release Engine: 1.0 
' 
' Date last successfully test: 04/01/2022
' ****************************************


Imports CHCCommonLibrary.AreaCommon.Models
Imports CHCCommonLibrary.AreaEngine.Encryption



Namespace AreaCommon.Models.Supply.Response

    ''' <summary>
    ''' This class contain 
    ''' </summary>
    Public Class SupplyResponseModel

        Inherits General.RemoteResponse

        Public Property value As New SupplyInformationModel

        ''' <summary>
        ''' This method provide to create a string summary of the member of a class
        ''' </summary>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Public Overrides Function toString() As String
            Dim tmp As String = value.toString()

            With MyBase.integrityTransactionChain
                tmp += .coordinate
                tmp += .hash
                tmp += .progressiveHash
                tmp += .registrationTimeStamp.ToString
            End With

            Return tmp
        End Function

        ''' <summary>
        ''' This method provide to get hash value from a string of a class
        ''' </summary>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Public Function getHash() As String
            Return HashSHA.generateSHA256(Me.toString())
        End Function

    End Class

End Namespace