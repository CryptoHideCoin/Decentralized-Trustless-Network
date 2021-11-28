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
                AreaCommon.log.track("Downloader.testMasterNode", "Begin")

                Dim remote As New ProxyWS(Of RemoteResponse)

                remote.url = addressValue & "/service/test"

                If (remote.getData() = "") Then
                    Return (remote.data.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete)
                Else
                    AreaCommon.log.track("Downloader.testMasterNode", "Connection failed url = " & remote.url, "fatal")

                    Return False
                End If

                AreaCommon.log.track("Downloader.testMasterNode", "Complete")

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
                AreaCommon.log.track("Downloader.getRequestA0x0", "Begin")

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
                    proceed = (remote.data.content.netName.Length > 0)
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

                AreaCommon.log.track("Downloader.getRequestA0x0", "Complete")

                remote = Nothing
            Catch ex As Exception
                AreaCommon.log.track("Downloader.getRequestA0x0", ex.Message, "fatal")

                Return EnumResponseGet.inError
            End Try
        End Function

        ''' <summary>
        ''' This method provide to get a request with code A0X1
        ''' </summary>
        ''' <param name="addressValue"></param>
        ''' <param name="value"></param>
        ''' <param name="dontRetry"></param>
        ''' <returns></returns>
        Private Function getRequestA0x1(ByVal addressValue As String, ByVal value As String, Optional ByVal dontRetry As Boolean = False) As EnumResponseGet
            Try
                AreaCommon.log.track("Downloader.getRequestA0x1", "Begin")

                Dim remote As New ProxyWS(Of AreaProtocol.A0x1.RequestResponseModel)
                Dim proceed As Boolean = True

                remote.url = addressValue & "/requests/a0x1/?hashValue=" & value

                If proceed Then
                    proceed = (remote.getData() = "")
                End If
                If proceed Then
                    proceed = (remote.data.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete)
                Else
                    AreaCommon.log.track("Downloader.getRequestA0x1", "Connection failed url = " & remote.url, "fatal")

                    If dontRetry Then
                        Return EnumResponseGet.connectionFailed
                    Else
                        If testMasterNode(addressValue) Then
                            Return getRequestA0x1(addressValue, value, True)
                        Else
                            Return EnumResponseGet.connectionFailed
                        End If
                    End If
                End If
                If proceed Then
                    proceed = (remote.data.whitePaper.Length > 0)
                End If
                If proceed Then
                    If AreaProtocol.A0x1.Manager.saveTemporallyRequest(remote.data) Then
                        AreaCommon.log.track("Downloader.getRequestA0x1", "request - Saved")

                        Return EnumResponseGet.connectionSuccessfully
                    Else
                        AreaCommon.log.track("Downloader.getRequestA0x1", "Request not saved", "fatal")

                        Return EnumResponseGet.inError
                    End If
                Else
                    AreaCommon.log.track("Downloader.getRequestA0x1", "Request not found", "fatal")

                    Return EnumResponseGet.inError
                End If

                AreaCommon.log.track("Downloader.getRequestA0x1", "Complete")

                remote = Nothing
            Catch ex As Exception
                AreaCommon.log.track("Downloader.getRequestA0x1", ex.Message, "fatal")

                Return EnumResponseGet.inError
            End Try
        End Function

        ''' <summary>
        ''' This method provide to get a request with code A0X2
        ''' </summary>
        ''' <param name="addressValue"></param>
        ''' <param name="value"></param>
        ''' <param name="dontRetry"></param>
        ''' <returns></returns>
        Private Function getRequestA0x2(ByVal addressValue As String, ByVal value As String, Optional ByVal dontRetry As Boolean = False) As EnumResponseGet
            Try
                AreaCommon.log.track("Downloader.getRequestA0x2", "Begin")

                Dim remote As New ProxyWS(Of AreaProtocol.A0x2.RequestResponseModel)
                Dim proceed As Boolean = True

                remote.url = addressValue & "/requests/a0x2/?hashValue=" & value

                If proceed Then
                    proceed = (remote.getData() = "")
                End If
                If proceed Then
                    proceed = (remote.data.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete)
                Else
                    AreaCommon.log.track("Downloader.getRequestA0x2", "Connection failed url = " & remote.url, "fatal")

                    If dontRetry Then
                        Return EnumResponseGet.connectionFailed
                    Else
                        If testMasterNode(addressValue) Then
                            Return getRequestA0x2(addressValue, value, True)
                        Else
                            Return EnumResponseGet.connectionFailed
                        End If
                    End If
                End If
                If proceed Then
                    proceed = (remote.data.yellowPaper.Length > 0)
                End If
                If proceed Then
                    If AreaProtocol.A0x2.Manager.saveTemporallyRequest(remote.data) Then
                        AreaCommon.log.track("Downloader.getRequestA0x2", "request - Saved")

                        Return EnumResponseGet.connectionSuccessfully
                    Else
                        AreaCommon.log.track("Downloader.getRequestA0x2", "Request not saved", "fatal")

                        Return EnumResponseGet.inError
                    End If
                Else
                    AreaCommon.log.track("Downloader.getRequestA0x2", "Request not found", "fatal")

                    Return EnumResponseGet.inError
                End If

                AreaCommon.log.track("Downloader.getRequestA0x2", "Complete")

                remote = Nothing
            Catch ex As Exception
                AreaCommon.log.track("Downloader.getRequestA0x2", ex.Message, "fatal")

                Return EnumResponseGet.inError
            End Try
        End Function

        ''' <summary>
        ''' This method provide to get a request with code A0X3
        ''' </summary>
        ''' <param name="addressValue"></param>
        ''' <param name="value"></param>
        ''' <param name="dontRetry"></param>
        ''' <returns></returns>
        Private Function getRequestA0x3(ByVal addressValue As String, ByVal value As String, Optional ByVal dontRetry As Boolean = False) As EnumResponseGet
            Try
                AreaCommon.log.track("Downloader.getRequestA0x3", "Begin")

                Dim remote As New ProxyWS(Of AreaProtocol.A0x3.RequestResponseModel)
                Dim proceed As Boolean = True

                remote.url = addressValue & "/requests/a0x3/?hashValue=" & value

                If proceed Then
                    proceed = (remote.getData() = "")
                End If
                If proceed Then
                    proceed = (remote.data.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete)
                Else
                    AreaCommon.log.track("Downloader.getRequestA0x3", "Connection failed url = " & remote.url, "fatal")

                    If dontRetry Then
                        Return EnumResponseGet.connectionFailed
                    Else
                        If testMasterNode(addressValue) Then
                            Return getRequestA0x3(addressValue, value, True)
                        Else
                            Return EnumResponseGet.connectionFailed
                        End If
                    End If
                End If
                If proceed Then
                    proceed = (remote.data.content.assetInformation.name.Length > 0)
                End If
                If proceed Then
                    If AreaProtocol.A0x3.Manager.saveTemporallyRequest(remote.data) Then
                        AreaCommon.log.track("Downloader.getRequestA0x3", "request - Saved")

                        Return EnumResponseGet.connectionSuccessfully
                    Else
                        AreaCommon.log.track("Downloader.getRequestA0x3", "Request not saved", "fatal")

                        Return EnumResponseGet.inError
                    End If
                Else
                    AreaCommon.log.track("Downloader.getRequestA0x3", "Request not found", "fatal")

                    Return EnumResponseGet.inError
                End If

                AreaCommon.log.track("Downloader.getRequestA0x3", "Complete")

                remote = Nothing
            Catch ex As Exception
                AreaCommon.log.track("Downloader.getRequestA0x3", ex.Message, "fatal")

                Return EnumResponseGet.inError
            End Try
        End Function

        ''' <summary>
        ''' This method provide to get a request with code A0X4
        ''' </summary>
        ''' <param name="addressValue"></param>
        ''' <param name="value"></param>
        ''' <param name="dontRetry"></param>
        ''' <returns></returns>
        Private Function getRequestA0x4(ByVal addressValue As String, ByVal value As String, Optional ByVal dontRetry As Boolean = False) As EnumResponseGet
            Try
                AreaCommon.log.track("Downloader.getRequestA0x4", "Begin")

                Dim remote As New ProxyWS(Of AreaProtocol.A0x4.RequestResponseModel)
                Dim proceed As Boolean = True

                remote.url = addressValue & "/requests/a0x4/?hashValue=" & value

                If proceed Then
                    proceed = (remote.getData() = "")
                End If
                If proceed Then
                    proceed = (remote.data.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete)
                Else
                    AreaCommon.log.track("Downloader.getRequestA0x4", "Connection failed url = " & remote.url, "fatal")

                    If dontRetry Then
                        Return EnumResponseGet.connectionFailed
                    Else
                        If testMasterNode(addressValue) Then
                            Return getRequestA0x4(addressValue, value, True)
                        Else
                            Return EnumResponseGet.connectionFailed
                        End If
                    End If
                End If
                If proceed Then
                    proceed = (remote.data.transactionChainSettings.initialCoinReleasePerBlock > 0)
                End If
                If proceed Then
                    If AreaProtocol.A0x4.Manager.saveTemporallyRequest(remote.data) Then
                        AreaCommon.log.track("Downloader.getRequestA0x4", "request - Saved")

                        Return EnumResponseGet.connectionSuccessfully
                    Else
                        AreaCommon.log.track("Downloader.getRequestA0x4", "Request not saved", "fatal")

                        Return EnumResponseGet.inError
                    End If
                Else
                    AreaCommon.log.track("Downloader.getRequestA0x4", "Request not found", "fatal")

                    Return EnumResponseGet.inError
                End If

                AreaCommon.log.track("Downloader.getRequestA0x4", "Complete")

                remote = Nothing
            Catch ex As Exception
                AreaCommon.log.track("Downloader.getRequestA0x4", ex.Message, "fatal")

                Return EnumResponseGet.inError
            End Try
        End Function

        ''' <summary>
        ''' This method provide to get a request with code A0X5
        ''' </summary>
        ''' <param name="addressValue"></param>
        ''' <param name="value"></param>
        ''' <param name="dontRetry"></param>
        ''' <returns></returns>
        Private Function getRequestA0x5(ByVal addressValue As String, ByVal value As String, Optional ByVal dontRetry As Boolean = False) As EnumResponseGet
            Try
                AreaCommon.log.track("Downloader.getRequestA0x5", "Begin")

                Dim remote As New ProxyWS(Of AreaProtocol.A0x5.RequestResponseModel)
                Dim proceed As Boolean = True

                remote.url = addressValue & "/requests/a0x5/?hashValue=" & value

                If proceed Then
                    proceed = (remote.getData() = "")
                End If
                If proceed Then
                    proceed = (remote.data.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete)
                Else
                    AreaCommon.log.track("Downloader.getRequestA0x5", "Connection failed url = " & remote.url, "fatal")

                    If dontRetry Then
                        Return EnumResponseGet.connectionFailed
                    Else
                        If testMasterNode(addressValue) Then
                            Return getRequestA0x5(addressValue, value, True)
                        Else
                            Return EnumResponseGet.connectionFailed
                        End If
                    End If
                End If
                If proceed Then
                    proceed = (remote.data.privacyPolicy.Length > 0)
                End If
                If proceed Then
                    If AreaProtocol.A0x5.Manager.saveTemporallyRequest(remote.data) Then
                        AreaCommon.log.track("Downloader.getRequestA0x5", "request - Saved")

                        Return EnumResponseGet.connectionSuccessfully
                    Else
                        AreaCommon.log.track("Downloader.getRequestA0x5", "Request not saved", "fatal")

                        Return EnumResponseGet.inError
                    End If
                Else
                    AreaCommon.log.track("Downloader.getRequestA0x5", "Request not found", "fatal")

                    Return EnumResponseGet.inError
                End If

                AreaCommon.log.track("Downloader.getRequestA0x5", "Complete")

                remote = Nothing
            Catch ex As Exception
                AreaCommon.log.track("Downloader.getRequestA0x5", ex.Message, "fatal")

                Return EnumResponseGet.inError
            End Try
        End Function

        ''' <summary>
        ''' This method provide to get a request with code A0X6
        ''' </summary>
        ''' <param name="addressValue"></param>
        ''' <param name="value"></param>
        ''' <param name="dontRetry"></param>
        ''' <returns></returns>
        Private Function getRequestA0x6(ByVal addressValue As String, ByVal value As String, Optional ByVal dontRetry As Boolean = False) As EnumResponseGet
            Try
                AreaCommon.log.track("Downloader.getRequestA0x6", "Begin")

                Dim remote As New ProxyWS(Of AreaProtocol.A0x6.RequestResponseModel)
                Dim proceed As Boolean = True

                remote.url = addressValue & "/requests/a0x6/?hashValue=" & value

                If proceed Then
                    proceed = (remote.getData() = "")
                End If
                If proceed Then
                    proceed = (remote.data.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete)
                Else
                    AreaCommon.log.track("Downloader.getRequestA0x6", "Connection failed url = " & remote.url, "fatal")

                    If dontRetry Then
                        Return EnumResponseGet.connectionFailed
                    Else
                        If testMasterNode(addressValue) Then
                            Return getRequestA0x6(addressValue, value, True)
                        Else
                            Return EnumResponseGet.connectionFailed
                        End If
                    End If
                End If
                If proceed Then
                    proceed = (remote.data.generalCondition.Length > 0)
                End If
                If proceed Then
                    If AreaProtocol.A0x6.Manager.saveTemporallyRequest(remote.data) Then
                        AreaCommon.log.track("Downloader.getRequestA0x6", "request - Saved")

                        Return EnumResponseGet.connectionSuccessfully
                    Else
                        AreaCommon.log.track("Downloader.getRequestA0x6", "Request not saved", "fatal")

                        Return EnumResponseGet.inError
                    End If
                Else
                    AreaCommon.log.track("Downloader.getRequestA0x6", "Request not found", "fatal")

                    Return EnumResponseGet.inError
                End If

                AreaCommon.log.track("Downloader.getRequestA0x6", "Complete")

                remote = Nothing
            Catch ex As Exception
                AreaCommon.log.track("Downloader.getRequestA0x6", ex.Message, "fatal")

                Return EnumResponseGet.inError
            End Try
        End Function

        ''' <summary>
        ''' This method provide to get a request with code A0X7
        ''' </summary>
        ''' <param name="addressValue"></param>
        ''' <param name="value"></param>
        ''' <param name="dontRetry"></param>
        ''' <returns></returns>
        Private Function getRequestA0x7(ByVal addressValue As String, ByVal value As String, Optional ByVal dontRetry As Boolean = False) As EnumResponseGet
            Try
                AreaCommon.log.track("Downloader.getRequestA0x7", "Begin")

                Dim remote As New ProxyWS(Of AreaProtocol.A0x7.RequestResponseModel)
                Dim proceed As Boolean = True

                remote.url = addressValue & "/requests/a0x7/?hashValue=" & value

                If proceed Then
                    proceed = (remote.getData() = "")
                End If
                If proceed Then
                    proceed = (remote.data.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete)
                Else
                    AreaCommon.log.track("Downloader.getRequestA0x7", "Connection failed url = " & remote.url, "fatal")

                    If dontRetry Then
                        Return EnumResponseGet.connectionFailed
                    Else
                        If testMasterNode(addressValue) Then
                            Return getRequestA0x7(addressValue, value, True)
                        Else
                            Return EnumResponseGet.connectionFailed
                        End If
                    End If
                End If
                If proceed Then
                    proceed = (remote.data.refundPlan.code.Length > 0)
                End If
                If proceed Then
                    If AreaProtocol.A0x7.Manager.saveTemporallyRequest(remote.data) Then
                        AreaCommon.log.track("Downloader.getRequestA0x7", "request - Saved")

                        Return EnumResponseGet.connectionSuccessfully
                    Else
                        AreaCommon.log.track("Downloader.getRequestA0x7", "Request not saved", "fatal")

                        Return EnumResponseGet.inError
                    End If
                Else
                    AreaCommon.log.track("Downloader.getRequestA0x7", "Request not found", "fatal")

                    Return EnumResponseGet.inError
                End If

                AreaCommon.log.track("Downloader.getRequestA0x7", "Complete")

                remote = Nothing
            Catch ex As Exception
                AreaCommon.log.track("Downloader.getRequestA0x7", ex.Message, "fatal")

                Return EnumResponseGet.inError
            End Try
        End Function

        ''' <summary>
        ''' This method provide to get a request with code A1X0
        ''' </summary>
        ''' <param name="addressValue"></param>
        ''' <param name="value"></param>
        ''' <param name="dontRetry"></param>
        ''' <returns></returns>
        Private Function getRequestA1x0(ByVal addressValue As String, ByVal value As String, Optional ByVal dontRetry As Boolean = False) As EnumResponseGet
            Try
                AreaCommon.log.track("Downloader.getRequestA1x0", "Begin")

                Dim remote As New ProxyWS(Of AreaProtocol.A1x0.RequestResponseModel)
                Dim proceed As Boolean = True

                remote.url = addressValue & "/requests/a1x0/?hashValue=" & value

                If proceed Then
                    proceed = (remote.getData() = "")
                End If
                If proceed Then
                    proceed = (remote.data.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete)
                Else
                    AreaCommon.log.track("Downloader.getRequestA1x0", "Connection failed url = " & remote.url, "fatal")

                    If dontRetry Then
                        Return EnumResponseGet.connectionFailed
                    Else
                        If testMasterNode(addressValue) Then
                            Return getRequestA1x0(addressValue, value, True)
                        Else
                            Return EnumResponseGet.connectionFailed
                        End If
                    End If
                End If
                If proceed Then
                    proceed = (remote.data.common.chainReferement.Length > 0)
                End If
                If proceed Then
                    If AreaProtocol.A1x0.Manager.saveTemporallyRequest(remote.data) Then
                        AreaCommon.log.track("Downloader.getRequestA1x0", "request - Saved")

                        Return EnumResponseGet.connectionSuccessfully
                    Else
                        AreaCommon.log.track("Downloader.getRequestA1x0", "Request not saved", "fatal")

                        Return EnumResponseGet.inError
                    End If
                Else
                    AreaCommon.log.track("Downloader.getRequestA1x0", "Request not found", "fatal")

                    Return EnumResponseGet.inError
                End If

                AreaCommon.log.track("Downloader.getRequestA1x0", "Complete")

                remote = Nothing
            Catch ex As Exception
                AreaCommon.log.track("Downloader.getRequestA1x0", ex.Message, "fatal")

                Return EnumResponseGet.inError
            End Try
        End Function

        ''' <summary>
        ''' This method provide to get a request with code A1X1
        ''' </summary>
        ''' <param name="addressValue"></param>
        ''' <param name="value"></param>
        ''' <param name="dontRetry"></param>
        ''' <returns></returns>
        Private Function getRequestA1x1(ByVal addressValue As String, ByVal value As String, Optional ByVal dontRetry As Boolean = False) As EnumResponseGet
            Try
                AreaCommon.log.track("Downloader.getRequestA1x1", "Begin")

                Dim remote As New ProxyWS(Of AreaProtocol.A1x1.RequestResponseModel)
                Dim proceed As Boolean = True

                remote.url = addressValue & "/requests/a1x1/?hashValue=" & value

                If proceed Then
                    proceed = (remote.getData() = "")
                End If
                If proceed Then
                    proceed = (remote.data.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete)
                Else
                    AreaCommon.log.track("Downloader.getRequestA1x1", "Connection failed url = " & remote.url, "fatal")

                    If dontRetry Then
                        Return EnumResponseGet.connectionFailed
                    Else
                        If testMasterNode(addressValue) Then
                            Return getRequestA1x1(addressValue, value, True)
                        Else
                            Return EnumResponseGet.connectionFailed
                        End If
                    End If
                End If
                If proceed Then
                    proceed = (remote.data.common.chainReferement.Length > 0)
                End If
                If proceed Then
                    If AreaProtocol.A1x1.Manager.saveTemporallyRequest(remote.data) Then
                        AreaCommon.log.track("Downloader.getRequestA1x1", "request - Saved")

                        Return EnumResponseGet.connectionSuccessfully
                    Else
                        AreaCommon.log.track("Downloader.getRequestA1x1", "Request not saved", "fatal")

                        Return EnumResponseGet.inError
                    End If
                Else
                    AreaCommon.log.track("Downloader.getRequestA1x1", "Request not found", "fatal")

                    Return EnumResponseGet.inError
                End If

                AreaCommon.log.track("Downloader.getRequestA1x1", "Complete")

                remote = Nothing
            Catch ex As Exception
                AreaCommon.log.track("Downloader.getRequestA1x1", ex.Message, "fatal")

                Return EnumResponseGet.inError
            End Try
        End Function

        ''' <summary>
        ''' This method provide to get a request with code A1X2
        ''' </summary>
        ''' <param name="addressValue"></param>
        ''' <param name="value"></param>
        ''' <param name="dontRetry"></param>
        ''' <returns></returns>
        Private Function getRequestA1x2(ByVal addressValue As String, ByVal value As String, Optional ByVal dontRetry As Boolean = False) As EnumResponseGet
            Try
                AreaCommon.log.track("Downloader.getRequestA1x2", "Begin")

                Dim remote As New ProxyWS(Of AreaProtocol.A1x2.RequestResponseModel)
                Dim proceed As Boolean = True

                remote.url = addressValue & "/requests/a1x2/?hashValue=" & value

                If proceed Then
                    proceed = (remote.getData() = "")
                End If
                If proceed Then
                    proceed = (remote.data.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete)
                Else
                    AreaCommon.log.track("Downloader.getRequestA1x2", "Connection failed url = " & remote.url, "fatal")

                    If dontRetry Then
                        Return EnumResponseGet.connectionFailed
                    Else
                        If testMasterNode(addressValue) Then
                            Return getRequestA1x2(addressValue, value, True)
                        Else
                            Return EnumResponseGet.connectionFailed
                        End If
                    End If
                End If
                If proceed Then
                    proceed = (remote.data.common.chainReferement.Length > 0)
                End If
                If proceed Then
                    If AreaProtocol.A1x2.Manager.saveTemporallyRequest(remote.data) Then
                        AreaCommon.log.track("Downloader.getRequestA1x2", "request - Saved")

                        Return EnumResponseGet.connectionSuccessfully
                    Else
                        AreaCommon.log.track("Downloader.getRequestA1x2", "Request not saved", "fatal")

                        Return EnumResponseGet.inError
                    End If
                Else
                    AreaCommon.log.track("Downloader.getRequestA1x2", "Request not found", "fatal")

                    Return EnumResponseGet.inError
                End If

                AreaCommon.log.track("Downloader.getRequestA1x2", "Complete")

                remote = Nothing
            Catch ex As Exception
                AreaCommon.log.track("Downloader.getRequestA1x2", ex.Message, "fatal")

                Return EnumResponseGet.inError
            End Try
        End Function

        ''' <summary>
        ''' This method provide to get a request with code A1X3
        ''' </summary>
        ''' <param name="addressValue"></param>
        ''' <param name="value"></param>
        ''' <param name="dontRetry"></param>
        ''' <returns></returns>
        Private Function getRequestA1x3(ByVal addressValue As String, ByVal value As String, Optional ByVal dontRetry As Boolean = False) As EnumResponseGet
            Try
                AreaCommon.log.track("Downloader.getRequestA1x3", "Begin")

                Dim remote As New ProxyWS(Of AreaProtocol.A1x3.RequestResponseModel)
                Dim proceed As Boolean = True

                remote.url = addressValue & "/requests/a1x3/?hashValue=" & value

                If proceed Then
                    proceed = (remote.getData() = "")
                End If
                If proceed Then
                    proceed = (remote.data.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete)
                Else
                    AreaCommon.log.track("Downloader.getRequestA1x3", "Connection failed url = " & remote.url, "fatal")

                    If dontRetry Then
                        Return EnumResponseGet.connectionFailed
                    Else
                        If testMasterNode(addressValue) Then
                            Return getRequestA1x3(addressValue, value, True)
                        Else
                            Return EnumResponseGet.connectionFailed
                        End If
                    End If
                End If
                If proceed Then
                    proceed = (remote.data.common.chainReferement.Length > 0)
                End If
                If proceed Then
                    If AreaProtocol.A1x3.Manager.saveTemporallyRequest(remote.data) Then
                        AreaCommon.log.track("Downloader.getRequestA1x3", "request - Saved")

                        Return EnumResponseGet.connectionSuccessfully
                    Else
                        AreaCommon.log.track("Downloader.getRequestA1x3", "Request not saved", "fatal")

                        Return EnumResponseGet.inError
                    End If
                Else
                    AreaCommon.log.track("Downloader.getRequestA1x3", "Request not found", "fatal")

                    Return EnumResponseGet.inError
                End If

                AreaCommon.log.track("Downloader.getRequestA1x3", "Complete")

                remote = Nothing
            Catch ex As Exception
                AreaCommon.log.track("Downloader.getRequestA1x3", ex.Message, "fatal")

                Return EnumResponseGet.inError
            End Try
        End Function

        ''' <summary>
        ''' This method provide to get a request with code A1X4
        ''' </summary>
        ''' <param name="addressValue"></param>
        ''' <param name="value"></param>
        ''' <param name="dontRetry"></param>
        ''' <returns></returns>
        Private Function getRequestA1x4(ByVal addressValue As String, ByVal value As String, Optional ByVal dontRetry As Boolean = False) As EnumResponseGet
            Try
                AreaCommon.log.track("Downloader.getRequestA1x4", "Begin")

                Dim remote As New ProxyWS(Of AreaProtocol.A1x4.RequestResponseModel)
                Dim proceed As Boolean = True

                remote.url = addressValue & "/requests/a1x4/?hashValue=" & value

                If proceed Then
                    proceed = (remote.getData() = "")
                End If
                If proceed Then
                    proceed = (remote.data.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete)
                Else
                    AreaCommon.log.track("Downloader.getRequestA1x4", "Connection failed url = " & remote.url, "fatal")

                    If dontRetry Then
                        Return EnumResponseGet.connectionFailed
                    Else
                        If testMasterNode(addressValue) Then
                            Return getRequestA1x4(addressValue, value, True)
                        Else
                            Return EnumResponseGet.connectionFailed
                        End If
                    End If
                End If
                If proceed Then
                    proceed = (remote.data.common.chainReferement.Length > 0)
                End If
                If proceed Then
                    If AreaProtocol.A1x4.Manager.saveTemporallyRequest(remote.data) Then
                        AreaCommon.log.track("Downloader.getRequestA1x4", "request - Saved")

                        Return EnumResponseGet.connectionSuccessfully
                    Else
                        AreaCommon.log.track("Downloader.getRequestA1x4", "Request not saved", "fatal")

                        Return EnumResponseGet.inError
                    End If
                Else
                    AreaCommon.log.track("Downloader.getRequestA1x4", "Request not found", "fatal")

                    Return EnumResponseGet.inError
                End If

                AreaCommon.log.track("Downloader.getRequestA1x4", "Complete")

                remote = Nothing
            Catch ex As Exception
                AreaCommon.log.track("Downloader.getRequestA1x4", ex.Message, "fatal")

                Return EnumResponseGet.inError
            End Try
        End Function

        ''' <summary>
        ''' This method provide to get a request with code A1X5
        ''' </summary>
        ''' <param name="addressValue"></param>
        ''' <param name="value"></param>
        ''' <param name="dontRetry"></param>
        ''' <returns></returns>
        Private Function getRequestA1x5(ByVal addressValue As String, ByVal value As String, Optional ByVal dontRetry As Boolean = False) As EnumResponseGet
            Try
                AreaCommon.log.track("Downloader.getRequestA1x5", "Begin")

                Dim remote As New ProxyWS(Of AreaProtocol.A1x5.RequestResponseModel)
                Dim proceed As Boolean = True

                remote.url = addressValue & "/requests/a1x5/?hashValue=" & value

                If proceed Then
                    proceed = (remote.getData() = "")
                End If
                If proceed Then
                    proceed = (remote.data.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete)
                Else
                    AreaCommon.log.track("Downloader.getRequestA1x5", "Connection failed url = " & remote.url, "fatal")

                    If dontRetry Then
                        Return EnumResponseGet.connectionFailed
                    Else
                        If testMasterNode(addressValue) Then
                            Return getRequestA1x5(addressValue, value, True)
                        Else
                            Return EnumResponseGet.connectionFailed
                        End If
                    End If
                End If
                If proceed Then
                    proceed = (remote.data.common.chainReferement.Length > 0)
                End If
                If proceed Then
                    If AreaProtocol.A1x5.Manager.saveTemporallyRequest(remote.data) Then
                        AreaCommon.log.track("Downloader.getRequestA1x5", "request - Saved")

                        Return EnumResponseGet.connectionSuccessfully
                    Else
                        AreaCommon.log.track("Downloader.getRequestA1x5", "Request not saved", "fatal")

                        Return EnumResponseGet.inError
                    End If
                Else
                    AreaCommon.log.track("Downloader.getRequestA1x5", "Request not found", "fatal")

                    Return EnumResponseGet.inError
                End If

                AreaCommon.log.track("Downloader.getRequestA1x5", "Complete")

                remote = Nothing
            Catch ex As Exception
                AreaCommon.log.track("Downloader.getRequestA1x5", ex.Message, "fatal")

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

                If Not value.source.directRequest Then
                    Dim baseAddress As String = AreaCommon.state.runtimeState.getDataNode(value.source.notifiedPublicAddress).ipAddress

                    If (baseAddress.Length = 0) Then
                        Return False
                    End If

                    Select Case value.dataCommon.type
                        Case "a0x0" : response = getRequestA0x0(baseAddress, value.dataCommon.hash)
                        Case "a0x1" : response = getRequestA0x1(baseAddress, value.dataCommon.hash)
                        Case "a0x2" : response = getRequestA0x2(baseAddress, value.dataCommon.hash)
                        Case "a0x3" : response = getRequestA0x3(baseAddress, value.dataCommon.hash)
                        Case "a0x4" : response = getRequestA0x4(baseAddress, value.dataCommon.hash)
                        Case "a0x5" : response = getRequestA0x5(baseAddress, value.dataCommon.hash)
                        Case "a0x6" : response = getRequestA0x6(baseAddress, value.dataCommon.hash)
                        Case "a0x7" : response = getRequestA0x7(baseAddress, value.dataCommon.hash)

                        Case "a1x0" : response = getRequestA1x0(baseAddress, value.dataCommon.hash)
                        Case "a1x1" : response = getRequestA1x1(baseAddress, value.dataCommon.hash)
                        Case "a1x2" : response = getRequestA1x2(baseAddress, value.dataCommon.hash)
                        Case "a1x3" : response = getRequestA1x3(baseAddress, value.dataCommon.hash)
                        Case "a1x4" : response = getRequestA1x4(baseAddress, value.dataCommon.hash)
                        Case "a1x5" : response = getRequestA1x5(baseAddress, value.dataCommon.hash)

                            ''' BOOKMARK: Add in this point 4
                    End Select

                    If (response = EnumResponseGet.connectionFailed) Then
                        AreaCommon.flow.repositionDownload(value.dataCommon.hash, value.source.notifiedPublicAddress)

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

                    If (item.dataCommon.hash.Length > 0) Then
                        proceed = True

                        If proceed Then proceed = downloadRequest(item)
                        If proceed Then proceed = AreaCommon.flow.setRequestToSelect(item)
                    End If

                    Threading.Thread.Sleep(1)
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
