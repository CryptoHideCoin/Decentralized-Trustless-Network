Option Compare Text
Option Explicit On

Imports TradingBotSystemModelsLibrary.AreaModel.ExchangeCurrencies






Namespace AreaBusiness

    ''' <summary>
    ''' This engine contain all method relative of a exchange references
    ''' </summary>
    Public Class ExchangeCurrenciesEngine

        Public Class ExchangeCurrenciesCache

            Public Property exchangeId As Integer
            Public Property currenciesLink As New List(Of ExchangeCurrencySupportStructure)

        End Class

        Private Property _EngineDB As New CHCDataAccess.AreaCommon.Database.DatabaseGeneric
        Private Property _DBStateFileName As String = "EvaluationState.Db"
        Private Property _Initialize As Boolean = False
        Private Property _OwnerId As String = ""
        Private Property _CacheInMemory As New List(Of ExchangeCurrenciesCache)

        Public Property useCache As Boolean = False




        ''' <summary>
        ''' This method provide to create an exchange currencies table
        ''' </summary>
        ''' <returns></returns>
        Private Function createExchangeCurrenciesTable() As Boolean
            Try
                Dim sql As String = ""

                sql += "CREATE TABLE exchangeCurrencies "
                sql += " (exchangeId INTEGER, "
                sql += "  currencyId INTEGER, "
                sql += "  supportedType INTEGER, "
                sql += "  lastFound REAL, "
                sql += " PRIMARY KEY (exchangeId, currencyId));"

                Return _EngineDB.executeDataTable(sql, _OwnerId)
            Catch ex As Exception
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackException("ExchangeCurrenciesEngine.createExchangeCurrenciesTable", _OwnerId, ex.Message)

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to create an index short name
        ''' </summary>
        ''' <returns></returns>
        Private Function createFirstIndex() As Boolean
            Try
                Dim sql As String = ""

                sql += " CREATE INDEX firstExchangeIndex "
                sql += " ON exchangeCurrencies(exchangeId)"

                Return _EngineDB.executeDataTable(sql, _OwnerId)
            Catch ex As Exception
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackException("ExchangeCurrenciesEngine.createFirstIndex", _OwnerId, ex.Message)

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to create a DB structures
        ''' </summary>
        ''' <returns></returns>
        Private Function createStructures() As Boolean
            Try
                Dim proceed As Boolean = True

                If proceed Then
                    proceed = createExchangeCurrenciesTable()
                End If
                If proceed Then
                    proceed = createFirstIndex()
                End If

                Return proceed
            Catch ex As Exception
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackException("ExchangeCurrenciesEngine.createStructures", _OwnerId, ex.Message)

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to add a new exchange currencies into table
        ''' </summary>
        ''' <param name="exchangeId"></param>
        ''' <param name="currencyId"></param>
        ''' <param name="supportedType"></param>
        ''' <param name="forceOwner"></param>
        ''' <returns></returns>
        Private Function addNew(ByVal exchangeId As Integer, ByVal currencyId As Integer, ByVal supportedType As TypeSupportedEnumeration, ByVal lastFound As Double, ByVal forceOwner As String) As Boolean
            Try
                Dim sql As String

                sql = $"INSERT INTO exchangeCurrencies (exchangeId, currencyId, supportedType, lastFound) VALUES ({exchangeId}, {currencyId}, {Val(supportedType)}, '{lastFound.ToString().Replace(",", ".")}')"

                Return _EngineDB.executeDataTableAndReturnID(sql, forceOwner)
            Catch ex As Exception
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackException("ExchangeCurrenciesEngine.addNew", forceOwner, ex.Message)

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to update SQL
        ''' </summary>
        ''' <param name="exchangeId"></param>
        ''' <param name="currencyId"></param>
        ''' <param name="supportedType"></param>
        ''' <param name="forceOwner"></param>
        ''' <returns></returns>
        Private Function updateSQL(ByVal exchangeId As Integer, ByVal currencyId As Integer, ByVal supportedType As TypeSupportedEnumeration, ByVal forceOwner As String) As Boolean
            Try
                Dim sql As String

                sql = $"UPDATE exchangeCurrencies SET supportedType = {Val(supportedType)} WHERE exchangeId = {exchangeId} AND currencyId = {currencyId}"

                Return _EngineDB.executeDataTable(sql, forceOwner)
            Catch ex As Exception
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackException("ExchangeCurrenciesEngine.updateSQL", forceOwner, ex.Message)

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method Add or Get the Id of a name of the exchange reference
        ''' </summary>
        ''' <param name="data"></param>
        ''' <param name="forceOwner"></param>
        ''' <returns></returns>
        Public Function addIfMissing(ByVal data As ExchangeCurrencySupportStructure, Optional ByVal forceOwner As String = "") As Boolean
            If (forceOwner.Length = 0) Then
                forceOwner = _OwnerId
            End If

            Try
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackEnter("ExchangeCurrenciesEngine.addIfMissing", forceOwner)

                If _Initialize Then
                    Dim exchangeCurrenciesData As List(Of ExchangeCurrencySupportStructure)
                    Dim foundCurrency As Boolean = False

                    If useCache Then
                        For Each item In _CacheInMemory
                            If (item.exchangeId = data.exchangeId) Then
                                exchangeCurrenciesData = item.currenciesLink

                                Exit For
                            End If
                        Next

#Disable Warning BC42104
                        If Not IsNothing(exchangeCurrenciesData) Then
#Enable Warning BC42104
                            For Each item In exchangeCurrenciesData
                                If (item.currencyId = data.currencyId) Then
                                    foundCurrency = True
                                End If
                            Next

                            If Not foundCurrency Then
                                exchangeCurrenciesData.Add(New ExchangeCurrencySupportStructure() With {.exchangeId = data.exchangeId, .currencyId = data.currencyId, .supportedType = data.supportedType, .lastFound = data.lastFound})
                            Else
                                Return True
                            End If
                        Else
                            Dim newCurrency As New ExchangeCurrencySupportStructure
                            Dim newItem As New ExchangeCurrenciesCache

                            newCurrency.exchangeId = data.exchangeId
                            newCurrency.currencyId = data.currencyId
                            newCurrency.supportedType = data.supportedType
                            newCurrency.lastFound = data.lastFound

                            newItem.exchangeId = data.exchangeId
                            newItem.currenciesLink.Add(newCurrency)

                            _CacheInMemory.Add(newItem)
                        End If
                    Else
                        Dim sql As String
                        Dim result As Object
                        Dim openDB As Object

                        sql = $"SELECT exchangeId FROM exchangeCurrencies WHERE exchangeId = {data.exchangeId} AND currencyId = {data.currencyId}"

                        openDB = _EngineDB.openDatabase(forceOwner)

                        If Not IsNothing(openDB) Then
                            Dim found As Boolean = False

                            result = _EngineDB.selectDataReader(openDB, sql, forceOwner)

                            If Not IsNothing(result) Then
                                While result.read()
                                    found = (result.GetInt32(0) = data.exchangeId)
                                End While
                            End If

                            openDB.close()

                            If found Then
                                Return True
                            End If
                        End If
                    End If

                    data.lastFound = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()

                    Return addNew(data.exchangeId, data.currencyId, data.supportedType, data.lastFound, forceOwner)
                Else
                    Return False
                End If
            Catch ex As Exception
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackException("ExchangeCurrenciesEngine.addIfMissing", forceOwner, ex.Message)

                Return False
            Finally
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackExit("ExchangeCurrenciesEngine.addIfMissing", forceOwner)
            End Try
        End Function

        ''' <summary>
        ''' This method provide to modify into db and into cache data and into db
        ''' </summary>
        ''' <param name="id"></param>
        ''' <param name="newName"></param>
        ''' <returns></returns>
        Public Function updateExchangeCurrency(ByVal exchangeId As Integer, ByVal currencyId As Integer, ByVal supportedType As TypeSupportedEnumeration, Optional ByVal forceOwner As String = "") As Boolean
            If (forceOwner.Length = 0) Then
                forceOwner = _OwnerId
            End If

            Try
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackEnter("ExchangeCurrenciesEngine.updateExchangeCurrency", _OwnerId)

                If _Initialize Then
                    Dim exchangeCurrenciesData As List(Of ExchangeCurrencySupportStructure)
                    Dim foundReference As Boolean = False

                    If useCache Then
                        For Each item In _CacheInMemory
                            If (item.exchangeId = exchangeId) Then
                                exchangeCurrenciesData = item.currenciesLink

                                Exit For
                            End If
                        Next

#Disable Warning BC42104
                        If Not IsNothing(exchangeCurrenciesData) Then
#Enable Warning BC42104
                            For Each item In exchangeCurrenciesData
                                If (item.currencyId = currencyId) Then
                                    item.supportedType = supportedType

                                    foundReference = True
                                End If
                            Next

                            If Not foundReference Then
                                Return False
                            End If
                        Else
                            Return False
                        End If
                    End If

                    Return updateSQL(exchangeId, currencyId, supportedType, forceOwner)
                End If

                Return False
            Catch ex As Exception
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackException("ExchangeCurrenciesEngine.updateExchangeReference", forceOwner, ex.Message)

                Return False
            Finally
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackExit("ExchangeCurrenciesEngine.updateExchangeReference", forceOwner)
            End Try
        End Function

        ''' <summary>
        ''' This method provide to get an exchange currency from an Id 
        ''' </summary>
        ''' <param name="id"></param>
        ''' <returns></returns>
        Public Function [select](ByVal exchangeId As Integer, ByVal currencyId As Integer, Optional ByVal forceOwner As String = "") As ExchangeCurrencySupportStructure
            Dim response As New ExchangeCurrencySupportStructure With {.exchangeId = exchangeId, .currencyId = currencyId}

            If (forceOwner.Length = 0) Then
                forceOwner = _OwnerId
            End If
            Try
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackEnter("ExchangeCurrenciesEngine.[select]", forceOwner)

                If _Initialize Then
                    If useCache Then
                        Dim exchangeCurrenciesData As List(Of ExchangeCurrencySupportStructure)

                        For Each item In _CacheInMemory
                            If (item.exchangeId = exchangeId) Then
                                exchangeCurrenciesData = item.currenciesLink

                                Exit For
                            End If
                        Next

