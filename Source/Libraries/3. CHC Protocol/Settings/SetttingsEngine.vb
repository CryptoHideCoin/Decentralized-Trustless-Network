Option Explicit On
Option Compare Text

' ****************************************
' Engine: Settings Engine
' Release Engine: 1.0 
' 
' Date last successfully test: 12/05/2022
' ****************************************

Imports CHCModelsLibrary.AreaModel.Administration.Settings
Imports CHCCommonLibrary.AreaEngine.DataFileManagement.Encrypted




Namespace AreaEngine.Settings

    Public Class SettingsEngine

        Public Enum ResultReadSetting
            fileNotFound
            ReadError
            Successfull
        End Enum

        Public Property dataPath As String = ""
        Public Property serviceName As String = ""
        Public Property password As String = ""

        Public Property data As SettingsSidechainServiceComplete


        ''' <summary>
        ''' This method provide to get a log settings from a file
        ''' </summary>
        ''' <returns></returns>
        Private Function getLogSettings() As SettingsLogSidechainService
            Dim result As New SettingsLogSidechainService
            Try
                Dim completeFileName As String = ""
                Dim engineFile As New BaseFile(Of SettingsLogSidechainService)

                completeFileName = IO.Path.Combine(dataPath, "Settings")
                completeFileName = IO.Path.Combine(completeFileName, serviceName.Replace(" ", "") & "-log.Settings")

                If Not IO.File.Exists(completeFileName) Then Return New SettingsLogSidechainService

                engineFile.fileName = completeFileName

                If (password.Length > 0) Then
                    engineFile.cryptoKEY = password
                Else
                    engineFile.noCrypt = True
                End If

                If engineFile.read() Then
                    Return engineFile.data
                End If
            Catch ex As Exception
            End Try

            Return result
        End Function

        ''' <summary>
        ''' This method provide to get a performance profile settings
        ''' </summary>
        ''' <returns></returns>
        Private Function getPerformanceProfileSettings() As SettingsPerformanceProfileService
            Dim result As New SettingsPerformanceProfileService
            Try
                Dim completeFileName As String = ""
                Dim engineFile As New BaseFile(Of SettingsPerformanceProfileService)

                completeFileName = IO.Path.Combine(dataPath, "Settings")
                completeFileName = IO.Path.Combine(completeFileName, serviceName.Replace(" ", "") & "-performance.Settings")

                If Not IO.File.Exists(completeFileName) Then Return New SettingsPerformanceProfileService

                engineFile.fileName = completeFileName

                If (password.Length > 0) Then
                    engineFile.cryptoKEY = password
                Else
                    engineFile.noCrypt = True
                End If

                If engineFile.read() Then
                    Return engineFile.data
                End If
            Catch ex As Exception
            End Try

            Return result
        End Function

        ''' <summary>
        ''' This method provide to return a counter settings
        ''' </summary>
        ''' <returns></returns>
        Private Function getCounterSettings() As CounterSidechainService
            Dim result As New CounterSidechainService
            Try
                Dim completeFileName As String = ""
                Dim engineFile As New BaseFile(Of CounterSidechainService)

                completeFileName = IO.Path.Combine(dataPath, "Settings")
                completeFileName = IO.Path.Combine(completeFileName, serviceName.Replace(" ", "") & "-counter.Settings")

                If Not IO.File.Exists(completeFileName) Then Return New CounterSidechainService

                engineFile.fileName = completeFileName

                If (password.Length > 0) Then
                    engineFile.cryptoKEY = password
                Else
                    engineFile.noCrypt = True
                End If

                If engineFile.read() Then
                    Return engineFile.data
                End If
            Catch ex As Exception
            End Try

            Return result
        End Function

        Private Function getAutoMaintenanceSettings() As SettingsAutoMaintenanceSidechainService
            Dim result As New SettingsAutoMaintenanceSidechainService
            Try
                Dim completeFileName As String = ""
                Dim engineFile As New BaseFile(Of SettingsAutoMaintenanceSidechainService)

                completeFileName = IO.Path.Combine(dataPath, "Settings")
                completeFileName = IO.Path.Combine(completeFileName, serviceName.Replace(" ", "") & "-automaintenance.Settings")

                If Not IO.File.Exists(completeFileName) Then Return New SettingsAutoMaintenanceSidechainService

                engineFile.fileName = completeFileName

                If (password.Length > 0) Then
                    engineFile.cryptoKEY = password
                Else
                    engineFile.noCrypt = True
                End If

                If engineFile.read() Then
                    Return engineFile.data
                End If
            Catch ex As Exception
            End Try

            Return result
        End Function

        ''' <summary>
        ''' This method provide to save a log setting's file
        ''' </summary>
        ''' <returns></returns>
        Private Function saveLogSettings() As Boolean
            Try
                Dim completeFileName As String = ""
                Dim engineFile As New BaseFile(Of SettingsLogSidechainService)

                completeFileName = IO.Path.Combine(dataPath, "Settings")
                completeFileName = IO.Path.Combine(completeFileName, serviceName.Replace(" ", "") & "-log.Settings")

                If IO.File.Exists(completeFileName) Then
                    IO.File.Delete(completeFileName)
                End If

                If Not _data.useLog Then
                    Return True
                End If

                engineFile.fileName = completeFileName

                If (password.Length > 0) Then
                    engineFile.cryptoKEY = password
                Else
                    engineFile.noCrypt = True
                End If

                engineFile.data = _data.logSettings

                Return engineFile.save()
            Catch ex As Exception
                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to save a performance profile setting's file
        ''' </summary>
        ''' <returns></returns>
        Private Function savePerformanceProfileSettings() As Boolean
            Try
                Dim completeFileName As String = ""
                Dim engineFile As New BaseFile(Of SettingsPerformanceProfileService)

                completeFileName = IO.Path.Combine(dataPath, "Settings")
                completeFileName = IO.Path.Combine(completeFileName, serviceName.Replace(" ", "") & "-performance.Settings")

                If IO.File.Exists(completeFileName) Then
                    IO.File.Delete(completeFileName)
                End If

                If Not _data.useLog Then
                    Return True
                End If

                engineFile.fileName = completeFileName

                If (password.Length > 0) Then
                    engineFile.cryptoKEY = password
                Else
                    engineFile.noCrypt = True
                End If

                engineFile.data = _data.performanceProfile

                Return engineFile.save()
            Catch ex As Exception
                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to save a counter settings
        ''' </summary>
        ''' <returns></returns>
        Private Function saveCounterSettings() As Boolean
            Try
                Dim completeFileName As String = ""
                Dim engineFile As New BaseFile(Of CounterSidechainService)

                completeFileName = IO.Path.Combine(dataPath, "Settings")
                completeFileName = IO.Path.Combine(completeFileName, serviceName.Replace(" ", "") & "-counter.Settings")

                If IO.File.Exists(completeFileName) Then
                    IO.File.Delete(completeFileName)
                End If

                If Not _data.useLog Then
                    Return True
                End If

                engineFile.fileName = completeFileName

                If (password.Length > 0) Then
                    engineFile.cryptoKEY = password
                Else
                    engineFile.noCrypt = True
                End If

                engineFile.data = _data.counterSettings

                Return engineFile.save()
            Catch ex As Exception
                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to save an automaintenance data
        ''' </summary>
        ''' <returns></returns>
        Private Function saveAutoMaintenance() As Boolean
            Try
                Dim completeFileName As String = ""
                Dim engineFile As New BaseFile(Of SettingsAutoMaintenanceSidechainService)

                completeFileName = IO.Path.Combine(dataPath, "Settings")
                completeFileName = IO.Path.Combine(completeFileName, serviceName.Replace(" ", "") & "-automaintenance.Settings")

                If IO.File.Exists(completeFileName) Then
                    IO.File.Delete(completeFileName)
                End If

                If Not _data.useLog Then
                    Return True
                End If

                engineFile.fileName = completeFileName

                If (password.Length > 0) Then
                    engineFile.cryptoKEY = password
                Else
                    engineFile.noCrypt = True
                End If

                engineFile.data = _data.autoMaintenance

                Return engineFile.save()
            Catch ex As Exception
                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to load a setting from a file
        ''' </summary>
        ''' <returns></returns>
        Public Function read() As ResultReadSetting
            Try
                Dim completeFileName As String = ""
                Dim engineFile As New BaseFile(Of SettingsSidechainServiceBase)

                completeFileName = IO.Path.Combine(dataPath, "Settings")
                completeFileName = IO.Path.Combine(completeFileName, serviceName.Replace(" ", "") & ".Settings")

                If Not IO.File.Exists(completeFileName) Then Return ResultReadSetting.fileNotFound

                engineFile.fileName = completeFileName

                If (password.Length > 0) Then
                    engineFile.cryptoKEY = password
                Else
                    engineFile.noCrypt = True
                End If

                If engineFile.read() Then
                    data = New SettingsSidechainServiceComplete

                    With engineFile.data
                        data.clientCertificate = .clientCertificate
                        data.internalName = .internalName
                        data.intranetMode = .intranetMode
                        data.middlePath = .middlePath
                        data.networkReferement = .networkReferement
                        data.publicAddress = .publicAddress
                        data.publicPort = .publicPort
                        data.secureChannel = .secureChannel
                        data.serviceID = .serviceID
                        data.serviceMode = .serviceMode
                        data.servicePort = .servicePort
                        data.sideChainName = .sideChainName
                        data.staticIP = .staticIP
                        data.useAdminMessage = .useAdminMessage
                        data.useAlert = .useAlert
                        data.useAutomaintenance = .useAutomaintenance
                        data.useEventRegistry = .useEventRegistry
                        data.useLog = .useLog
                        data.useProfile = .useProfile
                        data.useRequestCounter = .useRequestCounter

                        data.logSettings = getLogSettings()
                        data.performanceProfile = getPerformanceProfileSettings()
                        data.counterSettings = getCounterSettings()
                        data.autoMaintenance = getAutoMaintenanceSettings()
                    End With

                    Return ResultReadSetting.Successfull
                Else
                    Return ResultReadSetting.ReadError
                End If
            Catch ex As Exception
                Return ResultReadSetting.ReadError
            End Try
        End Function

        ''' <summary>
        ''' This method provide to save the information file
        ''' </summary>
        ''' <returns></returns>
        Public Function write() As Boolean
            Try
                Dim completeFileName As String = ""
                Dim engineFile As New BaseFile(Of SettingsSidechainServiceBase)
                Dim proceed As Boolean = True

                completeFileName = IO.Path.Combine(dataPath, "Settings")
                completeFileName = IO.Path.Combine(completeFileName, serviceName.Replace(" ", "") & ".Settings")

                engineFile.fileName = completeFileName
                engineFile.data = data.getServiceBase()

                If (_password.Length = 0) Then
                    engineFile.noCrypt = True
                Else
                    engineFile.cryptoKEY = _password
                End If

                If proceed Then
                    proceed = engineFile.save()
                End If
                If proceed Then
                    proceed = saveLogSettings()
                End If
                If proceed Then
                    proceed = savePerformanceProfileSettings()
                End If
                If proceed Then
                    proceed = saveCounterSettings()
                End If
                If proceed Then
                    proceed = saveAutoMaintenance()
                End If

                Return proceed
            Catch ex As Exception
                Return False
            End Try
        End Function

    End Class

End Namespace
