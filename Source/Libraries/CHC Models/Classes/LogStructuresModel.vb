Option Compare Text
Option Explicit On

' ****************************************
' Engine: Log Model
' Release Engine: 1.0 
' 
' Date last successfully test: 21/02/2022
' ****************************************



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
        Private Property _IstanceIDLocal As String = ""
        Private Property _PathFileLocal As String = ""
        Private Property _ChangeFileEveryLocal As Integer = 0
        Private Property _ChangeNumberOfRegistrationsLocal As Integer = 0

        Public Property pathFileLog As String = ""

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