#Disable Warning BC42104
                        If Not IsNothing(exchangeCurrenciesData) Then
#Enable Warning BC42104
                            For Each item In exchangeCurrenciesData
                                If (item.currencyId = currencyId) Then
                                    response.supportedType = item.supportedType
                                    response.lastFound = item.lastFound

                                    Return response
                                End If
                            Next
                        End If
                    Else
                        Dim sql As String
                        Dim result As Object
                        Dim openDB As Object

                        sql = $"SELECT supportedType, lastFound FROM exchangeCurrencies WHERE exchangeId = {exchangeId} AND currencyId = {currencyId}"

                        openDB = _EngineDB.openDatabase(forceOwner)

                        If Not IsNothing(openDB) Then
                            result = _EngineDB.selectDataReader(openDB, sql, forceOwner)

                            If Not IsNothing(result) Then
                                Dim item As ExchangeCurrencySupportStructure

                                While result.read()
                                    item = New ExchangeCurrencySupportStructure

                                    item.exchangeId = exchangeId
                                    item.currencyId = currencyId
                                    item.supportedType = result.GetInt32(0)
                                    item.lastFound = result.getDouble(1)
                                End While

#Disable Warning BC42104
                                If Not IsNothing(item) Then
#Enable Warning BC42104
                                    openDB.close()

                                    Return item
                                End If
                            End If

                            openDB.close()
                        End If
                    End If
                End If

                Return New ExchangeCurrencySupportStructure
            Catch ex As Exception
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackException("ExchangeCurrenciesEngine.[select]", forceOwner, ex.Message)

                Return New ExchangeCurrencySupportStructure
            Finally
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackExit("ExchangeCurrenciesEngine.[select]", forceOwner)
            End Try
        End Function

        ''' <summary>
        ''' This method provide to return a count of a exchange currency table
        ''' </summary>
        ''' <returns></returns>
        Public Function count(ByVal exchangeId As Integer, Optional ByVal forceOwner As String = "") As Integer
            If (forceOwner.Length = 0) Then
                forceOwner = _OwnerId
            End If
            Try
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackEnter("ExchangeCurrenciesEngine.count", forceOwner)

                If _Initialize Then
                    If useCache Then
                        For Each item In _CacheInMemory
                            If (item.exchangeId = exchangeId) Then
                                Return item.currenciesLink.Count
                            End If
                        Next
                    Else
                        Dim sql As String
                        Dim result As Object

                        sql = $"SELECT Count(id) as numExchange FROM exchangeCurrencies WHERE exchangeId = {exchangeId}"

                        result = _EngineDB.selectResultDataTable(sql, forceOwner)

                        If Not IsNothing(result) Then
                            Return result
                        End If
                    End If
                End If

                Return 0
            Catch ex As Exception
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackException("ExchangeCurrenciesEngine.count", forceOwner, ex.Message)

                Return 0
            Finally
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackExit("ExchangeCurrenciesEngine.count", forceOwner)
            End Try
        End Function

        ''' <summary>
        ''' This method provide to get all currency of exchange
        ''' </summary>
        ''' <returns></returns>
        Public Function listAll(Optional ByVal loadEntireCache As Boolean = False, Optional ByVal forceOwner As String = "") As List(Of ExchangeCurrenciesCache)
            If (forceOwner.Length = 0) Then
                forceOwner = _OwnerId
            End If

            Try
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackEnter("ExchangeCurrenciesEngine.listAll", forceOwner)

                If _Initialize Then
                    If useCache And Not loadEntireCache Then
                        Return _CacheInMemory
                    Else
                        Dim response As New List(Of ExchangeCurrenciesCache)
                        Dim currentDataExchange As New ExchangeCurrenciesCache
                        Dim sql As String
                        Dim result As Object
                        Dim openDB As Object

                        sql = $"SELECT exchangeId, currencyId, supportedType, lastFound FROM exchangeCurrencies ORDER BY exchangeId"

                        openDB = _EngineDB.openDatabase(forceOwner)

                        If Not IsNothing(openDB) Then
                            result = _EngineDB.selectDataReader(openDB, sql, forceOwner)

                            If Not IsNothing(result) Then
                                Dim item As ExchangeCurrencySupportStructure

                                While result.read()
                                    item = New ExchangeCurrencySupportStructure

                                    item.exchangeId = result.GetInt32(0)
                                    item.currencyId = result.GetInt32(1)

                                    Select Case result.GetInt32(2)
                                        Case 0 : item.supportedType = TypeSupportedEnumeration.undefined
                                        Case 1 : item.supportedType = TypeSupportedEnumeration.notSupported
                                        Case 2 : item.supportedType = TypeSupportedEnumeration.supportedDirectly
                                        Case 3 : item.supportedType = TypeSupportedEnumeration.supportedDecentralized
                                    End Select

                                    item.lastFound = result.getDouble(3)

                                    If (currentDataExchange.exchangeId <> item.exchangeId) Then
                                        If loadEntireCache And (currentDataExchange.exchangeId <> 0) And useCache Then
                                            _CacheInMemory.Add(currentDataExchange)
                                        End If
                                        If (currentDataExchange.exchangeId <> 0) Then
                                            response.Add(currentDataExchange)
                                        End If

                                        currentDataExchange = New ExchangeCurrenciesCache
                                    End If

                                    currentDataExchange.exchangeId = item.exchangeId
                                    currentDataExchange.currenciesLink.Add(item)
                                End While

                                If loadEntireCache And (currentDataExchange.exchangeId <> 0) And useCache Then
                                    _CacheInMemory.Add(currentDataExchange)
                                End If
                                If (currentDataExchange.exchangeId <> 0) Then
                                    response.Add(currentDataExchange)
                                End If
                            End If

                            openDB.close()

                            Return response
                        End If
                    End If
                End If

                Return New List(Of ExchangeCurrenciesCache)
            Catch ex As Exception
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackException("ExchangeCurrenciesEngine.listAll", forceOwner, ex.Message)

                Return New List(Of ExchangeCurrenciesCache)
            Finally
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackExit("ExchangeCurrenciesEngine.listAll", forceOwner)
            End Try
        End Function

        ''' <summary>
        ''' This method provide to get a list of a currency of an exchange
        ''' </summary>
        ''' <returns></returns>
        Public Function list(ByVal exchangeId As Integer, Optional ByVal forceOwner As String = "") As List(Of ExchangeCurrencySupportStructure)
            If (forceOwner.Length = 0) Then
                forceOwner = _OwnerId
            End If

            Try
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackEnter("ExchangeCurrenciesEngine.list", forceOwner)

                If _Initialize Then
                    If useCache Then
                        For Each item In _CacheInMemory
                            If (item.exchangeId = exchangeId) Then
                                Return item.currenciesLink
                            End If
                        Next

                        Return New List(Of ExchangeCurrencySupportStructure)
                    Else
                        Dim response As New List(Of ExchangeCurrencySupportStructure)
                        Dim sql As String
                        Dim result As Object
                        Dim openDB As Object

                        sql = $"SELECT currencyId, supportedType, lastFound FROM exchangeCurrencies WHERE exchangeId = {exchangeId}"

                        openDB = _EngineDB.openDatabase(forceOwner)

                        If Not IsNothing(openDB) Then
                            result = _EngineDB.selectDataReader(openDB, sql, forceOwner)

                            If Not IsNothing(result) Then
                                Dim item As ExchangeCurrencySupportStructure

                                While result.read()
                                    item = New ExchangeCurrencySupportStructure

                                    item.currencyId = result.GetInt32(0)
                                    item.supportedType = result.GetInt32(1)
                                    item.lastFound = result.getDouble(2)

                                    response.Add(item)
                                End While
                            End If

                            openDB.close()

                            Return response
                        End If
                    End If
                End If

                Return New List(Of ExchangeCurrencySupportStructure)
            Catch ex As Exception
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackException("ExchangeCurrenciesEngine.list", forceOwner, ex.Message)

                Return New List(Of ExchangeCurrencySupportStructure)
            Finally
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackExit("ExchangeCurrenciesEngine.list", forceOwner)
            End Try
        End Function

        ''' <summary>
        ''' This method provide to delete an unique id item's
        ''' </summary>
        ''' <param name="exchangeId"></param>
        ''' <param name="forceOwner"></param>
        ''' <returns></returns>
        Public Function delete(ByVal exchangeId As Integer, Optional ByVal forceOwner As String = "") As Boolean
            If (forceOwner.Length = 0) Then
                forceOwner = _OwnerId
            End If

            Try
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackEnter("ExchangeCurrenciesEngine.deleteExchange", forceOwner)

                If useCache Then
                    Dim toDelete As ExchangeCurrenciesCache

                    For Each item In _CacheInMemory
                        If (item.exchangeId = exchangeId) Then
                            toDelete = item

                            Exit For
                        End If
                    Next

