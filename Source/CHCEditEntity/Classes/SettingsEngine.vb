Option Compare Text
Option Explicit On




Public Class SettingsEngine

    Inherits CHCCommonLibrary.CHCEngines.Common.BaseEncryption(Of SettingsData)


    Public Class SettingsData

        Public urlBase As String = "https://localhost:44392/"
        Public apiKey As String = ""
        Public apiPassword As String = ""
        Public adminPublicAddressWallet As String = ""
        Public adminPrivateKey As String = ""

    End Class

End Class
