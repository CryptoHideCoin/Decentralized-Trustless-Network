Option Compare Text
Option Explicit On

Imports CHCProtocolLibrary.AreaCommon.Models.Chain






Namespace AreaState

    Public Class ChainStateEngine

        ''' <summary>
        ''' This class contain all internal element of single information
        ''' </summary>
        Public Class ChainNodeInformation

            Public Property identityPublicAddress As String = ""
            Public Property ipAddress As String = ""
            Public Property power As Decimal = 0
            Public Property role As RoleMasterNode = RoleMasterNode.undefined
            Public Property startConnectionTimeStamp As Double = 0
            Public Property dayConnection As Short = 0
            Public Property lastConnectionTimeStamp As Double = 0
            Public Property itsMe As Boolean = False
            Public Property registrationCoordinate As String = ""

            Public Property abstainRequest As New Dictionary(Of String, String)

        End Class

        ''' <summary>
        ''' This class contain all information to the community
        ''' </summary>
        Public Class PublicChainNodeInformation

            Public Property identityPublicAddress As String = ""
            Public Property ipAddress As String = ""
            Public Property role As RoleMasterNode = RoleMasterNode.undefined
            Public Property startConnectionTimeStamp As Double = 0
            Public Property dayConnection As Short = 0

            Public Property transactionChainRecord As New CHCCommonLibrary.AreaCommon.Models.General.IdentifyLastTransaction

        End Class

        ''' <summary>
        ''' This enumeration contain all field (with additional information) of data chain
        ''' </summary>
        Public Class DataChain

            Public Property identity As Integer = 0

            Public Property [name] As New PrimaryStateModel.ItemIdentityStructure
            Public Property isPrivate As New PrimaryStateModel.ItemIdentityStructure
            Public Property description As New PrimaryStateModel.ItemIdentityStructure

            Public Property parameters As New PrimaryStateModel.ParameterIdentityStructure

            Public Property protocolSets As New List(Of Response.SingleSetProtocol)
            Public Property priceList As New PrimaryStateModel.ChainPriceListStructure
            Public Property tokens As New List(Of AssetStructure)
            Public Property privacyPolicy As New PrimaryStateModel.ItemIdentityStructure
            Public Property termsAndConditions As New PrimaryStateModel.ItemIdentityStructure
            Public Property lastCloseBlock As New PrimaryStateModel.ItemIdentityStructure

            Public Property storedNodeList As New NodeListChainStructure
            Public Property originalNodeList As New Dictionary(Of String, NodeComplete)
            Public Property internalNodeList As New Dictionary(Of String, ChainNodeInformation)
            Public Property serviceNodeList As New Dictionary(Of String, PublicChainNodeInformation)

            Public ReadOnly Property hash As String
                Get
                    Return name.progressiveHash
                End Get
            End Property
            Public ReadOnly Property creationDateLedger As Double
                Get
                    Return name.registrationTimeStamp
                End Get
            End Property

            ''' <summary>
            ''' This method provide to extract the minimal data from the object
            ''' </summary>
            ''' <returns></returns>
            Public Function extractMinimalData() As CHCProtocolLibrary.AreaCommon.Models.Chain.ChainMinimalData
                Dim item As New CHCProtocolLibrary.AreaCommon.Models.Chain.ChainMinimalData
                Try
                    item.name = name.value
                    item.privateChain = (isPrivate.value = "1")
                    item.description = description.value
                Catch ex As Exception
                End Try

                Return item
            End Function

            ''' <summary>
            ''' This method provide to check if a chain is active or not
            ''' </summary>
            ''' <returns></returns>
            Public Function isActive() As Boolean
                Try
                    If (serviceNodeList.Count = 0) Then
                        Return False
                    Else
                        Return (CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime() - lastCloseBlock.value) < (24 * 60 * 60 * 1000)
                    End If
                Catch ex As Exception
                    Return False
                End Try
            End Function

        End Class

        ''' <summary>
        ''' This class contain all element relative a supply of the asset of a network
        ''' </summary>
        Public Class DataSupply

            Inherits CHCCommonLibrary.AreaCommon.Models.General.IdentifyLastTransaction

            Public Property value As New CHCProtocolLibrary.AreaCommon.Models.Supply.SupplyInformationModel

        End Class

        Private Property _DBNetwork As New AreaCommon.DAO.DBNetwork
        Private Property _DBChain As New AreaCommon.DAO.DBChain
        Private Property _Chains As New List(Of DataChain)


        Public Property activeNetwork As New PrimaryStateModel.DataNetwork
        Public Property activeChain As New DataChain

        Public Property chainByName As New Dictionary(Of String, DataChain)
        Public Property chainByID As New Dictionary(Of Integer, DataChain)

        Public Property supply As New DataSupply


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
                        IO.File.Delete(IO.Path.Combine(AreaCommon.paths.workData.state.contents, oldHashContent) & ".Content")
                    Catch ex As Exception
                    End Try
                End If

                If _DBNetwork.updatePropertNetworky(id, value, transactionChainRecord, hashContent, writeValueOnDB) Then
                    Select Case id
                        Case AreaCommon.DAO.DBNetwork.MainPropertyID.networkCreationDate
                            activeNetwork.networkCreationDate = value
                            AreaCommon.state.ledger.header.createLedgerTimeStamp = value
                        Case AreaCommon.DAO.DBNetwork.MainPropertyID.genesisPublicAddress : activeNetwork.genesisPublicAddress = value
                        Case AreaCommon.DAO.DBNetwork.MainPropertyID.networkName
                            activeNetwork.networkName.value = value
                            activeNetwork.networkName.coordinate = transactionChainRecord.coordinate
                            activeNetwork.networkName.hash = transactionChainRecord.hash
                            activeNetwork.networkName.progressiveHash = transactionChainRecord.progressiveHash
                            activeNetwork.networkName.registrationTimeStamp = transactionChainRecord.registrationTimeStamp

                            AreaCommon.state.serviceInformation.netWorkName = value
                            AreaCommon.state.serviceInformation.netWorkReferement = transactionChainRecord.hash
                        Case AreaCommon.DAO.DBNetwork.MainPropertyID.specialEnvironment
                            activeNetwork.envinronment.value = value
                            activeNetwork.envinronment.coordinate = transactionChainRecord.coordinate
                            activeNetwork.envinronment.hash = transactionChainRecord.hash
                            activeNetwork.envinronment.progressiveHash = transactionChainRecord.progressiveHash
                            activeNetwork.envinronment.registrationTimeStamp = transactionChainRecord.registrationTimeStamp
                        Case AreaCommon.DAO.DBNetwork.MainPropertyID.whitePaper
                            activeNetwork.whitePaper.value = value
                            activeNetwork.whitePaper.coordinate = transactionChainRecord.coordinate
                            activeNetwork.whitePaper.hash = transactionChainRecord.hash
                            activeNetwork.whitePaper.progressiveHash = transactionChainRecord.progressiveHash
                            activeNetwork.whitePaper.registrationTimeStamp = transactionChainRecord.registrationTimeStamp
                        Case AreaCommon.DAO.DBNetwork.MainPropertyID.yellowPaper
                            activeNetwork.yellowPaper.value = value
                            activeNetwork.yellowPaper.coordinate = transactionChainRecord.coordinate
                            activeNetwork.yellowPaper.hash = transactionChainRecord.hash
                            activeNetwork.yellowPaper.progressiveHash = transactionChainRecord.progressiveHash
                            activeNetwork.yellowPaper.registrationTimeStamp = transactionChainRecord.registrationTimeStamp
                        Case AreaCommon.DAO.DBNetwork.MainPropertyID.assetData
                            activeNetwork.primaryAssetData.coordinate = transactionChainRecord.coordinate
                            activeNetwork.primaryAssetData.hash = transactionChainRecord.hash
                            activeNetwork.primaryAssetData.progressiveHash = transactionChainRecord.progressiveHash
                            activeNetwork.primaryAssetData.registrationTimeStamp = transactionChainRecord.registrationTimeStamp
                        Case AreaCommon.DAO.DBNetwork.MainPropertyID.generalCondition
                            activeNetwork.generalConditions.value = value
                            activeNetwork.generalConditions.coordinate = transactionChainRecord.coordinate
                            activeNetwork.generalConditions.hash = transactionChainRecord.hash
                            activeNetwork.generalConditions.progressiveHash = transactionChainRecord.progressiveHash
                            activeNetwork.generalConditions.registrationTimeStamp = transactionChainRecord.registrationTimeStamp
                        Case AreaCommon.DAO.DBNetwork.MainPropertyID.privacyPolicy
                            activeNetwork.privacyPolicy.value = value
                            activeNetwork.privacyPolicy.coordinate = transactionChainRecord.coordinate
                            activeNetwork.privacyPolicy.hash = transactionChainRecord.hash
                            activeNetwork.privacyPolicy.progressiveHash = transactionChainRecord.progressiveHash
                            activeNetwork.privacyPolicy.registrationTimeStamp = transactionChainRecord.registrationTimeStamp
                        Case AreaCommon.DAO.DBNetwork.MainPropertyID.refundPlan
                            activeNetwork.refundPlan.coordinate = transactionChainRecord.coordinate
                            activeNetwork.refundPlan.hash = transactionChainRecord.hash
                            activeNetwork.refundPlan.progressiveHash = transactionChainRecord.progressiveHash
                            activeNetwork.refundPlan.registrationTimeStamp = transactionChainRecord.registrationTimeStamp
                        Case AreaCommon.DAO.DBNetwork.MainPropertyID.transactionChainConfiguration
                            activeNetwork.transactionChainSettings.coordinate = transactionChainRecord.coordinate
                            activeNetwork.transactionChainSettings.hash = transactionChainRecord.hash
                            activeNetwork.transactionChainSettings.progressiveHash = transactionChainRecord.progressiveHash
                            activeNetwork.transactionChainSettings.registrationTimeStamp = transactionChainRecord.registrationTimeStamp
                    End Select

                    AreaCommon.log.track("ChainStateEngine.addNetworkProperty", "Completed")

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
        Public Function addNewChain(ByVal name As String, ByVal privateChain As Boolean, ByVal description As String, ByRef transactionChainRecord As CHCCommonLibrary.AreaCommon.Models.General.IdentifyLastTransaction) As Integer
            Try
                AreaCommon.log.track("ChainStateEngine.addNewChain", "Begin")

                Dim newValue As New DataChain
                Dim id As Integer

                id = _DBChain.addNewChain(name, privateChain, description, transactionChainRecord)

                If (id > 0) Then
                    newValue.identity = id

                    newValue.name.value = name
                    newValue.name.coordinate = transactionChainRecord.coordinate
                    newValue.name.registrationTimeStamp = transactionChainRecord.registrationTimeStamp
                    newValue.name.hash = transactionChainRecord.hash
                    newValue.name.progressiveHash = transactionChainRecord.progressiveHash

                    newValue.isPrivate.value = privateChain
                    newValue.isPrivate.coordinate = transactionChainRecord.coordinate
                    newValue.isPrivate.registrationTimeStamp = transactionChainRecord.registrationTimeStamp
                    newValue.isPrivate.hash = transactionChainRecord.hash
                    newValue.isPrivate.progressiveHash = transactionChainRecord.progressiveHash

                    newValue.description.value = description
                    newValue.description.coordinate = transactionChainRecord.coordinate
                    newValue.description.registrationTimeStamp = transactionChainRecord.registrationTimeStamp
                    newValue.description.hash = transactionChainRecord.hash
                    newValue.description.progressiveHash = transactionChainRecord.progressiveHash

                    newValue.lastCloseBlock.value = transactionChainRecord.registrationTimeStamp.ToString()
                    newValue.lastCloseBlock.coordinate = transactionChainRecord.coordinate
                    newValue.lastCloseBlock.registrationTimeStamp = transactionChainRecord.registrationTimeStamp
                    newValue.lastCloseBlock.progressiveHash = transactionChainRecord.progressiveHash
                    newValue.lastCloseBlock.hash = transactionChainRecord.hash

                    If (newValue.name.value.CompareTo(AreaCommon.state.serviceInformation.chainName) = 0) Then
                        AreaCommon.log.track("ChainStateEngine.addNewChain", "Set activeChain")

                        activeChain = newValue
                    End If

                    chainByName.Add(name, newValue)
                    chainByID.Add(id, newValue)
                    _Chains.Add(newValue)
                End If

                AreaCommon.log.track("ChainStateEngine.addNewChain", "Completed")

                Return True
            Catch ex As Exception
                AreaCommon.log.track("ChainStateEngine.addNewChain", ex.Message, "fatal")

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to create a new chain temporally
        ''' </summary>
        ''' <returns></returns>
        Public Function addGenesisChain() As Boolean
            Try
                Dim newValue As New DataChain

                AreaCommon.log.track("ChainStateEngine.addGenesisChain", "Begin")

                newValue.description.value = "Genesis"
                newValue.identity = 0
                newValue.isPrivate.value = True
                newValue.name.value = "Genesis"

                chainByName.Add("Genesis", newValue)
                chainByID.Add(0, newValue)
                _Chains.Add(newValue)

                AreaCommon.log.track("ChainStateEngine.addGenesisChain", "Completed")

                Return True
            Catch ex As Exception
                AreaCommon.log.track("ChainStateEngine.addGenesisChain", ex.Message, "fatal")

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to update a new protocol
        ''' </summary>
        ''' <param name="chainReferement"></param>
        ''' <param name="value"></param>
        ''' <param name="transactionChainRecord"></param>
        ''' <returns></returns>
        Public Function updateNewProtocol(ByVal chainReferement As String, ByRef value As CHCProtocolLibrary.AreaCommon.Models.Chain.ProtocolMinimalData, ByRef transactionChainRecord As CHCCommonLibrary.AreaCommon.Models.General.IdentifyLastTransaction) As Boolean
            Try
                AreaCommon.log.track("ChainStateEngine.updateNewProtocol", "Begin")

                Dim chain As DataChain
                Dim protocolData As New CHCProtocolLibrary.AreaCommon.Models.Chain.Response.SingleSetProtocol

                chain = chainByName(chainReferement)

                If _DBChain.updateProtocol(chain.identity, value, transactionChainRecord) Then
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
                    protocolData.integrity.hash = transactionChainRecord.hash
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
                AreaCommon.log.track("ChainStateEngine.updateNewProtocol", "Completed")
            End Try
        End Function

        ''' <summary>
        ''' This method provide to add a new token
        ''' </summary>
        ''' <param name="chainReferement"></param>
        ''' <returns></returns>
        Public Function addNewToken(ByVal chainReferement As String, ByRef value As CHCProtocolLibrary.AreaCommon.Models.PrimaryChain.AssetConfigurationModel, ByVal hashContent As String, ByRef transactionChainRecord As CHCCommonLibrary.AreaCommon.Models.General.IdentifyLastTransaction) As Boolean
            Try
                Dim chain As DataChain
                Dim newToken As New CHCProtocolLibrary.AreaCommon.Models.Chain.AssetStructure

                AreaCommon.log.track("ChainStateEngine.addNewToken", "Begin")

                chain = chainByName(chainReferement)

                If _DBChain.addNewToken(chain.identity, value, transactionChainRecord, hashContent) Then
                    For Each token In chain.tokens
                        If (token.value.assetInformation.name.CompareTo(value.assetInformation.name) = 0) Then
                            chain.tokens.Remove(token)

                            Exit For
                        End If
                    Next

                    newToken.coordinate = transactionChainRecord.coordinate
                    newToken.hash = transactionChainRecord.hash
                    newToken.registrationTimeStamp = transactionChainRecord.registrationTimeStamp

                    newToken.value = value

                    chain.tokens.Add(newToken)

                    Return True
                End If

                Return False
            Catch ex As Exception
                AreaCommon.log.track("ChainStateEngine.addNewToken", ex.Message, "fatal")

                Return False
            Finally
                AreaCommon.log.track("ChainStateEngine.addNewToken", "Completed")
            End Try
        End Function

        ''' <summary>
        ''' This method provide to update price list
        ''' </summary>
        ''' <param name="chainReferement"></param>
        ''' <param name="value"></param>
        ''' <param name="hashContent"></param>
        ''' <param name="transactionChainRecord"></param>
        ''' <returns></returns>
        Public Function updatePriceList(ByVal chainReferement As String, ByVal value As CHCProtocolLibrary.AreaCommon.Models.Network.ItemPriceTableListModel, ByVal hashContent As String, ByRef transactionChainRecord As CHCCommonLibrary.AreaCommon.Models.General.IdentifyLastTransaction) As Boolean
            Try
                AreaCommon.log.track("ChainStateEngine.updatePriceList", "Begin")

                Dim chain As DataChain
                Dim proceed As Boolean = True

                If proceed Then
                    proceed = _DBChain.updateDetail(chainReferement, AreaCommon.DAO.DBChain.DetailPropertyID.priceList, value.getHash(), transactionChainRecord)
                End If
                If proceed Then
                    chain = chainByName(chainReferement)

                    chain.priceList.coordinate = transactionChainRecord.coordinate
                    chain.priceList.hash = transactionChainRecord.hash
                    chain.priceList.progressiveHash = transactionChainRecord.progressiveHash
                    chain.priceList.registrationTimeStamp = transactionChainRecord.registrationTimeStamp
                    chain.priceList.value = value

                    proceed = True
                End If

                Return proceed
            Catch ex As Exception
                AreaCommon.log.track("ChainStateEngine.updatePriceList", ex.Message, "fatal")

                Return False
            Finally
                AreaCommon.log.track("ChainStateEngine.updatePriceList", "Completed")
            End Try
        End Function

        ''' <summary>
        ''' This method provide to update chain property
        ''' </summary>
        ''' <param name="chainReferement"></param>
        ''' <param name="propertyID"></param>
        ''' <param name="value"></param>
        ''' <param name="transactionChainRecord"></param>
        ''' <returns></returns>
        Public Function updateChainProperty(ByVal chainReferement As String, ByVal propertyID As AreaCommon.DAO.DBChain.DetailPropertyID, ByVal value As Object, ByVal hashContent As String, ByRef transactionChainRecord As CHCCommonLibrary.AreaCommon.Models.General.IdentifyLastTransaction) As Boolean
            Try
                AreaCommon.log.track("ChainStateEngine.updateChainProperty", "Begin")

                Dim chain As DataChain
                Dim contentPath As String = AreaCommon.paths.workData.state.contents
                Dim proceed As Boolean = True
                Dim dataObject As Object

                If proceed Then
                    chain = chainByName(chainReferement)

                    proceed = _DBChain.updateDetail(chain.identity, propertyID, hashContent, transactionChainRecord)
                End If
                If proceed Then
                    Select Case propertyID
                        Case AreaCommon.DAO.DBChain.DetailPropertyID.chainParameters : dataObject = chain.parameters
                        Case AreaCommon.DAO.DBChain.DetailPropertyID.lastTransactionBlock : dataObject = chain.lastCloseBlock
                        Case AreaCommon.DAO.DBChain.DetailPropertyID.policyPrivacy : dataObject = chain.privacyPolicy
                        Case AreaCommon.DAO.DBChain.DetailPropertyID.lastNodeList : dataObject = chain.storedNodeList
                        Case Else : dataObject = chain.termsAndConditions
                    End Select

                    dataObject.coordinate = transactionChainRecord.coordinate
                    dataObject.hash = transactionChainRecord.hash
                    dataObject.progressiveHash = transactionChainRecord.progressiveHash
                    dataObject.registrationTimeStamp = transactionChainRecord.registrationTimeStamp
                    dataObject.value = value

                    proceed = True
                End If

                Return proceed
            Catch ex As Exception
                AreaCommon.log.track("ChainStateEngine.updatePriceList", ex.Message, "fatal")

                Return False
            Finally
                AreaCommon.log.track("ChainStateEngine.updatePriceList", "Completed")
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
        ''' This method provide to add a new node to chain
        ''' </summary>
        ''' <param name="value"></param>
        ''' <returns></returns>
        Public Function addNewNodeToChain(ByVal publicAddress As String, ByVal value As RequestAddNewNode, Optional ByVal transactionChainRecord As CHCCommonLibrary.AreaCommon.Models.General.IdentifyLastTransaction = Nothing) As Boolean
            Try
                Dim chain As DataChain
                Dim internalElement As New ChainNodeInformation
                Dim publicElement As New PublicChainNodeInformation
                Dim originalElement As NodeComplete

                AreaCommon.log.track("ChainStateEngine.addNewNodeToChain", "Begin")

                chain = chainByName(value.chainName)

                originalElement = value.clone()

                originalElement.identityPublicAddress = publicAddress
                originalElement.startConnectionTimeStamp = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()

                internalElement.identityPublicAddress = publicAddress
                internalElement.ipAddress = value.getPrimaryAddress()
                internalElement.itsMe = (internalElement.ipAddress = AreaCommon.state.serviceInformation.addressIP)
                internalElement.lastConnectionTimeStamp = originalElement.startConnectionTimeStamp

                If Not IsNothing(transactionChainRecord) Then
                    internalElement.power = value.getPower()
                    internalElement.registrationCoordinate = transactionChainRecord.coordinate
                Else
                    internalElement.power = 1
                End If

                internalElement.role = value.role
                internalElement.startConnectionTimeStamp = internalElement.lastConnectionTimeStamp

                publicElement.identityPublicAddress = publicAddress
                publicElement.ipAddress = internalElement.ipAddress
                publicElement.dayConnection = 0
                publicElement.role = value.role
                publicElement.startConnectionTimeStamp = internalElement.startConnectionTimeStamp

                If Not IsNothing(transactionChainRecord) Then
                    With publicElement.transactionChainRecord
                        .coordinate = transactionChainRecord.coordinate
                        .hash = transactionChainRecord.hash
                        .progressiveHash = transactionChainRecord.progressiveHash
                        .registrationTimeStamp = transactionChainRecord.registrationTimeStamp
                    End With
                End If

                If (AreaCommon.state.network.position = CHCRuntimeChainLibrary.AreaRuntime.AppState.EnumConnectionState.genesisOperation) Then
                    chain.internalNodeList.Clear()
                    chain.serviceNodeList.Clear()
                    chain.originalNodeList.Clear()
                End If

                chain.internalNodeList.Add(publicAddress, internalElement)
                chain.serviceNodeList.Add(publicAddress, publicElement)
                chain.originalNodeList.Add(publicAddress, originalElement)

                AreaCommon.log.track("ChainStateEngine.addNewNodeToChain", "Completed")

                Return True
            Catch ex As Exception
                AreaCommon.log.track("ChainStateEngine.addNewNodeToChain", ex.Message, "fatal")

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to remove a node from a chain
        ''' </summary>
        ''' <param name="publicAddress"></param>
        ''' <param name="chainName"></param>
        ''' <param name="transactionChainRecord"></param>
        ''' <returns></returns>
        Public Function removeNodeFromChain(ByVal publicAddress As String, ByVal chainName As String, Optional ByVal transactionChainRecord As CHCCommonLibrary.AreaCommon.Models.General.IdentifyLastTransaction = Nothing) As Boolean
            Try
                Dim chain As DataChain

                AreaCommon.log.track("ChainStateEngine.removeNodeFromChain", "Begin")

                chain = chainByName(chainName)

                chain.internalNodeList.Remove(publicAddress)
                chain.serviceNodeList.Remove(publicAddress)
                chain.originalNodeList.Remove(publicAddress)

                AreaCommon.log.track("ChainStateEngine.removeNodeFromChain", "Completed")

                Return True
            Catch ex As Exception
                AreaCommon.log.track("ChainStateEngine.removeNodeFromChain", ex.Message, "fatal")

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to get an information relative a peer
        ''' </summary>
        ''' <param name="publicAddress"></param>
        ''' <param name="chainName"></param>
        ''' <returns></returns>
        Public Function getDataNode(ByVal publicAddress As String, Optional ByVal chainName As String = "") As PublicChainNodeInformation
            Try
                Dim chain As DataChain

                AreaCommon.log.track("ChainStateEngine.getDataPeer", "Begin")

                If (chainName.Length = 0) Then
                    chainName = AreaCommon.state.serviceInformation.chainName
                End If

                chain = chainByName(chainName)

                Return chain.serviceNodeList(publicAddress)
            Catch ex As Exception
                AreaCommon.log.track("ChainStateEngine.getDataPeer", ex.Message, "fatal")

                Return New PublicChainNodeInformation
            Finally
                AreaCommon.log.track("ChainStateEngine.getDataPeer", "Completed")
            End Try
        End Function

        ''' <summary>
        ''' This method provide to check if exist a node into a chain
        ''' </summary>
        ''' <param name="publicAddress"></param>
        ''' <param name="chainName"></param>
        ''' <returns></returns>
        Public Function existDataNode(ByVal publicAddress As String, Optional ByVal chainName As String = "") As Boolean
            Try
                Dim chain As DataChain

                AreaCommon.log.track("ChainStateEngine.getDataPeer", "Begin")

                If (chainName.Length = 0) Then
                    chainName = AreaCommon.state.serviceInformation.chainName
                End If

                chain = chainByName(chainName)

                Return chain.serviceNodeList.ContainsKey(publicAddress)
            Catch ex As Exception
                AreaCommon.log.track("ChainStateEngine.getDataPeer", ex.Message, "fatal")

                Return False
            Finally
                AreaCommon.log.track("ChainStateEngine.getDataPeer", "Completed")
            End Try
        End Function

        ''' <summary>
        ''' This method provide to return a node list able to power a consensus
        ''' </summary>
        ''' <returns></returns>
        Public Function getNodeListAbleToConsensus() As List(Of ChainNodeInformation)
            Try
                Dim chain As DataChain
                Dim result As New List(Of ChainNodeInformation)

                AreaCommon.log.track("ChainStateEngine.getNodeListAbleToConsensus", "Begin")

                If (AreaCommon.state.runTimeState.activeChain.name.value.Length = 0) Then
                    chain = chainByName("Genesis")
                Else
                    chain = AreaCommon.state.runTimeState.activeChain
                End If

                For Each singleNode In chain.internalNodeList.Values
                    If (singleNode.role = RoleMasterNode.validator) Or
                    (singleNode.role = RoleMasterNode.fullStack) Then
                        result.Add(singleNode)
                    End If
                Next

                AreaCommon.log.track("ChainStateEngine.getNodeListAbleToConsensus", "Completed")

                Return result
            Catch ex As Exception
                AreaCommon.log.track("ChainStateEngine.getNodeListAbleToConsensus", ex.Message, "fatal")

                Return New List(Of ChainNodeInformation)
            End Try
        End Function

        ''' <summary>
        ''' This method provide to get a data page from a page number
        ''' </summary>
        ''' <param name="value"></param>
        ''' <returns></returns>
        Public Function getDataPageChainByNumber(ByVal value As Integer) As List(Of CHCProtocolLibrary.AreaCommon.Models.Chain.ChainMinimalData)
            Try
                Dim result As New List(Of CHCProtocolLibrary.AreaCommon.Models.Chain.ChainMinimalData)
                Dim index As Integer = 0

                AreaCommon.log.track("ChainStateEngine.getDataPageChainByNumber", "Begin")

                If (_Chains.Count > ((value - 1) * 10)) Then
                    For i As Integer = 1 To 10
                        index = i + (value - 1) * 10

                        If (index <= _Chains.Count - 1) Then
                            result.Add(_Chains.ElementAt(index).extractMinimalData())
                        Else
                            Exit For
                        End If
                    Next
                Else

                End If

                AreaCommon.log.track("ChainStateEngine.getDataPageChainByNumber", "Completed")

                Return result
            Catch ex As Exception
                AreaCommon.log.track("ChainStateEngine.getDataPageChainByNumber", ex.Message, "fatal")

                Return New List(Of CHCProtocolLibrary.AreaCommon.Models.Chain.ChainMinimalData)
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
                Dim chain As DataChain

                AreaCommon.log.track("ChainStateEngine.manageAbstained", "Begin")

                If (chainName.Length = 0) Then
                    chainName = AreaCommon.state.serviceInformation.chainName
                End If

                chain = chainByName(chainName)

                chain.internalNodeList(publicAddress).abstainRequest.Add(requestHash, requestHash)

                If (chain.internalNodeList(publicAddress).abstainRequest.Count = 3) Then
                    ''' UNDONE: manage Abstained
                    ''' 
                    ''' create a request A2x1 and manage this
                End If

                AreaCommon.log.track("ChainStateEngine.manageAbstained", "Completed")

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
                Dim chain As DataChain

                AreaCommon.log.track("ChainStateEngine.manageRejected", "Begin")

                If (chainName.Length = 0) Then
                    chainName = AreaCommon.state.serviceInformation.chainName
                End If

                ''' UNDONE: manage Rejected node
                ''' 
                ''' Create a A2x1 to esplunse this node for error (and penalization)

                AreaCommon.log.track("ChainStateEngine.manageRejected", "Completed")

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
                Dim chain As DataChain

                AreaCommon.log.track("ChainStateEngine.manageAbsent", "Begin")

                If (chainName.Length = 0) Then
                    chainName = AreaCommon.state.serviceInformation.chainName
                End If

                ''' UNDONE: manage Rejected node
                ''' 
                ''' Create a A2x1 to esplunse this node for error (and penalization)

                AreaCommon.log.track("ChainStateEngine.manageAbsent", "Completed")

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

                AreaCommon.log.track("ChainStateEngine.init", "Completed")

                Return True
            Catch ex As Exception
                AreaCommon.log.track("ChainStateEngine.init", "Failed = " & ex.Message, "fatal", True)

                Return False
            End Try
        End Function

    End Class

End Namespace
