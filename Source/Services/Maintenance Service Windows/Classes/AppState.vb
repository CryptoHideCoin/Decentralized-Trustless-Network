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


    Public currentApplication As EnumStateApplication = EnumStateApplication.notDefined

    Public adminStateData As New ServiceStatus
    Public loaderStateData As New ServiceStatus
    Public serviceStateData As New List(Of ServiceStatus)

    Public noConsoleMessage As Boolean = False
    Public recallLoader As Boolean = False
    Public loaderPort As String = ""
    Public serviceLoaderCertificate As String = ""
    Public useLastSettings As Boolean = False

    Public InstalledModuleList As New CHCProtocolLibrary.AreaUpdate.ModuleCollections

End Class
