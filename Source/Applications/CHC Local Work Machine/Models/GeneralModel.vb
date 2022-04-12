Option Compare Text
Option Explicit On

' ****************************************
' Engine: Common
' Release Engine: 1.0 
' 
' Date last successfully test: 25/02/2022
' ****************************************

Imports CHCModelsLibrary.AreaModel.Administration.Settings
Imports CHCProtocolLibrary.AreaEngine.Keys


Namespace AreaCommon.GeneralModel

    ''' <summary>
    ''' This class contain all information relative a single service
    ''' </summary>
    Public Class ServiceData
        Public Property configuration As SettingsSidechainServiceComplete
        Public Property keys As KeysEngine.KeyPair
        Public Property securityToken As String = ""
        Public Property status As String = ""
        Public Property lastCheckTimeStamp As Double = 0
    End Class

End Namespace
