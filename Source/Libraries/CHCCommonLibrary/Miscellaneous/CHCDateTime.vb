Option Compare Text
Option Explicit On

' ****************************************
' Engine: Date time support
' Release Engine: 1.0 
' 
' Date last successfully test: 02/10/2021
' ****************************************








Namespace AreaEngine.Miscellaneous

    ''' <summary>
    ''' This module contain a static method of a date (timestamp or GMT)
    ''' </summary>
    Public Module SupportDate

        Private _ErrorFormatDate As Boolean


        ''' <summary>
        ''' This method provide to compose a Time structure into GMT format
        ''' </summary>
        ''' <param name="value"></param>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Function formatDateTimeGMT(ByVal value As DateTime) As String
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

        ''' <summary>
        ''' This method provide to compose a Time structure String to GMT format
        ''' </summary>
        ''' <param name="value"></param>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Function formatDateTimeGMT(ByVal value As String) As String
            Return value.Replace("/", "-").Replace(" ", "T") & "Z"
        End Function

        ''' <summary>
        ''' This method provides to compose a time structure with a current time into GMT format
        ''' </summary>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Function atMomentGMT() As String
            Return formatDateTimeGMT(Now)
        End Function

        ''' <summary>
        ''' This method provide to convert a timestamp into DateTime structure
        ''' </summary>
        ''' <param name="value"></param>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Function dateTimeFromTimeStamp(value As Double) As DateTime
            Return New DateTime(1970, 1, 1, 0, 0, 0, 0).AddMilliseconds(value)
        End Function

        ''' <summary>
        ''' This method provide to convert a DateTime into timestamp
        ''' </summary>
        ''' <param name="value"></param>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Function timeStampFromDateTime(Optional ByVal value As DateTime = Nothing) As Double
            If (value = DateTime.MinValue) Then
                Return (DateTime.UtcNow - New DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalMilliseconds
            Else
                Return (value - New DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalMilliseconds
            End If
        End Function

    End Module

End Namespace
