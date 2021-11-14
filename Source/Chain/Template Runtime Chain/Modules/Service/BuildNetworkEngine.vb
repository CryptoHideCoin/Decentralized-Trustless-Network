﻿Option Compare Text
Option Explicit On




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

                AreaCommon.log.track("BuildNetwork.setNetworkState", "Complete")

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
                    .runtimeState.activeNetwork.networkCreationDate = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()
                    .currentBlockLedger.log = AreaCommon.log
                    .currentBlockLedger.identifyBlockChain = "B0"

                    .ledgerMap.log = AreaCommon.log

                    Return .currentBlockLedger.init(AreaCommon.paths.workData.ledger, AreaCommon.state.runtimeState.activeNetwork.networkCreationDate)
                End With

                AreaCommon.log.track("BuildNetwork.createLedger", "Complete")

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
            Return AreaCommon.state.runtimeState.init(AreaCommon.paths.workData.state.path)
        End Function

        ''' <summary>
        ''' This method provide to create a virtual node list
        ''' </summary>
        ''' <returns></returns>
        Private Function createVirtualNodeList() As Boolean
            Try
                AreaCommon.log.track("BuildNetwork.createVirtualNodeList", "Begin")

                With AreaCommon.state.runtimeState.addNewNode("Primary")
                    .dayConnection = 0

                    If AreaCommon.settings.data.intranetMode Then
                        .ipAddress = AreaCommon.state.localIpAddress
                    Else
                        .ipAddress = AreaCommon.state.publicIpAddress
                    End If

                    .lastConnectionTimeStamp = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()
                    .role = AreaState.ChainStateEngine.DataMasternode.roleMasterNode.fullService
                    .startConnectionTimeStamp = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()
                    .votePoint = 1
                    .warrantyCoin = 1
                    .warrantyPublicAddress = .identityPublicAddress
                    .refundPublicAddress = .identityPublicAddress
                End With

                AreaCommon.log.track("BuildNetwork.createVirtualNodeList", "Complete")

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
        Private Function createAndWaitRequest(ByRef [type] As String, Optional ByVal checkChainReferement As Boolean = False) As Boolean
            Try
                Do While (Not checkChainReferement And (AreaCommon.flow.getActiveRequest([type]).position.process <> AreaFlow.EnumOperationPosition.completeWithPositiveResult)) Or
                         (checkChainReferement And (AreaCommon.state.runtimeState.activeChain.hash.Length = 0))
                    Threading.Thread.Sleep(10)
                Loop

                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function


        'Private Sub manageA1x2()
        '    If _Proceed Then
        '        Dim commandA1x2 As New AreaProtocol.A1x2.Manager

        '        commandA1x2.log = AreaCommon.log
        '        commandA1x2.currentService = AreaCommon.state.currentService

        '        With AreaCommon.state.keys.key(TransactionChainLibrary.AreaEngine.KeyPair.KeysEngine.KeyPair.enumWalletType.identity)
        '            _Proceed = commandA1x2.init(AreaCommon.paths, AreaCommon.Customize.chainProtocolDocument, .publicAddress, .privateKey)
        '        End With

        '        commandA1x2 = Nothing
        '    End If
        'End Sub

        'Private Sub manageA1x3()
        '    If _Proceed Then
        '        Dim commandA1x3 As New AreaProtocol.A1x3.Manager

        '        commandA1x3.log = AreaCommon.log
        '        commandA1x3.currentService = AreaCommon.state.currentService

        '        With AreaCommon.state.keys.key(TransactionChainLibrary.AreaEngine.KeyPair.KeysEngine.KeyPair.enumWalletType.identity)
        '            _Proceed = commandA1x3.init(AreaCommon.paths, "BaseCommonServiceChain", .publicAddress, .privateKey)
        '        End With

        '        commandA1x3 = Nothing
        '    End If
        'End Sub

        'Private Sub manageA1x4()
        '    If _Proceed Then
        '        Dim commandA1x4 As New AreaProtocol.A1x4.Manager

        '        commandA1x4.log = AreaCommon.log
        '        commandA1x4.currentService = AreaCommon.state.currentService

        '        With AreaCommon.state.keys.key(TransactionChainLibrary.AreaEngine.KeyPair.KeysEngine.KeyPair.enumWalletType.identity)
        '            _Proceed = commandA1x4.init(AreaCommon.paths, New CHCProtocolLibrary.AreaCommon.Models.Network.ItemPriceTableListModel, .publicAddress, .privateKey)
        '        End With

        '        commandA1x4 = Nothing
        '    End If
        'End Sub

        'Private Sub manageA1x5()
        '    If _Proceed Then
        '        Dim commandA1x5 As New AreaProtocol.A1x5.Manager

        '        commandA1x5.log = AreaCommon.log
        '        commandA1x5.currentService = AreaCommon.state.currentService

        '        With AreaCommon.state.keys.key(TransactionChainLibrary.AreaEngine.KeyPair.KeysEngine.KeyPair.enumWalletType.identity)
        '            _Proceed = commandA1x5.init(AreaCommon.paths, "", .publicAddress, .privateKey)
        '        End With

        '        commandA1x5 = Nothing
        '    End If
        'End Sub

        'Private Sub manageA1x6()
        '    If _Proceed Then
        '        Dim commandA1x6 As New AreaProtocol.A1x6.Manager

        '        commandA1x6.log = AreaCommon.log
        '        commandA1x6.currentService = AreaCommon.state.currentService

        '        With AreaCommon.state.keys.key(TransactionChainLibrary.AreaEngine.KeyPair.KeysEngine.KeyPair.enumWalletType.identity)
        '            _Proceed = commandA1x6.init(AreaCommon.paths, "", .publicAddress, .privateKey)
        '        End With

        '        commandA1x6 = Nothing

        '        _CompleteProcess = True
        '    End If
        'End Sub

        Public Function buildNetwork() As Boolean
            Dim proceed As Boolean = True
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

                If proceed Then proceed = createAndWaitRequest(AreaProtocol.A0x0.Manager.createInternalRequest(dataNetwork.informationBase))
                If proceed Then proceed = createAndWaitRequest(AreaProtocol.A0x1.Manager.createInternalRequest(dataNetwork.whitePaper.content))
                If proceed Then proceed = createAndWaitRequest(AreaProtocol.A0x2.Manager.createInternalRequest(dataNetwork.yellowPaper.content))
                If proceed Then proceed = createAndWaitRequest(AreaProtocol.A0x3.Manager.createInternalRequest(dataNetwork.primaryAsset))
                If proceed Then proceed = createAndWaitRequest(AreaProtocol.A0x4.Manager.createInternalRequest(dataNetwork.transactionChainParameter))
                If proceed Then proceed = createAndWaitRequest(AreaProtocol.A0x5.Manager.createInternalRequest(dataNetwork.privacyPolicy.content))
                If proceed Then proceed = createAndWaitRequest(AreaProtocol.A0x6.Manager.createInternalRequest(dataNetwork.generalCondition.content))
                If proceed Then proceed = createAndWaitRequest(AreaProtocol.A0x7.Manager.createInternalRequest(dataNetwork.refundPlan))

                If proceed Then proceed = createAndWaitRequest(AreaProtocol.A1x0.Manager.createInternalRequest(AreaCommon.state.runtimeState.activeNetwork.hash, "Primary", "Primary Chain"), True)
                If proceed Then proceed = createAndWaitRequest(AreaProtocol.A1x1.Manager.createInternalRequest(AreaCommon.state.runtimeState.activeNetwork.hash, AreaCommon.state.runtimeState.activeChain.hash, "BaseOne", "First base of Primary Chain", "a0x0, a0x1, a0x2, a0x3, a0x4, a0x5, a0x6, a0x7, a1x0, a1x1, a1x2, a1x3, a1x4, a1x5, a1x6, a2x0, a2x1, a2x2, a2x3, a2x4"))

                'manageA1x2()
                'manageA1x3()
                'manageA1x4()
                'manageA1x5()
                'manageA1x6()

                If proceed Then
                    AreaCommon.log.trackIntoConsole("Build Network complete")
                Else
                    AreaCommon.log.trackIntoConsole("Build Network failed")
                End If
                AreaCommon.log.track("BuildNetwork.run", "Complete")

                Return True
            Catch ex As Exception
                AreaCommon.log.track("BuildNetwork.run", ex.Message, "fatal")

                Return False
            Finally
                If proceed Then
                    AreaCommon.state.currentService.currentAction.reset()
                End If

                AreaCommon.state.currentService.currentRunCommand = CHCProtocolLibrary.AreaCommon.Models.Administration.EnumActionAdministration.notDefined
                AreaCommon.state.currentService.requestCancelCurrentRunCommand = False
            End Try
        End Function

    End Module

End Namespace