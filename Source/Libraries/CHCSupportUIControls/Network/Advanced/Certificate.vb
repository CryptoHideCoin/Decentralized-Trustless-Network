Option Compare Text
Option Explicit On

' ****************************************
' File: Certificate Control
' Release Engine: 1.0 
' 
' Date last successfully test: 03/10/2021
' ****************************************











Public Class Certificate

    Private _NoChange As Boolean = False
    Private _UrlService As String = ""
    Private _DataPath As String = ""
    Private _ServiceId As String = ""

    Public Shadows Event TextChanged()
    Public Event LockScreen()
    Public Event UnLockScreen()
    Public Event GetPrivateKey(ByRef keyValue As String, ByRef cancel As Boolean)
    Public Event UpdateCertificateSetting(ByVal newValue As String)

    ''' <summary>
    ''' This property get/let the URL Service
    ''' </summary>
    ''' <returns></returns>
    Public Property urlService As String
        Get
            Return _UrlService
        End Get
        Set(value As String)
            _UrlService = value

            refreshButton()
        End Set
    End Property
    ''' <summary>
    ''' This property get/let the service id
    ''' </summary>
    ''' <returns></returns>
    Public Property serviceId() As String
        Get
            Return _ServiceId
        End Get
        Set(value As String)
            _ServiceId = value

            refreshButton()
        End Set
    End Property
    ''' <summary>
    ''' This property get/let the Data Path
    ''' </summary>
    ''' <returns></returns>
    Public Property dataPath As String
        Get
            Return _DataPath
        End Get
        Set(value As String)
            _DataPath = value

            refreshButton()
        End Set
    End Property
    ''' <summary>
    ''' This property get/let the value
    ''' </summary>
    ''' <returns></returns>
    Public Property value() As String
        Get
            Return valueText.Text
        End Get
        Set(value As String)
            valueText.Text = value
        End Set
    End Property
    ''' <summary>
    ''' This property get/let No Change state
    ''' </summary>
    ''' <returns></returns>
    Public Property noChange() As Boolean
        Get
            Return _NoChange
        End Get
        Set(value As Boolean)
            _NoChange = value

            resizeControls()
        End Set
    End Property


    Private Sub refreshButton()
        changeButton.Enabled = (_UrlService.Trim.Length > 0) And (_DataPath.Trim.Length > 0) And (value.Trim.Length > 0) And (_ServiceId.Trim.Length > 0)
    End Sub

    Private Sub resizeControls()
        Try
            valueLabel.Left = 3
            valueLabel.Width = 66
            valueText.Left = 75
            createButton.Width = 49
            browserButton.Width = 31
            changeButton.Width = 65

            If _NoChange Then
                valueText.Width = Width - 170
                createButton.Left = Width - 89
                browserButton.Left = Width - 34
                changeButton.Visible = False
            Else
                valueText.Width = Width - 243
                createButton.Left = Width - 162
                browserButton.Left = Width - 107
                changeButton.Left = Width - 70
                changeButton.Visible = True
            End If

        Catch ex As Exception
        End Try
    End Sub


    Private Sub Certificate_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        resizeControls()
    End Sub

    Private Sub Certificate_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        resizeControls()
    End Sub

    Private Sub Certificate_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        resizeControls()
    End Sub

    Private Sub changeButton_Click(sender As Object, e As EventArgs) Handles changeButton.Click
        Try
            Dim change As New DialogChangeCertificate
            Dim cancel As Boolean = False
            Dim keyValue As String = ""

            change.certificate = valueText.Text
            change.urlService = _UrlService & "/api/" & serviceId & "/security/changeCertificate"
            change.dataPath = _DataPath
            change.serviceId = _ServiceId

            RaiseEvent getPrivateKey(keyValue, cancel)

            If Not cancel Then
                change.privateKey = keyValue

                If (change.ShowDialog() = DialogResult.OK) Then
                    valueText.Text = change.certificate

                    RaiseEvent UpdateCertificateSetting(change.certificate)
                End If
            End If

            change.Close()
            change.Dispose()

            change = Nothing
        Catch ex As Exception
            MessageBox.Show("Error during a changeButton_Click - " & Err.Description, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub browserButton_Click(sender As Object, e As EventArgs) Handles browserButton.Click
        Try

            openFileDialog.FileName = ""

            If (openFileDialog.ShowDialog() = DialogResult.OK) Then
                valueText.Text = My.Computer.FileSystem.ReadAllText(openFileDialog.FileName)
            End If

        Catch ex As Exception
            MessageBox.Show("An error occurrent during browserButton_Click " & Err.Description, "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub createButton_Click(sender As Object, e As EventArgs) Handles createButton.Click
        valueText.Text = CHCProtocolLibrary.AreaBase.Certificate.createNew()
    End Sub

    Private Sub valueText_TextChanged(sender As Object, e As EventArgs) Handles valueText.TextChanged
        RaiseEvent TextChanged()

        refreshButton()
    End Sub

End Class
