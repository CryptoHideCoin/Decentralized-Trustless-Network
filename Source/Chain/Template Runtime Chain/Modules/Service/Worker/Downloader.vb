Option Explicit On
Option Compare Text

Imports CHCCommonLibrary.AreaEngine.Communication


Namespace AreaWorker

    Module Downloader

        Private Class ResponseGet

            Public Property connectionFailed As Boolean = False
            Public Property proceed As Boolean = False

        End Class

        Public Property workerOn As Boolean = False


        Private Function getRequestA0x0(ByVal addressValue As String, ByRef value As String) As ResponseGet
            Dim response As New ResponseGet

            Try
                Dim remote As New ProxyWS(Of AreaProtocol.A0x0.RequestModel)
                Dim requestFileEngine As New AreaProtocol.A0x0.FileEngine

                remote.url = addressValue & "/requests/a0x0/?hashValue=" & value

                Dim rt As String = CHCCommonLibrary.AreaEngine.Miscellaneous.atMomentGMT

                If (remote.getData() = "") Then
                    If (remote.data.netName.Length > 0) Then

                        requestFileEngine.data = remote.data

                        requestFileEngine.fileName = IO.Path.Combine(AreaCommon.paths.workData.temporally, value & ".request")

                        If requestFileEngine.save() Then
                            AreaCommon.log.track("Requester.getRequestA0x0", "request - Saved")

                            response.proceed = True
                        Else
                            AreaCommon.log.track("Requester.getRequestA0x0", "Request not saved", "error")
                            response.proceed = False
                        End If
                    Else
                        AreaCommon.log.track("Requester.getRequestA0x0", "Request not found", "error")
                        response.proceed = False
                    End If
                Else
                    AreaCommon.log.track("Requester.getRequestA0x0", "Connection failed url = " & remote.url, "error")

                    response.connectionFailed = True
                End If

                remote = Nothing
            Catch ex As Exception
                AreaCommon.log.track("Requester.getRequestA0x0", "Error:" & ex.Message, "error")

                response.proceed = False
            End Try

            Return response
        End Function

        Private Function getBaseAddress(ByVal value As String) As String
            Try
                Return AreaCommon.state.runtimeState.getDataPeer(value).ipAddress
            Catch ex As Exception
                AreaCommon.log.track("Requester.getBaseAddress", "Error:" & ex.Message, "error")

                Return False
            End Try
        End Function

        Private Function downloadRequest(ByRef value As AreaFlow.RequestExtended) As Boolean
            Try
                Dim response As New ResponseGet

                If Not value.directRequest Then
                    Select Case value.requestCode
                        Case "a0x0"
                            response = getRequestA0x0(getBaseAddress(value.externalSource), value.requestHash)
                    End Select

                    If response.connectionFailed Then
                        AreaCommon.flow.repositionDownload(value.requestHash, value.externalSource)

                        Return False
                    End If
                Else
                    Return True
                End If

                Return False
            Catch ex As Exception
                AreaCommon.log.track("Requester.formalCheck", "Error:" & ex.Message, "error")

                Return False
            End Try
        End Function


        Public Function work() As Boolean
            Try
                Dim item As AreaFlow.RequestExtended
                Dim proceed As Boolean = True

                AreaCommon.log.track("Downloader.work", "Begin")

                workerOn = True

                Do While (AreaCommon.flow.workerOn And workerOn)
                    item = AreaCommon.flow.getFirstRequestToDownload()

                    If (item.requestHash.Length > 0) Then
                        proceed = True

                        If proceed Then proceed = downloadRequest(item)
                        If proceed Then proceed = AreaCommon.flow.setRequestToSelect(item)
                    End If

                    Threading.Thread.Sleep(10)
                Loop

                workerOn = False

                AreaCommon.log.track("Downloader.work", "Complete")

                Return True
            Catch ex As Exception
                AreaCommon.log.track("Downloader.work", "Error:" & ex.Message, "error")

                Return False
            End Try
        End Function

    End Module

End Namespace
