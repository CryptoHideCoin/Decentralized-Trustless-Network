Option Compare Text
Option Explicit On

' ****************************************
' Engine: Common
' Release Engine: 1.0 
' 
' Date last successfully test: 05/10/2021
' ****************************************

Imports CHCProtocolLibrary.AreaCommon.Models.Service



Namespace AreaCommon

    Public Class Main

        Public Shared Property environment As New AreaChain.Runtime.Models.EnvironmentModel
        Public Shared Property serviceInformation As InternalServiceInformation
        Public Shared Property settingsPassword As String = ""

    End Class

End Namespace
