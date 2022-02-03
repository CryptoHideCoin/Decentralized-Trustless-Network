Option Compare Text
Option Explicit On





Namespace Models


    Public Enum EnumPeerStatusDetail

        offLine
        duringStartUp
        onLine
        shutDownStart
        maintenanceStart
        inMaintenance
        inPauseFromMaintenance

    End Enum


    Public Enum EnumPeerStatus

        offLine
        onLine

    End Enum


    Public Enum EnumChangeStatus

        toStart
        toStop
        toMaintenance

    End Enum


    Public Class PeerCurrentStatusModel

        Public value As EnumPeerStatus

    End Class

    Public Class PeerCurrentDetailStatusModel

        Public tokenRequest As String = ""
        Public value As EnumPeerStatusDetail

    End Class

    Public Class PeerRequestChangeStatusModel

        Public tokenRequest As String = ""
        Public newStatus As EnumChangeStatus = EnumChangeStatus.toStart

    End Class



End Namespace
