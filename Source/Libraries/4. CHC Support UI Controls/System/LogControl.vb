Option Compare Text
Option Explicit On

' ****************************************
' File: Log Control
' Release Engine: 1.0 
' 
' Date last successfully test: 06/10/2021
' ****************************************

Imports CHCModelsLibrary.AreaModel.Log
Imports CHCModelsLibrary.AreaModel.Log.LogRotateConfig









Public Class LogControl

    ''' <summary>
    ''' This property get/let the Track Configuration value
    ''' </summary>
    ''' <returns></returns>
    Public Property trackConfiguration() As TrackRuntimeModeEnum
        Get
            Select Case trackConfigurationCombo.SelectedIndex
                Case 0 : Return TrackRuntimeModeEnum.neverTrace
                Case 1 : Return TrackRuntimeModeEnum.trackAll
                Case 2 : Return TrackRuntimeModeEnum.trackOnlyBootstrapAndError
            End Select
            Return TrackRuntimeModeEnum.neverTrace
        End Get
        Set(value As TrackRuntimeModeEnum)
            Select Case value
                Case TrackRuntimeModeEnum.neverTrace : trackConfigurationCombo.SelectedIndex = 0
                Case TrackRuntimeModeEnum.trackAll : trackConfigurationCombo.SelectedIndex = 1
                Case TrackRuntimeModeEnum.trackOnlyBootstrapAndError : trackConfigurationCombo.SelectedIndex = 2
            End Select
        End Set
    End Property

    ''' <summary>
    ''' This property provide to get / set the max number of hours to maintain the file (frequency)
    ''' </summary>
    ''' <returns></returns>
    Public Property maxNumHours As Integer
        Get
            If IsNumeric(maxHourMaintain.text) Then
                Return maxHourMaintain.text
            Else
                Return 0
            End If
        End Get
        Set(value As Integer)
            maxHourMaintain.text = value
        End Set
    End Property

    ''' <summary>
    ''' This property provide to get / set the max number of registrations in the file (frequency)
    ''' </summary>
    ''' <returns></returns>
    Public Property maxNumberOfRegistrations() As Integer
        Get
            If IsNumeric(maxRegistrationNumbers.text) Then
                Return maxRegistrationNumbers.text
            Else
                Return 0
            End If
        End Get
        Set(value As Integer)
            maxRegistrationNumbers.text = value
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
    Public Property trackRotateFrequency() As FrequencyEnum
        Get
            Select Case startCleanEveryValueCombo.SelectedIndex
                Case 0 : Return FrequencyEnum.every12h
                Case 1 : Return FrequencyEnum.everyDay
            End Select
            Return FrequencyEnum.every12h
        End Get
        Set(value As FrequencyEnum)
            Select Case value
                Case FrequencyEnum.every12h : startCleanEveryValueCombo.SelectedIndex = 0
                Case FrequencyEnum.everyDay : startCleanEveryValueCombo.SelectedIndex = 1
            End Select
        End Set
    End Property

    ''' <summary>
    ''' This property get/let the Track Rotate Keep Last value
    ''' </summary>
    ''' <returns></returns>
    Public Property trackRotateKeepLast() As KeepEnum
        Get
            Select Case keepOnlyRecentFileValueCombo.SelectedIndex
                Case 0 : Return KeepEnum.lastDay
                Case 1 : Return KeepEnum.lastMonth
                Case 2 : Return KeepEnum.lastWeek
                Case 3 : Return KeepEnum.lastYear
            End Select

            Return KeepEnum.lastDay
        End Get
        Set(value As KeepEnum)
            Select Case value
                Case KeepEnum.lastDay : keepOnlyRecentFileValueCombo.SelectedIndex = 0
                Case KeepEnum.lastMonth : keepOnlyRecentFileValueCombo.SelectedIndex = 1
                Case KeepEnum.lastWeek : keepOnlyRecentFileValueCombo.SelectedIndex = 2
                Case KeepEnum.lastYear : keepOnlyRecentFileValueCombo.SelectedIndex = 3
            End Select
        End Set
    End Property

    ''' <summary>
    ''' This property get/let the Track Rotate Keep File value
    ''' </summary>
    ''' <returns></returns>
    Public Property trackRotateKeepFile() As KeepFileEnum
        Get
            Select Case keepFileTypeValueCombo.SelectedIndex
                Case 0 : Return KeepFileEnum.nothingFiles
                Case 1 : Return KeepFileEnum.onlyMainTracks
            End Select

            Return KeepFileEnum.nothingFiles
        End Get
        Set(value As KeepFileEnum)
            Select Case value
                Case KeepFileEnum.nothingFiles : keepFileTypeValueCombo.SelectedIndex = 0
                Case KeepFileEnum.onlyMainTracks : keepFileTypeValueCombo.SelectedIndex = 1
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
