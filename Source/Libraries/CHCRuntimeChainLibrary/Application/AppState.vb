Option Compare Text
Option Explicit On

Imports CHCProtocolLibrary.AreaCommon



Namespace AreaRuntime

    Public Class AppState

        ''' <summary>
        ''' This enum specify the position of stato of network connection
        ''' </summary>
        Public Enum EnumConnectionState

            notDefined
            offLine
            genesisOperation
            startingConnection
            connectionOffLine
            onLine

        End Enum

        ''' <summary>
        ''' This enum specificy the type of a role of a masternode in the network
        ''' </summary>
        Public Enum EnumMasternodeRole

            notDefined
            guarantee
            fullRole
            chainService
            clientService
            light

        End Enum

        Public Class ConnectionNetwork

            Public Property position As EnumConnectionState = EnumConnectionState.notDefined
            Public Property role As EnumMasternodeRole = EnumMasternodeRole.notDefined
            Public Property coinWarranty As Decimal = 0.000000001
            Public Property connectedMoment As Double = 0
            Public Property publicAddressIdentity As String = ""
            Public Property publicAddresstWarranty As String = ""
            Public Property publicAddressRefund As String = ""
            Public Property currentAction As New Models.Administration.ActionElement

        End Class


    End Class

End Namespace