Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web.Http

Public Module WebApiConfig
    Public Sub Register(ByVal config As HttpConfiguration)
        ' Servizi e configurazione dell'API Web

        ' Route dell'API Web
        config.MapHttpAttributeRoutes()

        config.Routes.MapHttpRoute(name:="ConfigurationApi", routeTemplate:="api/v1/Configuration/{controller}/{id}", defaults:=New With {.id = RouteParameter.Optional})
        config.Routes.MapHttpRoute(name:="PeerInformationApi", routeTemplate:="api/v1/PeerInformation/{controller}/{id}", defaults:=New With {.id = RouteParameter.Optional})

    End Sub
End Module
