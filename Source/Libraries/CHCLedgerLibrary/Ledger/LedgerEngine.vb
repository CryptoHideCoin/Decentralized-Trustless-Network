Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.Encryption
Imports CHCCommonLibrary.Support
Imports CHCProtocolLibrary.AreaCommon.Models.Ledger






Namespace AreaLedger

    ''' <summary>
    ''' This class contain all member relative a Ledger
    ''' </summary>
    Public Class LedgerEngine

        ''' <summary>
        ''' This enumeration contain the property ID
        ''' </summary>
        Public Enum EnumPropertyID

            undefined
            typeOfDB
            dateCreation
            name

        End Enum

        ''' <summary>
        ''' This class contain the last block essential information
        ''' </summary>
        Public Class LastCloseBlock

            Public Property blockIdentity As String = ""
            Public Property hash As String = ""

        End Class

        ''' <summary>
        ''' This class contain che content configuration of a transaction
        ''' </summary>
        Public Class ContentTransactionConfiguration

            Public Property content As String = ""
            Public Property fileNotFound As Boolean = False
            Public Property inError As Boolean = False

        End Class

        ''' <summary>
        ''' This class contain the transaction coordinate
        ''' </summary>
        Public Class TransactionCoordinate

            Public Property blockPath As String = ""
            Public Property ID As Integer = 0

        End Class

        Private Property _NewIdTransaction As Integer = 0
        Private Property _BasePath As String = ""
        Private Property _CompleteFileName As String = ""
        Private Property _CurrentTotalHash As String = ""
        Private Property _DAO As New AreaDataAccess.Ledger.DAOLedger

        Public Property approvedTransaction As New SingleTransactionLedger
        Public Property proposeNewTransaction As New SingleTransactionLedger
        Public Property currentIdBlock As Integer = 0
        Public Property currentIdVolume As Byte = 0
        Public Property nextIdBlock As Integer = 0
        Public Property nextIdVolume As Byte = 0
        Public Property lastBlockClosed As New LastCloseBlock

        Public Property log As LogEngine

        Public Property header As New HeaderLedgerInformationModel

        Public Property current


        ''' <summary>
        ''' This method provide to extract the base path of a Block
        ''' </summary>
        ''' <param name="transactionID"></param>
        ''' <returns></returns>
        Private Function extractBlockPathFromCompletePath(ByVal transactionID As String) As String
            Dim result As String = ""

            Try
                If (transactionID.Length > 0) Then
                    Dim elements = transactionID.Split("-")

                    If (elements.Count = 4) Then
                        result = elements(0) & "-" & elements(1) & "-" & elements(2)
                    ElseIf (elements.Count = 3) Then
                        result = transactionID
                    End If
                End If
            Catch ex As Exception
            End Try

            Return result
        End Function

        ''' <summary>
        ''' This method provide to separate path transaction
        ''' </summary>
        ''' <param name="transactionID"></param>
        ''' <returns></returns>
        Private Function separatePathTransaction(ByVal transactionID As String) As TransactionCoordinate
            Dim result As New TransactionCoordinate

            Try
                If (transactionID.Length > 0) Then
                    Dim elements = transactionID.Split("-")

                    If (elements.Count = 4) Then
                        result.blockPath = elements(0) & "-" & elements(1) & "-" & elements(2)
                        result.ID = elements(3)
                    ElseIf (elements.Count = 3) Then
                        result.blockPath = transactionID
                        result.ID = 0
                    End If
                End If
            Catch ex As Exception
            End Try

            Return result
        End Function


        ''' <summary>
        ''' This method provide to save an header the ledger
        ''' </summary>
        ''' <returns></returns>
        Public Function saveHeader() As Boolean
            Dim proceed As Boolean = True

            If proceed Then
                proceed = _DAO.writePropertyOnDB(AreaDataAccess.Generic.DBGeneric.DBPropertyID.identifyLedger, header.identifyLedger)
            End If
            If proceed Then
                proceed = _DAO.writePropertyOnDB(AreaDataAccess.Generic.DBGeneric.DBPropertyID.lastUpdateTimeStamp, header.lastUpdateTimeStamp)
            End If
            If proceed Then
                proceed = _DAO.writePropertyOnDB(AreaDataAccess.Generic.DBGeneric.DBPropertyID.latestTransaction, header.latestTransaction)
            End If
            If proceed Then
                proceed = _DAO.writePropertyOnDB(AreaDataAccess.Generic.DBGeneric.DBPropertyID.numBlocks, header.numBlocks)
            End If
            If proceed Then
                proceed = _DAO.writePropertyOnDB(AreaDataAccess.Generic.DBGeneric.DBPropertyID.numTransaction, header.numTransaction)
            End If
            If proceed Then
                proceed = _DAO.writePropertyOnDB(AreaDataAccess.Generic.DBGeneric.DBPropertyID.numVolumes, header.numVolumes)
            End If

            Return proceed
        End Function

        ''' <summary>
        ''' This method provide to load an header the ledger
        ''' </summary>
        ''' <returns></returns>
        Public Function loadHeader() As Boolean
            With header
                .createLedgerTimeStamp = _DAO.getPropertyOnDB(AreaDataAccess.Generic.DBGeneric.DBPropertyID.dateCreation)
                .identifyLedger = _DAO.getPropertyOnDB(AreaDataAccess.Generic.DBGeneric.DBPropertyID.identifyLedger)
                .lastUpdateTimeStamp = _DAO.getPropertyOnDB(AreaDataAccess.Generic.DBGeneric.DBPropertyID.lastUpdateTimeStamp)
                .latestTransaction = _DAO.getPropertyOnDB(AreaDataAccess.Generic.DBGeneric.DBPropertyID.latestTransaction)
                .numBlocks = _DAO.getPropertyOnDB(AreaDataAccess.Generic.DBGeneric.DBPropertyID.numBlocks)
                .numTransaction = _DAO.getPropertyOnDB(AreaDataAccess.Generic.DBGeneric.DBPropertyID.numTransaction)
                .numVolumes = _DAO.getPropertyOnDB(AreaDataAccess.Generic.DBGeneric.DBPropertyID.numVolumes)
            End With

            Return True
        End Function

        ''' <summary>
        ''' This method provide to get a request path
        ''' </summary>
        ''' <param name="blockPath"></param>
        ''' <returns></returns>
        Public Function getRequestPath(ByVal blockPath As String) As String
            Try
                Dim requestPath As String

                log.track("LedgerEngine.getRequestPath", "Begin")

                requestPath = _DAO.getBaseLedgerPath(blockPath)

                If (requestPath.Length > 0) Then
                    Return IO.Path.Combine(requestPath, blockPath, "Request")
                Else
                    Return ""
                End If
            Catch ex As Exception
                log.track("LedgerEngine.getRequestPath", ex.Message, "fatal")

                Return ""
            Finally
                log.track("LedgerEngine.getRequestPath", "Complete")
            End Try
        End Function

        ''' <summary>
        ''' This method provide to get a block number into volume
        ''' </summary>
        ''' <param name="volumeNumber"></param>
        ''' <returns></returns>
        Public Function getBlockNumberIntoVolume(ByVal volumeNumber As Integer) As Integer
            Try
                log.track("LedgerEngine.getBlockNumberIntoVolume", "Begin")

                Return _DAO.getBlockNumberIntoVolume(header.identifyLedger, volumeNumber)
            Catch ex As Exception
                log.track("LedgerEngine.getBlockNumberIntoVolume", ex.Message, "fatal")

                Return 0
            Finally
                log.track("LedgerEngine.getBlockNumberIntoVolume", "Complete")
            End Try
        End Function

        ''' <summary>
        ''' This method provide to retrieve a number of transaction 
        ''' </summary>
        ''' <param name="blockNumber"></param>
        ''' <returns></returns>
        Public Function getTransactionNumberIntoBlock(ByVal blockNumber As String) As Integer
            Try
                log.track("LedgerEngine.getBlockNumberIntoVolume", "Begin")

                Return _DAO.getTransactionsNumberIntoBlock(blockNumber)
            Catch ex As Exception
                log.track("LedgerEngine.getBlockNumberIntoVolume", ex.Message, "fatal")

                Return 0
            Finally
                log.track("LedgerEngine.getBlockNumberIntoVolume", "Complete")
            End Try
        End Function

        ''' <summary>
        ''' This method provide to get a transaction page into a block
        ''' </summary>
        ''' <param name="blockNumber"></param>
        ''' <param name="pageNumber"></param>
        ''' <returns></returns>
        Public Function getTransactionsPage(ByVal blockNumber As String, ByVal pageNumber As Integer) As List(Of SingleTransactionLedger)
            Dim result As New List(Of SingleTransactionLedger)
            Try
                log.track("LedgerEngine.getBlockNumberIntoVolume", "Begin")

                result = _DAO.getPageTransactionsIntoBlock(blockNumber, pageNumber)

                log.track("LedgerEngine.getBlockNumberIntoVolume", "Complete")
            Catch ex As Exception
                log.track("LedgerEngine.getBlockNumberIntoVolume", ex.Message, "fatal")
            End Try

            Return result
        End Function

        ''' <summary>
        ''' This method provide to get a transaction information
        ''' </summary>
        ''' <param name="transactionID"></param>
        ''' <returns></returns>
        Public Function getTransactionInformation(ByVal transactionID As String) As SingleTransactionLedger
            Try
                log.track("LedgerEngine.getBlockNumberIntoVolume", "Begin")

                Return _DAO.getTransactionIntoBlock(extractBlockPathFromCompletePath(transactionID), transactionID).value
            Catch ex As Exception
                log.track("LedgerEngine.getBlockNumberIntoVolume", ex.Message, "fatal")

                Return New SingleTransactionLedger
            Finally
                log.track("LedgerEngine.getBlockNumberIntoVolume", "Complete")
            End Try
        End Function

        ''' <summary>
        ''' This method provide to get a transaction content
        ''' </summary>
        ''' <param name="transactionID"></param>
        ''' <returns></returns>
        Public Function getTransactionContent(ByVal transactionID As String) As ContentTransactionConfiguration
            Dim result As New ContentTransactionConfiguration
            Try
                Dim item As SingleTransactionLedger
                Dim transactionData As TransactionCoordinate
                Dim contentsPath As String
                Dim proceed As Boolean = True

                log.track("LedgerEngine.getTransactionContent", "Begin")

                If proceed Then
                    transactionData = separatePathTransaction(transactionID)

                    proceed = (transactionData.blockPath.Length > 0)
                End If
                If proceed Then
                    With _DAO.getTransactionIntoBlock(transactionData.blockPath, transactionData.ID)
                        item = .value
                        contentsPath = .blockPath
                    End With

                    proceed = (item.progressiveHash.Length > 0)
                End If
                If proceed Then
                    proceed = (item.detailInformation.Length = 64)
                End If
                If proceed Then
                    If (contentsPath.Length > 0) Then
                        contentsPath = IO.Path.Combine(contentsPath, "Contents")
                    End If

                    proceed = (contentsPath.Length > 0)
                End If
                If proceed Then
                    contentsPath = IO.Path.Combine(contentsPath, item.detailInformation & ".Content")
                End If
                If proceed Then
                    If Not IO.File.Exists(contentsPath) Then
                        proceed = False

                        result.fileNotFound = True
                    End If
                End If
                If proceed Then
                    result.content = My.Computer.FileSystem.ReadAllText(contentsPath)
                End If

                log.track("LedgerEngine.getTransactionContent", "Complete")
            Catch ex As Exception
                log.track("LedgerEngine.getTransactionContent", ex.Message, "fatal")

                result.inError = True
            End Try

            Return result
        End Function

        ''' <summary>
        ''' This method provide to get a transaction content
        ''' </summary>
        ''' <param name="transactionID"></param>
        ''' <returns></returns>
        Public Function getTransactionContent(ByVal blockID As String, ByVal contentHash As String) As ContentTransactionConfiguration
            Dim result As New ContentTransactionConfiguration
            Try
                Dim contentsPath As String
                Dim proceed As Boolean = True

                log.track("LedgerEngine.getTransactionContent", "Begin")

                If proceed Then
                    contentsPath = IO.Path.Combine(_DAO.getBaseLedgerPath(blockID), blockID.ToString(), "Contents")
                End If
                If proceed Then
                    contentsPath = IO.Path.Combine(contentsPath, contentHash & ".Content")
                End If
                If proceed Then
                    If Not IO.File.Exists(contentsPath) Then
                        proceed = False

                        result.fileNotFound = True
                    End If
                End If
                If proceed Then
                    result.content = My.Computer.FileSystem.ReadAllText(contentsPath)
                End If

                log.track("LedgerEngine.getTransactionContent", "Complete")
            Catch ex As Exception
                log.track("LedgerEngine.getTransactionContent", ex.Message, "fatal")

                result.inError = True
            End Try

            Return result
        End Function

        ''' <summary>
        ''' This method provide to get transaction Order
        ''' </summary>
        ''' <param name="blockID"></param>
        ''' <param name="orderHash"></param>
        ''' <returns></returns>
        Public Function getTransactionOrder(ByVal blockID As String, ByVal orderHash As String) As ContentTransactionConfiguration
            Dim result As New ContentTransactionConfiguration
            Try
                Dim contentsPath As String
                Dim proceed As Boolean = True

                log.track("LedgerEngine.getTransactionContent", "Begin")

                If proceed Then
                    contentsPath = IO.Path.Combine(_DAO.getBaseLedgerPath(blockID), blockID.ToString(), "Requests")
                End If
                If proceed Then
                    contentsPath = IO.Path.Combine(contentsPath, orderHash & ".Request")
                End If
                If proceed Then
                    If Not IO.File.Exists(contentsPath) Then
                        proceed = False

                        result.fileNotFound = True
                    End If
                End If
                If proceed Then
                    result.content = My.Computer.FileSystem.ReadAllText(contentsPath)
                End If

                log.track("LedgerEngine.getTransactionContent", "Complete")
            Catch ex As Exception
                log.track("LedgerEngine.getTransactionContent", ex.Message, "fatal")

                result.inError = True
            End Try

            Return result
        End Function

        ''' <summary>
        ''' This method provide to get transaction Consensus
        ''' </summary>
        ''' <param name="blockID"></param>
        ''' <param name="orderHash"></param>
        ''' <returns></returns>
        Public Function getTransactionConsensus(ByVal blockID As String, ByVal orderHash As String) As ContentTransactionConfiguration
            Dim result As New ContentTransactionConfiguration
            Try
                Dim contentsPath As String
                Dim proceed As Boolean = True

                log.track("LedgerEngine.getTransactionContent", "Begin")

                If proceed Then
                    contentsPath = IO.Path.Combine(_DAO.getBaseLedgerPath(blockID), blockID.ToString(), "Consensus")
                End If
                If proceed Then
                    contentsPath = IO.Path.Combine(contentsPath, orderHash & ".Consent")
                End If
                If proceed Then
                    If Not IO.File.Exists(contentsPath) Then
                        proceed = False

                        result.fileNotFound = True
                    End If
                End If
                If proceed Then
                    result.content = My.Computer.FileSystem.ReadAllText(contentsPath)
                End If

                log.track("LedgerEngine.getTransactionContent", "Complete")
            Catch ex As Exception
                log.track("LedgerEngine.getTransactionContent", ex.Message, "fatal")

                result.inError = True
            End Try

            Return result
        End Function

        ''' <summary>
        ''' This method provide to update block path
        ''' </summary>
        ''' <param name="blockName"></param>
        ''' <param name="hash"></param>
        ''' <returns></returns>
        Public Function updateBlockPath(ByVal blockName As String, ByVal hash As String) As Boolean
            _DAO.log = log

            Return _DAO.updateBlockPath(blockName, hash)
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

                blockName = CHCCommonLibrary.AreaCommon.Models.General.EssentialDataTransaction.composeCoordinate(header.identifyLedger, currentIdVolume, currentIdBlock)
                proposeNewTransaction.pathData = CHCProtocolLibrary.AreaSystem.VirtualPathEngine.createBlockPath(_BasePath, blockName)
                proposeNewTransaction.id = _NewIdTransaction

                If IsNothing(approvedTransaction.pathData) Then
                    approvedTransaction.pathData = proposeNewTransaction.pathData
                End If

                intermediatePath = proposeNewTransaction.pathData.path
                _CompleteFileName = IO.Path.Combine(intermediatePath, "Current.BlockData")

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
                        Return CHCCommonLibrary.AreaCommon.Models.General.EssentialDataTransaction.composeCoordinate(header.identifyLedger, idVolume, idBlock)
                    Else
                        Return CHCCommonLibrary.AreaCommon.Models.General.EssentialDataTransaction.composeCoordinate(header.identifyLedger, idVolume, idBlock, idTransaction)
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
        Public ReadOnly Property currentTotalHash() As String
            Get
                Return _CurrentTotalHash
            End Get
        End Property

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

                proposeNewTransaction.currentHash = proposeNewTransaction.getHash()

                result.coordinate = CHCCommonLibrary.AreaCommon.Models.General.EssentialDataTransaction.composeCoordinate(header.identifyLedger, _currentIdVolume, _currentIdBlock, _NewIdTransaction)
                result.hash = proposeNewTransaction.currentHash
                proposeNewTransaction.progressiveHash = calculateProgressiveHash(result.hash)
                result.progressiveHash = proposeNewTransaction.progressiveHash
                result.registrationTimeStamp = proposeNewTransaction.registrationTimeStamp

                log.track("LedgerEngine.saveAndClean", "Assign value")

                _CompleteFileName = IO.Path.Combine(proposeNewTransaction.pathData.path, "BlockData.Ledger")

                Using fileData As IO.StreamWriter = IO.File.AppendText(_CompleteFileName)
                    fileData.WriteLine(proposeNewTransaction.toStringFormatToFile())
                End Using

                log.track("LedgerEngine.saveAndClean", "Write file ledger")

                If _DAO.saveData(proposeNewTransaction) Then
                    If (currentIdBlock <> nextIdBlock) Then
                        header.numBlocks += 1
                    Else
                        header.numBlocks = currentIdBlock + 1
                    End If

                    header.lastUpdateTimeStamp = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()
                    header.latestTransaction = result.coordinate
                    header.numVolumes = currentIdVolume + 1
                    header.numTransaction += 1

                    _NewIdTransaction += 1
                    _CurrentTotalHash = proposeNewTransaction.progressiveHash

                    log.track("LedgerEngine.saveAndClean", "Update counter")

                    approvedTransaction = proposeNewTransaction
                    proposeNewTransaction = New SingleTransactionLedger

                    proposeNewTransaction.pathData = approvedTransaction.pathData
                    proposeNewTransaction.id = _NewIdTransaction
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
        ''' This method provide to change a block
        ''' </summary>
        ''' <returns></returns>
        Public Function changeBlock(ByVal numberBlockInVolume As Integer) As Boolean
            Try
                log.track("LedgerEngine.changeBlock", "Begin")

                lastBlockClosed.blockIdentity = composeCoordinateTransaction(False, True)
                lastBlockClosed.hash = approvedTransaction.progressiveHash

                If (nextIdBlock = 0) And (nextIdVolume = 0) Then
                    nextIdBlock = 1
                End If

                currentIdBlock = nextIdBlock
                currentIdVolume = nextIdVolume
                _NewIdTransaction = 0

                If (nextIdBlock = numberBlockInVolume - 1) Then
                    nextIdVolume += 1

                    nextIdBlock = 0
                Else
                    nextIdBlock += 1
                End If

                log.track("LedgerEngine.changeBlock", "Local data set")

                Return createDBBlock()
            Catch ex As Exception
                log.track("LedgerEngine.changeBlock", ex.Message, "fatal")

            End Try

            Return False
        End Function

        ''' <summary>
        ''' This method provide to init a db engine
        ''' </summary>
        ''' <param name="path"></param>
        ''' <param name="creationLedgerDate"></param>
        ''' <returns></returns>
        Public Function init(ByVal path As String, ByVal creationLedgerDate As Double) As Boolean
            Try
                Dim proceed As Boolean = True

                log.track("LedgerEngine.init", "Begin")

                _BasePath = path

                _DAO.log = log

                log.track("LedgerEngine.init", "Local data set")

                If proceed Then
                    proceed = _DAO.createDBLedgerMap(_BasePath)
                End If
                If proceed Then
                    proceed = createDBBlock()
                End If
                If proceed Then
                    proceed = _DAO.init(path, True)
                End If

                Return proceed
            Catch ex As Exception
                log.track("LedgerEngine.init", ex.Message, "fatal")
            End Try

            Return False
        End Function

    End Class

End Namespace