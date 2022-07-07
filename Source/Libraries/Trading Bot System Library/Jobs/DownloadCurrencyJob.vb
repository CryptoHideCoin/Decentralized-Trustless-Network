Option Compare Text
Option Explicit On


Namespace AreaJob

    ''' <summary>
    ''' This class contain all element to manage the download new currency
    ''' </summary>
    Public Class DownloadCurrencyJob

        Public Property parameter As Integer


        ''' <summary>
        ''' This method provide to run a schedule job
        ''' </summary>
        ''' <returns></returns>
        Public Function run() As Boolean
            Return AreaCommon.state.currenciesDownloadEngine.downloadFromExchange(parameter, AreaCommon.Main.state.exchangesEngine.select(parameter).name, False)
        End Function

    End Class

End Namespace
