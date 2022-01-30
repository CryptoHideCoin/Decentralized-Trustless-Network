Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.DataFileManagement.XML





Namespace AreaCommon

    ''' <summary>
    ''' This class contain the app settings i/o Application data
    ''' </summary>
    Public Class AppSettings

        Inherits BaseFile(Of SettingsData)



        Public Class SettingsData

            Public Property environmentPath As String = ""

        End Class

    End Class

End Namespace
