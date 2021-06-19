Option Compare Text
Option Explicit On


Public Class WalletKeyPrivate

    Public Event GetWalletID(ByRef value As String)
    Public Shadows Event TextChanged()



    Public Property value As String
        Get
            Return privateKeyValue.Text
        End Get
        Set(key As String)
            privateKeyValue.Text = key
        End Set
    End Property

    Public Property keyStoreEnabled() As Boolean
        Get
            Return keyStoreManagerButton.Enabled
        End Get
        Set(value As Boolean)
            keyStoreManagerButton.Enabled = value
        End Set
    End Property


    Private Sub keyStoreManagerButton_Click(sender As Object, e As EventArgs) Handles keyStoreManagerButton.Click
        Dim key As String = ""

        RaiseEvent GetWalletID(key)

        privateKeyValue.Text = key
    End Sub

    Private Sub resizeControl()
        Try
            privateKeyLabel.Left = 0
            privateKeyLabel.Width = 61

            privateKeyValue.Left = 3
            privateKeyValue.Width = Width - 76

            keyStoreManagerButton.Left = Width - 70
            keyStoreManagerButton.Width = 68
        Catch ex As Exception
        End Try
    End Sub

    Private Sub WalletKeyPrivate_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        resizeControl()
    End Sub

    Private Sub WalletKeyPrivate_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        resizeControl()
    End Sub

    Private Sub WalletKeyPrivate_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        resizeControl()
    End Sub

    Private Sub privateKeyValue_TextChanged(sender As Object, e As EventArgs) Handles privateKeyValue.TextChanged
        RaiseEvent TextChanged()
    End Sub

End Class
