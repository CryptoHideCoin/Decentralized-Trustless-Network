Option Compare Text
Option Explicit On

' ****************************************
' File: Private Key
' Release Engine: 1.0 
' 
' Date last successfully test: 03/10/2021
' ****************************************










Public Class PrivateKey

    ''' <summary>
    ''' This property get/let the data path
    ''' </summary>
    ''' <returns></returns>
    Public Property dataPath As String = ""
    ''' <summary>
    ''' This property get the value of a Private Key
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property value() As String
        Get
            Return userWalletKeyPrivate.value
        End Get
    End Property


    Private Function verifyInformation() As Boolean
        If (userWalletKeyPrivate.value.Trim().Length = 0) Then
            MessageBox.Show("The private key is missing.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return False
        End If
        If Not CHCProtocolLibrary.AreaWallet.Support.WalletAddressEngine.checkPrivateKeyFormat(userWalletKeyPrivate.value) Then
            MessageBox.Show("The private key format is wrong.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return False
        End If

        Return True
    End Function

    Private Sub confirmButton_Click(sender As Object, e As EventArgs) Handles confirmButton.Click
        If verifyInformation() Then
            DialogResult = DialogResult.OK
        End If
    End Sub

    Private Sub userWalletKeyPrivate_GetWalletID(ByRef value As String) Handles userWalletKeyPrivate.GetWalletID
        Try
            Dim frm As New KeyStoreManager

            frm.dataPath = IO.Path.Combine(dataPath, "Settings")

            If (frm.ShowDialog = DialogResult.OK) Then
                value = frm.addressValue
            End If

            frm.Close()
            frm.Dispose()

            frm = Nothing
        Catch ex As Exception
            MessageBox.Show("Error during a userWalletKeyPrivate_GetWalletID - " & Err.Description, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class