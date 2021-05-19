'Imports System.Web.Http

'Imports CHCProtocolLibrary.AreaCommon.Models.Settings



'Namespace Controllers


'    ' GET: api/v1.0/System/MasternodeInfoController
'    <Route("SystemApi")>
'    Public Class MasternodeInfoController

'        Inherits ApiController




'        Public Function GetValue() As AreaCommon.Models.Network.SingleNodeResponseModel

'            Dim result As New AreaCommon.Models.Network.SingleNodeResponseModel

'            Try

'                If (AreaCommon.state.service = AreaCommon.Models.ServiceModel.InformationResponseModel.enumServiceState.started) Then

'                    If AreaCommon.settings.data.intranetMode Then
'                        result.addressIP = AreaCommon.state.localIpAddress
'                    Else
'                        result.addressIP = AreaCommon.state.publicIpAddress
'                    End If

'                    result.walletID = AreaCommon.settings.data.walletAddress

'                    result.response.error = False
'                    result.response.offline = False
'                Else
'                    result.response.error = True
'                    result.response.offline = True
'                End If

'            Catch ex As Exception
'                result.response.error = True
'                result.response.offline = True
'            End Try

'            Return result

'        End Function


'    End Class


'End Namespace

