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
        ''' This method provide to create a table ledger map
        ''' </summary>
        ''' <returns></returns>
        Private Function createTableLedgerMap() As Boolean
            Try
                Dim sql As String = ""

                log.track("DAOLedger.createTableLedgerMap", "Begin")

                sql += "CREATE TABLE ledgerMap "
                sql += " (block NVARCHAR(25) NOT NULL PRIMARY KEY, "
                sql += "  path_id INTEGER NOT NULL "
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

                log.track("DAOLedger.initDBLedger", "Begin")

                dbFileName = composeCoordinate
                dbFileName = IO.Path.Combine(basePath, "BlockData.db")

                DBGeneric.logIstance = log

                log.track("DAOLedger.initDBLedger", "Set db in" & dbFileName)

                If Not IO.File.Exists(dbFileName) Then
                    log.track("DAOLedger.initDBLedger", "Db file not exist")

                    SQLiteConnection.CreateFile(dbFileName)

                    log.track("DAOLedger.initDBLedger", "Db created")

                    _DBBlockDataConnectionString = String.Format(_DBBlockDataConnectionString, dbFileName)

                    If proceed Then
                        proceed = DBGeneric.createIdentityDBTable(_DBBlockDataConnectionString)
                    End If
                    If proceed Then
                        proceed = DBGeneric.writeIdentityDB(_DBBlockDataConnectionString, composeCoordinate, "BlockData")
                    End If
                    If proceed Then
                        proceed = createTableBlockLedger()
                    End If

                    Return proceed
                End If
            Catch ex As Exception
                log.track("DAOLedger.initDBLedger", ex.Message, "fatal")
            Finally
                log.track("DAOLedger.initDBLedger", "Complete")
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

                log.track("DAOLedger.createDBLedgerIndex", "Begin")

                dbFileName = IO.Path.Combine(basePath, "LedgerMap.db")

                SQLiteConnection.CreateFile(dbFileName)

                log.track("DAOLedger.createDBLedgerIndex", "Db created")

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
                log.track("DAOLedger.initDBLedger", ex.Message, "fatal")
            Finally
                log.track("DAOLedger.initDBLedger", "Complete")
            End Try

            Return False
        End Function

    End Class

End Namespace
