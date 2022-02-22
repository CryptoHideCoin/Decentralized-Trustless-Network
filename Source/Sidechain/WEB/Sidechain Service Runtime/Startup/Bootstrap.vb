Option Compare Text
Option Explicit On

Imports CHCSidechainServiceLibrary.AreaCommon.Main



Namespace AreaCommon.Startup

    ''' <summary>
    ''' This static class run the application
    ''' </summary>
    Module Bootstrap

        Private Property _Bootstrap As New CHCSidechainServiceLibrary.AreaCommon.Startup.Bootstrap



        ''' <summary>
        ''' This method provide to acquire the service information
        ''' </summary>
        ''' <returns></returns>
        Private Function acquireServiceInformation() As Boolean
            environment.log.trackIntoConsole("Load service information")

            Try
                environment.log.trackEnter("startUp.acquireServiceInformation")

                With state.serviceInformation
                    .chainName = CUSTOM_ChainServiceName

                    If environment.settings.intranetMode Then
                        .addressIP = environment.ipAddress.local
                    Else
                        .addressIP = environment.ipAddress.public
                    End If

                    .intranetMode = environment.settings.intranetMode
                    .netWorkName = environment.settings.networkReferement
                    .platformHost = "Microsoft Windows Desktop Application service"
                    .softwareRelease = My.Application.Info.Version.ToString()

                    If environment.settings.secureChannel Then
                        .completeAddress = "https://"
                    Else
                        .completeAddress = "http://"
                    End If

                    .completeAddress += .addressIP & "/api/" & environment.settings.serviceID

                    .currentStatus = CHCProtocolLibrary.AreaCommon.Models.Service.InternalServiceInformation.EnumInternalServiceState.starting
                End With

                serviceInformation = state.serviceInformation

                environment.log.trackIntoConsole("Acquire service information")

                environment.log.trackExit("startUp.acquireServiceInformation")

                Return True
            Catch ex As Exception
                environment.log.trackException("StartUp.loadDataInformation", "Error during Load data information:" & ex.Message)

                Return False
            Finally
                environment.log.trackExit("startUp.loadDataInformation")
            End Try
        End Function


        ''' <summary>
        ''' This method provide to prepare the application to the startup
        ''' </summary>
        ''' <returns></returns>
        Public Function run() As Boolean
            Try
                Dim problemDescription As String
                Dim proceed As Boolean = True

                If proceed Then
                    'If Not _Bootstrap.readParameters(HttpContext.Current.Server.MapPath("~/App_Data/"), "", "") Then
                    If Not _Bootstrap.readParameters("e:\data", "", "") Then
                        Console.WriteLine("Problem during read a parameters")

                        proceed = False
                    End If
                End If
                If proceed Then
                    If Not _Bootstrap.printWelcome(CUSTOM_ChainServiceName, My.Application.Info.Version.ToString()) Then
                        Console.WriteLine("Problem during print a welcome")

                        proceed = False
                    End If
                End If
                If proceed Then
#Disable Warning BC42030
                    If Not _Bootstrap.managePath(problemDescription) Then
#Enable Warning BC42030
                        Console.WriteLine(problemDescription)

                        proceed = False
                    End If
                End If
                If proceed Then
                    With environment.readSettings(CUSTOM_ChainServiceName)
                        proceed = .successful

                        If Not proceed Then
                            Console.WriteLine(problemDescription)

                            proceed = False
                        End If
                    End With
                End If
                If proceed Then
                    If Not _Bootstrap.trackRuntimeStart(problemDescription) Then
                        Console.WriteLine(problemDescription)

                        proceed = False
                    End If
                End If
                If proceed Then
                    proceed = _Bootstrap.acquireIPAddress()
                End If
                If proceed Then
                    proceed = acquireServiceInformation()
                End If
                If proceed Then
                    proceed = _Bootstrap.readAdminKeyStore()
                End If
                If proceed Then
                    environment.log.trackIntoConsole("Root paths set " & environment.paths.directoryData)
                    environment.log.trackIntoConsole("Service GUID = " & environment.settings.serviceID)
                End If

                Return proceed
            Catch ex As Exception
                Console.WriteLine("An error occurrent during moduleMain.bootstrap " & Err.Description)

                Return False
            End Try
        End Function

    End Module

End Namespace
