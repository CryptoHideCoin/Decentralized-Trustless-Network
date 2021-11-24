Option Compare Text
Option Explicit On

Imports System.Data.SQLite







Namespace AreaCommon.DAO

    ''' <summary>
    ''' This class contain all method manage a DB Ledger
    ''' </summary>
    Public Class DAOLedger

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
                sql += " (block NVARCHAR(25) NOT NULL PRIMARY KEY, "
                sql += "  path_id INTEGER NOT NULL, "
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
                sql += " (id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, "
                sql += "  path NVARCHAR(4096) NOT NULL "
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
        Public Function getRequestPath(ByVal blockInformation As String) As String
            Try
                Dim sql As String = ""
                Dim connectionDB As SQLiteConnection
                Dim sqlCommand As SQLiteCommand
                Dim sqlDataReader As SQLiteDataReader
                Dim result As String

                log.track("DAOLedger.getRequestPath", "Begin")

                sql += " SELECT basePAth.path as basePathBlock"
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

                log.track("DAOLedger.getRequestPath", "Complete")

                Return result
            Catch ex As Exception
                log.track("DAOLedger.getRequestPath", ex.Message, "fatal")

                Return ""
            End Try
        End Function

        ''' <summary>
        ''' This method provide to save into DB a single transaction
        ''' </summary>
        ''' <returns></returns>
        Public Function saveData(ByRef data As AreaLedger.SingleTransactionLedger) As Boolean
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
