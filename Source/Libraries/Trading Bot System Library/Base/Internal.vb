Option Compare Text
Option Explicit On







Namespace AreaAsynchronous

    Module Internal

        Public Property currentNumJobInRun As Integer = 0


        ''' <summary>
        ''' This method provide to execute a log clean 
        ''' </summary>
        ''' <returns></returns>
        Public Function executeDownloadCurrencies(Optional ByVal automatic As Boolean = True) As Boolean
            Dim ownerId As String = "executeDownloadCurrencies-" & Guid.NewGuid.ToString

            Try
                currentNumJobInRun += 1

                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackEnter("Internal.executeDownloadCurrencies", ownerId)

                For Each singleExchange In AreaCommon.state.exchangesEngine.list
                    AreaCommon.state.currenciesDownloadEngine.downloadFromExchange(singleExchange.id, singleExchange.name, Not automatic)
                Next

                Return True
            Catch ex As Exception
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackException("Internal.executeDownloadCurrencies", ownerId, ex.Message)

                Return False
            Finally
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackExit("Internal.executeDownloadCurrencies", ownerId)

                currentNumJobInRun -= 1
            End Try
        End Function

    End Module

End Namespace
