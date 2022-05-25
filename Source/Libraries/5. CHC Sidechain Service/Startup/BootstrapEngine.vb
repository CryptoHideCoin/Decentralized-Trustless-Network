Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.CommandLine
Imports CHCCommonLibrary.AreaEngine.Miscellaneous
Imports CHCSidechainServiceLibrary.AreaCommon.Main



Namespace AreaCommon.Startup

    ''' <summary>
    ''' This static class run the application
    ''' </summary>
    Public Class Bootstrap

        Private Property _DataPath As String = ""


        ''' <summary>
        ''' This method provide a read a wallet address from file
        ''' </summary>
        ''' <param name="uuid"></param>
        ''' <param name="keyStoreSecurityKey"></param>
        ''' <returns></returns>
        Private Function readWalletAddress(ByVal uuid As String, ByVal keyStoreSecurityKey As String) As String
            Try
                Dim engine As New CHCProtocolLibrary.AreaWallet.Support.WalletAddressDataEngine
                Dim dataLoaded As Boolean = False
                Dim securityValue As String = ""

                environment.log.track("StartUp.readWalletAddress", "Main", "Begin")

                engine.fileName = IO.Path.Combine(environment.paths.keyStore, uuid, "walletAddress.private")

                If (keyStoreSecurityKey.Length > 0) Then
                    engine.securityKey = keyStoreSecurityKey
                End If

                If Not engine.load() Then
                    environment.log.trackException("StartUp.readWalletAddress", "Main", "Error during load wallet")

                    Return ""
                Else
                    Return CHCProtocolLibrary.AreaWallet.Support.WalletAddressEngine.createNew(engine.data.privateRAWKey, True).official.publicKey
                End If

                environment.log.track("StartUp.readWalletAddress", "Main", "Completed")
            Catch ex As Exception
                environment.log.trackException("StartUp.readWalletAddress", "Main", "Error during read wallet address:" & ex.Message)

                Return ""
            End Try
        End Function


        ''' <summary>
        ''' This method provide to read a command line parameters
        ''' </summary>
        ''' <returns></returns>
        Public Function readParameters(Optional ByVal dataPathParameter As String = "", Optional ByVal passwordParameter As String = "", Optional ByVal securityKeyParameter As String = "") As Boolean
            Try
                Dim command As New CommandStructure
                Dim engine As New CommandBuilder

                command = engine.run()

                If (command.code.ToLower.CompareTo("force") = 0) Then
                    Try
                        _DataPath = command.parameterValue("dataPath")
                    Catch ex As Exception
                    End Try

                    Main.settingsPassword = command.parameterValue("password")
                    Main.securityKey = command.parameterValue("securityKey")
                Else
                    _DataPath = dataPathParameter
                    Main.settingsPassword = passwordParameter
                    Main.securityKey = securityKeyParameter
                End If

                Return True
            Catch ex As Exception
            End Try

            Return False
        End Function

        ''' <summary>
        ''' This method provide to print a welcome message into console
        ''' </summary>
        ''' <returns></returns>
        Public Function printWelcome(ByVal serviceName As String, ByVal applicationVersion As String) As Boolean
            environment.log.trackIntoConsole("=== Welcome into ====")
            environment.log.trackIntoConsole("Crypto Hide Coin Decentralized Trustless Network")
            environment.log.trackIntoConsole(serviceName & " Chain Engine Service")
            environment.log.trackIntoConsole("Rel." & applicationVersion)
            environment.log.trackIntoConsole("System bootstrap " & atMomentGMT() & " (gmt)")
            environment.log.trackIntoConsole()

#If DEBUG Then
            environment.log.trackIntoConsole("Debug mode on")
            environment.log.trackIntoConsole()
#End If

            Return True
        End Function

        ''' <summary>
        ''' This method provide to manage a path
        ''' </summary>
        ''' <param name="problemDescription"></param>
        ''' <returns></returns>
        Public Function managePath(ByRef problemDescription As String) As Boolean
            Try
                If (_DataPath.Trim.Length = 0) Then
                    problemDescription = "--dataPath parameter must be set!"

                    Return False
                End If
                If IO.Directory.Exists(_DataPath) Then
                    environment.paths.directoryData = _DataPath

                    If environment.paths.init(CHCProtocolLibrary.AreaSystem.VirtualPathEngine.EnumSystemType.runTime) Then
                        Return True
                    Else
                        problemDescription = "Problem during build a Path"
                    End If
                Else
                    problemDescription = _DataPath & " not found."
                End If

                Return False
            Catch ex As Exception
                problemDescription = "An error occurrent during Bootstrap.managePath " & Err.Description

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to start a runtime track
        ''' </summary>
        ''' <param name="problemDescription"></param>
        ''' <returns></returns>
        Public Function trackRuntimeStart(ByVal sideChainServiceName As String, ByRef problemDescription As String) As Boolean
            Try
                With environment.log.settings
                    .saveMode = environment.settings.logSettings.trackConfiguration
                    .changeFileEvery = environment.settings.logSettings.changeLogFileMaxNumHours
                    .changeNumberOfRegistrations = environment.settings.logSettings.changeLogFileNumRegistrations
                    .useBufferToWrite = environment.settings.logSettings.useBufferToWrite
                    .writeToFile = environment.settings.logSettings.writeToFile
                    .pathFile = IO.Path.Combine(environment.paths.system.logs, sideChainServiceName)
                    .instanceID = Guid.NewGuid.ToString
                End With

                Return True
            Catch ex As Exception
                problemDescription = "An error occurrent during Bootstrap.readSettings " & Err.Description

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to acquire IP addresses
        ''' </summary>
        ''' <returns></returns>
        Public Function acquireIPAddress() As Boolean
            Try
                environment.log.trackEnter("CHCSidechainServiceLibrary.AreaCommon.startUp.acquireIPAddress", "Main")

                environment.ipAddress.local = AreaNetwork.Address.acquireLocalIP(environment.settings.intranetMode, environment.log)
                environment.ipAddress.public = AreaNetwork.Address.acquirePublicIP(environment.log)

                environment.log.trackIntoConsole("Public IP Address = " & environment.ipAddress.public)
                environment.log.trackIntoConsole("Local IP Address = " & environment.ipAddress.local)

                environment.log.trackExit("CHCSidechainServiceLibrary.AreaCommon.startUp.acquireIPAddress", "Main")

                Return True
            Catch ex As Exception
                environment.log.trackException("CHCSidechainServiceLibrary.AreaCommon.StartUp.acquireIPAddress", "Main", "Error during Load data information:" & ex.Message)

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to Read Admin Keystore
        ''' </summary>
        ''' <returns></returns>
        Public Function readAdminKeyStore() As Boolean
            Try
                Dim uuidWallet As String = ""
                Dim settings As CHCModelsLibrary.AreaModel.Administration.Settings.SettingsSidechainServiceComplete

                If environment.iAmLocalWorkMachine Then
                    settings = environment.localWorkMachineSettings
                Else
                    settings = environment.settings
                End If

                environment.log.trackEnter("CHCSidechainServiceLibrary.AreaCommon.startUp.readAdminKeyStore", "Main")

                If (settings.publicAddress.Length >= 11) Then
                    If settings.publicAddress.StartsWith("keystoreid:") Then
                        Try
                            Dim keyStoreManager = New CHCProtocolLibrary.AreaWallet.Support.KeyStoreEngine

                            uuidWallet = settings.publicAddress.Substring(11)

                            keyStoreManager.fileName = IO.Path.Combine(environment.paths.keyStore, "keyAddress.list")

                            If keyStoreManager.read() Then
                                For Each item In keyStoreManager.data
                                    If (item.uuid.CompareTo(uuidWallet) = 0) Then
                                        environment.keys.administration.public = readWalletAddress(item.uuid, Main.securityKey)

                                        Return True
                                    End If
                                Next
                            End If
                        Catch ex As Exception
                            environment.log.trackException("CHCSidechainServiceLibrary.AreaCommon.StartUp.readAdminKeyStore", "Main", "Error during Load data keyStore :" & ex.Message)

                            Return False
                        End Try
                    End If
                End If

                environment.keys.administration.public = settings.publicAddress

                Return True
            Catch ex As Exception
                environment.log.trackException("CHCSidechainServiceLibrary.AreaCommon.StartUp.readAdminKeyStore", "Main", "Error during Load data information:" & ex.Message)

                Return False
            Finally
                environment.log.trackExit("CHCSidechainServiceLibrary.AreaCommon.startUp.readAdminKeyStore", "Main")

                environment.log.trackIntoConsole("KeyStore read successfully")
            End Try
        End Function


    End Class

End Namespace
