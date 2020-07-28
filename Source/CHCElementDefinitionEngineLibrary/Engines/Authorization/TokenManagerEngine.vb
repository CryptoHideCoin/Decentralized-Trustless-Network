Option Compare Text
Option Explicit On

Imports System.Web




Namespace CHCEngines


    Public Class TokenManagerEngine


        Public Class CompleteTokenData

            Inherits Models.Token.SingleToken

            Public secureKEY As String = ""
            Public pathTokenData As String = ""

        End Class


        Public Class ResponseCheckToken

            Public message As String = ""
            Public failed As Boolean = False

            Public token As CompleteTokenData

        End Class



        Private _logEngine As CHCServerSupport.Support.LogEngine
        Private _path As String = ""

        Private _activeTokens As New Dictionary(Of String, CompleteTokenData)




        Private Sub trackLog(ByVal position As String, ByVal content As String, Optional ByVal messageType As String = "info", Optional ByVal adapterLog As CHCServerSupport.Support.LogEngine = Nothing)

            If Not IsNothing(adapterLog) Then

                adapterLog.track(position, content, messageType)

            ElseIf Not IsNothing(_logEngine) Then

                _logEngine.track(position, content, messageType)

            End If

        End Sub


        'Private Function composeCompletePath(ByVal configurationName As String) As String

        '    Try

        '        Dim ext As String = System.IO.Path.GetExtension(configurationName)

        '        If (ext.Length = 0) Then

        '            configurationName += ".transChainDefinition"

        '        End If

        '        Return System.IO.Path.Combine(_Path, configurationName)

        '    Catch ex As Exception

        '    End Try

        '    Return ""

        'End Function



        Public Function canReleaseNewPublicToken(ByVal request As Object, ByRef statusObject As PeerStatusEngine) As String

            Try

                If (statusObject.currentStatus = Models.EnumPeerStatusDetail.onLine) Then

                    Return ""

                Else

                    Return "System offline"

                End If

            Catch ex As Exception

                Return ""

            End Try

        End Function



        Public Function canReleaseNewPrivateToken(ByVal request As Object, ByVal statusObject As PeerStatusEngine, ByVal apiKey As String) As String

            Try

                If (statusObject.currentStatus = Models.EnumPeerStatusDetail.onLine) Then

                    '
                    ' Controllo che l' apiKey esista tra quelle rilasciate
                    '
                    If (apiKey = "A01") Then

                        ' Sulla base delle impostazioni del rilascio dell' apiKey viene impostato o il controllo 
                        ' sulla provenienza o che sarà richiesto un successivo approfondimento
                        ' (o che non risulti in blacklist) 

                        Return ""

                    Else

                        Return "API Key or password wrong"

                    End If

                Else

                    Return "System offline"

                End If

            Catch ex As Exception

                Return ""

            End Try

        End Function



        Public Function canReleaseNewAdminToken(ByVal request As Object, ByVal statusObject As PeerStatusEngine, ByVal walletAddress As String) As String

            Try

                '
                ' Controllo che il walletAddress esista nella codifica interna
                '
                If (walletAddress = "A01") Then

                    ' Sulla base delle impostazioni del rilascio dell' apiKey viene impostato o il controllo 
                    ' sulla provenienza o che sarà richiesto un successivo approfondimento
                    ' (o che non risulti in blacklist) 

                    Return ""

                Else

                    Return "walletAddress not found"

                End If

            Catch ex As Exception

                Return ""

            End Try

        End Function



        Private Function getClientIPAddress(ByRef request As Net.Http.HttpRequestMessage) As String

            Dim httpContext As String = "MS_HttpContext"
            Dim remoteEndpointMessage As String = "System.ServiceModel.Channels.RemoteEndpointMessageProperty"

            If (request.Properties.ContainsKey(HttpContext)) Then

                Dim ctx As Object = request.Properties(HttpContext)

                If String.IsNullOrEmpty(ctx) Then

                    Return ctx.Request.UserHostAddress

                End If

            End If

            If (request.Properties.ContainsKey(RemoteEndpointMessage)) Then

                Dim remoteEndpoint As Object = request.Properties(remoteEndpointMessage)

                If String.IsNullOrEmpty(remoteEndpoint) Then

                    Return remoteEndpoint.Address

                End If

            End If

            Return ""

        End Function



        Public Function createNewPublicToken(ByRef request As Net.Http.HttpRequestMessage) As CompleteTokenData

            Dim response As New CompleteTokenData

            Try

                response.ipAddress = getClientIPAddress(request)
                response.ipAddress = response.ipAddress.Replace("::1", "localHost")

                response.momentReleased = Now
                response.momentLastActivity = response.momentReleased

                response.value = New Guid().ToString()

                response.pathTokenData = IO.Path.Combine(_path, Now.ToString("yyyy-MM-dd-hhmmss") & "-" & response.value)

                _activeTokens.Add(response.value, response)

            Catch ex As Exception

                ' Don't track this

            End Try

            Return response

        End Function



        Public Function createNewPrivateToken(ByRef request As Net.Http.HttpRequestMessage) As CompleteTokenData

            Dim response As New CompleteTokenData

            Try

                response.ipAddress = getClientIPAddress(request)
                response.ipAddress = response.ipAddress.Replace("::1", "localHost")

                response.momentReleased = Now
                response.momentLastActivity = response.momentReleased

                response.type = Models.Token.TokenType.private

                response.value = New Guid().ToString()

                response.pathTokenData = IO.Path.Combine(_path, Now.ToString("yyyy-MM-dd-hhmmss") & "-" & response.value)

                _activeTokens.Add(response.value, response)

            Catch ex As Exception

                ' Don't track this

            End Try

            Return response

        End Function


        Public Function createNewAdminToken(ByRef request As Net.Http.HttpRequestMessage) As CompleteTokenData

            Dim response As New CompleteTokenData

            Try

                response.ipAddress = getClientIPAddress(request)
                response.ipAddress = response.ipAddress.Replace("::1", "localHost")

                response.momentReleased = Now
                response.momentLastActivity = response.momentReleased

                response.type = Models.Token.TokenType.administration

                response.value = New Guid().ToString()

                response.pathTokenData = IO.Path.Combine(_path, Now.ToString("yyyy-MM-dd-hhmmss") & "-" & response.value)

                _activeTokens.Add(response.value, response)

            Catch ex As Exception

                ' Don't track this

            End Try

            Return response

        End Function



        Public Function checkAdminToken(ByRef tokenValue As String, ByRef request As Net.Http.HttpRequestMessage) As ResponseCheckToken

            Dim response As New ResponseCheckToken

            Try

                Dim ipAddress As String = ""
                Dim token As New CompleteTokenData

                If _activeTokens.ContainsKey(tokenValue) Then

                    token = _activeTokens(tokenValue)

                    If (token.testNumberAuthorizationFailed > 4) Or token.banned Then

                        response.message = "Banned token"
                        response.failed = True

                    ElseIf Not token.authorizated Then

                        response.message = "Unauthorized token"
                        response.failed = True

                        token.testNumberAuthorizationFailed += 1

                    Else

                        ipAddress = getClientIPAddress(request)
                        ipAddress = ipAddress.Replace("::1", "localHost")

                        If (token.ipAddress = ipAddress) Then

                            response.failed = False
                            response.message = ""

                            response.token.testNumberAuthorizationFailed = 0
                            response.token.authorizated = True
                            response.token.banned = False

                            response.token.momentLastActivity = Now

                        Else

                            response.message = "Banned token"
                            response.failed = True

                        End If

                    End If

                End If

            Catch ex As Exception

            End Try

            Return response

        End Function



        Public Sub New(ByVal path As String)

            Try

                _path = path

                If Not IO.Directory.Exists(_path) Then

                    IO.Directory.CreateDirectory(_path)

                End If

                _path = IO.Path.Combine(_path, "System")

                If Not IO.Directory.Exists(_path) Then

                    IO.Directory.CreateDirectory(_path)

                End If

                _path = IO.Path.Combine(_path, "Session")

                If Not IO.Directory.Exists(_path) Then

                    IO.Directory.CreateDirectory(_path)

                End If

            Catch ex As Exception

            End Try

        End Sub


    End Class




End Namespace