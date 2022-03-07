Option Compare Text
Option Explicit On

' ****************************************
' Engine: Common
' Release Engine: 1.0 
' 
' Date last successfully test: 25/02/2022
' ****************************************

Imports CHCModels.AreaModel.Service



Namespace AreaCommon

    Partial Public Class Main

        Public Shared Property schedulerInWorking As Boolean = False
        Public Shared Property notAddInScheduler As Boolean = False

        Public Shared Property settingList As New Dictionary(Of String, AreaCommon.GeneralModel.ServiceData)
        Public Shared Property serviceToRegister As New List(Of MinimalDataToRegister)

        Public Shared Property interfaceEntryPoint As ServiceList

        Public Shared Property dataPath As String = ""
        Public Shared Property securityKey As String = ""

    End Class

End Namespace
