Option Compare Text
Option Explicit On



Public Class Main

    Private _NoCheck As Boolean = False
    Private _InError As Boolean = True

    Private _PrintWallet As New PrintWalletCreatedEngine

    Private _PrintAddress As Boolean = False
    Private _FirstPrint As Boolean = True



    Private Sub printButton(ByVal sender As Object, ByVal e As EventArgs)

        If pDialogMain.ShowDialog() = Windows.Forms.DialogResult.OK Then

            ppdMain.PrintPreviewControl.Document.Print()

        End If

    End Sub

    Private Sub createNewButton_Click(sender As Object, e As EventArgs) Handles createNewButton.Click

        Try

            _NoCheck = True

            With CHCProtocol.AreaWallet.Support.WalletAddressEngine.createNew()

                privateKey.Text = .official.privateKey
                publicAddress.Text = .official.publicAddress
                privateKeyInternal.Text = .raw.privateKey
                publicAddressInternal.Text = .raw.publicAddress

            End With

            With CHCProtocol.AreaWallet.Support.WalletAddressEngine.createNew(privateKey.Text)

                If privateKeyInternal.Text <> .raw.privateKey Then

                    Debug.Print(.raw.privateKey)

                End If

            End With

            _InError = False

            manageAdvanceButton()

        Catch ex As Exception

        End Try

        _NoCheck = False

    End Sub

    Private Sub manageAdvanceButton()

        paperWalletButton.Enabled = Not _InError
        paperAddress.Enabled = Not _InError
        downloadWalletButton.Enabled = Not _InError

    End Sub

    Private Function calculateCharRemain(ByVal textValue As String, ByVal numCharMax As Integer) As String

        Return "(" & textValue.Length.ToString.Trim() & " / " & numCharMax.ToString.Trim() & ")"

    End Function

    Private Sub resizeCharCounter(ByRef objetCounter As Label, ByRef objectText As TextBox)

        objetCounter.Left = (objectText.Left + objectText.Width) - objetCounter.Width

    End Sub

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        charCounterPrivateAddress.Text = calculateCharRemain(privateKey.Text, CHCProtocol.AreaWallet.Support.WalletAddressEngine.numCharMaxFormatPrivateKey)

        resizeCharCounter(charCounterPrivateAddress, privateKey)

        privateKey.MaxLength = CHCProtocol.AreaWallet.Support.WalletAddressEngine.numCharMaxFormatPrivateKey

        manageAdvanceButton()

    End Sub

    Private Sub sbShowQrCode(ByVal Code As String)

        Dim generateBarcode As ZXing.IBarcodeWriter = New ZXing.BarcodeWriter() With {.Format = ZXing.BarcodeFormat.QR_CODE}

        qrCodePanel.BringToFront()

        qrCodePanel.Visible = True
        qrCodeImage.Visible = True
        closeUserButton.Visible = True

        createNewButton.Enabled = False

        qrCodeImage.Image = generateBarcode.Write(Code)

    End Sub

    Private Sub qrPublicAddressButton_Click(sender As Object, e As EventArgs) Handles qrPublicAddressButton.Click

        sbShowQrCode(publicAddress.Text)

    End Sub

    Private Sub closeUserButton_Click(sender As Object, e As EventArgs) Handles closeUserButton.Click

        qrCodePanel.Visible = False
        createNewButton.Enabled = True

    End Sub

    Private Sub publicAddress_TextChanged(sender As Object, e As EventArgs) Handles publicAddress.TextChanged

        qrPublicAddressButton.Enabled = (publicAddress.Text.Trim.Length > 0)
        copyPublicAddress.Enabled = qrPublicAddressButton.Enabled

    End Sub

    Private Sub qrPrivateAddressButton_Click(sender As Object, e As EventArgs) Handles qrPrivateAddressButton.Click

        sbShowQrCode(privateKey.Text)

    End Sub

    Private Function validatePrivateKeyFormat() As Boolean

        If Not CHCProtocol.AreaWallet.Support.WalletAddressEngine.SingleWallet.startAllowed(privateKey.Text) Then

            publicAddress.Text = "ERROR START PRIVATE KEY MUST BEGIN WITH " & CHCProtocol.AreaWallet.Support.WalletAddressEngine.basePvt
            publicAddress.ForeColor = Color.Red

            Return False

        End If

        If Not CHCProtocol.AreaWallet.Support.WalletAddressEngine.SingleWallet.endAllowed(privateKey.Text) Then

            publicAddress.Text = "ERROR END PRIVATE KEY MUST COMPLETE WITH " & CHCProtocol.AreaWallet.Support.WalletAddressEngine.closeBasePvt
            publicAddress.ForeColor = Color.Red

            Return False

        End If

        publicAddress.ForeColor = Color.DarkBlue

        Return True

    End Function

    Private Sub privateKey_TextChanged(sender As Object, e As EventArgs) Handles privateKey.TextChanged

        qrPrivateAddressButton.Enabled = (privateKey.Text.Trim.Length > 0)
        copyPrivateKEY.Enabled = qrPrivateAddressButton.Enabled

        charCounterPrivateAddress.Text = calculateCharRemain(privateKey.Text, CHCProtocol.AreaWallet.Support.WalletAddressEngine.numCharMaxFormatPrivateKey)

        resizeCharCounter(charCounterPrivateAddress, privateKey)

        If _NoCheck Then Return

        If (privateKey.Text.Length = 0) Then

            publicAddress.Text = ""
            publicAddressInternal.Text = ""
            privateKeyInternal.Text = ""

            _InError = False

            manageAdvanceButton()

            Return

        End If

        If validatePrivateKeyFormat() Then

            With CHCProtocol.AreaWallet.Support.WalletAddressEngine.createNew(privateKey.Text)

                privateKeyInternal.Text = .raw.privateKey
                publicAddressInternal.Text = .raw.publicAddress
                publicAddress.Text = .official.publicAddress

            End With

            _InError = False

        Else

            privateKeyInternal.Text = ""
            publicAddressInternal.Text = ""
            publicAddress.Text = ""

            _InError = True

        End If

        manageAdvanceButton()

    End Sub

    Private Sub copyPublicAddress_Click(sender As Object, e As EventArgs) Handles copyPublicAddress.Click

        Clipboard.SetText(publicAddress.Text)

    End Sub

    Private Sub Main_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged

        resizeCharCounter(charCounterPrivateAddress, privateKey)

    End Sub

    Private Sub privateKey_KeyDown(sender As Object, e As KeyEventArgs) Handles privateKey.KeyDown

        If _NoCheck Then Return

        Dim value As String = ""

        If (e.KeyValue = 8) Or (e.KeyValue = 16) Or (e.KeyValue = 18) Or (e.KeyValue = 17) Or (e.KeyValue = 39) Then Return

        Select Case e.KeyValue
            Case 50 : If e.Shift Then e.SuppressKeyPress = True Else value = "2"
            Case 188 : If e.Shift Then value = ";" Else value = ","
            Case 189 : If e.Shift Then value = "_" Else value = "-"
            Case 190 : If e.Shift Then value = ":" Else value = "."
            Case 192 : If e.Alt Then value = "@" Else e.SuppressKeyPress = True
            Case 219 : If e.Shift Then value = "?" Else e.SuppressKeyPress = True
            Case 220 : If e.Shift Then e.SuppressKeyPress = True Else value = "\"
            Case 222 : If e.Alt Then value = "#" Else e.SuppressKeyPress = True
            Case 186 : If e.Alt Then value = "[" Else e.SuppressKeyPress = True
            Case 187 : If e.Alt Then value = "]" Else e.SuppressKeyPress = True
            Case 111 : value = "/"
            Case 96 : value = "0"
            Case 106 : value = "*"
            Case 109 : value = "-"
            Case 107 : value = "+"
            Case Else : value = Chr(e.KeyValue)

        End Select

        If Not CHCProtocol.AreaWallet.Support.WalletAddressEngine.charAllowed(value) Then

            e.SuppressKeyPress = True

        End If

    End Sub

    Private Sub copyPrivateKEY_Click(sender As Object, e As EventArgs) Handles copyPrivateKEY.Click
        Clipboard.SetText(privateKey.Text)
    End Sub

    Private Sub loadWalletFileButton_Click(sender As Object, e As EventArgs) Handles loadWalletFileButton.Click

        Try

            Dim privateRaw As String = ""
            Dim privateNumber As New Numerics.BigInteger

            openFileDialog.FileName = ""

            If (openFileDialog.ShowDialog() = DialogResult.OK) Then

                privateRaw = CHCCommonLibrary.CHCEngines.Common.Encryption.AES.decrypt(IO.File.ReadAllText(openFileDialog.FileName), securityKey())

                If Numerics.BigInteger.TryParse(privateRaw, privateNumber) Then

                    privateKeyInternal.Text = privateRaw

                    With CHCProtocol.AreaWallet.Support.WalletAddressEngine.createNew(privateRaw, True)

                        publicAddressInternal.Text = .raw.publicAddress
                        privateKey.Text = .official.privateKey
                        publicAddress.Text = .official.publicAddress

                    End With

                    MessageBox.Show("Wallet Address load successfully", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Else

                    MessageBox.Show("File corrupt", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                End If

            End If

        Catch ex As Exception

            MessageBox.Show("An error occurrent during loadWalletFileButton_Click " & Err.Description, "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Function securityKey() As String

        Try

            Dim tmp As New RequestPassword

            If (tmp.ShowDialog() = DialogResult.OK) Then

                Return tmp.PasswordKEY

            End If

        Catch ex As Exception

        End Try

        Return ""

    End Function

    Private Sub downloadWalletButton_Click(sender As Object, e As EventArgs) Handles downloadWalletButton.Click

        Try

            saveFileDialog.FileName = ""

            If (saveFileDialog.ShowDialog() = DialogResult.OK) Then

                Dim cryptoRaw As String = ""

                cryptoRaw = CHCCommonLibrary.CHCEngines.Common.Encryption.AES.encrypt(privateKeyInternal.Text, securityKey())

                IO.File.WriteAllText(saveFileDialog.FileName, cryptoRaw)

                MessageBox.Show("Wallet Address successfully stored", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

        Catch ex As Exception

            MessageBox.Show("An error occurrent during downloadWalletButton_Click " & Err.Description, "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub createWalletFromSeed_Click(sender As Object, e As EventArgs) Handles createWalletFromSeed.Click

        Try

            _NoCheck = True

            With CHCProtocol.AreaWallet.Support.WalletAddressEngine.createNew(seedValue.Text, False)

                privateKey.Text = .official.privateKey
                publicAddress.Text = .official.publicAddress
                privateKeyInternal.Text = .raw.privateKey
                publicAddressInternal.Text = .raw.publicAddress

            End With

            _InError = False

            manageAdvanceButton()

        Catch ex As Exception

        End Try

        _NoCheck = False

    End Sub

    Private Sub seedValue_TextChanged(sender As Object, e As EventArgs) Handles seedValue.TextChanged

        createWalletFromSeed.Enabled = (seedValue.Text.ToString.Trim.Length() > 0)

    End Sub

    Private Sub paperWalletButton_Click(sender As Object, e As EventArgs) Handles paperWalletButton.Click

        _PrintAddress = False

        ppdMain.WindowState = FormWindowState.Maximized

        ppdMain.ShowDialog(Me)

    End Sub

    Private Sub pdMain_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles pdMain.PrintPage

        Try

            Dim generateBarcode As ZXing.IBarcodeWriter = New ZXing.BarcodeWriter() With {.Format = ZXing.BarcodeFormat.QR_CODE}

            With _PrintWallet

                .seed = seedValue.Text
                .publicAddress = publicAddress.Text

                If Not _PrintAddress Then

                    .privateKey = privateKey.Text
                    .qrCodePrivate = generateBarcode.Write(privateKey.Text)

                Else

                    .privateKey = ""

                End If

                .qrCodePublic = generateBarcode.Write(publicAddress.Text)

                .WritePage(1, e)

            End With

        Catch ex As Exception

        End Try

    End Sub

    Private Sub ppdMain_Load(sender As Object, e As EventArgs) Handles ppdMain.Load

    End Sub

    Private Sub ppdMain_Shown(sender As Object, e As EventArgs) Handles ppdMain.Shown

        If _FirstPrint Then

            Dim tsTmp As System.Windows.Forms.ToolStrip
            Dim tsPrint As System.Windows.Forms.ToolStripItem

            tsTmp = DirectCast(ppdMain.Controls("toolStrip1"), ToolStrip)

            tsTmp.Items(0).Visible = False

            tsPrint = tsTmp.Items.Add(tsTmp.Items(0).Image)

            AddHandler tsPrint.Click, AddressOf printButton

        End If

        _FirstPrint = False

    End Sub

    Private Sub paperAddress_Click(sender As Object, e As EventArgs) Handles paperAddress.Click

        _PrintAddress = True

        ppdMain.WindowState = FormWindowState.Maximized

        ppdMain.ShowDialog(Me)

    End Sub

    Private Sub testSignature_Click(sender As Object, e As EventArgs) Handles testSignature.Click

        Dim signature As String

        signature = CHCEngine.Encryption.Base58Signature.getSignature(privateKeyInternal.Text, "GSDKLT3W89JFRW3E9W389R3UWR93WJU")

        If CHCEngine.Encryption.Base58Signature.verifySignature("GSDKLT3W89JFRW3E9W389R3UWR93WJU", publicAddressInternal.Text, signature) Then

            MessageBox.Show("Signature corrent", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Else

            MessageBox.Show("Signature wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End If

    End Sub


End Class