#Disable Warning BC42104
                    If Not IsNothing(toDelete) Then
#Enable Warning BC42104
                        _CacheInMemory.Remove(toDelete)
                    End If
                End If

                Return _EngineDB.executeDataTable($"DELETE exchanges WHERE exchangeId = {exchangeId}", forceOwner)
            Catch ex As Exception
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackException("ExchangeCurrenciesEngine.deleteExchange", forceOwner, ex.Message)

                Return False
            Finally
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackExit("ExchangeCurrenciesEngine.deleteExchange", forceOwner)
            End Try
        End Function

        ''' <summary>
        ''' This method provide to delete a singleReference
        ''' </summary>
        ''' <param name="exchangeId"></param>
        ''' <param name="urlType"></param>
        ''' <param name="forceOwner"></param>
        ''' <returns></returns>
        Public Function delete(ByVal exchangeId As Integer, ByVal currencyId As Integer, Optional ByVal forceOwner As String = "") As Boolean
            If (forceOwner.Length = 0) Then
                forceOwner = _OwnerId
            End If

            Try
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackEnter("ExchangeCurrenciesEngine.delete", forceOwner)

                If useCache Then
                    Dim exchangeData As ExchangeCurrenciesCache
                    Dim toDelete As ExchangeCurrencySupportStructure

                    For Each item In _CacheInMemory
                        If (item.exchangeId = exchangeId) Then
                            exchangeData = item

                            Exit For
                        End If
                    Next

#Disable Warning BC42104
                    If Not IsNothing(exchangeData) Then
#Enable Warning BC42104
                        For Each item In exchangeData.currenciesLink
                            If (item.currencyId = currencyId) Then
                                toDelete = item

                                Exit For
                            End If
                        Next

#Disable Warning BC42104
                        If Not IsNothing(toDelete) Then
#Enable Warning BC42104
                            exchangeData.currenciesLink.Remove(toDelete)

                            If (exchangeData.currenciesLink.Count = 0) Then
                                _CacheInMemory.Remove(exchangeData)
                            End If
                        End If
                    End If
                End If

                Return _EngineDB.executeDataTable($"DELETE FROM exchangeReferences WHERE exchangeId = {exchangeId} AND currencyId = {currencyId}", forceOwner)
            Catch ex As Exception
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackException("ExchangeCurrenciesEngine.delete", forceOwner, ex.Message)

                Return False
            Finally
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackExit("ExchangeCurrenciesEngine.delete", forceOwner)
            End Try
        End Function

        ''' <summary>
        ''' This method provide to return the currency reference in the exchange id
        ''' </summary>
        ''' <param name="exchangeId"></param>
        ''' <returns></returns>
        Public Function exchangeCurrencyExist(ByVal exchangeId As Integer, ByVal currencyId As Integer) As Boolean
            Try
                If _Initialize Then
                    CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackEnter("ExchangeCurrenciesEngine.exchangeCurrencyExist", _OwnerId)

                    Return ([select](exchangeId, currencyId).exchangeId <> 0)
                End If
            Catch ex As Exception
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackException("ExchangeCurrenciesEngine.exchangeCurrencyExist", _OwnerId, ex.Message)
            Finally
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackExit("ExchangeCurrenciesEngine.exchangeCurrencyExist", _OwnerId)
            End Try

            Return False
        End Function

        ''' <summary>
        ''' This method provide to initialize the engine
        ''' </summary>
        ''' <param name="path"></param>
        ''' <returns></returns>
        Public Function init() As Boolean
            Try
                _EngineDB.path = CHCSidechainServiceLibrary.AreaCommon.Main.environment.paths.workData.state.path
                _EngineDB.fileName = _DBStateFileName
                _EngineDB.logInstance = CHCSidechainServiceLibrary.AreaCommon.Main.environment.log

                If Not IO.Directory.Exists(_EngineDB.path) Then
                    IO.Directory.CreateDirectory(_EngineDB.path)
                End If

                If _EngineDB.init("Evaluation", "Custom") Then
                    _OwnerId = "ExchangeCurrenciesEngine"

                    CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackEnter("ExchangeCurrenciesEngine.init", _OwnerId)

                    _Initialize = True

                    If Not _EngineDB.existTable("exchangeCurrencies", _OwnerId) Then
                        CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.track("ExchangeCurrenciesEngine.init", _OwnerId, "Exchange Currencies table not exist")

                        If Not createStructures() Then
                            CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.track("ExchangeCurrenciesEngine.init", _OwnerId, "Problem during create db structures")

                            Return False
                        End If
                    ElseIf useCache Then
                        listAll(True)
                    End If

                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackException("ExchangeCurrenciesEngine.init", _OwnerId, ex.Message)

                Return False
            Finally
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackExit("ExchangeCurrenciesEngine.init", _OwnerId)
            End Try
        End Function

    End Class

End Namespace
