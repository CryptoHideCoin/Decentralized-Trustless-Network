Option Compare Text
Option Explicit On



Public Class ConfigurationManager

    ''' <summary>
    ''' This class contain a tuple of a single configuration
    ''' </summary>
    Public Class SingleConfiguration
        Public Property text As String
        Public Property value As String


        Public Sub New(ByVal text As String, ByVal value As String)
            Me.text = text
            Me.value = value
        End Sub
    End Class

    ''' <summary>
    ''' This class contain a tuple of a single configuration DB
    ''' </summary>
    Public Class SingleConfigurationDB
        Public Property uuid As String = ""
        Public Property name As String = ""
    End Class

    ''' <summary>
    ''' This class provide to manage a configuration data
    ''' </summary>
    Public Class ConfigurationData
        Inherits CHCCommonLibrary.AreaEngine.DataFileManagement.XML.BaseFile(Of List(Of SingleConfigurationDB))
    End Class

    Private _Configurations As New ConfigurationData
    Private _NoWorkList As Boolean = False
    Private _SystemActive As Boolean = False


    ''' <summary>
    ''' This method load all information in the relative field
    ''' </summary>
    ''' <param name="data"></param>
    Private Sub loadData(ByRef data As AppSettings.SettingsData)
        Try
            urlProtocol.useSecure = data.useSecureProtocol
            urlProtocol.address = data.urlPublic

            serviceID.Text = data.serviceId

            personalPublicAddress.value = data.personalPublicAddress

            urlService.useSecure = data.useServiceSecureProtocol
            urlService.address = data.urlService

            adminCertificate.value = data.certificateService
            adminPublicAddress.value = data.adminPublicAddress
        Catch ex As Exception
            MessageBox.Show("An error occurrent during loadData " & Err.Description, "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' This method provide to load data from UI
    ''' </summary>
    ''' <param name="data"></param>
    Private Sub loadDataFromUI(ByRef data As AppSettings.SettingsData)
        Try
            data.useSecureProtocol = urlProtocol.useSecure
            data.urlPublic = urlProtocol.address

            data.serviceId = serviceID.Text

            data.personalPublicAddress = personalPublicAddress.value

            data.useServiceSecureProtocol = urlService.useSecure
            data.urlService = urlService.address

            data.certificateService = adminCertificate.value
            data.adminPublicAddress = adminPublicAddress.value
        Catch ex As Exception
            MessageBox.Show("An error occurrent during loadData " & Err.Description, "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' This method provide to show the setting in a form field
    ''' </summary>
    Private Sub showSettings(Optional ByVal excludeLocalPath As Boolean = False)
        With AreaCommon.settings.data
            If Not excludeLocalPath Then
                localPathData.Text = .dataPath
            End If

            _NoWorkList = True

            configurationNameCombo.Items.Clear()

            For Each item In _Configurations.data
                configurationNameCombo.Items.Add(New SingleConfiguration(item.name, item.uuid))
            Next

            _NoWorkList = False

            For Each item In configurationNameCombo.Items
                If item.value = .currentConfiguration Then
                    configurationNameCombo.SelectedItem = item
                End If
            Next
        End With

        loadData(AreaCommon.settings.data)
    End Sub

    Private Sub localPathDataText_TextChanged(sender As Object, e As EventArgs) Handles localPathData.TextChanged
        Try
            If IO.Directory.Exists(localPathData.Text) Then
                If (AreaCommon.paths.pathBaseData.Length = 0) Then
                    AreaCommon.paths.pathBaseData = localPathData.Text

                    If AreaCommon.startApplication() Then
                        showSettings()

                        AreaCommon.paths.updateRootPath(AreaCommon.paths.pathBaseData)
                        AreaCommon.settings.save()
                    End If
                Else
                    _Configurations.fileName = IO.Path.Combine(AreaCommon.paths.pathSettings, "Configurations.list")

                    _Configurations.read()

                    AreaCommon.settings.fileName = IO.Path.Combine(AreaCommon.paths.pathSettings, _Configurations.data(0).uuid & ".settings")

                    AreaCommon.settings.read()

                    personalPublicAddress.dataPath = AreaCommon.paths.pathKeystore
                    adminPublicAddress.dataPath = AreaCommon.paths.pathKeystore

                    adminCertificate.dataPath = localPathData.Text

                    showSettings(True)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("An error occurrent during localPathData_TextChanged " & Err.Description, "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub browseLocalPathButton_Click(sender As Object, e As EventArgs) Handles browseLocalPathButton.Click
        Try
            Dim path As String = localPathData.Text

            Dim dirName As String

            If (path.Trim().Length > 0) Then
                dirName = IO.Path.GetDirectoryName(localPathData.Text)
            Else
                dirName = ""
            End If

            Dim fileName As String = IO.Path.GetFileName(localPathData.Text)

            folderBrowserDialog.SelectedPath = dirName

            If (folderBrowserDialog.ShowDialog() = DialogResult.OK) Then
                localPathData.Text = folderBrowserDialog.SelectedPath
            End If
        Catch ex As Exception
            MessageBox.Show("An error occurrent during browseLocalPath_Click " & Err.Description, "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub configurationNameCombo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles configurationNameCombo.Click
        If Not _NoWorkList Then
            Try
                If Not IsNothing(configurationNameCombo.SelectedItem) Then
                    Dim configuration As New AppSettings

                    configuration.fileName = IO.Path.Combine(AreaCommon.paths.pathSettings, configurationNameCombo.SelectedItem.value & ".settings")

                    configuration.read()

                    loadData(configuration.data)
                End If
            Catch ex As Exception
                MessageBox.Show("Error during saveConfigurationButton_Click - " & Err.Description, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub newConfigurationButton_Click(sender As Object, e As EventArgs) Handles newConfigurationButton.Click
        Try
            Dim value As String = InputBox("Enter name of a new configuration", "Request", "")
            Dim found As Boolean = False

            If (value.Length = 0) Then Return

            For Each item In configurationNameCombo.Items
                If (value.CompareTo(item.text) = 0) Then
                    found = True

                    MessageBox.Show("Name exist into collection", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    Exit For
                End If
            Next

            If Not found Then
                Dim item As New SingleConfigurationDB

                item.uuid = Guid.NewGuid.ToString()
                item.name = value

                configurationNameCombo.Items.Add(New SingleConfiguration(value, item.uuid))

                configurationNameCombo.SelectedIndex = configurationNameCombo.Items.Count - 1

                _Configurations.data.Add(item)
            End If
        Catch ex As Exception
            MessageBox.Show("Error new configuration button - " & Err.Description, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub loadDataIntoSettings(ByRef engine As AppSettings)
        Try
            With engine.data
                .dataPath = localPathData.Text

                If Not IsNothing(configurationNameCombo.SelectedItem) Then
                    .currentConfiguration = configurationNameCombo.SelectedItem.value
                Else
                    .currentConfiguration = ""
                End If
            End With

            loadDataFromUI(engine.data)
        Catch ex As Exception
            MessageBox.Show("An error occurrent during loadDataIntoSettings " & Err.Description, "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub saveConfigurationButton_Click(sender As Object, e As EventArgs) Handles saveConfigurationButton.Click
        Try
            If Not IsNothing(configurationNameCombo.SelectedItem) Then
                Dim configuration As New AppSettings

                configuration.fileName = IO.Path.Combine(AreaCommon.paths.pathSettings, configurationNameCombo.SelectedItem.value & ".settings")

                loadDataIntoSettings(configuration)

                configuration.save()
                _Configurations.save()

                AreaCommon.settings.fileName = IO.Path.Combine(AreaCommon.paths.pathSettings, AreaCommon.paths.settingFileName)

                AreaCommon.settings.data = configuration.data
                AreaCommon.settings.save()
            End If
        Catch ex As Exception
            MessageBox.Show("Error during saveConfigurationButton_Click - " & Err.Description, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub deleteConfigurationButton_Click(sender As Object, e As EventArgs) Handles deleteConfigurationButton.Click
        Try
            If Not IsNothing(configurationNameCombo.SelectedItem) Then
                If (MessageBox.Show("Do you want to delete the configuration '" & configurationNameCombo.SelectedItem.text & "' from a list ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) = DialogResult.Yes) Then
                    Dim id As String = configurationNameCombo.SelectedItem.value

                    For Each item In _Configurations.data
                        If (item.uuid.CompareTo(configurationNameCombo.SelectedItem.value) = 0) Then
                            _Configurations.data.Remove(item)

                            Exit For
                        End If
                    Next

                    _Configurations.save()

                    configurationNameCombo.Items.Remove(configurationNameCombo.SelectedItem)

                    IO.File.Delete(IO.Path.Combine(AreaCommon.paths.pathSettings, id & ".settings"))
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error during deleteConfigurationButton_Click - " & Err.Description, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub urlProtocol_Load(sender As Object, e As EventArgs) Handles urlProtocol.Load

    End Sub

    Private Sub serviceID_TextChanged(sender As Object, e As EventArgs) Handles serviceID.TextChanged
        urlProtocol.serviceId = serviceID.Text
        urlService.serviceId = serviceID.Text
    End Sub

    Private Sub ConfigurationManager_Load(sender As Object, e As EventArgs) Handles Me.Load
        showSettings()
    End Sub

    Private Sub page1Next_Click(sender As Object, e As EventArgs) Handles page1Next.Click
        mainTab.SelectTab(1)
    End Sub

    Private Sub page2Next_Click(sender As Object, e As EventArgs) Handles page2Next.Click
        mainTab.SelectTab(2)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        mainTab.SelectTab(1)
    End Sub

    Private Sub page2Previous_Click(sender As Object, e As EventArgs) Handles page2Previous.Click
        mainTab.SelectTab(0)
    End Sub

End Class