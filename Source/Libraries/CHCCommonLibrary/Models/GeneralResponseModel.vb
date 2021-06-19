Option Compare Text
Option Explicit On



Namespace AreaCommon.Models.General

    Public Class BooleanModel
        Public value As Boolean
    End Class

    Public Class StatusWorkModel

        Public Enum EnumStatusWork

            unAuthorized
            onWork
            offWork

        End Enum

        Public value As EnumStatusWork = EnumStatusWork.unAuthorized

    End Class

    Public Class RemoteResponse

        Public Enum EnumResponseStatus

            responseComplete
            missingAuthorization
            systemOffline
            inError

        End Enum

        Public responseStatus As EnumResponseStatus = EnumResponseStatus.responseComplete
        Public errorDescription As String = ""
        Public requestTime As New DateTime
        Public responseTime As New DateTime

    End Class

End Namespace
