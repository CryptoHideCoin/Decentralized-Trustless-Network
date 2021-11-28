Option Compare Text
Option Explicit On







Namespace AreaCommon
    Public Class Customize

        Public Const chainName As String = "Primary"
        Public Const chainDescription As String = "This chain provides to manage the network, chain and stakeholders"
        Public Const chainProtocolDocument As String = "Protocol Description text"

        Public Const oneSecond As Integer = 1000
        Public Const oneMinute As Integer = 60
        Public Const oneHour As Integer = 1         ' Change in 60min
        Public Const oneDay As Integer = 1          ' Change in 24h

        Public Const defaultChainCloseBlockTimingSecond As Integer = oneSecond * oneMinute * oneHour * oneDay
        Public Const defaultTimeOutNotResponseMasternodeSecond As Integer = oneSecond * oneMinute * 2
        Public Const defaultMinimalMaintainRequestBlock As Integer = 365 * 3
        Public Const defaultMinimalMaintainConsensusBlock As Integer = 365 * 2
        Public Const defaultMinimalMaintainBulletinBlock As Integer = 365
        Public Const defaultMinimalMaintainRejectedBlock As Integer = 14
        Public Const defaultMinimalMaintainTrashedBlock As Integer = 7
        Public Const defaultMinimalMantainInternalRegistryBlock As Integer = 5

    End Class
End Namespace