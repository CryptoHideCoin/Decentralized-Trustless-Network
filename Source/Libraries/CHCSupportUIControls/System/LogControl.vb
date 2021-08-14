Option Compare Text
Option Explicit On



Public Class LogControl

    Public Property trackConfiguration() As CHCCommonLibrary.Support.LogEngine.TrackRuntimeModeEnum
        Get
            Select Case trackConfigurationCombo.SelectedIndex
                Case 0 : Return CHCCommonLibrary.Support.LogEngine.TrackRuntimeModeEnum.dontTrack
                Case 1 : Return CHCCommonLibrary.Support.LogEngine.TrackRuntimeModeEnum.trackAllRuntime
                Case 2 : Return CHCCommonLibrary.Support.LogEngine.TrackRuntimeModeEnum.trackOnlyMain
            End Select
            Return CHCCommonLibrary.Support.LogEngine.TrackRuntimeModeEnum.dontTrack
        End Get
        Set(value As CHCCommonLibrary.Support.LogEngine.TrackRuntimeModeEnum)
            Select Case value
                Case CHCCommonLibrary.Support.LogEngine.TrackRuntimeModeEnum.dontTrack : trackConfigurationCombo.SelectedIndex = 0
                Case CHCCommonLibrary.Support.LogEngine.TrackRuntimeModeEnum.trackAllRuntime : trackConfigurationCombo.SelectedIndex = 1
                Case CHCCommonLibrary.Support.LogEngine.TrackRuntimeModeEnum.trackOnlyMain : trackConfigurationCombo.SelectedIndex = 2
            End Select
        End Set
    End Property

    Public Property useTrackRotate() As Boolean
        Get
            Return autoCleanOptionCheck.Checked
        End Get
        Set(value As Boolean)
            autoCleanOptionCheck.Checked = value
        End Set
    End Property

    Public Property trackRotateFrequency() As CHCCommonLibrary.Support.LogRotateEngine.LogRotateConfig.FrequencyEnum
        Get
            Select Case startCleanEveryValueCombo.SelectedIndex
                Case 0 : Return CHCCommonLibrary.Support.LogRotateEngine.LogRotateConfig.FrequencyEnum.every12h
                Case 1 : Return CHCCommonLibrary.Support.LogRotateEngine.LogRotateConfig.FrequencyEnum.everyDay
            End Select
            Return CHCCommonLibrary.Support.LogRotateEngine.LogRotateConfig.FrequencyEnum.every12h
        End Get
        Set(value As CHCCommonLibrary.Support.LogRotateEngine.LogRotateConfig.FrequencyEnum)
            Select Case value
                Case CHCCommonLibrary.Support.LogRotateEngine.LogRotateConfig.FrequencyEnum.every12h : startCleanEveryValueCombo.SelectedIndex = 0
                Case CHCCommonLibrary.Support.LogRotateEngine.LogRotateConfig.FrequencyEnum.everyDay : startCleanEveryValueCombo.SelectedIndex = 1
            End Select
        End Set
    End Property

    Public Property trackRotateKeepLast() As CHCCommonLibrary.Support.LogRotateEngine.LogRotateConfig.KeepEnum
        Get
            Select Case keepOnlyRecentFileValueCombo.SelectedIndex
                Case 0 : Return CHCCommonLibrary.Support.LogRotateEngine.LogRotateConfig.KeepEnum.lastDay
                Case 1 : Return CHCCommonLibrary.Support.LogRotateEngine.LogRotateConfig.KeepEnum.lastMonth
                Case 2 : Return CHCCommonLibrary.Support.LogRotateEngine.LogRotateConfig.KeepEnum.lastWeek
                Case 3 : Return CHCCommonLibrary.Support.LogRotateEngine.LogRotateConfig.KeepEnum.lastYear
            End Select

            Return CHCCommonLibrary.Support.LogRotateEngine.LogRotateConfig.KeepEnum.lastDay
        End Get
        Set(value As CHCCommonLibrary.Support.LogRotateEngine.LogRotateConfig.KeepEnum)
            Select Case value
                Case CHCCommonLibrary.Support.LogRotateEngine.LogRotateConfig.KeepEnum.lastDay : keepOnlyRecentFileValueCombo.SelectedIndex = 0
                Case CHCCommonLibrary.Support.LogRotateEngine.LogRotateConfig.KeepEnum.lastMonth : keepOnlyRecentFileValueCombo.SelectedIndex = 1
                Case CHCCommonLibrary.Support.LogRotateEngine.LogRotateConfig.KeepEnum.lastWeek : keepOnlyRecentFileValueCombo.SelectedIndex = 2
                Case CHCCommonLibrary.Support.LogRotateEngine.LogRotateConfig.KeepEnum.lastYear : keepOnlyRecentFileValueCombo.SelectedIndex = 3
            End Select
        End Set
    End Property

    Public Property trackRotateKeepFile() As CHCCommonLibrary.Support.LogRotateEngine.LogRotateConfig.KeepFileEnum
        Get
            Select Case keepFileTypeValueCombo.SelectedIndex
                Case 0 : Return CHCCommonLibrary.Support.LogRotateEngine.LogRotateConfig.KeepFileEnum.nothingFiles
                Case 1 : Return CHCCommonLibrary.Support.LogRotateEngine.LogRotateConfig.KeepFileEnum.onlyMainTracks
            End Select

            Return CHCCommonLibrary.Support.LogRotateEngine.LogRotateConfig.KeepFileEnum.nothingFiles
        End Get
        Set(value As CHCCommonLibrary.Support.LogRotateEngine.LogRotateConfig.KeepFileEnum)
            Select Case value
                Case CHCCommonLibrary.Support.LogRotateEngine.LogRotateConfig.KeepFileEnum.nothingFiles : keepFileTypeValueCombo.SelectedIndex = 0
                Case CHCCommonLibrary.Support.LogRotateEngine.LogRotateConfig.KeepFileEnum.onlyMainTracks : keepFileTypeValueCombo.SelectedIndex = 1
            End Select
        End Set
    End Property

    Private Sub autoCleanOptionCheck_CheckedChanged(sender As Object, e As EventArgs) Handles autoCleanOptionCheck.CheckedChanged
        startCleanEveryLabel.Enabled = autoCleanOptionCheck.Checked
        startCleanEveryValueCombo.Enabled = autoCleanOptionCheck.Checked
        keepOnlyRecentFileLabel.Enabled = autoCleanOptionCheck.Checked
        keepOnlyRecentFileValueCombo.Enabled = autoCleanOptionCheck.Checked
        keepFileTypeLabel.Enabled = autoCleanOptionCheck.Checked
        keepFileTypeValueCombo.Enabled = autoCleanOptionCheck.Checked

        If Not autoCleanOptionCheck.Checked Then
            startCleanEveryValueCombo.SelectedIndex = -1
            keepOnlyRecentFileValueCombo.SelectedIndex = -1
            keepFileTypeValueCombo.SelectedIndex = -1
        End If
    End Sub

End Class
