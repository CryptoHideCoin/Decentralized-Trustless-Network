Option Compare Text
Option Explicit On

Imports System.Drawing.Printing
Imports CHCBasicCryptographyLibrary.AreaEngine
Imports CHCProtocolLibrary.AreaWallet.Support



Public Class CustomizeWalletAddress

    Private _PrintAddress As Boolean = False
    Private _FirstPrint As Boolean = True

    Private _PrintWallet As New PrintWalletCreatedEngine


    Public Property pathData() As String = ""


    Public Event RequestAccessSecurityKey(ByRef value As String, ByRef cancelValue As Boolean)
    Public Event CloseMe()





    Public Property uuid() As String
        Get
            Return UUIDText.Text
        End Get
        Set(value As String)
            UUIDText.Text = value

            If (pathData.Length > 0) Then
                loadData()
            End If
        End Set
    End Property

    Private Sub useProtectionKEYCheckbox_CheckedChanged(sender As Object, e As EventArgs) Handles useProtectionKEYCheckbox.CheckedChanged
        Dim value As Boolean

        value = useProtectionKEYCheckbox.Checked

        If Not value Then
            accessKEYTextBox.Text = ""
            repeatAccessKEYTextBox.Text = ""
        End If

        accessKEYTextBox.Enabled = value
        showCharacterAccessKEYButton.Enabled = value
        repeatAccessKEYLabel.Enabled = value
        repeatAccessKEYTextBox.Enabled = value
        showCharacterRepeatAccessKEYButton.Enabled = value
    End Sub

    Private Sub useAuthorizationKEYCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles useAuthorizationKEYCheckBox.CheckedChanged
        Dim value As Boolean

        value = useAuthorizationKEYCheckBox.Checked

        If Not value Then
            authorizationKEYTextBox.Text = ""
            repeatAuthorizationKeyTextArea.Text = ""
        End If

        authorizationKEYTextBox.Enabled = value
        showCharacterAuthorizationKEYButton.Enabled = value
        repeatAuthorizationKEYLabel.Enabled = value
        repeatAuthorizationKeyTextArea.Enabled = value
        showCharacterRepeatAuthorizationKEYButton.Enabled = value
    End Sub

    Private Sub showCharacterAccessKEYButton_Click(sender As Object, e As EventArgs) Handles showCharacterAccessKEYButton.Click

    End Sub

    Private Sub showCharacterAccessKEYButton_MouseDown(sender As Object, e As MouseEventArgs) Handles showCharacterAccessKEYButton.MouseDown
        accessKEYTextBox.PasswordChar = ""
    End Sub

    Private Sub showCharacterAccessKEYButton_MouseUp(sender As Object, e As MouseEventArgs) Handles showCharacterAccessKEYButton.MouseUp
        accessKEYTextBox.PasswordChar = "*"
    End Sub

    Private Sub showCharacterRepeatAccessKEYButton_Click(sender As Object, e As EventArgs) Handles showCharacterRepeatAccessKEYButton.Click

    End Sub

    Private Sub showCharacterRepeatAccessKEYButton_MouseDown(sender As Object, e As MouseEventArgs) Handles showCharacterRepeatAccessKEYButton.MouseDown
        repeatAccessKEYTextBox.PasswordChar = ""
    End Sub

    Private Sub showCharacterRepeatAccessKEYButton_MouseUp(sender As Object, e As MouseEventArgs) Handles showCharacterRepeatAccessKEYButton.MouseUp
        repeatAccessKEYTextBox.PasswordChar = "*"
    End Sub

    Private Sub showCharacterAuthorizationKEYButton_Click(sender As Object, e As EventArgs) Handles showCharacterAuthorizationKEYButton.Click

    End Sub

    Private Sub showCharacterAuthorizationKEYButton_MouseDown(sender As Object, e As MouseEventArgs) Handles showCharacterAuthorizationKEYButton.MouseDown
        authorizationKEYTextBox.PasswordChar = ""
    End Sub

    Private Sub showCharacterAuthorizationKEYButton_MouseUp(sender As Object, e As MouseEventArgs) Handles showCharacterAuthorizationKEYButton.MouseUp
        authorizationKEYTextBox.PasswordChar = "*"
    End Sub

    Private Sub showCharacterRepeatAuthorizationKEYButton_MouseUp(sender As Object, e As MouseEventArgs) Handles showCharacterRepeatAuthorizationKEYButton.MouseUp
        repeatAuthorizationKeyTextArea.PasswordChar = "*"
    End Sub

    Private Sub showCharacterRepeatAuthorizationKEYButton_MouseDown(sender As Object, e As MouseEventArgs) Handles showCharacterRepeatAuthorizationKEYButton.MouseDown
        repeatAuthorizationKeyTextArea.PasswordChar = ""
    End Sub

    Private Sub accessKEYTextBox_TextChanged(sender As Object, e As EventArgs) Handles accessKEYTextBox.TextChanged
        errorAccessKEYLabel.Visible = (accessKEYTextBox.Text.CompareTo(repeatAccessKEYTextBox.Text) <> 0)
    End Sub

    Private Sub repeatAccessKEYTextBox_TextChanged(sender As Object, e As EventArgs) Handles repeatAccessKEYTextBox.TextChanged
        errorAccessKEYLabel.Visible = (accessKEYTextBox.Text.CompareTo(repeatAccessKEYTextBox.Text) <> 0)
    End Sub

    Private Sub authorizationKEYTextBox_TextChanged(sender As Object, e As EventArgs) Handles authorizationKEYTextBox.TextChanged
        errorAuthorizationKEYLabel.Visible = (authorizationKEYTextBox.Text.CompareTo(repeatAuthorizationKeyTextArea.Text) <> 0)
    End Sub

    Private Sub repeatAuthorizationKeyTextArea_TextChanged(sender As Object, e As EventArgs) Handles repeatAuthorizationKeyTextArea.TextChanged
        errorAuthorizationKEYLabel.Visible = (authorizationKEYTextBox.Text.CompareTo(repeatAuthorizationKeyTextArea.Text) <> 0)
    End Sub

    Private Sub seedValue_TextChanged(sender As Object, e As EventArgs)
        createWalletFromSeedButton.Enabled = (seedValueTextArea.Text.ToString.Trim.Length() > 0)
    End Sub

    Private Sub seedPage_Resize(sender As Object, e As EventArgs) Handles seedPage.Resize

        Return

        Try
            seedValueTextArea.Width = (seedPage.Size.Width - 46)
            seedValueTextArea.Height = (seedPage.Size.Height - 306)
            seedValueTextArea.Visible = True
        Catch ex As Exception
            seedValueTextArea.Visible = False
            createWalletFromSeedButton.Visible = False
        End Try

        Try
            createWalletFromSeedButton.Left = (seedPage.Size.Width - 99)
            createWalletFromSeedButton.Top = (seedPage.Size.Height - 269)
            createWalletFromSeedButton.Visible = True
        Catch ex As Exception
            createWalletFromSeedButton.Visible = False
        End Try

    End Sub

    Private Sub CustomizeWalletButton_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If (walletNameText.Text.Length = 0) Then
            walletNameText.Text = "(no name)"
            UUIDText.Text = (Guid.NewGuid).ToString()
        End If
    End Sub

    Private Sub userPage_Click(sender As Object, e As EventArgs) Handles userPage.Click

    End Sub

    Private Sub userPage_Resize(sender As Object, e As EventArgs) Handles userPage.Resize

        Return

        Try
            userKeyPair.Width = (userPage.Width - 13)
            userKeyPair.Height = (userPage.Height - 13)
            userKeyPair.Visible = True
        Catch ex As Exception
            userKeyPair.Visible = False
        End Try

    End Sub

    Private Sub rawPage_Resize(sender As Object, e As EventArgs) Handles rawPage.Resize

        Return

        Try
            rawKeyPair.Width = rawPage.Width
            rawKeyPair.Height = rawPage.Height
            rawKeyPair.Visible = True
        Catch ex As Exception
            rawKeyPair.Visible = False
        End Try

    End Sub

    Private Sub manageAdvanceButton()

        paperWalletButton.Enabled = Not userKeyPair.inError
        paperAddress.Enabled = Not userKeyPair.inError
        saveAddressButton.Enabled = Not userKeyPair.inError And (pathData.Length > 0)
        testSignature.Enabled = Not userKeyPair.inError

    End Sub

    Private Sub createNewButton_Click(sender As Object, e As EventArgs) Handles createNewButton.Click
        Try
            seedValueTextArea.Text = ""

            With WalletAddressEngine.createNew()

                userKeyPair.noCheck = True
                userKeyPair.privateKey = .official.privateKey
                userKeyPair.publicAddress = .official.publicKey
                userKeyPair.inError = False

                rawKeyPair.noCheck = True
                rawKeyPair.privateKey = .raw.privateKey
                rawKeyPair.publicAddress = .raw.publicKey

            End With

            manageAdvanceButton()

            Me.mainTab.SelectedIndex = 2
        Catch ex As Exception
        End Try

        userKeyPair.noCheck = False
        rawKeyPair.noCheck = False
    End Sub

    Private Sub createWalletFromSeedButton_Click(sender As Object, e As EventArgs) Handles createWalletFromSeedButton.Click
        Try
            With WalletAddressEngine.createNew(seedValueTextArea.Text.Replace(" ", "+"), False)

                userKeyPair.noCheck = True
                userKeyPair.privateKey = .official.privateKey
                userKeyPair.publicAddress = .official.publicKey
                userKeyPair.inError = False

                rawKeyPair.noCheck = True
                rawKeyPair.privateKey = .raw.privateKey
                rawKeyPair.publicAddress = .raw.publicKey

            End With

            manageAdvanceButton()

            Me.mainTab.SelectedIndex = 2
        Catch ex As Exception
        End Try

        userKeyPair.noCheck = False
        rawKeyPair.noCheck = False
    End Sub

    Private Sub seedValueTextArea_TextChanged(sender As Object, e As EventArgs) Handles seedValueTextArea.TextChanged
        createWalletFromSeedButton.Enabled = (seedValueTextArea.Text.Length > 0)
    End Sub

    Private Sub userKeyPair_SynchroButtonEdit(value As Boolean) Handles userKeyPair.SynchroButtonEdit
        rawKeyPair.enableButtonEdit(value)
    End Sub

    Private Sub userKeyPair_SynchroClearField() Handles userKeyPair.SynchroClearField
        rawKeyPair.clearField()
    End Sub

    Private Sub userKeyPair_SynchroOther() Handles userKeyPair.SynchroOther
        manageAdvanceButton()
    End Sub

    Private Sub userKeyPair_SynchroOtherKeyPair(publicKey As String, privateKey As String) Handles userKeyPair.SynchroOtherKeyPair
        rawKeyPair.privateKey = privateKey
        rawKeyPair.publicAddress = publicKey
    End Sub

    Private Function verifyData() As Boolean
        If useProtectionKEYCheckbox.Checked Then
            If (accessKEYTextBox.Text.Length > 0) Then
                If (accessKEYTextBox.Text.CompareTo(repeatAccessKEYTextBox.Text) <> 0) Then
                    MessageBox.Show("Repeat Access Key do not match", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    Return False
                End If
            Else
                MessageBox.Show("Insert the Access Key", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                Return False
            End If
        End If

        If useAuthorizationKEYCheckBox.Checked Then
            If (authorizationKEYTextBox.Text.Length > 0) Then
                If (authorizationKEYTextBox.Text.CompareTo(repeatAuthorizationKeyTextArea.Text) <> 0) Then
                    MessageBox.Show("Repeat Authorization Key do not match", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    Return False
                End If
            Else
                MessageBox.Show("Insert the Authorization Key", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                Return False
            End If
        End If

        If (WalletAddressEngine.extractPrivateKeyRAW(userKeyPair.privateKeyText.Text).Length > 0) Then
            Return True
        Else
            MessageBox.Show("The format of PrivateKey is wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return False
        End If
    End Function

    Private Sub saveData()
        Try
            Dim engine As New WalletAddressDataEngine

            engine.fileName = IO.Path.Combine(Me.pathData, UUID)

            If Not IO.Directory.Exists(engine.fileName) Then
                IO.Directory.CreateDirectory(engine.fileName)
            End If

            engine.fileName = IO.Path.Combine(engine.fileName, "walletAddress.private")

            engine.data.name = walletNameText.Text

            If useProtectionKEYCheckbox.Checked Then
                engine.securityKey = accessKEYTextBox.Text
            Else
                engine.securityKey = ""
            End If

            If useAuthorizationKEYCheckBox.Checked Then
                engine.data.authorizationKey = authorizationKEYTextBox.Text
            Else
                engine.data.authorizationKey = ""
            End If

            engine.data.publicRAWAddress = rawKeyPair.publicKeyText.Text
            engine.data.privateRAWKey = rawKeyPair.privateKeyText.Text
            engine.data.note = noteText.Text

            If Not engine.save() Then
                MessageBox.Show("Problem during save information", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Problem during save information", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub loadData()
        Try
            Dim engine As New WalletAddressDataEngine
            Dim dataLoaded As Boolean = False
            Dim securityValue As String = ""
            Dim abort As Boolean = False

            engine.fileName = IO.Path.Combine(Me.pathData, UUID, "walletAddress.private")

            If Not engine.load() Then
                RaiseEvent RequestAccessSecurityKey(securityValue, abort)

                If Not abort Then
                    engine.securityKey = securityValue

                    dataLoaded = engine.load()
                End If
            Else
                dataLoaded = True
            End If

            If dataLoaded Then
                walletNameText.Text = engine.data.name

                If (securityValue.Length > 0) Then
                    useProtectionKEYCheckbox.Checked = True
                    accessKEYTextBox.Text = securityValue
                    repeatAccessKEYTextBox.Text = securityValue
                End If
                If (engine.data.authorizationKey.Length > 0) Then
                    useAuthorizationKEYCheckBox.Checked = True
                    authorizationKEYTextBox.Text = engine.data.authorizationKey
                    repeatAuthorizationKeyTextArea.Text = engine.data.authorizationKey
                End If

                With WalletAddressEngine.createNew(engine.data.privateRAWKey, True, engine.data.publicRAWAddress)
                    userKeyPair.noCheck = True
                    userKeyPair.privateKeyText.Text = .official.privateKey
                    userKeyPair.publicKeyText.Text = .official.publicKey
                    userKeyPair.noCheck = False
                    rawKeyPair.noCheck = True
                    rawKeyPair.privateKeyText.Text = .raw.privateKey
                    rawKeyPair.publicKeyText.Text = .raw.publicKey
                    rawKeyPair.noCheck = False
                End With

                noteText.Text = engine.data.note

                manageAdvanceButton()
            Else
                RaiseEvent CloseMe()
            End If
        Catch ex As Exception
            MessageBox.Show("Problem during loadData information", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub updateKeyStoreList()
        Try
            Dim engine As New KeyStoreEngine

            engine.fileName = IO.Path.Combine(pathData, "keyAddress.list")

            engine.read()
            engine.addInto(walletNameText.Text, UUIDText.Text)

            engine = Nothing
        Catch ex As Exception
            MessageBox.Show("Problem during update KeyStore List information", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub saveAddressButton_Click(sender As Object, e As EventArgs) Handles saveAddressButton.Click
        If verifyData() Then
            saveData()
            updateKeyStoreList()

            RaiseEvent CloseMe()
        End If
    End Sub

    Private Sub paperWalletButton_Click(sender As Object, e As EventArgs) Handles paperWalletButton.Click
        _PrintAddress = False

        ppdMain.WindowState = FormWindowState.Maximized

        ppdMain.ShowDialog(Me)
    End Sub

    Private Sub printButton(ByVal sender As Object, ByVal e As EventArgs)

        If (pDialogMain.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            ppdMain.PrintPreviewControl.Document.Print()
        End If

    End Sub

    Private Sub ppdMain_Shown(sender As Object, e As EventArgs) Handles ppdMain.Shown

        If _FirstPrint Then

            Dim tsTmp As ToolStrip
            Dim tsPrint As ToolStripItem

            tsTmp = DirectCast(ppdMain.Controls("toolStrip1"), ToolStrip)

            tsTmp.Items(0).Visible = False

            tsPrint = tsTmp.Items.Add(tsTmp.Items(0).Image)

            AddHandler tsPrint.Click, AddressOf printButton

        End If

        _FirstPrint = False

    End Sub

    Private Sub pdMain_PrintPage(sender As Object, e As PrintPageEventArgs) Handles pdMain.PrintPage

        Try
            Dim generateBarcode As ZXing.IBarcodeWriter = New ZXing.BarcodeWriter() With {.Format = ZXing.BarcodeFormat.QR_CODE}

            With _PrintWallet
                .publicAddress = userKeyPair.publicKeyText.Text

                If Not _PrintAddress Then
                    .seedPhrases = seedValueTextArea.Text
                    .privateKey = userKeyPair.privateKeyText.Text
                    .qrCodePrivate = generateBarcode.Write(userKeyPair.privateKey)
                Else
                    .privateKey = ""
                End If

                .qrCodePublic = generateBarcode.Write(userKeyPair.publicAddress)

                .WritePage(1, e)
            End With
        Catch ex As Exception
        End Try

    End Sub

    Private Sub paperAddress_Click(sender As Object, e As EventArgs) Handles paperAddress.Click
        _PrintAddress = True

        ppdMain.WindowState = FormWindowState.Maximized

        ppdMain.ShowDialog(Me)
    End Sub

    Private Sub loadWalletFileButton_Click(sender As Object, e As EventArgs) 

    End Sub

    Private Sub testSignature_Click(sender As Object, e As EventArgs) Handles testSignature.Click
        Dim signature As String

        signature = Encryption.Base58Signature.getSignature(rawKeyPair.privateKey, "GSDKLT3W89JFRW3E9W389R3UWR93WJU")

        If Encryption.Base58Signature.verifySignature("GSDKLT3W89JFRW3E9W389R3UWR93WJU", rawKeyPair.publicAddress, signature) Then
            MessageBox.Show("Signature corrent", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Signature wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub securityPage_Click(sender As Object, e As EventArgs) Handles securityPage.Click

    End Sub

    Private Sub userKeyPair_Load(sender As Object, e As EventArgs) Handles userKeyPair.Load

    End Sub
End Class
