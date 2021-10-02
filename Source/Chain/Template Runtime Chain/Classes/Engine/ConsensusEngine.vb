Option Compare Text
Option Explicit On

Imports System.Xml.Serialization
Imports CHCCommonLibrary.AreaEngine.Encryption



Namespace AreaConsensus


    Public Class RequestProcess

        Public Class NetSynchronization

            Public Property hashNetwork As String = ""
            Public Property hashChain As String = ""
            Public Property identifierTransactionLedger As String = ""
            Public Property progressiveHash As String = ""

        End Class

        Public Class RejectedRequest

            Public Property rejectTimeStamp As Double = 0
            Public Property masterNodePublicAddress As String = ""
            Public Property requestHash As String = ""
            Public Property rejectedMessage As String = ""

            Public Property hash As String = ""
            Public Property signature As String = ""

            Public Overrides Function toString() As String
                Dim tmp As String = ""

                tmp += rejectTimeStamp.ToString()
                tmp += masterNodePublicAddress
                tmp += requestHash
                tmp += rejectedMessage

                Return tmp
            End Function

            Public Function getHash() As String
                hash = HashSHA.generateSHA256(Me.toString())

                Return hash
            End Function

        End Class

        Public Class ReceiptOfApproval

            Public Property bulletinTimeStamp As String = ""
            Public Property masterNodePublicAddress As String = ""
            Public Property requestHash As String = ""
            Public Property voteValue As Double = 0

            Public Property hash As String = ""
            Public Property signature As String = ""

            Public Overrides Function toString() As String
                Dim tmp As String = ""

                tmp += bulletinTimeStamp.ToString()
                tmp += masterNodePublicAddress
                tmp += requestHash
                tmp += voteValue.ToString()

                Return tmp
            End Function

            Public Function getHash() As String
                hash = HashSHA.generateSHA256(Me.toString())

                Return hash
            End Function

        End Class

        Public Class RequestAbstention

            Public Property bulletinTimeStamp As String = ""
            Public Property masterNodePublicAddress As String = ""
            Public Property requestHash As String = ""

            Public Property hash As String = ""
            Public Property signature As String = ""

            Public Overrides Function toString() As String
                Dim tmp As String = ""

                tmp += bulletinTimeStamp.ToString()
                tmp += masterNodePublicAddress
                tmp += requestHash

                Return tmp
            End Function

            Public Function getHash() As String
                hash = HashSHA.generateSHA256(Me.toString())

                Return hash
            End Function

        End Class

        Public Class ProposalForApproval

            Public Property proposalIdentifierTransactionLedger As String = ""

            Public Property requestHash As String = ""
            Public Property dateFirstBulletinAssessmentTimeStamp As Double = 0
            Public Property firstMasternodeAssessment As String = ""
            Public Property deliveryToAllNetwork As Boolean = False
            Public Property totalVotes As Double = 0
            Public Property NetworkTotalVotes As Double = 0

            Public Overrides Function toString() As String
                Dim tmp As String = ""

                tmp += proposalIdentifierTransactionLedger
                tmp += requestHash
                tmp += dateFirstBulletinAssessmentTimeStamp.ToString
                tmp += firstMasternodeAssessment
                tmp += totalVotes.ToString()
                tmp += NetworkTotalVotes.ToString()

                Return tmp
            End Function

            Public Function getHash() As String
                Return HashSHA.generateSHA256(Me.toString())
            End Function

            Public Property hash As String = ""
            Public Property signature As String = ""

        End Class

        Public Class MasterNodeCommunication

            Public Property bulletinTimeStamp As String = ""
            Public Property publicAddress As String = ""
            Public Property requestHash As String = ""
            Public Property tryNumber As Byte
            Public Property startNotResponse As Double = 0
            Public Property lastNotResponse As Double = 0

            Public Property hash As String = ""
            Public Property signature As String = ""

            Public Overrides Function toString() As String
                Dim tmp As String = ""

                tmp += bulletinTimeStamp.ToString()
                tmp += publicAddress
                tmp += requestHash
                tmp += tryNumber
                tmp += startNotResponse.ToString()
                tmp += lastNotResponse.ToString()

                Return tmp
            End Function

            Public Function getHash() As String
                hash = HashSHA.generateSHA256(Me.toString())

                Return hash
            End Function

        End Class

        Public Property bulletinTimeStamp As Double = 0
        Public Property masterNodePublicAddress As String = ""

        Public Property netSynchronizationData As New NetSynchronization

        Public Property rejectedRequestData As New List(Of RejectedRequest)

        Public Property proposalsForApprovalData As New ProposalForApproval

        Public Property requestApprovedList As New Dictionary(Of String, ReceiptOfApproval)

        Public Property masternodeAbsent As New List(Of MasterNodeCommunication)

        Public Overrides Function toString() As String
            Dim tmp As String = ""

            tmp += bulletinTimeStamp.ToString()
            tmp += masterNodePublicAddress
            tmp += netSynchronizationData.hashNetwork
            tmp += netSynchronizationData.hashChain
            tmp += netSynchronizationData.identifierTransactionLedger
            tmp += netSynchronizationData.progressiveHash

            For Each rejected In rejectedRequestData
                tmp += rejected.toString()
            Next

            tmp += proposalsForApprovalData.toString()

            For Each requestApproved In requestApprovedList
                With requestApproved.Value
                    tmp += .bulletinTimeStamp
                    tmp += .masterNodePublicAddress
                    tmp += .requestHash
                    tmp += .voteValue.ToString()
                    tmp += .hash
                    tmp += .signature
                End With
            Next

            For Each absence In masternodeAbsent
                tmp += absence.toString()
            Next

            Return tmp
        End Function

        Public Function getHash() As String
            Return HashSHA.generateSHA256(Me.toString())
        End Function

        Public Property hash As String = ""
        Public Property signature As String = ""

    End Class

    Public Class ConsensusNetwork

        Public Property requestHash As String = ""

        Public Property nodeApproval As New Dictionary(Of String, RequestProcess.ReceiptOfApproval)
        Public Property nodeReject As New Dictionary(Of String, RequestProcess.RejectedRequest)
        Public Property nodeAdstained As New Dictionary(Of String, RequestProcess.RequestAbstention)
        Public Property nodeAbsent As New Dictionary(Of String, RequestProcess.MasterNodeCommunication)

        Public Property hash As String = ""
        Public Property signature As String = ""

        Public Overrides Function toString() As String
            Dim tmp As String = ""

            tmp += requestHash

            For Each item In nodeApproval
                tmp += item.Value.toString()
            Next
            For Each item In nodeReject
                tmp += item.Value.toString()
            Next
            For Each item In nodeAdstained
                tmp += item.Value.toString()
            Next
            For Each item In nodeAbsent
                tmp += item.Value.toString()
            Next

            Return tmp
        End Function

        Public Function getHash() As String
            Return HashSHA.generateSHA256(Me.toString())
        End Function

        Private Function reoderApproval() As Boolean
            Try
                Dim newList As New Dictionary(Of String, RequestProcess.ReceiptOfApproval)
                Dim minimal As RequestProcess.ReceiptOfApproval
                Dim current As RequestProcess.ReceiptOfApproval
                Dim indexMinimal As Integer

                Do While (nodeApproval.Count > 0)
                    indexMinimal = 0
                    minimal = nodeApproval.ElementAt(0).Value

                    For i As Integer = 1 To nodeApproval.Values.Count - 1
                        current = nodeApproval.ElementAt(i).Value

                        If (minimal.bulletinTimeStamp > current.bulletinTimeStamp) Then
                            minimal = current

                            indexMinimal = i
                        End If
                    Next

                    newList.Add(minimal.requestHash, minimal)
                    nodeApproval.Remove(minimal.requestHash)
                Loop

                nodeApproval = newList

                Return True
            Catch ex As Exception
                AreaCommon.log.track("ConsensusNetwork.reoderApproval", ex.Message, "fatal")

                Return False
            End Try
        End Function

        Private Function reoderReject() As Boolean
            Try
                Dim newList As New Dictionary(Of String, RequestProcess.RejectedRequest)
                Dim minimal As RequestProcess.RejectedRequest
                Dim current As RequestProcess.RejectedRequest
                Dim indexMinimal As Integer

                Do While (nodeApproval.Count > 0)

                    indexMinimal = 0
                    minimal = nodeReject.ElementAt(0).Value

                    For i As Integer = 1 To nodeReject.Values.Count - 1
                        current = nodeReject.ElementAt(i).Value

                        If (minimal.rejectTimeStamp > current.rejectTimeStamp) Then
                            minimal = current

                            indexMinimal = i
                        End If
                    Next

                    newList.Add(minimal.requestHash, minimal)
                    nodeApproval.Remove(minimal.requestHash)

                Loop

                nodeReject = newList

                Return True
            Catch ex As Exception
                AreaCommon.log.track("ConsensusNetwork.reoderReject", ex.Message, "fatal")

                Return False
            End Try
        End Function

        Private Function reoderAbstained() As Boolean
            Try
                Dim newList As New Dictionary(Of String, RequestProcess.RequestAbstention)
                Dim minimal As RequestProcess.RequestAbstention
                Dim current As RequestProcess.RequestAbstention
                Dim indexMinimal As Integer

                Do While (nodeApproval.Count > 0)

                    indexMinimal = 0
                    minimal = nodeAdstained.ElementAt(0).Value

                    For i As Integer = 1 To nodeAdstained.Values.Count - 1
                        current = nodeAdstained.ElementAt(i).Value

                        If (minimal.bulletinTimeStamp > current.bulletinTimeStamp) Then
                            minimal = current

                            indexMinimal = i
                        End If
                    Next

                    newList.Add(minimal.requestHash, minimal)
                    nodeAdstained.Remove(minimal.requestHash)

                Loop

                nodeAdstained = newList

                Return True
            Catch ex As Exception
                AreaCommon.log.track("ConsensusNetwork.reoderAbstained", ex.Message, "fatal")

                Return False
            End Try
        End Function

        Private Function reoderAbsent() As Boolean
            Try
                Dim newList As New Dictionary(Of String, RequestProcess.MasterNodeCommunication)
                Dim minimal As RequestProcess.MasterNodeCommunication
                Dim current As RequestProcess.MasterNodeCommunication
                Dim indexMinimal As Integer

                Do While (nodeAbsent.Count > 0)

                    indexMinimal = 0
                    minimal = nodeAbsent.ElementAt(0).Value

                    For i As Integer = 1 To nodeAbsent.Values.Count - 1
                        current = nodeAbsent.ElementAt(i).Value

                        If (minimal.bulletinTimeStamp > current.bulletinTimeStamp) Then
                            minimal = current

                            indexMinimal = i
                        End If
                    Next

                    newList.Add(minimal.requestHash, minimal)
                    nodeAdstained.Remove(minimal.requestHash)

                Loop

                nodeAbsent = newList

                Return True
            Catch ex As Exception
                AreaCommon.log.track("ConsensusNetwork.reoderAbsent", ex.Message, "fatal")

                Return False
            End Try
        End Function


        Public Function reorderElement() As Boolean
            Dim proceed As Boolean = True

            If proceed Then proceed = reoderApproval()
            If proceed Then proceed = reoderReject()
            If proceed Then proceed = reoderAbstained()
            If proceed Then proceed = reoderAbsent()

            Return proceed
        End Function

    End Class

    Public Class ConsensusNetworkFile

        Inherits CHCCommonLibrary.AreaEngine.DataFileManagement.XML.BaseFile(Of ConsensusNetwork)

    End Class

    Public Class ConsensusEngine

        Private _QueueProcessUpdateBulletin As New List(Of String)

        Public Property bulletin As New RequestProcess


        Private Function unlockUpdateBulletin(ByVal key As String) As Boolean
            Try
                _QueueProcessUpdateBulletin.Add(key)

                Do While (_QueueProcessUpdateBulletin(0).CompareTo(key) <> 0)
                    Threading.Thread.Sleep(10)
                Loop

                Return True
            Catch ex As Exception
                AreaCommon.log.track("ConsensusEngine.unlockUpdateBulletin", ex.Message, "fatal")

                Return False
            End Try
        End Function

        Private Function removeFromQueue(ByVal key As String) As Boolean
            Try
                _QueueProcessUpdateBulletin.Remove(key)

                Return True
            Catch ex As Exception
                AreaCommon.log.track("ConsensusEngine.unlockUpdateBulletin", ex.Message, "fatal")

                Return False
            End Try
        End Function

        Private Function checkAndCreateNewBulletin() As Boolean
            Try
                If (bulletin.bulletinTimeStamp = 0) Then
                    bulletin.bulletinTimeStamp = CHCCommonLibrary.AreaEngine.Miscellaneous.timestampFromDateTime()
                    bulletin.masterNodePublicAddress = AreaCommon.state.keys.key(TransactionChainLibrary.AreaEngine.KeyPair.KeysEngine.KeyPair.enumWalletType.identity).publicAddress

                    bulletin.netSynchronizationData.hashNetwork = AreaCommon.state.runtimeState.activeNetwork.networkName.recordHash
                    bulletin.netSynchronizationData.identifierTransactionLedger = AreaCommon.state.currentBlockLedger.currentRecord.id
                    bulletin.netSynchronizationData.progressiveHash = AreaCommon.state.currentBlockLedger.currentRecord.progressiveHash
                End If

                Return True
            Catch ex As Exception
                AreaCommon.log.track("ConsensusEngine.checkAndCreateNewBulletin", ex.Message, "fatal")

                Return False
            End Try
        End Function

        Private Function createRequestApproved(ByRef dataRequest As AreaFlow.RequestExtended) As RequestProcess.ReceiptOfApproval
            Try
                Dim result As New RequestProcess.ReceiptOfApproval
                Dim privateKeyRAW As String = AreaCommon.state.keys.key(TransactionChainLibrary.AreaEngine.KeyPair.KeysEngine.KeyPair.enumWalletType.identity).privateKey

                result.bulletinTimeStamp = bulletin.bulletinTimeStamp
                result.masterNodePublicAddress = bulletin.masterNodePublicAddress
                result.requestHash = dataRequest.requestHash

                result.hash = result.getHash()
                result.signature = CHCProtocolLibrary.AreaWallet.Support.WalletAddressEngine.createSignature(privateKeyRAW, result.hash)

                Return result
            Catch ex As Exception
                AreaCommon.log.track("ConsensusEngine.createRequestApproved", ex.Message, "fatal")

                Return New RequestProcess.ReceiptOfApproval
            End Try
        End Function

        Private Function updateAssessment(ByRef dataRequest As AreaFlow.RequestExtended) As Boolean
            Try
                Dim firstAssessmentData As AreaCommon.Masternode.MasternodeEvaluations.FirstAssessment
                Dim privateKeyRAW As String = AreaCommon.state.keys.key(TransactionChainLibrary.AreaEngine.KeyPair.KeysEngine.KeyPair.enumWalletType.identity).privateKey

                With bulletin.proposalsForApprovalData

                    firstAssessmentData = dataRequest.evaluations.getFirstAssessment(True)

                    If (.requestHash.Length = 0) Or (.dateFirstBulletinAssessmentTimeStamp < dataRequest.dateAssessment) Then

                        If (firstAssessmentData.dateFirstAssessment = 0) Then
                            firstAssessmentData.dateFirstAssessment = dataRequest.dateAssessment
                            firstAssessmentData.publicAddressMasternode = AreaCommon.state.keys.key(TransactionChainLibrary.AreaEngine.KeyPair.KeysEngine.KeyPair.enumWalletType.identity).publicAddress
                        End If

                        .requestHash = dataRequest.requestHash
                        .dateFirstBulletinAssessmentTimeStamp = firstAssessmentData.dateFirstAssessment
                        .firstMasternodeAssessment = firstAssessmentData.publicAddressMasternode
                        .NetworkTotalVotes = dataRequest.evaluations.currentChainNodeTotalVotes

                        .proposalIdentifierTransactionLedger = 1

                        .requestHash = dataRequest.requestHash
                        .totalVotes = dataRequest.evaluations.approved.totalValuePoints
                        .hash = .getHash()

                        .signature = CHCProtocolLibrary.AreaWallet.Support.WalletAddressEngine.createSignature(privateKeyRAW, .hash)

                    Else
                        If Not bulletin.requestApprovedList.ContainsKey(dataRequest.requestHash) Then
                            bulletin.requestApprovedList.Add(dataRequest.requestHash, createRequestApproved(dataRequest))
                        End If
                    End If

                End With

                bulletin.hash = bulletin.getHash()
                bulletin.signature = CHCProtocolLibrary.AreaWallet.Support.WalletAddressEngine.createSignature(privateKeyRAW, bulletin.hash)

                Return True
            Catch ex As Exception
                AreaCommon.log.track("ConsensusEngine.updateAssessment", ex.Message, "fatal")

                Return False
            End Try
        End Function

        Private Function updateReject(ByRef dataRequest As AreaFlow.RequestExtended) As Boolean
            Try
                Dim newItem As New RequestProcess.RejectedRequest

                For Each newItem In bulletin.rejectedRequestData
                    If newItem.requestHash.CompareTo(dataRequest.dateRequest) = 0 Then
                        Return True
                    End If
                Next

                newItem.rejectedMessage = dataRequest.rejectedNote
                newItem.rejectTimeStamp = dataRequest.dateAssessment
                newItem.requestHash = dataRequest.requestHash

                bulletin.rejectedRequestData.Add(newItem)

                Return True

            Catch ex As Exception
                AreaCommon.log.track("ConsensusEngine.updateReject", ex.Message, "fatal")

                Return False
            End Try
        End Function

        Private Function cloneBulletin() As RequestProcess
            Try
                Dim result As New RequestProcess
                Dim cloneReject As RequestProcess.RejectedRequest
                Dim masternode As RequestProcess.MasterNodeCommunication
                Dim singleRequest As RequestProcess.ReceiptOfApproval

                result.bulletinTimeStamp = bulletin.bulletinTimeStamp
                result.masterNodePublicAddress = bulletin.masterNodePublicAddress

                result.netSynchronizationData.hashNetwork = bulletin.netSynchronizationData.hashNetwork
                result.netSynchronizationData.identifierTransactionLedger = bulletin.netSynchronizationData.identifierTransactionLedger
                result.netSynchronizationData.progressiveHash = bulletin.netSynchronizationData.progressiveHash

                result.proposalsForApprovalData.dateFirstBulletinAssessmentTimeStamp = bulletin.proposalsForApprovalData.dateFirstBulletinAssessmentTimeStamp
                result.proposalsForApprovalData.deliveryToAllNetwork = bulletin.proposalsForApprovalData.deliveryToAllNetwork
                result.proposalsForApprovalData.firstMasternodeAssessment = bulletin.proposalsForApprovalData.firstMasternodeAssessment
                result.proposalsForApprovalData.signature = bulletin.proposalsForApprovalData.signature
                result.proposalsForApprovalData.NetworkTotalVotes = bulletin.proposalsForApprovalData.NetworkTotalVotes
                result.proposalsForApprovalData.hash = bulletin.proposalsForApprovalData.hash
                result.proposalsForApprovalData.proposalIdentifierTransactionLedger = bulletin.proposalsForApprovalData.proposalIdentifierTransactionLedger
                result.proposalsForApprovalData.requestHash = bulletin.proposalsForApprovalData.requestHash
                result.proposalsForApprovalData.totalVotes = bulletin.proposalsForApprovalData.totalVotes

                For Each rejected In bulletin.rejectedRequestData

                    cloneReject = New RequestProcess.RejectedRequest

                    cloneReject.rejectedMessage = rejected.rejectedMessage
                    cloneReject.rejectTimeStamp = rejected.rejectTimeStamp
                    cloneReject.requestHash = rejected.requestHash
                    cloneReject.signature = rejected.signature

                    result.rejectedRequestData.Add(cloneReject)

                Next

                For Each approved In bulletin.requestApprovedList

                    singleRequest = New RequestProcess.ReceiptOfApproval

                    singleRequest.bulletinTimeStamp = approved.Value.bulletinTimeStamp
                    singleRequest.hash = approved.Value.hash
                    singleRequest.masterNodePublicAddress = approved.Value.masterNodePublicAddress
                    singleRequest.requestHash = approved.Value.requestHash
                    singleRequest.signature = approved.Value.signature

                    result.requestApprovedList.Add(singleRequest.requestHash, singleRequest)
                Next

                For Each absence In bulletin.masternodeAbsent

                    masternode = New RequestProcess.MasterNodeCommunication

                    masternode.lastNotResponse = absence.lastNotResponse
                    masternode.publicAddress = absence.publicAddress
                    masternode.startNotResponse = absence.startNotResponse
                    masternode.tryNumber = absence.tryNumber

                    result.masternodeAbsent.Add(masternode)

                Next

                Return result
            Catch ex As Exception
                AreaCommon.log.track("ConsensusEngine.cloneBulletin", ex.Message, "fatal")

                Return New RequestProcess
            End Try
        End Function

        ''' <summary>
        ''' This method provide to clone a current bulletin and send a all node of the network
        ''' </summary>
        Private Function sendInBroadCast() As Boolean
            Try
                Dim listSender As AreaCommon.Masternode.MasternodeSenders
                Dim currentBulletin As RequestProcess

                currentBulletin = cloneBulletin()
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
        Private Function testNetwork(ByRef value As RequestProcess.NetSynchronization) As Boolean
            Return True
        End Function

        Private Function updateProposalRequest(ByVal bulletinTimeStamp As Double, ByVal masterNodePublicAddress As String, ByVal requestHash As String, ByVal approved As Boolean) As Boolean
            Try
                Dim request As AreaFlow.RequestExtended

                request = AreaCommon.flow.getRequestToProcess(requestHash)

                If (request.evaluations.notExpressed.getItem(masterNodePublicAddress).publicAddress.Length > 0) Then
                    If approved Then
                        Return request.evaluations.setApproved(masterNodePublicAddress, bulletinTimeStamp)
                    Else
                        Return request.evaluations.setRejected(masterNodePublicAddress, bulletinTimeStamp)
                    End If
                Else
                    Return True
                End If
            Catch ex As Exception
                AreaCommon.log.track("ConsensusEngine.sendInBroadCast", ex.Message, "fatal")

                Return False
            End Try
        End Function

        Private Function updateRejectRequest(ByVal bulletinTimeStamp As Double, ByVal masterNodePublicAddress As String, ByRef value As List(Of RequestProcess.RejectedRequest)) As Boolean
            Try
                Dim proceed As Boolean = True

                For Each item In value
                    If proceed Then
                        proceed = updateProposalRequest(bulletinTimeStamp, masterNodePublicAddress, item.requestHash, False)
                    End If
                Next

                Return proceed
            Catch ex As Exception
                AreaCommon.log.track("ConsensusEngine.sendInBroadCast", ex.Message, "fatal")

                Return False
            End Try
        End Function

        Private Function updateApprovalListData(ByVal bulletinTimeStamp As Double, ByVal masterNodePublicAddress As String, ByRef value As Dictionary(Of String, RequestProcess.ReceiptOfApproval)) As Boolean
            Try
                Dim proceed As Boolean = True

                For Each item In value
                    If proceed Then
                        proceed = updateProposalRequest(bulletinTimeStamp, masterNodePublicAddress, item.Value.requestHash, True)
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

                Select Case request.requestCode
                    Case "a0x0"
                End Select
            Catch ex As Exception
                AreaCommon.log.track("ConsensusEngine.updateLedger", ex.Message, "fatal")

                Return False
            End Try
        End Function

        Private Function createConsensusFile(ByVal dataRequest As AreaFlow.RequestExtended) As Boolean
            Try
                Dim file As New ConsensusNetworkFile
                Dim privateKeyRAW As String = AreaCommon.state.keys.key(TransactionChainLibrary.AreaEngine.KeyPair.KeysEngine.KeyPair.enumWalletType.identity).privateKey

                dataRequest.masterNodeExpressions.reorderElement()

                dataRequest.masterNodeExpressions.hash = dataRequest.masterNodeExpressions.getHash
                dataRequest.masterNodeExpressions.signature = CHCProtocolLibrary.AreaWallet.Support.WalletAddressEngine.createSignature(privateKeyRAW, dataRequest.masterNodeExpressions.hash)

                file.data = dataRequest.masterNodeExpressions

                file.fileName = ""

                Return file.save()
            Catch ex As Exception
                AreaCommon.log.track("ConsensusEngine.createConsensusFile", ex.Message, "fatal")

                Return False
            End Try
        End Function

        Public Function notifyAssessment(ByVal dataRequest As AreaFlow.RequestExtended) As Boolean
            Try
                Dim proceed As Boolean = True

                If unlockUpdateBulletin("MainAssessment-" & dataRequest.requestHash) Then
                    If proceed Then
                        proceed = checkAndCreateNewBulletin()
                    End If
                    If proceed Then
                        If (dataRequest.verifyPosition = AreaFlow.EnumOperationPosition.completeWithPositiveResult) Then
                            If Not bulletin.requestApprovedList.ContainsKey(dataRequest.requestHash) Then
                                bulletin.requestApprovedList.Add(dataRequest.requestHash, createRequestApproved(dataRequest))
                            End If

                            proceed = updateAssessment(dataRequest)
                        Else
                            proceed = updateReject(dataRequest)
                        End If
                    End If
                    If proceed Then
                        proceed = sendInBroadCast()
                    End If
                End If

                Return proceed
            Catch ex As Exception
                AreaCommon.log.track("ConsensusEngine.notifyAssessmentIntoBulletin", ex.Message, "fatal")

                Return False
            Finally
                removeFromQueue("MainAssessment-" & dataRequest.requestHash)
            End Try
        End Function

        Public Function notifyAllNetworkExpressAssessment(ByVal dataRequest As AreaFlow.RequestExtended) As Boolean
            Try
                If unlockUpdateBulletin("MainAssessment-" & dataRequest.requestHash) Then
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
                            proceed = updateLedger(dataRequest.requestHash)
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
                AreaCommon.log.track("ConsensusEngine.notifyAssessmentIntoBulletin", ex.Message, "fatal")

                Return False
            Finally
                removeFromQueue("MainAssessment-" & dataRequest.requestHash)
            End Try
        End Function

        Public Function processRemoteNotify(ByVal dataBulletin As AreaConsensus.RequestProcess) As Boolean
            Try
                Dim proceed As Boolean = True

                If proceed Then
                    proceed = testNetwork(dataBulletin.netSynchronizationData)
                End If
                If proceed Then
                    proceed = updateProposalRequest(dataBulletin.bulletinTimeStamp, dataBulletin.masterNodePublicAddress, dataBulletin.proposalsForApprovalData.requestHash, True)
                End If
                If proceed Then
                    proceed = updateRejectRequest(dataBulletin.bulletinTimeStamp, dataBulletin.masterNodePublicAddress, dataBulletin.rejectedRequestData)
                End If
                If proceed Then
                    proceed = updateApprovalListData(dataBulletin.bulletinTimeStamp, dataBulletin.masterNodePublicAddress, dataBulletin.requestApprovedList)
                End If

                Return True
            Catch ex As Exception
                AreaCommon.log.track("ConsensusEngine.notifyAssessmentIntoBulletin", ex.Message, "fatal")

                Return False
            End Try
        End Function

    End Class


End Namespace
