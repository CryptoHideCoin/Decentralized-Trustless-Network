Option Compare Text
Option Explicit On

Imports CHCModelsLibrary.AreaModel.Administration.Settings
Imports CHCCommonLibrary.AreaEngine.Communication
Imports CHCModelsLibrary.AreaModel.Network.Response




Public Class ServiceList

    ''' <summary>
    ''' This method provide to create Button Grid
    ''' </summary>
    ''' <param name="textValue"></param>
    ''' <param name="nameValue"></param>
    ''' <returns></returns>
    Private Function createButtonInGrid(ByVal textValue As String, ByVal nameValue As String) As DataGridViewButtonColumn
        Dim buttonColumn As DataGridViewButtonColumn

        buttonColumn = New DataGridViewButtonColumn()

        buttonColumn.HeaderText = ""
        buttonColumn.Text = textValue
        buttonColumn.Name = nameValue
        buttonColumn.Width = 60
        buttonColumn.UseColumnTextForButtonValue = True

        Return buttonColumn
    End Function

    Private Sub ServiceList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If Not AreaCommon.Startup.Bootstrap.run() Then
                End
            End If
            If Not AreaCommon.Startup.Scheduler.run() Then
                End
            End If
            If Not AreaCommon.Controllers.webServiceThread() Then
                End
            End If
            If (CHCSidechainServiceLibrary.AreaCommon.Main.serviceInformation.currentStatus = CHCModelsLibrary.AreaModel.Information.InternalServiceInformation.EnumInternalServiceState.started) Then
                checkSwitchOff.Enabled = True
            End If

            pageDataGrid.Columns.Add(createButtonInGrid("Log", "log"))

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

    Private Sub ExitToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem1.Click
        End
    End Sub

    Private Sub ShowLogParametersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShowLogParametersToolStripMenuItem.Click
        Me.TopMost = False

        ShowLogConfiguration.ShowDialog()

        Me.TopMost = setTopMostToolStrip.Checked
    End Sub

    Private Sub setTopMostToolStrip_Click(sender As Object, e As EventArgs) Handles setTopMostToolStrip.Click
        setTopMostToolStrip.Checked = Not setTopMostToolStrip.Checked

        Me.TopMost = setTopMostToolStrip.Checked
    End Sub

    Private Sub InfoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InfoToolStripMenuItem.Click
        Informations.ShowDialog()
    End Sub

    Private Sub checkSwitchOff_Tick(sender As Object, e As EventArgs) Handles checkSwitchOff.Tick
        If (CHCSidechainServiceLibrary.AreaCommon.Main.serviceInformation.currentStatus <> CHCModelsLibrary.AreaModel.Information.InternalServiceInformation.EnumInternalServiceState.started) Then
            checkSwitchOff.Enabled = False
            mainTimer.Enabled = False

            End
        End If
    End Sub

    ''' <summary>
    ''' This method provide to save remote settings
    ''' </summary>
    ''' <param name="value"></param>
    ''' <returns></returns>
    Private Function saveRemoteSettings(ByVal value As SettingsLogSidechainService, ByRef item As AreaCommon.GeneralModel.ServiceData) As Boolean
        Try
            Dim remote As New ProxyWS(Of SettingsLogSidechainService)
            Dim proceed As Boolean = True

            If proceed Then
                remote.url = AreaCommon.Network.buildURL("/administration/logSettings/?securityToken=" & item.securityToken, item.configuration)

                remote.data = value
            End If
            If proceed Then
                proceed = (remote.sendData("PUT") = "")
            End If
            If proceed Then
                proceed = (remote.remoteResponse.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete)
            End If

            Return proceed
        Catch exFile As System.IO.FileLoadException
            IntegrityApplication.executeRepairNewton(exFile.FileName)

            Return False
        Catch ex As Exception
            Console.WriteLine("Error during saveRemoteSettings - " & ex.Message)

            Return False
        End Try
    End Function

    ''' <summary>
    ''' This method provide to manage remote settings
    ''' </summary>
    ''' <param name="value"></param>
    ''' <returns></returns>
    Private Function manageRemoteSettings(ByVal value As SettingsLogSidechainService, ByRef item As AreaCommon.GeneralModel.ServiceData) As Boolean
        Try
            Dim settingPage As New trackLogSettings
            Dim topMostValue As Boolean = Me.TopMost

            Select Case value.trackConfiguration
                Case CHCModelsLibrary.AreaModel.Log.TrackRuntimeModeEnum.trackOnlyBootstrapAndError : settingPage.trackConfiguration.SelectedIndex = 0
                Case CHCModelsLibrary.AreaModel.Log.TrackRuntimeModeEnum.trackAll : settingPage.trackConfiguration.SelectedIndex = 1
            End Select

            settingPage.useBufferToWrite.Checked = value.useBufferToWrite
            settingPage.writeToFile.Checked = value.writeToFile
            settingPage.everyChangeFile.text = value.changeLogFileMaxNumHours
            settingPage.numberRegistrations.text = value.changeLogFileNumRegistrations

            Me.TopMost = False

            If (settingPage.ShowDialog() = DialogResult.OK) Then
                Select Case settingPage.trackConfiguration.SelectedIndex
                    Case 0 : value.trackConfiguration = CHCModelsLibrary.AreaModel.Log.TrackRuntimeModeEnum.trackOnlyBootstrapAndError
                    Case 1 : value.trackConfiguration = CHCModelsLibrary.AreaModel.Log.TrackRuntimeModeEnum.trackAll
                End Select

                value.useBufferToWrite = settingPage.useBufferToWrite.Checked
                value.writeToFile = settingPage.writeToFile.Checked
                If IsNumeric(settingPage.everyChangeFile.text) Then
                    value.changeLogFileMaxNumHours = settingPage.everyChangeFile.text
                Else
                    value.changeLogFileMaxNumHours = 0
                End If
                If IsNumeric(settingPage.numberRegistrations.text) Then
                    value.changeLogFileNumRegistrations = settingPage.numberRegistrations.text
                Else
                    value.changeLogFileNumRegistrations = 0
                End If

                saveRemoteSettings(value, item)
            End If

            Me.TopMost = topMostValue

            settingPage.Close()

            settingPage = Nothing

            Return True
        Catch ex As Exception
            MessageBox.Show("An error occurrence with manageRemoteSettings - " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return False
        End Try
    End Function

    Private Function getRemoteSetting(ByRef item As AreaCommon.GeneralModel.ServiceData) As Boolean
        Try
            Dim remote As New ProxyWS(Of ResponseLogSettingsModel)
            Dim proceed As Boolean = True

            If proceed Then
                remote.url = AreaCommon.Network.buildURL("/administration/logSettings/?securityToken=" & item.securityToken, item.configuration)
            End If
            If proceed Then
                proceed = (remote.getData() = "")
            End If
            If proceed Then
                proceed = (remote.data.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete)
            End If
            If proceed Then
                proceed = manageRemoteSettings(remote.data.value, item)
            End If

            Return proceed
        Catch exFile As System.IO.FileLoadException
            IntegrityApplication.executeRepairNewton(exFile.FileName)

            Return False
        Catch ex As Exception
            Console.WriteLine("Error during getRemoteSetting - " & ex.Message)

            Return False
        End Try
    End Function

    ''' <summary>
    ''' This method provide to update the service state
    ''' </summary>
    ''' <param name="item"></param>
    ''' <returns></returns>
    Private Function readRemoteSettings(ByVal item As AreaCommon.GeneralModel.ServiceData) As Boolean
        Dim proceed As Boolean = True
        Try
            Dim accessKey As String = ""

            If proceed Then
                proceed = AreaCommon.Network.testService(item.configuration)
            End If
            If (item.securityToken.Length = 0) Then
                If proceed Then
                    proceed = AreaCommon.Network.getAccessKey(accessKey, item)
                End If
                If proceed Then
                    proceed = AreaCommon.Network.getSecurityToken(accessKey, item)
                End If
            End If
            If proceed Then
                proceed = getRemoteSetting(item)
            End If

            Return proceed
        Catch ex As Exception
            Console.WriteLine("Error during updateStateService - " & ex.Message)

            proceed = False
        End Try

        Return proceed
    End Function

    Private Sub pageDataGrid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles pageDataGrid.CellContentClick
        Try
            Dim name As String

            Select Case e.ColumnIndex
                Case 4
                    name = pageDataGrid.Item(0, e.RowIndex).Value.ToString()

                    For Each item In AreaCommon.Main.settingList
                        If (item.Value.configuration.internalName.CompareTo(name) = 0) Then
                            readRemoteSettings(item.Value)

                            Return
                        End If
                    Next
            End Select
        Catch ex As Exception
            MessageBox.Show("Error during walletAddressDataGrid_CellContentClick " & Err.Description, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class
