﻿Option Compare Text
Option Explicit On

' ****************************************
' Engine: Log Cache
' Release Engine: 1.0 
' 
' Date last successfully test: 05/02/2022
' ****************************************



Namespace AreaEngine.Log

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
    ''' This class contain the element of a single action of application
    ''' </summary>
    Public Class SingleActionApplication
        Public Property instant As Double = 0
        Public Property action As ActionEnumeration = ActionEnumeration.notDefined
        Public Property position As String = ""
        Public Property message As String = ""

        ''' <summary>
        ''' This method provide to create a string resultant
        ''' </summary>
        ''' <returns></returns>
        Public Overrides Function toString() As String
            Return instant.ToString() & "|" & action & "|" & position & "|" & message
        End Function
    End Class

    ''' <summary>
    ''' This class contain the track configuration
    ''' </summary>
    Public Class TrackConfiguration
        Private Property _SaveModeLocal As TrackRuntimeModeEnum = TrackRuntimeModeEnum.trackAll
        Private Property _IstanceIDLocal As String = ""
        Private Property _PathFileLocal As String = ""
        Private Property _ChangeFileEveryLocal As Integer = 0
        Private Property _ChangeNumberOfRegistrationsLocal As Integer = 0

        Friend Property pathFileLog As String = ""

        Public Event ChangeValue()

        Public Property saveMode As TrackRuntimeModeEnum
            Get
                Return _SaveModeLocal
            End Get
            Set(value As TrackRuntimeModeEnum)
                _SaveModeLocal = value

                RaiseEvent ChangeValue()
            End Set
        End Property

        Public Property istanceID As String
            Get
                Return _IstanceIDLocal
            End Get
            Set(value As String)
                _IstanceIDLocal = value

                If (_PathFileLocal.Length > 0) And (_IstanceIDLocal.Length > 0) Then
                    pathFileLog = IO.Path.Combine(_PathFileLocal, _IstanceIDLocal)
                End If

                RaiseEvent ChangeValue()
            End Set
        End Property

        Public Property pathFile As String
            Get
                Return _PathFileLocal
            End Get
            Set(value As String)
                _PathFileLocal = value

                If (_PathFileLocal.Length > 0) And (_IstanceIDLocal.Length > 0) Then
                    pathFileLog = IO.Path.Combine(_PathFileLocal, _IstanceIDLocal)
                End If

                RaiseEvent ChangeValue()
            End Set
        End Property
        Public Property changeFileEvery As Integer
            Get
                Return _ChangeFileEveryLocal
            End Get
            Set(value As Integer)
                _ChangeFileEveryLocal = value

                RaiseEvent ChangeValue()
            End Set
        End Property
        Public Property changeNumberOfRegistrations As Integer
            Get
                Return _ChangeNumberOfRegistrationsLocal
            End Get
            Set(value As Integer)
                _ChangeNumberOfRegistrationsLocal = value

                RaiseEvent ChangeValue()
            End Set
        End Property
    End Class

End Namespace