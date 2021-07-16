Option Compare Text
Option Explicit On




Namespace AreaData


    Module Verify

        Private _DataCommon As New TransactionChainLibrary.AreaEngine.Ledger.Common.NetworkChain
        Private _Proceed As Boolean = True


        Private Sub checkStorage()
            If _Proceed Then
                AreaCommon.state.component.storage.log = AreaCommon.log
                AreaCommon.state.component.storage.serviceState = AreaCommon.state.serviceState

                _Proceed = AreaCommon.state.component.storage.init(_DataCommon, AreaCommon.paths, AreaCommon.settings.data.walletAddress)

                AreaCommon.state.serviceState.getComponentPosition(CHCProtocolLibrary.AreaCommon.Models.Administration.EnumDataElement.storage).position = AreaCommon.state.component.storage.generalState
            End If
        End Sub

        Private Sub checkPrevious()
            If _Proceed Then
                AreaCommon.state.component.previousVolume.log = AreaCommon.log
                AreaCommon.state.component.previousVolume.serviceState = AreaCommon.state.serviceState

                _Proceed = AreaCommon.state.component.previousVolume.init(_DataCommon, AreaCommon.paths, AreaCommon.settings.data.walletAddress)

                AreaCommon.state.serviceState.getComponentPosition(CHCProtocolLibrary.AreaCommon.Models.Administration.EnumDataElement.previousWork).position = AreaCommon.state.component.previousVolume.generalState
            End If
        End Sub

        Private Sub checkCurrent()
            If _Proceed Then
                AreaCommon.state.component.currentVolume.log = AreaCommon.log
                AreaCommon.state.component.currentVolume.serviceState = AreaCommon.state.serviceState

                _Proceed = AreaCommon.state.component.currentVolume.init(_DataCommon, AreaCommon.paths, AreaCommon.settings.data.walletAddress)

                AreaCommon.state.serviceState.getComponentPosition(CHCProtocolLibrary.AreaCommon.Models.Administration.EnumDataElement.currentWork).position = AreaCommon.state.component.currentVolume.generalState
            End If
        End Sub

        Private Sub checkState()
            If _Proceed Then
                AreaCommon.state.component.stateDB.log = AreaCommon.log
                AreaCommon.state.component.stateDB.serviceState = AreaCommon.state.serviceState

                _Proceed = AreaCommon.state.component.stateDB.init(_DataCommon, AreaCommon.paths, AreaCommon.settings.data.walletAddress)

                AreaCommon.state.serviceState.getComponentPosition(CHCProtocolLibrary.AreaCommon.Models.Administration.EnumDataElement.state).position = AreaCommon.state.component.stateDB.generalState
            End If
        End Sub

        Private Sub checkNodeList()
            If _Proceed Then
                AreaCommon.state.component.nodeList.log = AreaCommon.log
                AreaCommon.state.component.nodeList.serviceState = AreaCommon.state.serviceState

                _Proceed = AreaCommon.state.component.nodeList.init(_DataCommon, AreaCommon.paths, AreaCommon.settings.data.walletAddress)

                AreaCommon.state.serviceState.getComponentPosition(CHCProtocolLibrary.AreaCommon.Models.Administration.EnumDataElement.nodeList).position = AreaCommon.state.component.nodeList.generalState
            End If
        End Sub

        Private Function allVolumeState(ByVal value As CHCProtocolLibrary.AreaCommon.Models.Administration.EnumDataPosition) As Boolean
            Dim missing As Boolean = True

            With AreaCommon.state.serviceState.getComponentPosition(CHCProtocolLibrary.AreaCommon.Models.Administration.EnumDataElement.state)
                If missing Then
                    missing = (.element = CHCProtocolLibrary.AreaCommon.Models.Administration.EnumDataElement.state) And (.position = value)
                End If
            End With
            With AreaCommon.state.serviceState.getComponentPosition(CHCProtocolLibrary.AreaCommon.Models.Administration.EnumDataElement.currentWork)
                If missing Then
                    missing = (.element = CHCProtocolLibrary.AreaCommon.Models.Administration.EnumDataElement.currentWork) And (.position = value)
                End If
            End With
            With AreaCommon.state.serviceState.getComponentPosition(CHCProtocolLibrary.AreaCommon.Models.Administration.EnumDataElement.previousWork)
                If missing Then
                    missing = (.element = CHCProtocolLibrary.AreaCommon.Models.Administration.EnumDataElement.previousWork) And (.position = value)
                End If
            End With
            With AreaCommon.state.serviceState.getComponentPosition(CHCProtocolLibrary.AreaCommon.Models.Administration.EnumDataElement.storage)
                If missing Then
                    missing = (.element = CHCProtocolLibrary.AreaCommon.Models.Administration.EnumDataElement.storage) And (.position = value)
                End If
            End With

            Return missing
        End Function

        Private Sub rebuildCommandList()
            If _Proceed Then

                With AreaCommon.state.serviceState

                    .listAvailableCommand.Clear()

                    .listAvailableCommand.Add(CHCProtocolLibrary.AreaCommon.Models.Administration.EnumActionAdministration.verifyData)
                    .listAvailableCommand.Add(CHCProtocolLibrary.AreaCommon.Models.Administration.EnumActionAdministration.setTrustedIPAddress)

                    If allVolumeState(CHCProtocolLibrary.AreaCommon.Models.Administration.EnumDataPosition.missing) Then
                        With AreaCommon.state.serviceState.getComponentPosition(CHCProtocolLibrary.AreaCommon.Models.Administration.EnumDataElement.nodeList)
                            If (.element = CHCProtocolLibrary.AreaCommon.Models.Administration.EnumDataElement.nodeList) And
                               (.position = CHCProtocolLibrary.AreaCommon.Models.Administration.EnumDataPosition.missing) Then
                                AreaCommon.state.serviceState.listAvailableCommand.Add(CHCProtocolLibrary.AreaCommon.Models.Administration.EnumActionAdministration.downloadHistory)
                                AreaCommon.state.serviceState.listAvailableCommand.Add(CHCProtocolLibrary.AreaCommon.Models.Administration.EnumActionAdministration.buildNetwork)
                            End If
                        End With
                    Else
                        AreaCommon.state.serviceState.listAvailableCommand.Add(CHCProtocolLibrary.AreaCommon.Models.Administration.EnumActionAdministration.cleanLocalData)
                    End If

                    If allVolumeState(CHCProtocolLibrary.AreaCommon.Models.Administration.EnumDataPosition.checkControlPassed) Then
                        AreaCommon.state.serviceState.listAvailableCommand.Add(CHCProtocolLibrary.AreaCommon.Models.Administration.EnumActionAdministration.resumeSystemFirstNode)
                    End If

                End With

                With AreaCommon.state.serviceState.getComponentPosition(CHCProtocolLibrary.AreaCommon.Models.Administration.EnumDataElement.nodeList)
                    If (.element = CHCProtocolLibrary.AreaCommon.Models.Administration.EnumDataElement.nodeList) And
                       (.position = CHCProtocolLibrary.AreaCommon.Models.Administration.EnumDataPosition.checkControlPassed) Then
                        AreaCommon.state.serviceState.listAvailableCommand.Add(CHCProtocolLibrary.AreaCommon.Models.Administration.EnumActionAdministration.checkTrustedNodelist)
                    End If
                End With

                ' Il pulsante RebuildState si accende solo se i file sono scaricati e in sequenza

                ' Il pulsante Synchronize Network si accende solo se tutto è in checked e la nodelist è scaricata

                ' Il pulsante Request Network Connection si accende solo se tutto è in stato di checked

                ' Il pulsante Request Network Disconnection si accende solo se sei collegato alla rete

            End If
        End Sub

        Public Function analyzeInternalState() As Boolean
            Try
                AreaCommon.log.trackIntoConsole("Analize internal state start")

                AreaCommon.log.track("Verify.analyzeInternalState", "Begin")

                _DataCommon.chainName = AreaCommon.state.information.chainName
                _DataCommon.networkName = AreaCommon.state.information.networkName

                AreaCommon.log.track("Verify.analyzeInternalState", "Main data set")

                checkStorage()
                checkPrevious()
                checkCurrent()
                checkState()
                checkNodeList()
                rebuildCommandList()

                AreaCommon.log.trackIntoConsole("Analize internal state complete")

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