Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaCommon.Models
Imports CHCCommonLibrary.AreaEngine.Encryption



Namespace AreaCommon.Models.Network

    Public Class InfoNetworkBaseModel

        Inherits General.RemoteResponse

        Public Property name As String = ""
        Public Property networkCreationDate As String = ""
        Public Property genesisPublicAddress As String = ""


        Public Overrides Function toString() As String
            Dim tmp As String = ""

            tmp += name
            tmp += networkCreationDate
            tmp += genesisPublicAddress
            tmp += IntegrityTransactionChain.recordCoordinate
            tmp += IntegrityTransactionChain.recordHash

            Return tmp
        End Function

        Public Function getHash() As String
            Return HashSHA.generateSHA256(Me.toString())
        End Function

    End Class


    Public Class DocumentModel

        Inherits General.RemoteResponse

        Public value As String = ""

        Public Overrides Function toString() As String
            Dim tmp As String = ""

            tmp += value
            tmp += IntegrityTransactionChain.recordCoordinate
            tmp += IntegrityTransactionChain.recordHash

            Return tmp
        End Function

        Public Function getHash() As String
            Return HashSHA.generateSHA256(Me.toString())
        End Function

    End Class


    Public Class InfoAssetModel

        Inherits General.RemoteResponse

        Public Property value As AssetModel

        Public Overrides Function toString() As String
            Dim tmp As String = ""

            tmp += IntegrityTransactionChain.recordCoordinate
            tmp += IntegrityTransactionChain.recordHash
            tmp += value.toString()

            Return tmp
        End Function

        Public Function getHash() As String
            Return HashSHA.generateSHA256(Me.toString())
        End Function

    End Class


    Public Class InfoTransactionChainSettingsModel

        Inherits General.RemoteResponse

        Public Property value As TransactionChainModel

        Public Overrides Function toString() As String
            Dim tmp As String = ""

            tmp += IntegrityTransactionChain.recordCoordinate
            tmp += IntegrityTransactionChain.recordHash
            tmp += value.toString()

            Return tmp
        End Function

        Public Function getHash() As String
            Return HashSHA.generateSHA256(Me.toString())
        End Function

    End Class


    Public Class InfoRefundPlanModel

        Inherits General.RemoteResponse

        Public Property value As RefundItemList

        Public Overrides Function toString() As String
            Dim tmp As String = ""

            tmp += IntegrityTransactionChain.recordCoordinate
            tmp += IntegrityTransactionChain.recordHash
            tmp += value.toString()

            Return tmp
        End Function

        Public Function getHash() As String
            Return HashSHA.generateSHA256(Me.toString())
        End Function

    End Class

End Namespace
