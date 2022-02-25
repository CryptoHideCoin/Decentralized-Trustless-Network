Option Compare Text
Option Explicit On

' ****************************************
' File: Administration Model
' Release Engine: 1.0 
' 
' Date last successfully test: 03/10/2021
' ****************************************


Imports CHCModels.AreaModel.Network.Response
Imports CHCModels.AreaModel.Log



Namespace AreaCommon.Models.Administration


    ''' <summary>
    ''' This enumeration contain the list of the command
    ''' </summary>
    Public Enum EnumActionAdministration
        undefined
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

    ''' <summary>
    ''' This enumeration contain the list of macro element of the service
    ''' </summary>
    Public Enum EnumDataElement
        storage
        previousWork
        currentWork
        state
        nodeList
    End Enum

    ''' <summary>
    ''' This enumeration contain the response of a check
    ''' </summary>
    Public Enum EnumDataPosition
        notChecked
        missing
        checkControlPassed
        checkControlNotPassed
    End Enum

    ''' <summary>
    ''' This enumeration contain the position of a request
    ''' </summary>
    Public Enum EnumServicePosition
        offline
        requestToConnection
        online
        requestToDisconnection
    End Enum

    ''' <summary>
    ''' This class contain the single position of an element
    ''' </summary>
    Public Class ComponentElementPosition

        Public Property element As EnumDataElement
        Public Property position As EnumDataPosition

    End Class

    ''' <summary>
    ''' This class contain all element of a current action
    ''' </summary>
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

    ''' <summary>
    ''' This class contain a service state response
    ''' </summary>
    Public Class ServiceStateResponse

        Inherits RemoteResponse

        Public Property componentPosition As New List(Of ComponentElementPosition)
        Public Property listAvailableCommand As New List(Of EnumActionAdministration)
        Public Property currentAction As New ActionElement
        Public Property servicePosition As EnumServicePosition
        Public Property currentRunCommand As EnumActionAdministration = EnumActionAdministration.undefined
        Public Property requestCancelCurrentRunCommand As Boolean = False

        ''' <summary>
        ''' This method provide to add a new component position
        ''' </summary>
        ''' <param name="enumData"></param>
        Private Sub addNewComponentPosition(ByVal enumData As EnumDataElement)
            Dim data As New ComponentElementPosition

            data.element = enumData

            componentPosition.Add(data)
        End Sub

        ''' <summary>
        ''' This method provide to specific component position  
        ''' </summary>
        ''' <param name="key"></param>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Public Function getComponentPosition(ByVal key As EnumDataElement) As ComponentElementPosition
            For Each item In componentPosition
                If (item.element = key) Then
                    Return item
                End If
            Next

            Return New ComponentElementPosition
        End Function

        ''' <summary>
        ''' This method provide to initialize component
        ''' </summary>
        <DebuggerHiddenAttribute()> Public Sub init()
            addNewComponentPosition(EnumDataElement.storage)
            addNewComponentPosition(EnumDataElement.previousWork)
            addNewComponentPosition(EnumDataElement.currentWork)
            addNewComponentPosition(EnumDataElement.state)
            addNewComponentPosition(EnumDataElement.nodeList)

            listAvailableCommand.Add(EnumActionAdministration.verifyData)
        End Sub

    End Class

End Namespace