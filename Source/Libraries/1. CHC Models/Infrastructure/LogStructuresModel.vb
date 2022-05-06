Option Compare Text
Option Explicit On

' ****************************************
' Engine: Log Model
' Release Engine: 1.0 
' 
' Date last successfully test: 13/03/2022
' ****************************************

Imports CHCModelsLibrary.AreaModel.Network.Response



Namespace AreaModel.Log

    ''' <summary>
    ''' This enumeration contain the type of log row
    ''' </summary>
    Public Enum ActionEnumeration
        undefined
        printIntoConsole
        enterIntoMethod
        exitFromTheMethod
        genericTrack
        exception
    End Enum

    ''' <summary>
    ''' This enumeration contain the following value:
    ''' 
    ''' dontTrackEver - Don't save a log never
    ''' trackOnlyBootstrapAndError - Track only bootstrap and error
    ''' trackAll - Track all event
    ''' </summary>
    Public Enum TrackRuntimeModeEnum
        trackOnlyBootstrapAndError
        trackAll
    End Enum

    ''' <summary>
    ''' This enum contain the log file that we want to mantain
    ''' </summary>
    Public Enum KeepEnum
        undefined
        lastDay
        lastWeek
        lastMonth
        lastYear
    End Enum


    ''' <summary>
    ''' This class contain the runtime parameter's for the log panel
    ''' </summary>
    Public Class LogPanelParameters
        Public Property switchOff As Boolean = False
        Public Property showOnlyInfo As Boolean = True
        Public Property pause As Boolean = False
        Public Property frequencyRefresh As Double = 1000
    End Class

    ''' <summary>
    ''' This class contain the element of a single action of application
    ''' </summary>
    Public Class SingleActionApplication
        Public Property instant As Double = 0
        Public Property action As ActionEnumeration = ActionEnumeration.undefined
        Public Property position As String = ""
        Public Property message As String = ""
        Public Property duringBootstrap As Boolean = False

        ''' <summary>
        ''' This method provide to create a string resultant
        ''' </summary>
        ''' <returns></returns>
        Public Overrides Function toString() As String
            Return instant.ToString() & "|" & action & "|" & position & "|" & message
        End Function

        ''' <summary>
        ''' This method provide to create a string from a data of this class
        ''' </summary>
        ''' <param name="dataComplete"></param>
        ''' <returns></returns>
        Public Overloads Function toString(ByVal dataComplete As Boolean) As String
            Dim tmp As String = ""

            tmp += New DateTime(1970, 1, 1, 0, 0, 0, 0).AddMilliseconds(instant) & "|"
            tmp += instant & "|"

            Select Case action
                Case ActionEnumeration.enterIntoMethod : tmp += "Enter into method|"
                Case ActionEnumeration.exception : tmp += "Exception|"
                Case ActionEnumeration.exitFromTheMethod : tmp += "Exit into method|"
                Case ActionEnumeration.genericTrack : tmp += "Generic Track|"
                Case ActionEnumeration.printIntoConsole : tmp += "Print into console|"
            End Select

            tmp += position & "|"
            tmp += message

            If duringBootstrap Then
                tmp += "|During bootstrap"
            End If

            Return tmp
        End Function
    End Class

    ''' <summary>
    ''' This class contain the track configuration
    ''' </summary>
    Public Class TrackConfiguration
        Private Property _SaveModeLocal As TrackRuntimeModeEnum = TrackRuntimeModeEnum.trackAll
        Private Property _InstanceIDLocal As String = ""
        Private Property _PathFileLocal As String = ""
        Private Property _ChangeFileEveryLocal As Integer = 0
        Private Property _ChangeNumberOfRegistrationsLocal As Integer = 0
        Private Property _UseBufferToWrite As Boolean = True
        Private Property _WriteToFile As Boolean = True

        Public Property pathFileLog As String = ""

        Public Event ChangeValue()

        ''' <summary>
        ''' This property get / set the Save Mode
        ''' </summary>
        ''' <returns></returns>
        Public Property saveMode As TrackRuntimeModeEnum
            Get
                Return _SaveModeLocal
            End Get
            Set(value As TrackRuntimeModeEnum)
                _SaveModeLocal = value

                RaiseEvent ChangeValue()
            End Set
        End Property

        ''' <summary>
        ''' This property get / set the InstanceID of runtime
        ''' </summary>
        ''' <returns></returns>
        Public Property instanceID As String
            Get
                Return _InstanceIDLocal
            End Get
            Set(value As String)
                _InstanceIDLocal = value

                If (_PathFileLocal.Length > 0) And (_InstanceIDLocal.Length > 0) Then
                    pathFileLog = IO.Path.Combine(_PathFileLocal, _InstanceIDLocal)
                End If

                RaiseEvent ChangeValue()
            End Set
        End Property

        ''' <summary>
        ''' This property get / set the path file of track
        ''' </summary>
        ''' <returns></returns>
        Public Property pathFile As String
            Get
                Return _PathFileLocal
            End Get
            Set(value As String)
                _PathFileLocal = value

                If (_PathFileLocal.Length > 0) And (_InstanceIDLocal.Length > 0) Then
                    pathFileLog = IO.Path.Combine(_PathFileLocal, _InstanceIDLocal)
                End If

                RaiseEvent ChangeValue()
            End Set
        End Property

        ''' <summary>
        ''' This property get / set the frequency of change file 
        ''' </summary>
        ''' <returns></returns>
        Public Property changeFileEvery As Integer
            Get
                Return _ChangeFileEveryLocal
            End Get
            Set(value As Integer)
                _ChangeFileEveryLocal = value

                RaiseEvent ChangeValue()
            End Set
        End Property

        ''' <summary>
        ''' This property get / set the frequency number of registrations
        ''' </summary>
        ''' <returns></returns>
        Public Property changeNumberOfRegistrations As Integer
            Get
                Return _ChangeNumberOfRegistrationsLocal
            End Get
            Set(value As Integer)
                _ChangeNumberOfRegistrationsLocal = value

                RaiseEvent ChangeValue()
            End Set
        End Property

        ''' <summary>
        ''' This property get / set if the tracker use or not buffer to write
        ''' </summary>
        ''' <returns></returns>
        Public Property useBufferToWrite() As Boolean
            Get
                Return _UseBufferToWrite
            End Get
            Set(value As Boolean)
                _UseBufferToWrite = value

                RaiseEvent ChangeValue()
            End Set
        End Property

        Public Property writeToFile() As Boolean
            Get
                Return _WriteToFile
            End Get
            Set(value As Boolean)
                _WriteToFile = value

                RaiseEvent ChangeValue()
            End Set
        End Property

    End Class

    ''' <summary>
    ''' This class contain a configuration of a Log Rotate
    ''' </summary>
    Public Class LogRotateConfig

        Public Enum KeepFileEnum
            undefined
            nothingFiles
            onlyMainTracks
        End Enum

        Public keepLast As KeepEnum = KeepEnum.lastWeek
        Public keepFile As KeepFileEnum = KeepFileEnum.nothingFiles

    End Class

    ''' <summary>
    ''' This class contain the log stream response
    ''' </summary>
    Public Class LogStreamResponseModel
        Inherits BaseRemoteResponse

        Public Property value As New List(Of SingleActionApplication)
    End Class

    ''' <summary>
    ''' This class contain the information response model of Log Panel Parameters
    ''' </summary>
    Public Class LogPanelParametersResponseModel
        Inherits BaseRemoteResponse

        Public Property value As New LogPanelParameters
    End Class

    ''' <summary>
    ''' This class contain all element of the list Index
    ''' </summary>
    Public Class LogListModel

        ''' <summary>
        ''' This class contain the element of a single log block model
        ''' </summary>
        Public Class SingleLogBlockModel

            Public Property [name] As String = ""
            Public Property startAt As Double = 0

        End Class

        Public Property items As New List(Of SingleLogBlockModel)

        Public Function addNew(ByVal name As String, ByVal startAt As Double) As SingleLogBlockModel

            Dim item As New SingleLogBlockModel

            item.name = name
            item.startAt = startAt

            items.Add(item)

            Return item
        End Function

    End Class

    ''' <summary>
    ''' This class contain the information response model of Log Panel Parameters
    ''' </summary>
    Public Class LogListResponseModel
        Inherits BaseRemoteResponse

        Public Property value As New LogListModel
    End Class

End Namespace
