Option Compare Text
Option Explicit On

' ****************************************
' File: Wallet Key Private
' Release Engine: 1.0 
' 
' Date last successfully test: 03/10/2021
' ****************************************









Public Class WalletKeyPrivate

    Public Event GetWalletID(ByRef value As String)
    Public Shadows Event TextChanged()


    ''' <summary>
    ''' This property get/let the Value
    ''' </summary>
    ''' <returns></returns>
    Public Property value As String
        Get
            Return privateKeyValue.Text
        End Get
        Set(key As String)
            privateKeyValue.Text = key
        End Set
    End Property
    ''' <summary>
    ''' This property get/let if the Keystore is enabled
    ''' </summary>
    ''' <returns></returns>
    Public Property keyStoreEnabled() As Boolean
        Get
            Return keyStoreManagerButton.Enabled
        End Get
        Set(value As Boolean)
            keyStoreManagerButton.Enabled = value
        End Set
    End Property

    ''' <summary>
    ''' This method provide to resize a control
    ''' </summary>
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

    ''' <summary>
    ''' This event's method manage a click from KeyStore manager button
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub keyStoreManagerButton_Click(sender As Object, e As EventArgs) Handles keyStoreManagerButton.Click
        Dim key As String = ""

        RaiseEvent GetWalletID(key)

        privateKeyValue.Text = key
    End Sub
    ''' <summary>
    ''' This event's method manage a resize Wallet Key Private
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub WalletKeyPrivate_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        resizeControl()
    End Sub
    ''' <summary>
    ''' This event's method manage a size changed from a Wallet Key Private
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub WalletKeyPrivate_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        resizeControl()
    End Sub
    ''' <summary>
    ''' This event's method manage a paint from a Wallet Key Private
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub WalletKeyPrivate_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        resizeControl()
    End Sub
    ''' <summary>
    ''' This event's method manage a Text Changed from a PrivateKeyValue
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub privateKeyValue_TextChanged(sender As Object, e As EventArgs) Handles privateKeyValue.TextChanged
        RaiseEvent TextChanged()
    End Sub

End Class
