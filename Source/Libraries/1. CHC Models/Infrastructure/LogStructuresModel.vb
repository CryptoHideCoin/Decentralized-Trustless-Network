Option Compare Text
Option Explicit On

' ****************************************
' Engine: Log Model
' Release Engine: 1.0 
' 
' Date last successfully test: 13/03/2022
' ****************************************

Imports CHCModels.AreaModel.Network.Response



Namespace AreaModel.Log

    ''' <summary>
    ''' This enumeration contain the type of log row
    ''' </summary>
    Public Enum ActionEnumeration
        notDefined
        printIntoConsole
        enterIntoMethod
        exitIntoMethod
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
        neverTrace
        trackOnlyBootstrapAndError
        trackAll
    End Enum

    ''' <summary>
    ''' This enum contain the log file that we want to mantain
    ''' </summary>
    Public Enum KeepEnum
        lastDay
        lastWeek
        lastMonth
        lastYear
    End Enum


    ''' <summary>
    ''' This class contain the element of a single action of application
    ''' </summary>
    Public Class SingleActionApplication
        Public Property instant As Double = 0
        Public Property action As ActionEnumeration = ActionEnumeration.notDefined
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
                Case ActionEnumeration.exitIntoMethod : tmp += "Exit into method|"
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
            End Set
        End Property

    End Class

    ''' <summary>
    ''' This class contain a configuration of a Log Rotate
    ''' </summary>
    Public Class LogRotateConfig

        Public Enum FrequencyEnum
            every12h
            everyDay
        End Enum

        Public Enum KeepFileEnum
            nothingFiles
            onlyMainTracks
        End Enum

        Public frequency As FrequencyEnum
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

End Namespace
