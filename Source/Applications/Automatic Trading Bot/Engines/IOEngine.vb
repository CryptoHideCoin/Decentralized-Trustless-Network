Option Compare Text
Option Explicit On



Namespace AreaEngines.IO

    Public Class IOEngine

        Public Property tenantRootPath As String = ""
        Public Property orderRootPath As String = ""

        Public Property orderClosePath As String = ""
        Public Property orderPlacedPath As String = ""
        Public Property orderToDeliveryPath As String = ""

        Public Property botArchivePath As String = ""

        Public Property configurationPath As String = ""
        Public Property botListPath As String = ""
        Public Property summaryPath As String = ""
        Public Property accountPath As String = ""
        Public Property productsPath As String = ""
        Public Property automaticBotPath As String = ""
        Public Property blockCounterPath As String = ""
        Public Property JournalPath As String = ""
        Public Property fundReservationPath As String = ""
        Public Property logPath As String = ""
        Public Property tickerPath As String = ""

        Public Property newTenant As Boolean = False


        ''' <summary>
        ''' This method provide to create order path
        ''' </summary>
        ''' <returns></returns>
        Private Function checkAndMakeOrderPath() As Boolean
            If Not System.IO.Directory.Exists(orderRootPath) Then
                System.IO.Directory.CreateDirectory(orderRootPath)
            End If

            orderClosePath = System.IO.Path.Combine(orderRootPath, "Closed")

            If Not System.IO.Directory.Exists(orderClosePath) Then
                System.IO.Directory.CreateDirectory(orderClosePath)
            End If

            orderPlacedPath = System.IO.Path.Combine(orderRootPath, "Placed")

            If Not System.IO.Directory.Exists(orderPlacedPath) Then
                System.IO.Directory.CreateDirectory(orderPlacedPath)
            End If

            orderToDeliveryPath = System.IO.Path.Combine(orderRootPath, "To Delivery")

            If Not System.IO.Directory.Exists(orderToDeliveryPath) Then
                System.IO.Directory.CreateDirectory(orderToDeliveryPath)
            End If

            Return True
        End Function

        ''' <summary>
        ''' This method provide to update a user personal data of the tenant
        ''' </summary>
        ''' <returns></returns>
        Public Function updatePersonaData() As Boolean
            Return CHCCommonLibrary.AreaEngine.DataFileManagement.Json.IOFast(Of AreaCommon.Models.User.UserDataPersonalModel).save(configurationPath, AreaState.defaultUserDataAccount)
        End Function

        ''' <summary>
        ''' This method provide to update the botlist into the tenant
        ''' </summary>
        ''' <returns></returns>
        Public Function updateBotList() As Boolean
            Return CHCCommonLibrary.AreaEngine.DataFileManagement.Json.IOFast(Of AreaCommon.Models.Bot.BotListModel).save(botListPath, AreaState.botList)
        End Function

        ''' <summary>
        ''' This method provide to save into file the summary
        ''' </summary>
        ''' <returns></returns>
        Public Function updateSummary() As Boolean
            Return CHCCommonLibrary.AreaEngine.DataFileManagement.Json.IOFast(Of AreaCommon.Models.Account.SummaryModel).save(summaryPath, AreaState.summary)
        End Function

        Public Function updateCryptocurrency() As Boolean
            Return CHCCommonLibrary.AreaEngine.DataFileManagement.Json.IOFast(Of AreaCommon.Models.Products.ProductsModel).save(productsPath, AreaState.products)
        End Function

        Public Function updateAutomaticBot() As Boolean
            Return CHCCommonLibrary.AreaEngine.DataFileManagement.Json.IOFast(Of AreaCommon.Models.Bot.BotAutomatic).save(automaticBotPath, AreaState.automaticBot)
        End Function

        Public Function updateFundReservation() As Boolean
            Return CHCCommonLibrary.AreaEngine.DataFileManagement.Json.IOFast(Of AreaCommon.Models.Journal.FundReservationModel).save(fundReservationPath, AreaState.gainFund)
        End Function

        Public Function updateTickValue(ByVal pairName As String, ByRef tickData As AreaCommon.Models.Pair.TickInformation) As Boolean
            Dim pathName As String = System.IO.Path.Combine(tickerPath, pairName & ".tick")

            Return CHCCommonLibrary.AreaEngine.DataFileManagement.Json.IOFast(Of AreaCommon.Models.Pair.TickInformation).save(pathName, tickData)
        End Function

        Public Function readTickValue(ByVal pairName As String) As AreaCommon.Models.Pair.TickInformation
            Dim pathName As String = System.IO.Path.Combine(tickerPath, pairName & ".tick")
            Dim data As New AreaCommon.Models.Pair.TickInformation

            If System.IO.File.Exists(pathName) Then
                data = CHCCommonLibrary.AreaEngine.DataFileManagement.Json.IOFast(Of AreaCommon.Models.Pair.TickInformation).read(pathName)
            End If

            Return data
        End Function

        ''' <summary>
        ''' This method provide to update the data into the wallet
        ''' </summary>
        ''' <returns></returns>
        Public Function updateWallet() As Boolean
            If Not AreaState.defaultUserDataAccount.useVirtualAccount Then
                Try
                    System.IO.File.Delete(accountPath)
                Catch ex As Exception
                End Try

                Return True
            End If

            Dim accounts As New AreaCommon.Models.Account.AccountsModel

            For Each account In AreaState.accounts
                accounts.wallet.Add(New AreaCommon.Models.Account.AccountBaseForSerializationModel With {.key = account.Key, .id = account.Value.id, .amount = account.Value.amount})
            Next

            Return CHCCommonLibrary.AreaEngine.DataFileManagement.Json.IOFast(Of AreaCommon.Models.Account.AccountsModel).save(accountPath, accounts)
        End Function

        Public Function saveCurrentCounterBlock() As Boolean
            Dim filePath As String = ""

            filePath = System.IO.Path.Combine(blockCounterPath, AreaState.journal.currentBlockCounters.timeStart.ToString() & ".CurrentCounterBlock")

            Return CHCCommonLibrary.AreaEngine.DataFileManagement.Json.IOFast(Of AreaCommon.Models.Journal.BlockCounterModel).save(filePath, AreaState.journal.currentBlockCounters)
        End Function

        ''' <summary>
        ''' This method provide to update the trade close
        ''' </summary>
        ''' <param name="botId"></param>
        ''' <param name="data"></param>
        ''' <returns></returns>
        Public Function updateTradeClose(ByVal botId As String, ByRef data As AreaCommon.Models.Bot.TradeModel) As Boolean
            Dim pathComplete As String = System.IO.Path.Combine(tenantRootPath, "Bot-" & botId, "Trade Close", data.id & ".json")

            Return CHCCommonLibrary.AreaEngine.DataFileManagement.Json.IOFast(Of AreaCommon.Models.Bot.TradeModel).save(pathComplete, data)
        End Function

        ''' <summary>
        ''' This method provide to save the data trade into the file
        ''' </summary>
        ''' <param name="botId"></param>
        ''' <param name="data"></param>
        ''' <returns></returns>
        Public Function updateBotData(ByVal botId As String, ByRef data As AreaCommon.Models.Bot.BotDataModel) As Boolean
            Dim pathComplete As String = System.IO.Path.Combine(tenantRootPath, "Bot-" & botId, "data.json")

            Return CHCCommonLibrary.AreaEngine.DataFileManagement.Json.IOFast(Of AreaCommon.Models.Bot.BotDataModel).save(pathComplete, data)
        End Function

        ''' <summary>
        ''' This method provide to get a trade close from a db
        ''' </summary>
        ''' <param name="tradeId"></param>
        ''' <returns></returns>
        Public Function getTradeClose(ByVal botId As String, ByVal tradeId As String) As AreaCommon.Models.Bot.TradeModel
            Dim pathComplete As String = System.IO.Path.Combine(tenantRootPath, "Bot-" & botId, "Trade Close", tradeId & ".json")

            Return CHCCommonLibrary.AreaEngine.DataFileManagement.Json.IOFast(Of AreaCommon.Models.Bot.TradeModel).read(pathComplete)
        End Function

        ''' <summary>
        ''' This method provide to update the bot settings
        ''' </summary>
        ''' <returns></returns>
        Public Function updateBotSetting(ByRef data As AreaCommon.Models.Bot.BotConfigurationsModel) As Boolean
            Dim pathComplete As String = System.IO.Path.Combine(tenantRootPath, "Bot-" & data.parameters.header.id)
            Dim fileName As String = System.IO.Path.Combine(pathComplete, "Settings.json")

            AreaState.bots.Add(data.parameters.header.id, data)

            AreaState.botList.ActiveBots.Add(data.parameters.header.id)

            If Not System.IO.Directory.Exists(pathComplete) Then
                System.IO.Directory.CreateDirectory(pathComplete)
            End If

            pathComplete = System.IO.Path.Combine(pathComplete, "Trade Close")

            If Not System.IO.Directory.Exists(pathComplete) Then
                System.IO.Directory.CreateDirectory(pathComplete)
            End If

            If CHCCommonLibrary.AreaEngine.DataFileManagement.Json.IOFast(Of AreaCommon.Models.Bot.BotParametersModel).save(fileName, data.parameters) Then
                Return updateBotList()
            End If

            Return False
        End Function

        Public Function updateJournal() As Boolean
            Return CHCCommonLibrary.AreaEngine.DataFileManagement.Json.IOFast(Of AreaCommon.Models.Journal.CumulativeModel).save(JournalPath, AreaState.journal)
        End Function

        ''' <summary>
        ''' This method provide to archive Bot into DB
        ''' </summary>
        ''' <param name="id"></param>
        ''' <returns></returns>
        Public Function archiveBot(ByVal id As String) As Boolean
            AreaState.bots(id).parameters.header.isActive = False

            For Each item In AreaState.bots
                If (item.Value.parameters.header.id.CompareTo(id) = 0) Then
                    updateBotData(item.Value.parameters.header.id, item.Value.data)

                    AreaState.bots.Remove(id)

                    Exit For
                End If
            Next

            For Each item In AreaState.botList.ActiveBots
                If (item = id) Then
                    AreaState.botList.ActiveBots.Remove(item)

                    Exit For
                End If
            Next

            If (AreaState.botList.ActiveBots.Count = 0) Then
                System.IO.File.Delete(botListPath)
            Else
                updateBotList()
            End If

            Dim pathBot As String = System.IO.Path.Combine(tenantRootPath, "Bot-" & id)
            Dim pathArchived As String = System.IO.Path.Combine(tenantRootPath, "Archived", "Bot-" & id)

            System.IO.Directory.CreateDirectory(pathArchived)

            My.Computer.FileSystem.CopyDirectory(pathBot, pathArchived, True)

            System.IO.Directory.Delete(pathBot, True)

            Return True
        End Function


        Public Sub logAction(ByVal message As String)
            'System.IO.File.AppendAllText(logPath, message & vbCrLf)
        End Sub


        Public Function getPageCounters() As List(Of String)
            Dim files() As String = System.IO.Directory.GetFiles(blockCounterPath)
            Dim fileList As New List(Of String)
            Dim returnList As New List(Of String)
            Dim majorFile As String

            For Each file As String In files
                fileList.Add(file)
            Next

            Do While (fileList.Count > 1)
                majorFile = fileList(0)

                For count = 1 To fileList.Count - 1
                    If fileList(count) > majorFile Then
                        majorFile = fileList(count)
                    End If
                Next

                returnList.Add(majorFile)
                fileList.Remove(majorFile)
            Loop

            If (fileList.Count > 0) Then
                majorFile = fileList(0)

                returnList.Add(majorFile)
            End If

            Return returnList
        End Function

        ''' <summary>
        ''' This method provide to add a new order to the service
        ''' </summary>
        ''' <param name="productId"></param>
        ''' <param name="orderId"></param>
        ''' <param name="orderNumber"></param>
        ''' <returns></returns>
        Private Function startMonitorOrder(ByVal productId As String, ByVal orderId As String, ByVal orderNumber As String) As Boolean
            If Not AreaState.orders.ContainsKey(orderId) Then
                Dim newSimply As New AreaCommon.Models.Order.SimplyOrderModel

                newSimply.accountCredentials = AreaState.defaultUserDataAccount.exchangeAccess
                newSimply.productId = productId
                newSimply.internalOrderId = orderId
                newSimply.publicOrderId = orderNumber

                AreaState.orders.Add(orderId, newSimply)
            End If

            Return True
        End Function

        Private Sub loadOrderPlaced()
            Try
                For Each product In AreaState.products.items
                    With product.activity.openBuy
                        If (.state = AreaCommon.Models.Bot.BotOrderModel.OrderStateEnumeration.placed) Then

                            'startMonitorOrder(product.header.key, .internalOrderId, .orderNumber)

                        End If
                    End With

                    If (product.activity.sell.state = AreaCommon.Models.Bot.BotOrderModel.OrderStateEnumeration.placed) Then

                        'startMonitorOrder(product.header.key, product.activity.sell.internalOrderId, product.activity.sell.orderNumber)

                    End If
                Next

                AreaCommon.Engines.Orders.start()
            Catch ex As Exception
            End Try
        End Sub

        ''' <summary>
        ''' This method provide to initialize the engine
        ''' </summary>
        ''' <param name="path"></param>
        ''' <returns></returns>
        Public Function init(ByVal path As String) As Boolean
            Dim botPath As String = ""
            Dim newBot As AreaCommon.Models.Bot.BotConfigurationsModel

            path = path.Replace(Chr(34) & Chr(34), "").Trim()

            If Not System.IO.Directory.Exists(path) Then
                System.IO.Directory.CreateDirectory(path)
            End If

            tenantRootPath = path

            tickerPath = System.IO.Directory.GetParent(path).FullName
            tickerPath = System.IO.Directory.GetParent(tickerPath).FullName
            tickerPath = System.IO.Path.Combine(tickerPath, "Tickers")

            If Not System.IO.Directory.Exists(tickerPath) Then
                System.IO.Directory.CreateDirectory(tickerPath)
            End If

            AreaState.defaultUserDataAccount.tenantName = System.IO.Path.GetFileName(path)
            orderRootPath = System.IO.Path.Combine(System.IO.Directory.GetParent(path).Parent.FullName, "Orders")
            configurationPath = System.IO.Path.Combine(path, "Configuration.json")
            botListPath = System.IO.Path.Combine(path, "Botlist.json")
            summaryPath = System.IO.Path.Combine(path, "Summary.json")
            accountPath = System.IO.Path.Combine(path, "Accounts.json")
            productsPath = System.IO.Path.Combine(path, "Products.json")
            automaticBotPath = System.IO.Path.Combine(path, "AutomaticBot.json")
            fundReservationPath = System.IO.Path.Combine(path, "FundReservation.json")

            logPath = System.IO.Path.Combine(path, "Logs")

            If Not System.IO.Directory.Exists(logPath) Then
                System.IO.Directory.CreateDirectory(logPath)
            End If

            logPath = System.IO.Path.Combine(logPath, CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime().ToString.Replace(",", "") & ".log")

            checkAndMakeOrderPath()

            blockCounterPath = System.IO.Path.Combine(path, "DayCounters")
            JournalPath = System.IO.Path.Combine(path, "Journal.json")

            If Not System.IO.Directory.Exists(blockCounterPath) Then
                System.IO.Directory.CreateDirectory(blockCounterPath)
            End If

            botArchivePath = System.IO.Path.Combine(path, "Archived")

            If Not System.IO.Directory.Exists(botArchivePath) Then
                System.IO.Directory.CreateDirectory(botArchivePath)
            End If

            If System.IO.File.Exists(configurationPath) Then
                AreaState.defaultUserDataAccount = CHCCommonLibrary.AreaEngine.DataFileManagement.Json.IOFast(Of AreaCommon.Models.User.UserDataPersonalModel).read(configurationPath)
            Else
                newTenant = True

                Return True
            End If

            If System.IO.File.Exists(botListPath) Then
                AreaState.botList = CHCCommonLibrary.AreaEngine.DataFileManagement.Json.IOFast(Of AreaCommon.Models.Bot.BotListModel).read(botListPath)

                For Each botItem In AreaState.botList.ActiveBots
                    botPath = System.IO.Path.Combine(tenantRootPath, "Bot-" & botItem, "Settings.json")

                    newBot = New AreaCommon.Models.Bot.BotConfigurationsModel

                    newBot.parameters = CHCCommonLibrary.AreaEngine.DataFileManagement.Json.IOFast(Of AreaCommon.Models.Bot.BotParametersModel).read(botPath)

                    AreaState.bots.Add(botItem, newBot)

                    newBot.parameters.configuration.pairId = AreaState.Common.getPairID(newBot.parameters.configuration.pairKey)
                    newBot.data = CHCCommonLibrary.AreaEngine.DataFileManagement.Json.IOFast(Of AreaCommon.Models.Bot.BotDataModel).read(System.IO.Path.Combine(tenantRootPath, "Bot-" & botItem, "data.json"))

                    If newBot.parameters.header.isActive Then
                        AreaCommon.Engines.Bots.BotModule.start()
                    End If
                Next
            End If

            If System.IO.File.Exists(summaryPath) Then
                AreaState.summary = CHCCommonLibrary.AreaEngine.DataFileManagement.Json.IOFast(Of AreaCommon.Models.Account.SummaryModel).read(summaryPath)
            End If

            If System.IO.File.Exists(accountPath) Then
                AreaState.accounts = New Dictionary(Of String, AreaCommon.Models.Account.AccountModel)

                For Each account In CHCCommonLibrary.AreaEngine.DataFileManagement.Json.IOFast(Of AreaCommon.Models.Account.AccountsModel).read(accountPath).wallet
                    AreaState.accounts.Add(account.key, New AreaCommon.Models.Account.AccountModel With {.id = account.id, .amount = account.amount, .change = 0, .valueUSDT = 0})
                Next

                If AreaState.accounts.ContainsKey("USDT".ToLower()) Then
                    With AreaState.accounts("USDT".ToLower())
                        .change = 1
                        .valueUSDT = .amount
                    End With
                End If
            End If

            If System.IO.File.Exists(productsPath) Then
                For Each currency In CHCCommonLibrary.AreaEngine.DataFileManagement.Json.IOFast(Of AreaCommon.Models.Products.ProductsModel).read(productsPath).items
                    AreaState.products.addNew(currency.header.key, currency)
                Next

                loadOrderPlaced()
            End If

            If System.IO.File.Exists(automaticBotPath) Then
                AreaState.automaticBot = CHCCommonLibrary.AreaEngine.DataFileManagement.Json.IOFast(Of AreaCommon.Models.Bot.BotAutomatic).read(automaticBotPath)
            End If

            If System.IO.File.Exists(JournalPath) Then
                AreaState.journal = CHCCommonLibrary.AreaEngine.DataFileManagement.Json.IOFast(Of AreaCommon.Models.Journal.CumulativeModel).read(JournalPath)
            End If

            If System.IO.File.Exists(fundReservationPath) Then
                AreaState.gainFund = CHCCommonLibrary.AreaEngine.DataFileManagement.Json.IOFast(Of AreaCommon.Models.Journal.FundReservationModel).read(fundReservationPath)
            End If

            Return True
        End Function

    End Class

End Namespace
