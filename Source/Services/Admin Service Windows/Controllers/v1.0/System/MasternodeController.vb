Option Compare Text
Option Explicit On

Imports System.Web.Http
Imports CHCCommonLibrary.AreaEngine
Imports CHCProtocolLibrary.AreaBase
Imports CHCProtocolLibrary.AreaCommon




Namespace Controllers


    ' GET: api/v1.0/System/InfoMasternodeController
    ''' <summary>
    ''' This API permit a client to know if the Masternode is in work mode or not
    ''' </summary>
    <Route("SystemApi")>
    Public Class InfoMasternodeController

        Inherits ApiController



        Private Function getDataFromRuntime() As AreaCommon.Models.Masternode.NodeInformation

            Dim result As New AreaCommon.Models.Masternode.NodeInformation

            Try

                If (AreaCommon.settings.data.serviceRuntime.url.Trim.Length > 0) Then

                    Dim remote As New Communication.ProxyWS(Of AreaCommon.Models.Masternode.NodeInformation)

                    remote.url = AreaCommon.settings.data.serviceRuntime.composeURL("/api/v1.0/system/MasternodeInfo")

                    If (remote.getData() = "") Then
                        Return remote.data
                    Else
                        Throw New Exception("InfoMasternodeController.getDataFromRuntime(): Error connection")
                    End If

                Else
                    Throw New Exception("InfoMasternodeController.getDataFromRuntime(): data no set")
                End If

            Catch ex As Exception
                Throw New Exception("InfoMasternodeController.getDataFromRuntime(): " & ex.Message, ex)
            End Try

        End Function



        Public Function GetValue(ByVal certificate As String) As AreaCommon.Models.Masternode.InfoModel

            Dim result As New AreaCommon.Models.Masternode.InfoModel

            Try

                If AreaSecurity.authorization.checkClientCertification(certificate) Then

                    If (AreaCommon.state.currentApplication = Models.Settings.EnumStateApplication.inRunning) Then

                        result.masternodeLocalTime = Now & " - " & Miscellaneous.atMomentGMT()
                        result.platformHost = "Microsoft Windows / Desktop application"
                        result.publicWalletAddress = AreaCommon.settings.data.walletPublicAddress
                        result.protocolRelease = "rel. " & InfoSystem.ProtocolRelease
                        result.softwareRelease = "rel. " & InfoSystem.ApplicationRelease

                        Try

                            With getDataFromRuntime()

                                result.currentStatus = "Online"

                                For Each singleService In .serviceList

                                    Select Case singleService.type

                                        Case AreaCommon.Models.Masternode.NodeInformation.EnumPeerServiceType.dns : result.serviceOffered += "Dns, "
                                        Case AreaCommon.Models.Masternode.NodeInformation.EnumPeerServiceType.exChange : result.serviceOffered += "Exchange, "
                                        Case AreaCommon.Models.Masternode.NodeInformation.EnumPeerServiceType.file : result.serviceOffered += "Storage, "
                                        Case AreaCommon.Models.Masternode.NodeInformation.EnumPeerServiceType.service : result.serviceOffered += "Chain, "
                                        Case AreaCommon.Models.Masternode.NodeInformation.EnumPeerServiceType.thanksTo : result.serviceOffered += "Thanks to, "
                                        Case AreaCommon.Models.Masternode.NodeInformation.EnumPeerServiceType.vote : result.serviceOffered += "Vote, "

                                    End Select

                                Next

                                result.serviceOffered += "Public"

                                result.virtualName = .virtualName
                                result.ipAddress = .address

                            End With

                        Catch ex As Exception

                            result.currentStatus = "off"
                            result.serviceOffered = "n.a."
                            result.virtualName = "n.a."
                            result.ipAddress = "n.a."

                        End Try

                    Else

                        result.response.error = True
                        result.response.offline = True

                    End If

                Else

                    result.response.error = True
                    result.response.unAuthorized = True

                End If

            Catch ex As Exception
            End Try

            Return result

        End Function


    End Class


End Namespace

