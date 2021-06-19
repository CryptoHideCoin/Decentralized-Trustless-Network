Option Compare Text
Option Explicit On


Public Class _KeyStoreManager

    Public Property addressValue As String
    Public Property dataPath() As String
        Get
            Return listAddress.dataPath
        End Get
        Set(value As String)
            listAddress.dataPath = value
        End Set
    End Property

    Private Sub listAddress_RequestAddNew() Handles listAddress.RequestAddNew
        Try
            Dim tmp As New _KeyPairDetail
            Dim result As String = ""

            tmp.pathData = dataPath

            If (tmp.ShowDialog = DialogResult.OK) Then
                addressValue = "keystoreid:" & tmp.uuid

                DialogResult = DialogResult.OK
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub listAddress_Load(sender As Object, e As EventArgs) Handles listAddress.Load

    End Sub

    Private Sub listAddress_UseAddress(value As String) Handles listAddress.UseAddress
        addressValue = value

        DialogResult = DialogResult.OK
    End Sub

End Class