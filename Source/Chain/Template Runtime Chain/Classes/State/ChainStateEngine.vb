Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.Encryption
Imports CHCCommonLibrary.AreaEngine.DataFileManagement.Json






Namespace AreaState

    Public Class ChainStateEngine

        ''' <summary>
        ''' This class contain the last identify last transaction and a value
        ''' </summary>
        Public Class ItemIdentityStructure
            Inherits CHCCommonLibrary.AreaCommon.Models.General.IdentifyLastTransaction

            Public Property value As String = ""
        End Class

        ''' <summary>
        ''' This class contain all information reguard of complete asset information
        ''' </summary>
        Public Class NetworkAssetStructure
            Inherits CHCCommonLibrary.AreaCommon.Models.General.IdentifyLastTransaction

            Public Property value As New CHCProtocolLibrary.AreaCommon.Models.Network.AssetModel
        End Class

        ''' <summary>
        ''' This class contain the complete information of a network transaction structure
        ''' </summary>
        Public Class NetworkTransactionStructure
            Inherits CHCCommonLibrary.AreaCommon.Models.General.IdentifyLastTransaction

            Public Property value As New CHCProtocolLibrary.AreaCommon.Models.Network.TransactionChainModel
        End Class

        ''' <summary>
        ''' This class contain the complete information of a refund plan
        ''' </summary>
        Public Class NetworkRefundItemListStructure
            Inherits CHCCommonLibrary.AreaCommon.Models.General.IdentifyLastTransaction

            Public Property value As New CHCProtocolLibrary.AreaCommon.Models.Network.RefundItemList
        End Class

        ''' <summary>
        ''' This class contain all element of a network
        ''' </summary>
        Public Class DataNetwork

            Public Property networkName As New ItemIdentityStructure
            Public Property whitePaper As New ItemIdentityStructure
            Public Property yellowPaper As New ItemIdentityStructure
            Public Property primaryAssetData As New NetworkAssetStructure
            Public Property transactionChainSettings As New NetworkTransactionStructure
            Public Property privacyPolicy As New ItemIdentityStructure
            Public Property generalCondition As New ItemIdentityStructure

            Public Property refundPlan As New NetworkRefundItemListStructure

            Public Property networkCreationDate As Double = 0

            Public Property genesisPublicAddress As String = ""

            Public ReadOnly Property hash() As String
                Get
                    Return networkName.progressiveHash
                End Get
            End Property
        End Class


        Public Class ChainPriceListStructure
            Inherits CHCCommonLibrary.AreaCommon.Models.General.IdentifyLastTransaction

            Public Property value As New CHCProtocolLibrary.AreaCommon.Models.Network.ItemPriceTableListModel
        End Class

        ''' <summary>
        ''' This enumeration contain all list of chain property
        ''' </summary>
        Public Enum PropertyChainID

            notDefined
            chainCreationDate
            description
            protocolDocument
            priceList
            privacyPolicy
            generalCondition

        End Enum

        ''' <summary>
        ''' This class contain the element of a protocol set
        ''' </summary>
        Public Class ProtocolSetStructure

            Public Property data As New CHCProtocolLibrary.AreaCommon.Models.Chain.ProtocolMinimalData
            Public Property integrity As New ItemIdentityStructure

        End Class

        ''' <summary>
        ''' This enumeration contain all field (with additional information) of data chain
        ''' </summary>
        Public Class DataChain

            Public ReadOnly Property hash As String
                Get
                    Return name.progressiveHash
                End Get
            End Property
            Public Property name As New ItemIdentityStructure
            Public Property isPrivate As New ItemIdentityStructure
            Public Property description As New ItemIdentityStructure
            Public Property protocolSets As New List(Of ProtocolSetStructure)
            Public Property priceList As New ChainPriceListStructure
            Public Property privacyPolicy As New itemIdentityStructure
            Public Property generalCondition As New itemIdentityStructure

            Public Property creationDateLedger As Double = 0

        End Class


        Public Class DataMasternode

            Public Enum roleMasterNode

                fullService
                light
                frontOffice
                consensus
                arbitration

            End Enum

            Public Property identityPublicAddress As String = ""
            Public Property warrantyPublicAddress As String = ""
            Public Property refundPublicAddress As String = ""
            Public Property ipAddress As String = ""
            Public Property warrantyCoin As Decimal = 0
            Public Property votePoint As Decimal = 0
            Public Property chainName As String = ""
            Public Property role As roleMasterNode = roleMasterNode.arbitration
            Public Property startConnectionTimeStamp As Double = 0
            Public Property dayConnection As Short = 0
            Public Property lastConnectionTimeStamp As Double = 0
            Public Property itsMe As Boolean = False

            Public Property abstainRequest As New Dictionary(Of String, String)

        End Class

        Public Class DataMasternodeKey

            Public Property chainName As String = ""
            Public Property identityPublicAddress As String = ""

        End Class


        Private _DBNetwork As New AreaCommon.DAO.DBNetwork
        Private _DBChain As New AreaCommon.DAO.DBChain


        Public Property activeNetwork As New DataNetwork
        Public Property activeChain As New DataChain
        Public Property chainByName As New Dictionary(Of String, DataChain)
        Public Property chainByHash As New Dictionary(Of String, DataChain)

        Public Property activeMasterNode As New Dictionary(Of DataMasternodeKey, DataMasternode)


        ''' <summary>
        ''' This method provide to add a network property
        ''' </summary>
        ''' <param name="id"></param>
        ''' <param name="value"></param>
        ''' <param name="transactionChainRecord"></param>
        ''' <param name="hashContent"></param>
        ''' <param name="writeValueOnDB"></param>
        ''' <returns></returns>
        Public Function addNetworkProperty(ByVal id As AreaCommon.DAO.DBNetwork.MainPropertyID, ByVal value As String, ByRef transactionChainRecord As CHCCommonLibrary.AreaCommon.Models.General.IdentifyLastTransaction, Optional ByVal hashContent As String = "", Optional ByVal writeValueOnDB As Boolean = True) As Boolean
            Try
                Dim oldHashContent As String

                AreaCommon.log.track("ChainStateEngine.addNetworkProperty", "Begin")

                oldHashContent = _DBNetwork.getContentHash(id)

                If (oldHashContent.Length > 0) Then
                    Try
                        IO.File.Delete(IO.Path.Combine(AreaCommon.paths.workData.state.contents, oldHashContent) & ".content")
                    Catch ex As Exception
                    End Try
                End If

                If _DBNetwork.updatePropertNetworky(id, value, transactionChainRecord, hashContent, writeValueOnDB) Then
                    Select Case id
                        Case AreaCommon.DAO.DBNetwork.MainPropertyID.networkCreationDate : activeNetwork.networkCreationDate = value
                        Case AreaCommon.DAO.DBNetwork.MainPropertyID.genesisPublicAddress : activeNetwork.genesisPublicAddress = value
                        Case AreaCommon.DAO.DBNetwork.MainPropertyID.networkName
                            activeNetwork.networkName.value = value
                            activeNetwork.networkName.coordinate = transactionChainRecord.coordinate
                            activeNetwork.networkName.progressiveHash = transactionChainRecord.progressiveHash
                            activeNetwork.networkName.registrationTimeStamp = transactionChainRecord.registrationTimeStamp
                        Case AreaCommon.DAO.DBNetwork.MainPropertyID.whitePaper
                            activeNetwork.whitePaper.value = value
                            activeNetwork.whitePaper.coordinate = transactionChainRecord.coordinate
                            activeNetwork.whitePaper.progressiveHash = transactionChainRecord.progressiveHash
                            activeNetwork.whitePaper.registrationTimeStamp = transactionChainRecord.registrationTimeStamp
                        Case AreaCommon.DAO.DBNetwork.MainPropertyID.yellowPaper
                            activeNetwork.yellowPaper.value = value
                            activeNetwork.yellowPaper.coordinate = transactionChainRecord.coordinate
                            activeNetwork.yellowPaper.progressiveHash = transactionChainRecord.progressiveHash
                            activeNetwork.yellowPaper.registrationTimeStamp = transactionChainRecord.registrationTimeStamp
                        Case AreaCommon.DAO.DBNetwork.MainPropertyID.assetData
                            activeNetwork.primaryAssetData.coordinate = transactionChainRecord.coordinate
                            activeNetwork.primaryAssetData.progressiveHash = transactionChainRecord.progressiveHash
                            activeNetwork.primaryAssetData.registrationTimeStamp = transactionChainRecord.registrationTimeStamp
                        Case AreaCommon.DAO.DBNetwork.MainPropertyID.generalCondition
                            activeNetwork.generalCondition.value = value
                            activeNetwork.generalCondition.coordinate = transactionChainRecord.coordinate
                            activeNetwork.generalCondition.progressiveHash = transactionChainRecord.progressiveHash
                            activeNetwork.generalCondition.registrationTimeStamp = transactionChainRecord.registrationTimeStamp
                        Case AreaCommon.DAO.DBNetwork.MainPropertyID.privacyPolicy
                            activeNetwork.privacyPolicy.value = value
                            activeNetwork.privacyPolicy.coordinate = transactionChainRecord.coordinate
                            activeNetwork.privacyPolicy.progressiveHash = transactionChainRecord.progressiveHash
                            activeNetwork.privacyPolicy.registrationTimeStamp = transactionChainRecord.registrationTimeStamp
                        Case AreaCommon.DAO.DBNetwork.MainPropertyID.refundPlan
                            activeNetwork.refundPlan.coordinate = transactionChainRecord.coordinate
                            activeNetwork.refundPlan.progressiveHash = transactionChainRecord.progressiveHash
                            activeNetwork.refundPlan.registrationTimeStamp = transactionChainRecord.registrationTimeStamp
                        Case AreaCommon.DAO.DBNetwork.MainPropertyID.transactionChainConfiguration
                            activeNetwork.transactionChainSettings.coordinate = transactionChainRecord.coordinate
                            activeNetwork.transactionChainSettings.progressiveHash = transactionChainRecord.progressiveHash
                            activeNetwork.transactionChainSettings.registrationTimeStamp = transactionChainRecord.registrationTimeStamp
                    End Select

                    AreaCommon.log.track("ChainStateEngine.addNetworkProperty", "Complete")

                    Return True
                End If

            Catch ex As Exception
                AreaCommon.log.track("ChainStateEngine.addNetworkProperty", ex.Message, "fatal")
            End Try

            Return False
        End Function

        ''' <summary>
        ''' This method provide to add a new chain
        ''' </summary>
        ''' <param name="name"></param>
        ''' <param name="privateChain"></param>
        ''' <param name="description"></param>
        ''' <param name="transactionChainRecord"></param>
        ''' <returns></returns>
        Public Function addNewChain(ByVal name As String, ByVal privateChain As Boolean, ByVal description As String, ByRef transactionChainRecord As CHCCommonLibrary.AreaCommon.Models.General.IdentifyLastTransaction) As Boolean
            Try
                AreaCommon.log.track("ChainStateEngine.addNewChain", "Begin")

                Dim newValue As New DataChain
                Dim hash As String

                hash = _DBChain.insertSQLNewChain(name, privateChain, description, transactionChainRecord)

                If (hash.Length > 0) Then
                    newValue.name.value = name
                    newValue.name.coordinate = transactionChainRecord.coordinate
                    newValue.name.registrationTimeStamp = transactionChainRecord.registrationTimeStamp
                    newValue.name.progressiveHash = transactionChainRecord.progressiveHash

                    newValue.isPrivate.value = privateChain
                    newValue.isPrivate.coordinate = transactionChainRecord.coordinate
                    newValue.isPrivate.registrationTimeStamp = transactionChainRecord.registrationTimeStamp
                    newValue.isPrivate.progressiveHash = transactionChainRecord.progressiveHash

                    newValue.description.value = description
                    newValue.description.coordinate = transactionChainRecord.coordinate
                    newValue.description.registrationTimeStamp = transactionChainRecord.registrationTimeStamp
                    newValue.description.progressiveHash = transactionChainRecord.progressiveHash

                    If (newValue.name.value.CompareTo(AreaCommon.state.internalInformation.chainName) = 0) Then
                        AreaCommon.log.track("ChainStateEngine.addNewChain", "Set activeChain")

                        activeChain = newValue
                    End If

                    chainByHash.Add(hash, newValue)
                    chainByName.Add(name, newValue)
                End If

                AreaCommon.log.track("ChainStateEngine.addNewChain", "Complete")

                Return True
            Catch ex As Exception
                AreaCommon.log.track("ChainStateEngine.addNewChain", ex.Message, "fatal")

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to update a new protocol
        ''' </summary>
        ''' <param name="chainReferement"></param>
        ''' <param name="hashContent"></param>
        ''' <param name="transactionChainRecord"></param>
        ''' <returns></returns>
        Public Function updateNewProtocol(ByVal chainReferement As String, ByVal value As CHCProtocolLibrary.AreaCommon.Models.Chain.ProtocolMinimalData, ByVal hashContent As String, ByRef transactionChainRecord As CHCCommonLibrary.AreaCommon.Models.General.IdentifyLastTransaction) As Boolean
            Try
                AreaCommon.log.track("ChainStateEngine.updateNewProtocol", "Begin")

                Dim chain As DataChain
                Dim protocolData As New ProtocolSetStructure

                If _DBChain.updateProtocol(chainReferement, value, transactionChainRecord) Then
                    chain = chainByHash(chainReferement)

                    For Each item In chain.protocolSets
                        If (item.data.setCode.CompareTo(value.setCode) = 0) Then
                            chain.protocolSets.Remove(item)

                            Exit For
                        End If
                    Next

                    protocolData.data.setCode = value.setCode
                    protocolData.data.protocol = value.protocol
                    protocolData.data.documentation = value.documentation

                    protocolData.integrity.coordinate = transactionChainRecord.coordinate
                    protocolData.integrity.progressiveHash = transactionChainRecord.progressiveHash
                    protocolData.integrity.registrationTimeStamp = transactionChainRecord.registrationTimeStamp

                    chain.protocolSets.Add(protocolData)

                    Return True
                End If

                Return False
            Catch ex As Exception
                AreaCommon.log.track("ChainStateEngine.updateNewProtocol", ex.Message, "fatal")

                Return False
            Finally
                AreaCommon.log.track("ChainStateEngine.updateNewProtocol", "Complete")
            End Try
        End Function

        ''' <summary>
        ''' This method provide to update price list
        ''' </summary>
        ''' <returns></returns>
        Public Function updatePriceList(ByVal chainReferement As String, ByVal value As CHCProtocolLibrary.AreaCommon.Models.Network.ItemPriceTableListModel, ByVal hashContent As String, ByRef transactionChainRecord As CHCCommonLibrary.AreaCommon.Models.General.IdentifyLastTransaction) As Boolean
            Try
                AreaCommon.log.track("ChainStateEngine.updatePriceList", "Begin")

                Dim chain As DataChain
                Dim protocolData As New ProtocolSetStructure

                If _DBChain.updateDetail(chainReferement, AreaCommon.DAO.DBChain.DetailPropertyID.priceList, value, transactionChainRecord) Then
                    chain = chainByHash(chainReferement)

                    'chain.priceList = value

                    Return True
                End If

                Return False
            Catch ex As Exception
                AreaCommon.log.track("ChainStateEngine.updatePriceList", ex.Message, "fatal")

                Return False
            Finally
                AreaCommon.log.track("ChainStateEngine.updatePriceList", "Complete")
            End Try
        End Function

        ''' <summary>
        ''' This method return a chain by name
        ''' </summary>
        ''' <param name="name"></param>
        ''' <returns></returns>
        Public Function getDataChainByName(ByVal name As String) As DataChain
            If chainByName.ContainsKey(name) Then
                Return chainByName.Item(name)
            Else
                Return New DataChain
            End If
        End Function


        ''' <summary>
        ''' This method provide to add new node
        ''' </summary>
        ''' <param name="chainName"></param>
        ''' <param name="publicAddress"></param>
        ''' <returns></returns>
        Public Function addNewNode(ByVal chainName As String, Optional ByVal publicAddress As String = "") As DataMasternode
            Dim newValue As New DataMasternode

            Try
                Dim newKey As New DataMasternodeKey

                AreaCommon.log.track("ChainStateEngine.addNewNode", "Begin")

                newKey.chainName = chainName

                If (publicAddress.Length = 0) Then
                    publicAddress = AreaCommon.state.network.publicAddressIdentity

                    newValue.itsMe = True
                End If
                newKey.identityPublicAddress = publicAddress

                newValue.identityPublicAddress = publicAddress

                activeMasterNode.Add(newKey, newValue)

                AreaCommon.log.track("ChainStateEngine.addNewNode", "Complete")
            Catch ex As Exception
                AreaCommon.log.track("ChainStateEngine.addNewNode", ex.Message, "fatal")
            End Try

            Return newValue
        End Function

        ''' <summary>
        ''' This method provide to get an information relative a peer
        ''' </summary>
        ''' <param name="publicAddress"></param>
        ''' <param name="chainName"></param>
        ''' <returns></returns>
        Public Function getDataNode(ByVal publicAddress As String, Optional ByVal chainName As String = "") As DataMasternode
            Dim newKey As New DataMasternodeKey

            Try
                AreaCommon.log.track("ChainStateEngine.getDataPeer", "Begin")

                If (chainName.Length = 0) Then
                    newKey.chainName = AreaCommon.state.internalInformation.chainName
                Else
                    newKey.chainName = chainName
                End If
                newKey.identityPublicAddress = publicAddress

                If activeMasterNode.ContainsKey(newKey) Then
                    Return activeMasterNode.Item(newKey)
                End If
            Catch ex As Exception
                AreaCommon.log.track("ChainStateEngine.getDataPeer", ex.Message, "fatal")
            Finally
                AreaCommon.log.track("ChainStateEngine.getDataPeer", "Complete")
            End Try

            Return New DataMasternode
        End Function

        ''' <summary>
        ''' This method provide to check if exist a node into a chain
        ''' </summary>
        ''' <param name="publicAddress"></param>
        ''' <param name="chainName"></param>
        ''' <returns></returns>
        Public Function existDataNode(ByVal publicAddress As String, Optional ByVal chainName As String = "") As Boolean
            Dim newKey As New DataMasternodeKey

            Try
                AreaCommon.log.track("ChainStateEngine.getDataPeer", "Begin")

                If (chainName.Length = 0) Then
                    newKey.chainName = AreaCommon.state.internalInformation.chainName
                Else
                    newKey.chainName = chainName
                End If
                newKey.identityPublicAddress = publicAddress

                Return activeMasterNode.ContainsKey(newKey)
            Catch ex As Exception
                AreaCommon.log.track("ChainStateEngine.getDataPeer", ex.Message, "fatal")

                Return False
            Finally
                AreaCommon.log.track("ChainStateEngine.getDataPeer", "Complete")
            End Try
        End Function

        ''' <summary>
        ''' This method provide to return a node list able to vote a consensus
        ''' </summary>
        ''' <returns></returns>
        Public Function getNodeListAbleToConsensus() As List(Of DataMasternode)
            Try
                Dim result As New List(Of DataMasternode)

                AreaCommon.log.track("ChainStateEngine.getNodeListAbleToConsensus", "Begin")

                For Each item In activeMasterNode.Values
                    If (item.role = DataMasternode.roleMasterNode.consensus) Or
                       (item.role = DataMasternode.roleMasterNode.fullService) Then
                        result.Add(item)
                    End If
                Next

                AreaCommon.log.track("ChainStateEngine.getNodeListAbleToConsensus", "Complete")

                Return result
            Catch ex As Exception
                AreaCommon.log.track("ChainStateEngine.getNodeListAbleToConsensus", ex.Message, "fatal")

                Return New List(Of DataMasternode)
            End Try
        End Function

        ''' <summary>
        ''' This method provide to manage a node abstained
        ''' </summary>
        ''' <param name="publicAddress"></param>
        ''' <param name="requestHash"></param>
        ''' <returns></returns>
        Public Function manageAbstained(ByVal publicAddress As String, ByVal requestHash As String, Optional ByVal chainName As String = "") As Boolean
            Try
                Dim newKey As New DataMasternodeKey

                AreaCommon.log.track("ChainStateEngine.manageAbstained", "Begin")

                newKey.identityPublicAddress = publicAddress

                If (chainName.Length = 0) Then
                    newKey.chainName = AreaCommon.state.internalInformation.chainName
                Else
                    newKey.chainName = chainName
                End If

                If activeMasterNode.ContainsKey(newKey) Then
                    If Not activeMasterNode(newKey).abstainRequest.ContainsKey(requestHash) Then

                        ''' UNDONE: when close a block reset this list

                        activeMasterNode(newKey).abstainRequest.Add(requestHash, requestHash)
                    End If

                    If (activeMasterNode(newKey).abstainRequest.Values.Count > 3) Then

                        ''' UNDONE: manage Abstained
                        ''' 
                        ''' create a request A2x1 and manage this

                    End If
                End If

                AreaCommon.log.track("ChainStateEngine.manageAbstained", "Complete")

                Return True
            Catch ex As Exception
                AreaCommon.log.track("ChainStateEngine.manageAbstained", ex.Message, "fatal")

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to manage a reject node
        ''' </summary>
        ''' <param name="publicAddress"></param>
        ''' <param name="requestHash"></param>
        ''' <param name="chainName"></param>
        ''' <returns></returns>
        Public Function manageRejected(ByVal publicAddress As String, ByVal requestHash As String, Optional ByVal chainName As String = "") As Boolean
            Try
                Dim newKey As New DataMasternodeKey

                AreaCommon.log.track("ChainStateEngine.manageRejected", "Begin")

                newKey.identityPublicAddress = publicAddress

                If (chainName.Length = 0) Then
                    newKey.chainName = AreaCommon.state.internalInformation.chainName
                Else
                    newKey.chainName = chainName
                End If

                If activeMasterNode.ContainsKey(newKey) Then
                    If Not activeMasterNode(newKey).abstainRequest.ContainsKey(requestHash) Then

                        ''' UNDONE: manage Rejected node
                        ''' 
                        ''' Create a A2x1 to esplunse this node for error (and penalization)

                    End If
                End If

                AreaCommon.log.track("ChainStateEngine.manageRejected", "Complete")

                Return True
            Catch ex As Exception
                AreaCommon.log.track("ChainStateEngine.manageRejected", ex.Message, "fatal")

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to response to absent node
        ''' </summary>
        ''' <param name="publicAddress"></param>
        ''' <param name="requestHash"></param>
        ''' <param name="chainName"></param>
        ''' <returns></returns>
        Public Function manageAbsent(ByVal publicAddress As String, ByVal requestHash As String, Optional ByVal chainName As String = "") As Boolean
            Try
                Dim newKey As New DataMasternodeKey

                AreaCommon.log.track("ChainStateEngine.manageAbsent", "Begin")

                newKey.identityPublicAddress = publicAddress

                If (chainName.Length = 0) Then
                    newKey.chainName = AreaCommon.state.internalInformation.chainName
                Else
                    newKey.chainName = chainName
                End If

                If activeMasterNode.ContainsKey(newKey) Then
                    If Not activeMasterNode(newKey).abstainRequest.ContainsKey(requestHash) Then

                        ''' UNDONE: manage Absent node
                        ''' 
                        ''' Create a A2x1 to esplunse this node for error (and penalization)

                    End If
                End If

                AreaCommon.log.track("ChainStateEngine.manageAbsent", "Complete")

                Return True
            Catch ex As Exception
                AreaCommon.log.track("ChainStateEngine.manageAbsent", ex.Message, "fatal")

                Return False
            End Try
        End Function


        ''' <summary>
        ''' This method provide to initialize a class
        ''' </summary>
        ''' <param name="workPath"></param>
        ''' <returns></returns>
        Public Function init(ByVal workPath As String) As Boolean
            Try
                Dim proceed As Boolean = True

                AreaCommon.log.track("ChainStateEngine.init", "Begin")

                If proceed Then
                    proceed = _DBNetwork.init(workPath)
                End If
                If proceed Then
                    proceed = _DBChain.init(workPath)
                End If

                AreaCommon.log.track("ChainStateEngine.init", "Complete")

                Return True
            Catch ex As Exception
                AreaCommon.log.track("ChainStateEngine.init", "Failed = " & ex.Message, "fatal", True)

                Return False
            End Try
        End Function

    End Class

End Namespace
