Option Compare Text
Option Explicit On

Imports System.Data.SQLite




Namespace AreaState

    Public Class ChainStateEngine

        ''' <summary>
        ''' This class contain the last identify last transaction and a value
        ''' </summary>
        Public Class ItemIdentityStructure
            Inherits CHCCommonLibrary.AreaCommon.Models.General.IdentifyLastTransaction

            Public Property value As String = ""
        End Class


        Public Class NetworkAssetStructure
            Inherits CHCCommonLibrary.AreaCommon.Models.General.IdentifyLastTransaction

            Public Property value As New CHCProtocolLibrary.AreaCommon.Models.Network.AssetModel
        End Class

        Public Class NetworkTransactionStructure
            Inherits CHCCommonLibrary.AreaCommon.Models.General.IdentifyLastTransaction

            Public Property value As New CHCProtocolLibrary.AreaCommon.Models.Network.TransactionChainModel
        End Class

        Public Class NetworkRefundItemListStructure
            Inherits CHCCommonLibrary.AreaCommon.Models.General.IdentifyLastTransaction

            Public Property value As New CHCProtocolLibrary.AreaCommon.Models.Network.RefundItemList
        End Class

        Public Class ChainPriceListStructure
            Inherits CHCCommonLibrary.AreaCommon.Models.General.IdentifyLastTransaction

            Public Property value As New CHCProtocolLibrary.AreaCommon.Models.Network.ItemPriceTableListModel
        End Class

        Public Class DataNetwork

            Public Property networkName As New itemIdentityStructure
            Public Property whitePaper As New itemIdentityStructure
            Public Property yellowPaper As New itemIdentityStructure
            Public Property primaryAssetData As New NetworkAssetStructure
            Public Property transactionChainSettings As New NetworkTransactionStructure
            Public Property privacyPolicy As New itemIdentityStructure
            Public Property generalCondition As New itemIdentityStructure

            Public Property refundPlan As New NetworkRefundItemListStructure

            Public Property networkCreationDate As Double = 0

            Public Property genesisPublicAddress As String = ""
        End Class

        Public Class DataChain

            Public Property name As New itemIdentityStructure
            Public Property description As New itemIdentityStructure
            Public Property protocolDocument As New itemIdentityStructure
            Public Property protocolSets As New List(Of itemIdentityStructure)
            Public Property priceLists As New ChainPriceListStructure
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

        Public Enum PropertyID

            notDefined
            networkCreationDate
            genesisPublicAddress
            networkName
            whitePaper
            yellowPaper
            assetData
            transactionChainConfiguration
            privacyPolicy
            generalCondition
            refundPlan

        End Enum

        Public Enum DBPropertyID

            notDefined
            typeOfDB
            dateCreation
            name

        End Enum

        Private _DBStateFileName As String = "State.Db"
        Private _DBStateConnectionString As String = "Data source = {0};Version=3;"

        Public Property activeNetwork As New DataNetwork
        Public Property activeChain As New DataChain
        Public Property activeChains As New Dictionary(Of String, DataChain)
        Public Property activeMasterNode As New Dictionary(Of DataMasternodeKey, DataMasternode)

        ''' <summary>
        ''' This method provide to create a main db table
        ''' </summary>
        ''' <returns></returns>
        Private Function createMainDBTable() As Boolean
            Try
                Dim sql As String = ""
                Dim connectionDB As SQLiteConnection
                Dim sqlCommand As SQLiteCommand

                AreaCommon.log.track("ChainStateEngine.createDBTable", "Begin")

                sql += "CREATE TABLE mainProperties "
                sql += " (property_id INTEGER PRIMARY KEY, "
                sql += "  value NVARCHAR(1024) NOT NULL, "
                sql += "  recordCoordinate NVARCHAR(128) NOT NULL, "
                sql += "  recordHash NVARCHAR(65) NOT NULL, "
                sql += "  hashContent NVARCHAR(65) NOT NULL "
                sql += ");"

                connectionDB = New SQLiteConnection(String.Format(_DBStateConnectionString, _DBStateFileName))

                connectionDB.Open()

                AreaCommon.log.track("ChainStateEngine.createDBTable", "DB Open")

                sqlCommand = New SQLiteCommand(connectionDB)

                sqlCommand.CommandText = sql

                sqlCommand.ExecuteScalar()

                AreaCommon.log.track("ChainStateEngine.createDBTable", "Execute scalar")

                connectionDB.Close()

                AreaCommon.log.track("ChainStateEngine.createDBTable", "DB Close")

                Return True
            Catch ex As Exception
                AreaCommon.log.track("ChainStateEngine.createDBTable", "Failed = " & ex.Message, "fatal", True)

                Return False
            Finally
                AreaCommon.log.track("ChainStateEngine.createDBTable", "Complete")
            End Try
        End Function

        ''' <summary>
        ''' This method provide to insert a new record into mainProperties table
        ''' </summary>
        ''' <param name="id"></param>
        ''' <param name="value"></param>
        ''' <param name="recordCoordinate"></param>
        ''' <param name="recordHash"></param>
        ''' <param name="hashContent"></param>
        ''' <param name="writeValueOnDB"></param>
        ''' <returns></returns>
        Private Function insertSQLProperty(ByVal id As PropertyID, ByVal value As String, ByVal recordCoordinate As String, ByVal recordHash As String, Optional ByVal hashContent As String = "", Optional ByVal writeValueOnDB As Boolean = False) As Boolean
            Try
                Dim sql As String = ""
                Dim connectionDB As SQLiteConnection
                Dim sqlCommand As SQLiteCommand

                AreaCommon.log.track("ChainStateEngine.addSQLProperty", "Begin")

                sql += "INSERT INTO mainProperties "
                sql += " (property_id, value, recordCoordinate, recordHash, hashContent) "
                sql += "VALUES "
                sql += " (" & id & ", '"
                If writeValueOnDB Then
                    sql += value
                Else
                    sql += "(ext. content)"
                End If

                sql += "', '" & recordCoordinate & "', '" & recordHash & "'"

                If (hashContent.Length = 0) Then
                    sql += ", '---'"
                Else
                    sql += ", '" & hashContent & "'"
                End If

                sql += ")"

                connectionDB = New SQLiteConnection(String.Format(_DBStateConnectionString, _DBStateFileName))

                connectionDB.Open()

                AreaCommon.log.track("ChainStateEngine.addSQLProperty", "DB Open")

                sqlCommand = New SQLiteCommand(connectionDB)

                sqlCommand.CommandText = sql

                sqlCommand.ExecuteScalar()

                AreaCommon.log.track("ChainStateEngine.addSQLProperty", "Execute scalar")

                connectionDB.Close()

                AreaCommon.log.track("ChainStateEngine.addSQLProperty", "DB Close")

                Return True
            Catch ex As Exception
                AreaCommon.log.track("ChainStateEngine.addSQLProperty", "Failed = " & ex.Message, "fatal", True)

                Return False
            Finally
                AreaCommon.log.track("ChainStateEngine.addSQLProperty", "Complete")
            End Try
        End Function

        ''' <summary>
        ''' This method provide to create an identity db table
        ''' </summary>
        ''' <returns></returns>
        Private Function createIdentityDBTable() As Boolean
            Try
                Dim sql As String = ""
                Dim connectionDB As SQLiteConnection
                Dim sqlCommand As SQLiteCommand

                AreaCommon.log.track("ChainStateEngine.createIdentityDBTable", "Begin")

                sql += "CREATE TABLE dbIdentity "
                sql += " (property_id INTEGER PRIMARY KEY, "
                sql += "  value NVARCHAR(1024) NOT NULL "
                sql += ");"

                connectionDB = New SQLiteConnection(String.Format(_DBStateConnectionString, _DBStateFileName))

                connectionDB.Open()

                AreaCommon.log.track("ChainStateEngine.createIdentityDBTable", "Connection Open")

                sqlCommand = New SQLiteCommand(connectionDB)

                sqlCommand.CommandText = sql

                sqlCommand.ExecuteScalar()

                AreaCommon.log.track("ChainStateEngine.createIdentityDBTable", "Command execute")

                connectionDB.Close()

                AreaCommon.log.track("ChainStateEngine.createIdentityDBTable", "Connection close")

                Return True
            Catch ex As Exception
                AreaCommon.log.track("ChainStateEngine.createIdentityDBTable", ex.Message, "fatal")

                Return False
            Finally
                AreaCommon.log.track("ChainStateEngine.createIdentityDBTable", "Complete")
            End Try
        End Function

        ''' <summary>
        ''' This method provide to insert a sql property identity on db
        ''' </summary>
        ''' <param name="id"></param>
        ''' <param name="value"></param>
        ''' <returns></returns>
        Private Function insertSQLPropertyIdentityDB(ByVal id As PropertyID, ByVal value As String) As Boolean
            Try
                Dim sql As String = ""
                Dim connectionDB As SQLiteConnection
                Dim sqlCommand As SQLiteCommand

                AreaCommon.log.track("ChainStateEngine.insertSQLPropertyIdentityDB", "Begin")

                sql += "INSERT INTO dbIdentity "
                sql += " (property_id, value) "
                sql += "VALUES "
                sql += " (" & id & ", '"
                sql += value
                sql += "')"

                connectionDB = New SQLiteConnection(String.Format(_DBStateConnectionString, _DBStateFileName))

                connectionDB.Open()

                AreaCommon.log.track("ChainStateEngine.insertSQLPropertyIdentityDB", "Connection Open")

                sqlCommand = New SQLiteCommand(connectionDB)

                sqlCommand.CommandText = sql

                sqlCommand.ExecuteScalar()

                AreaCommon.log.track("ChainStateEngine.insertSQLPropertyIdentityDB", "Command executed")

                connectionDB.Close()

                AreaCommon.log.track("ChainStateEngine.insertSQLPropertyIdentityDB", "Connection Closed")

                Return True
            Catch ex As Exception
                AreaCommon.log.track("ChainStateEngine.insertSQLPropertyIdentityDB", ex.Message, "fatal")

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to write an identity on db
        ''' </summary>
        ''' <returns></returns>
        Private Function writeIdentityDB() As Boolean
            Try
                insertSQLPropertyIdentityDB(DBPropertyID.dateCreation, CHCCommonLibrary.AreaEngine.Miscellaneous.atMomentGMT())
                insertSQLPropertyIdentityDB(DBPropertyID.name, "State")
                insertSQLPropertyIdentityDB(DBPropertyID.typeOfDB, "State")

                Return True
            Catch ex As Exception
                AreaCommon.log.track("ChainStateEngine.createIdentityDBTable", ex.Message, "fatal")

                Return False
            End Try
        End Function


        ''' <summary>
        ''' This method provide to add a newtork property
        ''' </summary>
        ''' <param name="id"></param>
        ''' <param name="value"></param>
        ''' <param name="recordCoordinate"></param>
        ''' <param name="recordHash"></param>
        ''' <param name="hashContent"></param>
        ''' <param name="writeValueOnDB"></param>
        ''' <returns></returns>
        Public Function addNetworkProperty(ByVal id As PropertyID, ByVal value As String, ByVal transactionCoordinate As String, ByVal transactionHash As String, Optional ByVal hashContent As String = "", Optional ByVal writeValueOnDB As Boolean = True) As Boolean
            Try
                AreaCommon.log.track("ChainStateEngine.addNetworkProperty", "Begin")

                If insertSQLProperty(id, value, transactionCoordinate, transactionHash, hashContent, writeValueOnDB) Then
                    Select Case id
                        Case PropertyID.networkCreationDate : activeNetwork.networkCreationDate = value
                        Case PropertyID.genesisPublicAddress : activeNetwork.genesisPublicAddress = value
                        Case PropertyID.networkName
                            activeNetwork.networkName.value = value
                            activeNetwork.networkName.coordinate = transactionCoordinate
                            activeNetwork.networkName.hash = transactionHash
                        Case PropertyID.whitePaper
                            activeNetwork.whitePaper.value = value
                            activeNetwork.whitePaper.coordinate = transactionCoordinate
                            activeNetwork.whitePaper.hash = transactionHash
                        Case PropertyID.yellowPaper
                            activeNetwork.whitePaper.value = value
                            activeNetwork.whitePaper.coordinate = transactionCoordinate
                            activeNetwork.whitePaper.hash = transactionHash
                        Case PropertyID.assetData
                            activeNetwork.primaryAssetData.coordinate = transactionCoordinate
                            activeNetwork.primaryAssetData.hash = transactionHash
                        Case PropertyID.generalCondition
                            activeNetwork.generalCondition.coordinate = transactionCoordinate
                            activeNetwork.generalCondition.hash = transactionHash
                        Case PropertyID.privacyPolicy
                            activeNetwork.privacyPolicy.coordinate = transactionCoordinate
                            activeNetwork.privacyPolicy.hash = transactionHash
                        Case PropertyID.refundPlan
                            activeNetwork.refundPlan.coordinate = transactionCoordinate
                            activeNetwork.refundPlan.hash = transactionHash
                        Case PropertyID.transactionChainConfiguration
                            activeNetwork.transactionChainSettings.coordinate = transactionCoordinate
                            activeNetwork.transactionChainSettings.hash = transactionHash
                    End Select

                    AreaCommon.log.track("ChainStateEngine.addNetworkProperty", "Complete")

                    Return True
                End If

            Catch ex As Exception
                AreaCommon.log.track("ChainStateEngine.addNetworkProperty", ex.Message, "fatal")
            End Try

            Return False
        End Function


        Public Function addNewChain(ByVal name As String, ByVal ledgerCoordinate As String, ByVal ledgerHash As String) As DataChain
            Dim newValue As New DataChain

            newValue.name.value = name

            activeChains.Add(name, newValue)

            Return newValue
        End Function

        Public Function getDataChain(ByVal name As String) As DataChain
            If activeChains.ContainsKey(name) Then
                Return activeChains.Item(name)
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

                _DBStateFileName = IO.Path.Combine(workPath, _DBStateFileName)

                AreaCommon.log.track("ChainStateEngine.init", "Set path = " & _DBStateFileName)

                If Not IO.File.Exists(_DBStateFileName) Then
                    AreaCommon.log.track("ChainStateEngine.init", "File DB not exist")

                    SQLiteConnection.CreateFile(_DBStateFileName)
                End If

                If proceed Then
                    proceed = createIdentityDBTable()
                End If
                If proceed Then
                    proceed = writeIdentityDB()
                End If
                If proceed Then
                    proceed = createMainDBTable()
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
