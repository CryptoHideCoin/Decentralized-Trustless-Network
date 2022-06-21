Option Compare Text
Option Explicit On

' ****************************************
' File: Key Paint Control
' Release Engine: 1.0 
' 
' Date last successfully test: 06/10/2021
' ****************************************











Public Class KeyPair

    Public Event SynchroButtonEdit(ByVal value As Boolean)
    Public Event SynchroClearField()
    Public Event SynchroOther()
    Public Event SynchroOtherKeyPair(ByVal publicKey As String, ByVal privateKey As String)

    Public Property noCheck As Boolean
    Public Property inError As Boolean

    ''' <summary>
    ''' This method provide to enable button edit
    ''' </summary>
    ''' <param name="value"></param>
    <DebuggerHiddenAttribute()> Public Sub enableButtonEdit(ByVal value As Boolean)
        qrPublicAddressButton.Enabled = value
        copyPublicAddressButton.Enabled = value
        qrPrivateAddressButton.Enabled = value
        copyPrivateAddressButton.Enabled = value
    End Sub
    ''' <summary>
    ''' This method provide to clear field
    ''' </summary>
    <DebuggerHiddenAttribute()> Public Sub clearField()
        publicKeyText.Text = ""
        privateKeyText.Text = ""
    End Sub
    ''' <summary>
    ''' This property get/let the User Mode
    ''' </summary>
    ''' <returns></returns>
    Public Property userMode As Boolean
        Get
            Return Not privateKeyText.ReadOnly
        End Get
        Set(value As Boolean)
            privateKeyText.ReadOnly = Not value
            charCounterPrivateAddress.Visible = value
        End Set
    End Property
    ''' <summary>
    ''' This property get/let Private Key 
    ''' </summary>
    ''' <returns></returns>
    Public Property privateKey() As String
        Get
            Return privateKeyText.Text
        End Get
        Set(value As String)
            privateKeyText.Text = value
        End Set
    End Property
    ''' <summary>
    ''' This property get/let the Public Address
    ''' </summary>
    ''' <returns></returns>
    Public Property publicAddress As String
        Get
            Return publicKeyText.Text
        End Get
        Set(value As String)
            publicKeyText.Text = value
        End Set
    End Property

    ''' <summary>
    ''' This method provide to calculate char remain
    ''' </summary>
    ''' <param name="textValue"></param>
    ''' <param name="numCharMax"></param>
    ''' <returns></returns>
    Private Function calculateCharRemain(ByVal textValue As String, ByVal numCharMax As Integer) As String
        Return "(" & textValue.Length.ToString.Trim() & " / " & numCharMax.ToString.Trim() & ")"
    End Function
    ''' <summary>
    ''' This method provide to resize a char counter
    ''' </summary>
    ''' <param name="objetCounter"></param>
    ''' <param name="objectText"></param>
    Private Sub resizeCharCounter(ByRef objetCounter As Label, ByRef objectText As TextBox)
        objetCounter.Left = (objectText.Left + objectText.Width) - objetCounter.Width
    End Sub
    ''' <summary>
    ''' This method provide a Custom Resize
    ''' </summary>
    Private Sub customResize()
        Try
            qrCodePanel.Left = 5
            qrCodePanel.Width = Me.Width - 5
            qrCodeImage.Top = 20
            qrCodeImage.Height = Me.Height - 20
        Catch ex As Exception
            qrCodeImage.Visible = False
        End Try
        Try
            publicKeyText.Left = 15
            publicKeyText.Top = 28
            publicKeyText.Width = (Me.Width - 32)
            publicKeyText.Visible = True
        Catch ex As Exception
            publicKeyText.Visible = False
        End Try
        Try
            qrPublicAddressButton.Left = (Me.Width - 64)
            qrPublicAddressButton.Visible = True
        Catch ex As Exception
            qrPublicAddressButton.Visible = False
        End Try
        Try
            copyPublicAddressButton.Left = (Me.Width - 128)
            copyPublicAddressButton.Visible = True
        Catch ex As Exception
            copyPublicAddressButton.Visible = False
        End Try
        Try
            privateKeyText.Left = 15
            privateKeyText.Width = publicKeyText.Width
            privateKeyText.Height = (Me.Height - 153)
            privateKeyText.Visible = True
        Catch ex As Exception
            privateKeyText.Visible = False
        End Try
        Try
            qrPrivateAddressButton.Left = qrPublicAddressButton.Left
            qrPrivateAddressButton.Top = (privateKeyText.Height + privateKeyText.Top) - qrPrivateAddressButton.Height - 2
            qrPrivateAddressButton.Visible = True
        Catch ex As Exception
            qrPrivateAddressButton.Visible = False
        End Try
        Try
            copyPrivateAddressButton.Left = copyPublicAddressButton.Left
            copyPrivateAddressButton.Top = qrPrivateAddressButton.Top
            copyPrivateAddressButton.Visible = True
        Catch ex As Exception
            copyPrivateAddressButton.Visible = False
        End Try
    End Sub
    ''' <summary>
    ''' This method provide to manage a Validate Private Key Format
    ''' </summary>
    ''' <returns></returns>
    Private Function validatePrivateKeyFormat() As Boolean
        If Not CHCProtocolLibrary.AreaWallet.Support.WalletAddressEngine.SingleKeyPair.startAllowed(privateKeyText.Text) Then

            publicKeyText.Text = "ERROR START PRIVATE KEY MUST BEGIN WITH " & CHCProtocolLibrary.AreaWallet.Support.WalletAddressEngine.basePvt
            publicKeyText.ForeColor = Color.Red

            Return False

        End If
        If Not CHCProtocolLibrary.AreaWallet.Support.WalletAddressEngine.SingleKeyPair.endAllowed(privateKeyText.Text) Then

            publicKeyText.Text = "ERROR END PRIVATE KEY MUST COMPLETE WITH " & CHCProtocolLibrary.AreaWallet.Support.WalletAddressEngine.closeBasePvt
            publicKeyText.ForeColor = Color.Red

            Return False

        End If

        publicKeyText.ForeColor = Color.DarkBlue

        Return True
    End Function
    ''' <summary>
    ''' This method provide to show a QR Panel
    ''' </summary>
    ''' <param name="code"></param>
    Private Sub showQRPanel(ByVal code As String)
        qrCodePanel.Visible = True

        Dim generateBarcode As ZXing.IBarcodeWriter = New ZXing.BarcodeWriter() With {.Format = ZXing.BarcodeFormat.QR_CODE}

        qrCodePanel.BringToFront()

        qrCodePanel.Visible = True
        qrCodeImage.Visible = True
        closeUserButton.Visible = True

        qrCodeImage.Image = generateBarcode.Write(code)
    End Sub

    ''' <summary>
    ''' This event's method provide to manage a load method of this control
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub KeyPair_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If privateKeyText.ReadOnly Then
            charCounterPrivateAddress.Text = calculateCharRemain(privateKeyText.Text, CHCProtocolLibrary.AreaWallet.Support.WalletAddressEngine.numCharMaxFormatPrivateKey)

            resizeCharCounter(charCounterPrivateAddress, privateKeyText)

            privateKeyText.MaxLength = CHCProtocolLibrary.AreaWallet.Support.WalletAddressEngine.numCharMaxFormatPrivateKey

            RaiseEvent SynchroOther()
        End If
    End Sub
    ''' <summary>
    ''' This event's method provide to resize a control
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub KeyPair_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        customResize()
    End Sub
    ''' <summary>
    ''' This event's method provide to manage a Paint of a control
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub KeyPair_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        customResize()
    End Sub
    ''' <summary>
    ''' This event's method provide to manage a Text Changed of a control
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub privateKeyText_TextChanged(sender As Object, e As EventArgs) Handles privateKeyText.TextChanged
        If Not privateKeyText.ReadOnly Then
            qrPublicAddressButton.Enabled = (privateKeyText.Text.Trim.Length > 0)
            copyPublicAddressButton.Enabled = qrPublicAddressButton.Enabled
            qrPrivateAddressButton.Enabled = qrPublicAddressButton.Enabled
            copyPrivateAddressButton.Enabled = qrPublicAddressButton.Enabled

            RaiseEvent SynchroButtonEdit(qrPublicAddressButton.Enabled)

            charCounterPrivateAddress.Text = calculateCharRemain(privateKeyText.Text, CHCProtocolLibrary.AreaWallet.Support.WalletAddressEngine.numCharMaxFormatPrivateKey)

            resizeCharCounter(charCounterPrivateAddress, privateKeyText)

            If noCheck Then Return
            If (privateKeyText.Text.Length = 0) Then
                publicKeyText.Text = ""

                RaiseEvent SynchroClearField()

                inError = False

                RaiseEvent SynchroOther()

                Return
            End If
            If validatePrivateKeyFormat() Then
                With CHCProtocolLibrary.AreaWallet.Support.WalletAddressEngine.createNew(privateKeyText.Text)
                    RaiseEvent SynchroOtherKeyPair(.raw.public, .raw.private)

                    publicKeyText.Text = .official.public
                End With

                inError = False
            Else
                RaiseEvent SynchroOtherKeyPair("", "")

                inError = True
            End If

            RaiseEvent SynchroOther()
        End If
    End Sub
    ''' <summary>
    ''' This event's method provide to manage a Size Changed of a control
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub KeyPair_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        If Not privateKeyText.ReadOnly Then
            resizeCharCounter(charCounterPrivateAddress, privateKeyText)
        End If
    End Sub
    ''' <summary>
    ''' This event's method provide to manage a click of a Copy Public Address Button
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub copyPublicAddressButton_Click(sender As Object, e As EventArgs) Handles copyPublicAddressButton.Click
        Clipboard.SetText(publicKeyText.Text)
    End Sub
    ''' <summary>
    ''' This event's method provide to manage a click of a copy private address button
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub copyPrivateAddressButton_Click(sender As Object, e As EventArgs) Handles copyPrivateAddressButton.Click
        Clipboard.SetText(privateKeyText.Text)
    End Sub
    ''' <summary>
    ''' This event's method provide to manage a Text Down of a PrivateKeyText control
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub privateKeyText_KeyDown(sender As Object, e As KeyEventArgs) Handles privateKeyText.KeyDown
        If noCheck Then Return

        Dim value As String = ""

        If (e.KeyValue = 8) Or (e.KeyValue = 16) Or (e.KeyValue = 18) Or (e.KeyValue = 17) Or (e.KeyValue = 39) Then Return

        Select Case e.KeyValue
            Case Keys.Space : e.SuppressKeyPress = True
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

        If Not CHCProtocolLibrary.AreaWallet.Support.WalletAddressEngine.charAllowed(value) Then
            e.SuppressKeyPress = True
        End If
    End Sub
    ''' <summary>
    ''' This event's method provide to manage a click on QrPublicAddressButton
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub qrPublicAddressButton_Click(sender As Object, e As EventArgs) Handles qrPublicAddressButton.Click
        showQRPanel(publicKeyText.Text)
    End Sub
    ''' <summary>
    ''' This event's method provide to manage a click on Close User Button 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub closeUserButton_Click(sender As Object, e As EventArgs) Handles closeUserButton.Click
        qrCodePanel.Visible = False
    End Sub
    ''' <summary>
    ''' This event's method provide to manage a click on a qr Private Address Button
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub qrPrivateAddressButton_Click(sender As Object, e As EventArgs) Handles qrPrivateAddressButton.Click
        showQRPanel(privateKeyText.Text)
    End Sub

End Class