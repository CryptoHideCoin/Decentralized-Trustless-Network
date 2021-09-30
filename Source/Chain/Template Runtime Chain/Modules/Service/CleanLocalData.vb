Option Compare Text
Option Explicit On




Namespace AreaData


    Module Service

        Private _Proceed As Boolean = True


        Private Sub rebuildCommandList()
            If _Proceed Then

                With AreaCommon.state.currentService
                    .listAvailableCommand.Clear()

                    .listAvailableCommand.Add(CHCProtocolLibrary.AreaCommon.Models.Administration.EnumActionAdministration.verifyData)
                    .listAvailableCommand.Add(CHCProtocolLibrary.AreaCommon.Models.Administration.EnumActionAdministration.setTrustedIPAddress)
                    .listAvailableCommand.Add(CHCProtocolLibrary.AreaCommon.Models.Administration.EnumActionAdministration.buildNetwork)
                End With

                With AreaCommon.state.currentService.getComponentPosition(CHCProtocolLibrary.AreaCommon.Models.Administration.EnumDataElement.nodeList)
                    If (.element = CHCProtocolLibrary.AreaCommon.Models.Administration.EnumDataElement.nodeList) And
                       (.position = CHCProtocolLibrary.AreaCommon.Models.Administration.EnumDataPosition.checkControlPassed) Then
                        AreaCommon.state.currentService.listAvailableCommand.Add(CHCProtocolLibrary.AreaCommon.Models.Administration.EnumActionAdministration.checkTrustedNodelist)
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
                AreaCommon.state.component.storage.serviceState = AreaCommon.state.currentService

                _Proceed = AreaCommon.state.component.storage.cleanData(AreaCommon.paths)

                If _Proceed Then
                    _Proceed = AreaCommon.paths.init(CHCProtocolLibrary.AreaSystem.VirtualPathEngine.EnumSystemType.runTime)
                End If

                rebuildCommandList()

                AreaCommon.log.track("service.CleanLocalData", "Complete")

                AreaCommon.log.trackIntoConsole("Clean Local Data complete")

                Return _Proceed
            Catch ex As Exception
                AreaCommon.log.track("service.CleanLocalData", ex.Message, "fatal")

                Return False
            Finally
                AreaCommon.state.currentService.currentAction.reset()

                AreaCommon.state.currentService.currentRunCommand = CHCProtocolLibrary.AreaCommon.Models.Administration.EnumActionAdministration.notDefined
                AreaCommon.state.currentService.requestCancelCurrentRunCommand = False
            End Try
        End Function


    End Module

End Namespace
