Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.DataFileManagement.Json
Imports CHCCommonLibrary.AreaEngine.Encryption
Imports CHCPrimaryRuntimeService.AreaCommon.Models.Network.Request




Namespace AreaProtocol


    ''' <summary>
    ''' This enumeration contain the RoleMasterNode enumeration
    ''' </summary>
    Public Enum RoleMasterNode

        undefined
        fullStack
        consensus
        onlyQuery
        arbitration

    End Enum

    ''' <summary>
    ''' This class contain the document of a delegate information
    ''' </summary>
    Public Class DelegateGuarantee

        Public Property publicAddress As String = ""
        Public Property signature As String = ""

    End Class

    ''' <summary>
    ''' This class contain the masternode element data
    ''' </summary>
    Public Class RequestAddNewNode

        ''' <summary>
        ''' This class contain the element to identify the address configuration
        ''' </summary>
        Public Class AddressConfiguration

            Public Property main As Boolean = False
            Public Property addressIP As String = ""

            Public Overrides Function toString() As String
                Dim result As String

                If main Then
                    result = "1"
                Else
                    result = "0"
                End If

                result += addressIP

                Return result
            End Function

        End Class

        ''' <summary>
        ''' This class contain the information relative of a guarantee
        ''' </summary>
        Public Class GuaranteeInformation

            Public Property publicAddress As String = ""
            Public Property power As Decimal = 0

            Public Overrides Function toString() As String
                Dim result As String

                result = publicAddress
                result += power.ToString

                Return result
            End Function

        End Class

        Public Property guarantors As New List(Of GuaranteeInformation)
        Public Property refundPublicAddress As String = ""
        Public Property addressesIP As New List(Of AddressConfiguration)
        Public Property chainName As String = ""
        Public Property role As AreaProtocol.RoleMasterNode = AreaProtocol.RoleMasterNode.undefined
        Public Property autoDisconnectTimeStamp As Double = 0

        ''' <summary>
        ''' This method provide to convert to string the contain of this class
        ''' </summary>
        ''' <returns></returns>
        Public Overrides Function toString() As String
            Dim result As String = ""

            For Each singleGuarantee In guarantors
                result += singleGuarantee.toString()
            Next

            result += refundPublicAddress

            For Each singleAddress In addressesIP
                result += singleAddress.toString()
            Next

            result += chainName

            Select Case role
                Case RoleMasterNode.arbitration : result += "1"
                Case RoleMasterNode.consensus : result += "2"
                Case RoleMasterNode.fullStack : result += "3"
                Case RoleMasterNode.onlyQuery : result += "4"
            End Select

            result += autoDisconnectTimeStamp.ToString()

            Return result
        End Function

        ''' <summary>
        ''' This methdo provide to get an hash of the object
        ''' </summary>
        ''' <returns></returns>
        Public Overridable Function getHash() As String
            Return HashSHA.generateSHA256(Me.toString())
        End Function

        ''' <summary>
        ''' This method provide to get a primary address IP
        ''' </summary>
        ''' <returns></returns>
        Public Function getPrimaryAddress() As String
            For Each singleAddress In addressesIP
                If singleAddress.main Then
                    Return singleAddress.addressIP
                End If
            Next

            Return ""
        End Function

        ''' <summary>
        ''' This method provide to get a complessive power
        ''' </summary>
        ''' <returns></returns>
        Public Function getPower() As Decimal
            Dim total As Decimal = 0

            For Each singleGuarantee In guarantors
                total += singleGuarantee.power
            Next

            Return total
        End Function

        ''' <summary>
        ''' This method provide to add a new address IP into list
        ''' </summary>
        ''' <param name="address"></param>
        ''' <param name="main"></param>
        ''' <returns></returns>
        Public Function addNewAddressIP(ByVal address As String, ByVal main As Boolean) As Boolean
            Try
                Dim item As New AddressConfiguration

                item.addressIP = address
                item.main = main

                addressesIP.Add(item)

                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to add a new guarantee into list
        ''' </summary>
        ''' <param name="publicAddress"></param>
        ''' <param name="power"></param>
        ''' <returns></returns>
        Public Function addNewGuarantee(ByVal publicAddress As String, ByVal power As Decimal) As Boolean
            Try
                Dim item As New GuaranteeInformation

                item.publicAddress = publicAddress
                item.power = power

                guarantors.Add(item)

                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to clone an object
        ''' </summary>
        ''' <returns></returns>
        Public Function clone() As NodeComplete
            Try
                Dim item As New NodeComplete

                For Each singleGuarantor In guarantors
                    item.addNewGuarantee(singleGuarantor.publicAddress, singleGuarantor.power)
                Next

                item.refundPublicAddress = refundPublicAddress

                For Each singleAddress In addressesIP
                    item.addNewAddressIP(singleAddress.addressIP, singleAddress.main)
                Next

                item.chainName = chainName
                item.role = role
                item.autoDisconnectTimeStamp = autoDisconnectTimeStamp

                Return item
            Catch ex As Exception
                Return New RequestAddNewNode
            End Try
        End Function

    End Class

    ''' <summary>
    ''' This class contain all element to manage a A2x0 command
    ''' </summary>
    Public Class A2x0

        ''' <summary>
        ''' This class contain alla member of request model
        ''' </summary>
        Public Class RequestModel : Implements IRequestModel

            Public Property common As New CommonRequest Implements IRequestModel.common
            Public Property content As New RequestAddNewNode
            Public Property feeConfiguration As New CHCProtocolLibrary.AreaCommon.Models.Payments.FeeModel
            Public Property guaranteeDelegation As New List(Of DelegateGuarantee)

            ''' <summary>
            ''' This method provide to convert into a string the element of the object
            ''' </summary>
            ''' <returns></returns>
            Public Overrides Function toString() As String Implements IRequestModel.toString
                Dim tmp As String = common.toString()

                tmp += content.toString()
                tmp += feeConfiguration.toString()
                tmp += guaranteeDelegation.ToString()

                Return tmp
            End Function

            ''' <summary>
            ''' This methdo provide to get an hash of the object
            ''' </summary>
            ''' <returns></returns>
            Public Function getHash() As String Implements IRequestModel.getHash
                Return HashSHA.generateSHA256(Me.toString())
            End Function

            ''' <summary>
            ''' This method provide to add a new guarantee delegation into list
            ''' </summary>
            ''' <param name="publicAddress"></param>
            ''' <param name="signature"></param>
            ''' <returns></returns>
            Public Function addNewGuaranteeDelegation(ByVal publicAddress As String, ByVal signature As String) As Boolean
                Try
                    Dim item As New DelegateGuarantee

                    item.publicAddress = publicAddress
                    item.signature = signature

                    guaranteeDelegation.Add(item)

                    Return True
                Catch ex As Exception
                    Return False
                End Try
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
            Public Property content As RequestAddNewNode
                Get
                    Return _Base.content
                End Get
                Set(value As RequestAddNewNode)
                    _Base.content = value
                End Set
            End Property
            Public Property feeConfiguration As CHCProtocolLibrary.AreaCommon.Models.Payments.FeeModel
                Get
                    Return _Base.feeConfiguration
                End Get
                Set(value As CHCProtocolLibrary.AreaCommon.Models.Payments.FeeModel)
                    _Base.feeConfiguration = value
                End Set
            End Property
            Public Property guaranteeDelegation As List(Of DelegateGuarantee)
                Get
                    Return _Base.guaranteeDelegation
                End Get
                Set(value As List(Of DelegateGuarantee))
                    _Base.guaranteeDelegation = value
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
                    Dim hashContent As String = HashSHA.generateSHA256(value.content.toString())
                    Dim completefileName As String = IO.Path.Combine(AreaCommon.paths.workData.state.contents, hashContent) & ".Content"

                    AreaCommon.log.track("RecoveryState.fromRequest", "Begin")

                    If proceed Then
                        proceed = AreaCommon.state.runTimeState.addNewNodeToChain(value.common.publicAddressRequester, value.content, transactionChainRecord)
                    End If
                    If proceed Then
                        If IO.File.Exists(completefileName) Then
                            IO.File.Delete(completefileName)
                        End If
                        proceed = Not IO.File.Exists(completefileName)
                    End If
                    If proceed Then
                        proceed = IOFast(Of RequestAddNewNode).save(completefileName, value.content)
                    End If

                    AreaCommon.log.track("RecoveryState.fromRequest", "Completed")

                    Return proceed
                Catch ex As Exception
                    AreaCommon.log.track("RecoveryState.fromRequest", ex.Message, "fatal")

                    Return False
                End Try
            End Function

            Public Shared Function fromTransactionLedger(ByVal statePath As String, ByRef data As TransactionChainLibrary.AreaLedger.SingleTransactionLedger) As Boolean
                ''' TODO: A1x8 RecoveryState.fromTransactionLedger
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
                    Dim found As Boolean = False

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
                        proceed = (request.common.chainReferement.CompareTo(AreaCommon.state.internalInformation.chainName) = 0)
                    End If
                    If proceed Then
                        proceed = (request.common.requestDateTimeStamp <= CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime())
                    End If
                    If proceed Then
                        proceed = (request.content.chainName.Length > 0)
                    End If
                    If proceed Then
                        proceed = (request.content.addressesIP.Count > 0)
                    End If
                    If proceed Then
                        proceed = (request.content.role > RoleMasterNode.undefined)
                    End If
                    If proceed Then
                        proceed = (request.content.guarantors.Count > 0)
                    End If
                    For Each singleGuarantee In request.content.guarantors
                        If proceed Then
                            proceed = CHCProtocolLibrary.AreaWallet.Support.WalletAddressEngine.SingleKeyPair.checkFormatPublicAddress(singleGuarantee.publicAddress)
                        End If
                        If proceed Then
                            proceed = (singleGuarantee.power > 0)
                        End If
                        If proceed Then
                            If (singleGuarantee.publicAddress.CompareTo(request.common.publicAddressRequester) <> 0) Then
                                found = False

                                For Each singleDelegate In request.guaranteeDelegation
                                    If (singleDelegate.publicAddress.CompareTo(singleGuarantee.publicAddress) = 0) Then
                                        found = True

                                        proceed = AreaSecurity.checkSignature(request.getHash, singleDelegate.signature, singleDelegate.publicAddress)
                                    End If
                                Next

                                If proceed Then
                                    If Not found Then
                                        proceed = False
                                    End If
                                End If
                            End If
                        End If
                    Next
                    If proceed Then
                        proceed = CHCProtocolLibrary.AreaWallet.Support.WalletAddressEngine.SingleKeyPair.checkFormatPublicAddress(request.content.refundPublicAddress)
                    End If
                    If proceed Then
                        proceed = CHCProtocolLibrary.AreaWallet.Support.WalletAddressEngine.SingleKeyPair.checkFormatPublicAddress(request.common.publicAddressRequester)
                    End If
                    If proceed Then
                        If (request.feeConfiguration.exempionCode.CompareTo("ESENTION") = 0) Then
                            If (request.feeConfiguration.exempionReferement.CompareTo("Build network") = 0) Then
                                proceed = (AreaCommon.state.network.position = CHCRuntimeChainLibrary.AreaRuntime.AppState.EnumConnectionState.genesisOperation)
                            End If
                        End If
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
                    Dim request As RequestModel = value.data

                    AreaCommon.log.track("FormalCheck.evaluate", "Begin")

                    If (request.common.requestDateTimeStamp <= CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime(Now.ToUniversalTime.AddDays(-1))) Then
                        value.evaluations.rejectedNote = "Request expired"
                        value.position.verify = AreaFlow.EnumOperationPosition.completeWithNegativeResult

                        Return True
                    End If
                    If (AreaCommon.state.internalInformation.chainName.CompareTo(request.common.chainReferement) <> 0) Then
                        value.evaluations.rejectedNote = "Chain not exist"
                        value.position.verify = AreaFlow.EnumOperationPosition.completeWithNegativeResult

                        Return True
                    End If

                    If Not AreaCommon.state.runTimeState.chainByName.ContainsKey(request.content.chainName) Then
                        value.evaluations.rejectedNote = "Chain not exist"
                        value.position.verify = AreaFlow.EnumOperationPosition.completeWithNegativeResult

                        Return True
                    End If

                    If AreaCommon.state.network.position <> CHCRuntimeChainLibrary.AreaRuntime.AppState.EnumConnectionState.genesisOperation Then
                        If AreaCommon.state.runTimeState.chainByName(request.content.chainName).internalNodeList.ContainsKey(request.common.publicAddressRequester) Then
                            value.evaluations.rejectedNote = "Node already exist"
                            value.position.verify = AreaFlow.EnumOperationPosition.completeWithNegativeResult

                            Return True
                        End If
                    End If

                    ''' TODO: Test if the addressIP respond

                    ''' TODO: Test if the coin avaiable (the requester) is sustain (for the fee paiement)

                    ''' TODO: Test if the coin avaiable (the guarantee) is sustain (for the lock of warranty)

                    ''' TODO: Test if the last close block is correct (exclude the new chain)

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
            Shared Function addIntoLedger(ByVal approverPublicAddress As String, ByVal consensusHash As String, ByVal registrationTimeStamp As String, ByVal value As RequestAddNewNode, ByVal requesterPublicAddress As String, ByVal requestHash As String) As CHCCommonLibrary.AreaCommon.Models.General.IdentifyLastTransaction
                Try
                    Dim contentPath As String = AreaCommon.state.currentBlockLedger.proposeNewTransaction.pathData.contents
                    Dim hash As String = value.getHash()

                    AreaCommon.log.track("A2x0.Manager.addIntoLedger", "Begin")

                    contentPath = IO.Path.Combine(contentPath, hash & ".Content")

                    If IOFast(Of RequestAddNewNode).save(contentPath, value) Then
                        With AreaCommon.state.currentBlockLedger.proposeNewTransaction
                            .type = "a2x0"
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

                    AreaCommon.log.track("A2x0.Manager.addIntoLedger", ex.Message, "fatal")

                    Return New CHCCommonLibrary.AreaCommon.Models.General.IdentifyLastTransaction
                Finally
                    AreaCommon.log.track("A2x0.Manager.addIntoLedger", "Completed")
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
            ''' This method provide to save a request into temporally position from RequestResponseModel
            ''' </summary>
            ''' <param name="value"></param>
            ''' <returns></returns>
            Public Shared Function saveTemporallyRequest(ByRef value As RequestResponseModel) As Boolean
                Return saveTemporallyRequest(value)
            End Function

            ''' <summary>
            ''' This method provide to create a initial procedure A2x0
            ''' </summary>
            ''' <returns></returns>
            Shared Function createInternalRequest() As String
                Try
                    Dim data As New RequestModel

                    AreaCommon.log.track("A2x0Manager.createInternalRequest", "Begin")

                    If AreaCommon.state.currentService.requestCancelCurrentRunCommand Then Return False

                    With AreaCommon.state.keys.key(TransactionChainLibrary.AreaEngine.KeyPair.KeysEngine.KeyPair.enumWalletType.identity)
                        data.feeConfiguration.exempionCode = "ESENTION"
                        data.feeConfiguration.exempionReferement = "Build network"

                        data.content.autoDisconnectTimeStamp = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime + (14 * 24 * 60 * 60 * 1000)

                        data.content.addNewAddressIP(AreaCommon.state.internalInformation.addressIP, True)
                        data.content.addNewGuarantee(.publicAddress, 1)

                        data.content.role = RoleMasterNode.fullStack
                        data.content.refundPublicAddress = .publicAddress
                        data.content.chainName = "Primary"

                        data.common.netWorkReferement = AreaCommon.state.runTimeState.activeNetwork.hash
                        data.common.chainReferement = data.content.chainName
                        data.common.type = "a2x0"
                        data.common.publicAddressRequester = .publicAddress
                        data.common.requestDateTimeStamp = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()
                        data.common.hash = data.getHash()
                        data.common.signature = CHCProtocolLibrary.AreaWallet.Support.WalletAddressEngine.createSignature(.privateKey, data.common.hash)
                    End With

                    If saveTemporallyRequest(data) Then
                        AreaCommon.log.track("A2x0Manager.createInternalRequest", "request - Saved")

                        If AreaCommon.flow.addNewRequestDirect(data) Then
                            Return data.common.hash
                        Else
                            Return ""
                        End If
                    End If
                Catch ex As Exception
                    AreaCommon.state.currentService.currentAction.setError(Err.Number, ex.Message)

                    AreaCommon.log.track("A2x0Manager.createInternalRequest", ex.Message, "fatal")
                Finally
                    AreaCommon.log.track("A2x0Manager.createInternalRequest", "Completed")
                End Try

                Return ""
            End Function

        End Class

    End Class

End Namespace