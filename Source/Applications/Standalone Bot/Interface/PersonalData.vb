Option Compare Text
Option Explicit On


Public Class PersonalData

    Private Sub confirmButton_Click(sender As Object, e As EventArgs) Handles confirmButton.Click
        If (workSpaceNameValue.ToString.Trim.Length > 0) Then
            If (workSpaceNameValue.Text.ToLower.CompareTo("default") <> 0) Then
                AreaState.Common.nameArea = workSpaceNameValue.Text
            End If
        End If

        With AreaState.defaultGenericAccount
            .exchange = AreaCommon.Models.Bot.BotUserAccountModel.ExchangeEnumeration.coinbasePro
            .APIKey = APIKeyValue.Text
            .passphrase = passphraseValue.Text
            .secret = secretValue.Text
            .apiURL = apiURLValue.Text
        End With

        If IsNumeric(baseFundValue.Text) Then
            If (AreaState.accounts.Count = 1) Then
                AreaState.accounts.Remove("USDT".ToLower())

                AreaState.addIntoAccount("USDT".ToLower(), Val(baseFundValue.Text))
            End If
        End If

        DialogResult = DialogResult.OK
    End Sub

    Private Sub PersonalData_Load(sender As Object, e As EventArgs) Handles Me.Load
        If (AreaState.Common.nameArea.ToLower.CompareTo("default") <> 0) Then
            workSpaceNameValue.Text = AreaState.Common.nameArea
        End If

        With AreaState.defaultGenericAccount
            APIKeyValue.Text = .APIKey
            passphraseValue.Text = .passphrase
            secretValue.Text = .secret
            apiURLValue.Text = .apiURL
        End With

        If (AreaState.accounts.Count = 1) Then
            baseFundValue.Text = AreaState.accounts("USDT".ToLower()).amount
        End If
    End Sub

End Class