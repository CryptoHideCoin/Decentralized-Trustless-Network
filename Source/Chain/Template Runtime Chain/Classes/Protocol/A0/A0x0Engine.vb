Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.Support
Imports CHCCommonLibrary.AreaEngine.DataFileManagement
Imports CHCCommonLibrary.AreaEngine.Encryption




Namespace AreaProtocol

    Public Class A0x0

        Public Class RequestModel

            Public Property netWorkReferement As String = ""
            Public Property chainReferement As String = ""
            Public Property requestCode As String = "A0x0"

            Public Property publicAddressRequester As String = ""
            Public Property requestDateTimeStamp As Double = 0
            Public Property netName As String = ""
            Public Property requestHash As String = ""
            Public Property requestSignature As String = ""

            Public Overrides Function toString() As String
                Dim tmp As String = ""

                tmp += netWorkReferement
                tmp += chainReferement
                tmp += requestCode
                tmp += requestDateTimeStamp.ToString()
                tmp += publicAddressRequester
                tmp += netName

                Return tmp
            End Function

            Public Function getHash() As String
                Return HashSHA.generateSHA256(Me.toString())
            End Function

        End Class

        Public Class RequestResponseModel

            Inherits CHCCommonLibrary.AreaCommon.Models.General.RemoteResponse

            Public Property netWorkReferement As String = ""
            Public Property chainReferement As String = ""
            Public Property requestCode As String = "A0x0"

            Public Property requestDateTimeStamp As Double = 0
            Public Property publicAddressRequester As String = ""
            Public Property netName As String = ""
            Public Property requestHash As String = ""
            Public Property requestSignature As String = ""

            Public Overrides Function toString() As String
                Dim tmp As String = ""

                tmp += netWorkReferement
                tmp += chainReferement
                tmp += requestCode
                tmp += requestDateTimeStamp.ToString()
                tmp += publicAddressRequester
                tmp += netName

                Return tmp
            End Function

            Public Function getHash() As String
                Return HashSHA.generateSHA256(Me.toString())
            End Function

        End Class

        Public Class RecoveryState

            Public Shared Function fromRequest(ByRef value As RequestModel, ByRef transactionChainRecord As CHCCommonLibrary.AreaCommon.Models.General.IdentifyRecordLedger) As Boolean
                Dim proceed As Boolean = True

                If proceed Then
                    proceed = AreaCommon.state.runtimeState.addProperty(AreaState.ChainStateEngine.PropertyID.networkCreationDate, value.requestDateTimeStamp, transactionChainRecord.recordCoordinate, transactionChainRecord.recordHash)
                End If
                If proceed Then
                    proceed = AreaCommon.state.runtimeState.addProperty(AreaState.ChainStateEngine.PropertyID.genesisPublicAddress, value.publicAddressRequester, transactionChainRecord.recordCoordinate, transactionChainRecord.recordHash)
                End If
                If proceed Then
                    AreaCommon.state.runtimeState.addProperty(AreaState.ChainStateEngine.PropertyID.networkName, value.netName, transactionChainRecord.recordCoordinate, transactionChainRecord.recordHash)
                End If

                Return proceed
            End Function

            Public Shared Function fromTransactionLedger(ByRef value As TransactionChainLibrary.AreaLedger.LedgerEngine.SingleRecordLedger) As Boolean
                With AreaCommon.state.runtimeState.activeNetwork
                    .networkName.value = value.detailInformation
                    .networkCreationDate = value.approvedDate
                    .genesisPublicAddress = value.requester
                End With

                Return True
            End Function

        End Class

        Public Class FormalCheck

            Shared Function verify(ByVal requestHash As String) As Nullable(Of Boolean)
                Try
                    Dim file As New IOFast(Of RequestModel)
                    Dim proceed As Boolean = True

                    file.fileName = IO.Path.Combine(AreaCommon.paths.workData.temporally, requestHash & ".request")

                    If file.read() Then
                        If proceed Then
                            proceed = (file.data.requestDateTimeStamp <= CHCCommonLibrary.AreaEngine.Miscellaneous.timestampFromDateTime())
                        End If
                        If proceed Then
                            proceed = (file.data.netName.Trim.Length > 0)
                        End If
                        If proceed Then
                            proceed = CHCProtocolLibrary.AreaWallet.Support.WalletAddressEngine.SingleKeyPair.checkFormatPublicAddress(file.data.publicAddressRequester)
                        End If
                        If proceed Then
                            proceed = AreaSecurity.checkSignature(file.data.requestHash, file.data.requestSignature, file.data.publicAddressRequester)
                        End If
                    Else
                        proceed = False
                    End If

                    Return proceed
                Catch ex As Exception
                    Return Nothing
                End Try
            End Function

            Shared Function evaluate(ByRef value As AreaFlow.RequestExtended) As Nullable(Of Boolean)
                Try
                    Dim file As New IOFast(Of RequestModel)
                    Dim proceed As Boolean = True

                    file.fileName = IO.Path.Combine(AreaCommon.paths.workData.temporally, value.requestHash & ".request")

                    If file.read() Then
                        If (file.data.requestDateTimeStamp <= CHCCommonLibrary.AreaEngine.Miscellaneous.timestampFromDateTime(Now.AddDays(-1))) Then
                            value.rejectedNote = "Request expired"
                            value.generalStatus = AreaFlow.RequestExtended.EnumOperationPosition.completeWithNegativeResult

                            Return True
                        End If
                        If (AreaCommon.state.network.position <> CHCRuntimeChainLibrary.AreaRuntime.AppState.EnumConnectionState.genesisOperation) Then
                            value.rejectedNote = "Not permitted"
                            value.generalStatus = AreaFlow.RequestExtended.EnumOperationPosition.completeWithNegativeResult

                            Return True
                        End If
                        value.generalStatus = AreaFlow.RequestExtended.EnumOperationPosition.completeWithPositiveResult
                    Else
                        proceed = False

                        value.rejectedNote = "Masternode problem"
                        value.generalStatus = AreaFlow.RequestExtended.EnumOperationPosition.completeWithPositiveResult
                    End If

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
            Public Shared Function extractToRequest(ByRef value As RequestResponseModel) As RequestModel
                Dim result As New RequestModel
                Try
                    result.netWorkReferement = value.netWorkReferement
                    result.chainReferement = value.chainReferement
                    result.netName = value.netName
                    result.publicAddressRequester = value.publicAddressRequester
                    result.requestDateTimeStamp = value.requestDateTimeStamp
                    result.requestHash = value.requestHash
                    result.requestSignature = value.requestSignature
                Catch ex As Exception
                End Try

                Return result
            End Function

            ''' <summary>
            ''' This method provide to save a request into temporally position
            ''' </summary>
            ''' <param name="value"></param>
            ''' <returns></returns>
            Public Shared Function saveTemporallyRequest(ByRef value As RequestModel) As Boolean
                Try
                    Dim requestFileEngine As New IOFast(Of RequestModel)

                    requestFileEngine.data = value
                    requestFileEngine.fileName = IO.Path.Combine(AreaCommon.paths.workData.temporally, value.requestHash & ".request")

                    Return requestFileEngine.save()
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
                Return saveTemporallyRequest(extractToRequest(value))
            End Function

            ''' <summary>
            ''' This method provide to create a initial procedure A0x0
            ''' </summary>
            ''' <param name="networkNameParameter"></param>
            ''' <returns></returns>
            Public Shared Function createRequest(ByVal networkNameParameter As String) As Boolean
                Try
                    Dim data As New RequestModel

                    AreaCommon.log.track("A0x0Manager.init", "Begin")

                    AreaCommon.state.currentService.currentAction.setAction("1x0001", "BuildManager - A0x0 - A0x0Manager")

                    If AreaCommon.state.currentService.requestCancelCurrentRunCommand Then Return False

                    If (networkNameParameter.CompareTo(AreaCommon.state.internalInformation.networkName) <> 0) Then
                        AreaCommon.state.currentService.currentAction.setError("-1", "Network not compatible")
                        AreaCommon.state.currentService.currentAction.reset()

                        AreaCommon.log.track("A0x0Manager.init", "Error: Network not compatible", "fatal")

                        Return False
                    End If

                    With AreaCommon.state.keys.key(TransactionChainLibrary.AreaEngine.KeyPair.KeysEngine.KeyPair.enumWalletType.identity)
                        data.netName = networkNameParameter
                        data.publicAddressRequester = .publicAddress
                        data.requestDateTimeStamp = AreaCommon.state.runtimeState.activeNetwork.networkCreationDate
                        data.requestHash = data.getHash
                        data.requestSignature = CHCProtocolLibrary.AreaWallet.Support.WalletAddressEngine.createSignature(.privateKey, data.requestHash)
                    End With

                    If saveTemporallyRequest(data) Then
                        AreaCommon.log.track("A0x0Manager.init", "request - Saved")

                        Return AreaCommon.flow.addNewRequestDirect(data.requestHash, data.requestCode, data.requestDateTimeStamp, "")
                    End If
                Catch ex As Exception
                    AreaCommon.state.currentService.currentAction.setError(Err.Number, ex.Message)

                    AreaCommon.log.track("A0x0Manager.init", ex.Message, "fatal")
                Finally
                    AreaCommon.log.track("A0x0Manager.init", "Completed")
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
