Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.Communication
Imports CHCCommonLibrary.AreaCommon.Models


Public Class UrlProtocol

    Public Event LockScreen()
    Public Event UnLockScreen()
    Public Event RunCommand()

    Public Shadows Event TextChanged()



    Private _noChange As Boolean = False


    Public Property serviceId As String = ""
    Public Property executeCommand As Boolean = False

    Public Property useSecure() As Boolean
        Get
            Return (protocolCombo.SelectedIndex = 1)
        End Get
        Set(value As Boolean)
            _noChange = True
            If value Then
                protocolCombo.SelectedIndex = 1
            Else
                protocolCombo.SelectedIndex = 0
            End If
            _noChange = False
        End Set
    End Property

    Public Property address As String
        Get
            Return serviceAdminUrlText.Text
        End Get
        Set(value As String)
            _noChange = True
            serviceAdminUrlText.Text = value
            _noChange = False
        End Set
    End Property

    Public ReadOnly Property baseUrlComplete() As String
        Get
            Dim result As String

            If useSecure Then
                result = "https://"
            Else
                result = "http://"
            End If

            result += address

            Return result
        End Get
    End Property

    Public Function testServiceResponse() As Boolean
        If (serviceAdminUrlText.Text.ToString.Trim.Length > 0) Then
            Try
                Dim handShakeEngine As New ProxyWS(Of General.RemoteResponse)

                If (protocolCombo.SelectedIndex = 0) Then
                    handShakeEngine.url = "http://"
                Else
                    handShakeEngine.url = "https://"
                End If

                RaiseEvent LockScreen()

                handShakeEngine.url += serviceAdminUrlText.Text & "/api/" & serviceId & "/service/test"

                If (handShakeEngine.getData() = "") Then

                    If (handShakeEngine.data.responseStatus = General.RemoteResponse.EnumResponseStatus.systemOffline) Then
                        Return False
                    Else
                        Return True
                    End If

                Else
                    Return False
                End If

            Catch ex As Exception
                Return False
            Finally
                RaiseEvent UnLockScreen()
            End Try
        Else
            Return False
        End If
    End Function

    Private Sub testButton_Click(sender As Object, e As EventArgs) Handles testButton.Click
        If (serviceAdminUrlText.Text.ToString.Trim.Length > 0) Then
            If executeCommand Then
                RaiseEvent RunCommand()
            Else
                Try
                    Dim handShakeEngine As New ProxyWS(Of CHCCommonLibrary.AreaCommon.Models.General.RemoteResponse)

                    If (protocolCombo.SelectedIndex = 0) Then
                        handShakeEngine.url = "http://"
                    Else
                        handShakeEngine.url = "https://"
                    End If

                    RaiseEvent LockScreen()

                    handShakeEngine.url += serviceAdminUrlText.Text & "/api/" & serviceId & "/service/test"

                    If (handShakeEngine.getData() = "") Then

                        If (handShakeEngine.data.responseStatus = General.RemoteResponse.EnumResponseStatus.systemOffline) Then
                            MessageBox.Show("Test connection failed", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Else
                            MessageBox.Show("Test connection succesful", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If

                    Else
                        MessageBox.Show("Test connection failed", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If

                Catch ex As Exception
                    MessageBox.Show("Test connection failed", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

                RaiseEvent UnLockScreen()
            End If
        End If
    End Sub

    Private Sub serviceAdminUrlText_TextChanged(sender As Object, e As EventArgs) Handles serviceAdminUrlText.TextChanged
        testButton.Enabled = (serviceAdminUrlText.Text.Length > 0)

        If Not _noChange Then
            RaiseEvent TextChanged()
        End If
    End Sub

    Private Sub positionControls()
        Try
            urlLabel.Left = 8
            urlLabel.Width = 29
            protocolCombo.Left = 43
            protocolCombo.Width = 70
            testButton.Left = Width - 26
            testButton.Width = 20
            serviceAdminUrlText.Left = 119
            serviceAdminUrlText.Width = Width - 149
        Catch ex As Exception
        End Try
    End Sub

    Private Sub UrlProtocol_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        positionControls()
    End Sub

    Private Sub UrlProtocol_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        positionControls()
    End Sub

    Private Sub UrlProtocol_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        positionControls()
    End Sub

    Private Sub protocolCombo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles protocolCombo.SelectedIndexChanged
        If Not _noChange Then
            RaiseEvent TextChanged()
        End If
    End Sub

End Class