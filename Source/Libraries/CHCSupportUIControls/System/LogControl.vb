Option Compare Text
Option Explicit On

' ****************************************
' File: Log Control
' Release Engine: 1.0 
' 
' Date last successfully test: 06/10/2021
' ****************************************









Public Class LogControl

    ''' <summary>
    ''' This property get/let the Track Configuration value
    ''' </summary>
    ''' <returns></returns>
    Public Property trackConfiguration() As CHCCommonLibrary.Support.LogEngine.TrackRuntimeModeEnum
        Get
            Select Case trackConfigurationCombo.SelectedIndex
                Case 0 : Return CHCCommonLibrary.Support.LogEngine.TrackRuntimeModeEnum.dontTrackEver
                Case 1 : Return CHCCommonLibrary.Support.LogEngine.TrackRuntimeModeEnum.trackAll
                Case 2 : Return CHCCommonLibrary.Support.LogEngine.TrackRuntimeModeEnum.trackOnlyBootstrapAndError
            End Select
            Return CHCCommonLibrary.Support.LogEngine.TrackRuntimeModeEnum.dontTrackEver
        End Get
        Set(value As CHCCommonLibrary.Support.LogEngine.TrackRuntimeModeEnum)
            Select Case value
                Case CHCCommonLibrary.Support.LogEngine.TrackRuntimeModeEnum.dontTrackEver : trackConfigurationCombo.SelectedIndex = 0
                Case CHCCommonLibrary.Support.LogEngine.TrackRuntimeModeEnum.trackAll : trackConfigurationCombo.SelectedIndex = 1
                Case CHCCommonLibrary.Support.LogEngine.TrackRuntimeModeEnum.trackOnlyBootstrapAndError : trackConfigurationCombo.SelectedIndex = 2
            End Select
        End Set
    End Property
    ''' <summary>
    ''' This property get/let the Use Track Rotate
    ''' </summary>
    ''' <returns></returns>
    Public Property useTrackRotate() As Boolean
        Get
            Return autoCleanOptionCheck.Checked
        End Get
        Set(value As Boolean)
            autoCleanOptionCheck.Checked = value
        End Set
    End Property
    ''' <summary>
    ''' This property get/let the Track Rotate Frequency value
    ''' </summary>
    ''' <returns></returns>
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
    ''' <summary>
    ''' This property get/let the Track Rotate Keep Last value
    ''' </summary>
    ''' <returns></returns>
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
    ''' <summary>
    ''' This property get/let the Track Rotate Keep File value
    ''' </summary>
    ''' <returns></returns>
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
    ''' <summary>
    ''' This property get/let the CheckChanged on AutoCleanOptionCheck
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
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
