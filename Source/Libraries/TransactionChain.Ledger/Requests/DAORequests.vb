Option Compare Text
Option Explicit On

Imports System.Data.SQLite







Namespace AreaCommon.DAO

    ''' <summary>
    ''' This class contain all method manage a DB Ledger
    ''' </summary>
    Friend Class DAORequest

        Private _DBFileName As String = "Requests.Db"
        Private _DBLedgerConnectionString As String = "Data source = {0};Version=3;"

        Public Property logIstance As CHCCommonLibrary.Support.LogEngine


        ''' <summary>
        ''' This method provide to create a DB Requests
        ''' </summary>
        ''' <returns></returns>
        Public Function createDBRequests() As Boolean
            Try
                Dim sql As String = ""

                logIstance.track("DAORequest.createDBRequests", "Begin")

                sql += "CREATE TABLE Requests "
                sql += " (hash NVARCHAR(128) NOT NULL PRIMARY KEY, "
                sql += "  acquire REAL, type NVARCHAR(20), state INTEGER, "
                sql += "  block NVARCHAR(25) NOT NULL"
                sql += ");"

                Return DBGeneric.executeDataTable(sql, String.Format(_DBLedgerConnectionString, _DBFileName))
            Catch ex As Exception
                logIstance.track("DAORequest.createDBRequests", ex.Message, "fatal")

                Return False
            Finally
                logIstance.track("DAORequest.createDBRequests", "Complete")
            End Try
        End Function

        ''' <summary>
        ''' This method provide to save into DB a single transaction
        ''' </summary>
        ''' <returns></returns>
        Public Function addNewRequest(ByVal value As AreaEngine.Requests.RequestManager.RequestData, ByVal [type] As String) As Boolean
            Try
                Dim sql As String = ""
                Dim connectionDB As SQLiteConnection
                Dim sqlCommand As SQLiteCommand

                logIstance.track("DAORequest.addNewRequest", "Begin")

                sql += "INSERT INTO Requests "
                sql += " (acquire, type, hash, state, block) "
                sql += "VALUES "
                sql += " ('" & value.acquire & "','" & [type] & "','" & value.hash & "', "
                sql += "" & value.state & ", "
                sql += "'" & value.block & "')"

                connectionDB = New SQLiteConnection(String.Format(_DBLedgerConnectionString, _DBFileName))

                connectionDB.Open()

                logIstance.track("DAORequest.addNewRequest", "Connection Open")

                sqlCommand = New SQLiteCommand(connectionDB)

                sqlCommand.CommandText = sql

                sqlCommand.ExecuteNonQuery()

                logIstance.track("DAORequest.addNewRequest", "Command executed")

                connectionDB.Close()

                logIstance.track("DAORequest.addNewRequest", "Connection Closed")

                Return True
            Catch ex As Exception
                logIstance.track("DAORequest.addNewRequest", ex.Message, "fatal")

                Return False
            Finally
                logIstance.track("DAORequest.addNewRequest", "Complete")
            End Try
        End Function

        ''' <summary>
        ''' This method provide to get a request from a request hash
        ''' </summary>
        ''' <param name="requestHash"></param>
        ''' <returns></returns>
        Public Function getRequest(ByVal hash As String) As AreaEngine.Requests.RequestManager.RequestData
            Try
                Dim sql As String = ""
                Dim connectionDB As SQLiteConnection
                Dim sqlCommand As SQLiteCommand
                Dim sqlDataReader As SQLiteDataReader
                Dim result As New AreaEngine.Requests.RequestManager.RequestData

                logIstance.track("DAORequest.getRequest", "Begin")

                sql += " SELECT TOP 1 acquire, type, state, coordinate "
                sql += " FROM Requests "
                sql += " WHERE hash = '" & hash & "'"

                connectionDB = New SQLiteConnection(String.Format(_DBLedgerConnectionString, _DBFileName))

                connectionDB.Open()

                logIstance.track("DAORequest.getRequest", "Connection Open")

                sqlCommand = New SQLiteCommand(connectionDB)

                sqlCommand.CommandText = sql

                sqlDataReader = sqlCommand.ExecuteReader()

                If sqlDataReader.HasRows Then
                    sqlDataReader.Read()

                    result.acquire = sqlDataReader("acquire")
                    result.state = sqlDataReader("state")
                    result.block = sqlDataReader("block")
                    result.type = sqlDataReader("type")
                End If

                logIstance.track("DAORequest.getRequest", "Command executed")

                connectionDB.Close()

                logIstance.track("DAORequest.getRequest", "End")

                Return result
            Catch ex As Exception
                logIstance.track("DAORequest.getRequest", ex.Message, "fatal")

                Return New AreaEngine.Requests.RequestManager.RequestData
            Finally
                logIstance.track("DAORequest.getRequest", "Complete")
            End Try
        End Function

        ''' <summary>
        ''' This method provide to set a request state
        ''' </summary>
        ''' <param name="hash"></param>
        ''' <returns></returns>
        Public Function updateState(ByVal hash As String, ByVal state As Integer, ByVal block As String) As Boolean
            Try
                Dim sql As String = ""
                Dim connectionDB As SQLiteConnection
                Dim sqlCommand As SQLiteCommand
                Dim result As New AreaEngine.Requests.RequestManager.RequestData

                logIstance.track("DAORequest.updateState", "Begin")

                sql += "UPDATE Requests "
                sql += "SET state = '" & state & "', block = '" & block & "' "
                sql += "WHERE hash = '" & hash & "'"

                connectionDB = New SQLiteConnection(String.Format(_DBLedgerConnectionString, _DBFileName))

                connectionDB.Open()

                logIstance.track("DAORequest.updateState", "Connection Open")

                sqlCommand = New SQLiteCommand(connectionDB)

                sqlCommand.CommandText = sql

                sqlCommand.ExecuteNonQuery()

                logIstance.track("DAORequest.updateState", "Command executed")

                connectionDB.Close()

                logIstance.track("DAORequest.updateState", "Connection Closed")

                Return True
            Catch ex As Exception
                logIstance.track("DAORequest.updateState", ex.Message, "fatal")

                Return False
            Finally
                logIstance.track("DAORequest.updateState", "Complete")
            End Try
        End Function

        ''' <summary>
        ''' This method provide to delete old request
        ''' </summary>
        ''' <param name="minimalMantainRequestBlock"></param>
        ''' <returns></returns>
        Public Function deleteOldRequest(ByVal minimalMantainRequestBlock As Double) As Boolean
            Try
                Dim sql As String = ""
                Dim connectionDB As SQLiteConnection
                Dim sqlCommand As SQLiteCommand
                Dim result As New AreaEngine.Requests.RequestManager.RequestData

                logIstance.track("DAORequest.deleteOldRequest", "Begin")

                sql += "DELETE FROM Requests "

                sql += "WHERE acquire < '" & CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime - (minimalMantainRequestBlock * 60 * 60 * 24 * 1000) & "'"
                sql += "  AND block <> ''"

                connectionDB = New SQLiteConnection(String.Format(_DBLedgerConnectionString, _DBFileName))

                connectionDB.Open()

                logIstance.track("DAORequest.deleteOldRequest", "Connection Open")

                sqlCommand = New SQLiteCommand(connectionDB)

                sqlCommand.CommandText = sql

                sqlCommand.ExecuteNonQuery()

                logIstance.track("DAORequest.deleteOldRequest", "Command executed")

                connectionDB.Close()

                logIstance.track("DAORequest.deleteOldRequest", "Connection Closed")

                Return True
            Catch ex As Exception
                logIstance.track("DAORequest.deleteOldRequest", ex.Message, "fatal")

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to get an old block
        ''' </summary>
        ''' <param name="minimalMaintenanceRequestBlock "></param>
        ''' <returns></returns>
        Public Function getOldBlock(ByVal minimalMaintenanceRequestBlock As Double) As List(Of String)
            Try
                Dim sql As String = ""
                Dim connectionDB As SQLiteConnection
                Dim sqlCommand As SQLiteCommand
                Dim sqlDataReader As SQLiteDataReader
                Dim result As New List(Of String)

                logIstance.track("DAORequest.getOldBlock", "Begin")

                sql += "SELECT DISTINCT block "
                sql += "FROM Requests "

                sql += "WHERE acquire < '" & CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime - (minimalMaintenanceRequestBlock * 60 * 60 * 24 * 1000) & "'"
                sql += "  AND block <> ''"

                connectionDB = New SQLiteConnection(String.Format(_DBLedgerConnectionString, _DBFileName))

                connectionDB.Open()

                logIstance.track("DAORequest.getOldBlock", "Connection Open")

                sqlCommand = New SQLiteCommand(connectionDB)

                sqlCommand.CommandText = sql

                sqlDataReader = sqlCommand.ExecuteReader()

                If sqlDataReader.HasRows() Then
                    Do While sqlDataReader.Read()
                        result.Add(sqlDataReader("block"))
                    Loop
                End If

                logIstance.track("DAORequest.getOldBlock", "Command executed")

                connectionDB.Close()

                logIstance.track("DAORequest.getOldBlock", "End")

                Return result
            Catch ex As Exception
                logIstance.track("DAORequest.getOldBlock", ex.Message, "fatal")

                Return New List(Of String)
            Finally
                logIstance.track("DAORequest.getOldBlock", "Complete")
            End Try
        End Function

        ''' <summary>
        ''' This method provide to get an old file
        ''' </summary>
        ''' <param name="minimalMaintenanceRequestBlock"></param>
        ''' <returns></returns>
        Public Function getOldFile(ByVal minimalMaintenanceRequestBlock As Double, ByVal state As Integer) As List(Of String)
            Try
                Dim sql As String = ""
                Dim connectionDB As SQLiteConnection
                Dim sqlCommand As SQLiteCommand
                Dim sqlDataReader As SQLiteDataReader
                Dim result As New List(Of String)

                logIstance.track("DAORequest.getOldFile", "Begin")

                sql += "SELECT hash "
                sql += "FROM Requests "

                sql += "WHERE acquire < '" & CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime - (minimalMaintenanceRequestBlock * 60 * 60 * 24 * 1000) & "'"
                sql += " AND state = " & state

                connectionDB = New SQLiteConnection(String.Format(_DBLedgerConnectionString, _DBFileName))

                connectionDB.Open()

                logIstance.track("DAORequest.getOldFile", "Connection Open")

                sqlCommand = New SQLiteCommand(connectionDB)

                sqlCommand.CommandText = sql

                sqlDataReader = sqlCommand.ExecuteReader()

                If sqlDataReader.HasRows() Then
                    Do While sqlDataReader.Read()
                        result.Add(sqlDataReader("hash"))
                    Loop
                End If

                logIstance.track("DAORequest.getOldFile", "Command executed")

                connectionDB.Close()

                logIstance.track("DAORequest.getOldFile", "End")

                Return result
            Catch ex As Exception
                logIstance.track("DAORequest.getOldFile", ex.Message, "fatal")

                Return New List(Of String)
            Finally
                logIstance.track("DAORequest.getOldFile", "Complete")
            End Try
        End Function

        ''' <summary>
        ''' This method provide to initialize a db ledger
        ''' </summary>
        ''' <returns></returns>
        Public Function init(ByVal basePath As String) As Boolean
            Try
                Dim proceed As Boolean = True

                logIstance.track("init.initDBLedger", "Begin")

                _DBFileName = IO.Path.Combine(basePath, "Requests.Db")

                DBGeneric.logIstance = logIstance

                logIstance.track("init.initDBLedger", "Set db in" & _DBFileName)

                If Not IO.File.Exists(_DBFileName) Then
                    logIstance.track("init.initDBLedger", "Db file not exist")

                    SQLiteConnection.CreateFile(_DBFileName)

                    logIstance.track("init.initDBLedger", "Db created")

                    If proceed Then
                        proceed = DBGeneric.createIdentityDBTable(String.Format(_DBLedgerConnectionString, _DBFileName))
                    End If
                    If proceed Then
                        proceed = DBGeneric.writeIdentityDB(String.Format(_DBLedgerConnectionString, _DBFileName), "Requests", "Requests")
                    End If
                    If proceed Then
                        proceed = createDBRequests()
                    End If

                    Return proceed
                End If
            Catch ex As Exception
                logIstance.track("init.initDBLedger", ex.Message, "fatal")
            Finally
                logIstance.track("init.initDBLedger", "Complete")
            End Try

            Return False
        End Function

    End Class

End Namespace
