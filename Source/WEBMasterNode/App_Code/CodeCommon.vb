Option Compare Text
Option Explicit On

Imports CHCMasterNodeEngineLibrary



Namespace AreaCommon


    Module AppModule


        Public paths As New AreaSystem.Paths
        Public cryptoAssetDefinitionManager As CHCEngines.CryptoAssetDefinitionEngine
        Public transChainDefinitionManager As CHCEngines.TransChainDefinitionEngine
        Public log As New CHCServerSupport.Support.LogEngine
        Public logRotate As New CHCServerSupport.Support.LogRotateEngine
        Public counter As New CHCServerSupport.Support.CounterEngine
        Public registry As New CHCServerSupport.Support.RegistryEngine
        Public settings As CHCEngines.PeerSettingEngine
        Public systemStatus As CHCEngines.PeerStatusEngine
        Public tokenManager As CHCEngines.TokenManagerEngine
        Public engine As CHCCommonLibrary.StandardInterface





        Public Function run() As Boolean

            Try

                Dim pathLog As String = IO.Path.Combine(paths.pathBaseData, "System")

                log.track("AppModule.run", "Begin")

                registry.init(pathLog)
                registry.addNew(CHCServerSupport.Support.RegistryEngine.RegistryData.TypeEvent.applicationStartUp)

                pathLog = IO.Path.Combine(pathLog, "Logs")

                log.init(pathLog,, registry)
                log.track("AppModule.run", "before coinArchive.init")

                paths.init()

                tokenManager = New CHCEngines.TokenManagerEngine(paths.pathBaseData)

                cryptoAssetDefinitionManager = New CHCEngines.CryptoAssetDefinitionEngine(paths.pathCryptoAssetValue)
                transChainDefinitionManager = New CHCEngines.TransChainDefinitionEngine(paths.pathTransChainValue)

                settings = New CHCEngines.PeerSettingEngine(paths.pathBaseData, log)

                counter.init(IO.Path.Combine(paths.pathBaseData, "System", "Counters"))

                log.noSave = (settings.data.useTrack = Models.Administration.SettingModel.TrackRuntimeModeEnum.dontTrack)

                With settings.data.trackRotate

                    logRotate.configuration.frequency = .frequency
                    logRotate.configuration.keepFile = .keepFile
                    logRotate.configuration.keepLast = .keepLast

                End With

                logRotate.path = pathLog

                logRotate.run(log)

                systemStatus = New CHCEngines.PeerStatusEngine

                systemStatus.Init(log, engine)

                log.track("AppModule.run", "Complete")

                Return True

            Catch ex As Exception

                If Not IsNothing(log) Then

                    log.track("AppModule.run", "Error:" & ex.Message, "Fatal")

                End If

                Return False

            End Try

        End Function



        Public Function refreshBatch(ByRef adapterLog As CHCServerSupport.Support.LogEngine) As Boolean

            Try

                adapterLog.track("AppModule.refreshBatch", "Begin")

                Return logRotate.run(adapterLog)

            Catch ex As Exception

                adapterLog.track("AppModule.refreshBatch", "Error:" & ex.Message, "Fatal")

                Return False

            Finally

                adapterLog.track("AppModule.refreshBatch", "Complete")

            End Try

        End Function



    End Module



End Namespace