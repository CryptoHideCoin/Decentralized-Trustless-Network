' ============================================================================
'    Author: Kenneth Perkins
'    Date:   Nov 18, 2020
'    Taken From: http://programmingnotes.org/
'    File: Program.vb
'    Description: The following demonstrates the use of the Utils Namespace
' ============================================================================
Option Strict On
Option Explicit On

Imports System.Net



Public Class Main

    Public Async Function ProcessRequests() As Task
        Dim url = remoteAddressText.Text & "api/service/test/"
        Try
            Dim request As WebRequest = WebRequest.Create(url)
            Dim response As WebResponse = request.GetResponse()
            Dim dataStream As IO.Stream = response.GetResponseStream()
            Dim reader As New IO.StreamReader(dataStream)
            Dim responseFromServer As String = reader.ReadToEnd()

            reader.Close()
            response.Close()

            responseText.Text = responseFromServer

        Catch ex As Exception
            responseText.Text = "Error: " & ex.Message
        End Try
    End Function

    Private Sub connectButton_Click(sender As Object, e As EventArgs) Handles connectButton.Click
        Try
            ProcessRequests().Wait()
        Catch ex As Exception
            responseText.Text = "Error: " & ex.Message
        End Try
    End Sub

    Private Sub remoteAddressText_TextChanged(sender As Object, e As EventArgs) Handles remoteAddressText.TextChanged
        connectButton.Enabled = (remoteAddressText.Text.Length > 0)
    End Sub

End Class
