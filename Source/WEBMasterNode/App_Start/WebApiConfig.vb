Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web.Http



Public Module WebApiConfig
    Public Sub Register(ByVal config As HttpConfiguration)
        ' Servizi e configurazione dell'API Web

        ' Route dell'API Web
        config.MapHttpAttributeRoutes()

        config.Routes.MapHttpRoute(name:="DefinitionApi", routeTemplate:="api/v1/Definition/{controller}/{id}", defaults:=New With {.id = RouteParameter.Optional})
        config.Routes.MapHttpRoute(name:="InformationApi", routeTemplate:="api/v1/Peer/Information/{controller}/{id}", defaults:=New With {.id = RouteParameter.Optional})
        'config.Routes.MapHttpRoute(name:="PeerApi", routeTemplate:="api/v1/Peer/{controller}/{id}", defaults:=New With {.id = RouteParameter.Optional})

        config.Routes.MapHttpRoute(name:="AuthorizationApi", routeTemplate:="api/v1/Authorization/{controller}/{id}", defaults:=New With {.id = RouteParameter.Optional})
        config.Routes.MapHttpRoute(name:="AdminApi", routeTemplate:="api/v1/Admin/{controller}/{id}", defaults:=New With {.id = RouteParameter.Optional})

    End Sub
End Module
