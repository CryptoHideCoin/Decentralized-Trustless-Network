Option Compare Text
Option Explicit On

Imports CHCModelsLibrary.AreaModel.Network.Response
Imports CHCCommonLibrary.AreaEngine.Encryption




Namespace AreaCommon.Models.Ledger

    ''' <summary>
    ''' This class contain the page transaction data
    ''' </summary>
    Public Class PageTransactionsModel

        Public Property pageNumber As Integer
        Public Property transactions As New List(Of SingleTransactionLedger)

        ''' <summary>
        ''' This method provide to create a string summary of the member of a class
        ''' </summary>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Public Overrides Function toString() As String
            Dim tmp As String = pageNumber.ToString()

            For Each singleTransaction In transactions
                tmp += singleTransaction.toString()
            Next

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

    ''' <summary>
    ''' This class contain the page transaction information
    ''' </summary>
    Public Class PageTransactionResponseModel

        Inherits BaseRemoteResponse

        Public Property value As New PageTransactionsModel

        ''' <summary>
        ''' This method provide to create a string summary of the member of a class
        ''' </summary>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Public Overrides Function toString() As String
            Dim tmp As String = value.toString()

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
