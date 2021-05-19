Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.DataFileManagement



Namespace AreaUpdate


    Public Class PackageRelease

        Public relativePath As String = ""
        Public serviceName As String = ""
        Public fileName As String = ""
        Public release As String = ""

    End Class

    Public Class SingleModuleInformation

        Public information As PackageRelease
        Public component As List(Of PackageRelease)

    End Class

    Public Class ModuleCollections

        Public information As PackageRelease
        Public component As List(Of SingleModuleInformation)

    End Class

    Public Class ModuleListEngine

        Inherits BaseFileDB(Of List(Of PackageRelease))

    End Class

    Public Class PackageReleaseEngine

        Inherits BaseFileDB(Of List(Of PackageRelease))

    End Class


End Namespace