Imports System.Web.Http
Imports System.Web.Optimization

Public Class WebApiApplication
    Inherits System.Web.HttpApplication

    Protected Sub Application_Start()
        AreaCommon.Startup.Main.run()

        AreaRegistration.RegisterAllAreas()
        GlobalConfiguration.Configure(AddressOf WebApiConfig.Register)
        FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters)
    End Sub
End Class
