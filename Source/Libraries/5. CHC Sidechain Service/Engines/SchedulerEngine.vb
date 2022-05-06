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
                Dim response As New JobSchedule

                response.type = ScheduleJobType.notifyLocalWorkMachine
                response.nextTimeExecuted = 0

                Return response
            Catch ex As Exception
                environment.log.trackException("Scheduler.loadLocalWorkMachineSlot", ex.Message)

                Return New JobSchedule
            End Try
        End Function

        ''' <summary>
        ''' This method provide to return a Log Rotate Job
        ''' </summary>
        ''' <returns></returns>
        Private Function loadLogRotate() As JobSchedule
            Try
                Dim response As New JobSchedule

                response.type = ScheduleJobType.logRotate

                response.nextTimeExecuted = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime() + (AreaCommon.Main.environment.settings.autoMaintenance.autoMaintenanceFrequencyHours * 60 * 60 * CDbl(1000))

                Return response
            Catch ex As Exception
                environment.log.trackException("Scheduler.loadLogRotate", ex.Message)

                Return New JobSchedule
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
            Catch exFile As system.io.FileLoadException
                IntegrityApplication.executeRepairNewton(exFile.FileName)

                Return False
            Catch ex As Exception
                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to 
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
        ''' This method provide to process slot
        ''' </summary>
        ''' <param name="item"></param>
        ''' <returns></returns>
        Private Function processJob(ByVal item As JobSchedule, ByVal serviceName As String) As Boolean
            Try
                If (item.nextTimeExecuted < CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()) Then
                    Select Case item.type
                        Case ScheduleJobType.notifyLocalWorkMachine
                            callLocalWorkMachine(serviceName)

                            item.nextTimeExecuted = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime() + 10000

                            Return True
                        Case ScheduleJobType.logRotate
                            environment.log.track("AreaScheduler.MainEngine.processJob", "Start log rotate")

                            callLogRotate()

                            item.nextTimeExecuted = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime() + (AreaCommon.Main.environment.settings.autoMaintenance.autoMaintenanceFrequencyHours * 60 * 60 * CDbl(1000))

                            environment.log.track("AreaScheduler.MainEngine.processJob", $"Complete log rotate. Next time {item.nextTimeExecuted}")
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
            _ScheduleJobs.Add(loadLogRotate)

            ' Manage the Profile 

            ' Count the call

            ' Check the alert

            Return True
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
