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







Namespace AreaCommon.Models.Chain

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

End Namespace