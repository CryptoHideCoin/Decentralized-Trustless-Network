Option Compare Text
Option Explicit On





Namespace AreaConsensus

    ''' <summary>
    ''' This class contain all element to manage a consensus of all request
    ''' </summary>
    Public Class ConsensusEngine

        ''' <summary>
        ''' This class contain a support properties update bulletin
        ''' 
        ''' notifyNetworkForUpdate occurs when a new request is add into bulletin or when a proposalUpdateNewTransactionHash
        ''' </summary>
        Private Class SupportUpdateBulletin

            Public Property proceed As Boolean = True
            Public Property notifyNetworkForUpdate As Boolean = False
            Public Property newProposalReadyToConsolidate As Boolean = False
            Public Property newIdentity As CHCCommonLibrary.AreaCommon.Models.General.IdentifyLastTransaction
            Public Property blockNumber As String = ""

            Public Property currentPath As CHCProtocolLibrary.AreaSystem.VirtualPathEngine.LedgerBlockPath

        End Class

        Private _QueueProcessUpdateBulletin As New List(Of String)

        Public Property bulletin As New BulletinInformation


        ''' <summary>
        ''' This method provide to lock an element from queue
        ''' </summary>
        ''' <param name="key"></param>
        ''' <returns></returns>
        Private Function unlockUpdateBulletin(ByVal key As String) As Boolean
            Try
                AreaCommon.log.track("ConsensusEngine.unlockUpdateBulletin", "Begin")

                _QueueProcessUpdateBulletin.Add(key)

                Do While (_QueueProcessUpdateBulletin(0).CompareTo(key) <> 0)
                    Threading.Thread.Sleep(1)
                Loop

                AreaCommon.log.track("ConsensusEngine.unlockUpdateBulletin", "Complete")

                Return True
            Catch ex As Exception
                AreaCommon.log.track("ConsensusEngine.unlockUpdateBulletin", ex.Message, "fatal")

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to remove lock into bulletin
        ''' </summary>
        ''' <param name="key"></param>
        ''' <returns></returns>
        Private Function removeFromQueue(ByVal key As String) As Boolean
            Try
                AreaCommon.log.track("ConsensusEngine.removeFromQueue", "Begin")

                _QueueProcessUpdateBulletin.Remove(key)

                AreaCommon.log.track("ConsensusEngine.removeFromQueue", "Complete")

                Return True
            Catch ex As Exception
                AreaCommon.log.track("ConsensusEngine.removeFromQueue", ex.Message, "fatal")

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to check and create new bulletin
        ''' </summary>
        ''' <returns></returns>
        Private Function updateHeaderBulletin() As Boolean
            Try
                AreaCommon.log.track("ConsensusEngine.checkAndCreateNewBulletin", "Begin")

                With bulletin.header
                    .bulletinTimeStamp = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()
                    .publicAddress = AreaCommon.state.network.publicAddressIdentity

                    With .netSynchronizationData
                        .hashNetwork = AreaCommon.state.runtimeState.activeNetwork.hash
                        .hashChain = AreaCommon.state.runtimeState.activeChain.hash

                        With .lastApprovedTransaction
                            .coordinate = AreaCommon.state.currentBlockLedger.composeCoordinateTransaction()
                            .registrationTimeStamp = AreaCommon.state.currentBlockLedger.approvedTransaction.registrationTimeStamp
                            .hash = AreaCommon.state.currentBlockLedger.approvedTransaction.currentHash
                            .progressiveHash = AreaCommon.state.currentBlockLedger.approvedTransaction.progressiveHash
                        End With
                    End With
                End With

                AreaCommon.log.track("ConsensusEngine.checkAndCreateNewBulletin", "Complete")

                Return True
            Catch ex As Exception
                AreaCommon.log.track("ConsensusEngine.checkAndCreateNewBulletin", ex.Message, "fatal")

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to create request approved
        ''' </summary>
        ''' <param name="dataRequest"></param>
        ''' <returns></returns>
        Private Function createRequest(ByRef dataRequest As AreaFlow.RequestExtended, Optional ByVal model As EnumModel = EnumModel.approved) As ReceiptOfConsensusAssessment
            Try
                AreaCommon.log.track("ConsensusEngine.createRequest", "Begin")

                Dim result As New ReceiptOfConsensusAssessment

                result.requestHash = dataRequest.dataCommon.hash
                result.model = model
                result.assessmentTimeStamp = bulletin.header.bulletinTimeStamp

                result = AreaSecurity.createSignature(result)

                AreaCommon.log.track("ConsensusEngine.createRequest", "Complete")

                Return result
            Catch ex As Exception
                AreaCommon.log.track("ConsensusEngine.createRequest", ex.Message, "fatal")

                Return New ReceiptOfConsensusAssessment
            End Try
        End Function

        ''' <summary>
        ''' This method provide to create a request reject
        ''' </summary>
        ''' <param name="dataRequest"></param>
        ''' <returns></returns>
        Private Function createRequestReject(ByRef dataRequest As AreaFlow.RequestExtended) As RejectedRequest
            Try
                Dim result As New RejectedRequest

                AreaCommon.log.track("ConsensusEngine.createReject", "Begin")

                result.model = EnumModel.rejected
                result.rejectedMessage = dataRequest.evaluations.rejectedNote
                result.assessmentTimeStamp = bulletin.header.bulletinTimeStamp

                result.requestHash = dataRequest.dataCommon.hash

                result = AreaSecurity.createSignature(result)

                AreaCommon.log.track("ConsensusEngine.createReject", "Complete")

                Return result
            Catch ex As Exception
                AreaCommon.log.track("ConsensusEngine.createReject", ex.Message, "fatal")

                Return New RejectedRequest
            End Try
        End Function

        ''' <summary>
        ''' This method provide to route the assessment 
        ''' </summary>
        ''' <param name="dataRequest"></param>
        ''' <returns></returns>
        Private Function routeAssessment(ByRef dataRequest As AreaFlow.RequestExtended) As SupportUpdateBulletin
            Dim result As New SupportUpdateBulletin
            Try
                AreaCommon.log.track("ConsensusEngine.routeAssessment", "Begin")

                If (dataRequest.position.verify = AreaFlow.EnumOperationPosition.completeWithPositiveResult) Then
                    If bulletin.addNewAcceptOrAbstainRequestList(createRequest(dataRequest)) Then
                        result.notifyNetworkForUpdate = True
                    End If
                ElseIf (dataRequest.position.verify = AreaFlow.EnumOperationPosition.completeWithNegativeResult) Then
                    If bulletin.addNewRejectRequestList(createRequestReject(dataRequest)) Then
                        result.notifyNetworkForUpdate = True
                    End If
                Else
                    If bulletin.addNewAcceptOrAbstainRequestList(createRequest(dataRequest, EnumModel.abstained)) Then
                        result.notifyNetworkForUpdate = True
                    End If
                End If

                AreaCommon.log.track("ConsensusEngine.routeAssessment", "Complete")
            Catch ex As Exception
                AreaCommon.log.track("ConsensusEngine.routeAssessment", ex.Message, "fatal")

                result.proceed = False
            End Try

            Return result
        End Function

        ''' <summary>
        ''' This method provide to assign the timeStamp to evaluate
        ''' </summary>
        ''' <param name="dataRequest"></param>
        ''' <returns></returns>
        Private Function assignDateAssessment(ByRef dataRequest As AreaFlow.RequestExtended, ByRef result As SupportUpdateBulletin) As SupportUpdateBulletin
            Try
                AreaCommon.log.track("ConsensusEngine.assignDateAssessment", "Begin")

                If result.proceed Then
                    result.proceed = dataRequest.evaluations.approved.assignAssessment(bulletin.header.bulletinTimeStamp)
                End If
                If result.proceed Then
                    result.proceed = dataRequest.evaluations.abstained.assignAssessment(bulletin.header.bulletinTimeStamp)
                End If
                If result.proceed Then
                    result.proceed = dataRequest.evaluations.absents.assignAssessment(bulletin.header.bulletinTimeStamp)
                End If
                If result.proceed Then
                    result.proceed = dataRequest.evaluations.rejected.assignAssessment(bulletin.header.bulletinTimeStamp)
                End If

                AreaCommon.log.track("ConsensusEngine.assignDateAssessment", "Complete")
            Catch ex As Exception
                AreaCommon.log.track("ConsensusEngine.assignDateAssessment", ex.Message, "fatal")

                result.proceed = False
            End Try

            Return result
        End Function

        ''' <summary>
        ''' This method provide to manage a bulletin evaluation
        ''' </summary>
        ''' <param name="dataRequest"></param>
        ''' <param name="result"></param>
        ''' <returns></returns>
        Private Function manageBulletinCheckNotExpressed(ByRef dataRequest As AreaFlow.RequestExtended, ByRef result As SupportUpdateBulletin) As SupportUpdateBulletin
            Try
                Dim responseNotExpressed As AreaCommon.Masternode.ContactDataMasternodeList.ContactDataMasternode
                Dim newNotExpressed As New AreaCommon.Masternode.ContactDataMasternodeList

                AreaCommon.log.track("ConsensusEngine.manageBulletinEvaluation", "Begin")

                If result.proceed Then
                    Do While (dataRequest.evaluations.notExpressed.count > 0)
                        responseNotExpressed = dataRequest.evaluations.notExpressed.getItem(0)

                        If (responseNotExpressed.tryFirstTimeStamp > 300) Then
                            dataRequest.evaluations.setAbsent(responseNotExpressed.publicAddress, bulletin.header.bulletinTimeStamp)
                        ElseIf (responseNotExpressed.tryNumberOfRequest < 3) Then
                            If AreaCommon.flow.checkRemoteBulletinFromNode(responseNotExpressed.publicAddress) Then
                                newNotExpressed.addNew(responseNotExpressed)
                            Else
                                If AreaCommon.flow.addNewRequestToExpression(AreaCommon.Masternode.MasternodeSenders.createSingleMasterNodeList(responseNotExpressed.publicAddress, responseNotExpressed.publicIPAddress), dataRequest.dataCommon.hash) Then
                                    newNotExpressed.addNew(responseNotExpressed)
                                End If
                            End If
                        Else
                            newNotExpressed.addNew(responseNotExpressed)
                        End If
                    Loop

                    If (newNotExpressed.count > 0) Then
                        dataRequest.evaluations.notExpressed = newNotExpressed
                    End If
                End If

                AreaCommon.log.track("ConsensusEngine.manageBulletinEvaluation", "Complete")
            Catch ex As Exception
                AreaCommon.log.track("ConsensusEngine.manageBulletinEvaluation", ex.Message, "fatal")

                result.proceed = False
            End Try

            Return result
        End Function

        ''' <summary>
        ''' This method provide to manage a proposal and approve date
        ''' </summary>
        ''' <param name="registration"></param>
        ''' <returns></returns>
        Private Function useNewProposalForApproval(ByRef registration As ReceiptOfConsensusAssessment, ByRef result As SupportUpdateBulletin) As SupportUpdateBulletin
            Try
                Dim request As AreaFlow.RequestExtended

                AreaCommon.log.track("ConsensusEngine.useNewProposalForApproval", "Begin")

                request = AreaCommon.flow.getActiveRequest(registration.requestHash)

                With bulletin.proposalsForApprovalData
                    .registerBulletinAssessmentTimeStamp = registration.assessmentTimeStamp

                    If request.source.directRequest Then
                        .registerMasternodeAddress = AreaCommon.state.network.publicAddressIdentity
                    Else
                        .registerMasternodeAddress = request.source.notifiedPublicAddress
                    End If

                    .requestHash = registration.requestHash

                    With .totalVotes
                        .abstained = request.evaluations.abstained.totalValuePoints
                        .approved = request.evaluations.approved.totalValuePoints
                        .notExpressed = request.evaluations.notExpressed.totalValuePoints
                        .rejected = request.evaluations.rejected.totalValuePoints
                    End With
                End With

                bulletin.proposalsForApprovalData = AreaSecurity.createSignature(bulletin.proposalsForApprovalData, True)

                result.notifyNetworkForUpdate = True

                AreaCommon.log.track("ConsensusEngine.useNewProposalForApproval", "Complete")
            Catch ex As Exception
                AreaCommon.log.track("ConsensusEngine.useNewProposalForApproval", ex.Message, "fatal")

                result.proceed = False
            End Try

            Return result
        End Function

        ''' <summary>
        ''' This method provide to update new transaction for the ledger
        ''' </summary>
        ''' <param name="result"></param>
        ''' <returns></returns>
        Private Function useNewProposalUpdateNewTransactionHash(ByRef result As SupportUpdateBulletin) As SupportUpdateBulletin
            Try
                Dim proceed As Boolean = True
                Dim request As AreaFlow.RequestExtended

                AreaCommon.log.track("ConsensusEngine.useNewproposalUpdateNewTransactionHash", "Begin")

                If proceed Then
                    proceed = (bulletin.proposalUpdateNewTransactionHash.requestHash.CompareTo(bulletin.proposalsForApprovalData.requestHash) <> 0)
                End If
                If proceed Then
                    request = AreaCommon.flow.getActiveRequest(bulletin.proposalsForApprovalData.requestHash)

                    If (request.evaluations.notExpressed.count = 0) Then

                        If request.createConsensus(bulletin) Then
                            bulletin.proposalUpdateNewTransactionHash.consensusHash = request.consensus.hash
                            bulletin.proposalUpdateNewTransactionHash.requestHash = bulletin.proposalsForApprovalData.requestHash
                            bulletin.proposalUpdateNewTransactionHash.proposalIdentifierTransactionLedger = AreaCommon.state.currentBlockLedger.composeCoordinateTransaction(True)

                            result.notifyNetworkForUpdate = True
                            result.newProposalReadyToConsolidate = True
                        End If
                    End If
                End If

                AreaCommon.log.track("ConsensusEngine.useNewproposalUpdateNewTransactionHash", "Complete")
            Catch ex As Exception
                AreaCommon.log.track("ConsensusEngine.useNewproposalUpdateNewTransactionHash", ex.Message, "fatal")

                result.proceed = False
            End Try

            Return result
        End Function

        ''' <summary>
        ''' This method provide to retrieve the registration 
        ''' </summary>
        ''' <returns></returns>
        Private Function manageBulletinForAssessment(ByRef result As SupportUpdateBulletin) As SupportUpdateBulletin
            Dim registrationTimeStamp As Double = 0
            Dim minimalRegistration As New ReceiptOfConsensusAssessment
            Try
                AreaCommon.log.track("ConsensusEngine.manageBulletinForAssessment", "Begin")

                For Each request In bulletin.acceptOrAbstainRequestList
                    If (request.model = EnumModel.approved) Then
                        registrationTimeStamp = AreaCommon.flow.getApprovedTimeStamp(request.requestHash, bulletin.header.netSynchronizationData.lastApprovedTransaction.registrationTimeStamp)

                        If (registrationTimeStamp < minimalRegistration.assessmentTimeStamp) Or
                           (minimalRegistration.assessmentTimeStamp = 0) Then
                            minimalRegistration = request
                        End If
                    End If
                Next

                If (minimalRegistration.assessmentTimeStamp < bulletin.proposalsForApprovalData.registerBulletinAssessmentTimeStamp) Or
                   (bulletin.proposalsForApprovalData.registerBulletinAssessmentTimeStamp = 0) Then
                    result = useNewProposalForApproval(minimalRegistration, result)
                End If

                If result.proceed Then
                    If (bulletin.proposalsForApprovalData.totalVotes.notExpressed = 0) Then
                        result = useNewProposalUpdateNewTransactionHash(result)
                    End If
                End If

                AreaCommon.log.track("ConsensusEngine.manageBulletinForAssessment", "Complete")
            Catch ex As Exception
                AreaCommon.log.track("ConsensusEngine.manageBulletinForAssessment", ex.Message, "fatal")

                result.proceed = False
            End Try

            Return result
        End Function

        ''' <summary>
        ''' This method provide to manage a node abstain of a bulletin
        ''' </summary>
        ''' <param name="result"></param>
        ''' <returns></returns>
        Private Function manageNodeAbstain(ByRef dataRequest As AreaFlow.RequestExtended, ByRef result As SupportUpdateBulletin) As SupportUpdateBulletin
            Try
                Dim node As AreaCommon.Masternode.MinimalDataMasternodeList.MinimalDataMasternode

                AreaCommon.log.track("ConsensusEngine.manageNodeAbstain", "Begin")

                For i As Integer = 1 To dataRequest.evaluations.abstained.count
                    node = dataRequest.evaluations.abstained.getItem(i)

                    If Not AreaCommon.state.runtimeState.manageAbstained(AreaCommon.state.network.publicAddressIdentity, dataRequest.dataCommon.hash) Then
                        result.proceed = False

                        Exit For
                    End If
                Next

                AreaCommon.log.track("ConsensusEngine.manageNodeAbstain", "Complete")
            Catch ex As Exception
                AreaCommon.log.track("ConsensusEngine.manageNodeAbstain", ex.Message, "fatal")

                result.proceed = False
            End Try

            Return result
        End Function

        ''' <summary>
        ''' This method provide to manage a request abstain
        ''' </summary>
        ''' <param name="support"></param>
        ''' <returns></returns>
        Private Function manageRequestAbstain(ByRef support As SupportUpdateBulletin) As SupportUpdateBulletin
            Try
                Dim dataRequest As AreaFlow.RequestExtended
                Dim haveChangeList As Boolean = True

                AreaCommon.log.track("ConsensusEngine.manageRequestAbstain", "Begin")

                Do While haveChangeList
                    haveChangeList = False

                    For Each assessment In bulletin.acceptOrAbstainRequestList
                        If (assessment.model = EnumModel.abstained) Then
                            dataRequest = AreaCommon.flow.getActiveRequest(assessment.requestHash)

                            If dataRequest.position.deliveryBulletinNodeRemain.ContainsKey("delivered") Then
                                bulletin.acceptOrAbstainRequestList.Remove(assessment)
                                haveChangeList = True

                                Exit For
                            End If
                        End If
                    Next
                Loop

                AreaCommon.log.track("ConsensusEngine.manageRequestAbstain", "Complete")
            Catch ex As Exception
                AreaCommon.log.track("ConsensusEngine.manageRequestAbstain", ex.Message, "fatal")

                support.proceed = False
            End Try

            Return support
        End Function

        ''' <summary>
        ''' This manage bulletin rejected
        ''' </summary>
        ''' <param name="result"></param>
        ''' <returns></returns>
        Private Function manageNodeRejected(ByRef dataRequest As AreaFlow.RequestExtended, ByRef result As SupportUpdateBulletin) As SupportUpdateBulletin
            Try
                Dim node As AreaCommon.Masternode.MinimalDataMasternodeList.MinimalDataMasternode

                AreaCommon.log.track("ConsensusEngine.manageNodeRejected", "Begin")

                For i As Integer = 1 To dataRequest.evaluations.rejected.count
                    node = dataRequest.evaluations.abstained.getItem(i)

                    If Not AreaCommon.state.runtimeState.manageRejected(AreaCommon.state.network.publicAddressIdentity, dataRequest.dataCommon.hash) Then
                        result.proceed = False

                        Exit For
                    End If
                Next

                AreaCommon.log.track("ConsensusEngine.manageNodeRejected", "Complete")
            Catch ex As Exception
                AreaCommon.log.track("ConsensusEngine.manageNodeRejected", ex.Message, "fatal")

                result.proceed = False
            End Try

            Return result
        End Function

        ''' <summary>
        ''' This method provide to explore all request rejected and evaluate it if is to remove
        ''' </summary>
        ''' <param name="support"></param>
        ''' <returns></returns>
        Private Function manageRequestRejected(ByRef support As SupportUpdateBulletin) As SupportUpdateBulletin
            Try
                Dim dataRequest As AreaFlow.RequestExtended
                Dim haveChangeList As Boolean = True

                AreaCommon.log.track("ConsensusEngine.manageRequestRejected", "Begin")

                Do While haveChangeList
                    haveChangeList = False

                    For Each rejected In bulletin.rejectedRequestData
                        dataRequest = AreaCommon.flow.getActiveRequest(rejected.requestHash)

                        If dataRequest.position.deliveryBulletinNodeRemain.ContainsKey("delivered") Then
                            bulletin.rejectedRequestData.Remove(rejected)
                            bulletin.removeRejectRequestData(rejected)

                            haveChangeList = True

                            Exit For
                        End If
                    Next
                Loop

                AreaCommon.log.track("ConsensusEngine.manageRequestRejected", "Complete")
            Catch ex As Exception
                AreaCommon.log.track("ConsensusEngine.manageRequestRejected", ex.Message, "fatal")

                support.proceed = False
            End Try

            Return support
        End Function

        ''' <summary>
        ''' This method provide to Manage Request Absent
        ''' </summary>
        ''' <param name="dataRequest"></param>
        ''' <param name="result"></param>
        ''' <returns></returns>
        Private Function manageRequestAbsent(ByRef dataRequest As AreaFlow.RequestExtended, ByRef result As SupportUpdateBulletin) As SupportUpdateBulletin
            Try
                Dim node As AreaCommon.Masternode.MinimalDataMasternodeList.MinimalDataMasternode

                AreaCommon.log.track("ConsensusEngine.manageRequestAbsent", "Begin")

                For i As Integer = 1 To dataRequest.evaluations.absents.count
                    node = dataRequest.evaluations.abstained.getItem(i)

                    If Not AreaCommon.state.runtimeState.manageAbsent(node.publicAddress, dataRequest.dataCommon.hash) Then
                        result.proceed = False

                        Exit For
                    End If
                Next

                AreaCommon.log.track("ConsensusEngine.manageRequestAbsent", "Complete")
            Catch ex As Exception
                AreaCommon.log.track("ConsensusEngine.manageRequestAbsent", ex.Message, "fatal")

                result.proceed = False
            End Try

            Return result
        End Function

        ''' <summary>
        ''' This method provide to save a bulletin into file
        ''' </summary>
        ''' <param name="dataRequest"></param>
        ''' <param name="result"></param>
        ''' <returns></returns>
        Private Function saveBulletin(ByRef dataRequest As AreaFlow.RequestExtended, ByRef result As SupportUpdateBulletin) As SupportUpdateBulletin
            Try
                AreaCommon.log.track("ConsensusEngine.saveBulletin", "Begin")

                If result.newProposalReadyToConsolidate Then
                    bulletin = AreaSecurity.createSignature(bulletin, True)

                    If Not bulletin.save() Then
                        AreaCommon.log.track("saveBulletin with problem", "Complete")

                        result.proceed = False
                    End If
                End If

                AreaCommon.log.track("ConsensusEngine.saveBulletin", "Complete")
            Catch ex As Exception
                AreaCommon.log.track("ConsensusEngine.saveBulletin", ex.Message, "fatal")

                result.proceed = False
            End Try

            Return result
        End Function

        ''' <summary>
        ''' This method provide to load list a sender into requests
        ''' </summary>
        ''' <param name="listSender"></param>
        ''' <param name="requests"></param>
        ''' <returns></returns>
        Private Function loadListSenderIntoRequests(ByRef listSender As AreaCommon.Masternode.MasternodeSenders, ByRef requests As List(Of String)) As Boolean
            Try
                Dim requestData As AreaFlow.RequestExtended
                Dim publicAddress As String

                AreaCommon.log.track("ConsensusEngine.loadListSenderIntoRequests", "Begin")

                For Each request In requests
                    requestData = AreaCommon.flow.getActiveRequest(request)

                    If (requestData.position.deliveryBulletinNodeRemain.Count = 0) Then
                        For i As Integer = 0 To listSender.count - 1

                            publicAddress = listSender.getItem(i).publicAddress

                            If Not requestData.position.deliveryBulletinNodeRemain.ContainsKey(publicAddress) Then
                                requestData.position.deliveryBulletinNodeRemain.Add(publicAddress, publicAddress)
                            End If
                        Next
                    End If
                Next

                AreaCommon.log.track("ConsensusEngine.loadListSenderIntoRequests", "Complete")

                Return True
            Catch ex As Exception
                AreaCommon.log.track("ConsensusEngine.loadListSenderIntoRequests", ex.Message, "fatal")

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to send a all node of the network
        ''' </summary>
        Private Function sendInBroadCast(ByRef dataRequest As AreaFlow.RequestExtended) As Boolean
            Try
                Dim listSender As AreaCommon.Masternode.MasternodeSenders = AreaCommon.Masternode.MasternodeSenders.createMasterNodeList()
                Dim requests As List(Of String) = extractRequestFromBulletin(bulletin)

                loadListSenderIntoRequests(listSender, requests)

                Return AreaCommon.flow.addNewBulletinToSend(listSender, dataRequest.bulletin)
            Catch ex As Exception
                AreaCommon.log.track("ConsensusEngine.sendInBroadCast", ex.Message, "fatal")

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to determinate if the proposal is approved to the network or not
        ''' </summary>
        ''' <returns></returns>
        Private Function proposalDataApproved() As Boolean
            Try
                AreaCommon.log.track("ConsensusEngine.proposalDataApproved", "Begin")

                Dim percApproved As Decimal = bulletin.proposalsForApprovalData.totalVotes.approved / bulletin.proposalsForApprovalData.totalVotes.total * 100
                Dim percReject As Decimal = bulletin.proposalsForApprovalData.totalVotes.rejected / bulletin.proposalsForApprovalData.totalVotes.total * 100
                Dim dataRequest As AreaFlow.RequestExtended

                dataRequest = AreaCommon.flow.getActiveRequest(bulletin.proposalsForApprovalData.requestHash)

                If (percApproved >= percReject) Then
                    dataRequest.position.process = AreaFlow.EnumOperationPosition.completeWithPositiveResult
                Else
                    dataRequest.position.process = AreaFlow.EnumOperationPosition.completeWithNegativeResult
                End If

                AreaCommon.log.track("ConsensusEngine.proposalDataApproved", "Complete")

                Return True
            Catch ex As Exception
                AreaCommon.log.track("ConsensusEngine.proposalDataApproved", ex.Message, "fatal")

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to update a ledger with 
        ''' </summary>
        ''' <returns></returns>
        Private Function updateLedger(ByRef support As SupportUpdateBulletin) As SupportUpdateBulletin
            Try
                AreaCommon.log.track("ConsensusEngine.updateLedger", "Begin")

                Dim request As AreaFlow.RequestExtended = AreaCommon.flow.getActiveRequest(bulletin.proposalUpdateNewTransactionHash.requestHash)
                Dim registrant As String = bulletin.proposalsForApprovalData.registerMasternodeAddress
                Dim registrationTimeStamp As Double = bulletin.proposalsForApprovalData.registerBulletinAssessmentTimeStamp
                Dim consensusHash As String = bulletin.proposalUpdateNewTransactionHash.consensusHash
                Dim requestHash As String = bulletin.proposalUpdateNewTransactionHash.requestHash

                Select Case request.dataCommon.type
                    Case "a0x0" : support.newIdentity = AreaProtocol.A0x0.Manager.addIntoLedger(registrant, consensusHash, registrationTimeStamp, request.data.content, request.data.common.publicAddressRequester, requestHash)
                    Case "a0x1" : support.newIdentity = AreaProtocol.A0x1.Manager.addIntoLedger(registrant, consensusHash, registrationTimeStamp, request.data.whitePaper, request.data.common.publicAddressRequester, requestHash)
                    Case "a0x2" : support.newIdentity = AreaProtocol.A0x2.Manager.addIntoLedger(registrant, consensusHash, registrationTimeStamp, request.data.yellowPaper, request.data.common.publicAddressRequester, requestHash)
                    Case "a0x3" : support.newIdentity = AreaProtocol.A0x3.Manager.addIntoLedger(registrant, consensusHash, registrationTimeStamp, request.data.content, request.data.common.publicAddressRequester, requestHash)
                    Case "a0x4" : support.newIdentity = AreaProtocol.A0x4.Manager.addIntoLedger(registrant, consensusHash, registrationTimeStamp, request.data.transactionChainSettings, request.data.common.publicAddressRequester, requestHash)
                    Case "a0x5" : support.newIdentity = AreaProtocol.A0x5.Manager.addIntoLedger(registrant, consensusHash, registrationTimeStamp, request.data.privacyPolicy, request.data.common.publicAddressRequester, requestHash)
                    Case "a0x6" : support.newIdentity = AreaProtocol.A0x6.Manager.addIntoLedger(registrant, consensusHash, registrationTimeStamp, request.data.generalCondition, request.data.common.publicAddressRequester, requestHash)
                    Case "a0x7" : support.newIdentity = AreaProtocol.A0x7.Manager.addIntoLedger(registrant, consensusHash, registrationTimeStamp, request.data.refundPlan, request.data.common.publicAddressRequester, requestHash)

                    Case "a1x0" : support.newIdentity = AreaProtocol.A1x0.Manager.addIntoLedger(registrant, consensusHash, registrationTimeStamp, request.data.extractMinimal(), request.data.common.publicAddressRequester, requestHash)
                    Case "a1x1" : support.newIdentity = AreaProtocol.A1x1.Manager.addIntoLedger(registrant, consensusHash, registrationTimeStamp, request.data.extractMinimal(), request.data.common.publicAddressRequester, requestHash)
                    Case "a1x2" : support.newIdentity = AreaProtocol.A1x2.Manager.addIntoLedger(registrant, consensusHash, registrationTimeStamp, request.data.extractMinimal(), request.data.common.publicAddressRequester, requestHash)
                    Case "a1x3" : support.newIdentity = AreaProtocol.A1x3.Manager.addIntoLedger(registrant, consensusHash, registrationTimeStamp, request.data.extractMinimal(), request.data.common.publicAddressRequester, requestHash)
                    Case "a1x4" : support.newIdentity = AreaProtocol.A1x4.Manager.addIntoLedger(registrant, consensusHash, registrationTimeStamp, request.data.extractMinimal(), request.data.common.publicAddressRequester, requestHash)
                    Case "a1x5" : support.newIdentity = AreaProtocol.A1x5.Manager.addIntoLedger(registrant, consensusHash, registrationTimeStamp, request.data.common.publicAddressRequester, requestHash)

                        ''' BOOKMARK: Add in this point 1
                End Select

                support.proceed = Not IsNothing(support.newIdentity)
                support.blockNumber = AreaCommon.state.currentBlockLedger.composeCoordinateTransaction(False, True)

                AreaCommon.log.track("ConsensusEngine.updateLedger", "Complete")

                Return support
            Catch ex As Exception
                AreaCommon.log.track("ConsensusEngine.updateLedger", ex.Message, "fatal")

                support.proceed = False

                Return support
            End Try
        End Function

        ''' <summary>
        ''' This method provide to update the state position of a approvation
        ''' </summary>
        ''' <returns></returns>
        Private Function updateState(ByRef support As SupportUpdateBulletin) As SupportUpdateBulletin
            Try
                AreaCommon.log.track("ConsensusEngine.updateState", "Begin")

                Dim request As AreaFlow.RequestExtended = AreaCommon.flow.getActiveRequest(bulletin.proposalUpdateNewTransactionHash.requestHash)

                support.proceed = False

                Select Case request.dataCommon.type
                    Case "a0x0" : support.proceed = AreaProtocol.A0x0.RecoveryState.fromRequest(request.data, support.newIdentity)
                    Case "a0x1" : support.proceed = AreaProtocol.A0x1.RecoveryState.fromRequest(request.data, support.newIdentity)
                    Case "a0x2" : support.proceed = AreaProtocol.A0x2.RecoveryState.fromRequest(request.data, support.newIdentity)
                    Case "a0x3" : support.proceed = AreaProtocol.A0x3.RecoveryState.fromRequest(request.data, support.newIdentity)
                    Case "a0x4" : support.proceed = AreaProtocol.A0x4.RecoveryState.fromRequest(request.data, support.newIdentity)
                    Case "a0x5" : support.proceed = AreaProtocol.A0x5.RecoveryState.fromRequest(request.data, support.newIdentity)
                    Case "a0x6" : support.proceed = AreaProtocol.A0x6.RecoveryState.fromRequest(request.data, support.newIdentity)
                    Case "a0x7" : support.proceed = AreaProtocol.A0x7.RecoveryState.fromRequest(request.data, support.newIdentity)

                    Case "a1x0" : support.proceed = AreaProtocol.A1x0.RecoveryState.fromRequest(request.data, support.newIdentity)
                    Case "a1x1" : support.proceed = AreaProtocol.A1x1.RecoveryState.fromRequest(request.data, support.newIdentity)
                    Case "a1x2" : support.proceed = AreaProtocol.A1x2.RecoveryState.fromRequest(request.data, support.newIdentity)
                    Case "a1x3" : support.proceed = AreaProtocol.A1x3.RecoveryState.fromRequest(request.data, support.newIdentity)
                    Case "a1x4" : support.proceed = AreaProtocol.A1x4.RecoveryState.fromRequest(request.data, support.newIdentity)
                    Case "a1x5" : support.proceed = AreaProtocol.A1x5.RecoveryState.fromRequest(request.data, support.newIdentity)

                        ''' BOOKMARK: Add in this point 2
                End Select

                AreaCommon.log.track("ConsensusEngine.updateState", "Complete")

                Return support
            Catch ex As Exception
                AreaCommon.log.track("ConsensusEngine.updateState", ex.Message, "fatal")

                support.proceed = False

                Return support
            End Try
        End Function

        ''' <summary>
        ''' This method provide to move a request into current ledger directory
        ''' </summary>
        ''' <returns></returns>
        Private Function moveFileToCurrentLedger(ByRef request As AreaFlow.RequestExtended) As Boolean
            Try
                AreaCommon.log.track("ConsensusEngine.moveRequestToCurrentLedger", "Begin")

                Dim fileSource As String = IO.Path.Combine(AreaCommon.paths.workData.requestData.received, request.dataCommon.hash & ".Request")
                Dim fileDestination As String = IO.Path.Combine(AreaCommon.state.currentBlockLedger.approvedTransaction.pathData.requests, request.dataCommon.hash & ".Request")

                IO.File.Move(fileSource, fileDestination)

                fileSource = IO.Path.Combine(AreaCommon.paths.workData.temp, request.dataCommon.hash & ".Bulletin")
                fileDestination = IO.Path.Combine(AreaCommon.state.currentBlockLedger.approvedTransaction.pathData.bulletines, request.dataCommon.hash & ".Bulletin")

                IO.File.Move(fileSource, fileDestination)

                fileSource = IO.Path.Combine(AreaCommon.paths.workData.temp, request.dataCommon.hash & ".Consent")
                fileDestination = IO.Path.Combine(AreaCommon.state.currentBlockLedger.approvedTransaction.pathData.consensus, request.dataCommon.hash & ".Consent")

                IO.File.Move(fileSource, fileDestination)

                AreaCommon.log.track("ConsensusEngine.moveRequestToCurrentLedger", "Complete")

                Return True
            Catch ex As Exception
                AreaCommon.log.track("ConsensusEngine.moveRequestToCurrentLedger", ex.Message, "fatal")

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to remove from bulletin the element relative the propose update into the ledger
        ''' </summary>
        ''' <param name="request"></param>
        ''' <returns></returns>
        Private Function removeProposalFromBulletin(ByRef request As AreaFlow.RequestExtended) As Boolean
            Try
                AreaCommon.log.track("ConsensusEngine.removeProposalFromBulletin", "Begin")

                If bulletin.cleanProposalData() Then
                    Return bulletin.removeAcceptOrAbstainRequestList(request.dataCommon.hash)
                Else
                    Return False
                End If
            Catch ex As Exception
                AreaCommon.log.track("ConsensusEngine.removeProposalFromBulletin", ex.Message, "fatal")

                Return False
            Finally
                AreaCommon.log.track("ConsensusEngine.removeProposalFromBulletin", "Complete")
            End Try
        End Function

        ''' <summary>
        ''' This method provide to manage an other operation
        ''' </summary>
        ''' <param name="support"></param>
        ''' <returns></returns>
        Private Function otherOperations(ByRef support As SupportUpdateBulletin, ByVal requestHash As String) As SupportUpdateBulletin
            Try
                AreaCommon.log.track("ConsensusEngine.otherOperation", "Begin")

                Dim request As AreaFlow.RequestExtended = AreaCommon.flow.getActiveRequest(bulletin.proposalUpdateNewTransactionHash.requestHash)

                support.proceed = False

                Select Case request.dataCommon.type
                    Case "a1x5" : support.proceed = AreaProtocol.A1x5.Manager.finalizeBlock(requestHash, support.blockNumber)
                    Case Else : support.proceed = True

                        ''' BOOKMARK: Add in this point 10
                End Select

                AreaCommon.log.track("ConsensusEngine.otherOperation", "Complete")

                Return support
            Catch ex As Exception
                AreaCommon.log.track("ConsensusEngine.otherOperation", ex.Message, "fatal")

                support.proceed = False

                Return support
            End Try
        End Function


        ''' <summary>
        ''' This method provide to extract request from bulletin
        ''' </summary>
        ''' <returns></returns>
        Public Shared Function extractRequestFromBulletin(ByVal bulletinData As AreaConsensus.BulletinInformation) As List(Of String)
            Try
                Dim response As New List(Of String)

                AreaCommon.log.track("ConsensusEngine.extractRequestFromBulletin", "Begin")

                For Each rejected In bulletinData.rejectedRequestData
                    response.Add(rejected.requestHash)
                Next

                For Each assessment In bulletinData.acceptOrAbstainRequestList
                    response.Add(assessment.requestHash)
                Next

                AreaCommon.log.track("ConsensusEngine.extractRequestFromBulletin", "Complete")

                Return response
            Catch ex As Exception
                AreaCommon.log.track("ConsensusEngine.extractRequestFromBulletin", ex.Message, "fatal")

                Return New List(Of String)
            End Try
        End Function

        ''' <summary>
        ''' This method provide to update a bulletin and in any case send in broadcast to the network
        ''' </summary>
        ''' <param name="dataRequest"></param>
        ''' <returns></returns>
        Public Function updateBulletin(ByRef dataRequest As AreaFlow.RequestExtended) As Boolean
            Try
                Dim support As New SupportUpdateBulletin
                Dim cloneBulletin As BulletinInformation

                AreaCommon.log.track("ConsensusEngine.updateBulletin", "Begin")

                If support.proceed Then
                    support.proceed = unlockUpdateBulletin("MainAssessment-" & dataRequest.dataCommon.hash)
                End If
                If support.proceed Then
                    dataRequest.position.process = AreaFlow.EnumOperationPosition.inWork

                    support.proceed = updateHeaderBulletin()
                End If
                If support.proceed Then
                    support = routeAssessment(dataRequest)
                End If
                If support.proceed Then
                    support = assignDateAssessment(dataRequest, support)
                End If
                If support.proceed Then
                    support = manageBulletinCheckNotExpressed(dataRequest, support)
                End If
                If support.proceed Then
                    support = manageBulletinForAssessment(support)
                End If
                If support.proceed Then
                    support = manageNodeAbstain(dataRequest, support)
                End If
                If support.proceed Then
                    support = manageRequestAbstain(support)
                End If
                If support.proceed Then
                    support = manageNodeRejected(dataRequest, support)
                End If
                If support.proceed Then
                    support = manageRequestRejected(support)
                End If
                If support.proceed Then
                    support = manageRequestAbsent(dataRequest, support)
                End If
                If support.proceed Then
                    support = saveBulletin(dataRequest, support)
                End If
                If support.proceed Then
                    support.currentPath = AreaCommon.state.currentBlockLedger.approvedTransaction.pathData

                    cloneBulletin = bulletin.clone()

                    If Not IsNothing(dataRequest.bulletin) Then
                        If (dataRequest.bulletin.header.publicAddress.Length = 0) Then
                            dataRequest.bulletin = cloneBulletin
                        End If
                    End If
                End If
                If support.proceed Then
                    dataRequest.position.process = AreaFlow.EnumOperationPosition.completeWithPositiveResult
                Else
                    dataRequest.position.process = AreaFlow.EnumOperationPosition.completeWithNegativeResult
                End If

                removeFromQueue("MainAssessment-" & dataRequest.dataCommon.hash)

                If support.proceed Then
                    If support.notifyNetworkForUpdate Then
                        support.proceed = sendInBroadCast(dataRequest)
                    End If
                End If
                If support.proceed Then
                    If support.newProposalReadyToConsolidate Then
                        support = updateLedger(support)
                    End If
                End If
                If support.proceed Then
                    If support.newProposalReadyToConsolidate Then
                        support = updateState(support)
                    End If
                End If
                If support.proceed Then
                    support = otherOperations(support, dataRequest.dataCommon.hash)
                End If
                If support.proceed Then
                    support.proceed = AreaCommon.flow.setRequestProcessed(dataRequest, support.blockNumber)
                End If
                If support.proceed Then
                    support.proceed = moveFileToCurrentLedger(dataRequest)
                End If
                If support.proceed Then
                    If Not proposalDataApproved() Then
                        ''' TODO: Add a request to disconnect from the network
                    End If
                End If
                If support.proceed Then
                    If support.newProposalReadyToConsolidate Then
                        support.proceed = removeProposalFromBulletin(dataRequest)
                    End If
                End If

                AreaCommon.log.track("ConsensusEngine.updateBulletin", "Complete")

                Return support.proceed
            Catch ex As Exception
                AreaCommon.log.track("ConsensusEngine.updateBulletin", ex.Message, "fatal")

                removeFromQueue("MainAssessment-" & dataRequest.dataCommon.hash)

                Return False
            End Try

        End Function




        ''' <summary>
        ''' This method provide to check if the network and the chain is correct
        ''' </summary>
        ''' <param name="value"></param>
        ''' <returns></returns>
        Private Function testNetwork(ByRef value As NetSynchronization) As Boolean
            Return True
        End Function



        Private Function updateRejectRequest(ByVal bulletinTimeStamp As Double, ByVal masterNodePublicAddress As String, ByRef value As List(Of RejectedRequest)) As Boolean
            Try
                Dim proceed As Boolean = True

                For Each item In value
                    If proceed Then
                        'proceed = updateProposalRequest(bulletinTimeStamp, masterNodePublicAddress, item.requestHash, False)
                    End If
                Next

                Return proceed
            Catch ex As Exception
                AreaCommon.log.track("ConsensusEngine.sendInBroadCast", ex.Message, "fatal")

                Return False
            End Try
        End Function

        Private Function updateApprovalListData(ByVal bulletinTimeStamp As Double, ByVal masterNodePublicAddress As String, ByRef value As Dictionary(Of String, ReceiptOfAssessment)) As Boolean
            Try
                Dim proceed As Boolean = True

                For Each item In value
                    If proceed Then
                        'proceed = updateProposalRequest(bulletinTimeStamp, masterNodePublicAddress, item.Value.requestHash, True)
                    End If
                Next

                Return proceed
            Catch ex As Exception
                AreaCommon.log.track("RequestFlowEngine.sendInBroadCast", ex.Message, "fatal")

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to test all late comers
        ''' </summary>
        ''' <param name="dataRequest"></param>
        ''' <returns></returns>
        Private Function manageLateComers(ByVal dataRequest As AreaFlow.RequestExtended) As Boolean
            Try
                Dim publicAddress As String = ""

                AreaCommon.log.track("ConsensusEngine.manageLateComers", "Begin")

                For i As Integer = 0 To dataRequest.evaluations.notExpressed.count - 1
                    publicAddress = dataRequest.evaluations.notExpressed.getItem(0).publicAddress

                    ' controllo di non avere già in pancia un bulletin di questo wallet

                    ' se non è presente un bulletin ... allora provo ad interrogare direttamente il nodo

                    ' vediamo come finisce

                Next

                AreaCommon.log.track("ConsensusEngine.manageLateComers", "Complete")

                Return True
            Catch ex As Exception
                AreaCommon.log.track("ConsensusEngine.manageProposalData", ex.Message, "fatal")

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to manage a proposal data
        ''' </summary>
        ''' <param name="dataRequest"></param>
        ''' <returns></returns>
        Public Function manageProposalData(ByVal dataRequest As AreaFlow.RequestExtended) As Boolean
            Try
                AreaCommon.log.track("ConsensusEngine.manageProposalData", "Begin")

                If (bulletin.proposalsForApprovalData.totalVotes.notExpressed = 0) Then
                    Dim percApproved As Decimal = bulletin.proposalsForApprovalData.totalVotes.approved / bulletin.proposalsForApprovalData.totalVotes.total * 100
                    Dim percReject As Decimal = bulletin.proposalsForApprovalData.totalVotes.rejected / bulletin.proposalsForApprovalData.totalVotes.total * 100

                    If (percApproved >= percReject) Then
                        dataRequest.position.process = AreaFlow.EnumOperationPosition.completeWithPositiveResult
                    Else
                        dataRequest.position.process = AreaFlow.EnumOperationPosition.completeWithNegativeResult
                    End If
                Else
                    Return manageLateComers(dataRequest)
                End If

                AreaCommon.log.track("ConsensusEngine.manageProposalData", "Complete")

                Return True
            Catch ex As Exception
                AreaCommon.log.track("ConsensusEngine.manageProposalData", ex.Message, "fatal")

                Return False
            End Try
        End Function

        Public Function processRemoteNotify(ByVal dataBulletin As AreaConsensus.BulletinInformation) As Boolean
            ''' TODO: ProcessRemoteNotify - Complete method
            Try
                Dim proceed As Boolean = True

                If proceed Then
                    proceed = testNetwork(dataBulletin.header.netSynchronizationData)
                End If
                If proceed Then
                    'proceed = updateProposalRequest(dataBulletin.header.bulletinTimeStamp, dataBulletin.header.publicAddress, dataBulletin.proposalsForApprovalData.requestHash, True)
                End If
                If proceed Then
                    proceed = updateRejectRequest(dataBulletin.header.bulletinTimeStamp, dataBulletin.header.publicAddress, dataBulletin.rejectedRequestData)
                End If
                If proceed Then
                    'proceed = updateApprovalListData(dataBulletin.header.bulletinTimeStamp, dataBulletin.header.publicAddress, dataBulletin.AcceptOrAbstainRequestList)
                End If

                Return True
            Catch ex As Exception
                AreaCommon.log.track("ConsensusEngine.processRemoteNotify", ex.Message, "fatal")

                Return False
            End Try
        End Function

    End Class

End Namespace
