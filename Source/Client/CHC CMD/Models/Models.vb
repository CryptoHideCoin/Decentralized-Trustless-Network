Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.CommandLine





Namespace AreaCommon.Models

    ''' <summary>
    ''' This is the interface of all command managed
    ''' </summary>
    Public Interface CommandModel

        Property command As CommandStructure

        Function run() As Boolean

    End Interface

End Namespace
