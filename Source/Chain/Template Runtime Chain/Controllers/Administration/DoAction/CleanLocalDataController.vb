Option Compare Text
Option Explicit On


Imports System.Web.Http
Imports CHCCommonLibrary.AreaCommon.Models
Imports CHCProtocolLibrary.AreaCommon




Namespace Controllers


    ' GET: API/{GUID service}/Administration/DoAction/CleanLocalData
    <Route("AdministrationDoActionApi")>
    Public Class CleanLocalDataController

        Inherits ApiController



        ''' <summary>
        ''' This method start a Clean Local Data procedure
        ''' </summary>
        ''' <param name="signature"></param>
        ''' <returns></returns>
        Public Function getValue(ByVal signature As String) As General.RemoteResponse
            Dim result As New General.RemoteResponse
            Dim proceed As Boolean = True

            Try
                AreaCommon.log.track("CleanLocalDataController.getValue", "Begin")

                result.requestTime = CHCCommonLibrary.AreaEngine.Miscellaneous.atMomentGMT()

                If proceed Then
                    If (AreaCommon.state.service <> Models.Service.InformationResponseModel.EnumInternalServiceState.started) Then
                        result.responseStatus = General.RemoteResponse.EnumResponseStatus.systemOffline

                        proceed = False
                    End If
                End If
                If proceed Then
                    If Not AreaSecurity.checkSignature(signature) Then
                        result.responseStatus = General.RemoteResponse.EnumResponseStatus.missingAuthorization

                        proceed = False
                    End If
                End If
                If proceed Then
                    For Each item In AreaCommon.state.currentService.listAvailableCommand
                        If (item = CHCProtocolLibrary.AreaCommon.Models.Administration.EnumActionAdministration.cleanLocalData) Then
                            AreaCommon.state.currentService.currentRunCommand = CHCProtocolLibrary.AreaCommon.Models.Administration.EnumActionAdministration.cleanLocalData

                            AreaCommon.state.currentService.listAvailableCommand.Clear()
                            AreaCommon.state.currentService.listAvailableCommand.Add(CHCProtocolLibrary.AreaCommon.Models.Administration.EnumActionAdministration.cancelCurrentAction)

                            Dim ais As New Threading.Thread(AddressOf AreaData.cleanLocalData)

                            ais.Start()

                            result.responseStatus = General.RemoteResponse.EnumResponseStatus.responseComplete

                            Exit For
                        End If
                    Next

                    If (result.responseStatus <> General.RemoteResponse.EnumResponseStatus.responseComplete) Then
                        result.responseStatus = General.RemoteResponse.EnumResponseStatus.commandNotAllowed
                    End If
                End If

                AreaCommon.log.track("CleanLocalDataController.getValue", "Complete")
            Catch ex As Exception
                result.responseStatus = General.RemoteResponse.EnumResponseStatus.inError
                result.errorDescription = "503 - Generic Error"

                AreaCommon.log.track("CleanLocalDataController.getValue", "An error occurrent during execute: " & ex.Message, "fatal")
            End Try

            result.responseTime = CHCCommonLibrary.AreaEngine.Miscellaneous.atMomentGMT()

            Return result
        End Function

    End Class


End Namespace