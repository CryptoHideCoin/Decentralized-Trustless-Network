Option Compare Text
Option Explicit On

' ****************************************
' Engine: Registry Model
' Release Engine: 1.0 
' 
' Date last successfully test: 13/03/2022
' ****************************************

Imports CHCModelsLibrary.AreaModel.Network.Response



Namespace AreaModel.Registry

    ''' <summary>
    ''' This class contain the data relative an a event
    ''' </summary>
    Public Class RegistryData

        Public Enum TypeEvent
            applicationStartUp
            applicationShutdown
            applicationError
            adminTokenReleased
            autoMaintenanceStartup
            other
        End Enum

        Public istant As Double
        Public type As TypeEvent
        Public description As String
        Public fileDetail As String

    End Class

    ''' <summary>
    ''' This class contain a configuration of a Registry Rotate
    ''' </summary>
    Public Class RegistryRotateConfig

        Public keepLast As Log.KeepEnum = Log.KeepEnum.lastMonth

    End Class

    ''' <summary>
    ''' This class contain the registry stream response
    ''' </summary>
    Public Class RegistryStreamResponseModel
        Inherits BaseRemoteResponse

        Public Property value As New List(Of RegistryData)
    End Class

    ''' <summary>
    ''' This class contain the registry list response model
    ''' </summary>
    Public Class RegistryListResponseModel
        Inherits BaseRemoteResponse

        Public Property value As New List(Of String)
    End Class

End Namespace
