Option Compare Text
Option Explicit On






Namespace AreaCommon.Masternode

    ''' <summary>
    ''' This enumerate contain the evaluation response
    ''' </summary>
    Public Enum EvaluationResponse
        notDeterminate
        approval
        rejected
        abstained
    End Enum

    ''' <summary>
    ''' This class is used to track a senders (broadcast) of a request
    ''' </summary>
    Public Class MasternodeSenders

        Public Class MasternodeSender

            Public publicAddress As String = ""
            Public publicAddressIP As String = ""

            Public deliveryTimeStamp As Double = 0
            Public lastTry As Double = 0
            Public tryNumber As Byte = 0

        End Class

        Public Property _Masternodes As New List(Of MasternodeSender)


        Public Shared Function createMasterNodeList() As MasternodeSenders
            Try
                Dim result As New MasternodeSenders
                Dim singleItem As MasternodeSender

                For Each item In state.runtimeState.activeMasterNode
                    singleItem = New MasternodeSender

                    singleItem.publicAddress = item.Value.identityPublicAddress
                    singleItem.publicAddressIP = item.Value.ipAddress

                    result.Add(singleItem)
                Next

                Return result
            Catch ex As Exception
                log.track("MasternodeSenders.createMasterNodeList", ex.Message, "fatal")

                Return New MasternodeSenders
            End Try
        End Function


        Public Function add(ByRef value As MasternodeSender) As Boolean
            Try
                _Masternodes.Add(value)

                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public ReadOnly Property count() As Integer
            Get
                Return _Masternodes.Count
            End Get
        End Property

        Public ReadOnly Property getFirst() As MasternodeSender
            Get
                If (_Masternodes.Count > 0) Then
                    Return _Masternodes(0)
                Else
                    Return Nothing
                End If
            End Get
        End Property

        Public Function removeFirst() As Boolean
            Try
                If (_Masternodes.Count > 0) Then
                    _Masternodes.RemoveAt(0)
                End If

                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

    End Class

    ''' <summary>
    ''' This class is used to collect e manage an information relative an assessment vote of a masternode
    ''' </summary>
    Public Class MinimalDataMasternodeList

        Public Class MinimalDataMasternode

            Public Property publicAddress As String = ""
            Public Property publicIPAddress As String = ""
            Public Property votePoint As Double = 0

            Public Property assessmentTimeStamp As Double = 0

        End Class

        Private Property _Items As New Dictionary(Of String, MinimalDataMasternode)

        Public Property totalValuePoints As Double = 0

        Public Function addNew(ByVal node As ContactDataMasternodeList.ContactDataMasternode, ByVal assessmentTimeStamp As Double) As Boolean
            Try
                Dim item As New MinimalDataMasternode

                item.publicAddress = node.publicAddress
                item.publicIPAddress = node.publicIPAddress
                item.votePoint = node.votePoint

                item.assessmentTimeStamp = assessmentTimeStamp

                If _Items.ContainsKey(node.publicAddress) Then
                    Return True
                End If
                _Items.Add(node.publicAddress, item)

                totalValuePoints += node.votePoint

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

        Public Function getItem(ByVal publicAddress As String) As MinimalDataMasternode
            If _Items.ContainsKey(publicAddress) Then
                Return _Items.Item(publicAddress)
            Else
                Return Nothing
            End If
        End Function

        Public Function getItem(ByVal index As Integer) As MinimalDataMasternode
            If (index <= _Items.Count) Then
                Return _Items.ElementAt(index).Value
            Else
                Return New MinimalDataMasternode
            End If
        End Function

    End Class

    ''' <summary>
    ''' This class is used to collect e manage an information of a list of a node without a response
    ''' </summary>
    Public Class ContactDataMasternodeList

        Public Class ContactDataMasternode

            Inherits MinimalDataMasternodeList.MinimalDataMasternode

            Public Property tryNumberOfRequest As Byte = 0
            Public Property tryFirstTimeStamp As Double = 0

        End Class

        Private Property _Items As New Dictionary(Of String, ContactDataMasternode)

        Public Property totalValuePoints As Double = 0

        Public Function addNew(ByVal publicAddress As String, ByVal publicIPAddress As String, ByVal votePoint As Double) As Boolean
            Try
                Dim item As New ContactDataMasternode

                item.publicAddress = publicAddress
                item.publicIPAddress = publicIPAddress
                item.votePoint = votePoint

                If _Items.ContainsKey(publicAddress) Then
                    _Items.Remove(publicAddress)
                End If
                _Items.Add(publicAddress, item)

                totalValuePoints += votePoint

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

        Public Function getItem(ByVal publicAddress As String) As ContactDataMasternode
            If _Items.ContainsKey(publicAddress) Then
                Return _Items.Item(publicAddress)
            Else
                Return Nothing
            End If
        End Function

        Public Function containKey(ByVal publicAddress As String) As Boolean
            Return _Items.ContainsKey(publicAddress)
        End Function

    End Class

    ''' <summary>
    ''' This class contains the expression to vote
    ''' </summary>
    Public Class MasternodeEvaluations

        Public Class FirstAssessment

            Public Property requestHash As String = ""
            Public Property publicAddressMasternode As String = ""
            Public Property dateFirstAssessment As Double = 0

        End Class

        Public Property notExpressed As ContactDataMasternodeList
        Public Property approved As New MinimalDataMasternodeList
        Public Property rejected As New MinimalDataMasternodeList
        Public Property abstained As New MinimalDataMasternodeList
        Public Property absents As New MinimalDataMasternodeList

        Public Property currentChainNodeTotalVotes As Double = 0

        Public Property firstAssessmentTimeStamp As Double = 0

        Private Function setResult(ByVal publicAddress As String, Optional ByVal approvedTime As Double = 0, Optional ByVal operation As EvaluationResponse = EvaluationResponse.notDeterminate) As Boolean
            If approvedTime = 0 Then
                approvedTime = CHCCommonLibrary.AreaEngine.Miscellaneous.timestampFromDateTime()
            End If

            If (firstAssessmentTimeStamp = 0) Or (firstAssessmentTimeStamp > approvedTime) Then
                firstAssessmentTimeStamp = approvedTime
            End If
            If Not notExpressed.containKey(publicAddress) Then
                Return True
            Else
                Select Case operation
                    Case EvaluationResponse.approval : Return approved.addNew(notExpressed.getItem(publicAddress), approvedTime)
                    Case EvaluationResponse.rejected : Return rejected.addNew(notExpressed.getItem(publicAddress), approvedTime)
                    Case EvaluationResponse.abstained : Return abstained.addNew(notExpressed.getItem(publicAddress), approvedTime)
                    Case Else : Return absents.addNew(notExpressed.getItem(publicAddress), approvedTime)
                End Select
            End If
        End Function

        Public Function setApproved(ByVal publicAddress As String, Optional ByVal approvedTime As Double = 0) As Boolean
            Return setResult(publicAddress, approvedTime, EvaluationResponse.approval)
        End Function

        Public Function setRejected(ByVal publicAddress As String, Optional ByVal approvedTime As Double = 0) As Boolean
            Return setResult(publicAddress, approvedTime, EvaluationResponse.rejected)
        End Function

        Public Function setAbstained(ByVal publicAddress As String, Optional ByVal approvedTime As Double = 0) As Boolean
            Return setResult(publicAddress, approvedTime, EvaluationResponse.abstained)
        End Function

        Public Function setAbsent(ByVal publicAddress As String, Optional ByVal approvedTime As Double = 0) As Boolean
            Return setResult(publicAddress, approvedTime, EvaluationResponse.notDeterminate)
        End Function

        Public Function getFirstAssessment(ByVal onlyApproved As Boolean) As FirstAssessment
            Try
                Dim result As New FirstAssessment

                For i As Integer = 1 To approved.count
                    With approved.getItem(i)
                        If (result.dateFirstAssessment = 0) Or (result.dateFirstAssessment < .assessmentTimeStamp) Then
                            result.dateFirstAssessment = .assessmentTimeStamp
                            result.publicAddressMasternode = .publicAddress
                        End If
                    End With
                Next

                If Not onlyApproved Then
                    For i As Integer = 1 To rejected.count
                        With rejected.getItem(i)
                            If (result.dateFirstAssessment = 0) Or (result.dateFirstAssessment < .assessmentTimeStamp) Then
                                result.dateFirstAssessment = .assessmentTimeStamp
                                result.publicAddressMasternode = .publicAddress
                            End If
                        End With
                    Next
                End If

                Return result
            Catch ex As Exception
                AreaCommon.log.track("MasternodeEvaluations.getFirstAssessment", ex.Message, "fatal")

                Return New FirstAssessment
            End Try
        End Function

    End Class

    ''' <summary>
    ''' This class manage a delivery of a message rejected
    ''' </summary>
    Public Class MasternodeNotifyRejectedList

        Public Property notDelivery As ContactDataMasternodeList
        Public Property delivery As New MinimalDataMasternodeList

    End Class

End Namespace