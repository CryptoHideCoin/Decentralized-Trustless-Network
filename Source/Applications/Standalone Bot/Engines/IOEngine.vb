Option Compare Text
Option Explicit On



Namespace AreaCommon.Engines

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

        Public Property newTenant As Boolean = False


        ''' <summary>
        ''' This method provide to create order path
        ''' </summary>
        ''' <returns></returns>
        Private Function checkAndMakeOrderPath() As Boolean
            If Not IO.Directory.Exists(orderRootPath) Then
                IO.Directory.CreateDirectory(orderRootPath)
            End If

            orderClosePath = IO.Path.Combine(orderRootPath, "Closed")

            If Not IO.Directory.Exists(orderClosePath) Then
                IO.Directory.CreateDirectory(orderClosePath)
            End If

            orderPlacedPath = IO.Path.Combine(orderRootPath, "Placed")

            If Not IO.Directory.Exists(orderPlacedPath) Then
                IO.Directory.CreateDirectory(orderPlacedPath)
            End If

            orderToDeliveryPath = IO.Path.Combine(orderRootPath, "To Delivery")

            If Not IO.Directory.Exists(orderToDeliveryPath) Then
                IO.Directory.CreateDirectory(orderToDeliveryPath)
            End If

            Return True
        End Function

        ''' <summary>
        ''' This method provide to update a user personal data of the tenant
        ''' </summary>
        ''' <returns></returns>
        Public Function updatePersonaData() As Boolean
            Return CHCCommonLibrary.AreaEngine.DataFileManagement.Json.IOFast(Of Models.User.UserDataPersonalModel).save(configurationPath, AreaState.defaultUserDataAccount)
        End Function

        ''' <summary>
        ''' This method provide to update the botlist into the tenant
        ''' </summary>
        ''' <returns></returns>
        Public Function updateBotList() As Boolean
            Return CHCCommonLibrary.AreaEngine.DataFileManagement.Json.IOFast(Of Models.Bot.BotListModel).save(botListPath, AreaState.botList)
        End Function

        ''' <summary>
        ''' This method provide to save into file the summary
        ''' </summary>
        ''' <returns></returns>
        Public Function updateSummary() As Boolean
            Return CHCCommonLibrary.AreaEngine.DataFileManagement.Json.IOFast(Of Models.Account.SummaryModel).save(summaryPath, AreaState.summary)
        End Function

        ''' <summary>
        ''' This method provide to update the data into the wallet
        ''' </summary>
        ''' <returns></returns>
        Public Function updateWallet() As Boolean
            Dim accounts As New Models.Account.AccountsModel

            For Each account In AreaState.accounts
                accounts.wallet.Add(New Models.Account.AccountBaseForSerializationModel With {.key = account.Key, .id = account.Value.id, .amount = account.Value.amount})
            Next

            Return CHCCommonLibrary.AreaEngine.DataFileManagement.Json.IOFast(Of Models.Account.AccountsModel).save(accountPath, accounts)
        End Function

        ''' <summary>
        ''' This method provide to update the trade close
        ''' </summary>
        ''' <param name="botId"></param>
        ''' <param name="data"></param>
        ''' <returns></returns>
        Public Function updateTradeClose(ByVal botId As String, ByRef data As Models.Bot.TradeModel) As Boolean
            Dim pathComplete As String = IO.Path.Combine(tenantRootPath, "Bot-" & botId, "Trade Close", data.id & ".json")

            Return CHCCommonLibrary.AreaEngine.DataFileManagement.Json.IOFast(Of Models.Bot.TradeModel).save(pathComplete, data)
        End Function

        ''' <summary>
        ''' This method provide to save the data trade into the file
        ''' </summary>
        ''' <param name="botId"></param>
        ''' <param name="data"></param>
        ''' <returns></returns>
        Public Function updateBotData(ByVal botId As String, ByRef data As Models.Bot.BotDataModel) As Boolean
            Dim pathComplete As String = IO.Path.Combine(tenantRootPath, "Bot-" & botId, "data.json")

            Return CHCCommonLibrary.AreaEngine.DataFileManagement.Json.IOFast(Of Models.Bot.BotDataModel).save(pathComplete, data)
        End Function

        ''' <summary>
        ''' This method provide to get a trade close from a db
        ''' </summary>
        ''' <param name="tradeId"></param>
        ''' <returns></returns>
        Public Function getTradeClose(ByVal botId As String, ByVal tradeId As String) As Models.Bot.TradeModel
            Dim pathComplete As String = IO.Path.Combine(tenantRootPath, "Bot-" & botId, "Trade Close", tradeId & ".json")

            Return CHCCommonLibrary.AreaEngine.DataFileManagement.Json.IOFast(Of Models.Bot.TradeModel).read(pathComplete)
        End Function

        ''' <summary>
        ''' This method provide to update the bot settings
        ''' </summary>
        ''' <returns></returns>
        Public Function updateBotSetting(ByRef data As Models.Bot.BotConfigurationsModel) As Boolean
            Dim pathComplete As String = IO.Path.Combine(tenantRootPath, "Bot-" & data.parameters.header.id)
            Dim fileName As String = IO.Path.Combine(pathComplete, "Settings.json")

            AreaState.bots.Add(data.parameters.header.id, data)

            AreaState.botList.ActiveBots.Add(data.parameters.header.id)

            If Not IO.Directory.Exists(pathComplete) Then
                IO.Directory.CreateDirectory(pathComplete)
            End If

            pathComplete = IO.Path.Combine(pathComplete, "Trade Close")

            If Not IO.Directory.Exists(pathComplete) Then
                IO.Directory.CreateDirectory(pathComplete)
            End If

            If CHCCommonLibrary.AreaEngine.DataFileManagement.Json.IOFast(Of Models.Bot.BotParametersModel).save(fileName, data.parameters) Then
                Return updateBotList()
            End If

            Return False
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
                    AreaEngine.IO.updateBotData(item.Value.parameters.header.id, item.Value.data)

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
                IO.File.Delete(botListPath)
            Else
                updateBotList()
            End If

            Dim pathBot As String = IO.Path.Combine(AreaEngine.IO.tenantRootPath, "Bot-" & id)
            Dim pathArchived As String = IO.Path.Combine(AreaEngine.IO.tenantRootPath, "Archived", "Bot-" & id)

            IO.Directory.CreateDirectory(pathArchived)

            My.Computer.FileSystem.CopyDirectory(pathBot, pathArchived, True)

            IO.Directory.Delete(pathBot, True)

            Return True
        End Function

        ''' <summary>
        ''' This method provide to initialize the engine
        ''' </summary>
        ''' <param name="path"></param>
        ''' <returns></returns>
        Public Function init(ByVal path As String) As Boolean
            Dim botPath As String = ""
            Dim newBot As Models.Bot.BotConfigurationsModel

            path = path.Replace(Chr(34) & Chr(34), "").Trim()

            If Not IO.Directory.Exists(path) Then
                IO.Directory.CreateDirectory(path)
            End If

            tenantRootPath = path
            AreaState.defaultUserDataAccount.tenantName = IO.Path.GetFileName(path)
            orderRootPath = IO.Path.Combine(IO.Directory.GetParent(path).Parent.FullName, "Orders")
            configurationPath = IO.Path.Combine(path, "Configuration.json")
            botListPath = IO.Path.Combine(path, "Botlist.json")
            summaryPath = IO.Path.Combine(path, "Summary.json")
            accountPath = IO.Path.Combine(path, "Accounts.json")

            checkAndMakeOrderPath()

            botArchivePath = IO.Path.Combine(path, "Archived")

            If Not IO.Directory.Exists(botArchivePath) Then
                IO.Directory.CreateDirectory(botArchivePath)
            End If

            If IO.File.Exists(configurationPath) Then
                AreaState.defaultUserDataAccount = CHCCommonLibrary.AreaEngine.DataFileManagement.Json.IOFast(Of Models.User.UserDataPersonalModel).read(configurationPath)
            Else
                newTenant = True

                Return True
            End If

            If IO.File.Exists(botListPath) Then
                AreaState.botList = CHCCommonLibrary.AreaEngine.DataFileManagement.Json.IOFast(Of Models.Bot.BotListModel).read(botListPath)

                For Each botItem In AreaState.botList.ActiveBots
                    botPath = IO.Path.Combine(tenantRootPath, "Bot-" & botItem, "Settings.json")

                    newBot = New Models.Bot.BotConfigurationsModel

                    newBot.parameters = CHCCommonLibrary.AreaEngine.DataFileManagement.Json.IOFast(Of Models.Bot.BotParametersModel).read(botPath)

                    AreaState.bots.Add(botItem, newBot)

                    newBot.parameters.configuration.pairId = AreaState.Common.getPairID(newBot.parameters.configuration.pairKey)
                    newBot.data = CHCCommonLibrary.AreaEngine.DataFileManagement.Json.IOFast(Of Models.Bot.BotDataModel).read(IO.Path.Combine(tenantRootPath, "Bot-" & botItem, "data.json"))

                    If newBot.parameters.header.isActive Then
                        Bots.start()
                    End If
                Next
            End If

            If IO.File.Exists(summaryPath) Then
                AreaState.summary = CHCCommonLibrary.AreaEngine.DataFileManagement.Json.IOFast(Of Models.Account.SummaryModel).read(summaryPath)
            End If

            If IO.File.Exists(accountPath) Then
                AreaState.accounts = New Dictionary(Of String, Models.Account.AccountModel)

                For Each account In CHCCommonLibrary.AreaEngine.DataFileManagement.Json.IOFast(Of Models.Account.AccountsModel).read(accountPath).wallet
                    AreaState.accounts.Add(account.key, New Models.Account.AccountModel With {.id = account.id, .amount = account.amount, .change = 0, .valueUSDT = 0})
                Next

                With AreaState.accounts("USDT".ToLower())
                    .change = 1
                    .valueUSDT = .amount
                End With
            End If

            Return True
        End Function

    End Class

End Namespace