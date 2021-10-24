Option Compare Text
Option Explicit On





Namespace AreaFlow


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

        Public Enum EnumPhases
            toSelect
            toVerify
        End Enum

        Public Property workerOn As Boolean = False


        ''' <summary>
        ''' This method provide to get a first request of a list
        ''' </summary>
        ''' <param name="phase"></param>
        ''' <returns></returns>
        Private Function getFirstRequest(ByVal phase As EnumPhases) As RequestExtended
            Try
                Dim result As New RequestExtended
                Dim listRequest As List(Of RequestExtended)

                AreaCommon.log.track("RequestFlowEngine.getFirstRequest", "Begin")

                Select Case phase
                    Case EnumPhases.toSelect : listRequest = _RequestToSelected
                    Case EnumPhases.toVerify : listRequest = _RequestToVerify
                End Select

                For Each item In listRequest
                    If (result.dataCommon.hash.Length = 0) Or (result.source.ticketNumber <= item.source.ticketNumber) Then
                        result = item
                    End If
                Next

                AreaCommon.log.track("RequestFlowEngine.getFirstRequest", "Complete")

                Return result
            Catch ex As Exception
                AreaCommon.log.track("RequestFlowEngine.getFirstRequest", ex.Message, "fatal")

                Return New RequestExtended
            End Try
        End Function

        ''' <summary>
        ''' This method provide to rebuild the final command list
        ''' </summary>
        Private Sub rebuildFinalCommandList()
            With AreaCommon.state.currentService
                .listAvailableCommand.Clear()

                .listAvailableCommand.Add(CHCProtocolLibrary.AreaCommon.Models.Administration.EnumActionAdministration.requestNetworkDisconnect)
            End With
        End Sub


        ''' <summary>
        ''' This method provide to add a new direct request
        ''' </summary>
        ''' <param name="requestHash"></param>
        ''' <param name="requestCode"></param>
        ''' <param name="dateRequest"></param>
        ''' <param name="ticketNumber"></param>
        ''' <returns></returns>
        Public Function addNewRequestDirect(ByRef request As Object, Optional ByVal ticketNumber As String = "") As Boolean
            Try
                Dim value As New RequestExtended

                AreaCommon.log.track("RequestFlowEngine.addNewRequestDirect", "Begin")

                If Not _Requests.ContainsKey(request.common.hash) Then
                    value.addDataObject(request)
                    value.source.acquireTimeStamp = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()
                    value.source.directRequest = True

                    If (value.source.ticketNumber.Length > 0) Then
                        _TicketNumberValue = value.source.ticketNumber
                    Else
                        _TicketNumberValue += 1

                        value.source.ticketNumber = _TicketNumberValue
                    End If

                    _Requests.Add(request.common.hash, value)
                    _RequestToSelected.Add(value)
                End If

                AreaCommon.log.track("RequestFlowEngine.addNewRequestDirect", "Complete")

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
        ''' <param name="requestCode"></param>
        ''' <param name="dateRequest"></param>
        ''' <param name="externalSource"></param>
        ''' <returns></returns>
        Public Function addNewRequestNotify(ByVal requestHash As String, ByVal requestCode As String, ByVal dateRequest As Double, ByVal externalSource As String) As Boolean
            Try
                Dim value As New RequestExtended

                AreaCommon.log.track("RequestFlowEngine.addNewRequestNotify", "Begin")

                If Not _Requests.ContainsKey(value.dataCommon.hash) Then
                    _TicketNumberValue += 1

                    value.dataCommon.hash = requestHash
                    value.dataCommon.requestCode = requestCode
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
                AreaCommon.log.track("RequestFlowEngine.addNewRequestNotify", "Complete")
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

                AreaCommon.log.track("RequestFlowEngine.addNewRequestToDownload", "Complete")

                Return False
            Catch ex As Exception
                AreaCommon.log.track("RequestFlowEngine.addNewRequestToDownload", ex.Message, "fatal")

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to add a new request to send
        ''' </summary>
        ''' <param name="requestCode"></param>
        ''' <param name="requestHash"></param>
        ''' <param name="sender"></param>
        ''' <param name="dataRequest"></param>
        ''' <param name="times"></param>
        ''' <returns></returns>
        Public Function addNewRequestToSend(ByVal requestCode As String, ByRef requestHash As String, ByRef sender As AreaCommon.Masternode.MasternodeSenders, ByRef dataRequest As Object, Optional ByVal times As Byte = 0) As Boolean
            Try
                AreaCommon.log.track("RequestFlowEngine.addNewRequestToSend", "Begin")

                Dim item As New RequestToSend

                item.requestCode = requestCode
                item.requestHash = requestHash
                item.addTimeStamp = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()
                item.deliveryList = sender
                item.dataObject = dataRequest
                item.tryNumber = times

                _RequestToSend.Add(item)

                AreaCommon.log.track("RequestFlowEngine.addNewRequestToSend", "Complete")

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

                AreaCommon.log.track("RequestFlowEngine.addNewBulletinToSend", "Complete")

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

                AreaCommon.log.track("RequestFlowEngine.addNewRequestToExpression", "Complete")

                Return True
            Catch ex As Exception
                AreaCommon.log.track("RequestFlowEngine.addNewRequestToExpression", ex.Message, "fatal")

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to add new request remote bullettin
        ''' </summary>
        ''' <param name="value"></param>
        ''' <returns></returns>
        Public Function addNewRequestRemoteBulletin(ByVal value As AreaConsensus.BulletinInformation) As Boolean
            Try
                AreaCommon.log.track("RequestFlowEngine.addNewRequestRemoteBulletin", "Begin")

                _RemoteBulletin.Add(value)

                AreaCommon.log.track("RequestFlowEngine.addNewRequestRemoteBulletin", "Complete")

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

                AreaCommon.log.track("RequestFlowEngine.setRequestToProcess", "Complete")

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
                AreaCommon.log.track("RequestFlowEngine.setRequestToSelect", "Begin")

                AreaCommon.flow.removeFirstRequestToDownload(item.dataCommon.hash, item.source.notifiedPublicAddress)
                _RequestToSelected.Add(item)

                AreaCommon.log.track("RequestFlowEngine.setRequestToSelect", "Complete")

                Return True
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

                AreaCommon.log.track("RequestFlowEngine.setRequestToSelect", "Complete")

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
        Public Function setRequestProcessed(ByRef item As RequestExtended) As Boolean
            Try
                AreaCommon.log.track("RequestFlowEngine.setRequestRejected", "Begin")

                _RequestToSelected.Remove(item)
                _RequestProcessed.Add(item.dataCommon.hash, item)

                AreaCommon.log.track("RequestFlowEngine.setRequestRejected", "Complete")

                Return True
            Catch ex As Exception
                AreaCommon.log.track("RequestFlowEngine.setRequestRejected", ex.Message, "fatal")

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

                For Each item In AreaCommon.state.runtimeState.getNodeListAbleToConsensus()
                    result.addNew(item.identityPublicAddress, item.ipAddress, item.votePoint)
                Next

                AreaCommon.log.track("RequestFlowEngine.createConsensusList", "Complete")

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

                AreaCommon.log.track("RequestFlowEngine.getFirstRequestToDownload", "Begin")

                For Each item In _RequestToDownload.Values
                    If (result.dataCommon.hash.Length = 0) Then
                        result = item
                    ElseIf (result.source.notifyTimeStamp <= item.source.notifyTimeStamp) Then
                        result = item
                    End If
                Next

                AreaCommon.log.track("RequestFlowEngine.getFirstRequestToDownload", "Complete")

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
                AreaCommon.log.track("RequestFlowEngine.getFirstRequestToSend", ex.Message, "fatal")

                Return New RequestToSend
            End Try
        End Function

        ''' <summary>
        ''' This method provide to get a request
        ''' </summary>
        ''' <param name="requestHash"></param>
        ''' <returns></returns>
        Public Function getRequest(ByVal requestHash As String) As RequestExtended
            Try
                AreaCommon.log.track("RequestFlowEngine.getRequest", "Begin")

                If _Requests.ContainsKey(requestHash) Then
                    Return _Requests(requestHash)
                End If

                AreaCommon.log.track("RequestFlowEngine.getRequest", "Complete")
            Catch ex As Exception
                AreaCommon.log.track("RequestFlowEngine.getRequest", ex.Message, "fatal")
            End Try

            Return New RequestExtended
        End Function

        ''' <summary>
        ''' This method provide to get all list to process
        ''' </summary>
        ''' <returns></returns>
        Public Function getAllListToProcess() As Dictionary(Of String, RequestExtended)
            Return _RequestToProcess
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

                AreaCommon.log.track("RequestFlowEngine.getApprovedTimeStamp", "Complete")

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

                AreaCommon.log.track("RequestFlowEngine.getFirstRemoteBulletin", "Complete")
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

                AreaCommon.log.track("RequestFlowEngine.checkRemoteBulletinFromNode", "Complete")

                Return False
            Catch ex As Exception
                AreaCommon.log.track("RequestFlowEngine.checkRemoteBulletinFromNode", ex.Message, "fatal")

                Return False
            End Try
        End Function


        Public Function getRequestToProcess(ByVal requestHash As String) As RequestExtended
            If _RequestToProcess.ContainsKey(requestHash) Then
                Return _RequestToProcess(requestHash)
            End If

            Return New RequestExtended
        End Function

        Public Function removeRequest(ByRef value As RequestExtended) As Boolean
            Try
                _RequestToProcess.Remove(value.dataCommon.hash)
                _Requests.Remove(value.dataCommon.hash)

                Return True
            Catch ex As Exception
                AreaCommon.log.track("RequestFlowEngine.removeRequest", ex.Message, "fatal")

                Return False
            End Try
        End Function

        Public Function removeRequestToSend(ByRef value As RequestToSend) As Boolean
            Try
                _RequestToSend.Remove(value)

                Return True
            Catch ex As Exception
                AreaCommon.log.track("RequestFlowEngine.removeItem", ex.Message, "fatal")

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

        ''' <summary>
        ''' This method provide to remove old request
        ''' </summary>
        ''' <returns></returns>
        Public Function removeOldRequest() As Boolean
            Try
                Dim item As RequestExtended
                Dim counter As Integer = 0

                AreaCommon.log.track("RequestFlowEngine.refreshOldRequest", "Begin")

                If (_RequestProcessed.Count > 0) Then
                    item = _RequestProcessed(counter)

                    Do While (counter <= _RequestProcessed.Count)
                        If (item.source.acquireTimeStamp + (60000 * 60 * 24) > CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()) Then
                            _RequestProcessed.Remove(item.dataCommon.hash)
                        End If

                        counter += 1
                    Loop
                End If

                AreaCommon.log.track("RequestFlowEngine.refreshOldRequest", "Complete")

                Return True
            Catch ex As Exception
                AreaCommon.log.track("RequestFlowEngine.refreshOldRequest", ex.Message, "fatal")

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to execute the action after assessment 
        ''' </summary>
        ''' <returns></returns>
        Public Function actionAfterAssessment() As Boolean
            Try
                AreaCommon.log.track("RequestFlowEngine.actionAfterAssessment", "Begin")

                If (AreaCommon.state.network.position = CHCRuntimeChainLibrary.AreaRuntime.AppState.EnumConnectionState.genesisOperation) Then
                    If (AreaCommon.state.runtimeState.activeNetwork.networkName.value.Length > 0) Then
                        AreaCommon.state.network.position = CHCRuntimeChainLibrary.AreaRuntime.AppState.EnumConnectionState.onLine

                        rebuildFinalCommandList()

                        If AreaCommon.webServiceThread() Then
                            AreaCommon.log.trackIntoConsole("Public port (" & AreaCommon.settings.data.publicPort & ") chain is listen")
                        Else
                            AreaCommon.log.trackIntoConsole("Problem during start public service")
                        End If
                    End If
                End If

                AreaCommon.log.track("RequestFlowEngine.actionAfterAssessment", "Complete")

                Return True
            Catch ex As Exception
                AreaCommon.log.track("RequestFlowEngine.actionAfterAssessment", ex.Message, "fatal")

                Return False
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
                Dim key As New AreaFlow.RequestDownloadKey
                Dim request As AreaFlow.RequestExtended

                key.requestHash = requestHash
                key.publicAddress = publicAddress

                If _RequestToDownload.ContainsKey(key) Then

                    request = _RequestToDownload(key)

                    If request.source.firstErrorDuringDownload = 0 Then
                        request.source.firstErrorDuringDownload = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime
                    End If

                    If ((CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime - request.source.firstErrorDuringDownload) > 300) Then
                        Return AreaProtocol.A2x1.Manager.createRequest(publicAddress)
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


        Public Function manageCloseBlock() As Boolean
            Try
                Return True
            Catch ex As Exception
                AreaCommon.log.track("RequestFlowEngine.checkCloseBlock", ex.Message, "fatal")

                Return False
            End Try
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

                work1.Start()
                work2.Start()
                work3.Start()
                work4.Start()
                work5.Start()
                work6.Start()

                AreaCommon.log.track("RequestFlowEngine.init", "Complete")

                Return True
            Catch ex As Exception
                AreaCommon.log.track("RequestFlowEngine.init", ex.Message, "fatal")

                Return False
            End Try
        End Function

    End Class


End Namespace