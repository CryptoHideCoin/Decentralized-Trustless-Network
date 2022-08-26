Option Compare Text
Option Explicit On


Public Class PersonalData

    Private Sub confirmButton_Click(sender As Object, e As EventArgs) Handles confirmButton.Click
        AreaState.Common.defaultUserDataAccount.tenantName = workSpaceNameValue.Text

        With AreaState.defaultUserDataAccount.exchangeAccess
            .exchange = AreaCommon.Models.User.UserDataPersonalModel.ExchangeCredentialUserAccess.ExchangeEnumeration.coinbasePro
            .APIKey = APIKeyValue.Text
            .passphrase = passphraseValue.Text
            .secret = secretValue.Text
            .apiURL = apiURLValue.Text
        End With

        If IsNumeric(baseFundValue.Text) Then
            AreaState.defaultUserDataAccount.initialBaseFund = baseFundValue.Text
            AreaState.defaultUserDataAccount.initialBaseFundCurrencyKey = currencyBaseFundValue.Text

            If (AreaState.accounts.Count = 1) Then
                AreaState.accounts.Remove("USDT".ToLower())

                AreaState.addIntoAccount("USDT", Val(baseFundValue.Text))
            End If
        End If

        DialogResult = DialogResult.OK

        AreaEngine.IO.updatePersonaData()
    End Sub

    Private Sub PersonalData_Load(sender As Object, e As EventArgs) Handles Me.Load
        workSpaceNameValue.Text = AreaState.Common.defaultUserDataAccount.tenantName

        workSpaceNameValue.Enabled = AreaEngine.IO.newTenant

        With AreaState.defaultUserDataAccount.exchangeAccess
            APIKeyValue.Text = .APIKey
            passphraseValue.Text = .passphrase
            secretValue.Text = .secret
            apiURLValue.Text = .apiURL
        End With

        If (AreaState.accounts.Count = 1) Then
            baseFundValue.Text = AreaState.accounts("USDT".ToLower()).amount
        End If
    End Sub

    Private Sub useVirtualAccount_CheckedChanged(sender As Object, e As EventArgs) Handles useVirtualAccount.CheckedChanged
        baseFundLabel.Enabled = useVirtualAccount.Checked
        baseFundValue.Enabled = useVirtualAccount.Checked
    End Sub

End Class