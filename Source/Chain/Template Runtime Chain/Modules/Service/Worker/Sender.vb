Option Explicit On
Option Compare Text

Imports CHCCommonLibrary.AreaEngine.Communication
Imports CHCProtocolLibrary.AreaCommon


Namespace AreaWorker

    Module Sender

        Public Property workerOn As Boolean = False


        Private Function sendToMasterNode(ByRef dataPack As Models.Network.NotifyModel, ByVal publicAddressIP As String) As Boolean
            Try
                Dim remote As New ProxyWS(Of Models.Network.NotifyModel)

                remote.url = publicAddressIP & "/notify/request/"

                remote.data = dataPack

                If (remote.sendData() = "") Then
                    Return (remote.remoteResponse.responseStatus = CHCCommonLibrary.AreaCommon.Models.General.RemoteResponse.EnumResponseStatus.responseComplete)
                Else
                    AreaCommon.log.track("Sender.sendToMasterNode", "Connection failed url = " & remote.url, "error")
                End If

                remote = Nothing

                Return False
            Catch ex As Exception
                AreaCommon.log.track("Sender.sendToMasterNode", "Error:" & ex.Message, "error")

                Return False
            End Try
        End Function

        Private Function sendToMasterNodeBulletin(ByRef dataObject As AreaConsensus.RequestProcess, ByVal publicAddressIP As String) As Boolean
            Try
                Dim remote As New ProxyWS(Of AreaConsensus.RequestProcess)

                remote.url = publicAddressIP & "/notify/bulletin/"

                remote.data = dataObject

                If (remote.sendData() = "") Then
                    Return (remote.remoteResponse.responseStatus = CHCCommonLibrary.AreaCommon.Models.General.RemoteResponse.EnumResponseStatus.responseComplete)
                Else
                    AreaCommon.log.track("Sender.sendToMasterNodeBulletin", "Connection failed url = " & remote.url, "error")
                End If

                remote = Nothing

                Return False
            Catch ex As Exception
                AreaCommon.log.track("Sender.sendToMasterNodeBulletin", "Error:" & ex.Message, "error")

                Return False
            End Try
        End Function

        Private Function sendInBroadCast(ByRef requestCode As String, ByVal requestHash As String, ByRef deliveryList As AreaCommon.Masternode.MasternodeSenders) As AreaCommon.Masternode.MasternodeSenders
            Dim newDeliveryList As New AreaCommon.Masternode.MasternodeSenders

            Try
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
            Catch ex As Exception
                AreaCommon.log.track("Sender.sendInBroadCast", "Error:" & ex.Message, "error")
            End Try

            Return newDeliveryList
        End Function

        Private Function sendBulletinInBroadCast(ByRef dataObject As AreaConsensus.RequestProcess, ByRef deliveryList As AreaCommon.Masternode.MasternodeSenders) As AreaCommon.Masternode.MasternodeSenders
            Dim newDeliveryList As New AreaCommon.Masternode.MasternodeSenders

            Try
                Dim masterNode As AreaCommon.Masternode.MasternodeSenders.MasternodeSender

                masterNode = deliveryList.getFirst()

                Do While Not IsNothing(masterNode)
                    If Not sendToMasterNodeBulletin(dataObject, masterNode.publicAddressIP) Then
                        newDeliveryList.add(masterNode)
                    End If

                    deliveryList.removeFirst()

                    masterNode = deliveryList.getFirst()
                Loop
            Catch ex As Exception
                AreaCommon.log.track("Sender.sendBulletinInBroadCast", "Error:" & ex.Message, "error")
            End Try

            Return newDeliveryList
        End Function

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

                        If newDeliveryList.count > 0 Then
                            If item.tryNumber < 3 Then
                                AreaCommon.flow.addNewRequestToSend(item.requestCode, item.requestHash, newDeliveryList, item.dataObject, item.tryNumber + 1)
                            End If
                        End If
                    End If

                    Threading.Thread.Sleep(10)
                Loop

                workerOn = False

                AreaCommon.log.track("Sender.work", "Complete")

                Return True
            Catch ex As Exception
                AreaCommon.log.track("Sender.work", "Error:" & ex.Message, "error")

                Return False
            End Try
        End Function


    End Module

End Namespace