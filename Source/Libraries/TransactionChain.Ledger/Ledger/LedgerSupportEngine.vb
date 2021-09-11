Option Compare Text
Option Explicit On

Imports System.Data.SQLite
Imports CHCCommonLibrary.Support






Namespace AreaLedger

    Public Class LedgerSupportEngine

        Private Property _DBCurrentLedgerConnectionString As String = "Data source = {0};Version=3;"
        Private Property _DBPreviousLedgerConnectionString As String = "Data source = {0};Version=3;"

        Public Property NoUsePrevious As Boolean = False
        Public Property currentIdBlock As Integer = 0
        Public Property currentIdVolume As Byte = 0
        Public Property previousIdBlock As Integer = 0
        Public Property previousIdVolume As Byte = 0
        Public Property identifyBlockChain As String = ""
        Public Property log As LogEngine


        Private Function foundRequestInLedger(ByVal requestHash As String, ByVal currentBlock As Boolean) As Boolean
            Try
                Dim sql As String = ""
                Dim connectionDB As SQLiteConnection
                Dim sqlCommand As SQLiteCommand
                Dim result As Boolean

                log.track("LedgerSupportEngine.foundRequestInLedger", "Begin")

                sql += "SELECT Count(record_id) "
                sql += "FROM blockData "
                sql += "WHERE requestHash = '" & requestHash & "'"

                If currentBlock Then
                    connectionDB = New SQLiteConnection(_DBCurrentLedgerConnectionString)
                Else
                    connectionDB = New SQLiteConnection(_DBPreviousLedgerConnectionString)
                End If

                connectionDB.Open()

                log.track("LedgerSupportEngine.foundRequestInLedger", "Connection Open")

                sqlCommand = New SQLiteCommand(connectionDB)

                sqlCommand.CommandText = sql

                result = (sqlCommand.ExecuteScalar() > 0)

                log.track("LedgerSupportEngine.foundRequestInLedger", "Command executed")

                connectionDB.Close()

                log.track("LedgerSupportEngine.foundRequestInLedger", "Connection Closed")

                Return result
            Catch ex As Exception
                log.track("LedgerSupportEngine.foundRequestInLedger", "Error:" & ex.Message, "error")

                Return False
            End Try
        End Function

        Public Function foundRequestInLedger(ByVal requestHash As String) As Boolean
            If foundRequestInLedger(requestHash, True) Then
                Return True
            ElseIf Not NoUsePrevious Then
                If foundRequestInLedger(requestHash, True) Then
                    Return True
                End If
            End If

            Return False
        End Function

        Public Function init(ByVal currentLedgerPath As String, ByVal previousLedgerPath As String) As Boolean
            Try
                Dim fileName As String

                log.track("LedgerSupportEngine.init", "Begin")

                fileName = CHCCommonLibrary.AreaCommon.Models.General.IdentifyRecordLedger.composeCoordinate(identifyBlockChain, currentIdVolume, currentIdBlock)
                fileName = IO.Path.Combine(currentLedgerPath, fileName & ".db")

                _DBCurrentLedgerConnectionString = String.Format(_DBCurrentLedgerConnectionString, fileName)

                fileName = CHCCommonLibrary.AreaCommon.Models.General.IdentifyRecordLedger.composeCoordinate(identifyBlockChain, previousIdVolume, previousIdBlock)
                fileName = IO.Path.Combine(previousLedgerPath, fileName & ".db")

                _DBPreviousLedgerConnectionString = String.Format(_DBPreviousLedgerConnectionString, fileName)

                If Not NoUsePrevious Then
                    NoUsePrevious = Not IO.File.Exists(fileName)
                End If

                log.track("LedgerSupportEngine.init", "Complete")
            Catch ex As Exception
                log.track("LedgerSupportEngine.init", "Error:" & ex.Message, "error")
            End Try

            Return False
        End Function

    End Class

End Namespace