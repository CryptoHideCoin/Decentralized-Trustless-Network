Option Explicit On
Option Compare Text

' ****************************************
' Engine: Counter Engine
' Release Engine: 1.0 
' 
' Date last successfully test: 28/05/2022
' ****************************************

Imports CHCCommonLibrary.AreaEngine
Imports CHCModelsLibrary.AreaModel.Counter




Namespace AreaEngine

    Public Class CounterEngine

        Private Property _EngineDB As New CHCDataAccess.AreaCommon.Database.DatabaseGeneric
        Private Property _DBStateFileName As String = "Counter.Db"
        Private Property _Initialize As Boolean = False
        Private Property _OwnerId As String = ""

        Public WithEvents core As New CounterAPICacheEngine
        Public Property writeIntoDB As Boolean = True



        Public Property serviceActive As Boolean
            Get
                Return core.serviceActive
            End Get
            Set(value As Boolean)
                core.serviceActive = value
            End Set
        End Property

        Public Property timeSpan() As CHCModelsLibrary.AreaModel.Administration.Settings.ShortTimeEnum
            Get
                Return core.timeSpan
            End Get
            Set(value As CHCModelsLibrary.AreaModel.Administration.Settings.ShortTimeEnum)
                Select Case value
                    Case CHCModelsLibrary.AreaModel.Administration.Settings.ShortTimeEnum.second : core.timeSpan = 1000
                    Case CHCModelsLibrary.AreaModel.Administration.Settings.ShortTimeEnum.minute : core.timeSpan = 60000
                    Case CHCModelsLibrary.AreaModel.Administration.Settings.ShortTimeEnum.hour : core.timeSpan = 60 * 60000
                End Select
            End Set
        End Property


        ''' <summary>
        ''' This method provide to create a main table
        ''' </summary>
        ''' <returns></returns>
        Private Function createEntryPointTable() As Boolean
            Try
                Dim sql As String = ""

                sql += "CREATE TABLE entryPoints "
                sql += " ([id] INTEGER PRIMARY KEY AUTOINCREMENT, "
                sql += "  [name] NVARCHAR(1024));"

                Return _EngineDB.executeDataTable(sql)
            Catch ex As Exception
                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to create a main table
        ''' </summary>
        ''' <returns></returns>
        Private Function createCountersTable() As Boolean
            Try
                Dim sql As String = ""

                sql += "CREATE TABLE counters "
                sql += " ([entryPoint_id] INTEGER NOT NULL, "
                sql += "  [slotTime] REAL, "
                sql += "  [isAPI] INTEGER, "
                sql += "  [value] INTEGER);"

                Return _EngineDB.executeDataTable(sql)
            Catch ex As Exception
                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to create a main table
        ''' </summary>
        ''' <returns></returns>
        Private Function createEntryPointIndex() As Boolean
            Try
                Dim sql As String = ""

                sql += "CREATE UNIQUE INDEX idx_Name "
                sql += " ON entryPoints ([name])"

                Return _EngineDB.executeDataTable(sql)
            Catch ex As Exception
                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to create a main table
        ''' </summary>
        ''' <returns></returns>
        Private Function createCountersIndex() As Boolean
            Try
                Dim sql As String = ""

                sql += "CREATE INDEX idx_Primary "
                sql += " ON counters ([entryPoint_id])"

                Return _EngineDB.executeDataTable(sql)
            Catch ex As Exception
                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to add a new entry point API and return Id
        ''' </summary>
        ''' <param name="apiName"></param>
        ''' <returns></returns>
        Private Function addNewEntryPoint(ByVal apiName As String) As Integer
            Try
                Dim sql As String

                sql = $"INSERT INTO entryPoints ([name]) VALUES ('{apiName}')"

                Return _EngineDB.executeDataTableAndReturnID(sql)
            Catch ex As Exception
                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method Add or Get API Ids
        ''' </summary>
        ''' <param name="apiName"></param>
        ''' <returns></returns>
        Private Function addOrGetAPI(ByVal apiName As String) As Integer
            Try
                Dim sql As String
                Dim result As Object

                sql = $"SELECT id FROM entryPoints WHERE [name] = '{apiName}'"

                result = _EngineDB.selectResultDataTable(sql)

                If Not IsNothing(result) Then
                    Return result
                Else
                    Return addNewEntryPoint(apiName)
                End If
            Catch ex As Exception
                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to add a slot time the API
        ''' </summary>
        ''' <param name="timeSlot"></param>
        ''' <param name="id_Api"></param>
        ''' <param name="access"></param>
        ''' <returns></returns>
        Private Function addSlotTime(ByVal timeSlot As Double, ByVal id_Api As Integer, ByVal fromAPI As Boolean, ByVal access As Integer) As Boolean
            Try
                Dim sql As String
                Dim result As Object
                Dim value As Integer

                If fromAPI Then
                    value = "1"
                Else
                    value = "0"
                End If

                sql = $"INSERT INTO counters ([entryPoint_id], [slotTime], [isAPI], [value]) VALUES ({id_Api}, '{timeSlot}', {value}, {access})"

                result = _EngineDB.executeDataTable(sql)

                If Not IsNothing(result) Then
                    Return False
                Else
                    Return True
                End If
            Catch ex As Exception
                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to remove all information before the limit time value parameter
        ''' </summary>
        ''' <param name="limitTime"></param>
        ''' <returns></returns>
        Public Function removeOld(ByVal limitTime As Double) As Boolean
            Try
                Dim sql As String
                Dim result As Object

                sql = $"DELETE FROM counters WHERE [slotTime]< '{limitTime}'"

                result = _EngineDB.executeDataTable(sql)

                If Not IsNothing(result) Then
                    Return False
                Else
                    Return True
                End If
            Catch ex As Exception
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
                    proceed = createEntryPointTable()
                End If
                If proceed Then
                    AreaCommon.Main.environment.log.track("CounterEngine.createStructures", _OwnerId, "Create 'EntryPoint' table")

                    proceed = createEntryPointIndex()
                End If
                If proceed Then
                    AreaCommon.Main.environment.log.track("CounterEngine.createStructures", _OwnerId, "Create 'EntryPoint' Index 'Name' field")

                    proceed = createCountersTable()
                End If
                If proceed Then
                    AreaCommon.Main.environment.log.track("CounterEngine.createStructures", _OwnerId, "Create 'Counters' table")

                    proceed = createCountersIndex()
                End If
                If proceed Then
                    AreaCommon.Main.environment.log.track("CounterEngine.createStructures", _OwnerId, "Create 'Counters' Primary Index")
                End If

                Return proceed
            Catch ex As Exception
                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method return a get total call
        ''' </summary>
        ''' <param name="isAPI"></param>
        ''' <param name="fromTimestamp"></param>
        ''' <param name="toTimeStamp"></param>
        ''' <returns></returns>
        Public Function getTotalCall(ByVal isAPI As Boolean, ByVal fromTimestamp As Double, ByVal toTimeStamp As Double) As Integer
            Try
                Dim sql As String
                Dim result As Object

                sql = $"select sum(value) as totalValue FROM counters WHERE slotTime >= '{fromTimestamp}' AND slotTime <= '{toTimeStamp}'"

                If isAPI Then
                    sql += " AND isApi <> 0"
                Else
                    sql += " AND isApi = 0"
                End If

                result = _EngineDB.selectResultDataTable(sql)

                If Not IsNothing(result) Then
                    Return result
                Else
                    Return 0
                End If
            Catch ex As Exception
                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to return a totals of a filter counter
        ''' </summary>
        ''' <param name="filter"></param>
        ''' <returns></returns>
        Public Function getTotals(filter As QueryCounterFilter) As QuerySingleTotal
            Dim value As New QuerySingleTotal

            Try
                Select Case filter.components
                    Case QueryCounterFilter.CounterComponentEnumeration.both
                        value.onlyAPI = getTotalCall(True, filter.fromTimestamp, filter.toTimeStamp)
                        value.onlyOther = getTotalCall(False, filter.fromTimestamp, filter.toTimeStamp)
                    Case QueryCounterFilter.CounterComponentEnumeration.onlyAPI
                        value.onlyAPI = getTotalCall(True, filter.fromTimestamp, filter.toTimeStamp)
                    Case QueryCounterFilter.CounterComponentEnumeration.onlyOther
                        value.onlyOther = getTotalCall(False, filter.fromTimestamp, filter.toTimeStamp)
                End Select
            Catch ex As Exception
            End Try

            Return value
        End Function

        ''' <summary>
        ''' This method provide to return a counter Time slot in async
        ''' </summary>
        ''' <param name="filter"></param>
        ''' <returns></returns>
        Public Function getCounterTimeSlots(filter As QueryCounterFilter) As List(Of SlotDetailValue)
            Dim sql As String
            Dim result As Object
            Dim openDB As Object
            Dim value As New List(Of SlotDetailValue)

            Try
                AreaCommon.Main.environment.log.trackEnter("CounterEngine.getCounterTimeSlots", _OwnerId)

                sql = $"SELECT slotTime, sum(value) as sumSlotTime FROM counters WHERE slotTime >= '{filter.fromTimestamp}' AND slotTime <= '{filter.toTimeStamp}'"

                If (filter.components = QueryCounterFilter.CounterComponentEnumeration.onlyAPI) Then
                    sql += " AND isApi <> 0"
                ElseIf (filter.components = QueryCounterFilter.CounterComponentEnumeration.onlyOther) Then
                    sql += " AND isApi = 0"
                End If

                sql += " GROUP BY slotTime"

                openDB = _EngineDB.openDatabase()

                If Not IsNothing(openDB) Then
                    result = _EngineDB.selectDataReader(openDB, sql)

                    If Not IsNothing(result) Then
                        Dim item As SlotDetailValue

                        While result.read()
                            item = New SlotDetailValue

                            item.timestamp = CDbl(result.GetString(0))
                            item.value.onlyOther = result.GetInt32(1)

                            value.Add(item)
                        End While
                    End If

                    openDB.close()
                End If
            Catch ex As Exception
                AreaCommon.Main.environment.log.trackException("CounterEngine.selectResultDataTable", _OwnerId, ex.Message)
            Finally
                AreaCommon.Main.environment.log.trackExit("CounterEngine.selectResultDataTable", _OwnerId)
            End Try

            Return value
        End Function


        ''' <summary>
        ''' This method provide to initialize the Counter Engine
        ''' </summary>
        ''' <param name="path"></param>
        ''' <returns></returns>
        Public Function init(ByVal path As String) As Boolean
            Try
                _EngineDB.path = path
                _EngineDB.fileName = _DBStateFileName
                _EngineDB.logInstance = AreaCommon.Main.environment.log

                If Not IO.Directory.Exists(path) Then
                    IO.Directory.CreateDirectory(path)
                End If

                If _EngineDB.init("Counter", "Custom") Then
                    _OwnerId = "CounterEngine"

                    AreaCommon.Main.environment.log.trackEnter("CounterEngine.init", _OwnerId)

                    If Not _EngineDB.existTable("counters") Then
                        AreaCommon.Main.environment.log.track("CounterEngine.init", _OwnerId, "TimeCounters table not exist")

                        If Not createStructures() Then
                            AreaCommon.Main.environment.log.track("CounterEngine.init", _OwnerId, "Problem during create db structures")

                            Return False
                        End If
                    End If

                    _Initialize = True

                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                AreaCommon.Main.environment.log.trackException("CounterEngine.init", _OwnerId, ex.Message)

                Return False
            Finally
                AreaCommon.Main.environment.log.trackExit("CounterEngine.init", _OwnerId)
            End Try
        End Function


        Private Sub core_changeBlock(ByVal fromAPI As Boolean) Handles core.changeBlock
            If _Initialize And core.serviceActive And writeIntoDB Then
                Dim elements As Dictionary(Of String, CounterAPICacheEngine.CounterCache)
                Dim api As CounterAPICacheEngine.CounterCache
                Dim timeSlot As Double

                If fromAPI Then
                    timeSlot = core.previousAPIBlock.timeStart

                    elements = core.previousAPIBlock.elements
                Else
                    timeSlot = core.previousWEBBlock.timeStart

                    elements = core.previousWEBBlock.elements
                End If

                Do While (elements.Values.Count > 0)
                    api = elements.Values(0)

                    addSlotTime(timeSlot, addOrGetAPI(api.name), fromAPI, api.access)

                    elements.Remove(api.name)
                Loop
            End If
        End Sub

    End Class

End Namespace
