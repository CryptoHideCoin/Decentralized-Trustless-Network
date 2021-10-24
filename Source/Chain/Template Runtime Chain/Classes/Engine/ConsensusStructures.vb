Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.Encryption






Namespace AreaConsensus


    ''' <summary>
    ''' This enumeration contain all type of model
    ''' </summary>
    Public Enum EnumModel
        approved
        reject
        absteined
        absent
    End Enum

    ''' <summary>
    ''' This class contain a simply release of ReceiptOfAssessment structure
    ''' </summary>
    Public Class ReceiptOfAssessmentBase

        Public Property model As EnumModel = EnumModel.absent
        Public Property assessmentTimeStamp As Double = 0
        Public Property publicAddress As String = ""

        ''' <summary>
        ''' This method provide to create a string of all element of this object
        ''' </summary>
        ''' <returns></returns>
        Public Overridable Function toString() As String
            Dim result As String = ""

            result += Byte.Parse(model).ToString()
            result += assessmentTimeStamp.ToString()
            result += publicAddress

            Return result
        End Function

        ''' <summary>
        ''' This method provide to get a hash of a data contained
        ''' </summary>
        ''' <returns></returns>
        Public Overridable Function getHash() As String
            Return HashSHA.generateSHA256(Me.toString())
        End Function

        Public Property hash As String = ""
        Public Property signature As String = ""

    End Class

    ''' <summary>
    ''' This class contain all element of Accept or Abstein of a consensus 
    ''' </summary>
    Public Class ReceiptOfConsensusAssessment

        Public Property model As EnumModel = EnumModel.absent
        Public Property requestHash As String = ""
        Public Property approvedTimeStamp As Double = 0

        ''' <summary>
        ''' This method provide to create a string of all element of this object
        ''' </summary>
        ''' <returns></returns>
        Public Overridable Function toString() As String
            Dim result As String = ""

            result += AreaCommon.state.network.publicAddressIdentity
            result += Byte.Parse(model).ToString()
            result += requestHash
            result += approvedTimeStamp.ToString()

            Return result
        End Function

        ''' <summary>
        ''' This method provide to get a hash of a data contained
        ''' </summary>
        ''' <returns></returns>
        Public Overridable Function getHash() As String
            Return HashSHA.generateSHA256(Me.toString())
        End Function

        ''' <summary>
        ''' This method provide to clone this object
        ''' </summary>
        ''' <returns></returns>
        Public Function clone() As ReceiptOfConsensusAssessment
            Return Me.MemberwiseClone()
        End Function

        Public Property hash As String = ""
        Public Property signature As String = ""

    End Class

    ''' <summary>
    ''' This class contain the rejected request base
    ''' </summary>
    Public Class RejectedRequestBase

        Inherits ReceiptOfAssessmentBase

        Public Property rejectedMessage As String = ""

    End Class

    ''' <summary>
    ''' This class contain all information necessary to receipt of approval
    ''' </summary>
    Public Class ReceiptOfAssessment

        Inherits ReceiptOfConsensusAssessment

        Public Property requestHash As String = ""

        ''' <summary>
        ''' This method provide to create a string the element of this class
        ''' </summary>
        ''' <returns></returns>
        Public Overrides Function toString() As String
            Dim tmp As String = ""

            tmp += requestHash
            tmp += MyBase.ToString()

            Return tmp
        End Function

        ''' <summary>
        ''' This method provide to get a hash of a data contained
        ''' </summary>
        ''' <returns></returns>
        Public Function getHash() As String
            Return HashSHA.generateSHA256(Me.toString())
        End Function

        ''' <summary>
        ''' This method provide to clone this object
        ''' </summary>
        ''' <returns></returns>
        Public Overloads Function clone() As ReceiptOfAssessment
            Return Me.MemberwiseClone()
        End Function

    End Class

    ''' <summary>
    ''' This class contain all information to reject a request
    ''' </summary>
    Public Class RejectedRequest

        Inherits ReceiptOfConsensusAssessment

        Public Property rejectedMessage As String = ""

        ''' <summary>
        ''' This method provide to create a string the element of this class
        ''' </summary>
        ''' <returns></returns>
        Public Overrides Function toString() As String
            Dim tmp As String = ""

            tmp += MyBase.toString()
            tmp += rejectedMessage

            Return tmp
        End Function

        ''' <summary>
        ''' This method provide to get a hash of a data contained
        ''' </summary>
        ''' <returns></returns>
        Public Overloads Function getHash() As String
            Return HashSHA.generateSHA256(Me.toString())
        End Function

        ''' <summary>
        ''' This method provide to clone a Rejected Request
        ''' </summary>
        ''' <returns></returns>
        Public Overloads Function clone() As RejectedRequest
            Try
                Dim result As New RejectedRequest

                result = MyBase.clone()
                result.rejectedMessage = rejectedMessage

                Return result
            Catch ex As Exception
                Return New RejectedRequest
            End Try
        End Function

    End Class

    ''' <summary>
    ''' This class contain the minimal information of absent of masternode
    ''' </summary>
    Public Class MasterNodeAbsent

        Public Property publicAddress As String = ""
        Public Property registerTimeStamp As Double = 0

        Public Property hash As String = ""
        Public Property signature As String = ""

    End Class

    ''' <summary>
    ''' This class contain all information of a communication of masternode
    ''' </summary>
    Public Class MasterNodeCommunication

        Public Property bulletinTimeStamp As String = ""
        Public Property publicAddress As String = ""
        Public Property requestHash As String = ""
        Public Property tryNumber As Byte
        Public Property startNotResponse As Double = 0
        Public Property lastNotResponse As Double = 0

        Public Property hash As String = ""
        Public Property signature As String = ""

        ''' <summary>
        ''' This method provide to create a string resultant a contain of a object
        ''' </summary>
        ''' <returns></returns>
        Public Overrides Function toString() As String
            Dim tmp As String = ""

            tmp += bulletinTimeStamp.ToString()
            tmp += publicAddress
            tmp += requestHash
            tmp += tryNumber.ToString()
            tmp += startNotResponse.ToString()
            tmp += lastNotResponse.ToString()

            Return tmp
        End Function

        ''' <summary>
        ''' This method provide to create an hash of a string resultant
        ''' </summary>
        ''' <returns></returns>
        Public Function getHash() As String
            Return HashSHA.generateSHA256(Me.toString())
        End Function

        ''' <summary>
        ''' This method provide to create a clone object
        ''' </summary>
        ''' <returns></returns>
        Public Function clone() As MasterNodeCommunication
            Dim result As New MasterNodeCommunication

            result.bulletinTimeStamp = bulletinTimeStamp
            result.publicAddress = publicAddress
            result.requestHash = requestHash
            result.tryNumber = tryNumber
            result.startNotResponse = startNotResponse
            result.lastNotResponse = lastNotResponse
            result.hash = hash
            result.signature = signature

            Return result
        End Function

    End Class

    ''' <summary>
    ''' This class contain the element reguard the minimal information to identificate the network
    ''' </summary>
    Public Class NetSynchronization

        Public Property hashNetwork As String = ""
        Public Property hashChain As String = ""
        Public Property lastApprovedTransaction As New CHCCommonLibrary.AreaCommon.Models.General.IdentifyLastTransaction

        ''' <summary>
        ''' This method provide to return a cumulative information of a important member of this class
        ''' </summary>
        ''' <returns></returns>
        Public Overrides Function toString() As String
            Dim result As String = ""

            result += hashNetwork
            result += hashChain
            result += lastApprovedTransaction.toString()

            Return result
        End Function

    End Class

    ''' <summary>
    ''' This class contain the header of a bulletin
    ''' </summary>
    Public Class HeaderBulletin

        Public Property bulletinTimeStamp As Double = 0
        Public Property publicAddress As String = ""
        Public Property netSynchronizationData As New NetSynchronization

        ''' <summary>
        ''' This method provide to return a string relative all data of a object
        ''' </summary>
        ''' <returns></returns>
        Public Overrides Function toString() As String
            Dim tmp As String = ""

            tmp += bulletinTimeStamp.ToString()
            tmp += publicAddress
            tmp += netSynchronizationData.toString()

            Return tmp
        End Function

        ''' <summary>
        ''' This method provide to clone a value of this object
        ''' </summary>
        ''' <returns></returns>
        Public Function clone() As HeaderBulletin
            Dim result As New HeaderBulletin

            With result
                .bulletinTimeStamp = bulletinTimeStamp
                .publicAddress = publicAddress

                With .netSynchronizationData
                    .hashChain = netSynchronizationData.hashChain
                    .hashNetwork = netSynchronizationData.hashNetwork
                    .lastApprovedTransaction = netSynchronizationData.lastApprovedTransaction
                End With
            End With

            Return result
        End Function

    End Class

    ''' <summary>
    ''' This class contain the convergence of a new 
    ''' </summary>
    Public Class UpdateNewTransactionHashInformation

        Public Property requestHash As String = ""
        Public Property transactionHash As String = ""

        Public Property remainNodeList As New List(Of String)

        ''' <summary>
        ''' This method provide to clone this object
        ''' </summary>
        ''' <returns></returns>
        Public Function clone() As UpdateNewTransactionHashInformation
            Dim result As New UpdateNewTransactionHashInformation

            result.requestHash = requestHash
            result.transactionHash = transactionHash

            For Each item In remainNodeList
                result.remainNodeList.Add(item)
            Next

            Return result
        End Function

    End Class

    ''' <summary>
    ''' This class contain all information reguard the propose for approval
    ''' </summary>
    Public Class ProposalForApproval

        ''' <summary>
        ''' This class provide to collect all single total of expression of vote
        ''' </summary>
        Public Class VoteTotalizations

            Public Property netWorkTotalVote As Double = 0

            Public Property notExpressed As Double = 0
            Public Property approved As Double = 0
            Public Property rejected As Double = 0
            Public Property abstained As Double = 0

            ''' <summary>
            ''' This property return a total of votes
            ''' </summary>
            ''' <returns></returns>
            Public ReadOnly Property total As Double
                Get
                    Return (notExpressed + approved + rejected + abstained)
                End Get
            End Property

            ''' <summary>
            ''' This method provide to create a string resultant a votes into data class
            ''' </summary>
            ''' <returns></returns>
            Public Overrides Function toString() As String
                Return (netWorkTotalVote + total).ToString()
            End Function

            ''' <summary>
            ''' This method provide to clone an object
            ''' </summary>
            ''' <returns></returns>
            Public Function clone() As VoteTotalizations
                Dim result As New VoteTotalizations

                result.netWorkTotalVote = netWorkTotalVote
                result.notExpressed = notExpressed
                result.approved = approved
                result.rejected = rejected
                result.abstained = abstained

                Return result
            End Function

        End Class

        Public Property proposalIdentifierTransactionLedger As String = ""

        Public Property requestHash As String = ""
        Public Property registerBulletinAssessmentTimeStamp As Double = 0
        Public Property registerMasternodeAddress As String = ""
        Public Property consensusHash As String = ""
        Public Property deliveryToAllNetwork As Boolean = False
        Public Property totalVotes As New VoteTotalizations

        ''' <summary>
        ''' This method provide to create a string resultant of a Proposal for Approval
        ''' </summary>
        ''' <returns></returns>
        Public Overrides Function toString() As String
            Dim tmp As String = ""

            tmp += proposalIdentifierTransactionLedger
            tmp += requestHash
            tmp += registerBulletinAssessmentTimeStamp.ToString
            tmp += registerMasternodeAddress
            tmp += totalVotes.toString()

            Return tmp
        End Function

        ''' <summary>
        ''' This method provide to return an hash of data
        ''' </summary>
        ''' <returns></returns>
        Public Function getHash() As String
            Return HashSHA.generateSHA256(Me.toString())
        End Function

        ''' <summary>
        ''' This method provide to clone all element of this object
        ''' </summary>
        ''' <returns></returns>
        Public Function clone() As ProposalForApproval
            Dim result As New ProposalForApproval

            result.proposalIdentifierTransactionLedger = proposalIdentifierTransactionLedger
            result.requestHash = requestHash
            result.registerBulletinAssessmentTimeStamp = registerBulletinAssessmentTimeStamp
            result.registerMasternodeAddress = registerMasternodeAddress
            result.consensusHash = consensusHash
            result.deliveryToAllNetwork = deliveryToAllNetwork

            result.totalVotes = totalVotes.clone()

            Return result
        End Function

        Public Property hash As String = ""
        Public Property signature As String = ""

    End Class

    ''' <summary>
    ''' This class contain all information reguard a bulletin communition
    ''' </summary>
    Public Class BulletinInformation

        Private Property _KeyAcceptOrAbstainRequestList As New Dictionary(Of String, ReceiptOfConsensusAssessment)
        Private Property _KeyRejectedList As New Dictionary(Of String, RejectedRequest)

        Public Property header As New HeaderBulletin

        Public Property proposalUpdateNewTransactionHash As New UpdateNewTransactionHashInformation
        Public Property proposalsForApprovalData As New ProposalForApproval

        Public Property rejectedRequestData As New List(Of RejectedRequest)
        Public Property acceptOrAbstainRequestList As New List(Of ReceiptOfConsensusAssessment)
        Public Property masternodeAbsent As New List(Of MasterNodeCommunication)

        ''' <summary>
        ''' This method provide to return a string relative all data of a object
        ''' </summary>
        ''' <returns></returns>
        Public Overrides Function toString() As String
            Dim tmp As String = ""

            Try
                tmp += header.toString()
                tmp += proposalUpdateNewTransactionHash.transactionHash
                tmp += proposalsForApprovalData.toString()

                For Each rejected In rejectedRequestData
                    tmp += rejected.toString()
                Next
                For Each requestTmp In AcceptOrAbstainRequestList
                    requestTmp.ToString()
                Next
                For Each absence In masternodeAbsent
                    tmp += absence.toString()
                Next
            Catch ex As Exception
            End Try

            Return tmp
        End Function

        ''' <summary>
        ''' This method provide to generate hash of a string representative the object
        ''' </summary>
        ''' <returns></returns>
        Public Function getHash() As String
            Return HashSHA.generateSHA256(Me.toString())
        End Function

        Public Property hash As String = ""
        Public Property signature As String = ""

        ''' <summary>
        ''' This method provide to clone this object
        ''' </summary>
        ''' <returns></returns>
        Public Function clone() As BulletinInformation
            Try
                Dim result As New BulletinInformation

                With result
                    .header = header.clone()
                    .proposalUpdateNewTransactionHash = proposalUpdateNewTransactionHash.clone()
                    .proposalsForApprovalData = proposalsForApprovalData.clone()

                    For Each rejected In rejectedRequestData
                        .rejectedRequestData.Add(rejected.clone())
                    Next
                    For Each approved In acceptOrAbstainRequestList
                        .addNewAcceptOrAbstainRequestList(approved.clone())
                    Next
                    For Each absence In masternodeAbsent
                        result.masternodeAbsent.Add(absence.clone())
                    Next
                End With

                Return result
            Catch ex As Exception
                AreaCommon.log.track("ConsensusEngine.cloneBulletin", ex.Message, "fatal")

                Return New BulletinInformation
            End Try
        End Function

        ''' <summary>
        ''' This method provide to add a new accept or abstain request list
        ''' </summary>
        ''' <param name="request"></param>
        ''' <returns></returns>
        Public Function addNewAcceptOrAbstainRequestList(ByRef request As ReceiptOfConsensusAssessment) As Boolean
            If Not _KeyAcceptOrAbstainRequestList.ContainsKey(request.hash) Then
                _KeyAcceptOrAbstainRequestList.Add(request.hash, request)
                acceptOrAbstainRequestList.Add(request)

                Return True
            Else
                Return False
            End If
        End Function

        ''' <summary>
        ''' This method provide to add a new reject request list
        ''' </summary>
        ''' <param name="request"></param>
        ''' <returns></returns>
        Public Function addNewRejectRequestList(ByRef request As RejectedRequest) As Boolean
            If Not _KeyAcceptOrAbstainRequestList.ContainsKey(request.hash) Then
                _KeyRejectedList.Add(request.hash, request)
                rejectedRequestData.Add(request)

                Return True
            Else
                Return False
            End If
        End Function

    End Class

    ''' <summary>
    ''' This class contain all data of a consensus network
    ''' </summary>
    Public Class ConsensusNetwork

        Public Property requestHash As String = ""

        Public Property nodeAbstainedOrApproval As New Dictionary(Of String, ReceiptOfConsensusAssessment)
        Public Property nodeReject As New Dictionary(Of String, RejectedRequestBase)
        Public Property nodeAbsent As New Dictionary(Of String, MasterNodeAbsent)

        Public Property hash As String = ""
        Public Property signature As String = ""

        ''' <summary>
        ''' This method provide to create a string hash resultant
        ''' </summary>
        ''' <returns></returns>
        Private Function getHashInternalData() As String
            Try
                Dim tmp As String = ""

                tmp += requestHash

                For Each item In nodeAbstainedOrApproval
                    tmp += item.Value.hash
                Next
                For Each item In nodeReject
                    tmp += item.Value.hash
                Next
                For Each item In nodeAbsent
                    tmp += item.Value.hash
                Next

                Return tmp
            Catch ex As Exception
                Return ""
            End Try
        End Function

        ''' <summary>
        ''' This method provide to reorder Abstained or Approval
        ''' </summary>
        ''' <returns></returns>
        Private Function reoderAbstainedOrApproval() As Boolean
            Try
                Dim newList As New Dictionary(Of String, ReceiptOfAssessmentBase)
                Dim minimal As ReceiptOfAssessmentBase
                Dim current As ReceiptOfAssessmentBase
                Dim indexMinimal As Integer

                AreaCommon.log.track("ConsensusNetwork.reoderAbstainedOrApproval", "Begin")

                Do While (nodeAbstainedOrApproval.Count > 0)
                    indexMinimal = 0

                    'minimal = nodeAbstainedOrApproval.ElementAt(0).Value

                    For i As Integer = 1 To nodeAbstainedOrApproval.Values.Count - 1
                        'current = nodeAbstainedOrApproval.ElementAt(i).Value

                        If (minimal.assessmentTimeStamp > current.assessmentTimeStamp) Then
                            minimal = current

                            indexMinimal = i
                        End If
                    Next

                    newList.Add(minimal.publicAddress, minimal)
                    nodeAbstainedOrApproval.Remove(minimal.publicAddress)
                Loop

                'nodeAbstainedOrApproval = newList

                AreaCommon.log.track("ConsensusNetwork.reoderAbstainedOrApproval", "Complete")

                Return True
            Catch ex As Exception
                AreaCommon.log.track("ConsensusNetwork.reoderApproval", ex.Message, "fatal")

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to reorder a reject masternode
        ''' </summary>
        ''' <returns></returns>
        Private Function reoderReject() As Boolean
            Try
                Dim newList As New Dictionary(Of String, RejectedRequestBase)
                Dim minimal As RejectedRequestBase
                Dim current As RejectedRequestBase
                Dim indexMinimal As Integer

                AreaCommon.log.track("ConsensusNetwork.reoderReject", "Begin")

                Do While (nodeAbstainedOrApproval.Count > 0)
                    indexMinimal = 0
                    minimal = nodeReject.ElementAt(0).Value

                    For i As Integer = 1 To nodeReject.Values.Count - 1
                        current = nodeReject.ElementAt(i).Value

                        If (minimal.assessmentTimeStamp > current.assessmentTimeStamp) Then
                            minimal = current

                            indexMinimal = i
                        End If
                    Next

                    newList.Add(minimal.publicAddress, minimal)
                    nodeReject.Remove(minimal.publicAddress)
                Loop

                nodeReject = newList

                AreaCommon.log.track("ConsensusNetwork.reoderReject", "Complete")

                Return True
            Catch ex As Exception
                AreaCommon.log.track("ConsensusNetwork.reoderReject", ex.Message, "fatal")

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to reorder an absent masternode
        ''' </summary>
        ''' <returns></returns>
        Private Function reoderAbsent() As Boolean
            Try
                Dim newList As New Dictionary(Of String, MasterNodeAbsent)
                Dim minimal As MasterNodeAbsent
                Dim current As MasterNodeAbsent
                Dim indexMinimal As Integer

                AreaCommon.log.track("ConsensusEngine.reoderAbsent", "Begin")

                Do While (nodeAbsent.Count > 0)
                    indexMinimal = 0
                    minimal = nodeAbsent.ElementAt(0).Value

                    For i As Integer = 1 To nodeAbsent.Values.Count - 1
                        current = nodeAbsent.ElementAt(i).Value

                        If (minimal.registerTimeStamp > current.registerTimeStamp) Then
                            minimal = current

                            indexMinimal = i
                        End If
                    Next

                    newList.Add(minimal.publicAddress, minimal)
                    nodeAbsent.Remove(minimal.publicAddress)
                Loop

                nodeAbsent = newList

                AreaCommon.log.track("ConsensusEngine.reoderAbsent", "Complete")

                Return True
            Catch ex As Exception
                AreaCommon.log.track("ConsensusNetwork.reoderAbsent", ex.Message, "fatal")

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to add a new Abstained or Approval
        ''' </summary>
        ''' <param name="model"></param>
        ''' <param name="requestHash"></param>
        ''' <param name="assessmentTimeStamp"></param>
        ''' <param name="voteValue"></param>
        ''' <param name="publicAddress"></param>
        ''' <returns></returns>
        Private Function addNewAbstainedOrApproval(ByVal model As EnumModel, ByVal assessmentTimeStamp As Double, ByVal voteValue As Double, ByVal publicAddress As String, ByVal hash As String, ByVal signature As String) As Boolean
            Try
                Dim item As New ReceiptOfConsensusAssessment

                AreaCommon.log.track("ConsensusNetwork.addNewAbstainedOrApproval", "Begin")

                'item.assessmentTimeStamp = assessmentTimeStamp

                If (publicAddress.Length = 0) Then
                    publicAddress = AreaCommon.state.network.publicAddressIdentity
                End If
                If (voteValue = 0) Then
                    voteValue = AreaCommon.state.network.coinWarranty
                End If

                'item.publicAddress = publicAddress
                item.model = model
                'item.voteValue = voteValue
                item.hash = hash
                item.signature = signature

                If Not nodeAbstainedOrApproval.ContainsKey(requestHash) Then
                    nodeAbstainedOrApproval.Add(requestHash, item)
                End If

                AreaCommon.log.track("ConsensusNetwork.addNewAbstainedOrApproval", "Complete")

                Return True
            Catch ex As Exception
                AreaCommon.log.track("ConsensusNetwork.addNewAbstainedOrApproval", ex.Message, "fatal")

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to reoder all element
        ''' </summary>
        ''' <returns></returns>
        Public Function reorderElement() As Boolean
            Try
                Dim proceed As Boolean = True

                AreaCommon.log.track("ConsensusNetwork.reorderElement", "Begin")

                If proceed Then proceed = reoderAbstainedOrApproval()
                If proceed Then proceed = reoderReject()
                If proceed Then proceed = reoderAbsent()

                AreaCommon.log.track("ConsensusNetwork.reorderElement", "Complete")

                Return proceed
            Catch ex As Exception
                AreaCommon.log.track("ConsensusNetwork.reoderAbsent", ex.Message, "fatal")

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to add a new approval
        ''' </summary>
        ''' <param name="requestHash"></param>
        ''' <param name="assessmentTimeStamp"></param>
        ''' <param name="voteValue"></param>
        ''' <param name="publicAddress"></param>
        ''' <returns></returns>
        Public Function addNewApproval(ByVal assessmentTimeStamp As Double, ByVal hash As String, ByVal signature As String, Optional ByVal voteValue As Double = 0, Optional ByVal publicAddress As String = "") As Boolean
            Return addNewAbstainedOrApproval(EnumModel.approved, assessmentTimeStamp, voteValue, publicAddress, hash, signature)
        End Function

        ''' <summary>
        ''' This method provide to add a new abstained
        ''' </summary>
        ''' <param name="requestHash"></param>
        ''' <param name="assessmentTimeStamp"></param>
        ''' <param name="voteValue"></param>
        ''' <param name="publicAddress"></param>
        ''' <returns></returns>
        Public Function addNewAbstained(ByVal assessmentTimeStamp As Double, ByVal hash As String, ByVal signature As String, Optional ByVal voteValue As Double = 0, Optional ByVal publicAddress As String = "") As Boolean
            Return addNewAbstainedOrApproval(EnumModel.absteined, assessmentTimeStamp, voteValue, publicAddress, hash, signature)
        End Function

        ''' <summary>
        ''' This method provide to add a new rejected
        ''' </summary>
        ''' <param name="assessmentTimeStamp"></param>
        ''' <param name="hash"></param>
        ''' <param name="signature"></param>
        ''' <param name="voteValue"></param>
        ''' <param name="publicAddress"></param>
        ''' <returns></returns>
        Public Function addNewRejected(ByVal assessmentTimeStamp As Double, ByVal hash As String, ByVal signature As String, Optional ByVal voteValue As Double = 0, Optional ByVal publicAddress As String = "") As Boolean
            Try
                Dim item As New ReceiptOfConsensusAssessment

                AreaCommon.log.track("ConsensusNetwork.addNewRejected", "Begin")

                'item.assessmentTimeStamp = assessmentTimeStamp

                If (publicAddress.Length = 0) Then
                    publicAddress = AreaCommon.state.network.publicAddressIdentity
                End If
                If (voteValue = 0) Then
                    voteValue = AreaCommon.state.network.coinWarranty
                End If

                'item.publicAddress = publicAddress
                item.model = EnumModel.reject
                'item.voteValue = voteValue
                item.hash = hash
                item.signature = signature

                If Not nodeAbstainedOrApproval.ContainsKey(publicAddress) Then
                    nodeAbstainedOrApproval.Add(publicAddress, item)
                End If

                AreaCommon.log.track("ConsensusNetwork.addNewRejected", "Complete")

                Return True
            Catch ex As Exception
                AreaCommon.log.track("ConsensusNetwork.addNewRejected", ex.Message, "fatal")

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to create an hash resultant
        ''' </summary>
        ''' <returns></returns>
        Public Function getHash() As String
            Return HashSHA.generateSHA256(Me.getHashInternalData())
        End Function

    End Class

End Namespace
