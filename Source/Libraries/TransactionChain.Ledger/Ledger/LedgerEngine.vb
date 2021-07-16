Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.Encryption





Namespace AreaLedger

    Public Class LedgerEngine

        Public Class SingleRecordLedger

            Public Property id As Integer = 1
            Public Property approvedDate As Double = 0
            Public Property actionCode As String = ""
            Public Property requester As String = ""
            Public Property detailInformation As String = ""
            Public Property requestHash As String = ""
            Public Property approvedHash As String = ""
            Public Property consensusHash As String = ""
            Public Property currentHash As String = ""
            Public Property progressiveHash As String = ""


            Public Function toMemoryFromFile(ByVal value As String) As Boolean
                Try
                    Dim elements = value.Split("|")

                    If (UBound(elements) = 7) Then

                        If IsNumeric(elements(0)) Then
                            If Not Integer.TryParse(elements(0), id) Then
                                Return False
                            End If
                        Else
                            Return False
                        End If

                        If IsNumeric(elements(1)) Then
                            If Not Double.TryParse(elements(1), approvedDate) Then
                                Return False
                            End If
                        Else
                            Return False
                        End If

                        actionCode = elements(2)
                        requester = elements(3)
                        detailInformation = elements(4)
                        requestHash = elements(5)
                        approvedHash = elements(6)
                        consensusHash = elements(7)
                        currentHash = elements(8)
                        progressiveHash = elements(9)

                        Return True
                    Else
                        Return False
                    End If
                Catch ex As Exception
                    Return False
                End Try
            End Function

            Public Function toStringToFile(Optional ByVal separator As String = "|", Optional limited As Boolean = False) As String
                Dim tmp As String = ""

                tmp += id.ToString() & separator
                tmp += approvedDate.ToString() & separator
                tmp += actionCode & separator
                tmp += requester & separator
                tmp += detailInformation & separator
                tmp += requestHash & separator
                tmp += approvedHash & separator
                tmp += consensusHash & separator

                If Not limited Then
                    tmp += currentHash & separator
                    tmp += progressiveHash
                End If

                Return tmp
            End Function

            Public Overrides Function toString() As String
                Return toStringToFile("", True)
            End Function

            Public Function getHash() As String
                Return HashSHA.generateSHA256(Me.toString())
            End Function

        End Class

        Public Property currentRecord As New SingleRecordLedger

        Private _NewIdTransaction As Integer = 1
        Private _CurrentIdBlock As Integer = 0
        Private _CurrentIdVolume As Byte = 0
        Private _BasePath As String = ""
        Private _CompleteFileName As String = ""
        Private _CurrentTotalHash As String = ""
        Private _CreationLedgerDate As Double = 0

        Private _NextBlockCloseAtTime As DateTime



        Private Function createNextCloseAtTime() As DateTime
            Dim dateCreation As Date = CHCCommonLibrary.AreaEngine.Miscellaneous.dateTimeFromTimestamp(_CreationLedgerDate)
            Dim currentYear As Short = Now.ToUniversalTime.Year
            Dim currentMonth As Byte = Now.ToUniversalTime.Month
            Dim currentDay As Byte = Now.ToUniversalTime.Day

            Dim currentHour As Byte = dateCreation.Hour
            Dim currentMinute As Byte = dateCreation.Minute
            Dim currentSecond As Byte = dateCreation.Second

            Return New Date(currentYear, currentMonth, currentDay, currentHour, currentMinute, currentSecond)
        End Function

        Public ReadOnly Property BlockComplete() As Boolean
            Get
                Return (Now.Subtract(_NextBlockCloseAtTime).TotalSeconds > 0)
            End Get
        End Property

        Public Sub completeRecord()
            currentRecord.id = _NewIdTransaction
            currentRecord.currentHash = currentRecord.getHash
            currentRecord.progressiveHash = HashSHA.generateSHA256(currentRecord.currentHash & _CurrentTotalHash)
        End Sub

        Public Function saveAndClean() As Boolean
            Try
                currentRecord.currentHash = currentRecord.getHash()

                Using fileData As IO.StreamWriter = IO.File.AppendText(_CompleteFileName)
                    fileData.WriteLine(currentRecord.toStringToFile())
                End Using

                _NewIdTransaction += 1
                _CurrentTotalHash = currentRecord.progressiveHash

                currentRecord = New SingleRecordLedger

                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function init(ByVal path As String, ByVal creationLedgerDate As Double) As Boolean
            Try
                _BasePath = path

                _CreationLedgerDate = creationLedgerDate
                _NextBlockCloseAtTime = createNextCloseAtTime()

                _CompleteFileName = IO.Path.Combine(path, _CurrentIdBlock.ToString & ".ledger")

                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

    End Class

End Namespace