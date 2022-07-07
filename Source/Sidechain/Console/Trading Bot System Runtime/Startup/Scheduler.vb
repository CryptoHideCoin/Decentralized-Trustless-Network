Option Compare Text
Option Explicit On

Imports CHCSidechainServiceLibrary.AreaCommon.Main
Imports CHCModelsLibrary.AreaModel.Information.InternalServiceInformation




Namespace AreaCommon.Startup

    Module Scheduler

        Private _Engine As New CHCSidechainServiceLibrary.AreaScheduler.MainEngine

        ''' <summary>
        ''' This method provide to start service processor
        ''' </summary>
        Private Sub startServiceProcessor()
            Try
                environment.log.trackEnter("Scheduler.startServiceProcessor", "Main")

                _Engine.loadScheduleList()

                Do While (serviceInformation.currentStatus = EnumInternalServiceState.started)
                    _Engine.manageJobProcessList(AreaCommon.Customized.CUSTOM_ChainServiceName)

                    Threading.Thread.Sleep(1000)
                Loop

                Environment.log.trackExit("Scheduler.startServiceProcessor", "Main")
            Catch ex As Exception
                Environment.log.trackException("Scheduler.startServiceProcessor", "Main", ex.Message)
            End Try
        End Sub

        ''' <summary>
        ''' This method provide to add work local machine job
        ''' </summary>
        ''' <returns></returns>
        Public Function addWorkLocalMachineJob() As Boolean
            Return _Engine.addLocalWorkMachineJob()
        End Function

        ''' <summary>
        ''' This method provide to add a new trade job
        ''' </summary>
        ''' <param name="item"></param>
        ''' <returns></returns>
        Public Function addTradeJob(ByVal item As CHCModelsLibrary.AreaModel.Service.Scheduler.JobSchedule) As Boolean
            Return _Engine.addExternalJob(item)
        End Function



        ''' <summary>
        ''' This method provide to start all maintenance service
        ''' </summary>
        ''' <returns></returns>
        Public Function run() As Boolean
            Try
                Dim objWS As Threading.Thread

                Environment.log.trackEnter("Scheduler.run", "Main")

                Do While (serviceInformation.currentStatus <> EnumInternalServiceState.started)
                    Threading.Thread.Sleep(0)
                Loop

                objWS = New Threading.Thread(AddressOf startServiceProcessor)

                objWS.Start()

                Environment.log.trackExit("Scheduler.run", "Main")

                Return True
            Catch ex As Exception
                Environment.log.trackException("Scheduler.run", "Main", ex.Message)

                Return False
            End Try
        End Function

    End Module

End Namespace
