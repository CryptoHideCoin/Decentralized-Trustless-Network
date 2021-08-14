Option Compare Text
Option Explicit On





Namespace AreaEngine.Miscellaneous



    Public Module SupportDate

        Private _ErrorFormatDate As Boolean


        Function formatDateTimeGMT(ByVal value As DateTime) As String
            Try
                If _ErrorFormatDate Then
                    Return value.ToUniversalTime().ToString("yyyy-MM-dd") & "T" & value.ToUniversalTime().ToLongTimeString & "Z"
                End If

                Return value.ToUniversalTime().GetDateTimeFormats()(78).ToString() & "Z"
            Catch ex As Exception
                _ErrorFormatDate = True

                Return value.ToUniversalTime().ToString("yyyy-MM-dd") & "T" & value.ToUniversalTime().ToLongTimeString & "Z"
            End Try
        End Function

        Function atMomentGMT() As String
            Return formatDateTimeGMT(Now)
        End Function

        Function dateTimeFromTimestamp(value As Double) As DateTime
            Return New DateTime(1970, 1, 1, 0, 0, 0, 0).AddMilliseconds(value)
        End Function

        Function timestampFromDateTime(Optional ByVal value As DateTime = Nothing) As Double
            If (value = DateTime.MinValue) Then
                Return (Now - New DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalMilliseconds
            Else
                Return (value - New DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalMilliseconds
            End If
        End Function


    End Module



End Namespace
