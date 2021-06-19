Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaCommon.Models
Imports CHCCommonLibrary.AreaEngine.Encryption
Imports CHCBasicCryptographyLibrary.AreaEngine.Encryption.Base58Signature



Namespace AreaCommon.Models.QoSModel

    Public Class RequestNewTicketResponseModel

        Inherits General.RemoteResponse

        Public Property ticketNumber As String = ""

        Public Property queueNumber As Integer = 0
        Public Property ofPriorityNumber As Integer = 0
        Public Property ofStandardNumber As Integer = 0
        Public Property ofUnclassified As Integer = 0

        Public Overrides Function toString() As String
            Dim tmp As String = ""

            tmp += ticketNumber.ToString
            tmp += queueNumber.ToString
            tmp += ofPriorityNumber.ToString()
            tmp += ofStandardNumber.ToString()
            tmp += ofUnclassified.ToString()

            Return tmp
        End Function

        Public ReadOnly Property toHash() As String
            Get
                Return HashSHA.generateSHA256(Me.toString().Replace("|", ""))
            End Get
        End Property

        Public ReadOnly Property signature() As String
            Get
                Dim privateWalletKey As String = AreaCommon.state.keys.Key(TransactionChainLibrary.AreaEngine.KeyPair.KeysEngine.KeyPair.enumWalletType.administration).privateKey

                Return getSignature(privateWalletKey, toHash())
            End Get
        End Property

    End Class

    Public Class RequestDataTicketResponseModel

        Inherits General.RemoteResponse

        Public ticketNumber As String = ""
        Public position As TransactionChainLibrary.AreaEngine.Requests.QueueEngine.DataTicketResponse.enumPosition = TransactionChainLibrary.AreaEngine.Requests.QueueEngine.DataTicketResponse.enumPosition.toEvaluate
        Public queueNumber As Integer = 0
        Public Property unClassified As Boolean = False
        Public Property priorClassified As Boolean = False

        Public Overrides Function toString() As String
            Dim tmp As String = ""

            tmp += ticketNumber.ToString
            tmp += position.ToString
            tmp += queueNumber.ToString
            If unClassified Then tmp += 1 Else tmp += 0
            If priorClassified Then tmp += 1 Else tmp += 0

            Return tmp
        End Function

        Public ReadOnly Property toHash() As String
            Get
                Return HashSHA.generateSHA256(Me.toString().Replace("|", ""))
            End Get
        End Property

        Public ReadOnly Property signature() As String
            Get
                Dim privateWalletKey As String = state.keys.Key(TransactionChainLibrary.AreaEngine.KeyPair.KeysEngine.KeyPair.enumWalletType.administration).privateKey

                Return getSignature(privateWalletKey, toHash())
            End Get
        End Property

    End Class

    Public Class RequestQueueTicketResponseModel

        Inherits General.RemoteResponse

        Public Property queueNumber As Integer = 0
        Public Property ofPriorityNumber As Integer = 0
        Public Property ofStandardNumber As Integer = 0
        Public Property ofUnclassified As Integer = 0

        Public Overrides Function toString() As String
            Dim tmp As String = ""

            tmp += queueNumber.ToString
            tmp += ofPriorityNumber.ToString()
            tmp += ofStandardNumber.ToString()
            tmp += ofUnclassified.ToString()

            Return tmp
        End Function

        Public ReadOnly Property toHash() As String
            Get
                Return HashSHA.generateSHA256(Me.toString().Replace("|", ""))
            End Get
        End Property

        Public ReadOnly Property signature() As String
            Get
                Dim privateWalletKey As String = state.keys.Key(TransactionChainLibrary.AreaEngine.KeyPair.KeysEngine.KeyPair.enumWalletType.administration).privateKey

                Return getSignature(privateWalletKey, toHash())
            End Get
        End Property

    End Class

    Public Class InformationPagesResponseModel

        Inherits General.RemoteResponse

        Public Property pages As List(Of TransactionChainLibrary.AreaEngine.Ledger.QoS.SinglePageInternalLedger)
        Public Property blockSize As Integer = 0

    End Class

    Public Class DataPageResponseModel

        Inherits General.RemoteResponse

        Public Property pageNumber As Integer = 0
        Public Property content As String = ""

    End Class

    Public Class SupportedProtocolsResponseModel

        Inherits General.RemoteResponse

        Public ticketNumber As String = ""

        Public queueNumber As Integer = 0
        Public ofPriorityNumber As Integer = 0
        Public ofStandardNumber As Integer = 0
        Public ofUnclassified As Integer = 0

    End Class

End Namespace