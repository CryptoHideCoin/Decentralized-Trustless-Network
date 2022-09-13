Option Compare Text
Option Explicit On


Public Class PersonalData

    Private Property oldValueVirtual As Boolean = False

    Public Property changeMode As Boolean



    Private Sub confirmButton_Click(sender As Object, e As EventArgs) Handles confirmButton.Click
        AreaState.Common.defaultUserDataAccount.tenantName = workSpaceNameValue.Text

        With AreaState.defaultUserDataAccount.exchangeAccess
            .exchange = AreaCommon.Models.User.UserDataPersonalModel.ExchangeCredentialUserAccess.ExchangeEnumeration.coinbasePro
            .APIKey = APIKeyValue.Text
            .passphrase = passphraseValue.Text
            .secret = secretValue.Text
            .apiURL = apiURLValue.Text
        End With

        AreaState.defaultUserDataAccount.useVirtualAccount = useVirtualAccount.Checked

        changeMode = (AreaState.defaultUserDataAccount.useVirtualAccount <> oldValueVirtual)

        If changeMode Then
            AreaState.accounts = New Dictionary(Of String, AreaCommon.Models.Account.AccountModel)
            AreaState.summary = New AreaCommon.Models.Account.SummaryModel
        End If

        If IsNumeric(baseFundValue.Text) Then
            AreaState.defaultUserDataAccount.initialBaseFund = baseFundValue.Text
            AreaState.defaultUserDataAccount.initialBaseFundCurrencyKey = currencyBaseFundValue.Text

            If (AreaState.accounts.Count = 1) Then
                AreaState.accounts.Remove("USDT".ToLower())
            End If

            If (AreaState.accounts.Count = 0) Then
                AreaState.addIntoAccount("USDT", Val(baseFundValue.Text), False)
            End If
        Else
            AreaState.defaultUserDataAccount.initialBaseFund = 0
        End If

        DialogResult = DialogResult.OK

        AreaCommon.Engine.IO.updatePersonaData()
    End Sub

    Private Sub PersonalData_Load(sender As Object, e As EventArgs) Handles Me.Load
        workSpaceNameValue.Text = AreaState.Common.defaultUserDataAccount.tenantName

        workSpaceNameValue.Enabled = AreaCommon.Engine.IO.newTenant

        With AreaState.defaultUserDataAccount.exchangeAccess
            APIKeyValue.Text = .APIKey
            passphraseValue.Text = .passphrase
            secretValue.Text = .secret
            apiURLValue.Text = .apiURL
        End With

        useVirtualAccount.Checked = AreaState.defaultUserDataAccount.useVirtualAccount

        oldValueVirtual = AreaState.defaultUserDataAccount.useVirtualAccount

        If (AreaState.accounts.Count = 1) Then
            baseFundValue.Text = AreaState.accounts("USDT".ToLower()).amount
        End If
    End Sub

    Private Sub useVirtualAccount_CheckedChanged(sender As Object, e As EventArgs) Handles useVirtualAccount.CheckedChanged
        baseFundLabel.Enabled = useVirtualAccount.Checked
        baseFundValue.Enabled = useVirtualAccount.Checked

        If Not useVirtualAccount.Checked Then
            baseFundValue.Text = "---"
        End If
    End Sub

End Class