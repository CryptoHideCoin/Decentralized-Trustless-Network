Option Compare Text
Option Explicit On


Namespace AreaFlow


    ''' <summary>
    ''' This enumeration contain the value of a single phase of a request
    ''' </summary>
    Public Enum EnumOperationPosition
        toDo
        inWork
        inError
        completeWithPositiveResult
        completeWithNegativeResult
    End Enum

    ''' <summary>
    ''' This class contain all information of all intermediate phase of process a request
    ''' </summary>
    Public Class RequestExtended

        Public Property requestHash As String = ""
        Public Property dateNotify As Double = 0
        Public Property ticketNumber As String = ""
        Public Property requestCode As String = ""
        Public Property dateRequest As Double = 0
        Public Property directRequest As Boolean = False
        Public Property notifiedPublicAddress As String = ""
        Public Property dateSelected As Double = 0
        Public Property dateAssessment As Double = 0
        Public Property rejectedNote As String = ""

        Public Property firstErrorDuringDownload As Double = 0

        Public Property requestPosition As EnumOperationPosition = EnumOperationPosition.toDo
        Public Property verifyPosition As EnumOperationPosition = EnumOperationPosition.toDo
        Public Property consensusPosition As EnumOperationPosition = EnumOperationPosition.toDo
        Public Property generalStatus As EnumOperationPosition = EnumOperationPosition.toDo

        Public Property response As AreaCommon.Masternode.EvaluationResponse = AreaCommon.Masternode.EvaluationResponse.notDeterminate

        Public Property evaluations As New AreaCommon.Masternode.MasternodeEvaluations
        Public Property notifyRejected As New AreaCommon.Masternode.MasternodeNotifyRejectedList

        Public Property notifyAssessmentAtNetwork As Boolean = False
        Public Property notifySingleConsensusAtNetwork As Boolean = False
        Public Property notifyConsensusAtNetwork As Boolean = False

        Public Property masterNodeExpressions As New AreaConsensus.ConsensusNetwork

    End Class


    Public Class RequestToSend

        Public Property sendBulletin As Boolean = False

        Public Property addTimeStamp As Double = 0
        Public Property requestCode As String = ""
        Public Property requestHash As String = ""
        Public Property deliveryList As AreaCommon.Masternode.MasternodeSenders

        Public Property dataObject As Object

        Public Property tryNumber As Double

    End Class

    Public Class RequestDownloadKey

        Public Property requestHash As String = ""
        Public Property publicAddress As String = ""

    End Class

End Namespace