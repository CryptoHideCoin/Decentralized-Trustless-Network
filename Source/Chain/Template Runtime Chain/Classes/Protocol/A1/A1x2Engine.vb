Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.DataFileManagement.Json
Imports CHCCommonLibrary.AreaEngine.Encryption
Imports CHCPrimaryRuntimeService.AreaCommon.Models.Network.Request





Namespace AreaProtocol

    ''' <summary>
    ''' This class contain the minimal data Essential A1x2
    ''' </summary>
    Public Class EssentialA1x2

        Inherits CHCProtocolLibrary.AreaCommon.Models.Chain.ProtocolMinimalData

        Public Property approveConfiguration As New CHCProtocolLibrary.AreaCommon.Models.Authorization.ApproveModel
        Public Property feeConfiguration As New CHCProtocolLibrary.AreaCommon.Models.Payments.FeeModel

        ''' <summary>
        ''' This method provide to convert into a string the element of the object
        ''' </summary>
        ''' <returns></returns>
        Public Overrides Function toString() As String
            Dim result As String = ""

            result += MyBase.ToString()
            result += approveConfiguration.ToString()
            result += feeConfiguration.ToString()

            Return result
        End Function

        ''' <summary>
        ''' This method provide to extract minimal data from this request
        ''' </summary>
        ''' <returns></returns>
        Public Function extractMinimal() As CHCProtocolLibrary.AreaCommon.Models.Chain.ProtocolMinimalData
            Dim result As New CHCProtocolLibrary.AreaCommon.Models.Chain.ProtocolMinimalData

            result.setCode = MyBase.setCode
            result.protocol = MyBase.protocol
            result.documentation = MyBase.documentation

            Return result
        End Function

    End Class

    ''' <summary>
    ''' This class contain all element to manage a A1x2 command
    ''' </summary>
    Public Class A1x2

        ''' <summary>
        ''' This method contain a request model
        ''' </summary>
        Public Class RequestModel : Implements IRequestModel

            Public Property common As New CommonRequest Implements IRequestModel.common
            Public Property content As New EssentialA1x2

            ''' <summary>
            ''' This method provide to convert into a string the element of the object
            ''' </summary>
            ''' <returns></returns>
            Public Overrides Function toString() As String Implements IRequestModel.toString
                Dim tmp As String = common.toString()

                tmp += content.toString()

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
        ''' This method contain all element of a request response
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
            Public Property content As EssentialA1x2
                Get
                    Return _Base.content
                End Get
                Set(value As EssentialA1x2)
                    _Base.content = value
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
            Public Shared Function fromRequest(ByRef value As RequestModel, ByRef transactionChainRecord As CHCCommonLibrary.AreaCommon.Models.General.IdentifyLastTransaction) As Boolean
                Try
                    Dim proceed As Boolean = True
                    Dim content As CHCProtocolLibrary.AreaCommon.Models.Chain.ProtocolMinimalData = value.content
                    Dim hashContent As String = HashSHA.generateSHA256(content.ToString())
                    Dim completefileName As String = IO.Path.Combine(AreaCommon.paths.workData.state.contents, hashContent) & ".Content"

                    AreaCommon.log.track("RecoveryState.fromRequest", "Begin")

                    If proceed Then
                        proceed = AreaCommon.state.runTimeState.updateNewProtocol(value.common.chainReferement, content, transactionChainRecord)
                    End If
                    If proceed Then
                        If IO.File.Exists(completefileName) Then
                            IO.File.Delete(completefileName)
                        End If
                        proceed = Not IO.File.Exists(completefileName)
                    End If
                    If proceed Then
                        proceed = IOFast(Of CHCProtocolLibrary.AreaCommon.Models.Chain.ProtocolMinimalData).save(completefileName, content)
                    End If

                    AreaCommon.log.track("RecoveryState.fromRequest", "Completed")

                    Return proceed
                Catch ex As Exception
                    AreaCommon.log.track("RecoveryState.fromRequest", ex.Message, "fatal")

                    Return False
                End Try
            End Function

            Public Shared Function fromTransactionLedger(ByRef value As TransactionChainLibrary.AreaLedger.SingleTransactionLedger) As Boolean
                ''' TODO: A0x0 RecoveryState.fromTransactionLedger
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

                    AreaCommon.log.track("FormalCheck.verify", "Begin")

                    With AreaCommon.flow.getActiveRequest(requestHash).data
                        If proceed Then
                            proceed = (.common.netWorkReferement.Length > 0)
                        End If
                        If proceed Then
                            proceed = (.common.netWorkReferement.CompareTo(AreaCommon.state.runtimeState.activeNetwork.hash) = 0)
                        End If
                        If proceed Then
                            proceed = (.common.chainReferement.length > 0)
                        End If
                        If proceed Then
                            proceed = (.common.chainReferement.CompareTo(AreaCommon.state.internalInformation.chainName) = 0)
                        End If
                        If proceed Then
                            proceed = (.common.requestDateTimeStamp <= CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime())
                        End If
                        If proceed Then
                            proceed = CHCProtocolLibrary.AreaWallet.Support.WalletAddressEngine.SingleKeyPair.checkFormatPublicAddress(.common.publicAddressRequester)
                        End If
                        If proceed Then
                            proceed = AreaSecurity.checkSignature(.getHash, .common.signature, .common.publicAddressRequester)
                        End If
                    End With

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
                    Dim request As RequestModel = value.data

                    AreaCommon.log.track("FormalCheck.evaluate", "Begin")

                    If (request.common.requestDateTimeStamp <= CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime(Now.ToUniversalTime.AddDays(-1))) Then
                        value.evaluations.rejectedNote = "Request expired"
                        value.position.verify = AreaFlow.EnumOperationPosition.completeWithNegativeResult

                        Return True
                    End If
                    If Not AreaCommon.state.runTimeState.chainByName.ContainsKey(request.common.chainReferement) Then
                        value.evaluations.rejectedNote = "Chain not exist"
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

            ''' <summary>
            ''' This method provide to write request into ledger
            ''' </summary>
            ''' <returns></returns>
            Shared Function addIntoLedger(ByVal approverPublicAddress As String, ByVal consensusHash As String, ByVal registrationTimeStamp As String, ByVal value As CHCProtocolLibrary.AreaCommon.Models.Chain.ProtocolMinimalData, ByVal requesterPublicAddress As String, ByVal requestHash As String) As CHCCommonLibrary.AreaCommon.Models.General.IdentifyLastTransaction
                Try
                    Dim contentPath As String = AreaCommon.state.currentBlockLedger.proposeNewTransaction.pathData.contents
                    Dim hash As String = value.getHash()

                    AreaCommon.log.track("A1x2.Manager.addIntoLedger", "Begin")

                    contentPath = IO.Path.Combine(contentPath, hash & ".Content")

                    If IOFast(Of CHCProtocolLibrary.AreaCommon.Models.Chain.ProtocolMinimalData).save(contentPath, value) Then
                        With AreaCommon.state.currentBlockLedger.proposeNewTransaction
                            .type = "a1x2"
                            .approverPublicAddress = approverPublicAddress
                            .consensusHash = consensusHash
                            .detailInformation = hash
                            .registrationTimeStamp = registrationTimeStamp
                            .requesterPublicAddress = requesterPublicAddress
                            .requestHash = requestHash
                            .currentHash = .getHash
                        End With

                        Return AreaCommon.state.currentBlockLedger.saveAndClean()
                    Else
                        Return New CHCCommonLibrary.AreaCommon.Models.General.IdentifyLastTransaction
                    End If
                Catch ex As Exception
                    AreaCommon.state.currentService.currentAction.setError(Err.Number, ex.Message)

                    AreaCommon.log.track("A1x2.Manager.addIntoLedger", ex.Message, "fatal")

                    Return New CHCCommonLibrary.AreaCommon.Models.General.IdentifyLastTransaction
                Finally
                    AreaCommon.log.track("A1x2.Manager.addIntoLedger", "Completed")
                End Try
            End Function

            ''' <summary>
            ''' This method provide to save a request into temporally position
            ''' </summary>
            ''' <param name="value"></param>
            ''' <returns></returns>
            Public Shared Function saveTemporallyRequest(ByRef value As RequestModel) As Boolean
                Try
                    Return IOFast(Of RequestModel).save(IO.Path.Combine(AreaCommon.paths.workData.requestData.received, value.getHash & ".request"), value)
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
            ''' This method provide to load a request from a repository
            ''' </summary>
            ''' <param name="hash"></param>
            ''' <returns></returns>
            Public Shared Function loadRequest(ByVal completePath As String, ByVal hash As String) As RequestModel
                Try
                    Return IOFast(Of RequestModel).read(IO.Path.Combine(completePath, hash & ".request"))
                Catch ex As Exception
                    Return New RequestModel
                End Try
            End Function

            ''' <summary>
            ''' This method provide to create a initial procedure A1x1
            ''' </summary>
            ''' <param name="setCode"></param>
            ''' <param name="protocol"></param>
            ''' <param name="documentation"></param>
            ''' <returns></returns>
            Public Shared Function createInternalRequest(ByVal setCode As String, ByVal protocol As String, ByVal documentation As String) As String
                Try
                    Dim data As New RequestModel

                    AreaCommon.log.track("A1x2Manager.createInternalRequest", "Begin")

                    AreaCommon.state.currentService.currentAction.setAction("11x0001", "A1x2 - A1x2Manager")

                    If AreaCommon.state.currentService.requestCancelCurrentRunCommand Then Return False

                    With AreaCommon.state.keys.key(TransactionChainLibrary.AreaEngine.KeyPair.KeysEngine.KeyPair.enumWalletType.identity)
                        data.content.setCode = setCode
                        data.content.protocol = protocol
                        data.content.documentation = documentation
                        data.common.netWorkReferement = AreaCommon.state.runTimeState.activeNetwork.hash
                        data.common.chainReferement = AreaCommon.state.internalInformation.chainName
                        data.common.type = "a1x2"
                        data.common.publicAddressRequester = .publicAddress
                        data.common.requestDateTimeStamp = AreaCommon.state.runTimeState.activeNetwork.networkCreationDate
                        data.common.hash = data.getHash()
                        data.common.signature = CHCProtocolLibrary.AreaWallet.Support.WalletAddressEngine.createSignature(.privateKey, data.common.hash)
                    End With

                    If saveTemporallyRequest(data) Then
                        AreaCommon.log.track("A1x2Manager.createInternalRequest", "request - Saved")

                        If AreaCommon.flow.addNewRequestDirect(data) Then
                            Return data.common.hash
                        Else
                            Return ""
                        End If
                    End If
                Catch ex As Exception
                    AreaCommon.state.currentService.currentAction.setError(Err.Number, ex.Message)

                    AreaCommon.log.track("A1x2Manager.createInternalRequest", ex.Message, "fatal")
                Finally
                    AreaCommon.log.track("A1x2Manager.createInternalRequest", "Completed")
                End Try

                Return ""
            End Function

        End Class

    End Class

End Namespace
