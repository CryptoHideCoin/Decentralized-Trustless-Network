Option Compare Text
Option Explicit On





Namespace AreaFlow


    Public Class RequestExtended

        Public Enum EnumOperationPosition
            toDo
            inWork
            inError
            completeWithPositiveResult
            completeWithNegativeResult
        End Enum

        Public Property requestHash As String = ""
        Public Property dateNotify As Double = 0
        Public Property ticketNumber As String = ""
        Public Property requestCode As String = ""
        Public Property dateRequest As Double = 0
        Public Property directRequest As Boolean = False
        Public Property externalSource As String = ""
        Public Property dateSelected As Double = 0
        Public Property dateAssessment As Double = 0
        Public Property rejectedNote As String = ""

        Public Property requestPosition As EnumOperationPosition = EnumOperationPosition.toDo
        Public Property verifyPosition As EnumOperationPosition = EnumOperationPosition.toDo
        Public Property consensusPosition As EnumOperationPosition = EnumOperationPosition.toDo
        Public Property generalStatus As EnumOperationPosition = EnumOperationPosition.toDo

        Public Property response As AreaCommon.Masternode.EvaluationResponse = AreaCommon.Masternode.EvaluationResponse.notDeterminate

        Public Property evaluations As New AreaCommon.Masternode.MasternodeEvaluations
        Public Property notifyRejected As New AreaCommon.Masternode.MasternodeNotifyRejectedList

        Public Property notifyAssessmentAtNetwork As Boolean = False
        Public Property notifySingleConsensusAtNetwork As Boolean = False
        Public Property notifyConsensusAtNetwork As Boolean = False

        Public Property masterNodeExpressions As New AreaConsensus.ConsensusNetwork

    End Class

    Public Class RequestToSend

        Public Property sendBulletin As Boolean = False

        Public Property addTimeStamp As Double = 0
        Public Property requestCode As String = ""
        Public Property requestHash As String = ""
        Public Property deliveryList As AreaCommon.Masternode.MasternodeSenders

        Public Property dataObject As Object

        Public Property tryNumber As Double

    End Class

    Public Class RequestDownloadKey

        Public Property requestHash As String = ""
        Public Property publicAddress As String = ""

    End Class


    Public Class FlowEngine

        Private _TicketNumberValue As Integer = 0

        Private _RequestToSelected As New List(Of RequestExtended)
        Private _RequestToDownload As New Dictionary(Of RequestDownloadKey, RequestExtended)
        Private _RequestToVerify As New List(Of RequestExtended)
        Private _RequestToSend As New List(Of RequestToSend)

        Private _Requests As New Dictionary(Of String, RequestExtended)
        Private _RequestToProcess As New Dictionary(Of String, RequestExtended)
        Private _RequestProcessed As New Dictionary(Of String, RequestExtended)

        Private _RemoteBulletin As New List(Of AreaConsensus.RequestProcess)

        Public Property workerOn As Boolean = False


        Public Function addNewRequestDirect(ByVal requestHash As String, ByVal requestCode As String, ByVal dateRequest As Double, ByVal ticketNumber As String) As Boolean
            Try
                Dim value As New RequestExtended

                AreaCommon.log.track("RequestFlowEngine.addNewRequestDirect", "Begin")

                If Not _Requests.ContainsKey(value.requestHash) Then
                    value.requestHash = requestHash
                    value.requestCode = requestCode
                    value.dateRequest = dateRequest

                    value.directRequest = True
                    value.ticketNumber = ticketNumber
                    value.externalSource = ""

                    If (value.ticketNumber.Length > 0) Then
                        _TicketNumberValue = value.ticketNumber
                    Else
                        _TicketNumberValue += 1

                        value.ticketNumber = _TicketNumberValue
                    End If

                    _Requests.Add(value.requestHash, value)
                    _RequestToSelected.Add(value)
                End If

                AreaCommon.log.track("RequestFlowEngine.addNewRequestDirect", "Complete")

                Return True
            Catch ex As Exception
                AreaCommon.log.track("RequestFlowEngine.addNewRequestDirect", "Error:" & ex.Message, "error")

                Return False
            End Try
        End Function

        Public Function addNewRequestNotify(ByVal requestHash As String, ByVal requestCode As String, ByVal dateRequest As Double, ByVal externalSource As String) As Boolean
            Try
                Dim value As New RequestExtended

                AreaCommon.log.track("RequestFlowEngine.addNewRequestNotify", "Begin")

                If Not _Requests.ContainsKey(value.requestHash) Then
                    _TicketNumberValue += 1

                    value.requestHash = requestHash
                    value.requestCode = requestCode
                    value.dateRequest = dateRequest
                    value.directRequest = False
                    value.externalSource = externalSource
                    value.ticketNumber = _TicketNumberValue
                    value.dateNotify = CHCCommonLibrary.AreaEngine.Miscellaneous.timestampFromDateTime()
                End If

                _Requests.Add(value.requestHash, value)

                Return addNewRequestToDownload(value.requestHash, value.externalSource)
            Catch ex As Exception
                AreaCommon.log.track("RequestFlowEngine.addNewRequestNotify", "Error:" & ex.Message, "error")

                Return False
            Finally
                AreaCommon.log.track("RequestFlowEngine.addNewRequestNotify", "Complete")
            End Try
        End Function

        Public Function addNewRequestToDownload(ByVal requestHash As String, ByVal publicAddress As String) As Boolean
            If _Requests.ContainsKey(requestHash) Then
                Dim key As New AreaFlow.RequestDownloadKey

                key.requestHash = requestHash
                key.publicAddress = publicAddress

                _RequestToDownload.Add(key, _Requests(requestHash))

                Return True
            End If

            Return False
        End Function

        Public Function addNewRequestToSend(ByVal requestCode As String, ByRef requestHash As String, ByRef sender As AreaCommon.Masternode.MasternodeSenders, ByRef dataRequest As Object, Optional ByVal times As Byte = 0) As Boolean
            Dim item As New RequestToSend

            item.requestCode = requestCode
            item.requestHash = requestHash
            item.addTimeStamp = CHCCommonLibrary.AreaEngine.Miscellaneous.timestampFromDateTime()
            item.deliveryList = sender
            item.dataObject = dataRequest
            item.tryNumber = times

            _RequestToSend.Add(item)

            Return True
        End Function

        Public Function addNewBulletinToSend(ByRef sender As AreaCommon.Masternode.MasternodeSenders, ByRef dataRequest As Object) As Boolean
            Dim item As New RequestToSend

            item.sendBulletin = True
            item.deliveryList = sender
            item.dataObject = dataRequest
            item.addTimeStamp = CHCCommonLibrary.AreaEngine.Miscellaneous.timestampFromDateTime()

            _RequestToSend.Add(item)

            Return True
        End Function

        Public Function addNewRequestRemoteBulletin(ByVal value As AreaConsensus.RequestProcess) As Boolean
            _RemoteBulletin.Add(value)

            Return True
        End Function


        Public Function setRequestToProcess(ByRef item As RequestExtended) As Boolean
            Try
                AreaCommon.log.track("RequestFlowEngine.setRequestToProcess", "Begin")

                _RequestToVerify.Remove(item)
                _RequestToProcess.Add(item.requestHash, item)

                Return True
            Catch ex As Exception
                AreaCommon.log.track("RequestFlowEngine.setRequestToProcess", "Error:" & ex.Message, "error")

                Return False
            End Try
        End Function

        Public Function setRequestToSelect(ByRef item As RequestExtended) As Boolean
            Try
                AreaCommon.log.track("RequestFlowEngine.setRequestToSelect", "Begin")

                AreaCommon.flow.removeFirstRequestToDownload(item.requestHash, item.externalSource)
                _RequestToSelected.Add(item)

                Return True
            Catch ex As Exception
                AreaCommon.log.track("RequestFlowEngine.setRequestToSelect", "Error:" & ex.Message, "error")

                Return False
            End Try
        End Function

        Public Function setRequestToVerify(ByRef item As RequestExtended) As Boolean
            Try
                AreaCommon.log.track("RequestFlowEngine.setRequestToSelect", "Begin")

                _RequestToSelected.Remove(item)
                _RequestToVerify.Add(item)

                Return True
            Catch ex As Exception
                AreaCommon.log.track("RequestFlowEngine.setRequestToSelect", "Error:" & ex.Message, "error")

                Return False
            End Try
        End Function

        Public Function setRequestProcessed(ByRef item As RequestExtended) As Boolean
            Try
                AreaCommon.log.track("RequestFlowEngine.setRequestRejected", "Begin")

                item.generalStatus = RequestExtended.EnumOperationPosition.completeWithNegativeResult

                _RequestToSelected.Remove(item)
                _RequestProcessed.Add(item.requestHash, item)

                Return True
            Catch ex As Exception
                AreaCommon.log.track("RequestFlowEngine.setRequestRejected", "Error:" & ex.Message, "error")

                Return False
            End Try
        End Function


        Public Function getFirstRequestToSelect() As RequestExtended
            Try
                Dim result As New RequestExtended

                AreaCommon.log.track("RequestFlowEngine.getFirstRequestToSelect", "Begin")

                For Each item In _RequestToSelected
                    If (result.requestHash.Length = 0) Or (result.ticketNumber <= item.ticketNumber) Then
                        result = item

                        result.generalStatus = RequestExtended.EnumOperationPosition.inWork
                    End If
                Next

                AreaCommon.log.track("RequestFlowEngine.getFirstRequestToSelect", "Complete")

                Return result
            Catch ex As Exception
                AreaCommon.log.track("RequestFlowEngine.getFirstRequestToSelect", "Error:" & ex.Message, "error")

                Return New RequestExtended
            End Try
        End Function

        Public Function getFirstRequestToDownload() As RequestExtended
            Try
                Dim result As New RequestExtended

                AreaCommon.log.track("RequestFlowEngine.getFirstRequestToProcess", "Begin")

                For Each item In _RequestToDownload.Values
                    If (result.requestHash.Length = 0) Then
                        result = item
                    ElseIf (result.dateNotify <= item.dateNotify) Then
                        result = item
                    End If
                Next

                AreaCommon.log.track("RequestFlowEngine.getFirstRequestToDownload", "Complete")

                Return result
            Catch ex As Exception
                AreaCommon.log.track("RequestFlowEngine.getFirstRequestToDownload", "Error:" & ex.Message, "error")

                Return New RequestExtended
            End Try
        End Function

        Public Function getFirstRequestToVerify() As RequestExtended
            Try
                Dim result As New RequestExtended

                AreaCommon.log.track("RequestFlowEngine.getFirstRequestToVerify", "Begin")

                For Each item In _RequestToVerify
                    If (result.requestHash.Length = 0) Or (result.ticketNumber <= item.ticketNumber) Then
                        result = item
                    End If
                Next

                AreaCommon.log.track("RequestFlowEngine.getFirstRequestToVerify", "Complete")

                Return result
            Catch ex As Exception
                AreaCommon.log.track("RequestFlowEngine.getFirstRequestToVerify", "Error:" & ex.Message, "error")

                Return New RequestExtended
            End Try
        End Function

        Public Function getFirstRequestToSend() As RequestToSend
            Try
                Dim result As New RequestToSend

                AreaCommon.log.track("RequestFlowEngine.getFirstRequestToSend", "Begin")

                For Each item In _RequestToSend
                    If (result.requestCode.Length = 0) Then
                        result = item
                    ElseIf (result.addTimeStamp <= item.addTimeStamp) Then
                        result = item
                    End If
                Next

                If (result.requestCode.Length > 0) Then
                    _RequestToSend.Remove(result)
                End If

                AreaCommon.log.track("RequestFlowEngine.getFirstRequestToSend", "Complete")

                Return result
            Catch ex As Exception
                AreaCommon.log.track("RequestFlowEngine.getFirstRequestToSend", "Error:" & ex.Message, "error")

                Return New RequestToSend
            End Try
        End Function

        Public Function getFirstRemoteBulletin() As AreaConsensus.RequestProcess
            Try
                If (_RemoteBulletin.Count > 0) Then
                    Return _RemoteBulletin(0)
                Else
                    Return New AreaConsensus.RequestProcess
                End If
            Catch ex As Exception
                AreaCommon.log.track("RequestFlowEngine.getFirstRemoteBulletin", "Error:" & ex.Message, "error")

                Return New AreaConsensus.RequestProcess
            End Try
        End Function

        Public Function getRequestToProcess(ByVal requestHash As String) As RequestExtended
            If _RequestToProcess.ContainsKey(requestHash) Then
                Return _RequestToProcess(requestHash)
            End If
        End Function

        Public Function getRequest(ByVal requestHash As String) As RequestExtended
            Try
                If _Requests.ContainsKey(requestHash) Then
                    Return _Requests(requestHash)
                Else
                    Return New RequestExtended
                End If
            Catch ex As Exception
                AreaCommon.log.track("RequestFlowEngine.getRequest", "Error:" & ex.Message, "error")

                Return New RequestExtended
            End Try
        End Function

        Public Function getAllListToProcess() As Dictionary(Of String, RequestExtended)
            Return _RequestToProcess
        End Function


        Public Function createConsensusList() As AreaCommon.Masternode.ContactDataMasternodeList
            Try
                Dim result As New AreaCommon.Masternode.ContactDataMasternodeList

                For Each item In AreaCommon.state.runtimeState.getNodeListAbleToConsensus()
                    result.addNew(item.identityPublicAddress, item.ipAddress, item.votePoint)
                Next

                Return result
            Catch ex As Exception
                AreaCommon.log.track("RequestFlowEngine.createConsensusList", "Error:" & ex.Message, "error")

                Return New AreaCommon.Masternode.ContactDataMasternodeList
            End Try
        End Function


        Public Function removeRequest(ByRef value As RequestExtended) As Boolean
            Try
                _RequestToProcess.Remove(value.requestHash)
                _Requests.Remove(value.requestHash)

                Return True
            Catch ex As Exception
                AreaCommon.log.track("RequestFlowEngine.removeRequest", "Error:" & ex.Message, "error")

                Return False
            End Try
        End Function

        Public Function removeRequestToSend(ByRef value As RequestToSend) As Boolean
            Try
                _RequestToSend.Remove(value)

                Return True
            Catch ex As Exception
                AreaCommon.log.track("RequestFlowEngine.removeItem", "Error:" & ex.Message, "error")

                Return False
            End Try
        End Function

        Public Function removeFirstRequestToDownload(ByVal requestHash As String, ByRef publicAddress As String) As Boolean
            Dim key As New AreaFlow.RequestDownloadKey

            key.requestHash = requestHash
            key.publicAddress = publicAddress

            If _RequestToDownload.ContainsKey(key) Then
                _RequestToDownload.Remove(key)
            End If

            Return True
        End Function

        Public Function removeOldRequest() As Boolean
            Try
                Dim item As RequestExtended
                Dim counter As Integer = 0

                AreaCommon.log.track("RequestFlowEngine.refreshOldRequest", "Begin")

                If (_RequestProcessed.Count > 0) Then
                    item = _RequestProcessed(counter)

                    Do While (counter <= _RequestProcessed.Count)
                        If (item.dateRequest + (60000 * 60 * 24) > CHCCommonLibrary.AreaEngine.Miscellaneous.timestampFromDateTime()) Then
                            _RequestProcessed.Remove(item.requestHash)
                        End If

                        counter += 1
                    Loop
                End If

                AreaCommon.log.track("RequestFlowEngine.refreshOldRequest", "Complete")

                Return True
            Catch ex As Exception
                AreaCommon.log.track("RequestFlowEngine.refreshOldRequest", "Error:" & ex.Message, "error")

                Return True
            End Try
        End Function


        Public Function repositionDownload(ByVal requestHash As String, ByVal publicAddress As String) As Boolean
            Dim key As New AreaFlow.RequestDownloadKey
            Dim request As AreaFlow.RequestExtended

            key.requestHash = requestHash
            key.publicAddress = publicAddress

            If _RequestToDownload.ContainsKey(key) Then
                request = _RequestToDownload(key)

                request.dateNotify = CHCCommonLibrary.AreaEngine.Miscellaneous.timestampFromDateTime()
            End If

            Return True
        End Function


        Public Function manageCloseBlock() As Boolean
            Try
                Return True
            Catch ex As Exception
                AreaCommon.log.track("RequestFlowEngine.checkCloseBlock", "Error:" & ex.Message, "error")

                Return False
            End Try
        End Function

        <DebuggerHiddenAttribute()>
        Public Function init() As Boolean
            Try
                AreaCommon.log.track("RequestFlowEngine.init", "Begin")

                workerOn = True

                Dim work1 As New Threading.Thread(AddressOf AreaWorker.Downloader.work)
                Dim work2 As New Threading.Thread(AddressOf AreaWorker.Requester.work)
                Dim work3 As New Threading.Thread(AddressOf AreaWorker.Processor.work)
                Dim work4 As New Threading.Thread(AddressOf AreaWorker.Verifier.work)
                Dim work5 As New Threading.Thread(AddressOf AreaWorker.Sender.work)
                Dim work6 As New Threading.Thread(AddressOf AreaWorker.RemoteVerifier.work)

                work1.Start()
                work2.Start()
                work3.Start()
                work4.Start()
                work5.Start()
                work6.Start()

                AreaCommon.log.track("RequestFlowEngine.init", "Complete")

                Return True
            Catch ex As Exception
                AreaCommon.log.track("RequestFlowEngine.init", "Error:" & ex.Message, "error")

                Return False
            End Try
        End Function

    End Class


End Namespace