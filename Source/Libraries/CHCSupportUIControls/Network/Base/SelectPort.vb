Option Compare Text
Option Explicit On





Public Class SelectPort

    Public Property value() As Integer
        Get
            Return CInt(portNumber.Text.ToString)
        End Get
        Set(value As Integer)
            portNumber.Text = value
        End Set
    End Property

    Public Property label() As String
        Get
            Return portNumberLabel.Text
        End Get
        Set(value As String)
            portNumberLabel.Text = value
        End Set
    End Property


    Public Function checkValue() As Boolean
        If (portNumber.Text.Trim.Length() = 0) Then
            MessageBox.Show("The port is missing.", "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return False
        ElseIf Not IsNumeric(portNumber.Text) Then
            MessageBox.Show("The port must be a number", "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return False
        ElseIf (portNumber.Text = "0") Then
            MessageBox.Show("The port is missing.", "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return False
        ElseIf (portNumber.Text > "65535") Then
            MessageBox.Show("The port is wrong.", "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return False
        Else
            Return True
        End If
    End Function


    Private Sub SelectPort_Layout(sender As Object, e As LayoutEventArgs) Handles Me.Layout

    End Sub

    Private Sub SelectPort_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Try
            portNumber.Left = Width - 63
            portNumberLabel.Left = 3
            portNumberLabel.Width = Width - 72
        Catch ex As Exception

        End Try
    End Sub

End Class
