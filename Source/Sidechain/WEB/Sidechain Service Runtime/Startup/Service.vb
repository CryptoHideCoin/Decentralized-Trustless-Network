Option Compare Text
Option Explicit On

Imports CHCSidechainServiceLibrary.AreaCommon.Main




Namespace AreaCommon.Startup

    ''' <summary>
    ''' This static class run the service of application
    ''' </summary>
    Module Service

        ''' <summary>
        ''' This method provide to run all service of application
        ''' </summary>
        ''' <returns></returns>
        Public Function run() As Boolean
            environment.log.trackIntoConsole("Start Services")

            Try
                Dim proceed As Boolean = True

                If proceed Then
                    environment.log.trackEnter("startUp.Service.run")

                    environment.log.track("startUp.Service.run", "Begin")
                    environment.log.track("startUp.Service.run", "Commandline process execute is " & System.Environment.CommandLine)
                    environment.log.track("startUp.Service.run", "DataPath is " & environment.paths.directoryData)

                    environment.registry.noSave = Not environment.settings.useEventRegistry
                End If
                If proceed Then
                    proceed = environment.registry.init(environment.paths.system.events)
                End If
                If proceed Then
                    environment.log.trackIntoConsole("Registry Service Start")

                    proceed = environment.registry.addNew(CHCCommonLibrary.Support.RegistryEngine.RegistryData.TypeEvent.applicationStartUp)
                End If
                If proceed Then
                    environment.log.track("startUp.Service.run", "System Registry is running")

                    environment.counter.init(environment.paths.system.counters)

                    environment.log.trackIntoConsole("Counter Service Start")
                End If
                If proceed Then
                    environment.log.track("startUp.Service.runService", "Counter is running")

                    state.serviceInformation.currentStatus = CHCProtocolLibrary.AreaCommon.Models.Service.InternalServiceInformation.EnumInternalServiceState.started
                End If
                If proceed Then
                    environment.log.trackIntoConsole("Admin port (" & environment.settings.servicePort & ") service in listen")
                    environment.log.changeInBootStrapComplete()
                End If

                Return True
            Catch ex As Exception
                environment.log.trackException("StartUp.Service.loadDataInformation", "Error during Load data information:" & ex.Message)

                Return False
            Finally
                environment.log.trackExit("startUp.Service.run")
            End Try
        End Function

    End Module

End Namespace
