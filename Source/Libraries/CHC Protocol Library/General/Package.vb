Option Compare Text
Option Explicit On

' ****************************************
' Engine: Info System
' Release Engine: 1.0 
' 
' Date last successfully test: 02/10/2021
' ****************************************


Imports CHCCommonLibrary.AreaEngine.DataFileManagement.XML





Namespace AreaUpdate

    ''' <summary>
    ''' This class contain the information relative of a release package
    ''' </summary>
    Public Class PackageRelease

        Public relativePath As String = ""
        Public serviceName As String = ""
        Public fileName As String = ""
        Public release As String = ""

    End Class

    ''' <summary>
    ''' This class contain the single module information of a update release
    ''' </summary>
    Public Class SingleModuleInformation

        Public information As PackageRelease
        Public component As List(Of PackageRelease)

    End Class

    ''' <summary>
    ''' This class contain the collection of module of a package update
    ''' </summary>
    Public Class ModuleCollections

        Public information As PackageRelease
        Public component As List(Of SingleModuleInformation)

    End Class

    ''' <summary>
    ''' This class manage module into file
    ''' </summary>
    Public Class ModuleListEngine

        Inherits BaseFile(Of List(Of PackageRelease))

    End Class

    ''' <summary>
    ''' This class manage package into file
    ''' </summary>
    Public Class PackageReleaseEngine

        Inherits BaseFile(Of List(Of PackageRelease))

    End Class

End Namespace