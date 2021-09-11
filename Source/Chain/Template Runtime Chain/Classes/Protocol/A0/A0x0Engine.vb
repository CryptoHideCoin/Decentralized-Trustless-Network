Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.Support
Imports CHCCommonLibrary.AreaEngine.DataFileManagement
Imports CHCCommonLibrary.AreaEngine.Encryption




Namespace AreaProtocol

    Public Class A0x0

        Public Class RequestModel

            Inherits CHCCommonLibrary.AreaCommon.Models.General.RemoteResponse

            Public Property requestCode As String = "A0x0"

            Public Property requestDateTimeStamp As Double = 0
            Public Property publicAddressRequester As String = ""
            Public Property requestHash As String = ""
            Public Property netName As String = ""

            Public Overrides Function toString() As String
                Dim tmp As String = ""

                tmp += requestDateTimeStamp.ToString()
                tmp += publicAddressRequester
                tmp += netName

                Return tmp
            End Function

            Public Function getHash() As String
                Return HashSHA.generateSHA256(Me.toString())
            End Function
        End Class

        Public Class FileEngine
            Inherits BaseFileDB(Of RequestModel)
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

            Shared Function verify(ByVal requestHash As String) As Boolean
                Try
                    Dim file As New FileEngine
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
                            proceed = AreaSecurity.checkSignature(file.data.requestHash, file.data.signature, file.data.publicAddressRequester)
                        End If
                    Else
                        proceed = False
                    End If

                    Return proceed
                Catch ex As Exception
                    Return False
                End Try
            End Function

            Shared Function evaluate(ByRef value As AreaFlow.RequestExtended) As Boolean
                Try
                    Dim file As New FileEngine
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
                    End If

                    Return proceed
                Catch ex As Exception
                    Return False
                End Try
            End Function

        End Class

        Public Class Manager

            Private data As New RequestModel

            Public Property log As LogEngine
            Public Property serviceState As CHCProtocolLibrary.AreaCommon.Models.Administration.ServiceStateResponse

            Private Property dateDeterminateApproved As Double
            Private Property approvedHash As String


            Private Function writeDataIntoLedger() As CHCCommonLibrary.AreaCommon.Models.General.IdentifyRecordLedger
                Try
                    With AreaCommon.state.currentBlockLedger.currentRecord
                        .actionCode = "a0x0"
                        .approvedDate = dateDeterminateApproved
                        .detailInformation = data.netName
                        .requester = data.publicAddressRequester
                        .requestHash = data.requestHash
                        .approvedHash = approvedHash
                    End With

                    If AreaCommon.state.currentBlockLedger.BlockComplete() Then
                        Return AreaCommon.state.currentBlockLedger.saveAndClean()
                    End If
                Catch ex As Exception
                    serviceState.currentAction.setError(Err.Number, ex.Message)

                    log.track("A0x0Manager.init", "Error:" & ex.Message, "error")
                End Try

                Return New CHCCommonLibrary.AreaCommon.Models.General.IdentifyRecordLedger
            End Function


            ''' <summary>
            ''' This method provide to create a initial procedure A0x0
            ''' </summary>
            ''' <param name="networkNameParameter"></param>
            ''' <param name="networkNameNode"></param>
            ''' <param name="networkCreationDate"></param>
            ''' <param name="publicWalletIdAddress"></param>
            ''' <param name="privateKeyRAW"></param>
            ''' <returns></returns>
            Public Function createGenesis(ByVal networkNameParameter As String, ByVal networkNameNode As String, ByVal networkCreationDate As Double, ByVal publicWalletIdAddress As String, ByVal privateKeyRAW As String) As Boolean
                Try
                    Dim requestFileEngine As New FileEngine

                    log.track("A0x0Manager.init", "Begin")

                    serviceState.currentAction.setAction("1x0001", "BuildManager - A0x0 - A0x0Manager")

                    If serviceState.requestCancelCurrentRunCommand Then Return False

                    If (networkNameParameter.CompareTo(networkNameNode) <> 0) Then
                        serviceState.currentAction.setError("-1", "Network not compatible")
                        serviceState.currentAction.reset()

                        log.track("A0x0Manager.init", "Error: Network not compatible", "error")

                        Return False
                    End If

                    data.netName = networkNameParameter
                    data.publicAddressRequester = publicWalletIdAddress
                    data.requestDateTimeStamp = networkCreationDate
                    data.requestHash = data.getHash
                    data.signature = CHCProtocolLibrary.AreaWallet.Support.WalletAddressEngine.createSignature(privateKeyRAW, data.requestHash)

                    requestFileEngine.data = data

                    requestFileEngine.fileName = IO.Path.Combine(AreaCommon.paths.workData.temporally, data.requestHash & ".request")

                    If requestFileEngine.save() Then
                        log.track("A0x0Manager.init", "request - Saved")

                        Return AreaCommon.flow.addNewRequest(data.requestHash, data.requestCode, data.requestDateTimeStamp, True)
                    End If
                Catch ex As Exception
                    serviceState.currentAction.setError(Err.Number, ex.Message)

                    log.track("A0x0Manager.init", "Error:" & ex.Message, "error")
                Finally
                    log.track("A0x0Manager.init", "Completed")
                End Try

                Return False
            End Function


            'Private Function toDo() As Boolean

            ' Dim ledgerCoordinate As CHCCommonLibrary.AreaCommon.Models.General.IdentifyRecordLedger
            '    If Not loadApprovedRequest(publicWalletIdAddress, privateKeyRAW) Then
            '        serviceState.currentAction.setError("-1", "Error during approved request")
            '        serviceState.currentAction.reset()

            '        log.track("A0x0Manager.init", "Error: Error during approved request", "error")

            '        Return False
            '    End If

            '    'If Not consensusWideningLedger() Then

            '    'End If

            '    ledgerCoordinate = writeDataIntoLedger()

            '    If (ledgerCoordinate.recordCoordinate.Length = 0) Then
            '        serviceState.currentAction.setError("-1", "Error during update ledger")
            '        serviceState.currentAction.reset()

            '        log.track("A0x0Manager.init", "Error: Error during update ledger", "error")

            '        Return False
            '    End If

            '    log.track("A0x0Manager.init", "Ledger updated")

            '    If Not RecoveryState.fromRequest(data, ledgerCoordinate) Then
            '        serviceState.currentAction.setError("-1", "Network not compatible")
            '        serviceState.currentAction.reset()

            '        log.track("A0x0Manager.init", "Error: Error during update State", "error")

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
            '        serviceState.currentAction.setError(Err.Number, ex.Message)

            '        log.track("A0x0Manager.loadApprovedRequest", "Error:" & ex.Message, "error")

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
            '        serviceState.currentAction.setError(Err.Number, ex.Message)

            '        log.track("A0x0Manager.consensusWideningLedger", "Error:" & ex.Message, "error")

            '        Return False
            '    End Try
            'End Function


        End Class

    End Class

End Namespace
