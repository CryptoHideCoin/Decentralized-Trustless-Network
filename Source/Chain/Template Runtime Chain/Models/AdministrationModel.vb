Option Compare Text
Option Explicit On

Imports CHCProtocolLibrary.AreaCommon.Models



Namespace AreaCommon.Models.Administration


    Public Class AdministrationModel

        Public Enum enumActionAdministration
            verifyData
            rebuildState
            downloadHistory
            setTrustedIPAddress
            buildNetwork
            resumeSystemFirstNode
            checkTrustedNodelist
            cleanLocalData
            synchroNetwork
            requestNetworkConnection
            requestNetworkDisconnect
        End Enum

        Public Enum enumDataElement
            storage
            previousWork
            currentWork
            state
            nodeList
        End Enum

        Public Enum enumDataPosition
            notChecked
            missing
            checkControlPassed
            checkControlNotPassed
        End Enum

        Public Enum enumServicePosition
            offline
            requestToConnection
            online
            requestToDisconnection
        End Enum

        Public Class ComponentElementPosition
            Public Property element As enumDataElement
            Public Property position As enumDataPosition
        End Class

        Public Class ServiceStateResponse

            Inherits General.RemoteResponse

            Public Property componentPosition As New List(Of ComponentElementPosition)
            Public Property listAvailableCommand As New List(Of enumActionAdministration)
            Public Property currentAction As New AppState.ActionElement
            Public Property servicePosition As enumServicePosition

            Private Sub addNewComponentPosition(ByVal enumData As enumDataElement)
                Dim data As New ComponentElementPosition

                data.element = enumData

                componentPosition.Add(data)
            End Sub

            Public Sub init()
                addNewComponentPosition(enumDataElement.storage)
                addNewComponentPosition(enumDataElement.previousWork)
                addNewComponentPosition(enumDataElement.currentWork)
                addNewComponentPosition(enumDataElement.state)
                addNewComponentPosition(enumDataElement.nodeList)
            End Sub
        End Class

    End Class


End Namespace