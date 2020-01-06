Option Compare Text
Option Explicit On



Namespace AreaCommon


    Module AppModule


        Public paths As New AreaSystem.Paths
        Public cryptoAssetDefinitionManager As CHCDefinitionEngineLibrary.CHCEngines.CryptoAssetDefinitionEngine
        Public transChainDefinitionManager As CHCDefinitionEngineLibrary.CHCEngines.TransChainDefinitionEngine
        Public log As New CHCServerSupport.Support.LogEngine
        Public counter As New CHCServerSupport.Support.CounterEngine
        Public settings As New AppSettings




        Public Function run() As Boolean

            Try

                log.track("AppModule.run", "Begin")

                log.init(IO.Path.Combine(paths.pathBaseData, "System", "Logs"))
                log.track("AppModule.run", "before coinArchive.init")

                paths.init()

                cryptoAssetDefinitionManager = New CHCDefinitionEngineLibrary.CHCEngines.CryptoAssetDefinitionEngine(paths.pathCryptoAssetValue)
                transChainDefinitionManager = New CHCDefinitionEngineLibrary.CHCEngines.TransChainDefinitionEngine(paths.pathTransChainValue)

                settings.logAccessActive = True
                settings.logActive = True

                counter.init(IO.Path.Combine(paths.pathBaseData, "System", "Counters"))

                log.noSave = Not settings.logActive

                log.track("moduleMain.run", "coinArchive.init failed", "warning")

                Return True

            Catch ex As Exception

                Return False

            End Try

        End Function



    End Module



End Namespace