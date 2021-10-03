Option Compare Text
Option Explicit On

' ****************************************
' File: Network General Model
' Release Engine: 1.0 
' 
' Date last successfully test: 03/10/2021
' ****************************************


Imports CHCCommonLibrary.AreaCommon.Models
Imports CHCCommonLibrary.AreaEngine.Encryption



Namespace AreaCommon.Models.Network

    ''' <summary>
    ''' This class contain the information base of this network
    ''' </summary>
    Public Class InfoNetworkBaseModel

        Inherits General.RemoteResponse

        Public Property name As String = ""
        Public Property networkCreationDate As String = ""
        Public Property genesisPublicAddress As String = ""


        ''' <summary>
        ''' This method provide to create a string summary of the member of a class
        ''' </summary>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Public Overrides Function toString() As String
            Dim tmp As String = ""

            tmp += name
            tmp += networkCreationDate
            tmp += genesisPublicAddress
            tmp += integrityTransactionChain.recordCoordinate
            tmp += integrityTransactionChain.recordHash

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
    ''' This class is model of interrogation a single value to return in a interrogation
    ''' </summary>
    Public Class DocumentModel

        Inherits General.RemoteResponse

        Public value As String = ""

        ''' <summary>
        ''' This method provide to create a string summary of the member of a class
        ''' </summary>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Public Overrides Function toString() As String
            Dim tmp As String = ""

            tmp += value
            tmp += integrityTransactionChain.recordCoordinate
            tmp += integrityTransactionChain.recordHash

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
    ''' This class contain the info asset of during interrogation 
    ''' </summary>
    Public Class InfoAssetModel

        Inherits General.RemoteResponse

        Public Property value As AssetModel

        ''' <summary>
        ''' This method provide to create a string summary of the member of a class
        ''' </summary>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Public Overrides Function toString() As String
            Dim tmp As String = ""

            tmp += integrityTransactionChain.recordCoordinate
            tmp += integrityTransactionChain.recordHash
            tmp += value.toString()

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
    ''' This class contain the info transaction chain setting of during interrogation 
    ''' </summary>
    Public Class InfoTransactionChainSettingsModel

        Inherits General.RemoteResponse

        Public Property value As TransactionChainModel

        ''' <summary>
        ''' This method provide to create a string summary of the member of a class
        ''' </summary>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Public Overrides Function toString() As String
            Dim tmp As String = ""

            tmp += integrityTransactionChain.recordCoordinate
            tmp += integrityTransactionChain.recordHash
            tmp += value.toString()

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
    ''' This class contain the info regard Info Refund during interrogation 
    ''' </summary>
    Public Class InfoRefundPlanModel

        Inherits General.RemoteResponse

        Public Property value As RefundItemList

        ''' <summary>
        ''' This method provide to create a string summary of the member of a class
        ''' </summary>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Public Overrides Function toString() As String
            Dim tmp As String = ""

            tmp += integrityTransactionChain.recordCoordinate
            tmp += integrityTransactionChain.recordHash
            tmp += value.toString()

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
