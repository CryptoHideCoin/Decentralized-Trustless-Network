Option Compare Text
Option Explicit On


Namespace AreaCommon.Models.Account

    Public Class AccountBaseModel

        Public Property id As String = ""
        Public Property amount As Double = 0

    End Class

    Public Class AccountBaseForSerializationModel

        Inherits AccountBaseModel

        Public Property key As String = ""

    End Class

    Public Class AccountModel

        Inherits AccountBaseModel

        Public Property available As Double = 0
        Public Property change As Double = 0
        Public Property valueUSDT As Double = 0

    End Class

    Public Class AccountsModel

        Public wallet As New List(Of AccountBaseForSerializationModel)

    End Class

End Namespace