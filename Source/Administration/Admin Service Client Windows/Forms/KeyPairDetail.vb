Option Compare Text
Option Explicit On


Public Class _KeyPairDetail

    Public Property pathData() As String
        Get
            Return walletDetail.pathData
        End Get
        Set(value As String)
            walletDetail.pathData = value
        End Set
    End Property

    Public Property uuid() As String
        Get
            Return walletDetail.uuid
        End Get
        Set(value As String)
            walletDetail.uuid = value
        End Set
    End Property

    Private Sub walletDetail_CloseMe() Handles walletDetail.CloseMe
        DialogResult = DialogResult.OK
    End Sub

End Class