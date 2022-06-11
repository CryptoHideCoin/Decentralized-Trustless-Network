Option Compare Text
Option Explicit On

Imports CHCSidechainServiceLibrary.AreaCommon.Main
Imports CHCModelsLibrary.AreaModel.Information
Imports CHCSidechainServiceLibrary.AreaCommon.Startup



Namespace AreaCommon.Startup

    Public Class ConsoleWriter

        Public Function write(ByVal color As ConsoleColor, ByVal message As String, ByVal useWriteLine As Boolean) As Boolean
            Console.ForegroundColor = color

            If useWriteLine Then
                Console.WriteLine(message)
            Else
                Console.Write(message)
            End If

            Return True
        End Function

    End Class


    ''' <summary>
    ''' This static class run the application
    ''' </summary>
    Module MainBootstrap

        ''' <summary>
        ''' This method provide to acquire the service information
        ''' </summary>
        ''' <returns></returns>
        Private Function acquireServiceInformation() As Boolean
            environment.log.trackIntoConsole("Load service information")

            Try
                environment.log.trackEnter("startUp.acquireServiceInformation", "Main")

                With serviceInformation
                    .chainName = CUSTOM_ChainServiceName

                    If environment.settings.intranetMode Then
                        .addressIP = environment.ipAddress.local
                    Else
                        .addressIP = environment.ipAddress.public
                    End If

                    .intranetMode = environment.settings.intranetMode
                    .netWorkName = environment.settings.networkReferement
                    .platformHost = "Microsoft Console Application service"
                    .softwareRelease = My.Application.Info.Version.ToString()

                    If environment.settings.secureChannel Then
                        .completeAddress = "https://"
                    Else
                        .completeAddress = "http://"
                    End If

                    .completeAddress += .addressIP & "/api/" & environment.settings.serviceID

                    .currentStatus = InternalServiceInformation.EnumInternalServiceState.starting
                End With

                serviceInformation = serviceInformation

                environment.log.trackIntoConsole("Acquire service information")

                Return True
            Catch ex As Exception
                environment.log.trackException("StartUp.acquireServiceInformation", "Main", "Error: " & ex.Message)

                Return False
            Finally
                environment.log.trackExit("startUp.acquireServiceInformation", "Main")
            End Try
        End Function


        ''' <summary>
        ''' This method provide to prepare the application to the startup
        ''' </summary>
        ''' <returns></returns>
        Public Function run() As Boolean
            Try
                Dim bootstrap As New Bootstrap
                Dim problemDescription As String
                Dim proceed As Boolean = True

                If proceed Then
                    environment.log.consoleObjectWriter = AreaCommon.consoleSupport
                    environment.log.trackMarker("Bootstrap run")

                    If Not bootstrap.readParameters() Then
                        writeError("Problem during read a parameters")

                        proceed = False
                    End If
                End If
                If proceed Then
                    If Not bootstrap.printWelcome(CUSTOM_ChainServiceName, My.Application.Info.Version.ToString()) Then
                        writeError("Problem during print a welcome")

                        proceed = False
                    End If
                End If
                If proceed Then
#Disable Warning BC42030
                    If Not bootstrap.managePath(CUSTOM_ChainServiceName, problemDescription) Then
#Enable Warning BC42030
                        writeError(problemDescription)

                        proceed = False
                    Else
                        environment.log.track("startUp.Service.run", "Main", "Commandline process execute is " & System.Environment.CommandLine)
                        environment.log.track("startUp.Service.run", "Main", "DataPath is " & environment.paths.directoryData)
                    End If
                End If
                If proceed Then
#Disable Warning BC42025
                    With environment.readSettings(CUSTOM_ChainServiceName)
#Enable Warning BC42025
                        proceed = .successful

                        environment.settings = .settings

                        If Not proceed Then
                            writeError(.problemDescription)

                            proceed = False
                        End If
                    End With
                End If
                If proceed Then
                    If Not bootstrap.trackRuntimeStart(problemDescription) Then
                        writeError(problemDescription)

                        proceed = False
                    End If
                End If
                If proceed Then
                    If environment.settings.useProfile Then
                        environment.performanceProfile.log = environment.log

                        proceed = environment.performanceProfile.init(environment.paths.system.performanceProfile)
                    End If
                End If
                If proceed Then
                    environment.log.apiService = environment.counter.core

                    If environment.settings.useRequestCounter Then
                        environment.counter.serviceActive = True
                        environment.counter.timeSpan = environment.settings.counterSettings.minimalTimeSlot
                        environment.counter.writeIntoDB = environment.settings.counterSettings.writeToFile
                    End If
                End If
                If proceed Then
                    proceed = bootstrap.acquireIPAddress()
                End If
                If proceed Then
                    proceed = acquireServiceInformation()
                End If
                If proceed Then
                    proceed = bootstrap.readAdminKeyStore()
                End If
                If proceed Then
#Disable Warning BC42025
                    With environment.readSettings("LocalWorkMachine")
#Enable Warning BC42025
                        If .successful Then
                            environment.localWorkMachineSettings = .settings

                            Scheduler.addWorkLocalMachineJob()
                        End If
                    End With
                End If

                If proceed Then
                    environment.log.trackIntoConsole("Root paths set " & environment.paths.directoryData)
                    If (environment.settings.serviceID.Length = 0) Then
                        environment.log.trackIntoConsole("Service GUID = Not set")
                    Else
                        environment.log.trackIntoConsole("Service GUID = " & environment.settings.serviceID)
                    End If

                End If

                Return proceed
            Catch ex As Exception
                writeError($"An error occurrent during moduleMain.bootstrap {Err.Description}")

                Return False
            End Try
        End Function

    End Module

End Namespace
