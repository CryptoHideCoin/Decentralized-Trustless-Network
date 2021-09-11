Option Compare Text
Option Explicit On

Imports System.Data.SQLite




Namespace AreaState

    Public Class ChainStateEngine

        Public Class itemIdentityStructure
            Inherits CHCCommonLibrary.AreaCommon.Models.General.IdentifyRecordLedger

            Public Property value As String = ""
        End Class

        Public Class NetworkAssetStructure
            Inherits CHCCommonLibrary.AreaCommon.Models.General.IdentifyRecordLedger

            Public Property value As New CHCProtocolLibrary.AreaCommon.Models.Network.AssetModel
        End Class

        Public Class NetworkTransactionStructure
            Inherits CHCCommonLibrary.AreaCommon.Models.General.IdentifyRecordLedger

            Public Property value As New CHCProtocolLibrary.AreaCommon.Models.Network.TransactionChainModel
        End Class

        Public Class NetworkRefundItemListStructure
            Inherits CHCCommonLibrary.AreaCommon.Models.General.IdentifyRecordLedger

            Public Property value As New CHCProtocolLibrary.AreaCommon.Models.Network.RefundItemList
        End Class

        Public Class ChainPriceListStructure
            Inherits CHCCommonLibrary.AreaCommon.Models.General.IdentifyRecordLedger

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
            Public Property chainName As String = ""
            Public Property role As roleMasterNode = roleMasterNode.arbitration
            Public Property startConnectionTimeStamp As Double = 0
            Public Property dayConnection As Short = 0
            Public Property lastConnectionDate As Double = 0

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
        Public Property activeChains As New Dictionary(Of String, DataChain)
        Public Property activeMasterNode As New Dictionary(Of DataMasternodeKey, DataMasternode)


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
                AreaCommon.log.track("ChainStateEngine.createDBTable", "Failed = " & ex.Message, "error", True)

                Return False
            End Try
        End Function

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
                AreaCommon.log.track("ChainStateEngine.addSQLProperty", "Failed = " & ex.Message, "error", True)

                Return False
            End Try
        End Function

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
                AreaCommon.log.track("ChainStateEngine.createIdentityDBTable", "Error:" & ex.Message, "error")

                Return False
            End Try
        End Function

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
                AreaCommon.log.track("ChainStateEngine.insertSQLPropertyIdentityDB", "Error:" & ex.Message, "error")

                Return False
            End Try
        End Function

        Private Function writeIdentityDB() As Boolean
            insertSQLPropertyIdentityDB(DBPropertyID.dateCreation, CHCCommonLibrary.AreaEngine.Miscellaneous.atMomentGMT())
            insertSQLPropertyIdentityDB(DBPropertyID.name, "State")
            insertSQLPropertyIdentityDB(DBPropertyID.typeOfDB, "State")

            Return True
        End Function


        Public Function addProperty(ByVal id As PropertyID, ByVal value As String, ByVal recordCoordinate As String, ByVal recordHash As String, Optional ByVal hashContent As String = "", Optional ByVal writeValueOnDB As Boolean = True) As Boolean
            Try
                AreaCommon.log.track("ChainStateEngine.addProperty", "Begin")

                If insertSQLProperty(id, value, recordCoordinate, recordHash, hashContent, writeValueOnDB) Then
                    Select Case id
                        Case PropertyID.networkCreationDate : activeNetwork.networkCreationDate = value
                        Case PropertyID.genesisPublicAddress : activeNetwork.genesisPublicAddress = value
                        Case PropertyID.networkName
                            activeNetwork.networkName.value = value
                            activeNetwork.networkName.recordCoordinate = recordCoordinate
                            activeNetwork.networkName.recordHash = recordHash
                        Case PropertyID.whitePaper
                            activeNetwork.whitePaper.value = value
                            activeNetwork.whitePaper.recordCoordinate = recordCoordinate
                            activeNetwork.whitePaper.recordHash = recordHash
                        Case PropertyID.yellowPaper
                            activeNetwork.whitePaper.value = value
                            activeNetwork.whitePaper.recordCoordinate = recordCoordinate
                            activeNetwork.whitePaper.recordHash = recordHash
                        Case PropertyID.assetData
                            activeNetwork.primaryAssetData.recordCoordinate = recordCoordinate
                            activeNetwork.primaryAssetData.recordHash = recordHash
                        Case PropertyID.generalCondition
                            activeNetwork.generalCondition.recordCoordinate = recordCoordinate
                            activeNetwork.generalCondition.recordHash = recordHash
                        Case PropertyID.privacyPolicy
                            activeNetwork.privacyPolicy.recordCoordinate = recordCoordinate
                            activeNetwork.privacyPolicy.recordHash = recordHash
                        Case PropertyID.refundPlan
                            activeNetwork.refundPlan.recordCoordinate = recordCoordinate
                            activeNetwork.refundPlan.recordHash = recordHash
                        Case PropertyID.transactionChainConfiguration
                            activeNetwork.transactionChainSettings.recordCoordinate = recordCoordinate
                            activeNetwork.transactionChainSettings.recordHash = recordHash
                    End Select

                    AreaCommon.log.track("ChainStateEngine.addProperty", "Complete")

                    Return True
                End If

            Catch ex As Exception
                AreaCommon.log.track("A0x0Manager.init", "Error:" & ex.Message, "error")
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

        Public Function addNewPeer(ByVal chainName As String, ByVal publicAddress As String) As DataMasternode
            Dim newValue As New DataMasternode
            Dim newKey As New DataMasternodeKey

            newKey.chainName = chainName
            newKey.identityPublicAddress = publicAddress

            newValue.identityPublicAddress = publicAddress

            activeMasterNode.Add(newKey, newValue)

            Return newValue
        End Function

        Public Function getDataPeer(ByVal chainName As String, ByVal publicAddress As String) As DataMasternode
            Dim newKey As New DataMasternodeKey

            newKey.chainName = chainName
            newKey.identityPublicAddress = publicAddress

            If activeMasterNode.ContainsKey(newKey) Then
                Return activeMasterNode.Item(newKey)
            Else
                Return New DataMasternode
            End If
        End Function


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

                Return True
            Catch ex As Exception
                AreaCommon.log.track("ChainStateEngine.init", "Failed = " & ex.Message, "error", True)

                Return False
            End Try
        End Function

    End Class

End Namespace
