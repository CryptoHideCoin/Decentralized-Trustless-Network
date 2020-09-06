Public Class Test

    Private Sub privateKeyValue_TextChanged(sender As Object, e As EventArgs) Handles privateKeyValue.TextChanged

    End Sub

    Private Sub createSignature_Click(sender As Object, e As EventArgs) Handles createSignature.Click

        signatureValue.Text = CHCEngine.Encryption.Base58Signature.getSignature(privateKeyValue.Text, messageValue.Text)

    End Sub

    Private Sub testSignature_Click(sender As Object, e As EventArgs) Handles testSignature.Click

        'Dim privateKey As String = "12626425284864278162202581626733466368365172003279154818513730163414056220634808175240377745093638775723650960236132281382465844310373676679136515591982314638340512635762073425366409623435095464790573542552416374080573617415647707706500642451483001702531625048053541476262422164628228345872647739272162751463210578515438432838245539562815272844067524231354116430743528591220602656677350382754730903332049240064276921388175243961085264094843187902414337645148533303506156644935353226812127644234722958"
        'Dim messageEx As String = "GSDKLT3W89JFRW3E9W389R3UWR93WJU"
        'Dim signatureEx As String = CHCEngine.Encryption.Base58Signature.getSignature(privateKey, messageEx)

        'If messageEx.CompareTo(messageValue.Text.ToString()) = 0 Then

        '    MessageBox.Show("Messaggio uguale")

        'End If

        'If walletPubblicAddressValue.Text.ToString.CompareTo("kBpZucTJ27cWjZRBmUEHyHsVPvQvWtdSJf2pebcJkJMBq1HhcpW9G7MTqNgKVBFWxGFoTmSdPhR33gy6KpCC84K") = 0 Then

        '    MessageBox.Show("Wallet uguale")

        'End If

        'If (signatureEx.CompareTo(signatureValue.Text.ToString) = 0) Then

        '    MessageBox.Show("Signature uguale")

        'End If

        'If CHCEngine.Encryption.Base58Signature.verifySignature(messageEx, "kBpZucTJ27cWjZRBmUEHyHsVPvQvWtdSJf2pebcJkJMBq1HhcpW9G7MTqNgKVBFWxGFoTmSdPhR33gy6KpCC84K", signatureEx) Then

        '    MessageBox.Show("Ciao")

        'Else

        '    MessageBox.Show("Miao")

        'End If

        'Return

        If CHCEngine.Encryption.Base58Signature.verifySignature(messageValue.Text, walletPubblicAddressValue.Text, signatureValue.Text) Then

            MessageBox.Show("Signature corrent", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Else

            MessageBox.Show("Signature wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End If

    End Sub

    Private Sub createNewWallet_Click(sender As Object, e As EventArgs) Handles createNewWallet.Click

        Dim rndChar As New Random(CInt(Date.Now.Ticks And &HFFFF))
        Dim index As Integer

        For intC As Integer = 0 To 249

            index = rndChar.Next(0, 83)
            privateKeyValue.Text += Strings.Right("0" & index.ToString.Trim(), 2)

        Next

        walletPubblicAddressValue.Text = CHCEngine.Encryption.Base58Signature.getPublicKeyFromPrivateKeyEx(privateKeyValue.Text)

    End Sub


End Class
