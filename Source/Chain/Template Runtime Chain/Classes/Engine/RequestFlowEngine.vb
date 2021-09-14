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

        Public Enum EvaluationResponse
            notDeterminate
            approval
            rejected
        End Enum


        Public Class SingleMasternodeInformation

            Public Property publicAddress As String = ""
            Public Property publicIPAddress As String = ""
            Public Property stakingValue As Double = 0

            Public Property assessment As EvaluationResponse = EvaluationResponse.notDeterminate
            Public Property assessmentTimeStamp As Double = 0
            Public Property proposalHash As String = ""

            Public Property tryNumberOfDelivery As Byte = 0
            Public Property tryFirstTimeStamp As Double = 0

            Public Property responseTimeOutExpired As Boolean = False

        End Class

        Public Class MasterNodeListInformation

            Private Property _Items As New Dictionary(Of String, SingleMasternodeInformation)

            Public Property totalValues As Double = 0

            Public Function addNew(ByVal publicAddress As String, ByVal publicIPAddress As String, ByVal stakingValue As Double) As Boolean
                Try
                    Dim item As New SingleMasternodeInformation

                    item.publicAddress = publicAddress
                    item.publicIPAddress = publicIPAddress
                    item.stakingValue = stakingValue

                    _Items.Add(publicAddress, item)

                    totalValues += stakingValue

                    Return True
                Catch ex As Exception
                    Return False
                End Try
            End Function

            Public Function addNew(ByRef nodeData As SingleMasternodeInformation) As Boolean
                If Not _Items.ContainsKey(nodeData.publicAddress) Then
                    _Items.Add(nodeData.publicAddress, nodeData)
                End If

                Return True
            End Function

            Public Function remove(ByVal publicAddress As String) As Boolean
                Try
                    Dim item As SingleMasternodeInformation = _Items(publicAddress)

                    totalValues -= item.stakingValue

                    _Items.Remove(publicAddress)

                    Return True
                Catch ex As Exception
                    Return False
                End Try
            End Function

            Public ReadOnly Property count() As Integer
                Get
                    Return _Items.Count
                End Get
            End Property

            Public Function getItem(ByVal publicAddress As String) As SingleMasternodeInformation
                If _Items.ContainsKey(publicAddress) Then
                    Return _Items.Item(publicAddress)
                Else
                    Return Nothing
                End If
            End Function

        End Class

        Public Class MasternodeConsensusDelivery

            Public Property network As New MasterNodeListInformation
            Public Property approved As New MasterNodeListInformation
            Public Property rejected As New MasterNodeListInformation
            Public Property delivery As New MasterNodeListInformation
            Public Property missing As New MasterNodeListInformation
            Public Property noReply As New MasterNodeListInformation


            Private Function searchAndExtract(ByVal publicAddress As String, ByRef value As MasterNodeListInformation) As SingleMasternodeInformation

                Dim masterNodeData As SingleMasternodeInformation = value.getItem(publicAddress)

                If IsNothing(masterNodeData) Then
                    Return Nothing
                Else
                    If value.remove(publicAddress) Then
                        Return masterNodeData
                    Else
                        Return Nothing
                    End If
                End If
            End Function

            Public Function assessmentReceive(ByVal publicAddress As String, ByVal assessment As EvaluationResponse, ByVal emittedTimeStamp As Double, ByVal proposalHash As String) As Boolean

                Dim masterNodeData As SingleMasternodeInformation = Nothing

                If IsNothing(masterNodeData) Then masterNodeData = searchAndExtract(publicAddress, network)
                If IsNothing(masterNodeData) Then masterNodeData = searchAndExtract(publicAddress, delivery)
                If IsNothing(masterNodeData) Then masterNodeData = searchAndExtract(publicAddress, missing)
                If IsNothing(masterNodeData) Then masterNodeData = searchAndExtract(publicAddress, noReply)

                If Not IsNothing(masterNodeData) Then
                    If (assessment = EvaluationResponse.approval) Then
                        Return approved.addNew(masterNodeData)
                    Else
                        Return rejected.addNew(masterNodeData)
                    End If
                End If

                Return True
            End Function

        End Class


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

        Public Property response As EvaluationResponse = EvaluationResponse.notDeterminate

        Public Property consensus As New MasternodeConsensusDelivery

    End Class

    Public Class RequestToSend

        Public Property requestTimeStamp As Double = 0
        Public Property requestCode As String = ""
        Public Property requestHash As String = ""
        Public Property deliveryList As AreaCommon.Masternode.MasternodeSenders
        Public Property dataRequest As Object

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
        Private _RequestToProcess As New List(Of RequestExtended)

        Private _Requests As New Dictionary(Of String, RequestExtended)

        Private _RequestRejected As New Dictionary(Of String, RequestExtended)

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

        Public Function addNewRequestToSend(ByVal requestCode As String, ByRef requestHash As String, ByRef sender As AreaCommon.Masternode.MasternodeSenders, ByRef dataRequest As Object) As Boolean
            Dim item As New RequestToSend

            item.requestCode = requestCode
            item.requestHash = requestHash
            item.requestTimeStamp = CHCCommonLibrary.AreaEngine.Miscellaneous.timestampFromDateTime()
            item.deliveryList = sender
            item.dataRequest = dataRequest

            _RequestToSend.Add(item)

            Return True
        End Function


        Public Function setRequestToProcess(ByRef item As RequestExtended) As Boolean
            Try
                AreaCommon.log.track("RequestFlowEngine.setRequestToProcess", "Begin")

                _RequestToVerify.Remove(item)
                _RequestToProcess.Add(item)

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

        Public Function setRequestRejected(ByRef item As RequestExtended) As Boolean
            Try
                AreaCommon.log.track("RequestFlowEngine.setRequestRejected", "Begin")

                item.generalStatus = RequestExtended.EnumOperationPosition.completeWithNegativeResult

                _RequestToSelected.Remove(item)
                _RequestRejected.Add(item.requestHash, item)

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

        Public Function getFirstRequestToProcess() As RequestExtended
            Try
                Dim result As New RequestExtended

                AreaCommon.log.track("RequestFlowEngine.getFirstRequestToProcess", "Begin")

                For Each item In _RequestToProcess
                    If (result.requestHash.Length = 0) Or (result.dateSelected <= item.dateSelected) Then
                        result = item
                    End If
                Next

                If (result.requestHash.Length > 0) Then
                    _RequestToProcess.Remove(result)
                End If

                AreaCommon.log.track("RequestFlowEngine.getFirstRequestToProcess", "Complete")

                Return result
            Catch ex As Exception
                AreaCommon.log.track("RequestFlowEngine.getFirstRequestToProcess", "Error:" & ex.Message, "error")

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
                    ElseIf (result.requestTimeStamp <= item.requestTimeStamp) Then
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


        Public Function removeRequest(ByRef value As RequestExtended) As Boolean
            Try
                _RequestToProcess.Remove(value)
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


        Public Function refreshRejectedRequest() As Boolean
            Try
                Dim item As RequestExtended
                Dim counter As Integer = 0

                AreaCommon.log.track("RequestFlowEngine.refreshRejectedRequest", "Begin")

                If (_RequestRejected.Count > 0) Then
                    item = _RequestRejected(counter)

                    Do While (counter <= _RequestRejected.Count)
                        If (item.dateRequest + (60000 * 60 * 24) > CHCCommonLibrary.AreaEngine.Miscellaneous.timestampFromDateTime()) Then
                            _RequestRejected.Remove(item.requestHash)
                        End If

                        counter += 1
                    Loop
                End If

                AreaCommon.log.track("RequestFlowEngine.refreshRejectedRequest", "Complete")

                Return True
            Catch ex As Exception
                AreaCommon.log.track("RequestFlowEngine.refreshRejectedRequest", "Error:" & ex.Message, "error")

                Return True
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

                work1.Start()
                work2.Start()
                work3.Start()
                work4.Start()
                work5.Start()

                AreaCommon.log.track("RequestFlowEngine.init", "Complete")

                Return True
            Catch ex As Exception
                AreaCommon.log.track("RequestFlowEngine.init", "Error:" & ex.Message, "error")

                Return False
            End Try
        End Function

    End Class


End Namespace