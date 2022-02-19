Option Compare Text
Option Explicit On

' ****************************************
' Engine: Log Cache
' Release Engine: 1.0 
' 
' Date last successfully test: 05/02/2022
' ****************************************



Namespace AreaEngine.Log

    ''' <summary>
    ''' This class contain the Log Cache
    ''' </summary>
    Friend Class TrackCacheEngine

        Private Property _DataCache As New List(Of SingleActionApplication)
        Private Property _InQueue As New List(Of SingleActionApplication)
        Private Property _IO As New TrackIOEngine
        Private Property _SaveMode As TrackRuntimeModeEnum
        Private Property _ToProcessDataCache As Boolean = False
        Private Property _ToProcessInQueue As Boolean = False
        Private Property _ToFlushCache As Boolean = False
        Private Property _InBootstrapMode As Boolean = True

        Public Property timeInCache As Double = 6000


        ''' <summary>
        ''' This method provide to transfer this information to engine to write data
        ''' </summary>
        ''' <returns></returns>
        Private Function flushCache(Optional ByVal forceClean As Boolean = False) As Boolean
            Try
                Dim limit As Double = Miscellaneous.timeStampFromDateTime() - timeInCache
                Dim i As Integer
                Dim item As SingleActionApplication
                Dim itemToWrite As Boolean = False

                _ToFlushCache = True

                i = 0

                Do While (i <= _DataCache.Count - 1)
                    item = _DataCache(i)

                    If (item.instant < limit) Or forceClean Then

                        If (item.action = ActionEnumeration.printIntoConsole) Then
                            itemToWrite = False
                        Else
                            Select Case _SaveMode
                                Case TrackRuntimeModeEnum.neverTrace : itemToWrite = False
                                Case TrackRuntimeModeEnum.trackAll : itemToWrite = True
                                Case TrackRuntimeModeEnum.trackOnlyBootstrapAndError : itemToWrite = (item.action = ActionEnumeration.exception) Or item.duringBootstrap
                            End Select
                        End If

                        If itemToWrite Then
                            _IO.addNewAction(item)
                        End If

                        _DataCache.RemoveAt(i)
                    Else
                        i += 1
                    End If
                Loop

                _ToFlushCache = False

                Return _IO.writeToFile()
            Catch ex As Exception
                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to add a new data into cache
        ''' </summary>
        ''' <returns></returns>
        Public Function addNewDataCache(ByRef item As SingleActionApplication) As Boolean
            Try
                If _ToProcessDataCache Then
                    Do While _ToProcessInQueue
                        Threading.Thread.Sleep(1)
                    Loop

                    _InQueue.Add(item)
                Else
                    _DataCache.Add(item)
                End If

                flushCache()
            Catch ex As Exception
            End Try

            Return True
        End Function

        ''' <summary>
        ''' This method provide to get a data from an internal list
        ''' </summary>
        ''' <param name="start"></param>
        ''' <returns></returns>
        Public Function getDataFrom(ByVal consoleMode As Boolean, Optional ByVal start As Double = 0) As List(Of SingleActionApplication)
            Dim newList As New List(Of SingleActionApplication)
            Dim returnList As Boolean = False

            Try
                _ToProcessDataCache = True

                Do While _ToFlushCache : Threading.Thread.Sleep(1) : Loop

                For Each item In _DataCache
                    If (item.instant >= start) Then
                        If consoleMode Then
                            returnList = (item.action = ActionEnumeration.exception) Or (item.action = ActionEnumeration.printIntoConsole)
                        Else
                            returnList = True
                        End If

                        If returnList Then
                            newList.Add(item)
                        End If
                    End If
                Next

                _ToFlushCache = True

                flushCache(True)

                _ToProcessInQueue = True

                Do While _ToFlushCache : Threading.Thread.Sleep(1) : Loop

                Do While (_InQueue.Count > 0)
                    _DataCache.Add(_InQueue(0))

                    _InQueue.RemoveAt(0)
                Loop

            Catch ex As Exception
            Finally
                _ToProcessInQueue = False
                _ToProcessDataCache = False
            End Try

            Return newList
        End Function

        ''' <summary>
        ''' This method provide to change a new settings
        ''' </summary>
        ''' <param name="value"></param>
        ''' <returns></returns>
        Public Function changeSettings(ByVal value As TrackConfiguration) As Boolean
            _SaveMode = value.saveMode

            Return _IO.changeSettings(value)
        End Function

        ''' <summary>
        ''' This method provide to notify a change bootstrap complete mode
        ''' </summary>
        ''' <returns></returns>
        Public Function changeInBootStrapComplete() As Boolean
            _InBootstrapMode = False

            Return _IO.changeInBootStrapComplete()
        End Function

        ''' <summary>
        ''' This method provide to force a write file
        ''' </summary>
        ''' <returns></returns>
        Public Function writeCacheToLogFile() As Boolean
            If flushCache(True) Then
                Return _IO.writeCacheToLogFile()
            End If

            Return False
        End Function


    End Class

End Namespace
