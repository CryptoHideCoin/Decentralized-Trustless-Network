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
    ''' This enumeration contain the element to send
    ''' </summary>
    Public Enum EnumEntityToSend
        request
        bulletin
        requestResponse
    End Enum

    ''' <summary>
    ''' This class contain the source information of a request
    ''' </summary>
    Public Class SourceRequestExtended

        Public Property directRequest As Boolean = False
        Public Property notifyTimeStamp As Double = 0
        Public Property acquireTimeStamp As Double = 0
        Public Property ticketNumber As String = ""
        Public Property notifiedPublicAddress As String = ""
        Public Property firstErrorDuringDownload As Double = 0

    End Class

    ''' <summary>
    ''' This class contain all information reguard the position of all part of the process
    ''' </summary>
    Public Class MonitorPositionRequestExtended

        Public Property request As EnumOperationPosition = EnumOperationPosition.toDo
        Public Property verify As EnumOperationPosition = EnumOperationPosition.toDo
        Public Property process As EnumOperationPosition = EnumOperationPosition.toDo

    End Class

    ''' <summary>
    ''' This class contain all information of all intermediate phase of process a request
    ''' </summary>
    Public Class RequestExtended

        Private Property _Data As Object

        Public ReadOnly Property dataCommon As AreaCommon.Models.Network.Request.CommonRequest
            Get
                Try
                    Return _Data.common
                Catch ex As Exception
                    Return New AreaCommon.Models.Network.Request.CommonRequest
                End Try
            End Get
        End Property
        Public ReadOnly Property data As Object
            Get
                Return _Data
            End Get
        End Property
        Public Property source As New SourceRequestExtended
        Public Property position As New MonitorPositionRequestExtended
        Public Property evaluations As New AreaCommon.Masternode.MasternodeEvaluations
        Public Property consensus As New AreaConsensus.ConsensusNetwork
        Public Property bulletin As New AreaConsensus.BulletinInformation

        ''' <summary>
        ''' This method provide to add a data object 
        ''' </summary>
        ''' <param name="value"></param>
        ''' <returns></returns>
        Public Function addDataObject(ByRef value As Object) As Boolean
            Try
                _Data = value

                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

    End Class

    ''' <summary>
    ''' This class contain all information to send
    ''' </summary>
    Public Class RequestToSend

        Public Property sendType As EnumEntityToSend = EnumEntityToSend.request

        Public Property addTimeStamp As Double = 0
        Public Property requestCode As String = ""
        Public Property requestHash As String = ""
        Public Property deliveryList As AreaCommon.Masternode.MasternodeSenders

        Public Property dataObject As Object

        Public Property tryNumber As Double

    End Class

    ''' <summary>
    ''' This class contain all information to download
    ''' </summary>
    Public Class RequestDownloadKey

        Public Property requestHash As String = ""
        Public Property publicAddress As String = ""

    End Class

End Namespace