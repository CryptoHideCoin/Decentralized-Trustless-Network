Option Compare Text
Option Explicit On




Public Class ServiceList

    Private Sub ServiceList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If Not (New IntegrityApplication).run() Then
                End
            End If
            If Not AreaCommon.Startup.Bootstrap.run() Then
                End
            End If
            If Not AreaCommon.Startup.Scheduler.run() Then
                End
            End If
            If Not AreaCommon.Controllers.webServiceThread() Then
                End
            End If
            mainNotifyIcon.ShowBalloonTip(5000, "Crypto Hide Coin - Local Work Machine", "The service is running. Click here to use or close!", ToolTipIcon.Info)

            AreaCommon.Main.interfaceEntryPoint = Me
        Catch ex As Exception
            Me.Opacity = 100

            MessageBox.Show("An error occurrence with ServiceList_Load - " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ServiceList_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = True
        Me.Opacity = 0

        mainTimer.Enabled = False

        mainNotifyIcon.ShowBalloonTip(5000, "Crypto Hide Coin - Local Work Machine", "The service is running", ToolTipIcon.Info)
    End Sub

    Private Sub mainNotifyIcon_MouseDown(sender As Object, e As MouseEventArgs) Handles mainNotifyIcon.MouseDown
        If (e.Button = MouseButtons.Right) Then
            serviceContextMenu.Show()
        Else
            Me.Opacity = 100

            mainTimer.Enabled = True
        End If
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        End
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        Me.Opacity = 100

        mainTimer.Enabled = True
    End Sub

    ''' <summary>
    ''' This method provide to notify add a new service
    ''' </summary>
    ''' <param name="serviceName"></param>
    ''' <returns></returns>
    Public Function notifyAddNewService(ByVal serviceName As String) As Boolean
        mainNotifyIcon.ShowBalloonTip(5000, "Crypto Hide Coin - Start new service ", "The service " & serviceName & " is now running", ToolTipIcon.Info)

        Return True
    End Function

    ''' <summary>
    ''' This method provide to notify remove a service
    ''' </summary>
    ''' <param name="serviceName"></param>
    ''' <returns></returns>
    Public Function notifyRemoveService(ByVal serviceName As String) As Boolean
        mainNotifyIcon.ShowBalloonTip(5000, "Crypto Hide Coin - Stop service ", "The service " & serviceName & " is now stopped", ToolTipIcon.Info)

        Return True
    End Function

    Public Function notifyStartUpdate() As Boolean
        descriptionOperationLabel.Text = "Start update service list..."

        Return True
    End Function

    Public Function notifyInIdle() As Boolean
        Try
            Dim rowItem As New ArrayList

            descriptionOperationLabel.Text = "Current operazion: in pause."
        Catch ex As Exception
        End Try

        Return True
    End Function

    Private Sub mainTimer_Tick(sender As Object, e As EventArgs) Handles mainTimer.Tick
        Try
            Dim rowItem As New ArrayList

            pageDataGrid.Rows.Clear()

            For Each item In AreaCommon.Main.settingList.Values
                rowItem.Add(item.configuration.internalName)
                rowItem.Add(item.configuration.sideChainName)
                rowItem.Add(item.configuration.servicePort)
                rowItem.Add(item.status)

                pageDataGrid.Rows.Add(rowItem.ToArray)
            Next

            pageDataGrid.Refresh()
        Catch ex As Exception
        End Try
    End Sub

End Class
