Option Compare Text
Option Explicit On





Namespace AreaEngine.Miscellaneous



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
            Return New DateTime(1970, 1, 1, 0, 0, 0, 0).AddMilliseconds(value)
        End Function


        Public Function timestampFromDateTime(Optional ByVal value As DateTime = Nothing) As Double
            If (value = DateTime.MinValue) Then
                Return (Now - New DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalMilliseconds
            Else
                Return (value - New DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalMilliseconds
            End If
        End Function


    End Module



End Namespace
