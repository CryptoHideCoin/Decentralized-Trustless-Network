Public Class Informations

    Private Sub PixBay_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles PixBay.LinkClicked
        Process.Start("https://pixabay.com/it/users/geralt-9301/?utm_source=link-attribution&amp;utm_medium=referral&amp;utm_campaign=image&amp;utm_content=30173892")
    End Sub

    Private Sub Close_Click(sender As Object, e As EventArgs) Handles Close.Click
        Hide()
    End Sub

End Class