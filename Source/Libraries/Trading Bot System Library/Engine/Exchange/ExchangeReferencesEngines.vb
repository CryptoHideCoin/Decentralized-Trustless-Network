Option Compare Text
Option Explicit On

Imports TradingBotSystemModelsLibrary.AreaModel.Exchange






Namespace AreaBusiness

    ''' <summary>
    ''' This engine contain all method relative of a exchange references
    ''' </summary>
    Public Class ExchangeReferencesEngine

        Public Class ExchangeReferencesCache

            Public Property exchange_id As Integer
            Public Property referenceData As New List(Of ExchangeReferenceStructure)

        End Class

        Private Property _EngineDB As New CHCDataAccess.AreaCommon.Database.DatabaseGeneric
        Private Property _DBStateFileName As String = "EvaluationState.Db"
        Private Property _Initialize As Boolean = False
        Private Property _OwnerId As String = ""
        Private Property _CacheInMemory As New List(Of ExchangeReferencesCache)

        Public Property useCache As Boolean = False



        ''' <summary>
        ''' This method provide to create an exchange reference table
        ''' </summary>
        ''' <returns></returns>
        Private Function createExchangeReferenceTable() As Boolean
            Try
                Dim sql As String = ""

                sql += "CREATE TABLE exchangeReferences "
                sql += " (exchange_id INTEGER, "
                sql += "  urlType INTEGER, "
                sql += "  url NVARCHAR(1024), "
                sql += " PRIMARY KEY (exchange_id, urlType));"

                Return _EngineDB.executeDataTable(sql)
            Catch ex As Exception
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackException("ExchangeReferencesEngine.createExchangeReferenceTable", _OwnerId, ex.Message)

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
                    proceed = createExchangeReferenceTable()
                End If

                Return proceed
            Catch ex As Exception
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackException("ExchangeReferencesEngine.createStructures", _OwnerId, ex.Message)

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to add a new exchange reference into table
        ''' </summary>
        ''' <param name="exchange_id"></param>
        ''' <param name="urlType"></param>
        ''' <param name="url"></param>
        ''' <param name="forceOwner"></param>
        ''' <returns></returns>
        Private Function addNew(ByVal exchange_id As Integer, ByVal urlType As ExchangeReferenceStructure.TypeReferenceEnumeration, ByVal url As String, ByVal forceOwner As String) As Boolean
            Try
                Dim sql As String

                sql = $"INSERT INTO exchangeReferences (exchange_id, urlType, url) VALUES ({exchange_id}, {urlType}, '{url}')"

                Return _EngineDB.executeDataTableAndReturnID(sql, forceOwner)
            Catch ex As Exception
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackException("ExchangeReferencesEngine.addNew", forceOwner, ex.Message)

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to update SQL
        ''' </summary>
        ''' <param name="exchange_id"></param>
        ''' <param name="urlType"></param>
        ''' <param name="url"></param>
        ''' <param name="forceOwner"></param>
        ''' <returns></returns>
        Private Function updateSQL(ByVal exchange_id As Integer, ByVal urlType As ExchangeReferenceStructure.TypeReferenceEnumeration, ByVal url As String, ByVal forceOwner As String) As Boolean
            Try
                Dim sql As String

                sql = $"UPDATE exchangeReferences SET url = '{url}' WHERE exchange_id = {exchange_id} AND urlType = {urlType}"

                Return _EngineDB.executeDataTable(sql, forceOwner)
            Catch ex As Exception
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackException("ExchangeReferencesEngine.updateSQL", forceOwner, ex.Message)

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method Add or Get the Id of a name of the exchange reference
        ''' </summary>
        ''' <param name="exchange_id"></param>
        ''' <param name="urlType"></param>
        ''' <param name="url"></param>
        ''' <param name="forceOwner"></param>
        ''' <returns></returns>
        Public Function addIfMissing(ByVal exchange_id As Integer, ByVal urlType As ExchangeReferenceStructure.TypeReferenceEnumeration, ByVal url As String, Optional ByVal forceOwner As String = "") As Boolean
            If (forceOwner.Length = 0) Then
                forceOwner = _OwnerId
            End If

            Try
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackEnter("ExchangeReferencesEngine.addIfMissing", forceOwner)

                If _Initialize Then
                    Dim exchangeData As List(Of ExchangeReferenceStructure)
                    Dim foundReference As Boolean = False

                    If useCache Then
                        For Each item In _CacheInMemory
                            If (item.exchange_id = exchange_id) Then
                                exchangeData = item.referenceData

                                Exit For
                            End If
                        Next

#Disable Warning BC42104
                        If Not IsNothing(exchangeData) Then
#Enable Warning BC42104
                            For Each item In exchangeData
                                If (item.urlType = urlType) Then
                                    foundReference = True
                                End If
                            Next

                            If Not foundReference Then
                                exchangeData.Add(New ExchangeReferenceStructure() With {.exchange_id = exchange_id, .urlType = urlType, .url = url})

                                Return addNew(exchange_id, urlType, url, forceOwner)
                            Else
                                Return True
                            End If
                        Else
                            Dim newReference As New ExchangeReferenceStructure
                            Dim newItem As New ExchangeReferencesCache

                            newReference.exchange_id = exchange_id
                            newReference.urlType = urlType
                            newReference.url = url

                            newItem.exchange_id = exchange_id
                            newItem.referenceData.Add(newReference)

                            _CacheInMemory.Add(newItem)

                            Return addNew(exchange_id, urlType, url, forceOwner)
                        End If
                    Else
                        Dim sql As String
                        Dim result As Object
                        Dim openDB As Object

                        Sql = $"SELECT exchange_id FROM exchangeReferences WHERE exchange_id = {exchange_id} AND urlType = {urlType}"

                        openDB = _EngineDB.openDatabase(forceOwner)

                        If Not IsNothing(openDB) Then
                            result = _EngineDB.selectDataReader(openDB, Sql, forceOwner)

                            If Not IsNothing(result) Then
                                openDB.close()

                                Return True
                            Else
                                openDB.close()
                            End If
                        End If
                    End If

                    Return addNew(exchange_id, urlType, url, forceOwner)
                Else
                    Return False
                End If
            Catch ex As Exception
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackException("ExchangeReferencesEngine.addIfMissing", forceOwner, ex.Message)

                Return False
            Finally
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackExit("ExchangeReferencesEngine.addIfMissing", forceOwner)
            End Try
        End Function

        ''' <summary>
        ''' This method provide to modify into db and into cache data the name of an exchange
        ''' </summary>
        ''' <param name="id"></param>
        ''' <param name="newName"></param>
        ''' <returns></returns>
        Public Function updateExchangeReference(ByVal exchange_id As Integer, ByVal urlType As ExchangeReferenceStructure.TypeReferenceEnumeration, ByVal url As String, Optional ByVal forceOwner As String = "") As Boolean
            If (forceOwner.Length = 0) Then
                forceOwner = _OwnerId
            End If

            Try
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackEnter("ExchangeReferencesEngine.updateExchangeReference", _OwnerId)

                If _Initialize Then
                    Dim exchangeData As List(Of ExchangeReferenceStructure)
                    Dim foundReference As Boolean = False

                    If useCache Then
                        For Each item In _CacheInMemory
                            If (item.exchange_id = exchange_id) Then
                                exchangeData = item.referenceData

                                Exit For
                            End If
                        Next

#Disable Warning BC42104
                        If Not IsNothing(exchangeData) Then
#Enable Warning BC42104
                            For Each item In exchangeData
                                If (item.urlType = urlType) Then
                                    item.url = url

                                    foundReference = True
                                End If
                            Next

                            If Not foundReference Then
                                Return False
                            Else
                                Return updateSQL(exchange_id, urlType, url, forceOwner)
                            End If
                        Else
                            Return False
                        End If
                    End If

                    Return updateSQL(exchange_id, urlType, url, forceOwner)
                End If

                Return False
            Catch ex As Exception
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackException("ExchangeReferencesEngine.updateExchangeReference", forceOwner, ex.Message)

                Return False
            Finally
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackExit("ExchangeReferencesEngine.updateExchangeReference", forceOwner)
            End Try
        End Function

        ''' <summary>
        ''' This method provide to get an exchange reference from an Id and Type
        ''' </summary>
        ''' <param name="id"></param>
        ''' <returns></returns>
        Public Function [select](ByVal exchange_id As Integer, ByVal urlType As ExchangeReferenceStructure.TypeReferenceEnumeration, Optional ByVal forceOwner As String = "") As ExchangeReferenceStructure
            Dim response As New ExchangeReferenceStructure With {.exchange_id = exchange_id, .urlType = urlType}

            If (forceOwner.Length = 0) Then
                forceOwner = _OwnerId
            End If
            Try
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackEnter("ExchangeReferencesEngine.[select]", forceOwner)

                If _Initialize Then
                    If useCache Then
                        Dim exchangeData As List(Of ExchangeReferenceStructure)

                        For Each item In _CacheInMemory
                            If (item.exchange_id = exchange_id) Then
                                exchangeData = item.referenceData

                                Exit For
                            End If
                        Next

