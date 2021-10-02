Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.Encryption
Imports System.Data.SQLite
Imports CHCCommonLibrary.Support





Namespace AreaLedger

    Public Class LedgerEngine

        Public Class SingleRecordLedger

            Public Property id As Integer = 0
            Public Property registrationDate As Double = 0
            Public Property actionCode As String = ""
            Public Property requesterPublicAddress As String = ""
            Public Property approverPublicAddress As String = ""
            Public Property requestHash As String = ""
            Public Property consensusHash As String = ""
            Public Property detailInformation As String = ""
            Public Property currentHash As String = ""
            Public Property progressiveHash As String = ""

            Private Function fillEmptyText(ByVal value As String) As String
                If (value.Trim.Length > 0) Then
                    Return value
                Else
                    Return "---"
                End If
            End Function

            Public Function toMemoryFromFile(ByVal value As String) As Boolean
                Try
                    Dim elements = value.Split("|")

                    If (UBound(elements) = 7) Then

                        If IsNumeric(elements(0)) Then
                            If Not Integer.TryParse(elements(0), id) Then
                                Return False
                            End If
                        Else
                            Return False
                        End If

                        If IsNumeric(elements(1)) Then
                            If Not Double.TryParse(elements(1), registrationDate) Then
                                Return False
                            End If
                        Else
                            Return False
                        End If

                        actionCode = elements(2)
                        requesterPublicAddress = elements(3)
                        approverPublicAddress = elements(4)
                        requestHash = elements(5)
                        consensusHash = elements(7)
                        detailInformation = elements(4)
                        currentHash = elements(8)
                        progressiveHash = elements(9)

                        Return True
                    Else
                        Return False
                    End If
                Catch ex As Exception
                    Return False
                End Try
            End Function

            Public Function toStringToFile(Optional ByVal separator As String = "|", Optional limited As Boolean = False) As String
                Dim tmp As String = ""

                tmp += id.ToString() & separator
                tmp += registrationDate.ToString() & separator
                tmp += actionCode & separator
                tmp += requesterPublicAddress & separator
                tmp += approverPublicAddress & separator
                tmp += requestHash & separator
                tmp += fillEmptyText(consensusHash) & separator
                tmp += detailInformation & separator

                If Not limited Then
                    tmp += currentHash & separator
                    tmp += progressiveHash
                End If

                Return tmp
            End Function

            Public Overrides Function toString() As String
                Return toStringToFile("", True)
            End Function

            Public Function getHash() As String
                Return HashSHA.generateSHA256(Me.toString())
            End Function

        End Class

        Public Enum PropertyID

            notDefined
            typeOfDB
            dateCreation
            name

        End Enum

        Public Property currentRecord As New SingleRecordLedger
        Public Property log As LogEngine
        Public Property identifyBlockChain As String = ""
        Public Property CurrentIdBlock As Integer = 0
        Public Property CurrentIdVolume As Byte = 0

        Private Property _NewIdTransaction As Integer = 1
        Private Property _BasePath As String = ""
        Private Property _CompleteFileName As String = ""
        Private Property _CurrentTotalHash As String = ""
        Private Property _CreationLedgerDate As Double = 0

        Private Property _NextBlockCloseAtTime As DateTime

        Private Property _DBLedgerFileName As String = "Ledger.Db"
        Private Property _DBLedgerConnectionString As String = "Data source = {0};Version=3;"



        Private Function createNextCloseAtTime() As DateTime
            Dim dateCreation As Date = CHCCommonLibrary.AreaEngine.Miscellaneous.dateTimeFromTimestamp(_CreationLedgerDate)
            Dim currentYear As Short = Now.ToUniversalTime.Year
            Dim currentMonth As Byte = Now.ToUniversalTime.Month
            Dim currentDay As Byte = Now.ToUniversalTime.Day

            Dim currentHour As Byte = dateCreation.Hour
            Dim currentMinute As Byte = dateCreation.Minute
            Dim currentSecond As Byte = dateCreation.Second

            Return New Date(currentYear, currentMonth, currentDay, currentHour, currentMinute, currentSecond)
        End Function

        Private Function createDBBlockLedgerIdentity() As Boolean
            Try
                Dim sql As String = ""
                Dim connectionDB As SQLiteConnection
                Dim sqlCommand As SQLiteCommand

                log.track("LedgerEngine.createDBBlockLedgerIdentity", "Begin")

                sql += "CREATE TABLE dbIdentity "
                sql += " (property_id INTEGER PRIMARY KEY, "
                sql += "  value NVARCHAR(1024) NOT NULL "
                sql += ");"

                connectionDB = New SQLiteConnection(String.Format(_DBLedgerConnectionString, _DBLedgerFileName))

                connectionDB.Open()

                log.track("LedgerEngine.createDBBlockLedgerIdentity", "Connection Open")

                sqlCommand = New SQLiteCommand(connectionDB)

                sqlCommand.CommandText = sql

                sqlCommand.ExecuteScalar()

                log.track("LedgerEngine.createDBBlockLedgerIdentity", "Command execute")

                connectionDB.Close()

                log.track("LedgerEngine.createDBBlockLedgerIdentity", "Complete")

                Return True
            Catch ex As Exception
                log.track("LedgerEngine.createDBBlockLedgerIdentity", ex.Message, "fatal")

                Return False
            End Try
        End Function

        Private Function createDBBlockLedger() As Boolean
            Try
                Dim sql As String = ""
                Dim connectionDB As SQLiteConnection
                Dim sqlCommand As SQLiteCommand

                log.track("LedgerEngine.createDBBlockLedger", "Begin")

                sql += "CREATE TABLE blockData "
                sql += " (record_id INTEGER PRIMARY KEY, "
                sql += "  registrationDate DOUBLE NOT NULL, "
                sql += "  actionCode NVARCHAR(10) NOT NULL, "
                sql += "  requesterPublicAddress NVARCHAR(4096) NOT NULL, "
                sql += "  approverPublicAddress NVARCHAR(65536) NOT NULL, "
                sql += "  requestHash NVARCHAR(128) NOT NULL, "
                sql += "  consensusHash NVARCHAR(128) NOT NULL, "
                sql += "  detailInformation NVARCHAR(65536) NOT NULL, "
                sql += "  currentHash NVARCHAR(128) NOT NULL, "
                sql += "  progressiveHash NVARCHAR(128) NOT NULL "
                sql += ");"

                connectionDB = New SQLiteConnection(String.Format(_DBLedgerConnectionString, _DBLedgerFileName))

                connectionDB.Open()

                log.track("LedgerEngine.createDBBlockLedger", "Db Open")

                sqlCommand = New SQLiteCommand(connectionDB)

                sqlCommand.CommandText = sql

                sqlCommand.ExecuteScalar()

                log.track("LedgerEngine.createDBBlockLedger", "Command execute")

                connectionDB.Close()

                log.track("LedgerEngine.createDBBlockLedger", "Connection close")

                Return True
            Catch ex As Exception
                log.track("LedgerEngine.createDBBlockLedger", ex.Message, "fatal")

                Return False
            End Try
        End Function

        Private Function insertSQLPropertyIdentityDB(ByVal id As PropertyID, ByVal value As String) As Boolean
            Try
                Dim sql As String = ""
                Dim connectionDB As SQLiteConnection
                Dim sqlCommand As SQLiteCommand

                log.track("LedgerEngine.insertSQLPropertyIdentityDB", "Begin")

                sql += "INSERT INTO dbIdentity "
                sql += " (property_id, value) "
                sql += "VALUES "
                sql += " (" & id & ", '"
                sql += value
                sql += "')"

                connectionDB = New SQLiteConnection(String.Format(_DBLedgerConnectionString, _DBLedgerFileName))

                connectionDB.Open()

                log.track("LedgerEngine.insertSQLPropertyIdentityDB", "Connection Open")

                sqlCommand = New SQLiteCommand(connectionDB)

                sqlCommand.CommandText = sql

                sqlCommand.ExecuteScalar()

                log.track("LedgerEngine.insertSQLPropertyIdentityDB", "Command executed")

                connectionDB.Close()

                log.track("LedgerEngine.insertSQLPropertyIdentityDB", "Connection Closed")

                Return True
            Catch ex As Exception
                log.track("LedgerEngine.insertSQLPropertyIdentityDB", ex.Message, "fatal")

                Return False
            End Try
        End Function

        Private Function writeIdentityDB() As Boolean
            insertSQLPropertyIdentityDB(PropertyID.dateCreation, CHCCommonLibrary.AreaEngine.Miscellaneous.atMomentGMT())
            insertSQLPropertyIdentityDB(PropertyID.name, CHCCommonLibrary.AreaCommon.Models.General.IdentifyRecordLedger.composeCoordinate(identifyBlockChain, _CurrentIdVolume, _CurrentIdBlock))
            insertSQLPropertyIdentityDB(PropertyID.typeOfDB, "BlockLedger")

            Return True
        End Function

        Private Function initDBLedger() As Boolean
            Try
                Dim proceed As Boolean = True

                log.track("LedgerEngine.initDBLedger", "Begin")

                _DBLedgerFileName = CHCCommonLibrary.AreaCommon.Models.General.IdentifyRecordLedger.composeCoordinate(identifyBlockChain, _CurrentIdVolume, _CurrentIdBlock)
                _DBLedgerFileName = IO.Path.Combine(_BasePath, _DBLedgerFileName & ".db")

                log.track("LedgerEngine.initDBLedger", "Set db in" & _DBLedgerFileName)

                If Not IO.File.Exists(_DBLedgerFileName) Then
                    log.track("LedgerEngine.initDBLedger", "Db file not exist")

                    SQLiteConnection.CreateFile(_DBLedgerFileName)

                    log.track("LedgerEngine.initDBLedger", "Db created")

                    If proceed Then
                        proceed = createDBBlockLedgerIdentity()
                    End If
                    If proceed Then
                        proceed = writeIdentityDB()
                    End If
                    If proceed Then
                        proceed = createDBBlockLedger()
                    End If

                    Return True
                End If
            Catch ex As Exception
                log.track("LedgerEngine.initDBLedger", ex.Message, "fatal")
            Finally
                log.track("LedgerEngine.initDBLedger", "Complete")
            End Try

            Return False
        End Function

        Private Function saveDataToDB() As Boolean
            Try
                Dim sql As String = ""
                Dim connectionDB As SQLiteConnection
                Dim sqlCommand As SQLiteCommand

                log.track("LedgerEngine.saveDataToDB", "Begin")

                sql += "INSERT INTO blockData "
                sql += " (record_id, registrationDate, actionCode, requesterPublicAddress, approverPublicAddress, requestHash, consensusHash, detailInformation, currentHash, progressiveHash) "
                sql += "VALUES "
                sql += " (" & currentRecord.id & ", "
                sql += "'" & currentRecord.registrationDate & "', "
                sql += "'" & currentRecord.actionCode & "', "
                sql += "'" & currentRecord.requesterPublicAddress & "', "
                sql += "'" & currentRecord.approverPublicAddress & "', "
                sql += "'" & currentRecord.requestHash & "', "
                sql += "'" & currentRecord.consensusHash & "', "
                sql += "'" & currentRecord.detailInformation & "', "
                sql += "'" & currentRecord.currentHash & "', "
                sql += "'" & currentRecord.progressiveHash & "' "
                sql += ")"

                connectionDB = New SQLiteConnection(String.Format(_DBLedgerConnectionString, _DBLedgerFileName))

                connectionDB.Open()

                log.track("LedgerEngine.saveDataToDB", "Connection Open")

                sqlCommand = New SQLiteCommand(connectionDB)

                sqlCommand.CommandText = sql

                sqlCommand.ExecuteScalar()

                log.track("LedgerEngine.saveDataToDB", "Command executed")

                connectionDB.Close()

                log.track("LedgerEngine.saveDataToDB", "Connection Closed")

                Return True
            Catch ex As Exception
                log.track("LedgerEngine.saveDataToDB", ex.Message, "fatal")

                Return False
            End Try
        End Function

        Public ReadOnly Property newIdTransaction() As Integer
            Get
                Return _NewIdTransaction
            End Get
        End Property

        Public ReadOnly Property blockComplete() As Boolean
            Get
                Return (Now.Subtract(_NextBlockCloseAtTime).TotalSeconds > 0)
            End Get
        End Property

        Public ReadOnly Property CurrentTotalHash() As String
            Get
                Return _CurrentTotalHash
            End Get
        End Property

        Public Sub completeRecord()
            currentRecord.id = _NewIdTransaction
            currentRecord.currentHash = currentRecord.getHash
            currentRecord.progressiveHash = HashSHA.generateSHA256(currentRecord.currentHash & _CurrentTotalHash)
        End Sub

        Public Function calculateProgressiveHash(ByVal recordHash As String) As String
            If (_CurrentTotalHash.Length = 0) Then
                Return recordHash
            Else
                Return HashSHA.generateSHA256(_CurrentTotalHash & recordHash)
            End If
        End Function

        Public Function saveAndClean() As CHCCommonLibrary.AreaCommon.Models.General.IdentifyRecordLedger
            Dim result As New CHCCommonLibrary.AreaCommon.Models.General.IdentifyRecordLedger

            Try
                log.track("LedgerEngine.saveAndClean", "Begin")

                currentRecord.id = _NewIdTransaction
                currentRecord.currentHash = currentRecord.getHash()

                result.recordCoordinate = CHCCommonLibrary.AreaCommon.Models.General.IdentifyRecordLedger.composeCoordinate(identifyBlockChain, _CurrentIdVolume, _CurrentIdBlock, _NewIdTransaction)
                result.recordHash = currentRecord.currentHash

                currentRecord.progressiveHash = calculateProgressiveHash(result.recordHash)

                log.track("LedgerEngine.saveAndClean", "Assign value")

                Using fileData As IO.StreamWriter = IO.File.AppendText(_CompleteFileName)
                    fileData.WriteLine(currentRecord.toStringToFile())
                End Using

                log.track("LedgerEngine.saveAndClean", "Write file ledger")

                If saveDataToDB() Then
                    _NewIdTransaction += 1
                    _CurrentTotalHash = currentRecord.progressiveHash

                    log.track("LedgerEngine.saveAndClean", "Update counter")

                    currentRecord = New SingleRecordLedger
                End If

                Return result
            Catch ex As Exception
                log.track("LedgerEngine.saveAndClean", ex.Message, "fatal")

                Return New CHCCommonLibrary.AreaCommon.Models.General.IdentifyRecordLedger
            End Try
        End Function


        ''' <summary>
        ''' This method provide to init a db engine
        ''' </summary>
        ''' <param name="path"></param>
        ''' <param name="creationLedgerDate"></param>
        ''' <returns></returns>
        Public Function init(ByVal path As String, ByVal creationLedgerDate As Double) As Boolean
            Try
                log.track("LedgerEngine.init", "Begin")

                _BasePath = path

                _CreationLedgerDate = creationLedgerDate
                _NextBlockCloseAtTime = createNextCloseAtTime()

                log.track("LedgerEngine.init", "Local data set")

                _CompleteFileName = IO.Path.Combine(path, _CurrentIdBlock.ToString & ".ledger")

                log.track("LedgerEngine.init", "Set Complete file name = " & _CompleteFileName)

                If initDBLedger() Then
                    log.track("LedgerEngine.init", "initDBLedger complete")

                    Return True
                End If
            Catch ex As Exception
                log.track("LedgerEngine.init", ex.Message, "fatal")
            End Try

            Return False
        End Function

    End Class

End Namespace