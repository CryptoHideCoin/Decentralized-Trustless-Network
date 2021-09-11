Option Explicit On
Option Compare Text

Imports CHCCommonLibrary.AreaEngine.Communication



Public Class Downloader

    Public Property workerOn As Boolean = False



    Private Function getRequestA0x0(ByVal addressValue As String, ByRef value As String) As Boolean
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

                        Return True
                    Else
                        AreaCommon.log.track("Requester.getRequestA0x0", "Request not saved", "error")
                    End If
                Else
                    AreaCommon.log.track("Requester.getRequestA0x0", "Request not found", "error")
                End If
            Else
                AreaCommon.log.track("Requester.getRequestA0x0", "Connection failed url = " & remote.url, "error")
            End If

            remote = Nothing

            Return False
        Catch ex As Exception
            AreaCommon.log.track("Requester.getRequestA0x0", "Error:" & ex.Message, "error")

            Return False
        End Try
    End Function

    Private Function getBaseAddress(ByVal value As String) As String
        Try
            ' Wait to create internal list

            Return value
        Catch ex As Exception
            AreaCommon.log.track("Requester.getBaseAddress", "Error:" & ex.Message, "error")

            Return False
        End Try
    End Function

    Private Function downloadRequest(ByRef value As AreaFlow.RequestExtended) As Boolean
        Try
            value.requestPosition = AreaFlow.RequestExtended.EnumOperationFase.downloadRequestCheck

            If Not value.directRequest Then
                Select Case value.requestCode
                    Case "a0x0"
                        If getRequestA0x0(getBaseAddress(value.externalSource), value.requestHash) Then
                            Return True
                        End If
                End Select
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
            Dim item As AreaFlow.FlowEngine.RequestToDownload
            Dim proceed As Boolean = True

            AreaCommon.log.track("Downloader.work", "Begin")

            workerOn = True

            Do While (AreaCommon.flow.workerOn And workerOn)
                item = AreaCommon.flow.getFirstRequestToDownload()

                If (item.requestHash.Length > 0) Then
                    proceed = True



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

End Class