#Disable Warning BC42104
                        If Not IsNothing(exchangeData) Then
#Enable Warning BC42104
                            For Each item In exchangeData
                                If (item.urlType = urlType) Then
                                    response.url = item.url

                                    Return response
                                End If
                            Next
                        End If
                    Else
                        Dim sql As String
                        Dim result As Object

                        sql = $"SELECT url FROM exchangeReferences WHERE exchange_id = {exchange_id} and urlType = {urlType}"

                        result = _EngineDB.selectResultDataTable(sql, forceOwner)

                        If Not IsNothing(result) Then
                            response.url = result

                            Return response
                        End If
                    End If
                End If

                Return New ExchangeReferenceStructure
            Catch ex As Exception
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackException("ExchangeReferencesEngine.[select]", forceOwner, ex.Message)

                Return New ExchangeReferenceStructure
            Finally
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackExit("ExchangeReferencesEngine.[select]", forceOwner)
            End Try
        End Function

        ''' <summary>
        ''' This method provide to return a count of a exchange reference table
        ''' </summary>
        ''' <returns></returns>
        Public Function count(ByVal exchange_id As Integer, Optional ByVal forceOwner As String = "") As Integer
            If (forceOwner.Length = 0) Then
                forceOwner = _OwnerId
            End If
            Try
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackEnter("ExchangeReferencesEngine.count", forceOwner)

                If _Initialize Then
                    If useCache Then
                        For Each item In _CacheInMemory
                            If (item.exchange_id = exchange_id) Then
                                Return item.referenceData.Count
                            End If
                        Next
                    Else
                        Dim sql As String
                        Dim result As Object

                        sql = $"SELECT Count(id) as numExchange FROM exchangeReferences WHERE exchange_id = {exchange_id}"

                        result = _EngineDB.selectResultDataTable(sql, forceOwner)

                        If Not IsNothing(result) Then
                            Return result
                        End If
                    End If
                End If

                Return 0
            Catch ex As Exception
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackException("ExchangeReferencesEngine.count", forceOwner, ex.Message)

                Return 0
            Finally
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackExit("ExchangeReferencesEngine.count", forceOwner)
            End Try
        End Function

        ''' <summary>
        ''' This method provide to get all reference of exchange
        ''' </summary>
        ''' <returns></returns>
        Public Function listAll(Optional ByVal loadEntireCache As Boolean = False, Optional ByVal forceOwner As String = "") As List(Of ExchangeReferencesCache)
            If (forceOwner.Length = 0) Then
                forceOwner = _OwnerId
            End If

            Try
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackEnter("ExchangeReferencesEngine.listAll", forceOwner)

                If _Initialize Then
                    If useCache And Not loadEntireCache Then
                        Return _CacheInMemory
                    Else
                        Dim response As New List(Of ExchangeReferencesCache)
                        Dim currentDataReference As New ExchangeReferencesCache
                        Dim sql As String
                        Dim result As Object
                        Dim openDB As Object

                        sql = $"SELECT exchange_id, urlType, url FROM exchangeReferences "

                        openDB = _EngineDB.openDatabase(forceOwner)

                        If Not IsNothing(openDB) Then
                            result = _EngineDB.selectDataReader(openDB, Sql, forceOwner)

                            If Not IsNothing(result) Then
                                Dim item As ExchangeReferenceStructure

                                While result.read()
                                    item = New ExchangeReferenceStructure

                                    item.exchange_id = result.GetInt32(0)
                                    item.urlType = result.GetInt32(1)
                                    item.url = result.GetString(2)

                                    If (currentDataReference.exchange_id <> item.exchange_id) Then
                                        item = New ExchangeReferenceStructure

                                        currentDataReference.exchange_id = item.exchange_id
                                        response.Add(currentDataReference)

                                        If loadEntireCache Then
                                            _CacheInMemory.Add(currentDataReference)
                                        End If
                                    End If
                                End While
                            End If

                            openDB.close()

                            Return response
                        End If
                    End If
                End If

                Return New List(Of ExchangeReferencesCache)
            Catch ex As Exception
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackException("ExchangeReferencesEngine.listAll", forceOwner, ex.Message)

                Return New List(Of ExchangeReferencesCache)
            Finally
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackExit("ExchangeReferencesEngine.listAll", forceOwner)
            End Try
        End Function

        ''' <summary>
        ''' This method provide to get a list of a reference of an exchange
        ''' </summary>
        ''' <returns></returns>
        Public Function list(ByVal exchange_id As Integer, Optional ByVal forceOwner As String = "") As List(Of ExchangeReferenceStructure)
            If (forceOwner.Length = 0) Then
                forceOwner = _OwnerId
            End If

            Try
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackEnter("ExchangeReferencesEngine.list", forceOwner)

                If _Initialize Then
                    If useCache Then
                        For Each item In _CacheInMemory
                            If (item.exchange_id = exchange_id) Then
                                Return item.referenceData
                            End If
                        Next

                        Return New List(Of ExchangeReferenceStructure)
                    Else
                        Dim response As New List(Of ExchangeReferenceStructure)
                        Dim sql As String
                        Dim result As Object
                        Dim openDB As Object

                        sql = $"SELECT exchange_id, urlType, url FROM exchangeReferences WHERE exchange_id = {exchange_id}"

                        openDB = _EngineDB.openDatabase(forceOwner)

                        If Not IsNothing(openDB) Then
                            result = _EngineDB.selectDataReader(openDB, sql, forceOwner)

                            If Not IsNothing(result) Then
                                Dim item As ExchangeReferenceStructure

                                While result.read()
                                    item = New ExchangeReferenceStructure

                                    item.exchange_id = result.GetInt32(0)
                                    item.urlType = result.GetInt32(1)
                                    item.url = result.GetString(2)

                                    response.Add(item)
                                End While
                            End If

                            openDB.close()

                            Return response
                        End If
                    End If
                End If

                Return New List(Of ExchangeReferenceStructure)
            Catch ex As Exception
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackException("ExchangeReferencesEngine.list", forceOwner, ex.Message)

                Return New List(Of ExchangeReferenceStructure)
            Finally
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackExit("ExchangeReferencesEngine.list", forceOwner)
            End Try
        End Function

        ''' <summary>
        ''' This method provide to delete an unique id item's
        ''' </summary>
        ''' <param name="exchange_id"></param>
        ''' <param name="forceOwner"></param>
        ''' <returns></returns>
        Public Function deleteExchange(ByVal exchange_id As Integer, Optional ByVal forceOwner As String = "") As Boolean
            If (forceOwner.Length = 0) Then
                forceOwner = _OwnerId
            End If

            Try
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackEnter("ExchangeReferencesEngine.deleteExchange", forceOwner)

                If useCache Then
                    Dim toDelete As ExchangeReferencesCache

                    For Each item In _CacheInMemory
                        If (item.exchange_id = exchange_id) Then
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

                Return _EngineDB.executeDataTable($"DELETE exchanges WHERE exchange_id = {exchange_id}", forceOwner)
            Catch ex As Exception
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackException("ExchangeReferencesEngine.deleteExchange", forceOwner, ex.Message)

                Return False
            Finally
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackExit("ExchangeReferencesEngine.deleteExchange", forceOwner)
            End Try
        End Function

        ''' <summary>
        ''' This method provide to delete a singleReference
        ''' </summary>
        ''' <param name="exchange_id"></param>
        ''' <param name="urlType"></param>
        ''' <param name="forceOwner"></param>
        ''' <returns></returns>
        Public Function delete(ByVal exchange_id As Integer, ByVal urlType As ExchangeReferenceStructure.TypeReferenceEnumeration, Optional ByVal forceOwner As String = "") As Boolean
            If (forceOwner.Length = 0) Then
                forceOwner = _OwnerId
            End If

            Try
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackEnter("ExchangeReferencesEngine.delete", forceOwner)

                If useCache Then
                    Dim exchangeData As ExchangeReferencesCache
                    Dim toDelete As ExchangeReferenceStructure

                    For Each item In _CacheInMemory
                        If (item.exchange_id = exchange_id) Then
                            exchangeData = item

                            Exit For
                        End If
                    Next

#Disable Warning BC42104
                    If Not IsNothing(exchangeData) Then
#Enable Warning BC42104
                        For Each item In exchangeData.referenceData
                            If (item.urlType = urlType) Then
                                toDelete = item

                                Exit For
                            End If
                        Next

#Disable Warning BC42104
                        If Not IsNothing(toDelete) Then
#Enable Warning BC42104
                            exchangeData.referenceData.Remove(toDelete)

                            If exchangeData.referenceData.Count = 0 Then
                                _CacheInMemory.Remove(exchangeData)
                            End If
                        End If
                    End If
                End If

                Return _EngineDB.executeDataTable($"DELETE exchangeReferences WHERE exchange_id = {exchange_id} AND typeUrl = {Val(urlType)}", forceOwner)
            Catch ex As Exception
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackException("ExchangeReferencesEngine.delete", forceOwner, ex.Message)

                Return False
            Finally
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackExit("ExchangeReferencesEngine.delete", forceOwner)
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
                    _OwnerId = "ExchangeReferenceEngine"

                    CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackEnter("ExchangeReferencesEngine.init", _OwnerId)

                    If Not _EngineDB.existTable("exchangeReferences", _OwnerId) Then
                        CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.track("ExchangeReferencesEngine.init", _OwnerId, "Exchange table not exist")

                        If Not createStructures() Then
                            CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.track("ExchangeReferencesEngine.init", _OwnerId, "Problem during create db structures")

                            Return False
                        End If
                    ElseIf useCache Then
                        listAll(True)
                    End If

                    _Initialize = True

                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackException("ExchangeReferencesEngine.init", _OwnerId, ex.Message)

                Return False
            Finally
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackExit("ExchangeReferencesEngine.init", _OwnerId)
            End Try
        End Function

    End Class

End Namespace
