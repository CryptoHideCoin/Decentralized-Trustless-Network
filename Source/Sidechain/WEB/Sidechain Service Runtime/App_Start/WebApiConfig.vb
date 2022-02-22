Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web.Http

Public Module WebApiConfig
    Public Sub Register(ByVal config As HttpConfiguration)
        Dim serviceID As String = ""

        config.MapHttpAttributeRoutes()

        If (CHCSidechainServiceLibrary.AreaCommon.Main.environment.settings.serviceID.Length > 0) Then
            serviceID = CHCSidechainServiceLibrary.AreaCommon.Main.environment.settings.serviceID & "/"
        End If

        config.Routes.MapHttpRoute(name:="ServiceApi", routeTemplate:="api/" & serviceID & "service/{controller}")
        config.Routes.MapHttpRoute(name:="SecurityApi", routeTemplate:="api/" & serviceID & "security/{controller}")
        config.Routes.MapHttpRoute(name:="AdministrationApi", routeTemplate:="api/" & serviceID & "administration/{controller}")
        config.Routes.MapHttpRoute(name:="AdministrationDoActionApi", routeTemplate:="api/" & serviceID & "administration/doAction/{controller}")

        config.Routes.MapHttpRoute(name:="QoSTicketApi", routeTemplate:="api/" & serviceID & "qos/{controller}")
        config.Routes.MapHttpRoute(name:="SystemApi", routeTemplate:="api/v1.0/System/{controller}")
        config.Routes.MapHttpRoute(name:="LedgerApi", routeTemplate:="api/" & serviceID & "ledger/{controller}")
        config.Routes.MapHttpRoute(name:="ChainApi", routeTemplate:="api/" & serviceID & "chain/{controller}")
        config.Routes.MapHttpRoute(name:="SupplyApi", routeTemplate:="api/" & serviceID & "supply/{controller}")
        config.Routes.MapHttpRoute(name:="NetworkApi", routeTemplate:="api/" & serviceID & "network/{controller}")
        config.Routes.MapHttpRoute(name:="RequestApi", routeTemplate:="api/" & serviceID & "request/{controller}")
        config.Routes.MapHttpRoute(name:="NotifyRequestApi", routeTemplate:="api/" & serviceID & "notify/{controller}")

    End Sub
End Module
