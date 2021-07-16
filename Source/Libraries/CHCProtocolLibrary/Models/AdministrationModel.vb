Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaCommon.Models



Namespace AreaCommon.Models


    Public Class Administration

        Public Enum EnumActionAdministration
            notDefined
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
            cancelCurrentAction
        End Enum

        Public Enum EnumDataElement
            storage
            previousWork
            currentWork
            state
            nodeList
        End Enum

        Public Enum EnumDataPosition
            notChecked
            missing
            checkControlPassed
            checkControlNotPassed
        End Enum

        Public Enum EnumServicePosition
            offline
            requestToConnection
            online
            requestToDisconnection
        End Enum

        Public Class ComponentElementPosition
            Public Property element As EnumDataElement
            Public Property position As EnumDataPosition
        End Class

        Public Class ActionElement
            Public Property codeAction As String = ""
            Public Property descriptionAction As String = ""
            Public Property codeError As String = ""
            Public Property descriptionError As String = ""

            Public Sub reset()
                codeAction = "" : descriptionAction = ""
                codeError = "" : descriptionError = ""
            End Sub

            Public Sub setAction(ByVal code As String, ByVal description As String)
                codeAction = code
                descriptionAction = description
            End Sub

            Public Sub setError(ByVal code As String, ByVal description As String)
                codeError = code
                descriptionError = description
            End Sub
        End Class

        Public Class ServiceStateResponse

            Inherits General.RemoteResponse

            Public Property componentPosition As New List(Of ComponentElementPosition)
            Public Property listAvailableCommand As New List(Of EnumActionAdministration)
            Public Property currentAction As New ActionElement
            Public Property servicePosition As EnumServicePosition
            Public Property currentRunCommand As EnumActionAdministration = EnumActionAdministration.notDefined
            Public Property requestCancelCurrentRunCommand As Boolean = False

            Private Sub addNewComponentPosition(ByVal enumData As EnumDataElement)
                Dim data As New ComponentElementPosition

                data.element = enumData

                componentPosition.Add(data)
            End Sub

            Public Function getComponentPosition(ByVal key As EnumDataElement) As ComponentElementPosition
                For Each item In componentPosition
                    If (item.element = key) Then
                        Return item
                    End If
                Next

                Return New ComponentElementPosition
            End Function

            Public Sub init()
                addNewComponentPosition(EnumDataElement.storage)
                addNewComponentPosition(EnumDataElement.previousWork)
                addNewComponentPosition(EnumDataElement.currentWork)
                addNewComponentPosition(EnumDataElement.state)
                addNewComponentPosition(EnumDataElement.nodeList)

                listAvailableCommand.Add(EnumActionAdministration.verifyData)
            End Sub
        End Class

    End Class


End Namespace