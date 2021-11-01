Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.Encryption
Imports System.Data.SQLite
Imports CHCCommonLibrary.Support





Namespace AreaLedger

    ''' <summary>
    ''' This enum contain the index of a field into string array of a single transaction data
    ''' </summary>
    Public Enum EnumPositionField
        id = 0
        registrationTimeStamp = 1
        actionCode = 2
        requesterPublicAddress = 3
        approverPublicAddress = 4
        requestHash = 5
        consensusHash = 6
        detailInformation = 7
        currentHash = 8
        progressiveHash = 9
    End Enum

    ''' <summary>
    ''' This class contain all element relative an a single transaction
    ''' </summary>
    Public Class SingleTransactionLedger

        Public Property id As Integer = 0
        Public Property registrationTimeStamp As Double = 0
        Public Property actionCode As String = ""
        Public Property requesterPublicAddress As String = ""
        Public Property approverPublicAddress As String = ""
        Public Property requestHash As String = ""
        Public Property consensusHash As String = ""
        Public Property detailInformation As String = ""
        Public Property currentHash As String = ""
        Public Property progressiveHash As String = ""

        ''' <summary>
        ''' This method provide to fill empty text with --- string
        ''' </summary>
        ''' <param name="value"></param>
        ''' <returns></returns>
        Private Function fillEmptyText(ByVal value As String) As String
            If (value.Trim.Length > 0) Then
                Return value
            Else
                Return "---"
            End If
        End Function

        ''' <summary>
        ''' This method provide to extract and load data from a string 
        ''' </summary>
        ''' <param name="value"></param>
        ''' <returns></returns>
        Public Function loadFromAString(ByVal value As String) As Boolean
            Try
                Dim elements = value.Split("|")

                If (UBound(elements) = EnumPositionField.progressiveHash) Then

                    If IsNumeric(elements(EnumPositionField.id)) Then
                        If Not Integer.TryParse(elements(EnumPositionField.id), id) Then
                            Return False
                        End If
                    Else
                        Return False
                    End If

                    If IsNumeric(elements(EnumPositionField.registrationTimeStamp)) Then
                        If Not Double.TryParse(elements(1), registrationTimeStamp) Then
                            Return False
                        End If
                    Else
                        Return False
                    End If

                    actionCode = elements(EnumPositionField.actionCode)
                    requesterPublicAddress = elements(EnumPositionField.requesterPublicAddress)
                    approverPublicAddress = elements(EnumPositionField.approverPublicAddress)
                    requestHash = elements(EnumPositionField.requestHash)
                    consensusHash = elements(EnumPositionField.consensusHash)
                    detailInformation = elements(EnumPositionField.detailInformation)
                    currentHash = elements(EnumPositionField.currentHash)
                    progressiveHash = elements(EnumPositionField.progressiveHash)

                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to return a string from a data to class
        ''' </summary>
        ''' <param name="separator"></param>
        ''' <param name="limited"></param>
        ''' <returns></returns>
        Public Function toStringFormatToFile(Optional ByVal separator As String = "|", Optional limited As Boolean = False) As String
            Dim tmp As String = ""

            tmp += id.ToString() & separator
            tmp += registrationTimeStamp.ToString() & separator
            tmp += actionCode & separator
            tmp += requesterPublicAddress & separator
            tmp += approverPublicAddress & separator
            tmp += requestHash & separator
            tmp += detailInformation & separator
            tmp += fillEmptyText(consensusHash) & separator

            If Not limited Then
                tmp += currentHash & separator
                tmp += progressiveHash
            End If

            Return tmp
        End Function

        ''' <summary>
        ''' This method provide to return a limited string file from a data in memory
        ''' </summary>
        ''' <returns></returns>
        Public Overrides Function toString() As String
            Return toStringFormatToFile("", True)
        End Function

        ''' <summary>
        ''' This method provide to create an hash from a limited element 
        ''' </summary>
        ''' <returns></returns>
        Public Function getHash() As String
            Return HashSHA.generateSHA256(Me.toString())
        End Function

    End Class

    ''' <summary>
    ''' This class contain all member relative a Ledger
    ''' </summary>
    Public Class LedgerEngine

        ''' <summary>
        ''' This enumeration contain the property ID
        ''' </summary>
        Public Enum EnumPropertyID

            notDefined
            typeOfDB
            dateCreation
            name

        End Enum

        Private Property _NewIdTransaction As Integer = 0
        Private Property _BasePath As String = ""
        Private Property _CompleteFileName As String = ""
        Private Property _CurrentTotalHash As String = ""
        Private Property _CreationLedgerDate As Double = 0
        Private Property _NextBlockCloseAtTime As DateTime
        Private Property _DBLedgerFileName As String = "Ledger.Db"
        Private Property _DBLedgerConnectionString As String = "Data source = {0};Version=3;"

        Public Property currentApprovedTransaction As New SingleTransactionLedger
        Public Property nextProposeNewTransaction As New SingleTransactionLedger
        Public Property identifyBlockChain As String = ""
        Public Property currentIdBlock As Integer = 0
        Public Property currentIdVolume As Byte = 0
        Public Property nextIdBlock As Integer = 0
        Public Property nextIdVolume As Byte = 0
        Public Property requestChangeBlock As Boolean = False
        Public Property log As LogEngine


        ''' <summary>
        ''' This methdo provide to create a next close time of a block 
        ''' </summary>
        ''' <returns></returns>
        Private Function createNextCloseAtTime() As DateTime
            Try
                log.track("LedgerEngine.createNextCloseAtTime", "Begin")

                Dim dateCreation As Date = CHCCommonLibrary.AreaEngine.Miscellaneous.dateTimeFromTimeStamp(_CreationLedgerDate)
                Dim currentYear As Short = Now.ToUniversalTime.Year
                Dim currentMonth As Byte = Now.ToUniversalTime.Month
                Dim currentDay As Byte = Now.ToUniversalTime.Day

                Dim currentHour As Byte = dateCreation.Hour
                Dim currentMinute As Byte = dateCreation.Minute
                Dim currentSecond As Byte = dateCreation.Second

                Return New Date(currentYear, currentMonth, currentDay, currentHour, currentMinute, currentSecond)
            Catch ex As Exception
                log.track("LedgerEngine.createNextCloseAtTime", ex.Message, "fatal")

                Return New Date()
            Finally
                log.track("LedgerEngine.createNextCloseAtTime", "Complete")
            End Try
        End Function

        ''' <summary>
        ''' This method provide to create a db lock ledger identity
        ''' </summary>
        ''' <returns></returns>
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

        ''' <summary>
        ''' This method provide to create a DB Block Ledger
        ''' </summary>
        ''' <returns></returns>
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
                sql += "  detailInformation NVARCHAR(65536) NOT NULL, "
                sql += "  consensusHash NVARCHAR(128) NOT NULL, "
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
            Finally
                log.track("LedgerEngine.createDBBlockLedger", "Complete")
            End Try
        End Function

        ''' <summary>
        ''' This method provide to insert a sql property into Indentity table
        ''' </summary>
        ''' <param name="id"></param>
        ''' <param name="value"></param>
        ''' <returns></returns>
        Private Function insertSQLPropertyIdentityDB(ByVal id As EnumPropertyID, ByVal value As String) As Boolean
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
            Finally
                log.track("LedgerEngine.insertSQLPropertyIdentityDB", "Complete")
            End Try
        End Function

        ''' <summary>
        ''' This method provide to write an Identity on a DB
        ''' </summary>
        ''' <returns></returns>
        Private Function writeIdentityDB() As Boolean
            Try
                log.track("LedgerEngine.writeIdentityDB", "Begin")

                insertSQLPropertyIdentityDB(EnumPropertyID.dateCreation, CHCCommonLibrary.AreaEngine.Miscellaneous.atMomentGMT())
                insertSQLPropertyIdentityDB(EnumPropertyID.name, CHCCommonLibrary.AreaCommon.Models.General.IdentifyLastTransaction.composeCoordinate(identifyBlockChain, _currentIdVolume, _currentIdBlock))
                insertSQLPropertyIdentityDB(EnumPropertyID.typeOfDB, "BlockLedger")

                log.track("LedgerEngine.writeIdentityDB", "Complete")

                Return True
            Catch ex As Exception
                log.track("LedgerEngine.writeIdentityDB", ex.Message, "fatal")

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to initialize a db ledger
        ''' </summary>
        ''' <returns></returns>
        Private Function initDBLedger() As Boolean
            Try
                Dim proceed As Boolean = True

                log.track("LedgerEngine.initDBLedger", "Begin")

                _DBLedgerFileName = CHCCommonLibrary.AreaCommon.Models.General.IdentifyLastTransaction.composeCoordinate(identifyBlockChain, _CurrentIdVolume, _CurrentIdBlock)
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

                    Return proceed
                End If
            Catch ex As Exception
                log.track("LedgerEngine.initDBLedger", ex.Message, "fatal")
            Finally
                log.track("LedgerEngine.initDBLedger", "Complete")
            End Try

            Return False
        End Function

        ''' <summary>
        ''' This method provide to save into DB a single transaction
        ''' </summary>
        ''' <returns></returns>
        Private Function saveDataToDB() As Boolean
            Try
                Dim sql As String = ""
                Dim connectionDB As SQLiteConnection
                Dim sqlCommand As SQLiteCommand

                log.track("LedgerEngine.saveDataToDB", "Begin")

                sql += "INSERT INTO blockData "
                sql += " (record_id, registrationDate, actionCode, requesterPublicAddress, approverPublicAddress, requestHash, consensusHash, detailInformation, currentHash, progressiveHash) "
                sql += "VALUES "
                sql += " (" & nextProposeNewTransaction.id & ", "
                sql += "'" & nextProposeNewTransaction.registrationTimeStamp & "', "
                sql += "'" & nextProposeNewTransaction.actionCode & "', "
                sql += "'" & nextProposeNewTransaction.requesterPublicAddress & "', "
                sql += "'" & nextProposeNewTransaction.approverPublicAddress & "', "
                sql += "'" & nextProposeNewTransaction.requestHash & "', "
                sql += "'" & nextProposeNewTransaction.consensusHash & "', "
                sql += "'" & nextProposeNewTransaction.detailInformation & "', "
                sql += "'" & nextProposeNewTransaction.currentHash & "', "
                sql += "'" & nextProposeNewTransaction.progressiveHash & "' "
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
            Finally
                log.track("LedgerEngine.saveDataToDB", "Complete")
            End Try
        End Function


        ''' <summary>
        ''' This method provide to compose a string with a coordinate last approved transaction
        ''' </summary>
        ''' <returns></returns>
        Public Function composeCoordinateTransaction(Optional ByVal nextTransaction As Boolean = False) As String
            Try
                Dim idTransaction As Integer
                Dim idBlock As Integer
                Dim idVolume As Byte

                log.track("LedgerEngine.composeCoordinateTransaction", "Begin")

                If nextTransaction Then
                    idTransaction = nextProposeNewTransaction.id
                    idBlock = nextIdBlock
                    idVolume = nextIdVolume
                Else
                    idTransaction = currentApprovedTransaction.id
                    idBlock = currentIdBlock
                    idVolume = currentIdVolume
                End If

                If (currentApprovedTransaction.actionCode.Length = 0) And Not nextTransaction Then
                    Return "----"
                Else
                    Return CHCCommonLibrary.AreaCommon.Models.General.EssentialDataTransaction.composeCoordinate(identifyBlockChain, idVolume, idBlock, idTransaction)
                End If
            Catch ex As Exception
                log.track("LedgerEngine.composeCoordinateTransaction", ex.Message, "fatal")

                Return "---"
            Finally
                log.track("LedgerEngine.composeCoordinateTransaction", "Complete")
            End Try
        End Function

        '''' <summary>
        '''' This method provide to assign a new id
        '''' </summary>
        '''' <returns></returns>
        'Public Function assignNewID() As Boolean
        '    Try
        '        log.track("LedgerEngine.assignNewID", "Begin")

        '        nextIdBlock = currentIdBlock
        '        nextIdVolume = currentIdVolume

        '        If requestChangeBlock Then
        '            Dim numberDaysOnYear As Integer = 365

        '            If DateTime.IsLeapYear(Now.Year) Then
        '                numberDaysOnYear = 366
        '            End If
        '            If (currentIdBlock = numberDaysOnYear) Then
        '                nextIdVolume = currentIdVolume + 1
        '                nextIdBlock = 0
        '            Else
        '                nextIdBlock += 1
        '            End If
        '            nextProposeNewTransaction.id = 0
        '        Else
        '            nextProposeNewTransaction.id = currentApprovedTransaction.id + 1
        '        End If

        '        log.track("LedgerEngine.assignNewID", "Complete")

        '        Return True
        '    Catch ex As Exception
        '        log.track("LedgerEngine.assignNewID", ex.Message, "fatal")

        '        Return False
        '    End Try
        'End Function

        'Public ReadOnly Property newIdTransaction() As Integer
        '    Get
        '        Return _NewIdTransaction
        '    End Get
        'End Property

        'Public ReadOnly Property blockComplete() As Boolean
        '    Get
        '        Return (Now.Subtract(_NextBlockCloseAtTime).TotalSeconds > 0)
        '    End Get
        'End Property

        Public ReadOnly Property CurrentTotalHash() As String
            Get
                Return _CurrentTotalHash
            End Get
        End Property

        Public Sub completeRecord()
            nextProposeNewTransaction.id = _NewIdTransaction
            nextProposeNewTransaction.currentHash = nextProposeNewTransaction.getHash
            nextProposeNewTransaction.progressiveHash = HashSHA.generateSHA256(nextProposeNewTransaction.currentHash & _CurrentTotalHash)
        End Sub

        Public Function calculateProgressiveHash(ByVal recordHash As String) As String
            If (_CurrentTotalHash.Length = 0) Then
                Return recordHash
            Else
                Return HashSHA.generateSHA256(_CurrentTotalHash & recordHash)
            End If
        End Function

        ''' <summary>
        ''' This method provide to save into db the transaction and update a block file with transaction and prepare the engine to create another one
        ''' </summary>
        ''' <returns></returns>
        Public Function saveAndClean() As CHCCommonLibrary.AreaCommon.Models.General.IdentifyLastTransaction
            Dim result As New CHCCommonLibrary.AreaCommon.Models.General.IdentifyLastTransaction

            Try
                log.track("LedgerEngine.saveAndClean", "Begin")

                nextProposeNewTransaction.id = _NewIdTransaction
                nextProposeNewTransaction.currentHash = nextProposeNewTransaction.getHash()

                result.coordinate = CHCCommonLibrary.AreaCommon.Models.General.EssentialDataTransaction.composeCoordinate(identifyBlockChain, _CurrentIdVolume, _CurrentIdBlock, _NewIdTransaction)
                result.hash = nextProposeNewTransaction.currentHash

                nextProposeNewTransaction.progressiveHash = calculateProgressiveHash(result.hash)

                log.track("LedgerEngine.saveAndClean", "Assign value")

                _CompleteFileName = IO.Path.Combine(_BasePath, _currentIdBlock.ToString & ".ledger")

                Using fileData As IO.StreamWriter = IO.File.AppendText(_CompleteFileName)
                    fileData.WriteLine(nextProposeNewTransaction.toStringFormatToFile())
                End Using

                log.track("LedgerEngine.saveAndClean", "Write file ledger")

                If saveDataToDB() Then
                    _NewIdTransaction += 1
                    _CurrentTotalHash = nextProposeNewTransaction.progressiveHash

                    log.track("LedgerEngine.saveAndClean", "Update counter")

                    currentApprovedTransaction = nextProposeNewTransaction
                    nextProposeNewTransaction = New SingleTransactionLedger
                End If

                Return result
            Catch ex As Exception
                log.track("LedgerEngine.saveAndClean", ex.Message, "fatal")

                Return New CHCCommonLibrary.AreaCommon.Models.General.IdentifyLastTransaction
            Finally
                log.track("LedgerEngine.saveAndClean", "Complete")
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