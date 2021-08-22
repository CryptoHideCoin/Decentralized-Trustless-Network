Option Compare Text
Option Explicit On




Namespace AreaData


    Module Network

        Public dataNetwork As New CHCProtocolLibrary.AreaCommon.Models.Network.BuildNetworkModel
        Private _Proceed As Boolean = True
        Private _CompleteProcess As Boolean = True



        Private Sub rebuildCommandList()
            If _Proceed Then
                With AreaCommon.state.serviceState
                    .listAvailableCommand.Clear()

                    .listAvailableCommand.Add(CHCProtocolLibrary.AreaCommon.Models.Administration.EnumActionAdministration.cancelCurrentAction)
                End With
            End If
        End Sub

        Private Sub rebuildFinalCommandList()
            With AreaCommon.state.serviceState
                .listAvailableCommand.Clear()

                If _CompleteProcess Then
                    .listAvailableCommand.Add(CHCProtocolLibrary.AreaCommon.Models.Administration.EnumActionAdministration.requestNetworkDisconnect)
                ElseIf _Proceed Then
                    .listAvailableCommand.Add(CHCProtocolLibrary.AreaCommon.Models.Administration.EnumActionAdministration.cleanLocalData)
                Else
                    .listAvailableCommand.Add(CHCProtocolLibrary.AreaCommon.Models.Administration.EnumActionAdministration.verifyData)
                End If

            End With
        End Sub

        Private Sub createLedger()
            If _Proceed Then
                AreaCommon.state.runtimeState.activeNetwork.networkCreationDate = CHCCommonLibrary.AreaEngine.Miscellaneous.timestampFromDateTime()

                AreaCommon.state.currentBlockLedger.log = AreaCommon.log
                AreaCommon.state.currentBlockLedger.identifyBlockChain = "B0"

                _Proceed = AreaCommon.state.currentBlockLedger.init(AreaCommon.paths.workData.currentVolume.ledger, AreaCommon.state.runtimeState.activeNetwork.networkCreationDate)
            End If
        End Sub

        Private Sub createState()
            If _Proceed Then
                _Proceed = AreaCommon.state.runtimeState.init(AreaCommon.paths.workData.state.db)
            End If
        End Sub

        Private Sub manageA0x0()
            If _Proceed Then
                Dim commandA0x0 As New AreaProtocol.A0x0.Manager

                commandA0x0.log = AreaCommon.log
                commandA0x0.serviceState = AreaCommon.state.serviceState

                With AreaCommon.state.keys.key(TransactionChainLibrary.AreaEngine.KeyPair.KeysEngine.KeyPair.enumWalletType.identity)
                    _Proceed = commandA0x0.init(AreaCommon.paths, dataNetwork.name, AreaCommon.state.information.networkName, AreaCommon.state.runtimeState.activeNetwork.networkCreationDate, .publicAddress, .privateKey)
                End With

                commandA0x0 = Nothing
            End If
        End Sub

        Private Sub manageA0x1()
            If _Proceed Then
                Dim commandA0x1 As New AreaProtocol.A0x1.Manager

                commandA0x1.log = AreaCommon.log
                commandA0x1.serviceState = AreaCommon.state.serviceState

                With AreaCommon.state.keys.key(TransactionChainLibrary.AreaEngine.KeyPair.KeysEngine.KeyPair.enumWalletType.identity)
                    _Proceed = commandA0x1.init(AreaCommon.paths, dataNetwork.whitePaper.content, .publicAddress, .privateKey)
                End With
            End If
        End Sub

        Private Sub manageA0x2()
            If _Proceed Then
                Dim commandA0x2 As New AreaProtocol.A0x2.Manager

                commandA0x2.log = AreaCommon.log
                commandA0x2.serviceState = AreaCommon.state.serviceState

                With AreaCommon.state.keys.key(TransactionChainLibrary.AreaEngine.KeyPair.KeysEngine.KeyPair.enumWalletType.identity)
                    _Proceed = commandA0x2.init(AreaCommon.paths, dataNetwork.yellowPaper.content, .publicAddress, .privateKey)
                End With
            End If
        End Sub

        Private Sub manageA0x3()
            If _Proceed Then
                Dim commandA0x3 As New AreaProtocol.A0x3.Manager

                commandA0x3.log = AreaCommon.log
                commandA0x3.serviceState = AreaCommon.state.serviceState

                With AreaCommon.state.keys.key(TransactionChainLibrary.AreaEngine.KeyPair.KeysEngine.KeyPair.enumWalletType.identity)
                    _Proceed = commandA0x3.init(AreaCommon.paths, dataNetwork.primaryAsset, .publicAddress, .privateKey)
                End With
            End If
        End Sub

        Private Sub manageA0x4()
            If _Proceed Then
                Dim commandA0x4 As New AreaProtocol.A0x4.Manager

                commandA0x4.log = AreaCommon.log
                commandA0x4.serviceState = AreaCommon.state.serviceState

                With AreaCommon.state.keys.key(TransactionChainLibrary.AreaEngine.KeyPair.KeysEngine.KeyPair.enumWalletType.identity)
                    _Proceed = commandA0x4.init(AreaCommon.paths, dataNetwork.transactionChainParameter, .publicAddress, .privateKey)
                End With
            End If
        End Sub

        Private Sub manageA0x5()
            If _Proceed Then
                Dim commandA0x5 As New AreaProtocol.A0x5.Manager

                commandA0x5.log = AreaCommon.log
                commandA0x5.serviceState = AreaCommon.state.serviceState

                With AreaCommon.state.keys.key(TransactionChainLibrary.AreaEngine.KeyPair.KeysEngine.KeyPair.enumWalletType.identity)
                    _Proceed = commandA0x5.init(AreaCommon.paths, dataNetwork.privacyPolicy.content, .publicAddress, .privateKey)
                End With
            End If
        End Sub

        Private Sub manageA0x6()
            If _Proceed Then
                Dim commandA0x6 As New AreaProtocol.A0x6.Manager

                commandA0x6.log = AreaCommon.log
                commandA0x6.serviceState = AreaCommon.state.serviceState

                With AreaCommon.state.keys.key(TransactionChainLibrary.AreaEngine.KeyPair.KeysEngine.KeyPair.enumWalletType.identity)
                    _Proceed = commandA0x6.init(AreaCommon.paths, dataNetwork.generalCondition.content, .publicAddress, .privateKey)
                End With
            End If
        End Sub

        Private Sub manageA0x7()
            If _Proceed Then
                Dim commandA0x7 As New AreaProtocol.A0x7.Manager

                commandA0x7.log = AreaCommon.log
                commandA0x7.serviceState = AreaCommon.state.serviceState

                With AreaCommon.state.keys.key(TransactionChainLibrary.AreaEngine.KeyPair.KeysEngine.KeyPair.enumWalletType.identity)
                    _Proceed = commandA0x7.init(AreaCommon.paths, dataNetwork.refundPlan, .publicAddress, .privateKey)
                End With
            End If
        End Sub

        Private Sub manageA1x0()
            If _Proceed Then
                Dim commandA1x0 As New AreaProtocol.A1x0.Manager

                commandA1x0.log = AreaCommon.log
                commandA1x0.serviceState = AreaCommon.state.serviceState

                With AreaCommon.state.keys.key(TransactionChainLibrary.AreaEngine.KeyPair.KeysEngine.KeyPair.enumWalletType.identity)
                    _Proceed = commandA1x0.init(AreaCommon.paths, AreaCommon.state.information.chainName, .publicAddress, .privateKey)
                End With

                commandA1x0 = Nothing
            End If
        End Sub

        Private Sub manageA1x1()
            If _Proceed Then
                Dim commandA1x1 As New AreaProtocol.A1x1.Manager

                commandA1x1.log = AreaCommon.log
                commandA1x1.serviceState = AreaCommon.state.serviceState

                With AreaCommon.state.keys.key(TransactionChainLibrary.AreaEngine.KeyPair.KeysEngine.KeyPair.enumWalletType.identity)
                    _Proceed = commandA1x1.init(AreaCommon.paths, AreaCommon.Customize.chainDescription, .publicAddress, .privateKey)
                End With

                commandA1x1 = Nothing
            End If
        End Sub

        Private Sub manageA1x2()
            If _Proceed Then
                Dim commandA1x2 As New AreaProtocol.A1x2.Manager

                commandA1x2.log = AreaCommon.log
                commandA1x2.serviceState = AreaCommon.state.serviceState

                With AreaCommon.state.keys.key(TransactionChainLibrary.AreaEngine.KeyPair.KeysEngine.KeyPair.enumWalletType.identity)
                    _Proceed = commandA1x2.init(AreaCommon.paths, AreaCommon.Customize.chainProtocolDocument, .publicAddress, .privateKey)
                End With

                commandA1x2 = Nothing
            End If
        End Sub

        Private Sub manageA1x3()
            If _Proceed Then
                Dim commandA1x3 As New AreaProtocol.A1x3.Manager

                commandA1x3.log = AreaCommon.log
                commandA1x3.serviceState = AreaCommon.state.serviceState

                With AreaCommon.state.keys.key(TransactionChainLibrary.AreaEngine.KeyPair.KeysEngine.KeyPair.enumWalletType.identity)
                    _Proceed = commandA1x3.init(AreaCommon.paths, "BaseCommonServiceChain", .publicAddress, .privateKey)
                End With

                commandA1x3 = Nothing
            End If
        End Sub

        Private Sub manageA1x4()
            If _Proceed Then
                Dim commandA1x4 As New AreaProtocol.A1x4.Manager

                commandA1x4.log = AreaCommon.log
                commandA1x4.serviceState = AreaCommon.state.serviceState

                With AreaCommon.state.keys.key(TransactionChainLibrary.AreaEngine.KeyPair.KeysEngine.KeyPair.enumWalletType.identity)
                    _Proceed = commandA1x4.init(AreaCommon.paths, New CHCProtocolLibrary.AreaCommon.Models.Network.ItemPriceTableListModel, .publicAddress, .privateKey)
                End With

                commandA1x4 = Nothing
            End If
        End Sub

        Private Sub manageA1x5()
            If _Proceed Then
                Dim commandA1x5 As New AreaProtocol.A1x5.Manager

                commandA1x5.log = AreaCommon.log
                commandA1x5.serviceState = AreaCommon.state.serviceState

                With AreaCommon.state.keys.key(TransactionChainLibrary.AreaEngine.KeyPair.KeysEngine.KeyPair.enumWalletType.identity)
                    _Proceed = commandA1x5.init(AreaCommon.paths, "", .publicAddress, .privateKey)
                End With

                commandA1x5 = Nothing
            End If
        End Sub

        Private Sub manageA1x6()
            If _Proceed Then
                Dim commandA1x6 As New AreaProtocol.A1x6.Manager

                commandA1x6.log = AreaCommon.log
                commandA1x6.serviceState = AreaCommon.state.serviceState

                With AreaCommon.state.keys.key(TransactionChainLibrary.AreaEngine.KeyPair.KeysEngine.KeyPair.enumWalletType.identity)
                    _Proceed = commandA1x6.init(AreaCommon.paths, "", .publicAddress, .privateKey)
                End With

                commandA1x6 = Nothing

                _CompleteProcess = True
            End If
        End Sub

        Public Function buildNetwork() As Boolean
            Try
                AreaCommon.log.trackIntoConsole("Build Network start")

                AreaCommon.log.track("BuildNetwork.run", "Begin")

                AreaCommon.state.network.position = CHCRuntimeChainLibrary.AreaRuntime.AppState.EnumConnectionState.genesisOperation

                createLedger()
                rebuildCommandList()
                createState()

                manageA0x0()
                manageA0x1()
                manageA0x2()
                manageA0x3()
                manageA0x4()
                manageA0x5()
                manageA0x6()
                manageA0x7()

                'manageA1x0()
                'manageA1x1()
                'manageA1x2()
                'manageA1x3()
                'manageA1x4()
                'manageA1x5()
                'manageA1x6()

                rebuildFinalCommandList()

                If AreaCommon.webServiceThread() Then
                    AreaCommon.log.trackIntoConsole("Service is in run")
                End If

                AreaCommon.log.trackIntoConsole("Build Network complete")

                Return True
            Catch ex As Exception
                AreaCommon.log.track("Verify.analyzeInternalState", "Error:" & ex.Message, "error")

                Return False
            Finally
                AreaCommon.state.serviceState.currentAction.reset()

                AreaCommon.state.serviceState.currentRunCommand = CHCProtocolLibrary.AreaCommon.Models.Administration.EnumActionAdministration.notDefined
                AreaCommon.state.serviceState.requestCancelCurrentRunCommand = False
            End Try
        End Function


    End Module

End Namespace