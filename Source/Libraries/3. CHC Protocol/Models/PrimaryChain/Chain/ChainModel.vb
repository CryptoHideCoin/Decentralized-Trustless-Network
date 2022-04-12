Option Explicit On
Option Compare Text

' ****************************************
' File: Chain Model
' Release Engine: 1.0 
' 
' Date last successfully test: 07/11/2021
' ****************************************


Imports CHCCommonLibrary.AreaEngine.Encryption
Imports CHCCommonLibrary.AreaEngine.Base.CHCStringExtensions
Imports CHCModelsLibrary.AreaModel.Ledger







Namespace AreaCommon.Models.Chain

    ''' <summary>
    ''' This enumeration contain the RoleMasterNode enumeration
    ''' </summary>
    Public Enum RoleMasterNode

        undefined
        fullStack
        validator
        newsFeeder
        publisherBlockChain
        query
        arbitration

    End Enum

    ''' <summary>
    ''' This class contain the minimal element of definion of chain
    ''' </summary>
    Public Class ChainMinimalData

        Public Property name As String = ""
        Public Property privateChain As Boolean = False
        Public Property description As String = ""

        ''' <summary>
        ''' This method provide to convert into a string the element of the object
        ''' </summary>
        ''' <returns></returns>
        Public Overrides Function toString() As String
            Dim result As String = ""

            result += name
            If privateChain Then
                result += "1"
            Else
                result += "0"
            End If
            result += description

            Return result
        End Function

        ''' <summary>
        ''' This method provide to code symbol to trasmit with a webservice
        ''' </summary>
        <DebuggerHiddenAttribute()> Public Sub codeSymbol()
            description.codeSymbol()
        End Sub

        ''' <summary>
        ''' This method provide to decoce symbol when receive a data with a webservice
        ''' </summary>
        <DebuggerHiddenAttribute()> Public Sub deCodeSymbol()
            description.decodeSymbol()
        End Sub

        ''' <summary>
        ''' This method provide to get hash value from a string of a class
        ''' </summary>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Public Overridable Function getHash() As String
            Return HashSHA.generateSHA256(Me.toString())
        End Function

    End Class

    ''' <summary>
    ''' This class contain the element of parameter configuration of a chain
    ''' </summary>
    Public Class ChainParameterModel

        Public Property blockSizeFrequency As String = "24h"
        Public Property numberBlockInVolume As Short = 365
        Public Property maxTimeOutNotRespondNode As String = "120sec"
        Public Property maxTimeOutNotEvaluateNode As String = "180sec"
        Public Property minimalMaintainRequest As String = "3years"
        Public Property minimalMaintainConsensus As String = "2years"
        Public Property minimalMaintainBulletines As String = "1years"
        Public Property minimalMaintainRejected As String = "14days"
        Public Property minimalMaintainTrashed As String = "7days"
        Public Property minimalMaintainInternalRegistry As String = "5days"

        ''' <summary>
        ''' This method provide to create a string summary of the member of a class
        ''' </summary>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Public Overrides Function toString() As String
            Dim tmp As String = ""

            tmp += blockSizeFrequency
            tmp += numberBlockInVolume.ToString()
            tmp += maxTimeOutNotRespondNode
            tmp += minimalMaintainRequest
            tmp += minimalMaintainConsensus
            tmp += minimalMaintainBulletines
            tmp += minimalMaintainRejected
            tmp += minimalMaintainTrashed
            tmp += minimalMaintainInternalRegistry

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

    ''' <summary>
    ''' This class contain the minimal element to install or upgrade a protocol
    ''' </summary>
    Public Class ProtocolMinimalData

        Public Property setCode As String = ""
        Public Property protocol As String = ""
        Public Property documentation As String = ""


        ''' <summary>
        ''' This method provide to convert into a string the element of the object
        ''' </summary>
        ''' <returns></returns>
        Public Overrides Function toString() As String
            Dim result As String = ""

            result += setCode
            result += protocol
            result += documentation

            Return result
        End Function

        ''' <summary>
        ''' This method provide to code symbol to trasmit with a webservice
        ''' </summary>
        <DebuggerHiddenAttribute()> Public Sub codeSymbol()
            documentation.codeSymbol()
        End Sub

        ''' <summary>
        ''' This method provide to decoce symbol when receive a data with a webservice
        ''' </summary>
        <DebuggerHiddenAttribute()> Public Sub deCodeSymbol()
            documentation.decodeSymbol()
        End Sub

        ''' <summary>
        ''' This method provide to get hash value from a string of a class
        ''' </summary>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Public Overridable Function getHash() As String
            Return HashSHA.generateSHA256(Me.toString())
        End Function

    End Class

    ''' <summary>
    ''' This class contain all information reguard of complete asset information
    ''' </summary>
    Public Class AssetStructure
        Inherits IdentifyLastTransaction

        Public Property value As New PrimaryChain.AssetConfigurationModel


        ''' <summary>
        ''' This method provide to convert into a string the element of the object
        ''' </summary>
        ''' <returns></returns>
        Public Overrides Function toString() As String
            Dim tmp As String = value.toString()

            With Me
                tmp += .coordinate
                tmp += .hash
                tmp += .progressiveHash
                tmp += .registrationTimeStamp.ToString
            End With

            Return tmp
        End Function

    End Class

    ''' <summary>
    ''' This class contain the document of a delegate information
    ''' </summary>
    Public Class DelegateGuarantee

        Public Property publicAddress As String = ""
        Public Property signature As String = ""

    End Class

    ''' <summary>
    ''' This class contain the masternode element data
    ''' </summary>
    Public Class RequestAddNewNode

        ''' <summary>
        ''' This class contain the element to identify the address configuration
        ''' </summary>
        Public Class AddressConfiguration

            Public Property main As Boolean = False
            Public Property addressIP As String = ""

            Public Overrides Function toString() As String
                Dim result As String

                If main Then
                    result = "1"
                Else
                    result = "0"
                End If

                result += addressIP

                Return result
            End Function

        End Class

        ''' <summary>
        ''' This class contain the information relative of a guarantee
        ''' </summary>
        Public Class GuaranteeInformation

            Public Property publicAddress As String = ""
            Public Property power As Decimal = 0

            Public Overrides Function toString() As String
                Dim result As String

                result = publicAddress
                result += power.ToString

                Return result
            End Function

        End Class

        Public Property guarantors As New List(Of GuaranteeInformation)
        Public Property refundPublicAddress As String = ""
        Public Property addressesIP As New List(Of AddressConfiguration)
        Public Property chainName As String = ""
        Public Property role As RoleMasterNode = RoleMasterNode.undefined
        Public Property autoDisconnectTimeStamp As Double = 0

        ''' <summary>
        ''' This method provide to convert to string the contain of this class
        ''' </summary>
        ''' <returns></returns>
        Public Overrides Function toString() As String
            Dim result As String = ""

            For Each singleGuarantee In guarantors
                result += singleGuarantee.toString()
            Next

            result += refundPublicAddress

            For Each singleAddress In addressesIP
                result += singleAddress.toString()
            Next

            result += chainName

            Select Case role
                Case RoleMasterNode.arbitration : result += "1"
                Case RoleMasterNode.validator : result += "2"
                Case RoleMasterNode.fullStack : result += "3"
                Case RoleMasterNode.query : result += "4"
                Case RoleMasterNode.newsFeeder : result += "5"
                Case RoleMasterNode.publisherBlockChain : result += "6"
            End Select

            result += autoDisconnectTimeStamp.ToString()

            Return result
        End Function

        ''' <summary>
        ''' This methdo provide to get an hash of the object
        ''' </summary>
        ''' <returns></returns>
        Public Overridable Function getHash() As String
            Return HashSHA.generateSHA256(Me.toString())
        End Function

        ''' <summary>
        ''' This method provide to get a primary address IP
        ''' </summary>
        ''' <returns></returns>
        Public Function getPrimaryAddress() As String
            For Each singleAddress In addressesIP
                If singleAddress.main Then
                    Return singleAddress.addressIP
                End If
            Next

            Return ""
        End Function

        ''' <summary>
        ''' This method provide to get a complessive power
        ''' </summary>
        ''' <returns></returns>
        Public Function getPower() As Decimal
            Dim total As Decimal = 0

            For Each singleGuarantee In guarantors
                total += singleGuarantee.power
            Next

            Return total
        End Function

        ''' <summary>
        ''' This method provide to add a new address IP into list
        ''' </summary>
        ''' <param name="address"></param>
        ''' <param name="main"></param>
        ''' <returns></returns>
        Public Function addNewAddressIP(ByVal address As String, ByVal main As Boolean) As Boolean
            Try
                Dim item As New AddressConfiguration

                item.addressIP = address
                item.main = main

                addressesIP.Add(item)

                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to add a new guarantee into list
        ''' </summary>
        ''' <param name="publicAddress"></param>
        ''' <param name="power"></param>
        ''' <returns></returns>
        Public Function addNewGuarantee(ByVal publicAddress As String, ByVal power As Decimal) As Boolean
            Try
                Dim item As New GuaranteeInformation

                item.publicAddress = publicAddress
                item.power = power

                guarantors.Add(item)

                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to clone an object
        ''' </summary>
        ''' <returns></returns>
        Public Function clone() As NodeComplete
            Try
                Dim item As New NodeComplete

                For Each singleGuarantor In guarantors
                    item.addNewGuarantee(singleGuarantor.publicAddress, singleGuarantor.power)
                Next

                item.refundPublicAddress = refundPublicAddress

                For Each singleAddress In addressesIP
                    item.addNewAddressIP(singleAddress.addressIP, singleAddress.main)
                Next

                item.chainName = chainName
                item.role = role
                item.autoDisconnectTimeStamp = autoDisconnectTimeStamp

                Return item
            Catch ex As Exception
                Return New RequestAddNewNode
            End Try
        End Function

    End Class

    ''' <summary>
    ''' This class contain the masternode element data
    ''' </summary>
    Public Class NodeComplete

        Inherits RequestAddNewNode

        Public Property identityPublicAddress As String = ""
        Public Property startConnectionTimeStamp As Double = 0

    End Class

    ''' <summary>
    ''' This class contain the element of node list chain
    ''' </summary>
    Public Class NodeListChainStructure

        Inherits IdentifyLastTransaction

        Public Property value As New List(Of NodeComplete)

    End Class

End Namespace
