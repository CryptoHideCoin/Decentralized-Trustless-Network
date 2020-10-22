Option Compare Text
Option Explicit On

Imports CHCProtocolLibrary.AreaCommon.Models.Settings




Public Class AppState

    Public Class ServiceStatus

        Public applicationName As String = ""
        Public serviceName As String = ""
        Public secureProtocol As String = ""
        Public url As String = ""
        Public status As EnumStateApplication = EnumStateApplication.notDefined
        Public connection As Boolean = False
        Public runTimeAutoStart As Boolean = False
        Public duringUpdate As Boolean = False

    End Class


    Public uiVisible As Boolean = False
    Public currentApplication As EnumStateApplication = EnumStateApplication.notDefined

    Public restartSystem As Boolean = False
    Public updateConnection As Boolean = False

    Public adminStateData As New ServiceStatus
    Public serviceStateData As New List(Of ServiceStatus)

End Class
