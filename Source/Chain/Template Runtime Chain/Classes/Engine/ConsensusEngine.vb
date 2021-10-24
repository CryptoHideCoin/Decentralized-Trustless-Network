Option Compare Text
Option Explicit On





Namespace AreaConsensus

    ''' <summary>
    ''' This class contain all element to manage a consensus of all request
    ''' </summary>
    Public Class ConsensusEngine

        ''' <summary>
        ''' This class contain a support properties update bulletin
        ''' </summary>
        Private Class SupportUpdateBulletin

            Public Property proceed As Boolean = True
            Public Property notifyNetworkForUpdate As Boolean = False

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
        Private Function checkAndCreateNewBulletin() As Boolean
            Try
                AreaCommon.log.track("ConsensusEngine.checkAndCreateNewBulletin", "Begin")

                If (bulletin.header.bulletinTimeStamp = 0) Then
                    With bulletin.header
                        .bulletinTimeStamp = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()
                        .publicAddress = AreaCommon.state.network.publicAddressIdentity

                        With .netSynchronizationData
                            .hashNetwork = AreaCommon.state.runtimeState.activeNetwork.networkName.hash
                            .hashChain = AreaCommon.state.runtimeState.activeChain.name.hash

                            With .lastApprovedTransaction
                                .coordinate = AreaCommon.state.currentBlockLedger.composeCoordinateTransaction()
                                .registrationTimeStamp = AreaCommon.state.currentBlockLedger.currentApprovedTransaction.registrationTimeStamp
                                .hash = AreaCommon.state.currentBlockLedger.currentApprovedTransaction.currentHash
                                .progressiveHash = AreaCommon.state.currentBlockLedger.currentApprovedTransaction.progressiveHash
                            End With
                        End With
                    End With
                End If

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
                result.approvedTimeStamp = bulletin.header.bulletinTimeStamp

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

                result.model = EnumModel.reject
                result.rejectedMessage = dataRequest.evaluations.rejectedNote
                result.approvedTimeStamp = bulletin.header.bulletinTimeStamp

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
                    If bulletin.addNewAcceptOrAbstainRequestList(createRequest(dataRequest, EnumModel.absteined)) Then
                        result.notifyNetworkForUpdate = True
                    End If
                End If

                AreaCommon.log.track("ConsensusEngine.routeAssessment", "Complete")

                result.proceed = True
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

                result.proceed = True
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

                request = AreaCommon.flow.getRequest(registration.requestHash)

                With bulletin.proposalsForApprovalData
                    '.consensusHash = ?"?
                    '.deliveryToAllNetwork =?!?

                    '.proposalIdentifierTransactionLedger = ?!?
                    .registerBulletinAssessmentTimeStamp = registration.approvedTimeStamp

                    If request.source.directRequest Then
                        .registerMasternodeAddress = AreaCommon.state.network.publicAddressIdentity
                    Else
                        .registerMasternodeAddress = request.source.notifiedPublicAddress
                    End If

                    .requestHash = registration.requestHash

                    With .totalVotes
                        .abstained = 0
                        .approved = 0
                        .netWorkTotalVote = 0
                        .notExpressed = 0
                        .rejected = 0
                    End With
                End With

                bulletin.proposalsForApprovalData = AreaSecurity.createSignature(bulletin.proposalsForApprovalData, True)

                AreaCommon.log.track("ConsensusEngine.useNewProposalForApproval", "Complete")
            Catch ex As Exception
                AreaCommon.log.track("ConsensusEngine.useNewProposalForApproval", ex.Message, "fatal")
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
                    If request.model = EnumModel.approved Then
                        registrationTimeStamp = AreaCommon.flow.getApprovedTimeStamp(request.requestHash, bulletin.header.netSynchronizationData.lastApprovedTransaction.registrationTimeStamp)

                        If (registrationTimeStamp < minimalRegistration.approvedTimeStamp) Or
                           (minimalRegistration.approvedTimeStamp = 0) Then
                            minimalRegistration = request
                        End If
                    End If
                Next

                If (minimalRegistration.approvedTimeStamp < bulletin.proposalsForApprovalData.registerBulletinAssessmentTimeStamp) Or
                   (bulletin.proposalsForApprovalData.registerBulletinAssessmentTimeStamp = 0) Then
                    result = useNewProposalForApproval(minimalRegistration, result)
                End If

                AreaCommon.log.track("ConsensusEngine.manageBulletinForAssessment", "Complete")

                result.proceed = True
            Catch ex As Exception
                AreaCommon.log.track("ConsensusEngine.manageBulletinForAssessment", ex.Message, "fatal")
            End Try

            Return result
        End Function

        ''' <summary>
        ''' This method provide to update a bulletin and in any case send in broadcast to the network
        ''' </summary>
        ''' <param name="dataRequest"></param>
        ''' <returns></returns>
        Public Function updateBulletin(ByRef dataRequest As AreaFlow.RequestExtended) As Boolean
            Try
                Dim support As New SupportUpdateBulletin

                AreaCommon.log.track("ConsensusEngine.updateBulletin", "Begin")

                If support.proceed Then
                    support.proceed = unlockUpdateBulletin("MainAssessment-" & dataRequest.dataCommon.hash)
                End If
                If support.proceed Then
                    support.proceed = checkAndCreateNewBulletin()
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
                    ' a questo punto cerco di capire se ci sono novità rispetto l'inizio ed eventualmente 
                    ' effettuo la notifica alla rete.

                    ' Importante però ... devo clonare l'oggetto e spedire la copia
                End If

                If support.proceed Then

                End If
                If support.proceed Then
                    'proceed = sendInBroadCast()
                End If

                AreaCommon.log.track("ConsensusEngine.updateBulletin", "Complete")

                Return support.proceed
            Catch ex As Exception
                AreaCommon.log.track("ConsensusEngine.updateBulletin", ex.Message, "fatal")

                Return False
            Finally
                removeFromQueue("MainAssessment-" & dataRequest.dataCommon.hash)
            End Try


            Try

                ' Cominciamo con il bloccare il bulletin

                ' Intanto ragioniamo...

                ' Quando cadono le condizioni affinché 

                ' Che faccio ?!?

                ' Mi segno gli attuali estremi della proposta di hash per l'aggiornamento del ledger

                ' Mi segno gli attuali estremi della proposta per l'aggiornamento 

                ' Se, al termine di questo proceesso di aggiornamento del bulletin saranno cambiati o proposta di hash o proposta per aggiornamento 

                ' A questo punto sarà maturata la necessità di notifica al network

                ' Oppure se sarà aggiunto un elemento alle liste di approvazione/disapprovazione 

                ' anche in questo caso sarà notificato al network


            Catch ex As Exception

            End Try
            ' Cosa faccio ?!?

            ' Cerco di capire questa richiesta che strada ha percorso

            ' Approvata

            ' Non approvata

            ' Mancata partecipazione alla votazione

            ' Se parliamo di approvazione... intanto cerco di aggiungerla nella lista 
            'bulletin.AcceptOrAbstainRequestList
            'bulletin.rejectedRequestData

            ' Bene, un pensiero in meno

        End Function

        Private Function refreshAssessmentTimeStamp(ByVal requestHash As String) As Double

            ' Cosa faccio ?!?

            ' Le regole sono queste

            ' Vedo l'ora dell'ultima scrittura del ledger avvenuta in forma collegiale 

            ' A questo punto rovisto all'interno di tutte le approvazioni ricevute 
            Try
                AreaCommon.log.track("ConsensusEngine.refreshAssessmentTimeStamp", "Begin")

                Dim recordTimeStamp As Double = bulletin.header.netSynchronizationData.lastApprovedTransaction.registrationTimeStamp
                Dim request As AreaFlow.RequestExtended = AreaCommon.flow.getRequest(requestHash)
                Dim approvedGreaterThan As AreaCommon.Masternode.ContactDataMasternodeList

                'request.evaluations.approved.extractGreaterThan(recordTimeStamp)
                'request.evaluations.approved.getItem()

                'request.consensus.addNewAbstained()

                AreaCommon.log.track("ConsensusEngine.refreshAssessmentTimeStamp", "Complete")
            Catch ex As Exception
                AreaCommon.log.track("ConsensusEngine.refreshAssessmentTimeStamp", ex.Message, "fatal")
            End Try

        End Function

        '''' <summary>
        '''' This method provide to manage bulletin position
        '''' </summary>
        '''' <param name="notifyNetworkForUpdate"></param>
        '''' <returns></returns>
        'Private Function checkCompleteAssessmentInBulletinForAssessment(ByVal notifyNetworkForUpdate As Boolean) As SupportUpdateBulletin
        '    Dim result As New SupportUpdateBulletin
        '    Try
        '        AreaCommon.log.track("ConsensusEngine.manageBulletinForAssessment", "Begin")

        '        result.notifyNetworkForUpdate = notifyNetworkForUpdate
        '        result.proceed = True

        '        For Each item In bulletin.AcceptOrAbstainRequestList

        '            item.Value.assessmentTimeStamp = refreshAssessmentTimeStamp(item.Value.requestHash)

        '        Next

        '        AreaCommon.log.track("ConsensusEngine.manageBulletinForAssessment", "Complete")
        '    Catch ex As Exception
        '        AreaCommon.log.track("ConsensusEngine.manageBulletinForAssessment", ex.Message, "fatal")

        '        result.proceed = False
        '    End Try

        '    Return result
        'End Function

        ''' <summary>
        ''' This method provide to update assessment to the network
        ''' </summary>
        ''' <param name="dataRequest"></param>
        ''' <returns></returns>
        Private Function updateAssessment(ByRef dataRequest As AreaFlow.RequestExtended) As SupportUpdateBulletin
            Dim result As New SupportUpdateBulletin
            Try
                ' Cosa devo fare adesso ?!?

                'Dim registerAssessmentData As AreaCommon.Masternode.MasternodeEvaluations.FirstAssessment
                Dim privateKeyRAW As String = AreaCommon.state.keys.key(TransactionChainLibrary.AreaEngine.KeyPair.KeysEngine.KeyPair.enumWalletType.identity).privateKey

                AreaCommon.log.track("ConsensusEngine.updateAssessment", "Begin")

                ' Questo metodo serve a capire se questa richiesta 
                ' è quella eletta, la più giovane in assoluto in termini di priorità di approvazione
                ' e quindi se merita subito l'attenzione della rete oppure no

                ' per fare ciò bisogna capire se... l'attuale data di register ... chiamiamola così...
                ' NO, in questo modo è sbagliato l'approccio...

                ' intanto finisce nell'AcceptOrAbastainRequestList...

                ' Quindi i passaggi da fare sono:

                ' La aggiungo alla lista AcceptOrAb...

                ' Poi controllo se, all'interno della lista ci sono elementi che hanno chiuso il loro ciclo di 
                ' Consultazioni all'interno della rete

                ' Se qualcuna ha completato quest'iter ... cerco di estrapolare la proposta di approvazione

                ' E la notifico alla rete

                ' Extract in AcceptOrAbstainRequestList all request that have not "notExpressed" in the internal list

                ' Locate the first

                ' Check if Locate is in Proposal for approval data

                ' in everywhere i check and manage Proposal for approval data

                ' eventualmente assemblo ... se ho già gli estremi anche la lista per l'aggiornamento hash

                ' Notifico tutto a tutti

                With bulletin.proposalsForApprovalData
                    'registerAssessmentData = dataRequest.evaluations.getFirstAssessment(True)

                    'If (.requestHash.Length = 0) Or (.registerBulletinAssessmentTimeStamp < dataRequest.evaluations.dateAssessment) Then

                    'If (registerAssessmentData.dateFirstAssessment = 0) Then
                    '    registerAssessmentData.dateFirstAssessment = dataRequest.evaluations.dateAssessment
                    '    registerAssessmentData.publicAddressMasternode = AreaCommon.state.network.publicAddressIdentity
                    'End If

                    .requestHash = dataRequest.dataCommon.hash
                        '.registerBulletinAssessmentTimeStamp = registerAssessmentData.dateFirstAssessment
                        '.registerMasternodeAddress = registerAssessmentData.publicAddressMasternode
                        '.totalVotes.netWorkTotalVote = dataRequest.evaluations.currentChainNodeTotalVotes

                        .proposalIdentifierTransactionLedger = AreaCommon.state.currentBlockLedger.composeCoordinateTransaction(True)

                        '.totalVotes.approved = dataRequest.evaluations.approved.totalValuePoints
                        '.totalVotes.abstained = dataRequest.evaluations.abstained.totalValuePoints
                        '.totalVotes.notExpressed = dataRequest.evaluations.notExpressed.totalValuePoints
                        '.totalVotes.rejected = dataRequest.evaluations.rejected.totalValuePoints

                        .hash = .getHash()

                        .signature = CHCProtocolLibrary.AreaWallet.Support.WalletAddressEngine.createSignature(privateKeyRAW, .hash)
                    'Else
                    'If Not bulletin.AcceptOrAbstainRequestList.ContainsKey(dataRequest.dataCommon.hash) Then
                    'bulletin.AcceptOrAbstainRequestList.Add(dataRequest.requestHash, createRequestApproved(dataRequest))
                    'End If
                    'End If
                End With

                bulletin.hash = bulletin.getHash()
                bulletin.signature = CHCProtocolLibrary.AreaWallet.Support.WalletAddressEngine.createSignature(privateKeyRAW, bulletin.hash)

                AreaCommon.log.track("ConsensusEngine.updateAssessment", "Complete")

                'Return True
            Catch ex As Exception
                AreaCommon.log.track("ConsensusEngine.updateAssessment", ex.Message, "fatal")

                'Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to process assessment
        ''' </summary>
        ''' <param name="dataRequest"></param>
        ''' <param name="notifyNetworkForUpdate"></param>
        ''' <returns></returns>
        Private Function processAssessment(ByRef dataRequest As AreaFlow.RequestExtended, ByVal notifyNetworkForUpdate As Boolean) As SupportUpdateBulletin
            Dim result As New SupportUpdateBulletin
            Try
                AreaCommon.log.track("ConsensusEngine.processAssessment", "Begin")

                result.notifyNetworkForUpdate = notifyNetworkForUpdate

                If (dataRequest.position.verify = AreaFlow.EnumOperationPosition.completeWithPositiveResult) Then
                    'result.proceed = updateAssessment(dataRequest)
                ElseIf (dataRequest.position.verify = AreaFlow.EnumOperationPosition.completeWithNegativeResult) Then
                    result.proceed = updateReject(dataRequest)
                Else
                    'result.proceed = updateAbstained(dataRequest)
                End If

                AreaCommon.log.track("ConsensusEngine.processAssessment", "processAssessment")
            Catch ex As Exception
                AreaCommon.log.track("ConsensusEngine.processAssessment", ex.Message, "fatal")
            End Try

            Return result
        End Function



        ''' <summary>
        ''' This method provide to notify assessment to the network
        ''' </summary>
        ''' <param name="dataRequest"></param>
        ''' <returns></returns>
        Public Function notifyNewAssessment(ByVal dataRequest As AreaFlow.RequestExtended) As Boolean
            Try
                Dim proceed As Boolean = True

                AreaCommon.log.track("ConsensusEngine.notifyAssessment", "Begin")

                If unlockUpdateBulletin("MainAssessment-" & dataRequest.dataCommon.hash) Then
                    If proceed Then
                        proceed = checkAndCreateNewBulletin()
                    End If
                    If proceed Then
                        If (dataRequest.position.verify = AreaFlow.EnumOperationPosition.completeWithPositiveResult) Then
                            'If Not bulletin.AcceptOrAbstainRequestList.ContainsKey(dataRequest.dataCommon.hash) Then
                            'bulletin.AcceptOrAbstainRequestList.Add(dataRequest.requestHash, createRequestApproved(dataRequest))
                            'End If

                            'proceed = updateAssessment(dataRequest)
                        Else
                            proceed = updateReject(dataRequest)
                        End If
                    End If
                    If proceed Then
                        proceed = sendInBroadCast()
                    End If
                End If

                AreaCommon.log.track("ConsensusEngine.notifyAssessment", "Complete")

                Return proceed
            Catch ex As Exception
                AreaCommon.log.track("ConsensusEngine.notifyAssessment", ex.Message, "fatal")

                Return False
            Finally
                removeFromQueue("MainAssessment-" & dataRequest.dataCommon.hash)
            End Try
        End Function

        Private Function updateReject(ByRef dataRequest As AreaFlow.RequestExtended) As Boolean
            'Try
            '    Dim newItem As New RejectedRequest

            '    For Each newItem In bulletin.rejectedRequestData
            '        If newItem.requestHash.CompareTo(dataRequest.dateRequest) = 0 Then
            '            Return True
            '        End If
            '    Next

            '    newItem.rejectedMessage = dataRequest.rejectedNote
            '    newItem.assessmentTimeStamp = dataRequest.dateAssessment
            '    newItem.requestHash = dataRequest.dataCommon.hash

            '    bulletin.rejectedRequestData.Add(newItem)

            '    Return True

            'Catch ex As Exception
            '    AreaCommon.log.track("ConsensusEngine.updateReject", ex.Message, "fatal")

            '    Return False
            'End Try
        End Function


        ''' <summary>
        ''' This method provide to clone a current bulletin and send a all node of the network
        ''' </summary>
        Private Function sendInBroadCast() As Boolean
            Try
                Dim listSender As AreaCommon.Masternode.MasternodeSenders
                Dim currentBulletin As BulletinInformation

                currentBulletin = bulletin.clone()
                listSender = AreaCommon.Masternode.MasternodeSenders.createMasterNodeList()

                Return AreaCommon.flow.addNewBulletinToSend(listSender, currentBulletin)
            Catch ex As Exception
                AreaCommon.log.track("ConsensusEngine.sendInBroadCast", ex.Message, "fatal")

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

        'Private Function updateProposalRequest(ByVal bulletinTimeStamp As Double, ByVal masterNodePublicAddress As String, ByVal requestHash As String, ByVal approved As Boolean) As Boolean
        '    Try
        '        Dim request As AreaFlow.RequestExtended

        '        request = AreaCommon.flow.getRequestToProcess(requestHash)

        '        If (request.evaluations.notExpressed.getItem(masterNodePublicAddress).publicAddress.Length > 0) Then
        '            If approved Then
        '                Return request.evaluations.setApproved(masterNodePublicAddress, bulletinTimeStamp)
        '            Else
        '                Return request.evaluations.setRejected(masterNodePublicAddress, bulletinTimeStamp)
        '            End If
        '        Else
        '            Return True
        '        End If
        '    Catch ex As Exception
        '        AreaCommon.log.track("ConsensusEngine.sendInBroadCast", ex.Message, "fatal")

        '        Return False
        '    End Try
        'End Function

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

        Private Function updateLedger(ByVal requestHash As String) As Boolean
            Try
                Dim request As AreaFlow.RequestExtended

                request = AreaCommon.flow.getRequest(requestHash)

                Select Case request.dataCommon.requestCode
                    Case "a0x0"
                End Select
            Catch ex As Exception
                AreaCommon.log.track("ConsensusEngine.updateLedger", ex.Message, "fatal")

                Return False
            End Try
        End Function

        Private Function createConsensusFile(ByVal dataRequest As AreaFlow.RequestExtended) As Boolean
            Try
                Dim privateKeyRAW As String = AreaCommon.state.keys.key(TransactionChainLibrary.AreaEngine.KeyPair.KeysEngine.KeyPair.enumWalletType.identity).privateKey

                dataRequest.consensus.reorderElement()

                dataRequest.consensus.hash = dataRequest.consensus.getHash
                dataRequest.consensus.signature = CHCProtocolLibrary.AreaWallet.Support.WalletAddressEngine.createSignature(privateKeyRAW, dataRequest.consensus.hash)

                Return CHCCommonLibrary.AreaEngine.DataFileManagement.Json.IOFast(Of ConsensusNetwork).save("", dataRequest.consensus)
            Catch ex As Exception
                AreaCommon.log.track("ConsensusEngine.createConsensusFile", ex.Message, "fatal")

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
                    Dim percApproved As Decimal = bulletin.proposalsForApprovalData.totalVotes.approved / bulletin.proposalsForApprovalData.totalVotes.netWorkTotalVote * 100
                    Dim percReject As Decimal = bulletin.proposalsForApprovalData.totalVotes.rejected / bulletin.proposalsForApprovalData.totalVotes.netWorkTotalVote * 100

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

        Public Function notifyAllNetworkExpressAssessment(ByVal dataRequest As AreaFlow.RequestExtended) As Boolean
            Try
                If unlockUpdateBulletin("MainAssessment-" & dataRequest.dataCommon.hash) Then
                    If (dataRequest.evaluations.notExpressed.count = 0) Then

                        Dim proceed As Boolean = True

                        If proceed Then
                            proceed = (dataRequest.evaluations.approved.totalValuePoints > dataRequest.evaluations.rejected.totalValuePoints)
                        End If
                        If proceed Then
                            proceed = createConsensusFile(dataRequest)
                        End If
                        If proceed Then
                            proceed = sendInBroadCast()
                        End If
                        If proceed Then
                            proceed = updateLedger(dataRequest.dataCommon.hash)
                        End If

                        ' Rimuovo la richiesta dalla lista

                        ' Aggiorno lo stato

                        ' Sposto nella cartella corrente la richiesta

                        ' Creo la ricevuta di approvazione 

                        ' Passo al successivo (quindi aggiorno il bulletin) 

                        ' E azzero la notifica di Assessment così lo 

                        Return True

                    End If

                End If

                Return False
            Catch ex As Exception
                AreaCommon.log.track("ConsensusEngine.notifyAssessmentAllNetworkExpressAssessment", ex.Message, "fatal")

                Return False
            Finally
                removeFromQueue("MainAssessment-" & dataRequest.dataCommon.hash)
            End Try
        End Function

        Public Function processRemoteNotify(ByVal dataBulletin As AreaConsensus.BulletinInformation) As Boolean
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
