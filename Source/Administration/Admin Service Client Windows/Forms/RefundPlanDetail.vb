Option Compare Text
Option Explicit On


Public Class RefundPlanDetail

    Public Property Data As New CHCProtocolLibrary.AreaCommon.Models.Network.RefundItem




    Private Function validateData() As Boolean
        Dim proceed As Boolean = True

        If proceed Then
            If (recipientText.Text.Trim.Length = 0) Then
                MessageBox.Show("The 'Recipient' is missing", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)

                proceed = False
            End If
        End If
        If proceed Then
            If (descriptionText.Text.Trim.Length = 0) Then
                MessageBox.Show("The 'Description' is missing", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)

                proceed = False
            End If
        End If
        If proceed Then
            If Not fixOption.Checked And Not percentageOption.Checked Then
                MessageBox.Show("The 'Fix' or 'Percentage' is not selected", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)

                proceed = False
            End If
        End If
        If proceed Then
            If valueText.Value = 0 Then
                MessageBox.Show("The 'Value' is missing", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)

                proceed = False
            ElseIf percentageOption.Checked Then
                If valueText.Value > 100 Then
                    MessageBox.Show("The 'Value' is overfloat", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    proceed = False
                End If
            End If
        End If

        Return proceed
    End Function

    Private Sub loadIntoStructure()
        Data.recipient = recipientText.Text
        Data.description = descriptionText.Text

        If fixOption.Checked Then
            Data.fixValue = valueText.Value
        Else
            Data.percentageValue = valueText.Value
        End If
    End Sub


    Private Sub RefundPlanDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Sub init()
        If Data.recipient.Length > 0 Then
            recipientText.Text = Data.recipient
            recipientText.Enabled = False

            descriptionText.Text = Data.description

            If (Data.fixValue > 0) Then
                fixOption.Checked = True

                valueText.text = Data.fixValue
            Else
                percentageOption.Checked = True

                valueText.text = Data.percentageValue
            End If
        End If
    End Sub

    Private Sub confirmButton_Click(sender As Object, e As EventArgs) Handles confirmButton.Click
        If validateData() Then
            loadIntoStructure()

            DialogResult = DialogResult.OK
        End If
    End Sub

    Private Sub cancelButton_Click(sender As Object, e As EventArgs) Handles cancelButton.Click
        DialogResult = DialogResult.Cancel

        Me.Close()
    End Sub


End Class