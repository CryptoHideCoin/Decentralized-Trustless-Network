Option Explicit On
Option Compare Text

Imports CHCCommonLibrary.AreaEngine.Encryption
Imports CHCBasicCryptographyLibrary.AreaEngine.Encryption.Base58Signature
Imports CHCCommonLibrary.AreaEngine.DataFileManagement
Imports CHCProtocolLibrary







Namespace AreaEngine.Ledger


    Namespace QoS

        Public Enum enumAction
            notDefined
            genesis
            linkBlock
            requestNewTicket
            associateRequest
            executeTicket
            responsePublicQuery
        End Enum

        Public Enum enumCurrentLocalPositionAction
            notDefined
            inQueue
            inEvaluation
            ProcessComplete
        End Enum

        Public Enum enumCurrentNetworkPositionAction
            notDefined
            notForwarded
            inEvaluation
            ProcessComplete
        End Enum

        Public Enum enumCurrentLedgerPositionAction
            notDefined
            actionNotYetStarted
            actionInProgress
            actionComplete
        End Enum

        Public Class ResponseWorkRequest
            Public localStatus As enumCurrentLocalPositionAction = enumCurrentLocalPositionAction.notDefined
            Public networkStatus As enumCurrentNetworkPositionAction = enumCurrentNetworkPositionAction.notDefined
            Public updateLedgerStatus As enumCurrentLedgerPositionAction = enumCurrentLedgerPositionAction.notDefined

            Public ReadOnly Property workComplete As Boolean
                Get
                    If (localStatus = enumCurrentLocalPositionAction.ProcessComplete) Then
                        If (errorResponse.Length > 0) Then
                            Return True
                        ElseIf (networkStatus = enumCurrentNetworkPositionAction.ProcessComplete) Then
                            If (errorResponse.Length > 0) Then
                                Return True
                            ElseIf (updateLedgerStatus = enumCurrentLedgerPositionAction.actionComplete) Then
                                Return True
                            Else
                                Return False
                            End If
                        Else
                            Return False
                        End If
                    Else
                        Return False
                    End If
                End Get
            End Property

            Public ledgerTransactionID As String = ""
            Public errorResponse As String = ""
        End Class

        Public Class SingleAction

            Private _totalHash As String = ""

            Public transactionID As String = ""
            Public moment As Double = 0
            Public action As enumAction = enumAction.notDefined
            Public ticketValue As String = ""
            Public requestID As String = ""
            Public runningTime As Decimal = 0

            Public currentState As New ResponseWorkRequest


            Public ReadOnly Property totalHash() As String
                Get
                    Return _totalHash
                End Get
            End Property

            Public Overrides Function toString() As String
                Dim tmp As String = ""

                tmp += transactionID & "|"
                tmp += moment.ToString() & "|"
                tmp += action.ToString() & "|"
                tmp += ticketValue & "|"
                tmp += runningTime.ToString()

                Return tmp
            End Function

            Public ReadOnly Property toHash() As String
                Get
                    Return HashSHA.generateSHA256(Me.toString().Replace("|", ""))
                End Get
            End Property

            Public Function exportEntireRow(ByVal previousTotalHash As String, ByVal privateWalletKey As String) As String
                Dim hash As String = toHash()

                _totalHash = HashSHA.generateSHA256(hash & previousTotalHash)

                Return Me.toString() & "|" & hash & "|" & getSignature(privateWalletKey, hash) & "|" & _totalHash
            End Function

        End Class

        Public Class SinglePageInternalLedger
            Public Property blockNumber As Integer
            Public Property fromTime As New DateTime
            Public Property toTime As New DateTime
            Public Property firstHash As String

            Public Sub New()
                fromTime = DateTime.MinValue
                toTime = DateTime.MaxValue
            End Sub
        End Class

        Public Class BlockInternalLedgerEngine

            Private _CurrentBlock As New SinglePageInternalLedger
            Private _LastHash As String = ""
            Private _RecordNumber As Integer = 0
            Private _BlockNumber As Integer = 0
            Private _PathBase As String = ""
            Private _PrivateKey As String = ""
            Private _FileName As String = ""

            Public pages As New List(Of SinglePageInternalLedger)
            Public blockSize As Integer = 0


            Private Sub saveBlockAction(ByRef newBlock As Ledger.QoS.SingleAction)
                Try
                    Using fileData As IO.StreamWriter = IO.File.AppendText(_FileName)
                        fileData.WriteLine(newBlock.exportEntireRow(_LastHash, _PrivateKey))
                    End Using

                    _LastHash = newBlock.totalHash
                    _RecordNumber += 1

                    changeBlockNumberFile()
                Catch ex As Exception
                End Try
            End Sub

            Private Sub createNewBlockAction(Optional ByVal value As enumAction = enumAction.genesis)
                Try
                    Dim newBlock As New SingleAction
                    Dim initial As DateTime = Now

                    newBlock.action = value
                    newBlock.moment = CHCCommonLibrary.AreaEngine.Miscellaneous.atMomentGMT()
                    newBlock.requestID = ""
                    newBlock.runningTime = Now.Subtract(initial).TotalSeconds
                    newBlock.ticketValue = ""
                    newBlock.transactionID = Guid.NewGuid.ToString()

                    saveBlockAction(newBlock)
                Catch ex As Exception
                End Try
            End Sub

            Private Sub changeBlockNumberFile()
                If (_FileName.Length > 0) Then
                    If (_RecordNumber > blockSize) Then
                        _CurrentBlock.toTime = Now

                        changeCurrentBlock()

                        _BlockNumber += 1

                        _FileName = IO.Path.Combine(_PathBase, _BlockNumber & ".ledger")

                        createNewBlockAction(enumAction.linkBlock)
                    End If
                Else
                    _FileName = IO.Path.Combine(_PathBase, _BlockNumber & ".ledger")
                End If
            End Sub

            Private Sub changeCurrentBlock()
                _CurrentBlock = New SinglePageInternalLedger

                _CurrentBlock.blockNumber = _BlockNumber
                _CurrentBlock.firstHash = _LastHash
                _CurrentBlock.fromTime = Now

                pages.Add(_CurrentBlock)
            End Sub

            Public Sub init(ByVal pathBase As String, ByVal ledgerBlockMaxSize As Integer, ByVal privateKey As String)
                _PathBase = IO.Path.Combine(pathBase, Guid.NewGuid.ToString())

                _PrivateKey = privateKey
                blockSize = ledgerBlockMaxSize

                IO.Directory.CreateDirectory(_PathBase)

                changeCurrentBlock()
                changeBlockNumberFile()
                createNewBlockAction()
            End Sub

            Public Function getDataFile(ByVal blockNumber As String) As String
                Try
                    Dim _FileName As String = IO.Path.Combine(_PathBase, _BlockNumber & ".ledger")
                    If IO.File.Exists(_FileName) Then
                        Return My.Computer.FileSystem.ReadAllText(_FileName)
                    Else
                        Return ""
                    End If
                Catch ex As Exception
                    Return ""
                End Try
            End Function

            Public Function requestNewTicket() As SingleAction
                Try
                    Dim newBlock As New SingleAction
                    Dim initial As DateTime = Now

                    newBlock.action = enumAction.requestNewTicket
                    newBlock.moment = CHCCommonLibrary.AreaEngine.Miscellaneous.atMomentGMT()
                    newBlock.requestID = ""
                    newBlock.runningTime = Now.Subtract(initial).TotalSeconds
                    newBlock.ticketValue = Guid.NewGuid.ToString()
                    newBlock.transactionID = newBlock.ticketValue

                    saveBlockAction(newBlock)

                    Return newBlock
                Catch ex As Exception
                    Return New SingleAction
                End Try
            End Function

            Public Sub associateRequest(ByVal ticketValue As String, ByVal requestID As String)
                Try
                    Dim newBlock As New SingleAction
                    Dim initial As DateTime = Now

                    newBlock.action = enumAction.associateRequest
                    newBlock.moment = CHCCommonLibrary.AreaEngine.Miscellaneous.atMomentGMT()
                    newBlock.requestID = requestID
                    newBlock.runningTime = Now.Subtract(initial).TotalSeconds
                    newBlock.ticketValue = ticketValue
                    newBlock.transactionID = Guid.NewGuid.ToString()

                    saveBlockAction(newBlock)
                Catch ex As Exception
                End Try
            End Sub

            Public Sub executeTicket(ByVal ticketValue As String)
                Try
                    Dim newBlock As New SingleAction
                    Dim initial As DateTime = Now

                    newBlock.action = enumAction.executeTicket
                    newBlock.moment = CHCCommonLibrary.AreaEngine.Miscellaneous.atMomentGMT()
                    newBlock.requestID = ""
                    newBlock.runningTime = Now.Subtract(initial).TotalSeconds
                    newBlock.ticketValue = ticketValue
                    newBlock.transactionID = Guid.NewGuid.ToString()

                    saveBlockAction(newBlock)
                Catch ex As Exception
                End Try
            End Sub

            Public Sub responsePublicQuery()
                Try
                    Dim newBlock As New SingleAction
                    Dim initial As DateTime = Now

                    newBlock.action = enumAction.responsePublicQuery
                    newBlock.moment = CHCCommonLibrary.AreaEngine.Miscellaneous.atMomentGMT()
                    newBlock.requestID = ""
                    newBlock.runningTime = Now.Subtract(initial).TotalSeconds
                    newBlock.ticketValue = ""
                    newBlock.transactionID = Guid.NewGuid.ToString()

                    saveBlockAction(newBlock)
                Catch ex As Exception
                End Try
            End Sub

        End Class


    End Namespace

End Namespace
