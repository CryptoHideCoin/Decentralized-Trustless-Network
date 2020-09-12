Option Compare Text
Option Explicit On



Namespace AreaCommon.Models.Masternode


    Public Class InfoMasternodeModel

        Public currentStatus As String = ""
        Public virtualName As String = ""
        Public masternodeLocalTime As String = ""
        Public publicWalletAddress As String = ""
        Public serviceOffered As String = ""
        Public platformHost As String = ""
        Public softwareRelease As String = ""
        Public protocolRelease As String = ""
        Public ipAddress As String = ""

        Public response As General.RemoteResponse

    End Class


End Namespace

