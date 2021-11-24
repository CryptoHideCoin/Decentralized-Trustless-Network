Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.Encryption
Imports CHCCommonLibrary.AreaEngine.DataFileManagement.Json






Namespace AreaConsensus


    ''' <summary>
    ''' This enumeration contain all type of model
    ''' </summary>
    Public Enum EnumModel
        approved
        rejected
        abstained
        absented
    End Enum

    ''' <summary>
    ''' This class contain a simply release of ReceiptOfAssessment structure
    ''' </summary>
    Public Class ReceiptOfAssessmentBase

        Public Property model As EnumModel = EnumModel.absented
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

        Public Property model As EnumModel = EnumModel.absented
        Public Overridable Property requestHash As String = ""
        Public Property assessmentTimeStamp As Double = 0

        ''' <summary>
        ''' This method provide to create a string of all element of this object
        ''' </summary>
        ''' <returns></returns>
        Public Overridable Function toString() As String
            Dim result As String = ""

            result += AreaCommon.state.network.publicAddressIdentity
            result += Byte.Parse(model).ToString()
            result += requestHash
            result += assessmentTimeStamp.ToString()

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

    Public Class ReceiptOfConsensusAssessmentComplete

        Inherits ReceiptOfAssessmentBase

        Public Property voteValue As Double = 0

        ''' <summary>
        ''' This method provide to create a string of all element of this object
        ''' </summary>
        ''' <returns></returns>
        Public Overridable Function toString() As String
            Dim result As String = ""

            result += MyBase.toString()
            result += voteValue.ToString()

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

        Public Overrides Property requestHash As String = ""

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

                result = MemberwiseClone()

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
            Return Me.MemberwiseClone()
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

        ''' <summary>
        ''' This method provide to clone all member of this object
        ''' </summary>
        ''' <returns></returns>
        Public Function clone() As NetSynchronization
            Dim result As New NetSynchronization

            Try
                AreaCommon.log.track("NetSynchronization.clone", "Begin")

                result.hashNetwork = hashNetwork
                result.hashChain = hashChain
                result.lastApprovedTransaction = lastApprovedTransaction.clone()

                AreaCommon.log.track("NetSynchronization.clone", "Complete")
            Catch ex As Exception
                AreaCommon.log.track("NetSynchronization.clone", ex.Message, "fatal")

                Return New NetSynchronization
            End Try

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
            Try
                Return New HeaderBulletin With {.bulletinTimeStamp = bulletinTimeStamp, .publicAddress = publicAddress, .netSynchronizationData = netSynchronizationData.clone()}
            Catch ex As Exception
                Return New HeaderBulletin
            End Try
        End Function

    End Class

    ''' <summary>
    ''' This class contain the convergence of a new 
    ''' </summary>
    Public Class UpdateNewTransactionHashInformation

        Public Property requestHash As String = ""
        Public Property proposalIdentifierTransactionLedger As String = ""
        Public Property consensusHash As String = ""

        ''' <summary>
        ''' This method provide to clone this object
        ''' </summary>
        ''' <returns></returns>
        Public Function clone() As UpdateNewTransactionHashInformation
            Return Me.MemberwiseClone()
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
                Return total.ToString()
            End Function

            ''' <summary>
            ''' This method provide to clone an object
            ''' </summary>
            ''' <returns></returns>
            Public Function clone() As VoteTotalizations
                Return Me.MemberwiseClone
            End Function

        End Class

        Public Property requestHash As String = ""
        Public Property registerBulletinAssessmentTimeStamp As Double = 0
        Public Property registerMasternodeAddress As String = ""
        Public Property totalVotes As New VoteTotalizations

        ''' <summary>
        ''' This method provide to create a string resultant of a Proposal for Approval
        ''' </summary>
        ''' <returns></returns>
        Public Overrides Function toString() As String
            Dim tmp As String = ""

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

            result.requestHash = requestHash
            result.registerBulletinAssessmentTimeStamp = registerBulletinAssessmentTimeStamp
            result.registerMasternodeAddress = registerMasternodeAddress

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
                tmp += proposalUpdateNewTransactionHash.ToString()
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

                    .hash = hash
                    .signature = signature
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

        ''' <summary>
        ''' This method provide to remove accept or abstain request list
        ''' </summary>
        ''' <param name="requestHash"></param>
        ''' <returns></returns>
        Public Function removeAcceptOrAbstainRequestList(ByVal requestHash As String) As Boolean
            Try
                AreaCommon.log.track("ConsensusEngine.removeAcceptOrAbstainRequestList", "Begin")

                For Each item In acceptOrAbstainRequestList
                    If (item.requestHash.CompareTo(requestHash) = 0) Then
                        acceptOrAbstainRequestList.Remove(item)
                        _KeyAcceptOrAbstainRequestList.Remove(requestHash)

                        Return True
                    End If
                Next

                AreaCommon.log.track("ConsensusEngine.removeAcceptOrAbstainRequestList", "Complete")

                Return True
            Catch ex As Exception
                AreaCommon.log.track("ConsensusEngine.removeAcceptOrAbstainRequestList", ex.Message, "fatal")

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to Remove Reject Request Data
        ''' </summary>
        ''' <param name="request"></param>
        ''' <returns></returns>
        Public Function removeRejectRequestData(ByRef request As RejectedRequest) As Boolean
            Try
                AreaCommon.log.track("ConsensusEngine.removeRejectRequestData", "Begin")

                For Each item In rejectedRequestData
                    If (item.requestHash.CompareTo(request) = 0) Then
                        rejectedRequestData.Remove(item)
                        _KeyRejectedList.Remove(request.requestHash)

                        Return True
                    End If
                Next

                AreaCommon.log.track("ConsensusEngine.removeRejectRequestData", "Complete")

                Return True
            Catch ex As Exception
                AreaCommon.log.track("ConsensusEngine.removeRejectRequestData", ex.Message, "fatal")

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to clean a proposal for approval data
        ''' </summary>
        ''' <returns></returns>
        Public Function cleanProposalData() As Boolean
            Try
                proposalsForApprovalData = New ProposalForApproval

                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to save a consensus file
        ''' </summary>
        ''' <returns></returns>
        Public Function save() As Boolean
            Try
                Return IOFast(Of BulletinInformation).save(IO.Path.Combine(AreaCommon.paths.workData.temp, proposalsForApprovalData.requestHash & ".Bulletin"), Me)
            Catch ex As Exception
                Return False
            End Try
        End Function

    End Class

    ''' <summary>
    ''' This class contain all data of a consensus network
    ''' </summary>
    Public Class ConsensusNetwork

        Public Property netWorkReferement As String = ""
        Public Property chainReferement As String = ""

        Public Property requestHash As String = ""
        Public Property masterNodePublicAddress As String = ""

        Public Property nodeRegistrant As String = ""
        Public Property nodeRegistrantTimeStamp As Double = 0

        Public Property nodeElements As New List(Of ReceiptOfConsensusAssessmentComplete)

        Public Property voteValueApproved As Double = 0
        Public Property voteValueRejected As Double = 0

        Public Property hash As String = ""
        Public Property signature As String = ""

        ''' <summary>
        ''' This method provide to create a string hash resultant
        ''' </summary>
        ''' <returns></returns>
        Private Overloads Function toString() As String
            Try
                Dim tmp As String = ""

                tmp += netWorkReferement
                tmp += chainReferement
                tmp += requestHash
                tmp += masterNodePublicAddress
                tmp += nodeRegistrant
                tmp += nodeRegistrantTimeStamp.ToString()

                For Each item In nodeElements
                    tmp += item.hash
                Next

                tmp += voteValueApproved.ToString()
                tmp += voteValueRejected.ToString()

                Return tmp
            Catch ex As Exception
                Return ""
            End Try
        End Function

        ''' <summary>
        ''' This method provide to clear all element of this structure
        ''' </summary>
        ''' <returns></returns>
        Public Function clear() As Boolean
            Try
                AreaCommon.log.track("ConsensusNetwork.clear", "Begin")

                nodeElements.Clear()

                AreaCommon.log.track("ConsensusNetwork.clear", "Complete")

                Return True
            Catch ex As Exception
                AreaCommon.log.track("ConsensusNetwork.clear", ex.Message, "fatal")

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to reoder all element
        ''' </summary>
        ''' <returns></returns>
        Public Function reorderElements() As Boolean
            Try
                Dim newList As New List(Of ReceiptOfConsensusAssessmentComplete)
                Dim minimal As ReceiptOfConsensusAssessmentComplete
                Dim current As ReceiptOfConsensusAssessmentComplete
                Dim indexMinimal As Integer

                AreaCommon.log.track("ConsensusNetwork.reorderElement", "Begin")

                Do While (nodeElements.Count > 0)
                    indexMinimal = 0

                    minimal = nodeElements.Item(0)

                    For i As Integer = 1 To nodeElements.Count - 1
                        current = nodeElements.Item(i)

                        If (minimal.assessmentTimeStamp > current.assessmentTimeStamp) Then
                            minimal = current

                            indexMinimal = i
                        End If
                    Next

                    newList.Add(minimal)
                    nodeElements.Remove(minimal)
                Loop

                nodeElements = newList

                AreaCommon.log.track("ConsensusNetwork.reorderElement", "Complete")

                Return True
            Catch ex As Exception
                AreaCommon.log.track("ConsensusNetwork.reorderElement", ex.Message, "fatal")

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to add a new assessment node
        ''' </summary>
        ''' <param name="assessmentTimeStamp"></param>
        ''' <param name="hash"></param>
        ''' <param name="signature"></param>
        ''' <param name="voteValue"></param>
        ''' <param name="publicAddress"></param>
        ''' <returns></returns>
        Public Function addNewAssessment(ByVal model As EnumModel, ByVal assessmentTimeStamp As Double, ByVal hash As String, ByVal signature As String, Optional ByVal voteValue As Double = 0, Optional ByVal publicAddress As String = "") As Boolean
            Try
                Dim item As New ReceiptOfConsensusAssessmentComplete

                AreaCommon.log.track("ConsensusNetwork.addNewAssessment", "Begin")

                item.assessmentTimeStamp = assessmentTimeStamp

                If (publicAddress.Length = 0) Then
                    publicAddress = AreaCommon.state.network.publicAddressIdentity
                End If
                If (voteValue = 0) Then
                    voteValue = AreaCommon.state.network.coinWarranty
                End If

                item.publicAddress = publicAddress
                item.model = model
                item.voteValue = voteValue
                item.hash = hash
                item.signature = signature

                nodeElements.Add(item)

                AreaCommon.log.track("ConsensusNetwork.addNewAbsent", "Complete")

                Return True
            Catch ex As Exception
                AreaCommon.log.track("ConsensusNetwork.addNewAbsent", ex.Message, "fatal")

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to create an hash resultant
        ''' </summary>
        ''' <returns></returns>
        Public Function getHash() As String
            Return HashSHA.generateSHA256(Me.toString())
        End Function

        ''' <summary>
        ''' This method provide to save a consensus file
        ''' </summary>
        ''' <returns></returns>
        Public Function save() As Boolean
            Try
                Return IOFast(Of ConsensusNetwork).save(IO.Path.Combine(AreaCommon.paths.workData.temp, requestHash & ".Consensus"), Me)
            Catch ex As Exception
                Return False
            End Try
        End Function

    End Class

End Namespace
