Option Compare Text
Option Explicit On

' ****************************************
' File: Select Port Control
' Release Engine: 1.0 
' 
' Date last successfully test: 05/10/2021
' ****************************************









Public Class SelectPort

    ''' <summary>
    ''' This property get/let the value of the control
    ''' </summary>
    ''' <returns></returns>
    Public Property value() As Integer
        Get
            Return CInt(portNumber.Text.ToString)
        End Get
        Set(value As Integer)
            portNumber.Text = value
        End Set
    End Property
    ''' <summary>
    ''' This property get/let the label of a control
    ''' </summary>
    ''' <returns></returns>
    Public Property label() As String
        Get
            Return portNumberLabel.Text
        End Get
        Set(value As String)
            portNumberLabel.Text = value
        End Set
    End Property

    ''' <summary>
    ''' This methdo provide to check a insert value
    ''' </summary>
    ''' <returns></returns>
    <DebuggerHiddenAttribute()> Public Function checkValue() As Boolean
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

    ''' <summary>
    ''' This event's method provide to manage a resize of a select port
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub SelectPort_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Try
            portNumber.Left = Width - 63
            portNumberLabel.Left = 3
            portNumberLabel.Width = Width - 72
        Catch ex As Exception

        End Try
    End Sub

End Class
