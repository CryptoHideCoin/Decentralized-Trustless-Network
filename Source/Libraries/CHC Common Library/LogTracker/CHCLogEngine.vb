Option Compare Text
Option Explicit On

' ****************************************
' Engine: Log Engine
' Release Engine: 1.0 
' 
' Date last successfully test: 02/10/2021
' ****************************************



Namespace AreaEngine.Log

    ''' <summary>
    ''' This class contain all element of tracking
    ''' </summary>
    Public Class TrackEngine

        Private Property _BootstrapMode As Boolean = True
        Private Property _Cache As New TrackCacheEngine


        Public WithEvents settings As New TrackConfiguration


        ''' <summary>
        ''' This method provide to add an message into cache data for the console
        ''' </summary>
        ''' <param name="message"></param>
        ''' <returns></returns>
        Public Function trackIntoConsole(Optional ByVal message As String = "") As Boolean
            Try
                Dim item As New SingleActionApplication

                With item
                    .instant = Miscellaneous.timeStampFromDateTime()
                    .action = ActionEnumeration.printIntoConsole
                    .message = message
                End With

                Return _Cache.addNewDataCache(item)
            Catch ex As Exception
                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to track the enter in the method
        ''' </summary>
        ''' <param name="completeName"></param>
        ''' <param name="addictionalInformation"></param>
        ''' <returns></returns>
        Public Function trackEnter(ByVal completeName As String, Optional ByVal addictionalInformation As String = "") As Boolean
            Try
                Dim item As New SingleActionApplication

                With item
                    .instant = Miscellaneous.timeStampFromDateTime()
                    .action = ActionEnumeration.enterIntoMethod
                    .position = completeName
                    .message = addictionalInformation
                End With

                Return _Cache.addNewDataCache(item)
            Catch ex As Exception
                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to track the exit in the method
        ''' </summary>
        ''' <param name="completeName"></param>
        ''' <param name="addictionalInformation"></param>
        ''' <returns></returns>
        Public Function trackExit(ByVal completeName As String, Optional ByVal addictionalInformation As String = "") As Boolean
            Try
                Dim item As New SingleActionApplication

                With item
                    .instant = Miscellaneous.timeStampFromDateTime()
                    .action = ActionEnumeration.exitIntoMethod
                    .position = completeName
                    .message = addictionalInformation
                End With

                Return _Cache.addNewDataCache(item)
            Catch ex As Exception
                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to track the exception during execute code
        ''' </summary>
        ''' <param name="completeName"></param>
        ''' <param name="errorMessage"></param>
        ''' <returns></returns>
        Public Function trackException(ByVal completeName As String, ByVal errorMessage As String) As Boolean
            Try
                Dim item As New SingleActionApplication

                With item
                    .instant = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()
                    .action = ActionEnumeration.exception
                    .position = completeName
                    .message = errorMessage
                End With

                Return _Cache.addNewDataCache(item)
            Catch ex As Exception
                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to annotate a generic note during execute code
        ''' </summary>
        ''' <param name="completeName"></param>
        ''' <param name="addictionalInformation"></param>
        ''' <returns></returns>
        Public Function track(ByVal completeName As String, Optional ByVal addictionalInformation As String = "") As Boolean
            Try
                Dim item As New SingleActionApplication

                With item
                    .instant = Miscellaneous.timeStampFromDateTime()
                    .action = ActionEnumeration.genericTrack
                    .position = completeName
                    .message = addictionalInformation
                End With

                Return _Cache.addNewDataCache(item)
            Catch ex As Exception
                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to change in bootstrap set a complete 
        ''' </summary>
        ''' <returns></returns>
        Public Function changeInBootStrapComplete() As Boolean
            _BootstrapMode = False

            Return _Cache.changeInBootStrapComplete()
        End Function

        ''' <summary>
        ''' This method provide to retrieve a data newer 
        ''' </summary>
        ''' <param name="fromTime"></param>
        ''' <param name="consoleMode"></param>
        ''' <returns></returns>
        Public Function getDataNewer(ByVal fromTime As Double, ByVal consoleMode As Boolean) As List(Of SingleActionApplication)
            Return _Cache.getDataFrom(fromTime, consoleMode)
        End Function

        Private Sub settings_ChangeValue() Handles settings.ChangeValue
            _Cache.changeSettings(settings)
        End Sub
    End Class

End Namespace
