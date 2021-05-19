Option Compare Text
Option Explicit On





Public Class UpdateEngines

    Public Class Release

        Public major As String = ""
        Public minor As String = ""
        Public build As String = ""
        Public revision As String = ""

    End Class

    Public Class ServiceRelease

        Public serviceName As String = ""
        Public release As New Release
        Public description As String = ""

    End Class

    Public Class ServiceReleasePosition

        Public packageData As New ServiceRelease
        Public notifyToAdmin As Boolean = False
        Public acceptToTheAdmin As Boolean = False
        Public downloadPackage As Boolean = False
        Public requestToStopApplication As Boolean = False
        Public updateProcessStart As Boolean = False

    End Class

End Class
