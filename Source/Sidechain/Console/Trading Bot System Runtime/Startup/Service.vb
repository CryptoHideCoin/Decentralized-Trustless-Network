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
                    environment.log.trackEnter("startUp.Service.run", "Main")

                    environment.registry.noSave = Not environment.settings.useEventRegistry
                End If
                If proceed Then
                    environment.registry.path = environment.paths.system.events

                    proceed = environment.registry.init()
                End If
                If proceed Then
                    environment.log.trackIntoConsole("Registry Service Start")

                    proceed = environment.registry.addNew(CHCModelsLibrary.AreaModel.Registry.RegistryData.TypeEvent.applicationStartUp)
                End If
                If proceed Then
                    environment.log.registryService = environment.registry

                    If environment.settings.useEventRegistry Then
                        environment.log.track("startUp.Service.run", "Main", "System Registry is active")
                    Else
                        environment.log.track("startUp.Service.run", "Main", "System Registry is load")
                    End If

                    proceed = environment.counter.init(IO.Path.Combine(environment.paths.system.counters, CUSTOM_ChainServiceName))
                End If
                If proceed Then
                    If environment.settings.useRequestCounter Then
                        environment.log.trackIntoConsole("Counter service active")
                        environment.log.track("startUp.Service.runService", "Main", "Counter is running")
                    Else
                        environment.log.trackIntoConsole("Counter service load")
                        environment.log.track("startUp.Service.runService", "Main", "Counter is active")
                    End If

                    proceed = AreaCommon.state.tradingBotSystem.init(AreaCommon.state)
                End If
                If proceed Then
                    environment.log.trackIntoConsole("")
                    environment.log.trackIntoConsole("Business Unit Start")
                    environment.log.track("startUp.Service.runService", "Main", "Business Unit (Trading Bot System) is running")

                    proceed = webServiceThread(True)
                End If
                If proceed Then
                    environment.log.trackIntoConsole("Admin port (" & environment.settings.servicePort & ") service in listen")
                    environment.log.changeInBootStrapComplete()
                End If

                Return True
            Catch ex As Exception
                environment.log.trackException("StartUp.Service.loadDataInformation", "Main", "Error during Load data information:" & ex.Message)

                Return False
            Finally
                environment.log.trackExit("startUp.Service.run", "Main")
            End Try
        End Function

    End Module

End Namespace
