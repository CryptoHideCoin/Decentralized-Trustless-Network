Option Compare Text
Option Explicit On



Namespace AreaCommon


    Module AppModule


        Public paths As New AreaSystem.Paths
        Public contractsOfValueManager As CHCContractOfValueEngineLibrary.CHCEngines.BaseContractOfValueDataEngine




        Public Function run() As Boolean

            paths.init()

            contractsOfValueManager = New CHCContractOfValueEngineLibrary.CHCEngines.BaseContractOfValueDataEngine(paths.pathUnitOfExchangeValue)

            Return True

        End Function



    End Module



End Namespace