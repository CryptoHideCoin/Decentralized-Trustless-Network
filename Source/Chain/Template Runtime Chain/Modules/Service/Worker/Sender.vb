Option Explicit On
Option Compare Text

Imports CHCCommonLibrary.AreaEngine.Communication
Imports CHCProtocolLibrary.AreaCommon


Namespace AreaWorker

    Module Sender

        Public Property workerOn As Boolean = False


        ''' <summary>
        ''' This method provide to send to masternode an element
        ''' </summary>
        ''' <param name="dataPack"></param>
        ''' <param name="publicAddressIP"></param>
        ''' <returns></returns>
        Private Function sendToMasterNode(ByRef dataPack As Models.Network.NotifyModel, ByVal publicAddressIP As String) As Boolean
            Try
                AreaCommon.log.track("Sender.sendToMasterNode", "Begin")

                Dim remote As New ProxyWS(Of Models.Network.NotifyModel)

                remote.url = publicAddressIP & "/notify/request/"

                remote.data = dataPack

                If (remote.sendData() = "") Then
                    Return (remote.remoteResponse.responseStatus = CHCCommonLibrary.AreaCommon.Models.General.RemoteResponse.EnumResponseStatus.responseComplete)
                Else
                    AreaCommon.log.track("Sender.sendToMasterNode", "Connection failed url = " & remote.url, "fatal")
                End If

                remote = Nothing

                AreaCommon.log.track("Sender.sendToMasterNode", "Complete")

                Return False
            Catch ex As Exception
                AreaCommon.log.track("Sender.sendToMasterNode", ex.Message, "fatal")

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to send a bullettin to masternode
        ''' </summary>
        ''' <param name="dataObject"></param>
        ''' <param name="publicAddressIP"></param>
        ''' <returns></returns>
        Private Function sendToMasterNodeBulletin(ByRef dataObject As AreaConsensus.RequestProcess, ByVal publicAddressIP As String) As Boolean
            Try
                AreaCommon.log.track("Sender.sendToMasterNodeBulletin", "Begin")

                Dim remote As New ProxyWS(Of AreaConsensus.RequestProcess)

                remote.url = publicAddressIP & "/notify/bulletin/"

                remote.data = dataObject

                If (remote.sendData() = "") Then
                    Return (remote.remoteResponse.responseStatus = CHCCommonLibrary.AreaCommon.Models.General.RemoteResponse.EnumResponseStatus.responseComplete)
                Else
                    AreaCommon.log.track("Sender.sendToMasterNodeBulletin", "Connection failed url = " & remote.url, "fatal")
                End If

                remote = Nothing

                AreaCommon.log.track("Sender.sendToMasterNodeBulletin", "Complete")

                Return False
            Catch ex As Exception
                AreaCommon.log.track("Sender.sendToMasterNodeBulletin", ex.Message, "fatal")

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to send a broadcast a request
        ''' </summary>
        ''' <param name="requestCode"></param>
        ''' <param name="requestHash"></param>
        ''' <param name="deliveryList"></param>
        ''' <returns></returns>
        Private Function sendInBroadCast(ByRef requestCode As String, ByVal requestHash As String, ByRef deliveryList As AreaCommon.Masternode.MasternodeSenders) As AreaCommon.Masternode.MasternodeSenders
            Dim newDeliveryList As New AreaCommon.Masternode.MasternodeSenders

            Try
                AreaCommon.log.track("Sender.sendInBroadCast", "Begin")

                Dim masterNode As AreaCommon.Masternode.MasternodeSenders.MasternodeSender
                Dim dataPack As New Models.Network.NotifyModel
                Dim privateKeyRAW As String = AreaCommon.state.keys.key(TransactionChainLibrary.AreaEngine.KeyPair.KeysEngine.KeyPair.enumWalletType.identity).privateKey

                If AreaCommon.settings.data.intranetMode Then
                    dataPack.publicAddress = AreaCommon.state.localIpAddress
                Else
                    dataPack.publicAddress = AreaCommon.state.publicIpAddress
                End If

                dataPack.requestCode = requestCode
                dataPack.requestHash = requestHash
                dataPack.signature = CHCProtocolLibrary.AreaWallet.Support.WalletAddressEngine.createSignature(privateKeyRAW, dataPack.getHash)

                masterNode = deliveryList.getFirst()

                Do While Not IsNothing(masterNode)
                    If Not sendToMasterNode(dataPack, masterNode.publicAddressIP) Then
                        newDeliveryList.add(masterNode)
                    End If

                    deliveryList.removeFirst()

                    masterNode = deliveryList.getFirst()
                Loop

                AreaCommon.log.track("Sender.sendInBroadCast", "Complete")
            Catch ex As Exception
                AreaCommon.log.track("Sender.sendInBroadCast", ex.Message, "fatal")
            End Try

            Return newDeliveryList
        End Function

        ''' <summary>
        ''' This method provide to send bullettin in broadcast
        ''' </summary>
        ''' <param name="dataObject"></param>
        ''' <param name="deliveryList"></param>
        ''' <returns></returns>
        Private Function sendBulletinInBroadCast(ByRef dataObject As AreaConsensus.RequestProcess, ByRef deliveryList As AreaCommon.Masternode.MasternodeSenders) As AreaCommon.Masternode.MasternodeSenders
            Dim newDeliveryList As New AreaCommon.Masternode.MasternodeSenders

            Try
                AreaCommon.log.track("Sender.sendBulletinInBroadCast", "Begin")

                Dim masterNode As AreaCommon.Masternode.MasternodeSenders.MasternodeSender

                masterNode = deliveryList.getFirst()

                Do While Not IsNothing(masterNode)
                    If Not sendToMasterNodeBulletin(dataObject, masterNode.publicAddressIP) Then
                        newDeliveryList.add(masterNode)
                    End If

                    deliveryList.removeFirst()

                    masterNode = deliveryList.getFirst()
                Loop

                AreaCommon.log.track("Sender.sendBulletinInBroadCast", "Complete")
            Catch ex As Exception
                AreaCommon.log.track("Sender.sendBulletinInBroadCast", ex.Message, "fatal")
            End Try

            Return newDeliveryList
        End Function

        ''' <summary>
        ''' This method provide to work a sender process
        ''' </summary>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()>
        Public Function work() As Boolean
            Try
                Dim newDeliveryList As New AreaCommon.Masternode.MasternodeSenders
                Dim item As AreaFlow.RequestToSend
                Dim proceed As Boolean = True

                AreaCommon.log.track("Sender.work", "Begin")

                workerOn = True

                Do While (AreaCommon.flow.workerOn And workerOn)
                    item = AreaCommon.flow.getFirstRequestToSend()

                    If (item.requestCode.Length > 0) Then
                        If item.sendBulletin Then
                            newDeliveryList = sendBulletinInBroadCast(item.dataObject, item.deliveryList)
                        Else
                            newDeliveryList = sendInBroadCast(item.requestCode, item.dataObject.requestHash, item.deliveryList)
                        End If

                        AreaCommon.flow.removeRequestToSend(item)

                        If (newDeliveryList.count > 0) Then
                            If item.tryNumber < 3 Then
                                AreaCommon.flow.addNewRequestToSend(item.requestCode, item.requestHash, newDeliveryList, item.dataObject, item.tryNumber + 1)
                            End If
                        End If
                    End If

                    Threading.Thread.Sleep(1)
                Loop

                workerOn = False

                AreaCommon.log.track("Sender.work", "Complete")

                Return True
            Catch ex As Exception
                AreaCommon.log.track("Sender.work", ex.Message, "fatal")

                Return False
            End Try
        End Function


    End Module

End Namespace