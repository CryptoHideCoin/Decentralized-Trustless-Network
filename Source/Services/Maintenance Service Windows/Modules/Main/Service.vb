Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine
Imports CHCCommonLibrary.AreaEngine.Communication
Imports CHCProtocolLibrary.AreaCommon.Models.Settings
Imports CHCProtocolLibrary.AreaSystem
Imports CHCProtocolLibrary.AreaCommon.Models
Imports CHCServerSupportLibrary.Support


Namespace AreaCommon


    Module Service


        ''' <summary>
        ''' This method provide to create an internal structure's of state service
        ''' </summary>
        Sub buildServices()

            Dim newData As AppState.ServiceStatus

            Try
                log.track("Service.buildServices", "Begin")

                With state.adminStateData
                    .applicationName = moduleMain.adminFileService
                    .runTimeAutoStart = True
                    .serviceName = "AdminService"
                    .status = EnumStateApplication.inStarting
                    .secureProtocol = settings.data.serviceAdmin.useSecure
                    .url = settings.data.serviceAdmin.url
                End With

                With state.loaderStateData
                    .applicationName = moduleMain.loaderFileService
                    .runTimeAutoStart = False
                    .serviceName = "LoaderService"
                    .status = EnumStateApplication.inStarting
                    .secureProtocol = settings.data.serviceAdmin.useSecure
                    .url = "localhost:" & state.loaderPort
                End With

                For Each value In settings.data.services

                    newData = New AppState.ServiceStatus()

                    newData.applicationName = value.applicationPath
                    newData.url = value.url
                    newData.secureProtocol = value.protocolSecure
                    newData.status = EnumStateApplication.waitingToStart
                    newData.runTimeAutoStart = settings.data.autoStart

                    state.serviceStateData.Add(newData)

                Next

                log.track("Service.buildServices", "Complete")
            Catch ex As Exception
                log.track("Service.buildServices", "Error:" & ex.Message, "fatal")

                closeApplication()
            End Try

        End Sub


        ''' <summary>
        ''' This method provide to check a new update online
        ''' </summary>
        Public Sub checkNewUpdates()

            ' Cosa faccio ?!?

            ' Intanto vedo se il source degli aggiornamenti è statico o è peer2peer

            ' ho la build di tutti i services, quindi recupero le attuali versioni di ogni DApps

            ' a questo punto interrogo la fonte remota

            ' in base alla risposta che ottengo, se ci sono nuovi aggiornamenti compilo il file locale per la news all'amministratore

            ' passo e chiudo

        End Sub


        Private Sub checkAuthorizations()

            ' Cosa faccio ?!?

            ' Controllo se l'amministratore in qualche modo ha dato l'autorizzazione su qualche aggiornamento da passare

        End Sub


        Private Sub downloadUpdates()

            ' Cosa faccio ?!?

            ' Mi scorro l'elenco degli aggiornamenti da scaricare e mi scarico il primo della lista

        End Sub


        Private Sub applyUpdates()

            ' Cosa faccio ?!?

            ' Scorro lo stato ed avvio la procedura per effettuare l'aggiornamento

        End Sub


        Public Sub resumeState()

            Try
                log.track("Service.resumeState", "Begin")

                Dim installedPackageListEngine As New CHCProtocolLibrary.AreaUpdate.ModuleListEngine
                Dim singlePackageEngine As CHCProtocolLibrary.AreaUpdate.PackageReleaseEngine
                Dim singleModule As CHCProtocolLibrary.AreaUpdate.SingleModuleInformation

                state.InstalledModuleList.information.relativePath = Windows.Forms.Application.ExecutablePath
                state.InstalledModuleList.information.fileName = "InstalledModules.list"

                installedPackageListEngine.fileName = IO.Path.Combine(state.InstalledModuleList.information.relativePath, state.InstalledModuleList.information.fileName)

                If Not IO.File.Exists(installedPackageListEngine.fileName) Then

                    Dim tmp As New CHCProtocolLibrary.AreaUpdate.PackageRelease

                    tmp.fileName = "Package.release"
                    tmp.relativePath = Windows.Forms.Application.ExecutablePath

                    installedPackageListEngine.data.Add(tmp)

                End If

                If installedPackageListEngine.read() Then

                    For Each singlePackage In installedPackageListEngine.data

                        singlePackageEngine = New CHCProtocolLibrary.AreaUpdate.PackageReleaseEngine

                        singlePackageEngine.fileName = IO.Path.Combine(singlePackage.relativePath, singlePackage.fileName)

                        If singlePackageEngine.read Then
                            singleModule = New CHCProtocolLibrary.AreaUpdate.SingleModuleInformation

                            singleModule.information.fileName = singlePackage.fileName
                            singleModule.information.relativePath = singlePackage.relativePath
                            singleModule.component = singlePackageEngine.data

                            state.InstalledModuleList.component.Add(singleModule)
                        End If

                    Next

                End If

            Catch ex As Exception
                log.track("Service.resumeState", "Error:" & ex.Message, "fatal")

                closeApplication()
            Finally
                log.track("Service.resumeState", "Complete")
            End Try

        End Sub


        ''' <summary>
        ''' This method provide to recall the Starter Service
        ''' </summary>
        Public Sub recallLoader()

            Try

                log.track("Service.recallStarter", "Begin")

                Dim handShakeEngine As New ProxyWS(Of General.BooleanModel)

                handShakeEngine.url = settings.data.serviceAdmin.composeURL("api/v1.0/System/handShake/?serviceAdministrative=false&serviceEngine=false&serviceUpdate=true&certificateValue=" & state.serviceLoaderCertificate)

                If handShakeEngine.getData() Then

                    If Not handShakeEngine.data.value Then

                        log.track("Service.recallLoader", "Cannot connection with the service or wrong certificate", "fatal")

                    End If

                End If

            Catch ex As Exception
                log.track("Service.recallLoader", "Error:" & ex.Message, "fatal")

                closeApplication()
            Finally
                log.track("Service.recallLoader", "Complete")
            End Try

        End Sub



    End Module


End Namespace
