Option Compare Text
Option Explicit On



Namespace AreaCommon.Models.General

    Public Class BooleanModel
        Public value As Boolean
    End Class


    ' TO DELETE
    Public Class StatusWorkModel

        Public Enum EnumStatusWork
            unAuthorized
            onWork
            offWork
        End Enum

        Public value As EnumStatusWork = EnumStatusWork.unAuthorized

    End Class

    Public Class IdentifyRecordLedger

        Public Property recordCoordinate As String = ""
        Public Property recordHash As String = ""

        Public Sub composeCoordinate(ByVal volumeId As String, ByVal blockId As String, ByVal recordId As String)
            recordCoordinate = volumeId & "-" & blockId & "-" & recordId
        End Sub

    End Class

    Public Class RemoteResponse

        Public Enum EnumResponseStatus
            responseComplete
            commandNotAllowed
            missingAuthorization
            systemOffline
            inError
        End Enum

        Public IntegrityTransactionChain As New IdentifyRecordLedger
        Public responseStatus As EnumResponseStatus = EnumResponseStatus.responseComplete
        Public errorDescription As String = ""
        Public requestTime As String = ""
        Public responseTime As String = ""

        Public masterNodePublicAddress As String = ""
        Public signature As String = ""

    End Class

End Namespace
