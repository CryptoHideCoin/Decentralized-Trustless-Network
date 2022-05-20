Option Compare Text
Option Explicit On

Imports CHCSidechainServiceLibrary.AreaCommon.Main
Imports CHCCommonLibrary.AreaEngine.Communication
Imports CHCModelsLibrary.AreaModel.Network.Response
Imports CHCModelsLibrary.AreaModel.Service
Imports System.Threading




Namespace AreaScheduler

    Public Class MainEngine

        ''' <summary>
        ''' This list contain the costant of a job of type
        ''' </summary>
        Private Enum ScheduleJobType
            notDefined
            notifyLocalWorkMachine
            logRotate
            registryRotate
            performanceProfile
            refreshTracker
        End Enum

        ''' <summary>
        ''' This class contain all element of single slot of a scheduler
        ''' </summary>
        Private Class JobSchedule
            Public Property [type] As ScheduleJobType
            Public Property nextTimeExecuted As Double = 0
            Public Property supportData As Object
        End Class

        Private Property _ScheduleJobs As New List(Of JobSchedule)


        ''' <summary>
        ''' This method provide to return a Local Work Machine
        ''' </summary>
        ''' <returns></returns>
        Private Function loadLocalWorkMachineSlot() As JobSchedule
            Try
                environment.log.trackEnter("AreaScheduler.MainEngine.loadLocalWorkMachineSlot")

                Dim response As New JobSchedule

                response.type = ScheduleJobType.notifyLocalWorkMachine
                response.nextTimeExecuted = 0

                environment.log.track("AreaScheduler.MainEngine.loadLocalWorkMachineSlot", "Next Time executed = Now")

                Return response
            Catch ex As Exception
                environment.log.trackException("Scheduler.MainEngine.loadLocalWorkMachineSlot", ex.Message)

                Return New JobSchedule
            Finally
                environment.log.trackExit("AreaScheduler.MainEngine.loadLocalWorkMachineSlot")
            End Try
        End Function

        ''' <summary>
        ''' This method provide to return a Log Rotate Job
        ''' </summary>
        ''' <returns></returns>
        Private Function loadLogRotate() As JobSchedule
            Try
                environment.log.trackEnter("AreaScheduler.MainEngine.loadLogRotate")

                Dim response As New JobSchedule

                response.type = ScheduleJobType.logRotate

#If DEBUG Then
                response.nextTimeExecuted = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime() + 10000
                response.nextTimeExecuted = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime() + (AreaCommon.Main.environment.settings.autoMaintenance.autoMaintenanceFrequencyHours * 60 * 60 * CDbl(1000))
#Else
                response.nextTimeExecuted = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime() + (AreaCommon.Main.environment.settings.autoMaintenance.autoMaintenanceFrequencyHours * 60 * 60 * CDbl(1000))
#End If


                environment.log.track("AreaScheduler.MainEngine.loadLogRotate", "Next Time executed = " & response.nextTimeExecuted)

                Return response
            Catch ex As Exception
                environment.log.trackException("Scheduler.loadLogRotate", ex.Message)

                Return New JobSchedule
            Finally
                environment.log.trackExit("AreaScheduler.MainEngine.loadLogRotate")
            End Try
        End Function

        ''' <summary>
        ''' This method provide to return a Registry Rotate Job
        ''' </summary>
        ''' <returns></returns>
        Private Function loadRegistryRotate() As JobSchedule
            Try
                environment.log.trackEnter("AreaScheduler.MainEngine.loadRegistryRotate")

                Dim response As New JobSchedule

                response.type = ScheduleJobType.registryRotate

#If DEBUG Then
                response.nextTimeExecuted = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime() + 10000
                'response.nextTimeExecuted = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime() + (AreaCommon.Main.environment.settings.autoMaintenance.autoMaintenanceFrequencyHours * 60 * 60 * CDbl(1000)) + 1000
#Else
                response.nextTimeExecuted = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime() + (AreaCommon.Main.environment.settings.autoMaintenance.autoMaintenanceFrequencyHours * 60 * 60 * CDbl(1000)) + 1000
#End If

                environment.log.track("AreaScheduler.MainEngine.loadRegistryRotate", "Next Time executed = " & response.nextTimeExecuted)

                Return response
            Catch ex As Exception
                environment.log.trackException("Scheduler.MainEngine.loadRegistryRotate", ex.Message)

                Return New JobSchedule
            Finally
                environment.log.trackExit("AreaScheduler.MainEngine.loadRegistryRotate")
            End Try
        End Function

        ''' <summary>
        ''' This method provide to return a Performance Profile Job
        ''' </summary>
        ''' <returns></returns>
        Private Function loadPerformanceProfile() As JobSchedule
            Try
                environment.log.trackEnter("AreaScheduler.MainEngine.loadPerformanceProfile")

                Dim response As New JobSchedule

                response.type = ScheduleJobType.performanceProfile

