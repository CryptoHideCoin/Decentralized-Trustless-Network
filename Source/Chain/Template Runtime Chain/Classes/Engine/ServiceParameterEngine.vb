Option Compare Text
Option Explicit On



Namespace AreaService

    ''' <summary>
    ''' This class contain the element of parameter configuration of a chain
    ''' </summary>
    Public Class ServiceParameters

        Public Property blockSizeFrequency As Double = 0
        Public Property numberBlockInVolume As Short = 0
        Public Property maxTimeOutNotRespondNode As Double = 0
        Public Property maxTimeOutNotEvaluateNode As Double = 0
        Public Property minimalMaintainRequest As Double = 0
        Public Property minimalMaintainConsensus As Double = 0
        Public Property minimalMaintainBulletines As Double = 0
        Public Property minimalMaintainRejected As Double = 0
        Public Property minimalMaintainTrashed As Double = 0
        Public Property minimalMaintainInternalRegistry As Double = 0

    End Class

    ''' <summary>
    ''' This class contain all method to manage the service parameter
    ''' </summary>
    Public Class ServiceParameterEngine

        ''' <summary>
        ''' This method provide to decode a value and check keyword
        ''' </summary>
        ''' <param name="value"></param>
        ''' <param name="keyWord"></param>
        ''' <param name="unitMeasure"></param>
        ''' <returns></returns>
        Private Shared Function decodeValueFromUM(ByVal value As String, ByVal keyWord As String, ByVal keyWord2 As String, ByVal unitMeasure As Double) As Double
            Dim newValue As String = value

            newValue = newValue.Replace(keyWord, "").Replace(keyWord2, "").Trim()

            If (newValue.CompareTo(value) <> 0) Then
                If IsNumeric(newValue) Then
                    Return Val(newValue) * unitMeasure
                End If
            End If

            Return 0
        End Function

        ''' <summary>
        ''' This method provide to decode a value from a string 
        ''' </summary>
        ''' <param name="value"></param>
        ''' <returns></returns>
        Private Shared Function decodeValue(ByVal value As String) As Double
            Try
                Dim newValue As Double = 0

                If (newValue = 0) Then newValue = decodeValueFromUM(value, "years", "year", AreaCommon.Customize.oneYear2Milliseconds)
                If (newValue = 0) Then newValue = decodeValueFromUM(value, "months", "month", AreaCommon.Customize.oneMonth2Milliseconds)
                If (newValue = 0) Then newValue = decodeValueFromUM(value, "weeks", "week", AreaCommon.Customize.oneWeek2Milliseconds)
                If (newValue = 0) Then newValue = decodeValueFromUM(value, "days", "day", AreaCommon.Customize.oneDay2Milliseconds)
                If (newValue = 0) Then newValue = decodeValueFromUM(value, "hours", "hour", AreaCommon.Customize.oneHour2Milliseconds)
                If (newValue = 0) Then newValue = decodeValueFromUM(value, "minutes", "minute", AreaCommon.Customize.oneMinute2Milliseconds)
                If (newValue = 0) Then newValue = decodeValueFromUM(value, "seconds", "second", AreaCommon.Customize.oneSecond2Milliseconds)
                If (newValue = 0) Then newValue = decodeValueFromUM(value, "sec.", "sec", AreaCommon.Customize.oneSecond2Milliseconds)

                If (newValue = 0) Then
                    If IsNumeric(value) Then
                        Return value
                    End If
                End If

                Return newValue
            Catch ex As Exception
                Return 0
            End Try
        End Function

        ''' <summary>
        ''' This method provide to return the default system parameter
        ''' </summary>
        ''' <returns></returns>
        Public Shared Function acquireDefaultParameter() As ServiceParameters
            Try
                Dim result As New ServiceParameters

                AreaCommon.log.track("ServiceParameterEngine.acquireDefaultParameter", "Begin")

                result.blockSizeFrequency = AreaCommon.Customize.defaultChainCloseBlockTimingSecond
                result.maxTimeOutNotEvaluateNode = AreaCommon.Customize.defaultTimeOutNotEvaluateMasternodeSecond
                result.maxTimeOutNotRespondNode = AreaCommon.Customize.defaultTimeOutNotResponseMasternodeSecond
                result.minimalMaintainBulletines = AreaCommon.Customize.defaultMinimalMaintainBulletinBlock
                result.minimalMaintainConsensus = AreaCommon.Customize.defaultMinimalMaintainConsensusBlock
                result.minimalMaintainInternalRegistry = AreaCommon.Customize.defaultMinimalMantainInternalRegistryBlock
                result.minimalMaintainRejected = AreaCommon.Customize.defaultMinimalMaintainRejectedBlock
                result.minimalMaintainRequest = AreaCommon.Customize.defaultMinimalMaintainRequestBlock
                result.minimalMaintainTrashed = AreaCommon.Customize.defaultMinimalMaintainTrashedBlock
                result.numberBlockInVolume = AreaCommon.Customize.defaultNumberBlockInVolume

                AreaCommon.log.track("ServiceParameterEngine.acquireDefaultParameter", "Completed")

                Return result
            Catch ex As Exception
                AreaCommon.log.track("ServiceParameterEngine.acquireDefaultParameter", ex.Message, "fatal")

                Return New ServiceParameters
            End Try
        End Function

        ''' <summary>
        ''' This method provide to acquire network parameter from a Transaction Chain Model
        ''' </summary>
        ''' <param name="data"></param>
        ''' <returns></returns>
        Public Shared Function acquireNetworkParameter(ByRef data As CHCProtocolLibrary.AreaCommon.Models.Network.TransactionChainModel) As ServiceParameters
            Try
                Dim result As New ServiceParameters

                AreaCommon.log.track("ServiceParameterEngine.addNetworkProperty", "Begin")

                result.blockSizeFrequency = decodeValue(data.blockSizeFrequency)
                result.maxTimeOutNotEvaluateNode = decodeValue(data.maxTimeOutNotEvaluateNode)
                result.maxTimeOutNotRespondNode = decodeValue(data.maxTimeOutNotRespondNode)
                result.minimalMaintainBulletines = decodeValue(data.minimalMaintainBulletines)
                result.minimalMaintainConsensus = decodeValue(data.minimalMaintainConsensus)
                result.minimalMaintainInternalRegistry = decodeValue(data.minimalMaintainInternalRegistry)
                result.minimalMaintainRejected = decodeValue(data.minimalMaintainRejected)
                result.minimalMaintainRequest = decodeValue(data.minimalMaintainRequest)
                result.minimalMaintainTrashed = decodeValue(data.minimalMaintainTrashed)
                result.numberBlockInVolume = decodeValue(data.numberBlockInVolume)

                AreaCommon.log.track("ServiceParameterEngine.addNetworkProperty", "End")

                Return result
            Catch ex As Exception
                AreaCommon.log.track("ServiceParameterEngine.addNetworkProperty", ex.Message, "fatal")

                Return New ServiceParameters
            End Try
        End Function

        ''' <summary>
        ''' This method provide to acquire chain parameter from EssentialA1x1
        ''' </summary>
        ''' <param name="data"></param>
        ''' <returns></returns>
        Public Shared Function acquireChainParameter(ByRef data As AreaProtocol.EssentialA1x1) As ServiceParameters
            Try
                Dim result As New ServiceParameters

                AreaCommon.log.track("ServiceParameterEngine.acquireChainParameter", "Begin")

                result.blockSizeFrequency = decodeValue(data.blockSizeFrequency)
                result.maxTimeOutNotEvaluateNode = decodeValue(data.maxTimeOutNotEvaluateNode)
                result.maxTimeOutNotRespondNode = decodeValue(data.maxTimeOutNotRespondNode)
                result.minimalMaintainBulletines = decodeValue(data.minimalMaintainBulletines)
                result.minimalMaintainConsensus = decodeValue(data.minimalMaintainConsensus)
                result.minimalMaintainInternalRegistry = decodeValue(data.minimalMaintainInternalRegistry)
                result.minimalMaintainRejected = decodeValue(data.minimalMaintainRejected)
                result.minimalMaintainRequest = decodeValue(data.minimalMaintainRequest)
                result.minimalMaintainTrashed = decodeValue(data.minimalMaintainTrashed)
                result.numberBlockInVolume = decodeValue(data.numberBlockInVolume)

                AreaCommon.log.track("ServiceParameterEngine.acquireChainParameter", "End")

                Return result
            Catch ex As Exception
                AreaCommon.log.track("ServiceParameterEngine.acquireChainParameter", ex.Message, "fatal")

                Return New ServiceParameters
            End Try
        End Function

    End Class

End Namespace
