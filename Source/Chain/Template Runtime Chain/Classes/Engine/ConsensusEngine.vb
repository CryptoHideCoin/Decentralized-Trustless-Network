Option Compare Text
Option Explicit On

Imports System.Xml.Serialization
Imports CHCCommonLibrary.AreaEngine.Encryption



Namespace AreaConsensus


    Public Class RequestProcess

        Public Class NetSynchronization

            Public Property hashNetwork As String = ""
            Public Property identifierTransactionLedger As String = ""
            Public Property progressiveHash As String = ""

        End Class

        Public Class RejectedRequest

            Public Property requestHash As String = ""
            Public Property rejectTimeStamp As Double = 0
            Public Property errorMessage As String = ""

            <Xmlignore()> Public Property toDelivery As New List(Of String)
            <Xmlignore()> Public Property impossibleToDeliver As New List(Of String)

            Public Property signature As String = ""

            Public Overrides Function toString() As String
                Dim tmp As String = ""

                tmp += requestHash
                tmp += rejectTimeStamp.ToString()
                tmp += errorMessage

                Return tmp
            End Function

            Public Function getHash() As String
                Return HashSHA.generateSHA256(Me.toString())
            End Function

        End Class

        Public Class MarkOnRegister

            Public Property identifiedTimeStamp As Double = 0
            Public Property hashProposal As String = ""
            Public Property masterNodePublicAddress As String = ""

        End Class

        Public Class ReportDeliveryProposal

            Public Property masterNodeListCount As Integer = 0
            Public Property masterNodeListValue As Double = 0

            Public Property numberOfAccept As Integer = 0
            Public Property numberOfReject As Integer = 0
            Public Property numberOfNotReceived As Integer = 0
            Public Property numberOfAbsent As Integer = 0

            Public Property approvedCount As Integer = 0
            Public Property approvedValue As Double = 0

        End Class

        Public Class MasterNodeToDelivery

            Public Property masterNodePublicAddress As String = ""
            Public Property deliveryCount As Byte = 0
            Public Property firstDeliveryTimeStamp As Double = 0
            Public Property lastDeliveryTimeStamp As Double = 0

        End Class

        Public Class ProposalsForApproval

            Public Property proposalHash As String = ""
            Public Property requestHash As String = ""
            Public Property identifierTransactionLedger As String = ""
            Public Property markOnRegisterData As New MarkOnRegister
            Public Property masterNodeApprovedHash As String = ""

            Public Property deliveryProposal As New ReportDeliveryProposal
            Public Property missingListDelivery As New List(Of MasterNodeToDelivery)

        End Class

        Public Class RequestApprovedList

            Public Property requestHash As String = ""
            Public Property approvedTimeStamp As Double = 0
            Public Property approvedHash As String = ""

        End Class

        Public Property bulletinTimeStamp As Double = 0
        Public Property masterNodePublicAddress As String = ""

        Public Property netSynchronizationData As New NetSynchronization

        Public Property rejectedRequestData As New List(Of RejectedRequest)

        Public Property proposalsForApprovalData As New ProposalsForApproval

        Public Property requestApprovedListData As New List(Of RequestApprovedList)

    End Class

    Public Class ConsensusEngine

        Private _QueueProcessUpdateBullettin As Queue(Of String)
        Private _CurrentProcessUpdateBullettin As String = ""

        Public Property bullettin As New RequestProcess


        'Private Function cloneMissingListDelivery(ByRef items As List(Of AreaConsensus.RequestProcess.MasterNodeToDelivery)) As List(Of AreaConsensus.RequestProcess.MasterNodeToDelivery)
        '    Try
        '        Dim result As New List(Of AreaConsensus.RequestProcess.MasterNodeToDelivery)
        '        Dim newItem As AreaConsensus.RequestProcess.MasterNodeToDelivery

        '        For Each item In items
        '            newItem = New AreaConsensus.RequestProcess.MasterNodeToDelivery

        '            'newItem.masterNodePublicAddress = 
        '        Next
        '    Catch ex As Exception
        '        AreaCommon.log.track("ConsensusEngine.cloneMissingListDelivery", "Error:" & ex.Message, "error")

        '        Return New List(Of AreaConsensus.RequestProcess.MasterNodeToDelivery)
        '    End Try
        'End Function

        'Private Function cloneBullettin() As RequestProcess
        '    Try
        '        Dim copyBullettin As New RequestProcess

        '        Do While _LockBullettin
        '            Threading.Thread.Sleep(10)
        '        Loop

        '        _LockBullettin = True

        '        With copyBullettin
        '            .bulletinTimeStamp = bullettin.bulletinTimeStamp
        '            .masterNodePublicAddress = bullettin.masterNodePublicAddress

        '            With .netSynchronizationData
        '                .hashNetwork = bullettin.netSynchronizationData.hashNetwork
        '                .identifierTransactionLedger = bullettin.netSynchronizationData.identifierTransactionLedger
        '                .progressiveHash = bullettin.netSynchronizationData.progressiveHash
        '            End With

        '            With .proposalsForApprovalData
        '                With .deliveryProposal
        '                    .approvedCount = bullettin.proposalsForApprovalData.deliveryProposal.approvedCount
        '                    .approvedValue = bullettin.proposalsForApprovalData.deliveryProposal.approvedValue
        '                    .masterNodeListCount = bullettin.proposalsForApprovalData.deliveryProposal.masterNodeListCount
        '                    .masterNodeListValue = bullettin.proposalsForApprovalData.deliveryProposal.masterNodeListValue
        '                    .numberOfAbsent = bullettin.proposalsForApprovalData.deliveryProposal.numberOfAbsent
        '                    .numberOfAccept = bullettin.proposalsForApprovalData.deliveryProposal.numberOfAccept
        '                    .numberOfNotReceived = bullettin.proposalsForApprovalData.deliveryProposal.numberOfNotReceived
        '                    .numberOfReject = bullettin.proposalsForApprovalData.deliveryProposal.numberOfReject
        '                End With

        '                .identifierTransactionLedger = bullettin.proposalsForApprovalData.identifierTransactionLedger

        '                With .markOnRegisterData
        '                    .hashProposal = bullettin.proposalsForApprovalData.markOnRegisterData.hashProposal
        '                    .identifiedTimeStamp = bullettin.proposalsForApprovalData.markOnRegisterData.identifiedTimeStamp
        '                    .masterNodePublicAddress = bullettin.proposalsForApprovalData.markOnRegisterData.masterNodePublicAddress
        '                End With

        '                .masterNodeApprovedHash = bullettin.proposalsForApprovalData.masterNodeApprovedHash

        '                .missingListDelivery = cloneMissingListDelivery(bullettin.proposalsForApprovalData.missingListDelivery)

        '                .proposalHash = bullettin.proposalsForApprovalData.proposalHash
        '                .requestHash = bullettin.proposalsForApprovalData.requestHash
        '            End With


        '            ' Richieste rigettate
        '            .rejectedRequestData

        '            ' Richieste approvate
        '            .requestApprovedListData

        '        End With

        '        _LockBullettin = False

        '        Return copyBullettin
        '    Catch ex As Exception
        '        AreaCommon.log.track("RequestFlowEngine.addNewRequest", "Error:" & ex.Message, "error")

        '        Return New RequestProcess
        '    End Try
        'End Function

        Private Function unlockUpdateBullettin(ByVal key As String) As Boolean
            Try
                If (_CurrentProcessUpdateBullettin.Length > 0) Then
                    _QueueProcessUpdateBullettin.Enqueue(key)
                End If

                Do While (_CurrentProcessUpdateBullettin.CompareTo(key) <> 0)
                    Threading.Thread.Sleep(10)
                Loop

                Return True
            Catch ex As Exception
                AreaCommon.log.track("RequestFlowEngine.unlockUpdateBullettin", "Error:" & ex.Message, "error")

                Return False
            End Try
        End Function

        Private Function checkAndCreateNewBullettin() As Boolean
            Try
                If (bullettin.bulletinTimeStamp = 0) Then
                    bullettin.bulletinTimeStamp = CHCCommonLibrary.AreaEngine.Miscellaneous.timestampFromDateTime()
                    bullettin.masterNodePublicAddress = AreaCommon.state.keys.key(TransactionChainLibrary.AreaEngine.KeyPair.KeysEngine.KeyPair.enumWalletType.identity).publicAddress

                    bullettin.netSynchronizationData.hashNetwork = ""
                    bullettin.netSynchronizationData.identifierTransactionLedger = ""
                    bullettin.netSynchronizationData.progressiveHash = ""
                End If

                Return True
            Catch ex As Exception
                AreaCommon.log.track("RequestFlowEngine.checkAndCreateNewBullettin", "Error:" & ex.Message, "error")

                Return False
            End Try
        End Function


        Public Function manageRequest(ByVal dataRequest As AreaFlow.RequestExtended) As Boolean
            Try
                Dim proceed As Boolean = True

                If unlockUpdateBullettin("main-" & dataRequest.requestHash) Then
                    If proceed Then
                        proceed = checkAndCreateNewBullettin()
                    End If
                    If proceed Then

                    End If
                End If

                Return proceed
            Catch ex As Exception
                AreaCommon.log.track("RequestFlowEngine.manageRequest", "Error:" & ex.Message, "error")

                Return False
            End Try
        End Function

    End Class


End Namespace
