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
        Public Property deliveryBulletinNodeRemain As New Dictionary(Of String, String)

    End Class

    ''' <summary>
    ''' This class contain all information of all intermediate phase of process a request
    ''' </summary>
    Public Class RequestExtended

        Private Property _Data As Object

        Public ReadOnly Property dataCommon As AreaCommon.Models.Network.Request.CommonRequest
            Get
                Try
                    If Not IsNothing(_Data) Then
                        Return _Data.common
                    Else
                        Return New AreaCommon.Models.Network.Request.CommonRequest
                    End If
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
        ''' This method provide to add a new assessment
        ''' </summary>
        ''' <returns></returns>
        Private Function addNewAssessment(ByRef items As AreaCommon.Masternode.MinimalDataMasternodeList, ByVal typology As AreaConsensus.EnumModel) As Boolean
            Try
                For i As Integer = 1 To items.count
                    With items.getItem(i)
                        If (.publicAddress.CompareTo(AreaCommon.state.network.publicAddressIdentity) = 0) Then
                            If (.signature.Length = 0) Then
                                .hash = .getHash(consensus.requestHash, typology)
                                .signature = AreaSecurity.createSignature(.hash)
                            End If
                            .votePoint = AreaCommon.state.network.coinWarranty
                        End If

                        If Not consensus.addNewAssessment(typology, .assessmentTimeStamp, .hash, .signature, .votePoint, .publicAddress) Then
                            Return False
                        End If
                    End With
                Next

                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function


        ''' <summary>
        ''' This method provide to add a data object (request)
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

        ''' <summary>
        ''' This method provide clear old consensus, swap information of evaluation and create consensus structures
        ''' </summary>
        ''' <returns></returns>
        Public Function createConsensus(ByVal currentBulletin As AreaConsensus.BulletinInformation) As Boolean
            Try
                Dim proceed As Boolean = True

                AreaCommon.log.track("RequestExtended.createConsensus", "Begin")

                If proceed Then
                    proceed = consensus.clear()
                End If
                If proceed Then
                    proceed = addNewAssessment(evaluations.approved, AreaConsensus.EnumModel.approved)
                End If
                If proceed Then
                    proceed = addNewAssessment(evaluations.abstained, AreaConsensus.EnumModel.abstained)
                End If
                If proceed Then
                    proceed = addNewAssessment(evaluations.rejected, AreaConsensus.EnumModel.rejected)
                End If
                If proceed Then
                    proceed = addNewAssessment(evaluations.absents, AreaConsensus.EnumModel.absented)
                End If
                If proceed Then
                    consensus.netWorkReferement = dataCommon.netWorkReferement
                    consensus.chainReferement = dataCommon.chainReferement
                    consensus.requestHash = dataCommon.hash
                    consensus.masterNodePublicAddress = AreaCommon.state.network.publicAddressIdentity
                    consensus.nodeRegistrant = currentBulletin.proposalsForApprovalData.registerMasternodeAddress
                    consensus.nodeRegistrantTimeStamp = currentBulletin.proposalsForApprovalData.registerBulletinAssessmentTimeStamp
                    consensus.voteValueApproved = evaluations.approved.totalValuePoints
                    consensus.voteValueRejected = evaluations.approved.totalValuePoints
                End If
                If proceed Then
                    proceed = consensus.reorderElements()
                End If
                If proceed Then
                    consensus.hash = consensus.getHash()
                    consensus.signature = AreaSecurity.createSignature(consensus.hash)
                End If
                If proceed Then
                    proceed = consensus.save()
                End If

                Return proceed
            Catch ex As Exception
                AreaCommon.log.track("RequestExtended.createConsensus", ex.Message, "fatal")

                Return True
            Finally
                AreaCommon.log.track("RequestExtended.createConsensus", "Complete")
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