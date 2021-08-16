Option Compare Text
Option Explicit On




Namespace AreaData


    Module Service

        Private _Proceed As Boolean = True


        Private Sub rebuildCommandList()
            If _Proceed Then

                With AreaCommon.state.serviceState
                    .listAvailableCommand.Clear()

                    .listAvailableCommand.Add(CHCProtocolLibrary.AreaCommon.Models.Administration.EnumActionAdministration.verifyData)
                    .listAvailableCommand.Add(CHCProtocolLibrary.AreaCommon.Models.Administration.EnumActionAdministration.setTrustedIPAddress)
                    .listAvailableCommand.Add(CHCProtocolLibrary.AreaCommon.Models.Administration.EnumActionAdministration.buildNetwork)
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

            End If
        End Sub

        Public Function cleanLocalData() As Boolean
            Try
                AreaCommon.log.trackIntoConsole("Clean Local Data start")

                AreaCommon.log.track("service.CleanLocalData", "Begin")

                AreaCommon.state.component.storage.log = AreaCommon.log
                AreaCommon.state.component.storage.serviceState = AreaCommon.state.serviceState

                _Proceed = AreaCommon.state.component.storage.cleanData(AreaCommon.paths)

                rebuildCommandList()

                AreaCommon.log.track("service.CleanLocalData", "Complete")

                AreaCommon.log.trackIntoConsole("Clean Local Data complete")

                Return True
            Catch ex As Exception
                AreaCommon.log.track("service.CleanLocalData", "Error:" & ex.Message, "error")

                Return False
            Finally
                AreaCommon.state.serviceState.currentAction.reset()

                AreaCommon.state.serviceState.currentRunCommand = CHCProtocolLibrary.AreaCommon.Models.Administration.EnumActionAdministration.notDefined
                AreaCommon.state.serviceState.requestCancelCurrentRunCommand = False
            End Try
        End Function


    End Module

End Namespace
