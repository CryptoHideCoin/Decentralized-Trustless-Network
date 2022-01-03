Option Compare Text
Option Explicit On

Imports CHCProtocolLibrary.AreaCommon.Models.Chain




Namespace AreaData


    Partial Module Network

        Public dataNetwork As New CHCProtocolLibrary.AreaCommon.Models.Network.BuildNetworkModel
        Private _Proceed As Boolean = True
        Private _CompleteProcess As Boolean = True


        ''' <summary>
        ''' This method provide to rebuild command list after start a genesis state
        ''' </summary>
        ''' <returns></returns>
        Private Function rebuildCommandList() As Boolean
            With AreaCommon.state.currentService
                .listAvailableCommand.Clear()

                .listAvailableCommand.Add(CHCProtocolLibrary.AreaCommon.Models.Administration.EnumActionAdministration.cancelCurrentAction)
            End With

            Return True
        End Function

        ''' <summary>
        ''' This method provide to initialize a property of the network
        ''' </summary>
        ''' <returns></returns>
        Private Function setGenesisNetworkState() As Boolean
            Try
                AreaCommon.log.track("BuildNetwork.setNetworkState", "Begin")

                With AreaCommon.state.network
                    .publicAddressIdentity = AreaCommon.state.keys.key(TransactionChainLibrary.AreaEngine.KeyPair.KeysEngine.KeyPair.enumWalletType.identity).publicAddress
                    .publicAddressRefund = AreaCommon.state.keys.key(TransactionChainLibrary.AreaEngine.KeyPair.KeysEngine.KeyPair.enumWalletType.refund).publicAddress
                    .publicAddresstWarranty = AreaCommon.state.keys.key(TransactionChainLibrary.AreaEngine.KeyPair.KeysEngine.KeyPair.enumWalletType.warranty).publicAddress
                    .coinWarranty = 1
                    .connectedMoment = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()
                    .role = CHCRuntimeChainLibrary.AreaRuntime.AppState.EnumMasternodeRole.fullRole
                End With

                AreaCommon.log.track("BuildNetwork.setNetworkState", "Completed")

                Return True
            Catch ex As Exception
                AreaCommon.log.track("BuildNetwork.setNetworkState", ex.Message, "fatal")

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to create a new Ledger 
        ''' </summary>
        ''' <returns></returns>
        Private Function createLedger() As Boolean
            Try
                AreaCommon.log.track("BuildNetwork.createLedger", "Begin")

                With AreaCommon.state
                    .runTimeState.activeNetwork.networkCreationDate = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()
                    .currentBlockLedger.log = AreaCommon.log
                    .currentBlockLedger.identifyBlockChain = "A0"

                    .ledgerMap.log = AreaCommon.log

                    If .currentBlockLedger.init(AreaCommon.paths.workData.ledger, AreaCommon.state.runTimeState.activeNetwork.networkCreationDate) Then
                        .ledgerMap.init(AreaCommon.paths.workData.ledger)
                    End If
                End With

                AreaCommon.log.track("BuildNetwork.createLedger", "Completed")

                Return True
            Catch ex As Exception
                AreaCommon.log.track("BuildNetwork.createLedger", ex.Message, "fatal")

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to create a new state
        ''' </summary>
        ''' <returns></returns>
        Private Function createState() As Boolean
            Return AreaCommon.state.runTimeState.init(AreaCommon.paths.workData.state.path)
        End Function

        ''' <summary>
        ''' This method provide to create a virtual node list
        ''' </summary>
        ''' <returns></returns>
        Private Function createVirtualNodeList() As Boolean
            Try
                Dim singleNode As New NodeComplete

                AreaCommon.log.track("BuildNetwork.createVirtualNodeList", "Begin")

                AreaCommon.state.runTimeState.addGenesisChain()

                singleNode.addNewAddressIP(AreaCommon.state.internalInformation.addressIP, True)

                singleNode.startConnectionTimeStamp = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()
                singleNode.role = RoleMasterNode.fullStack
                singleNode.chainName = "Genesis"

                AreaCommon.state.runTimeState.addNewNodeToChain(AreaCommon.state.keys.key(TransactionChainLibrary.AreaEngine.KeyPair.KeysEngine.KeyPair.enumWalletType.identity).publicAddress, singleNode)

                AreaCommon.log.track("BuildNetwork.createVirtualNodeList", "Completed")

                Return True
            Catch ex As Exception
                AreaCommon.log.track("BuildNetwork.createVirtualNodeList", ex.Message, "fatal")

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to create the request and wait the approvation
        ''' </summary>
        ''' <returns></returns>
        Private Function createAndWaitRequest(ByRef hash As String, Optional ByVal fase As Byte = 0) As Boolean
            Try
                Select Case fase
                    Case 0
                        Do While Not AreaCommon.flow.getActiveRequest(hash).processOperationComplete And
                                  (AreaCommon.state.runTimeState.activeNetwork.hash.Length = 0)
                            Threading.Thread.Sleep(AreaCommon.support.timeSleep)
                        Loop

                    Case 1
                        Do While Not AreaCommon.flow.getActiveRequest(hash).processOperationComplete And
                                 (AreaCommon.state.runTimeState.activeChain.hash.Length = 0)
                            Threading.Thread.Sleep(AreaCommon.support.timeSleep)
                        Loop

                    Case 2
                        Do While Not AreaCommon.flow.getActiveRequest(hash).processOperationComplete
                            Threading.Thread.Sleep(AreaCommon.support.timeSleep)
                        Loop

                End Select

                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to rebuild the final command list
        ''' </summary>
        Private Sub rebuildFinalCommandList()
            With AreaCommon.state.currentService
                .listAvailableCommand.Clear()

                .listAvailableCommand.Add(CHCProtocolLibrary.AreaCommon.Models.Administration.EnumActionAdministration.requestNetworkDisconnect)
            End With
        End Sub



        Public Function buildNetwork() As Boolean
            Dim proceed As Boolean = True
            Dim lastHash As String = ""
            Try
                AreaCommon.log.trackIntoConsole("Build Network start")
                AreaCommon.log.track("BuildNetwork.run", "Begin")

                AreaCommon.state.network.position = CHCRuntimeChainLibrary.AreaRuntime.AppState.EnumConnectionState.genesisOperation

                If proceed Then proceed = AreaCommon.flow.init()
                If proceed Then proceed = setGenesisNetworkState()
                If proceed Then proceed = createLedger()
                If proceed Then proceed = rebuildCommandList()
                If proceed Then proceed = createState()
                If proceed Then proceed = createVirtualNodeList()

                If proceed Then proceed = createAndWaitRequest(AreaProtocol.A0x0.Manager.createInternalRequest(dataNetwork.informationBase), 0)
                If proceed Then proceed = createAndWaitRequest(AreaProtocol.A1x0.Manager.createInternalRequest("Primary", "Primary Chain"), 1)
                If proceed Then proceed = createAndWaitRequest(AreaProtocol.A2x0.Manager.createInternalRequest(), 2)

                If proceed Then proceed = (AreaProtocol.A0x1.Manager.createInternalRequest(dataNetwork.whitePaper.content).Length > 0)
                If proceed Then proceed = (AreaProtocol.A0x2.Manager.createInternalRequest(dataNetwork.yellowPaper.content).Length > 0)
                If proceed Then proceed = (AreaProtocol.A0x3.Manager.createInternalRequest(dataNetwork.primaryAsset).Length > 0)
                If proceed Then proceed = (AreaProtocol.A0x4.Manager.createInternalRequest(dataNetwork.transactionChainParameter).Length > 0)
                If proceed Then proceed = (AreaProtocol.A0x5.Manager.createInternalRequest(dataNetwork.privacyPolicy.content).Length > 0)
                If proceed Then proceed = (AreaProtocol.A0x6.Manager.createInternalRequest(dataNetwork.generalCondition.content).Length > 0)
                If proceed Then proceed = (AreaProtocol.A0x7.Manager.createInternalRequest(dataNetwork.refundPlan).Length > 0)

                If proceed Then proceed = (AreaProtocol.A1x2.Manager.createInternalRequest("BaseOne", "First base of Primary Chain", "a0x0, a0x1, a0x2, a0x3, a0x4, a0x5, a0x6, a0x7, a1x0, a1x1, a1x2, a1x3, a1x4, a1x5, a1x6, a2x0, a2x1, a2x2, a2x3, a2x4").Length > 0)

                If proceed Then
                    lastHash = AreaProtocol.A0x8.Manager.createInternalRequest()

                    proceed = (lastHash.Length > 0)
                End If

                If proceed Then
                    Do While Not AreaCommon.flow.getActiveRequest(lastHash).processOperationComplete
                        Threading.Thread.Sleep(AreaCommon.support.timeSleep)
                    Loop

                    AreaCommon.log.trackIntoConsole("Build Network Completed")
                    AreaCommon.log.trackIntoConsole("")

                    If (AreaCommon.state.runTimeState.activeNetwork.envinronment.value.Trim.Length > 0) Then
                        AreaCommon.log.trackIntoConsole("Net name = " & AreaCommon.state.runTimeState.activeNetwork.networkName.value & " (" & AreaCommon.state.runTimeState.activeNetwork.envinronment.value & ")")
                    Else
                        AreaCommon.log.trackIntoConsole("Net name = " & AreaCommon.state.runTimeState.activeNetwork.networkName.value)
                    End If
                    AreaCommon.log.trackIntoConsole("Chain name = " & AreaCommon.state.runTimeState.activeChain.name.value)
                    AreaCommon.log.trackIntoConsole("Current Masternode = " & AreaCommon.state.keys.key(TransactionChainLibrary.AreaEngine.KeyPair.KeysEngine.KeyPair.enumWalletType.identity).publicAddress)
                    AreaCommon.log.trackIntoConsole("")
                Else
                    AreaCommon.log.trackIntoConsole("Build Network failed")
                End If
                AreaCommon.log.track("BuildNetwork.run", "Completed")
                AreaCommon.log.trackIntoConsole("")

                rebuildFinalCommandList()

                If AreaCommon.webServiceThread() Then
                    AreaCommon.log.trackIntoConsole("Public port (" & AreaCommon.settings.data.publicPort & ") chain in listen")
                Else
                    AreaCommon.log.trackIntoConsole("Problem during start public service")
                End If

                Return True
            Catch ex As Exception
                AreaCommon.log.track("BuildNetwork.run", ex.Message, "fatal")

                Return False
            Finally
                If proceed Then
                    AreaCommon.state.currentService.currentAction.reset()
                End If

                AreaCommon.state.currentService.currentRunCommand = CHCProtocolLibrary.AreaCommon.Models.Administration.EnumActionAdministration.undefined
                AreaCommon.state.currentService.requestCancelCurrentRunCommand = False
            End Try
        End Function

    End Module

End Namespace