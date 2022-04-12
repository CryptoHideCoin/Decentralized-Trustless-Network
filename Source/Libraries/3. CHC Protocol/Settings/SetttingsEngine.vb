Option Explicit On
Option Compare Text

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
                End With

                Return ResultReadSetting.Successfull
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

                completeFileName = IO.Path.Combine(dataPath, "Settings")
                completeFileName = IO.Path.Combine(completeFileName, serviceName.Replace(" ", "") & ".Settings")

                engineFile.fileName = completeFileName
                engineFile.data = data

                If (_password.Length = 0) Then
                    engineFile.noCrypt = True
                Else
                    engineFile.cryptoKEY = _password
                End If

                Return engineFile.save()
            Catch ex As Exception
                Return False
            End Try
        End Function

    End Class

End Namespace
