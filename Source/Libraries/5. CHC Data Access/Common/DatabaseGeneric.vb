Option Explicit On
Option Compare Text

Imports System.Data.SQLite

' ****************************************
' Engine: Counter Engine
' Release Engine: 1.0 
' 
' Date last successfully test: 28/05/2022
' ****************************************




Namespace AreaCommon.Database

    Public Class DatabaseGeneric

        Private Property _DBConnectionString As String = "Data source={0};Version=3;"
        Private Property _OwnerId As String = ""
        Private Property _Initialized As Boolean = False

        ''' <summary>
        ''' This is the enumeration relative of a type of db
        ''' </summary>
        Public Enum DBPropertyID
            undefined
            typeOfDB
            dateCreation
            name
            identifyLedger
            lastUpdateTimeStamp
            numVolumes
            numBlocks
            numTransaction
            latestTransaction
        End Enum

        Public Property logInstance As CHCCommonLibrary.AreaEngine.Log.TrackEngine
        Public Property path As String = ""
        Public Property fileName As String = ""



        ''' <summary>
        ''' This method provide to insert SQL
        ''' </summary>
        ''' <param name="sql"></param>
        ''' <returns></returns>
        Public Function executeDataTable(ByVal sql As String) As Boolean
            Try
                Dim connectionDB As SQLiteConnection
                Dim sqlCommand As SQLiteCommand

                If _Initialized Then
                    logInstance.trackEnter("DatabaseGeneric.executeDataTable", _OwnerId)

                    connectionDB = New SQLiteConnection(_DBConnectionString)

                    connectionDB.Open()

                    logInstance.track("DatabaseGeneric.executeDataTable", _OwnerId, "Connection Open")

                    sqlCommand = New SQLiteCommand(connectionDB)

                    sqlCommand.CommandText = sql

                    sqlCommand.ExecuteScalar()

                    logInstance.track("DatabaseGeneric.executeDataTable", _OwnerId, "Command executed")

                    connectionDB.Close()

                    logInstance.track("DatabaseGeneric.executeDataTable", _OwnerId, "Connection Closed")

                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                logInstance.trackException("DatabaseGeneric.executeDataTable", _OwnerId, ex.Message)

                Return False
            Finally
                logInstance.trackExit("DatabaseGeneric.executeDataTable", _OwnerId)
            End Try
        End Function

        ''' <summary>
        ''' This method provide to execute a data table and return the last ID
        ''' </summary>
        ''' <param name="sql"></param>
        ''' <returns></returns>
        Public Function executeDataTableAndReturnID(ByVal sql As String) As Object
            Dim result As Integer = -1
            Try
                Dim connectionDB As SQLiteConnection
                Dim sqlCommand As SQLiteCommand

                If _Initialized Then
                    logInstance.trackEnter("DatabaseGeneric.executeDataTable", _OwnerId)

                    connectionDB = New SQLiteConnection(_DBConnectionString)

                    connectionDB.Open()

                    logInstance.track("DatabaseGeneric.executeDataTable", _OwnerId, "Connection Open")

                    sqlCommand = New SQLiteCommand(connectionDB)

                    sqlCommand.CommandText = sql

                    sqlCommand.ExecuteScalar()

                    logInstance.track("DatabaseGeneric.executeDataTable", _OwnerId, "Command executed")

                    sqlCommand = New SQLiteCommand(connectionDB)

                    sqlCommand.CommandText = "SELECT last_insert_rowid()"

                    result = sqlCommand.ExecuteScalar()

                    connectionDB.Close()

                    logInstance.track("DatabaseGeneric.executeDataTable", _OwnerId, "Connection Closed")
                End If

                Return result
            Catch ex As Exception
                logInstance.trackException("DatabaseGeneric.executeDataTable", _OwnerId, ex.Message)

                Return -1
            Finally
                logInstance.trackExit("DatabaseGeneric.executeDataTable", _OwnerId)
            End Try
        End Function

        ''' <summary>
        ''' This method provide to select only result from a select SQL
        ''' </summary>
        ''' <param name="sql"></param>
        ''' <returns></returns>
        Public Function selectResultDataTable(ByVal sql As String) As Object
            Dim result As Object

            Try
                If _Initialized Then
                    Dim connectionDB As SQLiteConnection
                    Dim sqlCommand As SQLiteCommand

                    logInstance.trackEnter("DatabaseGeneric.selectResultDataTable", _OwnerId)

                    connectionDB = New SQLiteConnection(_DBConnectionString)

                    connectionDB.Open()

                    logInstance.track("DatabaseGeneric.selectResultDataTable", _OwnerId, "DB Open")

                    sqlCommand = New SQLiteCommand(connectionDB)

                    sqlCommand.CommandText = sql

                    result = sqlCommand.ExecuteScalar()

                    logInstance.track("DatabaseGeneric.selectResultDataTable", _OwnerId, "Execute scalar")

                    connectionDB.Close()

                    logInstance.track("DatabaseGeneric.selectResultDataTable", _OwnerId, "DB Close")

                    Return result
                Else
                    Return False
                End If
            Catch ex As Exception
                logInstance.track("DatabaseGeneric.selectResultDataTable", _OwnerId, ex.Message)

                Return Nothing
            Finally
                logInstance.trackExit("DatabaseGeneric.executeDataTable", _OwnerId)
            End Try
        End Function

        ''' <summary>
        ''' This method provide to get a select table data
        ''' </summary>
        ''' <param name="sql"></param>
        ''' <returns></returns>
        Public Function selectDataReader(ByVal sql As String) As Object
            Dim result As Object

            Try
                If _Initialized Then
                    Dim sqlCommand As SQLiteCommand
                    Dim connectionDB As SQLiteConnection

                    logInstance.trackEnter("DatabaseGeneric.selectDataReader", _OwnerId)

                    connectionDB = New SQLiteConnection(_DBConnectionString)

                    connectionDB.Open()

                    logInstance.track("DatabaseGeneric.selectDataReader", _OwnerId, "DB Open")

                    sqlCommand = New SQLiteCommand(connectionDB)

                    sqlCommand.CommandText = sql

                    result = sqlCommand.ExecuteReader()

                    logInstance.track("DatabaseGeneric.selectDataReader", _OwnerId, "Execute scalar")

                    connectionDB.Close()

                    logInstance.track("DatabaseGeneric.selectDataReader", _OwnerId, "DB Close")

                    Return result
                Else
                    Return False
                End If
            Catch ex As Exception
                logInstance.track("DatabaseGeneric.selectDataReader", _OwnerId, ex.Message)

                Return Nothing
            Finally
                logInstance.trackExit("DatabaseGeneric.executeDataTable", _OwnerId)
            End Try
        End Function


        ''' <summary>
        ''' This method provide to delete a SQL Property Identity on DB
        ''' </summary>
        ''' <param name="id"></param>
        ''' <returns></returns>
        Private Function deleteSQLPropertyIdentityDB(ByVal id As DBPropertyID) As Boolean
            Try
                If _Initialized Then
                    Dim sql As String = ""

                    logInstance.trackEnter("DatabaseGeneric.deleteSQLPropertyIdentityDB", _OwnerId)

                    sql = "DELETE FROM dbIdentity WHERE property_id = " & id

                    Return executeDataTable(sql)
                Else
                    Return False
                End If
            Catch ex As Exception
                logInstance.trackException("DatabaseGeneric.deleteSQLPropertyIdentityDB", _OwnerId, ex.Message)

                Return False
            Finally
                logInstance.trackExit("DatabaseGeneric.deleteSQLPropertyIdentityDB", _OwnerId)
            End Try
        End Function

        ''' <summary>
        ''' This method provide to insert a sql property identity on db
        ''' </summary>
        ''' <param name="id"></param>
        ''' <param name="value"></param>
        ''' <returns></returns>
        Private Function insertSQLPropertyIdentityDB(ByVal id As DBPropertyID, ByVal value As String) As Boolean
            Try
                If _Initialized Then
                    Dim sql As String = ""

                    logInstance.trackEnter("DatabaseGeneric.insertSQLPropertyIdentityDB", _OwnerId)

                    sql += "INSERT INTO dbIdentity "
                    sql += " (property_id, value) "
                    sql += "VALUES "
                    sql += " (" & id & ", '" & value & "')"

                    Return executeDataTable(sql)
                Else
                    Return False
                End If
            Catch ex As Exception
                logInstance.trackException("DatabaseGeneric.insertSQLPropertyIdentityDB", _OwnerId, ex.Message)

                Return False
            Finally
                logInstance.trackExit("DatabaseGeneric.insertSQLPropertyIdentityDB", _OwnerId)
            End Try
        End Function

        ''' <summary>
        ''' This method provide to create an identity db table
        ''' </summary>
        ''' <returns></returns>
        Private Function createIdentityDBTable() As Boolean
            Try
                Dim sql As String = ""

                logInstance.trackEnter("DatabaseGeneric.createIdentityDBTable", _OwnerId)

                sql += "CREATE TABLE dbIdentity "
                sql += " (property_id INTEGER PRIMARY KEY, "
                sql += "  value NVARCHAR(1024) NOT NULL "
                sql += ");"

                Return executeDataTable(sql)
            Catch ex As Exception
                logInstance.trackException("DatabaseGeneric.selectResultDataTable", _OwnerId, ex.Message)

                Return False
            Finally
                logInstance.trackExit("DatabaseGeneric.createIdentityDBTable", _OwnerId)
            End Try
        End Function

        ''' <summary>
        ''' This method provide to write an Identity on a DB
        ''' </summary>
        ''' <returns></returns>
        Private Function writeIdentityDB(ByVal nameDB As String, ByVal typeDB As String) As Boolean
            Try
                If _Initialized Then
                    Dim proceed As Boolean = True

                    logInstance.trackEnter("DatabaseGeneric.writeIdentityDB", _OwnerId)

                    If proceed Then
                        deleteSQLPropertyIdentityDB(DBPropertyID.dateCreation)

                        proceed = insertSQLPropertyIdentityDB(DBPropertyID.dateCreation, CHCCommonLibrary.AreaEngine.Miscellaneous.atMomentGMT())
                    End If
                    If proceed Then
                        deleteSQLPropertyIdentityDB(DBPropertyID.name)

                        proceed = insertSQLPropertyIdentityDB(DBPropertyID.name, nameDB)
                    End If
                    If proceed Then
                        deleteSQLPropertyIdentityDB(DBPropertyID.typeOfDB)

                        proceed = insertSQLPropertyIdentityDB(DBPropertyID.typeOfDB, typeDB)
                    End If

                    Return proceed
                Else
                    Return False
                End If
            Catch ex As Exception
                logInstance.trackException("DatabaseGeneric.writeIdentityDB", _OwnerId, ex.Message)

                Return False
            Finally
                logInstance.trackExit("DatabaseGeneric.writeIdentityDB", _OwnerId)
            End Try
        End Function


        ''' <summary>
        ''' This method provide to check parameter of create db
        ''' </summary>
        ''' <returns></returns>
        Public Function init(ByVal nameDB As String, ByVal typeDB As String) As Boolean
            If IsNothing(logInstance) Or (path.Length = 0) Or (fileName.Length = 0) Then
                Return False
            End If

            Try
                Dim dbFileName As String = IO.Path.Combine(path, fileName)

                _OwnerId = Guid.NewGuid.ToString()

                logInstance.trackEnter("DatabaseGeneric.init", _OwnerId)

                If IO.File.Exists(dbFileName) Then
                    _DBConnectionString = String.Format(_DBConnectionString, dbFileName)

                    logInstance.track("DatabaseGeneric.init", _OwnerId, "DB exist")

                    _Initialized = True

                    Return True
                Else
                    logInstance.track("DatabaseGeneric.init", _OwnerId, "DB not exist")

                    SQLiteConnection.CreateFile(dbFileName)

                    logInstance.track("DatabaseGeneric.init", _OwnerId, "DB create")

                    _DBConnectionString = String.Format(_DBConnectionString, dbFileName)

                    _Initialized = True

                    If createIdentityDBTable() Then
                        logInstance.track("DatabaseGeneric.init", _OwnerId, "Identity db table created")

                        If writeIdentityDB(nameDB, typeDB) Then
                            logInstance.track("DatabaseGeneric.init", _OwnerId, "Write Identity DB not created")

                            Return True
                        End If
                    End If

                    Return False
                End If
            Catch ex As Exception
                logInstance.trackException("DatabaseGeneric.init", _OwnerId, ex.Message)

                Return False
            Finally
                logInstance.trackExit("DatabaseGeneric.init", _OwnerId)
            End Try
        End Function

        ''' <summary>
        ''' This method provide to check if the table exist or not
        ''' </summary>
        ''' <param name="tableName"></param>
        ''' <returns></returns>
        Public Function existTable(ByVal tableName As String) As Boolean
            If Not _Initialized Then Return False

            Try
                Dim sql As String
                Dim connectionDB As SQLiteConnection
                Dim result As Object

                logInstance.trackEnter("DatabaseGeneric.existTable", _OwnerId)

                sql = $"SELECT name FROM sqlite_master WHERE type='table' AND name='{tableName}'"

                connectionDB = New SQLiteConnection(_DBConnectionString)

                connectionDB.Open()

                logInstance.track("DatabaseGeneric.existTable", _OwnerId, $"DB Open")

                result = selectResultDataTable(sql)

                If Not IsNothing(result) Then
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                Return False
            End Try
        End Function

    End Class

End Namespace
