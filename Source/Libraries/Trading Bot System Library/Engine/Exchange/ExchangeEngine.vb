Option Compare Text
Option Explicit On

Imports TradingBotSystemModelsLibrary.AreaModel.Exchange






Namespace AreaBusiness

    ''' <summary>
    ''' This engine contain all method relative of a exchange
    ''' </summary>
    Public Class ExchangeEngine

        Private Property _EngineDB As New CHCDataAccess.AreaCommon.Database.DatabaseGeneric
        Private Property _DBStateFileName As String = "EvaluationState.Db"
        Private Property _Initialize As Boolean = False
        Private Property _OwnerId As String = ""
        Private Property _CacheExchangeById As New Dictionary(Of Integer, ExchangeStructure)
        Private Property _CacheExchangeByName As New Dictionary(Of String, ExchangeStructure)

        Public Property useCache As Boolean = False

        Public Event SetExchangeActive(ByVal exchangeId As Integer, ByVal lastCurrenciesUpdate As Double, ByVal lastProductsUpdate As Double)
        Public Event UpdateExchangeCurrency(ByVal exchangeId As Integer, ByRef value As Boolean)
        Public Event UpdateExchangeProducts(ByVal exchangeId As Integer, ByRef value As Boolean)



        ''' <summary>
        ''' This method provide to create an exchange table
        ''' </summary>
        ''' <returns></returns>
        Private Function createExchangeTable() As Boolean
            Try
                Dim sql As String = ""

                sql += "CREATE TABLE exchanges "
                sql += " ([id] INTEGER PRIMARY KEY AUTOINCREMENT, "
                sql += "  [name] NVARCHAR(512), "
                sql += "  isActive INTEGER, "
                sql += "  lastCurrenciesCheck REAL, "
                sql += "  lastProductsCheck REAL, "
                sql += "  isCentralized INTEGER, "
                sql += "  groupId INTEGER, "
                sql += "  isUsed INTEGER);"

                Return _EngineDB.executeDataTable(sql, _OwnerId)
            Catch ex As Exception
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackException("ExchangeEngine.createExchangeTable", _OwnerId, ex.Message)

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
                    proceed = createExchangeTable()
                End If

                Return proceed
            Catch ex As Exception
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackException("ExchangeEngine.createStructures", _OwnerId, ex.Message)

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to add a new exchange into table
        ''' </summary>
        ''' <param name="[name]"></param>
        ''' <returns></returns>
        Private Function addNewAndReturnID(ByRef data As NewExchangeStructure, ByVal forceOwner As String) As Integer
            Try
                Dim sql As String = ""
                Dim isActiveValue As Integer = 0
                Dim isCentralized As Integer = 0
                Dim groupId As Integer = 0
                Dim newId As Integer = 0
                Dim copyIntoGroup As Boolean = False

                If data.isActive Then isActiveValue = 1
                If data.isCentralized Then isCentralized = 1

                If (data.group.Trim().Length > 0) Then
                    If (data.group.CompareTo(data.name) = 0) Then
                        copyIntoGroup = True
                    Else
                        groupId = [select](data.group).id

                        If (groupId = 0) Then
                            data.group = ""
                        End If
                    End If
                End If

                sql += $"INSERT INTO exchanges ([name], isActive, lastCurrenciesCheck, lastProductsCheck, isCentralized, groupId, isUsed) "
                sql += $" VALUES "
                sql += $"('{StrConv(data.name, VbStrConv.ProperCase)}', {isActiveValue}, 0, 0, {isCentralized}, {groupId}, 0)"

                newId = _EngineDB.executeDataTableAndReturnID(sql, forceOwner)

                If (newId <> 0) And copyIntoGroup Then
                    sql = $"UPDATE exchanges SET groupId = {newId} WHERE id = {newId}"

                    If _EngineDB.executeDataTable(sql, forceOwner) Then
                        Return newId
                    End If
                Else
                    Return newId
                End If

                Return 0
            Catch ex As Exception
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackException("ExchangeEngine.addNew", forceOwner, ex.Message)

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method Add or Get the Id of a name of the exchange
        ''' </summary>
        ''' <param name="apiName"></param>
        ''' <returns></returns>
        Public Function addNewExchange(ByRef data As NewExchangeStructure, Optional ByVal forceOwner As String = "") As Boolean
            Dim dataExt As New ExchangeStructure With {.name = StrConv(data.[name], VbStrConv.ProperCase), .group = data.group, .isActive = data.isActive, .isCentralized = data.isCentralized}

            If (forceOwner.Length = 0) Then
                forceOwner = _OwnerId
            End If

            Try
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackEnter("ExchangeEngine.addNewExchange", forceOwner)

                If _Initialize Then
                    If useCache Then
                        If Not _CacheExchangeByName.ContainsKey(data.[name]) Then
                            dataExt.id = addNewAndReturnID(data, forceOwner)

                            If (dataExt.id <> 0) And (dataExt.isActive) Then
                                RaiseEvent SetExchangeActive(dataExt.id, -1, -1)
                            End If

                            _CacheExchangeByName.Add(data.name, dataExt)
                            _CacheExchangeById.Add(dataExt.id, dataExt)
                        End If
                    Else
                        If [select](data.name).id = 0 Then
                            dataExt.id = addNewAndReturnID(data, forceOwner)

                            If (dataExt.id <> 0) And dataExt.isActive Then
                                RaiseEvent SetExchangeActive(dataExt.id, -1, -1)
                            End If
                        End If
                    End If
                End If

                Return (dataExt.id <> 0)
            Catch ex As Exception
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackException("ExchangeEngine.addNewExchange", forceOwner, ex.Message)

                Return False
            Finally
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackExit("ExchangeEngine.addNewExchange", forceOwner)
            End Try
        End Function

        ''' <summary>
        ''' This method provide to modify into db and into cache data the name of an exchange
        ''' </summary>
        ''' <param name="id"></param>
        ''' <param name="newName"></param>
        ''' <returns></returns>
        Public Function updateExchangeName(ByRef data As UpdateExchangeStructure, Optional ByVal forceOwner As String = "") As Boolean
            Try
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackEnter("ExchangeEngine.updateExchangeName", _OwnerId)

                If (forceOwner.Length = 0) Then
                    forceOwner = _OwnerId
                End If

                If _Initialize Then
                    Dim sql As String = ""
                    Dim groupId As Integer = 0

                    If useCache Then
                        Dim originalItem As ExchangeStructure

                        If _CacheExchangeById.ContainsKey(data.id) Then
                            originalItem = _CacheExchangeById(data.id)

                            If (data.name.Length > 0) Then
                                If (data.name.CompareTo(originalItem.name) <> 0) Then
                                    If Not _CacheExchangeByName.ContainsKey(data.name) Then
                                        _CacheExchangeByName.Remove(originalItem.name)

                                        originalItem.name = data.name

                                        _CacheExchangeByName.Add(data.name, originalItem)
                                    End If
                                End If
                            End If

                            originalItem.group = data.group
                            originalItem.isActive = data.isActive
                            originalItem.isCentralized = data.isCentralized
                        Else
                            Return False
                        End If
                    End If

                    sql += $"UPDATE exchanges "
                    sql += $"   SET [name] = '{data.name}',"

                    If data.isActive Then
                        sql += $"       isActive = 1,"
                    Else
                        sql += $"       isActive = 0,"
                    End If

                    If data.isCentralized Then
                        sql += $"       isCentralized = 1,"
                    Else
                        sql += $"       isCentralized = 0,"
                    End If

                    groupId = [select](data.group).id

                    If (groupId = 0) Then
                        sql += $"       groupId = ''"
                    Else
                        sql += $"       groupId = {groupId}"
                    End If

                    sql += $" WHERE id = {data.id}"

                    If _EngineDB.executeDataTable(sql, forceOwner) And data.isActive Then
                        RaiseEvent SetExchangeActive(data.id, -1, -1)

                        Return True
                    End If
                End If

                Return False
            Catch ex As Exception
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackException("ExchangeEngine.updateExchangeName", forceOwner, ex.Message)

                Return False
            Finally
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackExit("ExchangeEngine.updateExchangeName", forceOwner)
            End Try
        End Function

        ''' <summary>
        ''' This method provide to update to isUsed into db into cache data and into table of db
        ''' </summary>
        ''' <param name="id"></param>
        ''' <param name="newName"></param>
        ''' <returns></returns>
        Public Function updateExchangeInUsed(ByVal id As Integer, Optional ByVal forceOwner As String = "") As Boolean
            Try
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackEnter("ExchangeEngine.updateExchangeInUsed", _OwnerId)

                If (forceOwner.Length = 0) Then
                    forceOwner = _OwnerId
                End If

                If _Initialize Then
                    Dim sql As String

                    If useCache Then
                        If _CacheExchangeById.ContainsKey(id) Then
                            _CacheExchangeById(id).isUsed = True
                        Else
                            Return False
                        End If
                    End If

                    sql = $"UPDATE exchanges SET isUsed = 1 WHERE [id] = '{id}'"

                    Return _EngineDB.executeDataTable(sql, forceOwner)
                End If

                Return False
            Catch ex As Exception
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackException("ExchangeEngine.updateExchangeInUsed", forceOwner, ex.Message)

                Return False
            Finally
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackExit("ExchangeEngine.updateExchangeInUsed", forceOwner)
            End Try
        End Function

        ''' <summary>
        ''' This method provide to update active into db into cache data and into table of db
        ''' </summary>
        ''' <param name="id"></param>
        ''' <param name="newName"></param>
        ''' <returns></returns>
        Public Function updateExchangeActive(ByVal id As Integer, ByVal value As Boolean, Optional ByVal forceOwner As String = "") As Boolean
            Try
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackEnter("ExchangeEngine.updateExchangeActive", _OwnerId)

                If (forceOwner.Length = 0) Then
                    forceOwner = _OwnerId
                End If

                If _Initialize Then
                    Dim sql As String
                    Dim data As ExchangeStructure

                    If useCache Then
                        If _CacheExchangeById.ContainsKey(id) Then
                            _CacheExchangeById(id).isActive = True

                            data = _CacheExchangeById(id)
                        Else
                            Return False
                        End If
                    Else
                        data = [select](id)
                    End If

                    sql = $"UPDATE exchanges SET isActive = 1, hash = '{data.getHash()}' WHERE [id] = '{id}'"

                    Return _EngineDB.executeDataTable(sql, forceOwner)
                End If

                Return False
            Catch ex As Exception
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackException("ExchangeEngine.updateExchangeActive", forceOwner, ex.Message)

                Return False
            Finally
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackExit("ExchangeEngine.updateExchangeActive", forceOwner)
            End Try
        End Function

        ''' <summary>
        ''' This method provide to update last (Currencies, Products) into db into cache data and into table of db
        ''' </summary>
        ''' <param name="id"></param>
        ''' <param name="newName"></param>
        ''' <returns></returns>
        Public Function updateExchangeLast(ByVal id As Integer, ByVal updateCurrency As Boolean, Optional ByVal forceOwner As String = "") As Boolean
            Try
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackEnter("ExchangeEngine.updateExchangeLast", _OwnerId)

                If (forceOwner.Length = 0) Then
                    forceOwner = _OwnerId
                End If

                If _Initialize Then
                    Dim sql As String
                    Dim lastUpdate As Double = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()
                    Dim columnName As String = "lastCurrenciesCheck"

                    If useCache Then
                        If _CacheExchangeById.ContainsKey(id) Then
                            _CacheExchangeById(id).isActive = True

                            If updateCurrency Then
                                _CacheExchangeById(id).lastCurrenciesCheck = lastUpdate
                            Else
                                _CacheExchangeById(id).lastProductsCheck = lastUpdate

                                columnName = "lastProductsCheck"
                            End If

                        Else
                            Return False
                        End If
                    End If

                    sql = $"UPDATE exchanges SET {columnName} = '{lastUpdate.ToString().Replace(",", ".")}' WHERE [id] = '{id}'"

                    Return _EngineDB.executeDataTable(sql, forceOwner)
                End If

                Return False
            Catch ex As Exception
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackException("ExchangeEngine.updateExchangeLast", forceOwner, ex.Message)

                Return False
            Finally
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackExit("ExchangeEngine.updateExchangeLast", forceOwner)
            End Try
        End Function

        ''' <summary>
        ''' This method provide to get an name of an Exchange from an Id
        ''' </summary>
        ''' <param name="id"></param>
        ''' <returns></returns>
        Public Function [select](ByVal id As Integer, Optional ByVal forceOwner As String = "") As ExchangeStructure
            Dim response As New ExchangeStructure With {.id = id}
            Try
                If (forceOwner.Length = 0) Then
                    forceOwner = _OwnerId
                End If

                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackEnter("ExchangeEngine.[select]", forceOwner)

                If _Initialize Then
                    If useCache Then
                        If _CacheExchangeById.ContainsKey(id) Then
                            Return _CacheExchangeById(id)
                        Else
                            Return New ExchangeStructure
                        End If
                    Else
                        Dim sql As String = ""
                        Dim result As Object
                        Dim openDB As Object

                        sql += $"SELECT A.id, A.name, A.isActive, A.lastCurrenciesCheck, A.lastProductsCheck, A.isCentralized, B.name as [group], A.isUsed "
                        sql += $"FROM exchanges A LEFT Join exchanges B ON A.id = B.groupId "
                        sql += $"WHERE A.id = '{id}'"

                        openDB = _EngineDB.openDatabase(forceOwner)

                        If Not IsNothing(openDB) Then
                            result = _EngineDB.selectDataReader(openDB, sql, forceOwner)

                            While result.read()
                                While result.read()
                                    response.id = result.GetInt32(0)
                                    response.name = result.GetString(1)
                                    response.isActive = (result.GetInt32(2) <> 0)
                                    response.lastCurrenciesCheck = result.getDouble(3)
                                    response.lastProductsCheck = result.getDouble(4)
                                    response.isCentralized = (result.getInt32(5) <> 0)
                                    response.group = result.getString(6)
                                    response.isUsed = (result.GetInt32(7) <> 0)
                                End While
                            End While

                            openDB.close()
                        Else
                            response.id = id
                        End If
                    End If
                End If

                Return response
            Catch ex As Exception
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackException("ExchangeEngine.[select]", forceOwner, ex.Message)

                Return response
            Finally
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackExit("ExchangeEngine.[select]", forceOwner)
            End Try
        End Function

        ''' <summary>
        ''' This method provide to get an Id of an Exchange
        ''' </summary>
        ''' <param name="id"></param>
        ''' <returns></returns>
        Public Function [select](ByVal [name] As String, Optional ByVal forceOwner As String = "") As ExchangeStructure
            Dim response As New ExchangeStructure With {.name = name}
            Try
                If (forceOwner.Length = 0) Then
                    forceOwner = _OwnerId
                End If

                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackEnter("ExchangeEngine.[select]", forceOwner)

                If _Initialize Then
                    If useCache Then
                        If _CacheExchangeByName.ContainsKey([name]) Then
                            Return _CacheExchangeByName([name])
                        Else
                            Return New ExchangeStructure
                        End If
                    Else
                        Dim sql As String = ""
                        Dim result As Object
                        Dim openDB As Object

                        sql += $"SELECT A.id, A.isActive, A.lastCurrenciesCheck, A.lastProductsCheck, A.isCentralized, B.name as [group], A.isUsed "
                        sql += $"FROM exchanges A LEFT Join exchanges B ON A.id = B.groupId "
                        sql += $"WHERE A.name = '{[name]}'"

                        openDB = _EngineDB.openDatabase(forceOwner)

                        If Not IsNothing(openDB) Then
                            result = _EngineDB.selectDataReader(openDB, sql, forceOwner)

                            While result.read()
                                While result.read()
                                    response.id = result.GetInt32(0)
                                    response.name = name
                                    response.isActive = (result.GetInt32(1) <> 0)
                                    response.lastCurrenciesCheck = result.getDouble(2)
                                    response.lastProductsCheck = result.getDouble(3)
                                    response.isCentralized = (result.getInt32(4) <> 0)
                                    response.group = result.getString(5)
                                    response.isUsed = (result.GetInt32(6) <> 0)
                                End While
                            End While

                            openDB.close()
                        Else
                            response.name = name
                        End If
                    End If
                End If

                Return response
            Catch ex As Exception
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackException("ExchangeEngine.[select]", forceOwner, ex.Message)

                Return response
            Finally
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackExit("ExchangeEngine.[select]", forceOwner)
            End Try
        End Function

        ''' <summary>
        ''' This method provide to return the schedule job of exchange
        ''' </summary>
        ''' <param name="id"></param>
        ''' <param name="ownerId"></param>
        ''' <returns></returns>
        Public Function selectScheduleJob(ByVal id As Integer, ByVal forceOwner As String) As ExchangeScheduleJobModels
            Dim result As New ExchangeScheduleJobModels With {.exchangeId = id}

            Try
                If (forceOwner.Length = 0) Then
                    forceOwner = _OwnerId
                End If

                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackEnter("ExchangeEngine.selectScheduleJob", forceOwner)

                If _Initialize Then
                    With [select](id)
                        result.lastCurrenciesCheck = .lastCurrenciesCheck
                        result.lastProductsCheck = .lastProductsCheck

                        If (.lastCurrenciesCheck = 0) Then
                            result.nextCurrenciesCheck = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime() + (24 * 60 * 60 * 1000)
                        Else
                            result.nextCurrenciesCheck = .lastCurrenciesCheck + (24 * 60 * 60 * 1000)
                        End If

                        If (.lastProductsCheck = 0) Then
                            result.nextProductsCheck = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime() + (24 * 60 * 60 * 1000)
                        Else
                            result.nextProductsCheck = .lastProductsCheck + (24 * 60 * 60 * 1000)
                        End If
                    End With
                End If

                Return result
            Catch ex As Exception
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackException("ExchangeEngine.selectScheduleJob", forceOwner, ex.Message)

                Return result
            Finally
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackExit("ExchangeEngine.selectScheduleJob", forceOwner)
            End Try
        End Function

        ''' <summary>
        ''' This method provide to execute schedule command
        ''' </summary>
        ''' <param name="data"></param>
        ''' <param name="ownerId"></param>
        ''' <returns></returns>
        Public Function executeCommand(ByRef data As ExchangeActionModel, ByVal forceOwner As String) As Boolean
            Try
                Dim executeCommandValue As Boolean = False

                If (forceOwner.Length = 0) Then
                    forceOwner = _OwnerId
                End If

                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackEnter("ExchangeEngine.executeScheduleCommand", forceOwner)

                If _Initialize Then
                    With [select](data.exchangeId)
                        If (.id <> 0) And .isActive Then
                            If data.command = ExchangeActionModel.ActionEnumeration.updateCurrencies Then
                                RaiseEvent UpdateExchangeCurrency(data.exchangeId, executeCommandValue)
                            ElseIf data.command = ExchangeActionModel.ActionEnumeration.updateProducts Then
                                RaiseEvent UpdateExchangeProducts(data.exchangeId, executeCommandValue)
                            End If
                        End If
                    End With
                End If

                Return executeCommandValue
            Catch ex As Exception
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackException("ExchangeEngine.executeScheduleCommand", forceOwner, ex.Message)

                Return False
            Finally
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackExit("ExchangeEngine.executeScheduleCommand", forceOwner)
            End Try
        End Function

        ''' <summary>
        ''' This method provide to return a count of a exchange table
        ''' </summary>
        ''' <returns></returns>
        Public Function count(Optional ByVal forceOwner As String = "") As Integer
            Try
                If (forceOwner.Length = 0) Then
                    forceOwner = _OwnerId
                End If

                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackEnter("ExchangeEngine.count", forceOwner)

                If _Initialize Then
                    If useCache Then
                        Return _CacheExchangeById.Count
                    Else
                        Dim sql As String
                        Dim result As Object

                        sql = $"SELECT Count(id) as numExchange FROM exchanges"

                        result = _EngineDB.selectResultDataTable(sql, forceOwner)

                        If Not IsNothing(result) Then
                            Return result
                        End If
                    End If
                End If

                Return 0
            Catch ex As Exception
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackException("ExchangeEngine.count", forceOwner, ex.Message)

                Return 0
            Finally
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackExit("ExchangeEngine.count", forceOwner)
            End Try
        End Function

        ''' <summary>
        ''' This method provide to get a list of a table's exchange
        ''' </summary>
        ''' <returns></returns>
        Public Function list(Optional ByVal loadEntireCache As Boolean = False, Optional ByVal forceOwner As String = "", Optional ByVal checkActive As Boolean = False) As List(Of ExchangeStructure)
            Dim sql As String = ""
            Dim result As Object
            Dim openDB As Object
            Dim response As New List(Of ExchangeStructure)

            If (forceOwner.Length = 0) Then
                forceOwner = _OwnerId
            End If

            Try
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackEnter("ExchangeEngine.list", forceOwner)

                If _Initialize Then
                    If useCache And Not loadEntireCache Then
                        Return _CacheExchangeById.Values.ToList()
                    Else
                        sql += $"SELECT A.id, A.name, A.isActive, A.lastCurrenciesCheck, A.lastProductsCheck, A.isCentralized, B.name as [group], A.isUsed "
                        sql += $"FROM exchanges A LEFT Join exchanges B ON A.groupId = B.id "

                        openDB = _EngineDB.openDatabase(forceOwner)

                        If Not IsNothing(openDB) Then
                            result = _EngineDB.selectDataReader(openDB, sql, forceOwner)

                            If Not IsNothing(result) Then
                                Dim item As ExchangeStructure

                                While result.read()
                                    item = New ExchangeStructure

                                    item.id = result.GetInt32(0)
                                    item.name = result.GetString(1)
                                    item.isActive = (result.GetInt32(2) <> 0)
                                    item.lastCurrenciesCheck = result.getDouble(3)
                                    item.lastProductsCheck = result.getDouble(4)
                                    item.isCentralized = (result.getInt32(5) <> 0)

                                    Try
                                        item.group = result.getString(6)
                                    Catch ex As Exception
                                        item.group = ""
                                    End Try

                                    item.isUsed = (result.GetInt32(7) <> 0)

                                    _CacheExchangeById.Add(item.id, item)
                                    _CacheExchangeByName.Add(item.name, item)

                                    response.Add(item)
                                End While
                            End If

                            openDB.close()
                        End If
                    End If
                End If
            Catch ex As Exception
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackException("ExchangeEngine.list", forceOwner, $"{ex.Message}")

                Return New List(Of ExchangeStructure)
            Finally
                If checkActive Then
                    For Each item In response
                        If (item.id <> 0) And item.isActive Then
                            RaiseEvent SetExchangeActive(item.id, item.lastCurrenciesCheck, item.lastProductsCheck)
                        End If
                    Next
                End If

                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackExit("ExchangeEngine.list", forceOwner)
            End Try

            Return response
        End Function

        ''' <summary>
        ''' This method provide to delete an unique id item's
        ''' </summary>
        ''' <param name="id"></param>
        ''' <returns></returns>
        Public Function delete(ByVal id As Integer, Optional ByVal forceOwner As String = "") As Boolean
            Try
                If (forceOwner.Length = 0) Then
                    forceOwner = _OwnerId
                End If

                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackEnter("ExchangeEngine.delete", forceOwner)

                If useCache Then
                    If Not _CacheExchangeById.ContainsKey(id) Then
                        Return False
                    ElseIf _CacheExchangeById(id).isUsed Then
                        Return False
                    ElseIf _CacheExchangeById.ContainsKey(id) Then
                        _CacheExchangeByName.Remove(_CacheExchangeById(id).name)
                        _CacheExchangeById.Remove(id)
                    End If
                Else
                    If [select](id, forceOwner).isUsed Then
                        Return False
                    End If
                End If

                Return _EngineDB.executeDataTable($"DELETE FROM exchanges WHERE [id] = {id}", forceOwner)
            Catch ex As Exception
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackException("ExchangeEngine.delete", forceOwner, ex.Message)

                Return False
            Finally
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackExit("ExchangeEngine.delete", forceOwner)
            End Try
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
                    _OwnerId = "ExchangeEngine"

                    CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackEnter("ExchangeEngine.init", _OwnerId)

                    _Initialize = True

                    If Not _EngineDB.existTable("exchanges", _OwnerId) Then
                        CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.track("ExchangeEngine.init", _OwnerId, "Exchange table not exist")

                        If Not createStructures() Then
                            CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.track("ExchangeEngine.init", _OwnerId, "Problem during create db structures")

                            Return False
                        End If
                    ElseIf useCache Then
                        list(True,, True)
                    End If

                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackException("ExchangeEngine.init", _OwnerId, ex.Message)

                Return False
            Finally
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackExit("ExchangeEngine.init", _OwnerId)
            End Try
        End Function

    End Class

End Namespace
