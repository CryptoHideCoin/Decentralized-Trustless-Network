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
        Private Property _ToProcessDataCache As Boolean = False
        Private Property _ToProcessInQueue As Boolean = False
        Private Property _ToFlushCache As Boolean = False

        Public Property timeInCache As Double = 2000


        ''' <summary>
        ''' This method provide to transfer this information to engine to write data
        ''' </summary>
        ''' <returns></returns>
        Private Function flushCache() As Boolean
            Try
                Dim limit As Double = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime() - timeInCache
                Dim i As Integer
                Dim item As SingleActionApplication

                _ToFlushCache = True

                i = 0

                Do While (i <= _DataCache.Count - 1)
                    item = _DataCache(i)

                    If (item.instant < limit) Then
                        If _IO.addNewAction(item) Then
                            _DataCache.RemoveAt(i)
                        Else
                            Return False
                        End If
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

                For Each item In _InQueue
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

                _ToProcessInQueue = True

                Do While _ToFlushCache : Threading.Thread.Sleep(1) : Loop

                Do While (_InQueue.Count > 0)
                    _DataCache.Add(_InQueue(0))

                    _InQueue.RemoveAt(0)
                Loop

                _ToProcessInQueue = False
                _ToProcessDataCache = False
            Catch ex As Exception
            End Try

            Return newList
        End Function

        ''' <summary>
        ''' This method provide to change a new settings
        ''' </summary>
        ''' <param name="value"></param>
        ''' <returns></returns>
        Public Function changeSettings(ByVal value As TrackConfiguration) As Boolean
            Return _IO.changeSettings(value)
        End Function

        ''' <summary>
        ''' This method provide to notify a change bootstrap complete mode
        ''' </summary>
        ''' <returns></returns>
        Public Function changeInBootStrapComplete() As Boolean
            Return _IO.changeInBootStrapComplete()
        End Function

    End Class

End Namespace
