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
        [type] = 2
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

        Public Property pathData As CHCProtocolLibrary.AreaSystem.VirtualPathEngine.LedgerBlockPath

        Public Property id As Integer = 0
        Public Property registrationTimeStamp As Double = 0
        Public Property [type] As String = ""
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

                    [type] = elements(EnumPositionField.[type])
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
            tmp += [type] & separator
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
        Private Property _DAO As New AreaCommon.DAO.DAOLedger

        Public Property approvedTransaction As New SingleTransactionLedger
        Public Property proposeNewTransaction As New SingleTransactionLedger
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
        ''' This method provide to create a db block
        ''' </summary>
        ''' <returns></returns>
        Private Function createDBBlock() As Boolean
            Try
                Dim blockName As String = ""
                Dim intermediatePath As String
                Dim proceed As Boolean = True

                log.track("LedgerEngine.createDBBlock", "Begin")

                blockName = CHCCommonLibrary.AreaCommon.Models.General.IdentifyLastTransaction.composeCoordinate(identifyBlockChain, currentIdVolume, currentIdBlock)
                proposeNewTransaction.pathData = CHCProtocolLibrary.AreaSystem.VirtualPathEngine.createBlockPath(_BasePath, blockName)

                If IsNothing(approvedTransaction.pathData) Then
                    approvedTransaction.pathData = proposeNewTransaction.pathData
                End If

                intermediatePath = proposeNewTransaction.pathData.path
                _CompleteFileName = IO.Path.Combine(intermediatePath, "current.BlockData")

                log.track("LedgerEngine.createDBBlock", "Set Complete file name = " & _CompleteFileName)

                If proceed Then
                    proceed = _DAO.addNewBlockPath(blockName)
                End If
                If proceed Then
                    proceed = _DAO.createDBLedgerBlockData(intermediatePath, blockName)
                End If
                If proceed Then
                    log.track("LedgerEngine.createDBBlock", "initDBLedger complete")

                    Return True
                End If
            Catch ex As Exception
                log.track("LedgerEngine.createDBBlock", ex.Message, "fatal")
            End Try

            Return False
        End Function


        ''' <summary>
        ''' This method provide to compose a string with a coordinate last approved transaction
        ''' </summary>
        ''' <param name="nextTransaction"></param>
        ''' <param name="noTransaction"></param>
        ''' <returns></returns>
        Public Function composeCoordinateTransaction(Optional ByVal nextTransaction As Boolean = False, Optional ByVal noTransaction As Boolean = False) As String
            Try
                Dim idTransaction As Integer
                Dim idBlock As Integer
                Dim idVolume As Byte

                log.track("LedgerEngine.composeCoordinateTransaction", "Begin")

                If nextTransaction Then
                    idTransaction = proposeNewTransaction.id
                    idBlock = nextIdBlock
                    idVolume = nextIdVolume
                Else
                    idTransaction = approvedTransaction.id
                    idBlock = currentIdBlock
                    idVolume = currentIdVolume
                End If

                If (approvedTransaction.type.Length = 0) And Not nextTransaction Then
                    Return "----"
                Else
                    If noTransaction Then
                        Return CHCCommonLibrary.AreaCommon.Models.General.EssentialDataTransaction.composeCoordinate(identifyBlockChain, idVolume, idBlock)
                    Else
                        Return CHCCommonLibrary.AreaCommon.Models.General.EssentialDataTransaction.composeCoordinate(identifyBlockChain, idVolume, idBlock, idTransaction)
                    End If
                End If
            Catch ex As Exception
                log.track("LedgerEngine.composeCoordinateTransaction", ex.Message, "fatal")

                Return "---"
            Finally
                log.track("LedgerEngine.composeCoordinateTransaction", "Complete")
            End Try
        End Function

        ''' <summary>
        ''' This property get a current total hash
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property CurrentTotalHash() As String
            Get
                Return _CurrentTotalHash
            End Get
        End Property

        ''' <summary>
        ''' This method provide to complete a record
        ''' </summary>
        Public Sub completeRecord()
            proposeNewTransaction.id = _NewIdTransaction
            proposeNewTransaction.currentHash = proposeNewTransaction.getHash
            proposeNewTransaction.progressiveHash = HashSHA.generateSHA256(proposeNewTransaction.currentHash & _CurrentTotalHash)
        End Sub

        ''' <summary>
        ''' This method provide to calculate progressive hash
        ''' </summary>
        ''' <param name="recordHash"></param>
        ''' <returns></returns>
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

                proposeNewTransaction.id = _NewIdTransaction
                proposeNewTransaction.currentHash = proposeNewTransaction.getHash()

                result.coordinate = CHCCommonLibrary.AreaCommon.Models.General.EssentialDataTransaction.composeCoordinate(identifyBlockChain, _currentIdVolume, _currentIdBlock, _NewIdTransaction)
                result.hash = proposeNewTransaction.currentHash
                proposeNewTransaction.progressiveHash = calculateProgressiveHash(result.hash)
                result.progressiveHash = proposeNewTransaction.progressiveHash
                result.registrationTimeStamp = proposeNewTransaction.registrationTimeStamp

                log.track("LedgerEngine.saveAndClean", "Assign value")

                _CompleteFileName = IO.Path.Combine(proposeNewTransaction.pathData.path, CHCCommonLibrary.AreaCommon.Models.General.IdentifyLastTransaction.composeCoordinate(identifyBlockChain, currentIdVolume, currentIdBlock) & ".ledger")

                Using fileData As IO.StreamWriter = IO.File.AppendText(_CompleteFileName)
                    fileData.WriteLine(proposeNewTransaction.toStringFormatToFile())
                End Using

                log.track("LedgerEngine.saveAndClean", "Write file ledger")

                If _DAO.saveData(proposeNewTransaction) Then
                    _NewIdTransaction += 1
                    _CurrentTotalHash = proposeNewTransaction.progressiveHash

                    log.track("LedgerEngine.saveAndClean", "Update counter")

                    approvedTransaction = proposeNewTransaction
                    proposeNewTransaction = New SingleTransactionLedger

                    proposeNewTransaction.pathData = approvedTransaction.pathData
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

                _DAO.log = log

                log.track("LedgerEngine.init", "Local data set")

                If _DAO.createDBLedgerMap(_BasePath) Then
                    Return createDBBlock()
                End If
            Catch ex As Exception
                log.track("LedgerEngine.init", ex.Message, "fatal")
            End Try

            Return False
        End Function

    End Class

    ''' <summary>
    ''' This class contain all element to map a block of a ledger
    ''' </summary>
    Public Class LedgerMapEngine

        Private _DAO As New AreaCommon.DAO.DAOLedger


        Public Property log As LogEngine


        ''' <summary>
        ''' This method provide to get a request path
        ''' </summary>
        ''' <param name="blockPath"></param>
        ''' <returns></returns>
        Public Function getRequestPath(ByVal blockPath As String) As String
            Try
                Dim requestPath As String
                log.track("LedgerMapEngine.getRequestPath", "Begin")

                requestPath = _DAO.getRequestPath(blockPath)

                If (requestPath.Length > 0) Then
                    Return IO.Path.Combine(requestPath, blockPath, "Request")
                Else
                    Return ""
                End If
            Catch ex As Exception
                log.track("LedgerMapEngine.getRequestPath", ex.Message, "fatal")

                Return ""
            Finally
                log.track("LedgerMapEngine.getRequestPath", "Complete")
            End Try
        End Function

    End Class

End Namespace