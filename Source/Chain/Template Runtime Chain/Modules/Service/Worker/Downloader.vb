Option Explicit On
Option Compare Text

Imports CHCCommonLibrary.AreaEngine.Communication
Imports CHCCommonLibrary.AreaCommon.Models.General




Namespace AreaWorker

    Module Downloader

        Private Enum EnumResponseGet
            inError
            connectionFailed
            connectionSuccessfully
        End Enum

        Public Property workerOn As Boolean = False



        ''' <summary>
        ''' This method provide to test a Masternode
        ''' </summary>
        ''' <param name="addressValue"></param>
        ''' <returns></returns>
        Private Function testMasterNode(ByVal addressValue As String) As Boolean
            Try
                Dim remote As New ProxyWS(Of RemoteResponse)

                remote.url = addressValue & "/service/test"

                If (remote.getData() = "") Then
                    Return (remote.data.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete)
                Else
                    AreaCommon.log.track("Downloader.testMasterNode", "Connection failed url = " & remote.url, "fatal")

                    Return False
                End If

                remote = Nothing
            Catch ex As Exception
                AreaCommon.log.track("Downloader.testMasterNode", ex.Message, "fatal")

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to get a request with code A0X0
        ''' </summary>
        ''' <param name="addressValue"></param>
        ''' <param name="value"></param>
        ''' <returns></returns>
        Private Function getRequestA0x0(ByVal addressValue As String, ByRef value As String, Optional ByVal dontRetry As Boolean = False) As EnumResponseGet
            Try
                Dim remote As New ProxyWS(Of AreaProtocol.A0x0.RequestResponseModel)
                Dim proceed As Boolean = True

                remote.url = addressValue & "/requests/a0x0/?hashValue=" & value

                If proceed Then
                    proceed = (remote.getData() = "")
                End If
                If proceed Then
                    proceed = (remote.data.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete)
                Else
                    AreaCommon.log.track("Downloader.getRequestA0x0", "Connection failed url = " & remote.url, "fatal")

                    If dontRetry Then
                        Return EnumResponseGet.connectionFailed
                    Else
                        If testMasterNode(addressValue) Then
                            Return getRequestA0x0(addressValue, value, True)
                        Else
                            Return EnumResponseGet.connectionFailed
                        End If
                    End If
                End If
                If proceed Then
                    proceed = (remote.data.netName.Length > 0)
                End If
                If proceed Then
                    If AreaProtocol.A0x0.Manager.saveTemporallyRequest(remote.data) Then
                        AreaCommon.log.track("Downloader.getRequestA0x0", "request - Saved")

                        Return EnumResponseGet.connectionSuccessfully
                    Else
                        AreaCommon.log.track("Downloader.getRequestA0x0", "Request not saved", "fatal")

                        Return EnumResponseGet.inError
                    End If
                Else
                    AreaCommon.log.track("Downloader.getRequestA0x0", "Request not found", "fatal")

                    Return EnumResponseGet.inError
                End If

                remote = Nothing
            Catch ex As Exception
                AreaCommon.log.track("Downloader.getRequestA0x0", ex.Message, "fatal")

                Return EnumResponseGet.inError
            End Try
        End Function

        ''' <summary>
        ''' This method provide to download a specific request
        ''' </summary>
        ''' <param name="value"></param>
        ''' <returns></returns>
        Private Function downloadRequest(ByRef value As AreaFlow.RequestExtended) As Boolean
            Try
                AreaCommon.log.track("Downloader.downloadRequest", "Begin")

                Dim response As EnumResponseGet

                If Not value.directRequest Then
                    Dim baseAddress As String = AreaCommon.state.runtimeState.getDataPeer(value.notifiedPublicAddress).ipAddress

                    If (baseAddress.Length = 0) Then
                        Return False
                    End If

                    Select Case value.requestCode
                        Case "a0x0" : response = getRequestA0x0(baseAddress, value.requestHash)
                    End Select

                    If (response = EnumResponseGet.connectionFailed) Then
                        AreaCommon.flow.repositionDownload(value.requestHash, value.notifiedPublicAddress)

                        Return False
                    Else
                        Return True
                    End If
                End If

                AreaCommon.log.track("Downloader.downloadRequest", "Complete")

                Return False
            Catch ex As Exception
                AreaCommon.log.track("Downloader.downloadRequest", ex.Message, "fatal")

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to execute a job of downloader action
        ''' </summary>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()>
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
                AreaCommon.log.track("Downloader.work", ex.Message, "fatal")

                Return False
            End Try
        End Function

    End Module

End Namespace
