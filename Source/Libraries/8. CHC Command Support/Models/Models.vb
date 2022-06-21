Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.CommandLine





Namespace AreaCommon.Models

    ''' <summary>
    ''' This is the interface of all command managed
    ''' </summary>
    Public Interface CommandModel

        Property command As CommandStructure

        Event WriteLine(ByVal message As String)
        Event Process(ByVal applicationName As String, ByVal commandLine As String)
        Event IntegrityApplication(ByVal fileName As String)
        Event RaiseError(ByVal message As String)
        Event ReadKey()

        Function run() As Boolean

    End Interface

End Namespace
