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

                    environment.log.track("startUp.Service.run", "Main", "Commandline process execute is " & System.Environment.CommandLine)
                    environment.log.track("startUp.Service.run", "Main", "DataPath is " & environment.paths.directoryData)

                    environment.registry.noSave = Not environment.settings.useEventRegistry
                End If
                If proceed Then
                    environment.registry.path = IO.Path.Combine(environment.paths.system.events, CUSTOM_ChainServiceName)

                    proceed = environment.registry.init()
                End If
                If proceed Then
                    environment.log.trackIntoConsole("Registry Service Start")

                    proceed = environment.registry.addNew(CHCModelsLibrary.AreaModel.Registry.RegistryData.TypeEvent.applicationStartUp)
                End If
                If proceed Then
                    environment.log.registryService = environment.registry

                    environment.log.track("startUp.Service.run", "Main", "System Registry is running")
                End If
                If proceed Then
                    environment.counter.init(environment.paths.system.counters)
                End If
                If proceed Then
                    environment.log.trackIntoConsole("Counter Service Start")
                    environment.log.track("startUp.Service.runService", "Main", "Counter is running")

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
