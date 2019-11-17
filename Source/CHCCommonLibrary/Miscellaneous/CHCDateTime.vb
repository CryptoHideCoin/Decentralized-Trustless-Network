Option Compare Text
Option Explicit On





Namespace CHCEngines.Miscellaneous



    Public Module SupportDate

        Private _ErrorFormatDate As Boolean





        Public Function atMomentGMT() As String

            Try

                If _ErrorFormatDate Then

                    Return Now.ToUniversalTime().ToString("yyyy-MM-dd") & "T" & Now.ToUniversalTime().ToLongTimeString

                End If

                Return Now.ToUniversalTime().GetDateTimeFormats()(78).ToString()

            Catch ex As Exception

                _ErrorFormatDate = True

                Return Now.ToUniversalTime().ToString("yyyy-MM-dd") & "T" & Now.ToUniversalTime().ToLongTimeString

            End Try

        End Function



        Function dateTimeFromTimestamp(value As Double) As DateTime

            Dim UnixEpoch As New DateTime(1970, 1, 1, 0, 0, 0, 0)

            Return UnixEpoch.AddMilliseconds(value)

        End Function



        Public Function timestampFromDateTime(Optional ByVal value As DateTime = Nothing) As Double

            Dim ts As TimeSpan

            If (value = DateTime.MinValue) Then

                ts = (Now - New DateTime(1970, 1, 1, 0, 0, 0, 0))

            Else

                ts = (value - New DateTime(1970, 1, 1, 0, 0, 0, 0))

            End If

            Return ts.TotalMilliseconds

        End Function



    End Module



End Namespace
