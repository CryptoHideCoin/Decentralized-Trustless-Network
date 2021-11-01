Option Compare Text
Option Explicit On




Namespace AreaData

    Module Service

        Private Sub rebuildCommandList()

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

            ''' UNDONE: CleanLocalData - button RebuildState, Synchronize Network, Request Network Connection

        End Sub

        ''' <summary>
        ''' This method provide to clean a local data
        ''' </summary>
        ''' <returns></returns>
        Public Function cleanLocalData() As Boolean
            Dim proceed As Boolean = True

            Try
                AreaCommon.log.trackIntoConsole("Clean Local Data start")

                AreaCommon.log.track("service.CleanLocalData", "Begin")

                AreaCommon.state.component.storage.log = AreaCommon.log
                AreaCommon.state.component.storage.serviceState = AreaCommon.state.currentService

                proceed = AreaCommon.state.component.storage.cleanData(AreaCommon.paths)

                If proceed Then
                    proceed = AreaCommon.paths.init(CHCProtocolLibrary.AreaSystem.VirtualPathEngine.EnumSystemType.runTime)
                End If

                rebuildCommandList()

                AreaCommon.log.track("service.CleanLocalData", "Complete")

                AreaCommon.log.trackIntoConsole("Clean Local Data complete")

                Return proceed
            Catch ex As Exception
                AreaCommon.log.track("service.CleanLocalData", ex.Message, "fatal")

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
