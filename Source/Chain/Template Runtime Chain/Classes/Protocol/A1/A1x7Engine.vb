Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.DataFileManagement.Json
Imports CHCCommonLibrary.AreaEngine.Encryption
Imports CHCPrimaryRuntimeService.AreaCommon.Models.Network.Request
Imports CHCProtocolLibrary.AreaCommon.Models.Ledger





Namespace AreaProtocol

    ''' <summary>
    ''' This class contain the information of first request data
    ''' </summary>
    Public Class FirstRequestData
        Public Property data As String = ""
        Public Property minimalRequestClose As Double = 0
    End Class


    ''' <summary>
    ''' This class contain all element to manage a A1x7 command
    ''' </summary>
    Public Class A1x7

        ''' <summary>
        ''' This class contain all member of request model
        ''' </summary>
        Public Class RequestModel : Implements IRequestModel

            Public Property common As New CommonRequest Implements IRequestModel.common

            ''' <summary>
            ''' This method provide to convert into a string the element of the object
            ''' </summary>
            ''' <returns></returns>
            Public Overrides Function toString() As String Implements IRequestModel.toString
                Dim tmp As String = common.toString()

                Return tmp
            End Function

            ''' <summary>
            ''' This methdo provide to get an hash of the object
            ''' </summary>
            ''' <returns></returns>
            Public Function getHash() As String Implements IRequestModel.getHash
                Return HashSHA.generateSHA256(Me.toString())
            End Function

        End Class

        ''' <summary>
        ''' This class contain all element of a request response
        ''' </summary>
        Public Class RequestResponseModel

            Inherits CHCCommonLibrary.AreaCommon.Models.General.RemoteResponse : Implements IRequestModel

            Private _Base As New RequestModel

            Public Property common As CommonRequest Implements IRequestModel.common
                Get
                    Return _Base.common
                End Get
                Set(value As CommonRequest)
                    _Base.common = value
                End Set
            End Property
            Public Overrides Property signature As String
                Get
                    Return MyBase.signature
                End Get
                Set(value As String)
                    MyBase.signature = value
                End Set
            End Property

            ''' <summary>
            ''' This method provide to create a string of an element of this object
            ''' </summary>
            ''' <returns></returns>
            Public Overrides Function toString() As String Implements IRequestModel.toString
                Return MyBase.ToString() & _Base.toString()
            End Function

            ''' <summary>
            ''' This method provide to get the hash of this object
            ''' </summary>
            ''' <returns></returns>
            Public Function getHash() As String Implements IRequestModel.getHash
                Return _Base.getHash()
            End Function

        End Class

        ''' <summary>
        ''' This class contain all static member to recovery state 
        ''' </summary>
        Public Class RecoveryState

            ''' <summary>
            ''' This method provide to update the state from a request
            ''' </summary>
            ''' <param name="value"></param>
            ''' <param name="transactionChainRecord"></param>
            ''' <returns></returns>
            Public Shared Function fromRequest(ByRef value As RequestModel, ByVal transactionChainRecord As CHCCommonLibrary.AreaCommon.Models.General.IdentifyLastTransaction) As Boolean
                Try
                    Dim proceed As Boolean = True
                    Dim contentPath As String = AreaCommon.paths.workData.state.contents

                    AreaCommon.log.track("RecoveryState.fromRequest", "Begin")

                    If proceed Then
                        proceed = AreaCommon.state.runtimeState.updateChainProperty(value.common.chainReferement, AreaCommon.DAO.DBChain.DetailPropertyID.lastTransactionBlock, transactionChainRecord.registrationTimeStamp, "", transactionChainRecord)
                    End If
                    If proceed Then
                        Manager.firstRequestCloseBlock.data = ""
                        Manager.firstRequestCloseBlock.minimalRequestClose = 0
                    End If

                    AreaCommon.log.track("RecoveryState.fromRequest", "Completed")

                    Return proceed
                Catch ex As Exception
                    AreaCommon.log.track("RecoveryState.fromRequest", ex.Message, "fatal")

                    Return False
                End Try
            End Function

            Public Shared Function fromTransactionLedger(ByVal statePath As String, ByRef data As SingleTransactionLedger) As Boolean
                ''' TODO: A1x7 RecoveryState.fromTransactionLedger
            End Function

        End Class

        ''' <summary>
        ''' This class provides the static method to validate the request
        ''' </summary>
        Public Class FormalCheck

            ''' <summary>
            ''' This method provide to verify a formal request
            ''' </summary>
            ''' <param name="requestHash"></param>
            ''' <returns></returns>
            Shared Function verify(ByVal requestHash As String) As Nullable(Of Boolean)
                Try
                    Dim proceed As Boolean = True
                    Dim request As RequestModel = AreaCommon.flow.getActiveRequest(requestHash).data

                    AreaCommon.log.track("FormalCheck.verify", "Begin")

                    If proceed Then
                        proceed = (request.common.netWorkReferement.Length > 0)
                    End If
                    If proceed Then
                        proceed = (request.common.netWorkReferement.CompareTo(AreaCommon.state.runTimeState.activeNetwork.hash) = 0)
                    End If
                    If proceed Then
                        proceed = (request.common.chainReferement.Length > 0)
                    End If
                    If proceed Then
                        proceed = request.common.chainReferement.CompareTo(AreaCommon.state.internalInformation.chainName) = 0
                    End If
                    If proceed Then
                        proceed = (request.common.requestDateTimeStamp <= CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime())
                    End If
                    If proceed Then
                        proceed = CHCProtocolLibrary.AreaWallet.Support.WalletAddressEngine.SingleKeyPair.checkFormatPublicAddress(request.common.publicAddressRequester)
                    End If
                    If proceed Then
                        proceed = AreaSecurity.checkSignature(request.getHash, request.common.signature, request.common.publicAddressRequester)
                    End If

                    AreaCommon.log.track("FormalCheck.verify", "Completed")

                    Return proceed
                Catch ex As Exception
                    AreaCommon.log.track("FormalCheck.verify", ex.Message, "fatal")

                    Return Nothing
                End Try
            End Function

            ''' <summary>
            ''' This method provide to evaluate a request
            ''' </summary>
            ''' <param name="value"></param>
            ''' <returns></returns>
            Shared Function evaluate(ByRef value As AreaFlow.RequestExtended) As Boolean
                Try
                    Dim request As A1x7.RequestModel = value.data

                    AreaCommon.log.track("FormalCheck.evaluate", "Begin")

                    If (request.common.requestDateTimeStamp <= CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime(Now.ToUniversalTime.AddDays(-1))) Then
                        value.evaluations.rejectedNote = "Request expired"
                        value.position.verify = AreaFlow.EnumOperationPosition.completeWithNegativeResult

                        Return True
                    End If

                    value.position.verify = AreaFlow.EnumOperationPosition.completeWithPositiveResult

                    AreaCommon.log.track("FormalCheck.evaluate", "Completed")

                    Return True
                Catch ex As Exception
                    AreaCommon.log.track("FormalCheck.evaluate", ex.Message, "fatal")

                    Return False
                End Try
            End Function

        End Class

        ''' <summary>
        ''' This static class provides to static method to manage a request
        ''' </summary>
        Public Class Manager

            Shared Property firstRequestCloseBlock As New FirstRequestData
            Shared Property firstRequestCreateListMasterNode As New FirstRequestData


            ''' <summary>
            ''' This method provide to write request into ledger
            ''' </summary>
            ''' <returns></returns>
            Shared Function addIntoLedger(ByVal approverPublicAddress As String, ByVal consensusHash As String, ByVal registrationTimeStamp As String, ByVal requesterPublicAddress As String, ByVal requestHash As String) As CHCCommonLibrary.AreaCommon.Models.General.IdentifyLastTransaction
                Try
                    Dim contentPath As String = AreaCommon.state.ledger.proposeNewTransaction.pathData.contents

                    AreaCommon.log.track("A1x7.Manager.addIntoLedger", "Begin")

                    With AreaCommon.state.ledger.proposeNewTransaction
                        .type = "a1x7"
                        .approverPublicAddress = approverPublicAddress
                        .consensusHash = consensusHash
                        .detailInformation = ""
                        .registrationTimeStamp = registrationTimeStamp
                        .requesterPublicAddress = requesterPublicAddress
                        .requestHash = requestHash
                        .currentHash = .getHash
                    End With

                    Return AreaCommon.state.ledger.saveAndClean()
                Catch ex As Exception
                    AreaCommon.state.currentService.currentAction.setError(Err.Number, ex.Message)

                    AreaCommon.log.track("A1x7.Manager.addIntoLedger", ex.Message, "fatal")

                    Return New CHCCommonLibrary.AreaCommon.Models.General.IdentifyLastTransaction
                Finally
                    AreaCommon.log.track("A1x7.Manager.addIntoLedger", "Completed")
                End Try
            End Function

            ''' <summary>
            ''' This method provide to save a request into temporally position
            ''' </summary>
            ''' <param name="value"></param>
            ''' <returns></returns>
            Shared Function saveTemporallyRequest(ByRef value As RequestModel) As Boolean
                Try
                    Return IOFast(Of RequestModel).save(IO.Path.Combine(AreaCommon.paths.workData.requestData.received, value.getHash & ".Request"), value)
                Catch ex As Exception
                    Return False
                End Try
            End Function

            ''' <summary>
            ''' This method provide to load a request from a repository
            ''' </summary>
            ''' <param name="hash"></param>
            ''' <returns></returns>
            Shared Function loadRequest(ByVal completePath As String, ByVal hash As String) As RequestModel
                Try
                    Return IOFast(Of RequestModel).read(IO.Path.Combine(completePath, hash & ".Request"))
                Catch ex As Exception
                    Return New RequestModel
                End Try
            End Function

            ''' <summary>
            ''' This method provide to save a request into temporally position from RequestResponseModel
            ''' </summary>
            ''' <param name="value"></param>
            ''' <returns></returns>
            Shared Function saveTemporallyRequest(ByRef value As RequestResponseModel) As Boolean
                Return saveTemporallyRequest(value)
            End Function

            ''' <summary>
            ''' This method provide to create a initial procedure A1x7
            ''' </summary>
            ''' <returns></returns>
            Shared Function createInternalRequest() As String
                Try
                    Dim data As New RequestModel

                    AreaCommon.log.track("A1x7Manager.createInternalRequest", "Begin")

                    If AreaCommon.state.currentService.requestCancelCurrentRunCommand Then Return False

                    With AreaCommon.state.keys.key(TransactionChainLibrary.AreaEngine.KeyPair.KeysEngine.KeyPair.enumWalletType.identity)
                        data.common.netWorkReferement = AreaCommon.state.runTimeState.activeNetwork.hash
                        data.common.chainReferement = AreaCommon.state.internalInformation.chainName
                        data.common.type = "a1x7"
                        data.common.publicAddressRequester = .publicAddress
                        data.common.requestDateTimeStamp = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()
                        data.common.hash = data.getHash()
                        data.common.signature = CHCProtocolLibrary.AreaWallet.Support.WalletAddressEngine.createSignature(.privateKey, data.common.hash)
                    End With

                    If saveTemporallyRequest(data) Then
                        AreaCommon.log.track("A1x7Manager.createInternalRequest", "request - Saved")

                        If AreaCommon.flow.addNewRequestDirect(data) Then
                            Return data.common.hash
                        Else
                            Return ""
                        End If
                    End If
                Catch ex As Exception
                    AreaCommon.state.currentService.currentAction.setError(Err.Number, ex.Message)

                    AreaCommon.log.track("A1x7Manager.createInternalRequest", ex.Message, "fatal")
                Finally
                    AreaCommon.log.track("A1x7Manager.createInternalRequest", "Completed")
                End Try

                Return ""
            End Function

            ''' <summary>
            ''' This method provide to manage a close block
            ''' </summary>
            ''' <returns></returns>
            Shared Function manageCloseBlock() As Boolean
                Try
                    AreaCommon.log.track("A1x7Manager.manageCloseBlock", "Begin")

                    If (AreaCommon.state.runTimeState.activeChain.lastCloseBlock.value.Length = 0) Then Return False

                    Dim proceed As Boolean = True
                    Dim nextBlockClosedTimeStamp As Double = CDbl(AreaCommon.state.runTimeState.activeChain.lastCloseBlock.value) + AreaCommon.state.serviceParameters.blockSizeFrequency

                    If proceed Then
                        proceed = (CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime() > nextBlockClosedTimeStamp)
                    End If
                    If proceed Then
                        proceed = (firstRequestCloseBlock.data.Length = 0)
                    End If
                    If proceed Then
                        firstRequestCloseBlock.data = createInternalRequest()
                    End If
                    If proceed Then
                        proceed = (firstRequestCreateListMasterNode.data.Length = 0)
                    End If
                    If proceed Then
                        firstRequestCreateListMasterNode.data = A1x9.Manager.createInternalRequest()
                    End If

                    AreaCommon.log.track("A1x7Manager.manageCloseBlock", "Completed")

                    Return proceed
                Catch ex As Exception
                    AreaCommon.log.track("A1x7Manager.manageCloseBlock", ex.Message, "fatal")

                    Return False
                End Try
            End Function

            ''' <summary>
            ''' This method provide to create a post procedure a close block
            ''' </summary>
            ''' <param name="pathBlock"></param>
            Shared Sub postCloseBlock(ByVal pathBlock As CHCProtocolLibrary.AreaSystem.VirtualPathEngine.LedgerBlockPath)
                Try
                    Dim finalizeBlockEngine As New CHCLedgerLibrary.AreaLedger.LedgerSupportEngine
                    Dim proceed As Boolean = True, haveRejectOrTrash As Boolean = False
                    Dim requestBlockList As List(Of String)
                    Dim consensusBlockList As List(Of String)
                    Dim bulletinBlockList As List(Of String)
                    Dim requestList As List(Of String)
                    Dim internalList As List(Of String)

                    AreaCommon.log.track("A1x7Manager.postCloseBlock", "Begin")

                    finalizeBlockEngine.log = AreaCommon.log
                    finalizeBlockEngine.mainPath = pathBlock

                    With finalizeBlockEngine.headerData

                        .blockChainIdentity = AreaCommon.state.ledger.header.identifyLedger
                        .blockIdentity = AreaCommon.state.ledger.lastBlockClosed.blockIdentity
                        .hashBlock = AreaCommon.state.ledger.lastBlockClosed.hash
                        .chainReferement = AreaCommon.state.internalInformation.chainName
                        .netWorkReferement = AreaCommon.state.runTimeState.activeNetwork.hash

                    End With

                    If proceed Then
                        proceed = finalizeBlockEngine.init()
                    End If
                    If proceed Then
                        proceed = AreaCommon.state.ledger.updateBlockPath(AreaCommon.state.ledger.lastBlockClosed.blockIdentity, AreaCommon.state.ledger.lastBlockClosed.hash)
                    End If
                    If proceed Then
                        requestBlockList = AreaCommon.flow.getBlockList(AreaCommon.state.serviceParameters.minimalMaintainRequest)

                        proceed = (requestBlockList.Count > 0)
                    End If
                    If proceed Then
                        consensusBlockList = AreaCommon.flow.getBlockList(AreaCommon.state.serviceParameters.minimalMaintainConsensus)

                        proceed = (consensusBlockList.Count > 0)
                    End If
                    If proceed Then
                        bulletinBlockList = AreaCommon.flow.getBlockList(AreaCommon.state.serviceParameters.minimalMaintainBulletines)

                        proceed = (bulletinBlockList.Count > 0)
                    End If
                    If proceed Then
                        proceed = finalizeBlockEngine.removeOldFiles(AreaCommon.paths.workData.ledger, "Requests", requestBlockList)
                    End If
                    If proceed Then
                        proceed = finalizeBlockEngine.removeOldFiles(AreaCommon.paths.workData.ledger, "Consensus", consensusBlockList)
                    End If
                    If proceed Then
                        proceed = finalizeBlockEngine.removeOldFiles(AreaCommon.paths.workData.ledger, "Bulletines", bulletinBlockList)
                    End If
                    If proceed Then
                        proceed = AreaCommon.flow.removeOldRequestDB(AreaCommon.state.serviceParameters.minimalMaintainRequest)
                    End If
                    If proceed Then
                        requestList = AreaCommon.flow.getFileList(AreaCommon.state.serviceParameters.minimalMaintainRejected, CHCLedgerLibrary.AreaEngine.Requests.RequestManager.RequestData.stateRequest.rejected)

                        If (requestList.Count > 0) Then
                            haveRejectOrTrash = True

                            proceed = finalizeBlockEngine.removeOldTemporallyRequest(AreaCommon.paths.workData.requestData.rejected, requestList)
                        End If
                    End If
                    If proceed Then
                        requestList = AreaCommon.flow.getFileList(AreaCommon.state.serviceParameters.minimalMaintainTrashed, CHCLedgerLibrary.AreaEngine.Requests.RequestManager.RequestData.stateRequest.trashed)

                        If (requestList.Count > 0) Then
                            haveRejectOrTrash = True

                            proceed = finalizeBlockEngine.removeOldTemporallyRequest(AreaCommon.paths.workData.requestData.trashed, requestList)
                        End If
                    End If
                    If proceed Then
                        If haveRejectOrTrash Then
                            proceed = AreaCommon.flow.removeOldRequestRejectedAndTrashedIntoDB(AreaCommon.state.serviceParameters.minimalMaintainTrashed)
                        End If
                    End If
                    If proceed Then
                        ' Insert the internalList journal

                    End If
                    If proceed Then
                        proceed = finalizeBlockEngine.finalizeSingleBlock(AreaCommon.paths.workData.ledger, requestBlockList)
                    End If

                    AreaCommon.log.track("A1x7Manager.postCloseBlock", "Completed")
                Catch ex As Exception
                    AreaCommon.log.track("A1x7Manager.postCloseBlock", ex.Message, "fatal")
                End Try
            End Sub

            ''' <summary>
            ''' This method provide to execute post approve into the ledger
            ''' </summary>
            ''' <returns></returns>
            Shared Function finalizeBlock(ByVal requestHash As String, ByVal currentBlock As String) As Boolean
                Try
                    Dim proceed As Boolean = True
                    Dim currentPath As CHCProtocolLibrary.AreaSystem.VirtualPathEngine.LedgerBlockPath = AreaCommon.state.ledger.approvedTransaction.pathData

                    AreaCommon.log.track("Manager.finalizeBlock", "Begin")

                    If proceed Then
                        firstRequestCloseBlock.data = ""
                        firstRequestCloseBlock.minimalRequestClose = 0

                        proceed = AreaCommon.state.ledger.changeBlock(AreaCommon.state.serviceParameters.numberBlockInVolume)
                    End If
                    If proceed Then
                        Dim work1 As New Threading.Thread(Sub() AreaProtocol.A1x7.Manager.postCloseBlock(currentPath))

                        work1.Start()
                    End If

                    AreaCommon.log.track("Manager.finalizeBlock", "Completed")

                    Return proceed
                Catch ex As Exception
                    AreaCommon.log.track("Manager.finalizeBlock", ex.Message, "fatal")

                    Return False
                End Try

            End Function

        End Class

    End Class

End Namespace