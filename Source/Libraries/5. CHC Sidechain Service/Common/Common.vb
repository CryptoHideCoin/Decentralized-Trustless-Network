Option Compare Text
Option Explicit On

' ****************************************
' Engine: Common
' Release Engine: 1.0 
' 
' Date last successfully test: 25/02/2022
' ****************************************

Imports CHCModels.AreaModel.Information



Namespace AreaCommon

    Public Class Main

        Public Shared Property environment As New AreaChain.Runtime.Models.EnvironmentModel
        Public Shared Property serviceInformation As New InternalServiceInformation
        Public Shared Property settingsPassword As String = ""
        Public Shared Property securityTokenSwitchOnService As String = ""

    End Class

End Namespace
