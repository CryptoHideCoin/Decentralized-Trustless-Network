Option Compare Text
Option Explicit On







Namespace AreaCommon
    Public Class Customize

        Public Const chainName As String = "Primary"
        Public Const chainDescription As String = "This chain provides to manage the network, chain and stakeholders"
        Public Const chainProtocolDocument As String = "Protocol Description text"

        Public Const oneSecond2Milliseconds As Long = 1000

        Public Const oneMinute2Seconds As Long = 60
        Public Const oneMinute2Milliseconds As Long = oneMinute2Seconds * oneSecond2Milliseconds

        Public Const oneHour2Minutes As Long = 60
        Public Const oneHour2Seconds As Long = oneHour2Minutes * oneMinute2Seconds
        Public Const oneHour2Milliseconds As Long = oneHour2Seconds * oneSecond2Milliseconds

        Public Const oneDay2Hour As Long = 24
        Public Const oneDay2Minutes As Long = oneDay2Hour * oneHour2Minutes
        Public Const oneDay2Seconds As Long = oneDay2Minutes * oneHour2Minutes
        Public Const oneDay2Milliseconds As Long = oneDay2Seconds * oneSecond2Milliseconds

        Public Const oneWeek2Days As Long = 7
        Public Const oneWeek2Milliseconds As Long = oneWeek2Days * oneDay2Milliseconds

        Public Const oneMonth2Days As Long = 30
        Public Const oneMonth2Milliseconds As Long = oneMonth2Days * oneDay2Milliseconds

        Public Const oneYear2Month As Long = 12
        Public Const oneYear2Days As Long = 365
        Public Const oneYear2Milliseconds As Long = oneYear2Days * oneDay2Milliseconds

        Public Const defaultNumberBlockInVolume As Long = oneYear2Days
        Public Const defaultChainCloseBlockTimingSecond As Integer = oneDay2Milliseconds
        Public Const defaultTimeOutNotResponseMasternodeSecond As Integer = 2 * oneMinute2Milliseconds
        Public Const defaultTimeOutNotEvaluateMasternodeSecond As Integer = 3 * oneMinute2Milliseconds
        Public Const defaultMinimalMaintainRequestBlock As Long = oneYear2Days * 3 * oneDay2Milliseconds
        Public Const defaultMinimalMaintainConsensusBlock As Long = oneYear2Days * 2 * oneDay2Milliseconds
        Public Const defaultMinimalMaintainBulletinBlock As Long = oneYear2Days * oneDay2Milliseconds
        Public Const defaultMinimalMaintainRejectedBlock As Long = oneWeek2Days * 2 * oneDay2Milliseconds
        Public Const defaultMinimalMaintainTrashedBlock As Long = oneWeek2Days * oneDay2Milliseconds
        Public Const defaultMinimalMantainInternalRegistryBlock As Long = 5 * oneDay2Milliseconds

    End Class
End Namespace