#If DEBUG Then
                response.nextTimeExecuted = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime() + 10000
#Else
                response.nextTimeExecuted = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime() + (AreaCommon.Main.environment.settings.performanceProfile.useEveryHour * 60 * 60 * CDbl(1000)) + 2000
#End If

                environment.log.track("AreaScheduler.MainEngine.loadPerformanceProfile", "Next Time executed = " & response.nextTimeExecuted)

                Return response
            Catch ex As Exception
                environment.log.trackException("Scheduler.loadPerformanceProfile", ex.Message)

                Return New JobSchedule
            Finally
                environment.log.trackExit("AreaScheduler.MainEngine.loadPerformanceProfile")
            End Try
        End Function

        ''' <summary>
        ''' This method provide to return a Refresh cache tracked Job
        ''' </summary>
        ''' <returns></returns>
        Private Function loadRefreshCacheTracker() As JobSchedule
            Try
                environment.log.trackEnter("AreaScheduler.MainEngine.loadRefreshCacheTracker")

                Dim response As New JobSchedule

                response.type = ScheduleJobType.refreshTracker

                response.nextTimeExecuted = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime() + 60000

                environment.log.track("AreaScheduler.MainEngine.loadRefreshCacheTracker", "Next Time executed = " & response.nextTimeExecuted)

                Return response
            Catch ex As Exception
                environment.log.trackException("Scheduler.loadRefreshCacheTracker", ex.Message)

                Return New JobSchedule
            Finally
                environment.log.trackExit("AreaScheduler.MainEngine.loadRefreshCacheTracker")
            End Try
        End Function

        ''' <summary>
        ''' This method provide to build a URL
        ''' </summary>
        ''' <param name="api"></param>
        ''' <param name="ipAddress"></param>
        ''' <returns></returns>
        Private Function buildURL(ByVal api As String) As String
            Dim url As String = ""
            Try
                Dim proceed As Boolean = True

                If proceed Then
                    If AreaCommon.Main.environment.localWorkMachineSettings.secureChannel Then
                        url += "https"
                    Else
                        url += "http"
                    End If
                End If
                If proceed Then
                    url += "://localhost:" & AreaCommon.Main.environment.localWorkMachineSettings.servicePort & "/api"
                End If
                If proceed Then
                    If (AreaCommon.Main.environment.localWorkMachineSettings.serviceID.Length > 0) Then
                        url += "/" & AreaCommon.Main.environment.localWorkMachineSettings.serviceID & api
                    Else
                        url += api
                    End If
                End If
            Catch ex As Exception
            End Try

            Return url
        End Function

        ''' <summary>
        ''' This method provide to call a Local Work Machine
        ''' </summary>
        ''' <returns></returns>
        Private Function callLocalWorkMachine(ByVal serviceName As String) As Boolean
            Try
                AreaAsynchronous.Internal.currentNumJobInRun += 1

                Dim remote As New ProxyWS(Of MinimalDataToRegister)
                Dim proceed As Boolean = True
                Dim data As New MinimalDataToRegister

                If proceed Then
                    remote.url = buildURL("/linked/addNewService/")
                End If
                If proceed Then
                    data.service = serviceName
                    data.portNumber = AreaCommon.Main.environment.settings.servicePort

                    remote.data = data
                End If
                If proceed Then
                    proceed = (remote.sendData("PUT") = "")
                End If
                If proceed Then
                    proceed = (remote.remoteResponse.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete)
                End If

                Return proceed
            Catch exFile As System.IO.FileLoadException
                IntegrityApplication.executeRepairNewton(exFile.FileName)

                Return False
            Finally
                AreaAsynchronous.Internal.currentNumJobInRun -= 1
            End Try
        End Function

        ''' <summary>
        ''' This method provide to call in asynch the delete procedure old log
        ''' </summary>
        ''' <param name="serviceName"></param>
        ''' <returns></returns>
        Private Function callLogRotate() As Boolean
            Try
                Dim asynchThread As Thread

                asynchThread = New Thread(AddressOf AreaAsynchronous.executeLogClean)

                asynchThread.Start()

                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to call in asynch the delete a procedure old registry
        ''' </summary>
        ''' <returns></returns>
        Private Function callRegistryRotate() As Boolean
            Try
                Dim asynchThread As Thread

                asynchThread = New Thread(AddressOf AreaAsynchronous.executeRegistryClean)

                asynchThread.Start()

                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to call in asynch the compute log file into Performance Profile
        ''' </summary>
        ''' <returns></returns>
        Private Function callPerformanceProfile() As Boolean
            Try
                Dim asynchThread As Thread

                asynchThread = New Thread(AddressOf AreaAsynchronous.executePerformanceProfile)

                asynchThread.Start()

                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to process slot
        ''' </summary>
        ''' <param name="item"></param>
        ''' <returns></returns>
        Private Function processJob(ByRef item As JobSchedule, ByVal serviceName As String) As Boolean
            Try
                If (item.nextTimeExecuted < CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()) Then
                    Select Case item.type
                        Case ScheduleJobType.notifyLocalWorkMachine
                            callLocalWorkMachine(serviceName)

                            item.nextTimeExecuted = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime() + 10000

                            Return True
                        Case ScheduleJobType.logRotate
                            environment.log.track("AreaScheduler.MainEngine.processJob", "Start log rotate")
                            environment.registry.addNew(CHCModelsLibrary.AreaModel.Registry.RegistryData.TypeEvent.autoMaintenanceStartup, "Log Rotate")

                            item.nextTimeExecuted = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime() + (AreaCommon.Main.environment.settings.autoMaintenance.autoMaintenanceFrequencyHours * 60 * 60 * CDbl(1000))

                            callLogRotate()

                            environment.log.track("AreaScheduler.MainEngine.processJob", $"Log rotate run. Next time {item.nextTimeExecuted}")
                        Case ScheduleJobType.registryRotate
                            environment.log.track("AreaScheduler.MainEngine.processJob", "Start registry rotate")
                            environment.registry.addNew(CHCModelsLibrary.AreaModel.Registry.RegistryData.TypeEvent.autoMaintenanceStartup, "Registry Rotate")

                            item.nextTimeExecuted = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime() + (AreaCommon.Main.environment.settings.autoMaintenance.autoMaintenanceFrequencyHours * 60 * 60 * CDbl(1000)) + 1000

                            callRegistryRotate()

                            environment.log.track("AreaScheduler.MainEngine.processJob", $"Registry rotate run. Next time {item.nextTimeExecuted}")
                        Case ScheduleJobType.performanceProfile
                            environment.log.track("AreaScheduler.MainEngine.processJob", "Start Performance Profile")
                            environment.registry.addNew(CHCModelsLibrary.AreaModel.Registry.RegistryData.TypeEvent.autoMaintenanceStartup, "Performance Profile")

                            item.nextTimeExecuted = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime() + (AreaCommon.Main.environment.settings.performanceProfile.useEveryHour * 60 * 60 * CDbl(1000)) + 2000

                            callPerformanceProfile()

                            environment.log.track("AreaScheduler.MainEngine.processJob", $"Registry rotate run. Next time {item.nextTimeExecuted}")
                        Case ScheduleJobType.refreshTracker
                            environment.log.writeCacheToLogFile()

                            item.nextTimeExecuted = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime() + 60000
                    End Select

                    Return False
                End If

                Return True
            Catch ex As Exception
                environment.log.trackException("Scheduler.processJob", ex.Message)

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to load a schedule list
        ''' </summary>
        ''' <returns></returns>
        Public Function loadScheduleList() As Boolean
            Try
                environment.log.trackEnter("AreaScheduler.MainEngine.loadScheduleList")

                If AreaCommon.Main.environment.settings.useLog Then
                    _ScheduleJobs.Add(loadLogRotate)
                End If
                If AreaCommon.Main.environment.settings.useEventRegistry Then
                    _ScheduleJobs.Add(loadRegistryRotate)
                End If
                If AreaCommon.Main.environment.settings.useProfile Then
                    _ScheduleJobs.Add(loadPerformanceProfile)
                End If
                _ScheduleJobs.Add(loadRefreshCacheTracker)

                ' Count the call

                ' Check the alert

                Return True
            Catch ex As Exception
                environment.log.trackException("AreaScheduler.MainEngine.loadScheduleList", ex.Message)

                Return False
            Finally
                environment.log.trackExit("AreaScheduler.MainEngine.loadScheduleList")
            End Try
        End Function

        ''' <summary>
        ''' This method provide to ad
        ''' </summary>
        ''' <returns></returns>
        Public Function addLocalWorkMachineJob() As Boolean
            Try
                _ScheduleJobs.Add(loadLocalWorkMachineSlot)

                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to update next time executed local work machine job
        ''' </summary>
        ''' <returns></returns>
        Private Function checkUpdateNextLocalWorkMachineJob() As Boolean
            Try
                If (AreaCommon.Main.updateLastGetServiceInformation > 0) Then
                    For Each item In _ScheduleJobs
                        If (item.type = ScheduleJobType.notifyLocalWorkMachine) Then
                            item.nextTimeExecuted = AreaCommon.Main.updateLastGetServiceInformation + 10000
                        End If
                    Next
                End If

                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to manage a job process list
        ''' </summary>
        ''' <returns></returns>
        Public Function manageJobProcessList(ByVal serviceName As String) As Boolean
            Try
                For Each item In _ScheduleJobs
                    checkUpdateNextLocalWorkMachineJob()
                    processJob(item, serviceName)

                    Threading.Thread.Sleep(100)
                Next

                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

    End Class

End Namespace
