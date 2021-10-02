Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.DataFileManagement.XML
Imports CHCCommonLibrary.AreaEngine.Encryption
Imports CHCPrimaryRuntimeService.AreaCommon.Models.Network.Request

Namespace AreaProtocol

    Public Class A0x0

        Public Class RequestModel : Implements IRequestModel

            Public Property common As New CommonRequest Implements IRequestModel.common
            Public Property netName As String = ""
            Public Property signature As String Implements IRequestModel.signature

            Public Overrides Function toString() As String Implements IRequestModel.toString
                Dim tmp As String = common.toString()

                tmp += netName

                Return tmp
            End Function

            Public Function getHash() As String Implements IRequestModel.getHash
                Return HashSHA.generateSHA256(Me.toString())
            End Function

        End Class

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
            Public Property netName As String
                Get
                    Return _Base.netName
                End Get
                Set(value As String)
                    _Base.netName = value
                End Set
            End Property
            Public Property requestSignature As String Implements IRequestModel.signature
                Get
                    Return _Base.signature
                End Get
                Set(value As String)
                    _Base.signature = value
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

            Public Overrides Function toString() As String Implements IRequestModel.toString
                Return MyBase.toString() & _Base.toString()
            End Function
            Public Function getHash() As String Implements IRequestModel.getHash
                Return _Base.getHash()
            End Function

        End Class

        Public Class RecoveryState

            Public Shared Function fromRequest(ByRef value As RequestModel, ByRef transactionChainRecord As CHCCommonLibrary.AreaCommon.Models.General.IdentifyRecordLedger) As Boolean
                Dim proceed As Boolean = True

                If proceed Then
                    proceed = AreaCommon.state.runtimeState.addProperty(AreaState.ChainStateEngine.PropertyID.networkCreationDate, value.common.requestDateTimeStamp, transactionChainRecord.recordCoordinate, transactionChainRecord.recordHash)
                End If
                If proceed Then
                    proceed = AreaCommon.state.runtimeState.addProperty(AreaState.ChainStateEngine.PropertyID.genesisPublicAddress, value.common.publicAddressRequester, transactionChainRecord.recordCoordinate, transactionChainRecord.recordHash)
                End If
                If proceed Then
                    AreaCommon.state.runtimeState.addProperty(AreaState.ChainStateEngine.PropertyID.networkName, value.netName, transactionChainRecord.recordCoordinate, transactionChainRecord.recordHash)
                End If

                Return proceed
            End Function

            Public Shared Function fromTransactionLedger(ByRef value As TransactionChainLibrary.AreaLedger.LedgerEngine.SingleRecordLedger) As Boolean
                With AreaCommon.state.runtimeState.activeNetwork
                    .networkName.value = value.detailInformation
                    .networkCreationDate = value.registrationDate
                    .genesisPublicAddress = value.requesterPublicAddress
                End With

                Return True
            End Function

        End Class

        Public Class FormalCheck

            Shared Function verify(ByVal requestHash As String) As Nullable(Of Boolean)
                Try
                    Dim proceed As Boolean = True

                    With IOFast(Of RequestModel).read(IO.Path.Combine(AreaCommon.paths.workData.temporally, requestHash & ".request"))
                        If proceed Then
                            proceed = (.common.netWorkReferement.Length > 0)
                        End If
                        If proceed Then
                            proceed = (.common.requestDateTimeStamp <= CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime())
                        End If
                        If proceed Then
                            proceed = (.netName.Trim.Length > 0)
                        End If
                        If proceed Then
                            proceed = CHCProtocolLibrary.AreaWallet.Support.WalletAddressEngine.SingleKeyPair.checkFormatPublicAddress(.common.publicAddressRequester)
                        End If
                        If proceed Then
                            proceed = AreaSecurity.checkSignature(.getHash, .signature, .common.publicAddressRequester)
                        End If
                    End With

                    Return proceed
                Catch ex As Exception
                    Return Nothing
                End Try
            End Function

            Shared Function evaluate(ByRef value As AreaFlow.RequestExtended) As Nullable(Of Boolean)
                Try
                    Dim proceed As Boolean = True

                    With IOFast(Of RequestModel).read(IO.Path.Combine(AreaCommon.paths.workData.temporally, value.requestHash & ".request"))
                        If proceed Then
                            proceed = (.common.netWorkReferement.Length > 0)
                        End If
                        If proceed Then
                            If (.common.requestDateTimeStamp <= CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime(Now.AddDays(-1))) Then
                                value.rejectedNote = "Request expired"
                                value.generalStatus = AreaFlow.EnumOperationPosition.completeWithNegativeResult

                                Return True
                            End If
                            If (AreaCommon.state.network.position <> CHCRuntimeChainLibrary.AreaRuntime.AppState.EnumConnectionState.genesisOperation) Then
                                value.rejectedNote = "Not permitted"
                                value.generalStatus = AreaFlow.EnumOperationPosition.completeWithNegativeResult

                                Return True
                            End If
                            value.generalStatus = AreaFlow.EnumOperationPosition.completeWithPositiveResult
                        Else
                            proceed = False

                            value.rejectedNote = "Masternode problem"
                            value.generalStatus = AreaFlow.EnumOperationPosition.completeWithPositiveResult
                        End If
                    End With

                    Return proceed
                Catch ex As Exception
                    Return Nothing
                End Try
            End Function

        End Class

        Public Class Manager




            'Private Function writeDataIntoLedger() As CHCCommonLibrary.AreaCommon.Models.General.IdentifyRecordLedger
            '    Try
            '        With AreaCommon.state.currentBlockLedger.currentRecord
            '            .actionCode = "a0x0"
            '            .approvedDate = dateDeterminateApproved
            '            .detailInformation = data.netName
            '            .requester = data.publicAddressRequester
            '            .requestHash = data.requestHash
            '            .approvedHash = approvedHash
            '        End With

            '        If AreaCommon.state.currentBlockLedger.blockComplete() Then
            '            Return AreaCommon.state.currentBlockLedger.saveAndClean()
            '        End If
            '    Catch ex As Exception
            '        AreaCommon.state.currentService.currentAction.setError(Err.Number, ex.Message)

            '        AreaCommon.log.track("A0x0.Manager.init", ex.Message, "fatal")
            '    End Try

            '    Return New CHCCommonLibrary.AreaCommon.Models.General.IdentifyRecordLedger
            'End Function

            ''' <summary>
            ''' This method provide to return an RequestModel from RequestResponseModel
            ''' </summary>
            ''' <param name="value"></param>
            ''' <returns></returns>
            'Public Shared Function extractToRequest(ByRef value As RequestResponseModel) As RequestModel
            '    Dim result As New RequestModel
            '    Try
            '        result.netWorkReferement = value.netWorkReferement
            '        result.chainReferement = value.chainReferement
            '        result.netName = value.netName
            '        result.publicAddressRequester = value.publicAddressRequester
            '        result.requestDateTimeStamp = value.requestDateTimeStamp
            '        result.requestHash = value.requestHash
            '        result.requestSignature = value.requestSignature
            '    Catch ex As Exception
            '    End Try

            '    Return result
            'End Function

            ''' <summary>
            ''' This method provide to save a request into temporally position
            ''' </summary>
            ''' <param name="value"></param>
            ''' <returns></returns>
            Public Shared Function saveTemporallyRequest(ByRef value As RequestModel) As Boolean
                Try
                    Return IOFast(Of RequestModel).save(IO.Path.Combine(AreaCommon.paths.workData.temporally, value.getHash & ".request"), value)
                Catch ex As Exception
                    Return False
                End Try
            End Function

            ''' <summary>
            ''' This method provide to save a request into temporally position from RequestResponseModel
            ''' </summary>
            ''' <param name="value"></param>
            ''' <returns></returns>
            Public Shared Function saveTemporallyRequest(ByRef value As RequestResponseModel) As Boolean
                Return saveTemporallyRequest(value)
            End Function

            ''' <summary>
            ''' This method provide to create a initial procedure A0x0
            ''' </summary>
            ''' <param name="networkNameParameter"></param>
            ''' <returns></returns>
            Public Shared Function createRequest(ByVal networkNameParameter As String) As Boolean
                Try
                    Dim data As New RequestModel

                    AreaCommon.log.track("A0x0Manager.createRequest", "Begin")

                    AreaCommon.state.currentService.currentAction.setAction("1x0001", "BuildManager - A0x0 - A0x0Manager")

                    If AreaCommon.state.currentService.requestCancelCurrentRunCommand Then Return False

                    If (networkNameParameter.CompareTo(AreaCommon.state.internalInformation.networkName) <> 0) Then
                        AreaCommon.state.currentService.currentAction.setError("-1", "Network not compatible")
                        AreaCommon.state.currentService.currentAction.reset()

                        AreaCommon.log.track("A0x0Manager.createRequest", "Error: Network not compatible", "fatal")

                        Return False
                    End If

                    data.common.chainReferement = AreaCommon.state.internalInformation.chainName
                    data.common.requestCode = "A0x0"

                    With AreaCommon.state.keys.key(TransactionChainLibrary.AreaEngine.KeyPair.KeysEngine.KeyPair.enumWalletType.identity)
                        data.netName = networkNameParameter
                        data.common.netWorkReferement = networkNameParameter
                        data.common.publicAddressRequester = .publicAddress
                        data.common.requestDateTimeStamp = AreaCommon.state.runtimeState.activeNetwork.networkCreationDate
                        data.signature = CHCProtocolLibrary.AreaWallet.Support.WalletAddressEngine.createSignature(.privateKey, data.getHash())
                    End With

                    If saveTemporallyRequest(data) Then
                        AreaCommon.log.track("A0x0Manager.createRequest", "request - Saved")

                        Return AreaCommon.flow.addNewRequestDirect(data.getHash(), data.common.requestCode, data.common.requestDateTimeStamp, "")
                    End If
                Catch ex As Exception
                    AreaCommon.state.currentService.currentAction.setError(Err.Number, ex.Message)

                    AreaCommon.log.track("A0x0Manager.createRequest", ex.Message, "fatal")
                Finally
                    AreaCommon.log.track("A0x0Manager.createRequest", "Completed")
                End Try

                Return False
            End Function


            'Private Function toDo() As Boolean

            ' Dim ledgerCoordinate As CHCCommonLibrary.AreaCommon.Models.General.IdentifyRecordLedger
            '    If Not loadApprovedRequest(publicWalletIdAddress, privateKeyRAW) Then
            '        currentService.currentAction.setError("-1", "Error during approved request")
            '        currentService.currentAction.reset()

            '        log.track("A0x0Manager.init", "Error: Error during approved request", "fatal")

            '        Return False
            '    End If

            '    'If Not consensusWideningLedger() Then

            '    'End If

            '    ledgerCoordinate = writeDataIntoLedger()

            '    If (ledgerCoordinate.recordCoordinate.Length = 0) Then
            '        currentService.currentAction.setError("-1", "Error during update ledger")
            '        currentService.currentAction.reset()

            '        log.track("A0x0Manager.init", "Error: Error during update ledger", "fatal")

            '        Return False
            '    End If

            '    log.track("A0x0Manager.init", "Ledger updated")

            '    If Not RecoveryState.fromRequest(data, ledgerCoordinate) Then
            '        currentService.currentAction.setError("-1", "Network not compatible")
            '        currentService.currentAction.reset()

            '        log.track("A0x0Manager.init", "Error: Error during update State", "fatal")

            '        Return False
            '    End If

            'End Function

            'Private Function loadApprovedRequest(ByVal publicWalletIdAddress As String, ByVal privateKeyRAW As String) As Boolean
            '    Try
            '        Dim approved As New TransactionChainLibrary.AreaP2P.RequestModel
            '        Dim file As New TransactionChainLibrary.AreaP2P.FileRequestModel
            '        Dim fileName As String

            '        fileName = IO.Path.Combine(AreaCommon.paths.workData.currentVolume.evaluate, data.requestHash)

            '        IO.Directory.CreateDirectory(fileName)

            '        fileName = IO.Path.Combine(fileName, publicWalletIdAddress.Replace(":", "").Replace("/", "") & ".validate")

            '        dateDeterminateApproved = CHCCommonLibrary.AreaEngine.Miscellaneous.timestampFromDateTime()

            '        approved.publicAddressValidator = publicWalletIdAddress
            '        approved.dateDeterminateResult = dateDeterminateApproved
            '        approved.requestHash = data.requestHash
            '        approved.approved = True

            '        approved.signature = CHCProtocolLibrary.AreaWallet.Support.WalletAddressEngine.createSignature(privateKeyRAW, approved.getHash())

            '        approvedHash = approved.getHash()

            '        file.data = approved

            '        file.fileName = fileName

            '        Return file.save()
            '    Catch ex As Exception
            '        currentService.currentAction.setError(Err.Number, ex.Message)

            '        log.track("A0x0Manager.loadApprovedRequest", ex.Message, "fatal")

            '        Return False
            '    End Try
            'End Function

            'Private Function consensusWideningLedger() As Boolean
            '    Try
            '        Dim propose As New TransactionChainLibrary.AreaP2P.ProposeExtendedLedger

            '        propose.data.actionCode = "a0x0"
            '        propose.data.approvedDate = dateDeterminateApproved
            '        propose.data.approvedHash = approvedHash
            '        propose.data.detailInformation = data.netName
            '        propose.data.id = AreaCommon.state.currentBlockLedger.newIdTransaction
            '        propose.data.requester = data.publicAddressRequester
            '        propose.data.requestHash = data.requestHash
            '        propose.data.currentTotalHash = AreaCommon.state.currentBlockLedger.CurrentTotalHash
            '        propose.data.currentHash = propose.data.getHash()

            '        ' Send all information to all Peer

            '    Catch ex As Exception
            '        currentService.currentAction.setError(Err.Number, ex.Message)

            '        log.track("A0x0Manager.consensusWideningLedger", ex.Message, "fatal")

            '        Return False
            '    End Try
            'End Function


        End Class

    End Class

End Namespace
