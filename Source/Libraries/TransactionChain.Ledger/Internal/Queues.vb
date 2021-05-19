Option Explicit On
Option Compare Text









Namespace AreaEngine.Requests


    Public Class QueueEngine

        Public Class NewTicketResponse
            Public Property ticketId As String = ""
            Public Property queueRequestNumber As Integer = 0
            Public Property queueOfPriorNumber As Integer = 0
            Public Property queueOfStandardNumber As Integer = 0
            Public Property queueOfUnclassified As Integer = 0
        End Class

        Public Class DataTicketResponse
            Public Enum enumPosition
                notFound
                toEvaluate
                toWait
                inProcessing
                ProcessComplete
            End Enum
            Public Property ticketId As String = ""
            Public Property position As enumPosition = enumPosition.toEvaluate
            Public Property priorClassified As Boolean = False
            Public Property queueNumber As Integer = 0
        End Class

        Public Class QueueResponse
            Public Property queueRequestNumber As Integer = 0
            Public Property queueOfPriorNumber As Integer = 0
            Public Property queueOfStandardNumber As Integer = 0
            Public Property queueOfUnclassified As Integer = 0
        End Class

        Private _Cycle As Integer = 0
        Private _MaxThreadParallels As Integer = 0
        Private _InternalLedger As New Ledger.QoS.BlockInternalLedgerEngine

        Private _Unclassified As New Dictionary(Of String, Ledger.QoS.SingleAction)
        Private _PriorRequest As New Queue(Of Ledger.QoS.SingleAction)
        Private _Request As New Queue(Of Ledger.QoS.SingleAction)
        Private _RequestKey As New Dictionary(Of String, Ledger.QoS.SingleAction)

        Private _ToExecute As New List(Of Ledger.QoS.SingleAction)
        Private _InExecute As New List(Of Ledger.QoS.SingleAction)



        Private Sub startWork()
            Try
                Dim tmp As Ledger.QoS.SingleAction

                tmp = _ToExecute(0)

                _ToExecute.Remove(tmp)

                _InExecute.Add(tmp)
            Catch ex As Exception
            End Try
        End Sub

        Private Sub executeThread(ByRef item As Ledger.QoS.SingleAction)
            Try
                _ToExecute.Add(item)

                Dim objWS As New Threading.Thread(AddressOf startWork)

                objWS.Start(item)
            Catch ex As Exception
            End Try
        End Sub

        Private Sub cleanWorked()
            Try
                Dim noDelete As Boolean

                Do While Not noDelete
                    noDelete = True

                    For Each item In _InExecute
                        If item.currentState.workComplete Then
                            _InExecute.Remove(item)
                            _RequestKey.Remove(item.requestID)

                            noDelete = False

                            Exit For
                        End If
                    Next
                Loop
            Catch ex As Exception
            End Try
        End Sub

        Public Sub refreshQueue()
            Try
                cleanWorked()

                If (_InExecute.Count < _MaxThreadParallels) Then
                    Dim item As Ledger.QoS.SingleAction

                    If (_Cycle < 2) Then
                        If (_PriorRequest.Count > 0) Then
                            item = _PriorRequest(0)

                            _PriorRequest.Dequeue()
                        ElseIf (_Request.Count > 0) Then
                            item = _Request(0)

                            _Request.Dequeue()
                        End If
                    Else
                        If (_Request.Count > 0) Then
                            item = _Request(0)

                            _Request.Dequeue()
                        End If
                    End If

                    If Not IsNothing(item) Then
                        executeThread(item)
                    End If
                End If
            Catch ex As Exception
            End Try
        End Sub

        Public Function getNewTicket() As NewTicketResponse
            Try
                Dim response As New NewTicketResponse

                Dim newTicket As Ledger.QoS.SingleAction = _InternalLedger.requestNewTicket()

                response.ticketId = newTicket.ticketValue
                response.queueRequestNumber = _RequestKey.Count
                response.queueOfPriorNumber = _PriorRequest.Count
                response.queueOfStandardNumber = _Request.Count
                response.queueOfUnclassified = _Unclassified.Count

                _Unclassified.Add(newTicket.requestID, newTicket)

                Return response
            Catch ex As Exception
                Return New NewTicketResponse
            End Try
        End Function

        Public Function getDataTicket(ByVal ticketValue As String, ByVal pathMessage As String, ByVal pathOldMessage As String) As DataTicketResponse
            Try
                Dim response As New DataTicketResponse
                Dim dataTicket As Ledger.QoS.SingleAction
                Dim found As Boolean = False
                Dim position As Integer = 0

                response.ticketId = ticketValue
                response.priorClassified = False
                response.queueNumber = 0

                For Each item In _ToExecute
                    If (item.ticketValue = ticketValue) Then
                        found = True
                        response.position = DataTicketResponse.enumPosition.inProcessing
                        Exit For
                    End If
                Next

                If Not found Then
                    For Each item In _InExecute
                        If (item.ticketValue = ticketValue) Then
                            found = True
                            response.position = DataTicketResponse.enumPosition.inProcessing
                            Exit For
                        End If
                    Next
                End If

                If Not found Then
                    For Each key In _Unclassified.Keys
                        dataTicket = _Unclassified(key)
                        If (dataTicket.ticketValue = ticketValue) Then
                            found = True
                            response.position = DataTicketResponse.enumPosition.toEvaluate
                            Exit For
                        End If
                    Next
                End If

                If Not found Then
                    position = 0
                    For Each item In _PriorRequest
                        position += 1
                        If (item.ticketValue = ticketValue) Then
                            found = True
                            response.position = DataTicketResponse.enumPosition.toWait
                            response.priorClassified = True
                            response.queueNumber = position
                            Exit For
                        End If
                    Next
                End If

                If Not found Then
                    position = 0
                    For Each item In _Request
                        position += 1
                        If (item.ticketValue = ticketValue) Then
                            found = True
                            response.position = DataTicketResponse.enumPosition.toWait
                            response.priorClassified = False
                            response.queueNumber = position
                            Exit For
                        End If
                    Next
                End If

                If Not found Then
                    If IO.File.Exists(IO.Path.Combine(pathMessage, ticketValue & ".request")) Then
                        found = True
                        response.position = DataTicketResponse.enumPosition.ProcessComplete
                        response.priorClassified = False
                        response.queueNumber = 0
                    End If
                End If

                If Not found Then
                    If IO.File.Exists(IO.Path.Combine(pathOldMessage, ticketValue & ".request")) Then
                        found = True
                        response.position = DataTicketResponse.enumPosition.ProcessComplete
                        response.priorClassified = False
                        response.queueNumber = 0
                    Else
                        response.position = DataTicketResponse.enumPosition.ProcessComplete
                        response.priorClassified = False
                        response.queueNumber = 0
                    End If
                Else
                    response.position = DataTicketResponse.enumPosition.notFound
                    response.priorClassified = False
                    response.queueNumber = 0
                End If

                Return response
            Catch ex As Exception
                Return New DataTicketResponse
            End Try
        End Function

        Public Function getQueueTickets() As QueueResponse
            Dim response As New QueueResponse
            Try
                response.queueRequestNumber = _RequestKey.Count
                response.queueOfPriorNumber = _PriorRequest.Count
                response.queueOfStandardNumber = _Request.Count
                response.queueOfUnclassified = _Unclassified.Count
            Catch ex As Exception
            End Try

            Return response
        End Function

        Public ReadOnly Property getMaxBlockInternalLedgerSize() As Integer
            Get
                Return _InternalLedger.blockSize
            End Get
        End Property

        Public ReadOnly Property getDataPages() As List(Of AreaEngine.Ledger.QoS.SinglePageInternalLedger)
            Get
                Return _InternalLedger.pages
            End Get
        End Property

        Public Function getDataFile(ByVal pageNumber As Integer) As String
            Try
                Return _InternalLedger.getDataFile(pageNumber)
            Catch ex As Exception
                Return ""
            End Try
        End Function

        Public Function assignPriorRequest(ByVal ticketNumber As String, ByVal requestID As String) As Boolean
            Try
                Dim tmp As Ledger.QoS.SingleAction

                If _Unclassified.ContainsKey(ticketNumber) Then

                    tmp = _Unclassified(ticketNumber)

                    tmp.requestID = requestID

                    _Unclassified.Remove(ticketNumber)
                    _PriorRequest.Enqueue(tmp)
                    _RequestKey.Add(tmp.ticketValue, tmp)

                    refreshQueue()

                    Return True
                End If
            Catch ex As Exception
            End Try

            Return False
        End Function

        Public Function assignRequest(ByVal ticketNumber As String, ByVal requestID As String) As Boolean
            Try
                Dim tmp As Ledger.QoS.SingleAction

                If _Unclassified.ContainsKey(ticketNumber) Then

                    tmp = _Unclassified(ticketNumber)

                    tmp.requestID = requestID

                    _Unclassified.Remove(ticketNumber)
                    _Request.Enqueue(tmp)
                    _RequestKey.Add(tmp.ticketValue, tmp)

                    refreshQueue()

                    Return True
                End If
            Catch ex As Exception
            End Try

            Return False
        End Function

        Public Sub init(ByVal pathBase As String, ByVal ledgerBlockMaxSize As Integer, ByVal maxThreadParallels As Integer, ByVal privateKey As String)
            _MaxThreadParallels = maxThreadParallels

            _InternalLedger.init(pathBase, ledgerBlockMaxSize, privateKey)
        End Sub

    End Class


End Namespace