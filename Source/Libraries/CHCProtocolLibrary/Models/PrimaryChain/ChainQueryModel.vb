Option Explicit On
Option Compare Text

' ****************************************
' File: Chain Query Model
' Release Engine: 1.0 
' 
' Date last successfully test: 07/11/2021
' ****************************************


Imports CHCCommonLibrary.AreaEngine.Encryption
Imports CHCCommonLibrary.AreaEngine.Base.CHCStringExtensions
Imports CHCCommonLibrary.AreaCommon.Models





Namespace AreaCommon.Models.Chain.Queries

    ''' <summary>
    ''' This class contain the chain count information
    ''' </summary>
    Public Class ChainCountModel

        Inherits General.RemoteResponse

        Public Property value As Integer = 0

        ''' <summary>
        ''' This method provide to create a string summary of the member of a class
        ''' </summary>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Public Overrides Function toString() As String
            Dim tmp As String = value.ToString()

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

    ''' <summary>
    ''' This class contain the chain data information
    ''' </summary>
    Public Class ChainDataModel

        Inherits General.RemoteResponse

        Public Property information As New ChainMinimalData

        ''' <summary>
        ''' This method provide to create a string summary of the member of a class
        ''' </summary>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Public Overrides Function toString() As String
            Dim tmp As String = information.toString()

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

    ''' <summary>
    ''' This class contain the chain data last block
    ''' </summary>
    Public Class ChainDataLastBlockModel

        Inherits General.RemoteResponse

        ''' <summary>
        ''' This method provide to create a string summary of the member of a class
        ''' </summary>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Public Overrides Function toString() As String
            Dim tmp As String = ""

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

    ''' <summary>
    ''' This class contain the element of data page model
    ''' </summary>
    Public Class ChainDataPageModel

        Public Property pageNumber As Integer = 0
        Public Property pageDataList As New List(Of ChainMinimalData)

        ''' <summary>
        ''' This method provide to create a string summary of the member of a class
        ''' </summary>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Public Overrides Function toString() As String
            Dim tmp As String = ""

            tmp += pageNumber.ToString()

            For Each item In pageDataList
                tmp += item.toString()
            Next

            Return tmp
        End Function

    End Class

    ''' <summary>
    ''' This class contain the element of list data page
    ''' </summary>
    Public Class ChainListDataPageModel

        Inherits General.RemoteResponse

        Public Property value As New ChainDataPageModel


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

    ''' <summary>
    ''' This class contain the element of parameter of a chain
    ''' </summary>
    Public Class ChainParameterDataModel

        Inherits General.RemoteResponse

        Public Property value As New ChainParameterModel


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

    ''' <summary>
    ''' This class contain the element of a protocol set
    ''' </summary>
    Public Class SingleSetProtocol

        Public Property data As New ProtocolMinimalData
        Public Property integrity As New General.IdentifyLastTransaction

        ''' <summary>
        ''' This method provide to create a string summary of the member of a class
        ''' </summary>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Public Overrides Function toString() As String
            Dim tmp As String = ""

            tmp += data.toString()

            With integrity
                tmp += .coordinate
                tmp += .hash
                tmp += .progressiveHash
                tmp += .registrationTimeStamp.ToString
            End With

            Return tmp
        End Function

    End Class

    ''' <summary>
    ''' This class contain the element of protocol data of a chain
    ''' </summary>
    Public Class ChainProtocolDataModel

        Inherits General.RemoteResponse

        Public Property value As New List(Of SingleSetProtocol)


        ''' <summary>
        ''' This method provide to create a string summary of the member of a class
        ''' </summary>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Public Overrides Function toString() As String
            Dim tmp As String = ""

            For Each item In value
                tmp += item.toString()
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
    ''' This class contain the element of a price list of a chain
    ''' </summary>
    Public Class ChainPriceListDataModel

        Inherits General.RemoteResponse

        Public Property value As New Network.ItemPriceTableListModel


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

    ''' <summary>
    ''' This class contain the element of a Policy Privacy of a chain
    ''' </summary>
    Public Class ChainPrivacyPolicyModel

        Inherits General.RemoteResponse

        Public Property value As New Document.DocumentModel


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

    ''' <summary>
    ''' This class contain the element of a Terms and Conditions of a chain
    ''' </summary>
    Public Class ChainTermsAndConditionsModel

        Inherits General.RemoteResponse

        Public Property value As New Document.DocumentModel


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

    ''' <summary>
    ''' This class contain the element of an Active Chain
    ''' </summary>
    Public Class ChainActiveModel

        Inherits General.RemoteResponse

        Public Property value As Boolean = False


        ''' <summary>
        ''' This method provide to create a string summary of the member of a class
        ''' </summary>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Public Overrides Function toString() As String
            Dim tmp As String = ""

            If value Then
                tmp += "1"
            Else
                tmp += "0"
            End If
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

