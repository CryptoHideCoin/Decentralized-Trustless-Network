Option Compare Text
Option Explicit On

Imports System.Data.SQLite
Imports CHCLedgerLibrary.AreaDataAccess.Generic
Imports CHCProtocolLibrary.AreaCommon.Models.Ledger





Namespace AreaDataAccess.Ledger

    ''' <summary>
    ''' This class contain all method manage a DB Ledger
    ''' </summary>
    Public Class DAOLedger

        ''' <summary>
        ''' This class contain the element of result transaction
        ''' </summary>
        Public Class ServiceTransactionBlock

            Public Property value As New SingleTransactionLedger
            Public Property blockPath As String

        End Class

        Private _DBBlockDataConnectionString As String = "Data source = {0};Version=3;"
        Private _DBLedgerIndexConnectionString As String = "Data source = {0};Version=3;"
        Private _ConnectionDBOpened As SQLiteConnection
        Private _CurrentIdOriginPath As Integer = 0

        Public Property log As CHCCommonLibrary.Support.LogEngine


        ''' <summary>
        ''' This method provide to create a table block ledger
        ''' </summary>
        ''' <returns></returns>
        Private Function createTableBlockLedger() As Boolean
            Try
                Dim sql As String = ""

                log.track("DAOLedger.createDBBlockLedger", "Begin")

                sql += "CREATE TABLE blockData "
                sql += " (id INTEGER PRIMARY KEY, "
                sql += "  registrationDate DOUBLE NOT NULL, "
                sql += "  type NVARCHAR(10) NOT NULL, "
                sql += "  requesterPublicAddress NVARCHAR(4096) NOT NULL, "
                sql += "  approverPublicAddress NVARCHAR(65536) NOT NULL, "
                sql += "  requestHash NVARCHAR(128) NOT NULL, "
                sql += "  detailInformation NVARCHAR(65536) NOT NULL, "
                sql += "  consensusHash NVARCHAR(128) NOT NULL, "
                sql += "  currentHash NVARCHAR(128) NOT NULL, "
                sql += "  progressiveHash NVARCHAR(128) NOT NULL "
                sql += ");"

                Return DBGeneric.executeDataTable(sql, _DBBlockDataConnectionString)
            Catch ex As Exception
                log.track("DAOLedger.createDBBlockLedger", ex.Message, "fatal")

                Return False
            Finally
                log.track("DAOLedger.createDBBlockLedger", "Complete")
            End Try
        End Function

        ''' <summary>
        ''' This method provide to create a registration date index
        ''' </summary>
        ''' <returns></returns>
        Private Function createRegistrationDateIndex() As Boolean
            Try
                Dim sql As String = ""

                log.track("DAOLedger.createRegistrationDateIndex", "Begin")

                sql += "CREATE UNIQUE INDEX primaryIndex "
                sql += " ON blockData (registrationDate);"

                Return DBGeneric.executeDataTable(sql, _DBBlockDataConnectionString)
            Catch ex As Exception
                log.track("DAOLedger.createRegistrationDateIndex", ex.Message, "fatal")

                Return False
            Finally
                log.track("DAOLedger.createRegistrationDateIndex", "Complete")
            End Try
        End Function

        ''' <summary>
        ''' This method provide to retrieve a minimum timeStamp (registrationDate) from a blockData table and matain the connection opened
        ''' </summary>
        ''' <returns></returns>
        Public Function getFromTimeStampWithConnectionPersistent() As Double
            Try
                Dim sql As String = ""
                Dim idValue

                log.track("DAOLedger.getFromTimeStampWithConnectionPersistent", "Begin")

                sql += "SELECT Min(registrationDate) as minRegistrationDate FROM blockData "

                idValue = DBGeneric.selectResultDataTable(sql, _DBBlockDataConnectionString, False, _ConnectionDBOpened)

                If IsNumeric(idValue) Then
                    Return idValue
                Else
                    Return 0
                End If
            Catch ex As Exception
                log.track("DAOLedger.getFromTimeStampWithConnectionPersistent", ex.Message, "fatal")

                Return -1
            Finally
                log.track("DAOLedger.getFromTimeStampWithConnectionPersistent", "Complete")
            End Try
        End Function

        ''' <summary>
        ''' This method provide to get a block number into volume
        ''' </summary>
        ''' <param name="ledgerIdentify"></param>
        ''' <param name="volumeNumber"></param>
        ''' <returns></returns>
        Public Function getBlockNumberIntoVolume(ByVal ledgerIdentify As String, ByVal volumeNumber As Integer) As Integer
            Try
                Dim sql As String
                Dim volumePath As String = ledgerIdentify & "-" & volumeNumber.ToString.Trim() & "-"
                Dim value

                log.track("DAOLedger.getBlockNumberIntoVolume", "Begin")

                sql += "SELECT Count(block) as numBlocks FROM ledgerMap WHERE block like '%" & volumePath & "%'"

                value = DBGeneric.selectResultDataTable(sql, _DBLedgerIndexConnectionString, True)

                If IsNumeric(value) Then
                    Return value
                Else
                    Return 0
                End If
            Catch ex As Exception
                log.track("DAOLedger.getBlockNumberIntoVolume", ex.Message, "fatal")

                Return -1
            Finally
                log.track("DAOLedger.getBlockNumberIntoVolume", "Complete")
            End Try
        End Function

        ''' <summary>
        ''' This method provide to get a transaction number into block
        ''' </summary>
        ''' <param name="blockNumber"></param>
        ''' <returns></returns>
        Public Function getTransactionsNumberIntoBlock(ByVal blockNumber As String) As Integer
            Try
                Dim sql As String
                Dim blockPath As String, dbConnectionString As String
                Dim value

                log.track("DAOLedger.getTransactionsIntoBlock", "Begin")

                blockPath = getBaseLedgerPath(blockNumber)
                blockPath = IO.Path.Combine(blockPath, blockPath, "BlockData.DB")

                dbConnectionString = String.Format("Data source = {0};Version=3;", blockPath)

                sql += "SELECT Count(id) as numTransactions FROM blockData"

                value = DBGeneric.selectResultDataTable(sql, dbConnectionString)

                If IsNumeric(value) Then
                    Return value
                Else
                    Return 0
                End If
            Catch ex As Exception
                log.track("DAOLedger.getTransactionsIntoBlock", ex.Message, "fatal")

                Return -1
            Finally
                log.track("DAOLedger.getTransactionsIntoBlock", "Complete")
            End Try
        End Function

        ''' <summary>
        ''' This method provide to get a page data relative a transaction's block
        ''' </summary>
        ''' <param name="blockNumber"></param>
        ''' <param name="pageNumber"></param>
        ''' <returns></returns>
        Public Function getPageTransactionsIntoBlock(ByVal blockNumber As String, ByVal pageNumber As Integer) As List(Of SingleTransactionLedger)
            Dim result As New List(Of SingleTransactionLedger)
            Try
                Dim sql As String = ""
                Dim idMin As Integer = (pageNumber - 1) * 20, idMax As Integer = idMin + 19
                Dim blockPath As String, dbConnectionString As String
                Dim reader As SQLiteDataReader
                Dim rowData As SingleTransactionLedger

                log.track("DAOLedger.getPageTransactionsIntoBlock", "Begin")

                blockPath = getBaseLedgerPath(blockNumber)
                blockPath = IO.Path.Combine(blockPath, blockNumber, "BlockData.DB")

                dbConnectionString = String.Format("Data source = {0};Version=3;", blockPath)

                sql += " SELECT id, registrationDate, type, requesterPublicAddress, approverPublicAddress, requestHash, detailInformation, consensusHash, currentHash, progressiveHash "
                sql += " FROM blockData "
                sql += " WHERE (id >= " & idMin & ") AND (id <= " & idMax & ")"

                reader = DBGeneric.selectDataReader(sql, dbConnectionString, False)

                While reader.Read()
                    rowData = New SingleTransactionLedger

                    rowData.id = reader.Item("id")

                    Try
                        rowData.registrationTimeStamp = CDbl(reader.GetString(1))
                    Catch ex As Exception
                        rowData.registrationTimeStamp = CDbl(reader.GetDouble(1))
                    End Try

                    rowData.[type] = reader.Item("type")
                    rowData.requesterPublicAddress = reader.Item("requesterPublicAddress")
                    rowData.approverPublicAddress = reader.Item("approverPublicAddress")
                    rowData.requestHash = reader.Item("requestHash")
                    rowData.detailInformation = reader.Item("detailInformation")
                    rowData.consensusHash = reader.Item("consensusHash")
                    rowData.currentHash = reader.Item("currentHash")
                    rowData.progressiveHash = reader.Item("progressiveHash")

                    result.Add(rowData)
                End While

                log.track("DAOLedger.getPageTransactionsIntoBlock", "Complete")
            Catch ex As Exception
                log.track("DAOLedger.getPageTransactionsIntoBlock", ex.Message, "fatal")
            End Try

            Return result
        End Function

        ''' <summary>
        ''' This method provide to get an all information of a SingleTransactionLedger
        ''' </summary>
        ''' <param name="blockNumber"></param>
        ''' <param name="transactionID"></param>
        ''' <returns></returns>
        Public Function getTransactionIntoBlock(ByVal blockNumber As String, ByVal transactionID As String) As ServiceTransactionBlock
            Dim result As New ServiceTransactionBlock

            Try
                Dim sql As String = ""
                Dim blockPath As String, dbConnectionString As String
                Dim reader As SQLiteDataReader

                log.track("DAOLedger.getTransactionIntoBlock", "Begin")

                result.blockPath = IO.Path.Combine(getBaseLedgerPath(blockNumber), blockNumber)
                blockPath = IO.Path.Combine(result.blockPath, "BlockData.DB")

                dbConnectionString = String.Format("Data source = {0};Version=3;", blockPath)

                sql += " SELECT id, registrationDate, type, requesterPublicAddress, approverPublicAddress, requestHash, detailInformation, consensusHash, currentHash, progressiveHash "
                sql += " FROM blockData "
                sql += " WHERE id = " & transactionID

                reader = DBGeneric.selectDataReader(sql, dbConnectionString, False)

                If reader.Read() Then
                    result.value.id = reader.Item("id")

                    Try
                        result.value.registrationTimeStamp = CDbl(reader.GetString(1))
                    Catch ex As Exception
                        result.value.registrationTimeStamp = CDbl(reader.GetDouble(1))
                    End Try

                    result.value.[type] = reader.Item("type")
                    result.value.requesterPublicAddress = reader.Item("requesterPublicAddress")
                    result.value.approverPublicAddress = reader.Item("approverPublicAddress")
                    result.value.requestHash = reader.Item("requestHash")
                    result.value.detailInformation = reader.Item("detailInformation")
                    result.value.consensusHash = reader.Item("consensusHash")
                    result.value.currentHash = reader.Item("currentHash")
                    result.value.progressiveHash = reader.Item("progressiveHash")
                End If

                log.track("DAOLedger.getTransactionIntoBlock", "Complete")
            Catch ex As Exception
                log.track("DAOLedger.getTransactionIntoBlock", ex.Message, "fatal")
            End Try

            Return result
        End Function

        ''' <summary>
        ''' This method provide to retrieve a maximum timeStamp (registrationDate) from a blockData table and close connection
        ''' </summary>
        ''' <returns></returns>
        Public Function getToTimeStampAndCloseConnection() As Double
            Try
                Dim sql As String = ""
                Dim idValue

                log.track("DAOLedger.getToTimeStampAndCloseConnection", "Begin")

                sql += "SELECT Max(registrationDate) as maxRegistrationDate FROM blockData "

                idValue = DBGeneric.selectResultDataTable(sql, _DBBlockDataConnectionString, True, _ConnectionDBOpened)

                _ConnectionDBOpened.Close()

                If IsNumeric(idValue) Then
                    Return idValue
                Else
                    Return 0
                End If
            Catch ex As Exception
                log.track("DAOLedger.getToTimeStampAndCloseConnection", ex.Message, "fatal")

                Return -1
            Finally
                log.track("DAOLedger.getToTimeStampAndCloseConnection", "Complete")
            End Try
        End Function

        ''' <summary>
        ''' This method provide to create a table ledger map
        ''' </summary>
        ''' <returns></returns>
        Private Function createTableLedgerMap() As Boolean
            Try
                Dim sql As String = ""

                log.track("DAOLedger.createTableLedgerMap", "Begin")

                sql += "CREATE TABLE ledgerMap "
                sql += " (block NVARCHAR(25) Not NULL PRIMARY KEY, "
                sql += "  path_id INTEGER Not NULL, "
                sql += "  hash NVARCHAR(128) "
                sql += ");"

                Return DBGeneric.executeDataTable(sql, _DBLedgerIndexConnectionString)
            Catch ex As Exception
                log.track("DAOLedger.createTableLedgerMap", ex.Message, "fatal")

                Return False
            Finally
                log.track("DAOLedger.createTableLedgerMap", "Complete")
            End Try
        End Function

        ''' <summary>
        ''' This method provide to create a table ledger map
        ''' </summary>
        ''' <returns></returns>
        Private Function createTableBasePath() As Boolean
            Try
                Dim sql As String = ""

                log.track("DAOLedger.createTableBasePath", "Begin")

                sql += "CREATE TABLE basePath "
                sql += " (id INTEGER PRIMARY KEY AUTOINCREMENT Not NULL, "
                sql += "  path NVARCHAR(4096) Not NULL "
                sql += ");"

                Return DBGeneric.executeDataTable(sql, _DBLedgerIndexConnectionString)
            Catch ex As Exception
                log.track("DAOLedger.createTableBasePath", ex.Message, "fatal")

                Return False
            Finally
                log.track("DAOLedger.createTableBasePath", "Complete")
            End Try
        End Function

        ''' <summary>
        ''' This method provide to get id origin by path
        ''' </summary>
        ''' <param name="basePath"></param>
        ''' <returns></returns>
        Private Function getIdOriginByPath(ByVal basePath As String) As Integer
            Try
                Dim sql As String = ""
                Dim idValue

                log.track("DAOLedger.getIdOriginByPath", "Begin")

                sql += "SELECT id FROM basePath WHERE path = '" & basePath & "'"

                idValue = DBGeneric.selectResultDataTable(sql, _DBLedgerIndexConnectionString)

                If IsNumeric(idValue) Then
                    Return idValue
                Else
                    Return -1
                End If
            Catch ex As Exception
                log.track("DAOLedger.getIdOriginByPath", ex.Message, "fatal")

                Return -1
            Finally
                log.track("DAOLedger.getIdOriginByPath", "Complete")
            End Try
        End Function

        ''' <summary>
        ''' This method provide to get the origin by addNew
        ''' </summary>
        ''' <param name="basePath"></param>
        ''' <returns></returns>
        Private Function getIdOriginByAddNew(ByVal basePath As String) As Integer
            Try
                Dim sql As String = ""

                log.track("DAOLedger.getIdOriginByAddNew", "Begin")

                sql += "INSERT INTO basePath (path) VALUES ('" & basePath & "');SELECT last_insert_rowid()"

                Return DBGeneric.insertDataTableWithResult(sql, _DBLedgerIndexConnectionString)
            Catch ex As Exception
                log.track("DAOLedger.getIdOriginByAddNew", ex.Message, "fatal")

                Return -1
            Finally
                log.track("DAOLedger.getIdOriginByAddNew", "Complete")
            End Try
        End Function

        ''' <summary>
        ''' This method provide to add a new block path
        ''' </summary>
        ''' <param name="blockName"></param>
        ''' <returns></returns>
        Public Function addNewBlockPath(ByVal blockName As String) As Boolean
            Try
                Dim sql As String = ""

                log.track("DAOLedger.addNewBlockPath", "Begin")

                sql += "INSERT INTO ledgerMap (block, path_id) VALUES ('" & blockName & "'," & _CurrentIdOriginPath & ")"

                Return DBGeneric.executeDataTable(sql, _DBLedgerIndexConnectionString)
            Catch ex As Exception
                log.track("DAOLedger.addNewBlockPath", ex.Message, "fatal")

                Return False
            Finally
                log.track("DAOLedger.addNewBlockPath", "Complete")
            End Try
        End Function

        ''' <summary>
        ''' This method provide to update a block path  
        ''' </summary>
        ''' <param name="blockName"></param>
        ''' <param name="hash"></param>
        ''' <returns></returns>
        Public Function updateBlockPath(ByVal blockName As String, ByVal hash As String) As Boolean
            Try
                Dim sql As String = ""

                log.track("DAOLedger.updateBlockPath", "Begin")

                sql += "UPDATE ledgerMap SET hash = '" & hash & "' WHERE block = '" & blockName & "'"

                Return DBGeneric.executeDataTable(sql, _DBLedgerIndexConnectionString)
            Catch ex As Exception
                log.track("DAOLedger.updateBlockPath", ex.Message, "fatal")

                Return False
            Finally
                log.track("DAOLedger.updateBlockPath", "Complete")
            End Try
        End Function

        ''' <summary>
        ''' This method provide to retrieve a path origin
        ''' </summary>
        ''' <param name="basePath"></param>
        ''' <returns></returns>
        Private Function retrievePathOrigin(ByVal basePath As String) As Boolean
            Try
                log.track("DAOLedger.retrievePathOrigin", "Begin")

                _CurrentIdOriginPath = getIdOriginByPath(basePath)

                If (_CurrentIdOriginPath = -1) Then
                    _CurrentIdOriginPath = getIdOriginByAddNew(basePath)

                    Return (_CurrentIdOriginPath <> -1)
                End If
            Catch ex As Exception
                log.track("DAOLedger.retrievePathOrigin", ex.Message, "fatal")
            Finally
                log.track("DAOLedger.retrievePathOrigin", "Complete")
            End Try

            Return False
        End Function

        ''' <summary>
        ''' This method provide to retrieve a get path
        ''' </summary>
        ''' <param name="blockInformation"></param>
        ''' <returns></returns>
        Public Function getBaseLedgerPath(ByVal blockInformation As String) As String
            Try
                Dim sql As String = ""
                Dim connectionDB As SQLiteConnection
                Dim sqlCommand As SQLiteCommand
                Dim sqlDataReader As SQLiteDataReader
                Dim result As String

                log.track("DAOLedger.getBaseLedgerPath", "Begin")

                sql += " SELECT basePath.path as basePathBlock"
                sql += " From ledgerMap "
                sql += " LEFT JOIN basePath ON ledgerMap.path_id = basePath.id"
                sql += " WHERE ledgerMap.block = '" & blockInformation & "'"

                connectionDB = New SQLiteConnection(_DBLedgerIndexConnectionString)

                connectionDB.Open()

                sqlCommand = New SQLiteCommand(connectionDB)

                sqlCommand.CommandText = sql

                sqlDataReader = sqlCommand.ExecuteReader()

                sqlDataReader.Read()

                result = sqlDataReader("basePathBlock")

                connectionDB.Close()

                log.track("DAOLedger.getBaseLedgerPath", "Complete")

                Return result
            Catch ex As Exception
                log.track("DAOLedger.getBaseLedgerPath", ex.Message, "fatal")

                Return ""
            End Try
        End Function

        ''' <summary>
        ''' This method provide to save into DB a single transaction
        ''' </summary>
        ''' <returns></returns>
        Public Function saveData(ByRef data As SingleTransactionLedger) As Boolean
            Try
                Dim sql As String = ""
                Dim connectionDB As SQLiteConnection
                Dim sqlCommand As SQLiteCommand

                log.track("DAOLedger.saveData", "Begin")

                sql += "INSERT INTO blockData "
                sql += " (id, registrationDate, type, requesterPublicAddress, approverPublicAddress, requestHash, consensusHash, detailInformation, currentHash, progressiveHash) "
                sql += "VALUES "
                sql += " (" & data.id & ", "
                sql += "'" & data.registrationTimeStamp & "', "
                sql += "'" & data.type & "', "
                sql += "'" & data.requesterPublicAddress & "', "
                sql += "'" & data.approverPublicAddress & "', "
                sql += "'" & data.requestHash & "', "
                sql += "'" & data.consensusHash & "', "
                sql += "'" & data.detailInformation & "', "
                sql += "'" & data.currentHash & "', "
                sql += "'" & data.progressiveHash & "' "
                sql += ")"

                connectionDB = New SQLiteConnection(_DBBlockDataConnectionString)

                connectionDB.Open()

                log.track("DAOLedger.saveData", "Connection Open")

                sqlCommand = New SQLiteCommand(connectionDB)

                sqlCommand.CommandText = sql

                sqlCommand.ExecuteScalar()

                log.track("DAOLedger.saveData", "Command executed")

                connectionDB.Close()

                log.track("DAOLedger.saveData", "Connection Closed")

                Return True
            Catch ex As Exception
                log.track("DAOLedger.saveData", ex.Message, "fatal")

                Return False
            Finally
                log.track("DAOLedger.saveData", "Complete")
            End Try
        End Function

        ''' <summary>
        ''' This method provide to create a db ledger
        ''' </summary>
        ''' <returns></returns>
        Public Function createDBLedgerBlockData(ByVal basePath As String, ByVal composeCoordinate As String) As Boolean
            Try
                Dim proceed As Boolean = True
                Dim dbFileName As String = ""

                log.track("DAOLedger.createDBLedgerBlockData", "Begin")

                dbFileName = composeCoordinate
                dbFileName = IO.Path.Combine(basePath, "BlockData.DB")

                DBGeneric.logIstance = log

                log.track("DAOLedger.initDBLedger", "Set db in" & dbFileName)

                If Not IO.File.Exists(dbFileName) Then
                    log.track("DAOLedger.initDBLedger", "Db file not exist")

                    SQLiteConnection.CreateFile(dbFileName)

                    log.track("DAOLedger.initDBLedger", "Db created")

                    _DBBlockDataConnectionString = String.Format("Data source = {0};Version=3;", dbFileName)

                    If proceed Then
                        proceed = DBGeneric.createIdentityDBTable(_DBBlockDataConnectionString)
                    End If
                    If proceed Then
                        proceed = DBGeneric.writeIdentityDB(_DBBlockDataConnectionString, composeCoordinate, "BlockData")
                    End If
                    If proceed Then
                        proceed = createTableBlockLedger()
                    End If
                    If proceed Then
                        proceed = createRegistrationDateIndex()
                    End If

                    Return proceed
                End If
            Catch ex As Exception
                log.track("DAOLedger.createDBLedgerBlockData", ex.Message, "fatal")
            Finally
                log.track("DAOLedger.createDBLedgerBlockData", "Complete")
            End Try

            Return False
        End Function

        ''' <summary>
        ''' This method provide to create a db ledger Map
        ''' </summary>
        ''' <param name="basePath"></param>
        ''' <returns></returns>
        Public Function createDBLedgerMap(ByVal basePath As String) As Boolean
            Try
                Dim proceed As Boolean = True
                Dim dbFileName As String = ""

                log.track("DAOLedger.createDBLedgerMap", "Begin")

                dbFileName = IO.Path.Combine(basePath, "LedgerMap.DB")

                SQLiteConnection.CreateFile(dbFileName)

                log.track("DAOLedger.createDBLedgerMap", "Db created")

                _DBLedgerIndexConnectionString = String.Format(_DBLedgerIndexConnectionString, dbFileName)

                If proceed Then
                    proceed = DBGeneric.createIdentityDBTable(_DBLedgerIndexConnectionString)
                End If
                If proceed Then
                    proceed = DBGeneric.writeIdentityDB(_DBLedgerIndexConnectionString, "LedgerMap", "LedgerMap")
                End If
                If proceed Then
                    proceed = createTableLedgerMap()
                End If
                If proceed Then
                    proceed = createTableBasePath()
                End If
                If proceed Then
                    proceed = retrievePathOrigin(basePath)
                End If

                Return proceed
            Catch ex As Exception
                log.track("DAOLedger.createDBLedgerMap", ex.Message, "fatal")
            Finally
                log.track("DAOLedger.createDBLedgerMap", "Complete")
            End Try

            Return False
        End Function

        ''' <summary>
        ''' This method provide to write to property on db
        ''' </summary>
        ''' <param name="id"></param>
        ''' <param name="value"></param>
        ''' <returns></returns>
        Public Function writePropertyOnDB(ByVal id As DBGeneric.DBPropertyID, ByVal value As String) As Boolean
            Return DBGeneric.writePropertyOnDB(_DBLedgerIndexConnectionString, id, value)
        End Function

        ''' <summary>
        ''' This method provide to read a property on db
        ''' </summary>
        ''' <param name="id"></param>
        ''' <returns></returns>
        Public Function getPropertyOnDB(ByVal id As DBGeneric.DBPropertyID) As String
            Return DBGeneric.getPropertyOnDB(_DBLedgerIndexConnectionString, id)
        End Function

        ''' <summary>
        ''' This method provide to initialize the object
        ''' </summary>
        ''' <param name="basePath"></param>
        ''' <returns></returns>
        Public Function init(ByVal basePath As String, Optional ByVal toLedgerIndex As Boolean = False) As Boolean
            Try
                Dim dbFileName As String = ""

                log.track("DAOLedger.init", "Begin")

                If toLedgerIndex Then
                    dbFileName = IO.Path.Combine(basePath, "LedgerMap.DB")

                    _DBLedgerIndexConnectionString = String.Format(_DBLedgerIndexConnectionString, dbFileName)
                Else
                    dbFileName = IO.Path.Combine(basePath, "BlockData.DB")

                    _DBBlockDataConnectionString = String.Format(_DBBlockDataConnectionString, dbFileName)
                End If

                log.track("DAOLedger.init", "Complete")

                Return True
            Catch ex As Exception
                log.track("DAOLedger.init", ex.Message, "fatal")

                Return False
            End Try
        End Function

    End Class

End Namespace