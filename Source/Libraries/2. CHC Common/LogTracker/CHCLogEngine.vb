Option Compare Text
Option Explicit On

' ****************************************
' Engine: Log Engine
' Release Engine: 1.0 
' 
' Date last successfully test: 02/02/2022
' ****************************************

Imports CHCModelsLibrary.AreaModel.Log



Namespace AreaEngine.Log

    ''' <summary>
    ''' This class contain all element of tracking
    ''' </summary>
    Public Class TrackEngine

        Private Property _BootstrapMode As Boolean = True
        Private Property _Cache As New TrackCacheEngine


        Public WithEvents settings As New TrackConfiguration
        Public Property registryService As CHCCommonLibrary.AreaEngine.Registry.RegistryEngine


        ''' <summary>
        ''' This method provide to manage a data into cache
        ''' </summary>
        ''' <returns></returns>
        Private Function addNewDataCache(ByVal action As ActionEnumeration, ByVal message As String, Optional ByVal position As String = "") As Boolean
            Try
                Dim item As New SingleActionApplication

                With item
                    .instant = Miscellaneous.timeStampFromDateTime()
                    .action = action
                    .message = message
                    .position = position
                    .duringBootstrap = _BootstrapMode
                End With

                Return _Cache.addNewDataCache(item)
            Catch ex As Exception
                Return False
            End Try
        End Function


        ''' <summary>
        ''' This method provide to add an message into cache data for the console
        ''' </summary>
        ''' <param name="message"></param>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Public Function trackIntoConsole(Optional ByVal message As String = "") As Boolean
            Return addNewDataCache(ActionEnumeration.printIntoConsole, message)
        End Function

        ''' <summary>
        ''' This method provide to track the enter in the method
        ''' </summary>
        ''' <param name="completeName"></param>
        ''' <param name="addictionalInformation"></param>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Public Function trackEnter(ByVal completeName As String, Optional ByVal addictionalInformation As String = "", Optional ByVal count As Boolean = False) As Boolean
            Return addNewDataCache(ActionEnumeration.enterIntoMethod, addictionalInformation, completeName)
        End Function

        ''' <summary>
        ''' This method provide to track the exit in the method
        ''' </summary>
        ''' <param name="completeName"></param>
        ''' <param name="addictionalInformation"></param>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Public Function trackExit(ByVal completeName As String, Optional ByVal addictionalInformation As String = "", Optional ByVal count As Boolean = False) As Boolean
            Return addNewDataCache(ActionEnumeration.exitFromTheMethod, addictionalInformation, completeName)
        End Function

        ''' <summary>
        ''' This method provide to track the exception during execute code
        ''' </summary>
        ''' <param name="completeName"></param>
        ''' <param name="errorMessage"></param>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Public Function trackException(ByVal completeName As String, ByVal errorMessage As String) As Boolean
            If addNewDataCache(ActionEnumeration.exception, errorMessage, completeName) Then
                If Not IsNothing(registryService) Then
                    Return registryService.addNew(CHCModelsLibrary.AreaModel.Registry.RegistryData.TypeEvent.applicationError, errorMessage, completeName)
                End If

                Return True
            End If

            Return False
        End Function

        ''' <summary>
        ''' This method provide to annotate a generic note during execute code
        ''' </summary>
        ''' <param name="completeName"></param>
        ''' <param name="addictionalInformation"></param>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Public Function track(ByVal completeName As String, Optional ByVal addictionalInformation As String = "") As Boolean
            Return addNewDataCache(ActionEnumeration.genericTrack, addictionalInformation, completeName)
        End Function

        ''' <summary>
        ''' This method provide to change in bootstrap set a complete 
        ''' </summary>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Public Function changeInBootStrapComplete() As Boolean
            _BootstrapMode = False

            Return _Cache.changeInBootStrapComplete()
        End Function

        ''' <summary>
        ''' This method provide to retrieve a data newer 
        ''' </summary>
        ''' <param name="fromTime"></param>
        ''' <param name="consoleMode"></param>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Public Function getDataNewer(ByVal fromTime As Double, ByVal consoleMode As Boolean) As List(Of SingleActionApplication)
            Return _Cache.getDataFrom(consoleMode, fromTime)
        End Function

        ''' <summary>
        ''' This method provide to force a write a file 
        ''' </summary>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Public Function writeCacheToLogFile() As Boolean
            Return _Cache.writeCacheToLogFile()
        End Function

        ''' <summary>
        ''' This method provide to add a marker in log file to decode
        ''' </summary>
        ''' <param name="name"></param>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Public Function trackMarker(ByVal name As String) As Boolean
            Return addNewDataCache(ActionEnumeration.trackMarker, "", name)
        End Function


        Private Sub settings_ChangeValue() Handles settings.ChangeValue
            _Cache.changeSettings(settings)
        End Sub

    End Class

End Namespace
