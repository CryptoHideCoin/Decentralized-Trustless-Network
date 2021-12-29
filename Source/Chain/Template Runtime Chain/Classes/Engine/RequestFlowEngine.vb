Option Compare Text
Option Explicit On





Namespace AreaFlow

    ''' <summary>
    ''' This class contain the engine of a flow
    ''' </summary>
    Public Class FlowEngine

        Private _TicketNumberValue As Integer = 0

        Private _RequestToSelected As New List(Of RequestExtended)
        Private _RequestToDownload As New Dictionary(Of RequestDownloadKey, RequestExtended)
        Private _RequestToVerify As New List(Of RequestExtended)
        Private _RequestToSend As New List(Of RequestToSend)

        Private _Requests As New Dictionary(Of String, RequestExtended)
        Private _RequestToProcess As New Dictionary(Of String, RequestExtended)
        Private _RequestProcessed As New Dictionary(Of String, RequestExtended)

        Private _RemoteBulletin As New List(Of AreaConsensus.BulletinInformation)

        Private _RequestManager As New TransactionChainLibrary.AreaEngine.Requests.RequestManager

        Public Enum EnumPhases
            toSelect
            toVerify
        End Enum

        Public Property workerOn As Boolean = False



        ''' <summary>
        ''' This method provide to remove first request to download
        ''' </summary>
        ''' <param name="requestHash"></param>
        ''' <param name="publicAddress"></param>
        ''' <returns></returns>
        Private Function removeFirstRequestToDownload(ByVal requestHash As String, ByRef publicAddress As String) As Boolean
            Dim key As New AreaFlow.RequestDownloadKey

            key.requestHash = requestHash
            key.publicAddress = publicAddress

            If _RequestToDownload.ContainsKey(key) Then
                _RequestToDownload.Remove(key)
            End If

            Return True
        End Function

        ''' <summary>
        ''' This method provide to get a first request of a list
        ''' </summary>
        ''' <param name="phase"></param>
        ''' <returns></returns>
        Private Function getFirstRequest(ByVal phase As EnumPhases) As RequestExtended
            Try
                Dim result As New RequestExtended
                Dim listRequest As List(Of RequestExtended)
                Dim repeat As Boolean = True

                AreaCommon.log.track("RequestFlowEngine.getFirstRequest", "Begin")

                Do While repeat
                    repeat = False

                    Select Case phase
                        Case EnumPhases.toSelect : listRequest = _RequestToSelected
                        Case EnumPhases.toVerify : listRequest = _RequestToVerify
                    End Select

                    Try
                        For Each item In listRequest
                            If (result.dataCommon.hash.Length = 0) Or (Val(result.source.ticketNumber) >= Val(item.source.ticketNumber)) Then
                                result = item
                            End If
                        Next
                    Catch ex As Exception
                        repeat = True
                    End Try
                Loop

                AreaCommon.log.track("RequestFlowEngine.getFirstRequest", "Completed")

                Return result
            Catch ex As Exception
                AreaCommon.log.track("RequestFlowEngine.getFirstRequest", ex.Message, "fatal")

                Return New RequestExtended
            End Try
        End Function


        ''' <summary>
        ''' This method provide to add a new direct request
        ''' </summary>
        ''' <param name="request"></param>
        ''' <param name="ticketNumber"></param>
        ''' <returns></returns>
        Public Function addNewRequestDirect(ByRef request As Object, Optional ByVal ticketNumber As String = "") As Boolean
            Try
                Dim value As New RequestExtended

                AreaCommon.log.track("RequestFlowEngine.addNewRequestDirect", "Begin")

                If Not _Requests.ContainsKey(request.common.hash) Then
                    value.data = request
                    value.source.acquireTimeStamp = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()
                    value.source.directRequest = True

                    If (value.source.ticketNumber.Length > 0) Then
                        _TicketNumberValue = value.source.ticketNumber
                    ElseIf (ticketNumber.Length > 0) Then
                        value.source.ticketNumber = ticketNumber

                        _TicketNumberValue = ticketNumber
                    Else
                        _TicketNumberValue += 1

                        value.source.ticketNumber = _TicketNumberValue
                    End If

                    If _RequestManager.addNewRequest(request.common.hash, request.common.type) Then
                        _Requests.Add(request.common.hash, value)
                        _RequestToSelected.Add(value)
                    End If
                End If

                AreaCommon.log.track("RequestFlowEngine.addNewRequestDirect", "Completed")

                Return True
            Catch ex As Exception
                AreaCommon.log.track("RequestFlowEngine.addNewRequestDirect", ex.Message, "fatal")

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to add a new request into notify
        ''' </summary>
        ''' <param name="requestHash"></param>
        ''' <param name="type"></param>
        ''' <param name="dateRequest"></param>
        ''' <param name="externalSource"></param>
        ''' <returns></returns>
        Public Function addNewRequestNotify(ByVal requestHash As String, ByVal [type] As String, ByVal dateRequest As Double, ByVal externalSource As String) As Boolean
            Try
                Dim value As New RequestExtended

                AreaCommon.log.track("RequestFlowEngine.addNewRequestNotify", "Begin")

                If Not _Requests.ContainsKey(requestHash) Then
                    _TicketNumberValue += 1

                    value.dataCommon.hash = requestHash
                    value.dataCommon.type = [type]
                    value.source.directRequest = False
                    value.source.notifiedPublicAddress = externalSource
                    value.source.ticketNumber = _TicketNumberValue
                    value.source.notifyTimeStamp = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()
                Else
                    Return False
                End If

                _Requests.Add(value.dataCommon.hash, value)

                Return addNewRequestToDownload(value.dataCommon.hash, value.source.notifiedPublicAddress)
            Catch ex As Exception
                AreaCommon.log.track("RequestFlowEngine.addNewRequestNotify", ex.Message, "fatal")

                Return False
            Finally
                AreaCommon.log.track("RequestFlowEngine.addNewRequestNotify", "Completed")
            End Try
        End Function

        ''' <summary>
        ''' This method provide to add a new request to download
        ''' </summary>
        ''' <param name="requestHash"></param>
        ''' <param name="publicAddress"></param>
        ''' <returns></returns>
        Public Function addNewRequestToDownload(ByVal requestHash As String, ByVal publicAddress As String) As Boolean
            Try
                AreaCommon.log.track("RequestFlowEngine.addNewRequestToDownload", "Begin")

                If _Requests.ContainsKey(requestHash) Then
                    Dim key As New AreaFlow.RequestDownloadKey

                    key.requestHash = requestHash
                    key.publicAddress = publicAddress

                    _RequestToDownload.Add(key, _Requests(requestHash))

                    Return True
                End If

                AreaCommon.log.track("RequestFlowEngine.addNewRequestToDownload", "Completed")

                Return False
            Catch ex As Exception
                AreaCommon.log.track("RequestFlowEngine.addNewRequestToDownload", ex.Message, "fatal")

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to add a new request to send
        ''' </summary>
        ''' <param name="type"></param>
        ''' <param name="requestHash"></param>
        ''' <param name="sender"></param>
        ''' <param name="dataRequest"></param>
        ''' <param name="times"></param>
        ''' <returns></returns>
        Public Function addNewRequestToSend(ByVal [type] As String, ByRef requestHash As String, ByRef sender As AreaCommon.Masternode.MasternodeSenders, ByRef dataRequest As Object, Optional ByVal times As Byte = 0) As Boolean
            Try
                AreaCommon.log.track("RequestFlowEngine.addNewRequestToSend", "Begin")

                Dim item As New RequestToSend

                item.type = [type]
                item.requestHash = requestHash
                item.addTimeStamp = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()
                item.deliveryList = sender
                item.dataObject = dataRequest
                item.tryNumber = times

                _RequestToSend.Add(item)

                AreaCommon.log.track("RequestFlowEngine.addNewRequestToSend", "Completed")

                Return True
            Catch ex As Exception
                AreaCommon.log.track("RequestFlowEngine.addNewRequestToSend", ex.Message, "fatal")

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to add new bulletin to send
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="dataRequest"></param>
        ''' <returns></returns>
        Public Function addNewBulletinToSend(ByRef sender As AreaCommon.Masternode.MasternodeSenders, ByRef dataRequest As Object) As Boolean
            Try
                AreaCommon.log.track("RequestFlowEngine.addNewBulletinToSend", "Begin")

                Dim item As New RequestToSend

                item.sendType = EnumEntityToSend.bulletin
                item.deliveryList = sender
                item.dataObject = dataRequest
                item.addTimeStamp = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()

                _RequestToSend.Add(item)

                AreaCommon.log.track("RequestFlowEngine.addNewBulletinToSend", "Completed")

                Return True
            Catch ex As Exception
                AreaCommon.log.track("RequestFlowEngine.addNewBulletinToSend", ex.Message, "fatal")

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to add a new request to declare an expression
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="requestHash"></param>
        ''' <returns></returns>
        Public Function addNewRequestToExpression(ByRef sender As AreaCommon.Masternode.MasternodeSenders, ByRef requestHash As String) As Boolean
            Try
                AreaCommon.log.track("RequestFlowEngine.addNewRequestToExpression", "Begin")

                Dim item As New RequestToSend

                item.sendType = EnumEntityToSend.requestResponse
                item.deliveryList = sender
                item.requestHash = requestHash
                item.addTimeStamp = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()

                _RequestToSend.Add(item)

                AreaCommon.log.track("RequestFlowEngine.addNewRequestToExpression", "Completed")

                Return True
            Catch ex As Exception
                AreaCommon.log.track("RequestFlowEngine.addNewRequestToExpression", ex.Message, "fatal")

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to add new request remote bulletin
        ''' </summary>
        ''' <param name="value"></param>
        ''' <returns></returns>
        Public Function addNewRequestRemoteBulletin(ByVal value As AreaConsensus.BulletinInformation) As Boolean
            Try
                AreaCommon.log.track("RequestFlowEngine.addNewRequestRemoteBulletin", "Begin")

                _RemoteBulletin.Add(value)

                AreaCommon.log.track("RequestFlowEngine.addNewRequestRemoteBulletin", "Completed")

                Return True
            Catch ex As Exception
                AreaCommon.log.track("RequestFlowEngine.addNewRequestRemoteBulletin", ex.Message, "fatal")

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to set request to process
        ''' </summary>
        ''' <param name="item"></param>
        ''' <returns></returns>
        Public Function setRequestToProcess(ByRef item As RequestExtended) As Boolean
            Try
                AreaCommon.log.track("RequestFlowEngine.setRequestToProcess", "Begin")

                _RequestToVerify.Remove(item)
                _RequestToProcess.Add(item.dataCommon.hash, item)

                AreaCommon.log.track("RequestFlowEngine.setRequestToProcess", "Completed")

                Return True
            Catch ex As Exception
                AreaCommon.log.track("RequestFlowEngine.setRequestToProcess", ex.Message, "fatal")

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to set a request to select
        ''' </summary>
        ''' <param name="item"></param>
        ''' <returns></returns>
        Public Function setRequestToSelect(ByRef item As RequestExtended) As Boolean
            Try
                Dim proceed As Boolean = True

                AreaCommon.log.track("RequestFlowEngine.setRequestToSelect", "Begin")

                If proceed Then
                    proceed = removeFirstRequestToDownload(item.dataCommon.hash, item.source.notifiedPublicAddress)
                End If
                _RequestToSelected.Add(item)
                If proceed Then
                    proceed = _RequestManager.addNewRequest(item.dataCommon.hash, item.dataCommon.type)
                End If

                AreaCommon.log.track("RequestFlowEngine.setRequestToSelect", "Completed")

                Return proceed
            Catch ex As Exception
                AreaCommon.log.track("RequestFlowEngine.setRequestToSelect", ex.Message, "fatal")

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to set a request to verify
        ''' </summary>
        ''' <param name="item"></param>
        ''' <returns></returns>
        Public Function setRequestToVerify(ByRef item As RequestExtended) As Boolean
            Try
                AreaCommon.log.track("RequestFlowEngine.setRequestToSelect", "Begin")

                _RequestToSelected.Remove(item)
                _RequestToVerify.Add(item)

                AreaCommon.log.track("RequestFlowEngine.setRequestToSelect", "Completed")

                Return True
            Catch ex As Exception
                AreaCommon.log.track("RequestFlowEngine.setRequestToSelect", ex.Message, "fatal")

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to set a request to process
        ''' </summary>
        ''' <param name="item"></param>
        ''' <returns></returns>
        Public Function setRequestProcessed(ByRef item As RequestExtended, ByVal block As String, Optional ByVal rejected As Boolean = False) As Boolean
            Try
                AreaCommon.log.track("RequestFlowEngine.setRequestProcessed", "Begin")

                If _RequestToSelected.Contains(item) Then
                    _RequestToSelected.Remove(item)
                End If
                If _RequestToProcess.ContainsKey(item.dataCommon.hash) Then
                    _RequestToProcess.Remove(item.dataCommon.hash)
                End If
                _RequestProcessed.Add(item.dataCommon.hash, item)

                If rejected Or (item.position.process <> EnumOperationPosition.completeWithPositiveResult) Then
                    _RequestManager.completedRequest(item.dataCommon.hash, TransactionChainLibrary.AreaEngine.Requests.RequestManager.RequestData.stateRequest.rejected, block)
                Else
                    _RequestManager.completedRequest(item.dataCommon.hash, TransactionChainLibrary.AreaEngine.Requests.RequestManager.RequestData.stateRequest.stored, block)
                End If

                AreaCommon.log.track("RequestFlowEngine.setRequestProcessed", "Completed")

                Return True
            Catch ex As Exception
                AreaCommon.log.track("RequestFlowEngine.setRequestProcessed", ex.Message, "fatal")

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to first request to select
        ''' </summary>
        ''' <returns></returns>
        Public Function getFirstRequestToSelect() As RequestExtended
            Return getFirstRequest(EnumPhases.toSelect)
        End Function

        ''' <summary>
        ''' This method provide to get a first request to verify
        ''' </summary>
        ''' <returns></returns>
        Public Function getFirstRequestToVerify() As RequestExtended
            Return getFirstRequest(EnumPhases.toVerify)
        End Function

        ''' <summary>
        ''' This method provide to create a consensus list
        ''' </summary>
        ''' <returns></returns>
        Public Function createEvaluationList() As AreaCommon.Masternode.ContactDataMasternodeList
            Try
                Dim result As New AreaCommon.Masternode.ContactDataMasternodeList

                AreaCommon.log.track("RequestFlowEngine.createConsensusList", "Begin")

                For Each item In AreaCommon.state.runTimeState.getNodeListAbleToConsensus()
                    result.addNew(item.identityPublicAddress, item.ipAddress, item.power)
                Next

                AreaCommon.log.track("RequestFlowEngine.createConsensusList", "Completed")

                Return result
            Catch ex As Exception
                AreaCommon.log.track("RequestFlowEngine.createConsensusList", ex.Message, "fatal")

                Return New AreaCommon.Masternode.ContactDataMasternodeList
            End Try
        End Function

        ''' <summary>
        ''' This method provide to get a first request notified to download
        ''' </summary>
        ''' <returns></returns>
        Public Function getFirstRequestToDownload() As RequestExtended
            Try
                Dim result As New RequestExtended
                Dim repeat As Boolean = True

                AreaCommon.log.track("RequestFlowEngine.getFirstRequestToDownload", "Begin")

                Do While repeat
                    Try
                        repeat = False

                        For Each item In _RequestToDownload.Values
                            If (result.dataCommon.hash.Length = 0) Then
                                result = item
                            ElseIf (result.source.notifyTimeStamp <= item.source.notifyTimeStamp) Then
                                result = item
                            End If
                        Next
                    Catch ex As Exception
                        repeat = True
                    End Try
                Loop

                AreaCommon.log.track("RequestFlowEngine.getFirstRequestToDownload", "Completed")

                Return result
            Catch ex As Exception
                AreaCommon.log.track("RequestFlowEngine.getFirstRequestToDownload", ex.Message, "fatal")

                Return New RequestExtended
            End Try
        End Function

        ''' <summary>
        ''' This method provide to get a first request to send
        ''' </summary>
        ''' <returns></returns>
        Public Function getFirstRequestToSend() As RequestToSend
            Try
                Dim result As New RequestToSend

                AreaCommon.log.track("RequestFlowEngine.getFirstRequestToSend", "Begin")

                For Each item In _RequestToSend
                    If (result.type.Length = 0) Then
                        result = item
                    ElseIf (result.addTimeStamp <= item.addTimeStamp) Then
                        result = item
                    End If
                Next

                If (result.type.Length > 0) Then
                    _RequestToSend.Remove(result)
                End If

                AreaCommon.log.track("RequestFlowEngine.getFirstRequestToSend", "Completed")

                Return result
            Catch ex As Exception
                AreaCommon.log.track("RequestFlowEngine.getFirstRequestToSend", ex.Message, "fatal")

                Return New RequestToSend
            End Try
        End Function

        ''' <summary>
        ''' This method provide to get a request
        ''' </summary>
        ''' <param name="hash"></param>
        ''' <returns></returns>
        Public Function getActiveRequest(ByVal hash As String) As RequestExtended
            Try
                AreaCommon.log.track("RequestFlowEngine.getActiveRequest", "Begin")

                If _Requests.ContainsKey(hash) Then
                    Return _Requests(hash)
                End If

                AreaCommon.log.track("RequestFlowEngine.getActiveRequest", "Completed")
            Catch ex As Exception
                AreaCommon.log.track("RequestFlowEngine.getActiveRequest", ex.Message, "fatal")
            End Try

            Return New RequestExtended
        End Function

        ''' <summary>
        ''' This method provide to ge a request from a memory or DB
        ''' </summary>
        ''' <param name="hash"></param>
        ''' <returns></returns>
        Public Function getRequest(ByVal hash As String) As RequestExtended
            Try
                Dim result As RequestExtended
                Dim request As TransactionChainLibrary.AreaEngine.Requests.RequestManager.RequestData

                AreaCommon.log.track("RequestFlowEngine.getRequest", "Begin")

                result = getActiveRequest(hash)

                If (result.dataCommon.hash.Length = 0) Then
                    request = _RequestManager.getRequest(hash)

                    If (request.hash.Length > 0) Then
                        Dim requestPath As String = AreaCommon.state.ledgerMap.getRequestPath(request.block)

                        If (requestPath.Length > 0) Then
                            Select Case request.type
                                Case "a0x0" : result.data = AreaProtocol.A0x0.Manager.loadRequest(requestPath, hash)
                                Case "a0x1" : result.data = AreaProtocol.A0x1.Manager.loadRequest(requestPath, hash)
                                Case "a0x2" : result.data = AreaProtocol.A0x2.Manager.loadRequest(requestPath, hash)
                                Case "a0x3" : result.data = AreaProtocol.A0x3.Manager.loadRequest(requestPath, hash)
                                Case "a0x4" : result.data = AreaProtocol.A0x4.Manager.loadRequest(requestPath, hash)
                                Case "a0x5" : result.data = AreaProtocol.A0x5.Manager.loadRequest(requestPath, hash)
                                Case "a0x6" : result.data = AreaProtocol.A0x6.Manager.loadRequest(requestPath, hash)
                                Case "a0x7" : result.data = AreaProtocol.A0x7.Manager.loadRequest(requestPath, hash)
                                Case "a0x8" : result.data = AreaProtocol.A0x8.Manager.loadRequest(requestPath, hash)

                                Case "a1x0" : result.data = AreaProtocol.A1x0.Manager.loadRequest(requestPath, hash)
                                Case "a1x1" : result.data = AreaProtocol.A1x1.Manager.loadRequest(requestPath, hash)
                                Case "a1x2" : result.data = AreaProtocol.A1x2.Manager.loadRequest(requestPath, hash)
                                Case "a1x3" : result.data = AreaProtocol.A1x3.Manager.loadRequest(requestPath, hash)
                                Case "a1x4" : result.data = AreaProtocol.A1x4.Manager.loadRequest(requestPath, hash)
                                Case "a1x5" : result.data = AreaProtocol.A1x5.Manager.loadRequest(requestPath, hash)
                                Case "a1x6" : result.data = AreaProtocol.A1x6.Manager.loadRequest(requestPath, hash)
                                Case "a1x7" : result.data = AreaProtocol.A1x7.Manager.loadRequest(requestPath, hash)
                                Case "a1x8" : result.data = AreaProtocol.A1x8.Manager.loadRequest(requestPath, hash)
                                Case "a1x9" : result.data = AreaProtocol.A1x9.Manager.loadRequest(requestPath, hash)
                                Case "a1x10" : result.data = AreaProtocol.A1x10.Manager.loadRequest(requestPath, hash)

                                Case "a2x0" : result.data = AreaProtocol.A2x0.Manager.loadRequest(requestPath, hash)
                                Case "a2x1" : result.data = AreaProtocol.A2x1.Manager.loadRequest(requestPath, hash)
                                Case "a2x1" : result.data = AreaProtocol.A2x2.Manager.loadRequest(requestPath, hash)

                                    ''' BOOKMARK: Add in this point 3
                                    ''' 
                            End Select
                        End If
                    End If
                End If

                Return result

                AreaCommon.log.track("RequestFlowEngine.getRequest", "Completed")
            Catch ex As Exception
                AreaCommon.log.track("RequestFlowEngine.getRequest", ex.Message, "fatal")

                Return New RequestExtended
            End Try
        End Function

        ''' <summary>
        ''' This method provide to get a request block position
        ''' </summary>
        ''' <param name="requestHash"></param>
        ''' <returns></returns>
        Public Function getRequestBlockPosition(ByVal requestHash As String) As String
            Try
                AreaCommon.log.track("RequestFlowEngine.getRequestBlockPosition", "Begin")

                Return _RequestManager.getRequestBlockPosition(requestHash)
            Catch ex As Exception
                AreaCommon.log.track("RequestFlowEngine.getRequestBlockPosition", ex.Message, "fatal")

                Return ""
            Finally
                AreaCommon.log.track("RequestFlowEngine.getRequestBlockPosition", "Completed")
            End Try
        End Function

        ''' <summary>
        ''' This method provide to get first request to process
        ''' </summary>
        ''' <returns></returns>
        Public Function getFirstRequestToProcess() As RequestExtended
            Try
                Dim result As New RequestExtended
                Dim repeat As Boolean = True

                AreaCommon.log.track("RequestFlowEngine.getFirstRequestToProcess", "Begin")

                Do While repeat
                    repeat = False

                    Try
                        For Each item In _RequestToProcess.Values
                            If ((result.dataCommon.hash.Length = 0) Or (Val(result.source.ticketNumber) >= Val(item.source.ticketNumber))) Then
                                result = item
                            End If
                        Next
                    Catch ex As Exception
                        repeat = True
                    End Try
                Loop

                AreaCommon.log.track("RequestFlowEngine.getFirstRequestToProcess", "Completed")

                Return result
            Catch ex As Exception
                AreaCommon.log.track("RequestFlowEngine.getFirstRequestToProcess", ex.Message, "fatal")

                Return New RequestExtended
            End Try
        End Function

        ''' <summary>
        ''' This method provide to approve time stamp
        ''' </summary>
        ''' <param name="requesthash"></param>
        ''' <param name="bulletinRegistrationTimeStamp"></param>
        ''' <returns></returns>
        Public Function getApprovedTimeStamp(ByVal requestHash As String, ByVal ledgerRegistrationTimeStamp As Double) As Double
            Try
                Dim item As RequestExtended = _Requests(requestHash)
                Dim currentAssessmentTimeStamp As Double = 0
                Dim minimalAssessmentTimeStamp As Double = 0

                AreaCommon.log.track("RequestFlowEngine.getApprovedTimeStamp", "Begin")

                For i As Integer = 1 To _Requests.Count
                    currentAssessmentTimeStamp = item.evaluations.approved.getItem(i).assessmentTimeStamp

                    If (currentAssessmentTimeStamp > ledgerRegistrationTimeStamp) Then
                        If (minimalAssessmentTimeStamp = 0) Or (currentAssessmentTimeStamp < minimalAssessmentTimeStamp) Then
                            minimalAssessmentTimeStamp = currentAssessmentTimeStamp
                        End If
                    End If
                Next

                AreaCommon.log.track("RequestFlowEngine.getApprovedTimeStamp", "Completed")

                Return minimalAssessmentTimeStamp
            Catch ex As Exception
                AreaCommon.log.track("RequestFlowEngine.getApprovedTimeStamp", ex.Message, "fatal")

                Return 0
            End Try
        End Function

        ''' <summary>
        ''' This method provide to get a first a remote bulletin
        ''' </summary>
        ''' <returns></returns>
        Public Function getFirstRemoteBulletin() As AreaConsensus.BulletinInformation
            Try
                AreaCommon.log.track("RequestFlowEngine.getFirstRemoteBulletin", "Begin")

                If (_RemoteBulletin.Count > 0) Then
                    Return _RemoteBulletin(0)
                Else
                    Return New AreaConsensus.BulletinInformation
                End If

                AreaCommon.log.track("RequestFlowEngine.getFirstRemoteBulletin", "Completed")
            Catch ex As Exception
                AreaCommon.log.track("RequestFlowEngine.getFirstRemoteBulletin", ex.Message, "fatal")

                Return New AreaConsensus.BulletinInformation
            End Try
        End Function

        ''' <summary>
        ''' This method provide to check a remote a bulletin from a node
        ''' </summary>
        ''' <param name="publicAddress"></param>
        ''' <returns></returns>
        Public Function checkRemoteBulletinFromNode(ByVal publicAddress As String) As Boolean
            Try
                AreaCommon.log.track("RequestFlowEngine.checkRemoteBulletinFromNode", "Begin")

                For Each item In _RemoteBulletin
                    If (item.header.publicAddress.CompareTo(publicAddress) = 0) Then
                        Return True
                    End If
                Next

                AreaCommon.log.track("RequestFlowEngine.checkRemoteBulletinFromNode", "Completed")

                Return False
            Catch ex As Exception
                AreaCommon.log.track("RequestFlowEngine.checkRemoteBulletinFromNode", ex.Message, "fatal")

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to remote a request from a to Send list
        ''' </summary>
        ''' <param name="value"></param>
        ''' <returns></returns>
        Public Function removeRequestToSend(ByRef value As RequestToSend) As Boolean
            Try
                _RequestToSend.Remove(value)

                Return True
            Catch ex As Exception
                AreaCommon.log.track("RequestFlowEngine.removeItem", ex.Message, "fatal")

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to remove old request
        ''' </summary>
        ''' <returns></returns>
        Public Function removeOldRequest() As Boolean
            Try
                Dim item As RequestExtended
                Dim counter As Integer
                Dim repeat As Boolean = True

                AreaCommon.log.track("RequestFlowEngine.removeOldRequest", "Begin")

                If (_RequestProcessed.Count > 0) Then
                    Do While repeat
                        repeat = False

                        Try
                            counter = 0

                            Do While (counter < _RequestProcessed.Count)
                                item = _RequestProcessed.Values.ElementAt(counter)

                                If (item.source.acquireTimeStamp + (60000 * 60 * 24) < CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()) Then
                                    _RequestProcessed.Remove(item.dataCommon.hash)
                                    _Requests.Remove(item.dataCommon.hash)
                                End If

                                counter += 1
                            Loop
                        Catch ex As Exception
                            repeat = True
                        End Try
                    Loop
                End If

                AreaCommon.log.track("RequestFlowEngine.removeOldRequest", "Completed")

                Return True
            Catch ex As Exception
                AreaCommon.log.track("RequestFlowEngine.removeOldRequest", ex.Message, "fatal")

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to delete fron DB all request rejected or trashed
        ''' </summary>
        ''' <param name="minimalMaintainRequestBlock"></param>
        ''' <returns></returns>
        Public Function removeOldRequestRejectedAndTrashedIntoDB(ByVal minimalMaintainRequestBlock As Double) As Boolean
            Try
                AreaCommon.log.track("RequestFlowEngine.removeOldRequestRejectedAndTrashedIntoDB", "Begin")

                Return _RequestManager.deleteOldRequestRejectedAndTrashed(minimalMaintainRequestBlock)
            Catch ex As Exception
                AreaCommon.log.track("RequestFlowEngine.removeOldRequestRejectedAndTrashedIntoDB", ex.Message, "fatal")

                Return False
            Finally
                AreaCommon.log.track("RequestFlowEngine.removeOldRequestRejectedAndTrashedIntoDB", "Completed")
            End Try
        End Function

        ''' <summary>
        ''' This method provide to remove old request into db
        ''' </summary>
        ''' <param name="minimalMaintainRequestBlock"></param>
        ''' <returns></returns>
        Public Function removeOldRequestDB(ByVal minimalMaintainRequestBlock As Double) As Boolean
            Try
                AreaCommon.log.track("RequestFlowEngine.removeOldRequestDB", "Begin")

                Return _RequestManager.deleteOldRequest(minimalMaintainRequestBlock)
            Catch ex As Exception
                AreaCommon.log.track("RequestFlowEngine.removeOldRequestDB", ex.Message, "fatal")

                Return False
            Finally
                AreaCommon.log.track("RequestFlowEngine.removeOldRequestDB", "Completed")
            End Try
        End Function

        ''' <summary>
        ''' This method provide to get a old request block
        ''' </summary>
        ''' <param name="minimalMaintainRequestBlock"></param>
        ''' <returns></returns>
        Public Function getBlockList(ByVal minimalMaintainRequestBlock As Double) As List(Of String)
            Try
                AreaCommon.log.track("RequestFlowEngine.getBlockList", "Begin")

                Return _RequestManager.extractOldRequestBlock(minimalMaintainRequestBlock)
            Catch ex As Exception
                AreaCommon.log.track("RequestFlowEngine.getBlockList", ex.Message, "fatal")

                Return New List(Of String)
            Finally
                AreaCommon.log.track("RequestFlowEngine.getBlockList", "Completed")
            End Try
        End Function

        ''' <summary>
        ''' This method provide to extract the file list
        ''' </summary>
        ''' <param name="minimalMaintenanceRejectFile"></param>
        ''' <param name="state"></param>
        ''' <returns></returns>
        Public Function getFileList(ByVal minimalMaintenanceRejectFile As Double, ByVal state As TransactionChainLibrary.AreaEngine.Requests.RequestManager.RequestData.stateRequest) As List(Of String)
            Try
                AreaCommon.log.track("RequestFlowEngine.getFileList", "Begin")

                Return _RequestManager.extractOldRequestRejectOrTrashedFile(minimalMaintenanceRejectFile, state)
            Catch ex As Exception
                AreaCommon.log.track("RequestFlowEngine.getFileList", ex.Message, "fatal")

                Return New List(Of String)
            Finally
                AreaCommon.log.track("RequestFlowEngine.getFileList", "Completed")
            End Try
        End Function

        ''' <summary>
        ''' This method provide to manage a reposition of download
        ''' </summary>
        ''' <param name="requestHash"></param>
        ''' <param name="publicAddress"></param>
        ''' <returns></returns>
        Public Function repositionDownload(ByVal requestHash As String, ByVal publicAddress As String) As Boolean
            Try
                Dim key As New RequestDownloadKey
                Dim request As RequestExtended

                key.requestHash = requestHash
                key.publicAddress = publicAddress

                If _RequestToDownload.ContainsKey(key) Then

                    request = _RequestToDownload(key)

                    If request.source.firstErrorDuringDownload = 0 Then
                        request.source.firstErrorDuringDownload = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime
                    End If

                    If ((CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime - request.source.firstErrorDuringDownload) > 300) Then
                        Return AreaProtocol.A2x1.Manager.createInternalRequest(publicAddress, AreaCommon.state.runTimeState.activeChain.name.value)
                    Else
                        request.source.notifyTimeStamp = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()
                    End If
                End If

                Return True
            Catch ex As Exception
                AreaCommon.log.track("RequestFlowEngine.repositionDownload", ex.Message, "fatal")

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to check if the chain is in idle mode
        ''' </summary>
        ''' <returns></returns>
        Public Function inIdleMode() As Boolean
            Return (_RequestToDownload.Count = 0) And
                   (_RequestToProcess.Count = 0) And
                   (_RequestToSelected.Count = 0) And
                   (_RequestToSend.Count = 0) And
                   (_RequestToVerify.Count = 0)
        End Function

        ''' <summary>
        ''' This method provide to initialize the component
        ''' </summary>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()>
        Public Function init() As Boolean
            Try
                AreaCommon.log.track("RequestFlowEngine.init", "Begin")

                If workerOn Then
                    Return True
                Else
                    workerOn = True
                End If

                Dim work1 As New Threading.Thread(AddressOf AreaWorker.Downloader.work)
                Dim work2 As New Threading.Thread(AddressOf AreaWorker.Requester.work)
                Dim work3 As New Threading.Thread(AddressOf AreaWorker.Processor.work)
                Dim work4 As New Threading.Thread(AddressOf AreaWorker.Verifier.work)
                Dim work5 As New Threading.Thread(AddressOf AreaWorker.Sender.work)
                Dim work6 As New Threading.Thread(AddressOf AreaWorker.RemoteVerifier.work)

                AreaCommon.log.track("RequestFlowEngine.init", "Complete declaration")

                work1.Start()
                work2.Start()
                work3.Start()
                work4.Start()
                work5.Start()
                work6.Start()

                AreaCommon.log.track("RequestFlowEngine.init", "All worker on")

                _RequestManager.logIstance = AreaCommon.log

                _RequestManager.init(AreaCommon.paths.workData.requestData.path)

                AreaCommon.log.track("RequestFlowEngine.init", "Completed")

                Return True
            Catch ex As Exception
                AreaCommon.log.track("RequestFlowEngine.init", ex.Message, "fatal")

                Return False
            End Try
        End Function

    End Class


End Namespace