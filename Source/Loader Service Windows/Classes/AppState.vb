Option Compare Text
Option Explicit On

Imports CHCProtocolLibrary.AreaCommon.Models.Settings




Public Class AppState

    Public uiVisible As Boolean = False
    Public currentApplication As EnumStateApplication = EnumStateApplication.notDefined
    Public runTimeStart As Boolean = False
    Public runTimeInExecute As Boolean = False

    Public adminConnection As Boolean = False
    Public engineConnection As Boolean = False

End Class
