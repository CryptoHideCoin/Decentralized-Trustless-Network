Option Compare Text
Option Explicit On

' ****************************************
' Engine: Common
' Release Engine: 1.0 
' 
' Date last successfully test: 25/02/2022
' ****************************************

Imports CHCModelsLibrary.AreaModel.Information



Namespace AreaCommon

    Partial Public Class Main

        Public Shared Property environment As New AreaChain.Runtime.Models.EnvironmentModel
        Public Shared Property serviceInformation As New InternalServiceInformation
        Public Shared Property settingsPassword As String = ""
        Public Shared Property securityKey As String = ""
        Public Shared Property securityTokenSwitchOnService As String = ""

        Public Shared Property updateLastGetServiceInformation As Double = 0

    End Class

End Namespace
