Option Compare Text
Option Explicit On

Imports CHCCmd.AreaCommon.Models
Imports CHCModelsLibrary.AreaModel.Network.Response
Imports CHCCommonLibrary.AreaEngine.CommandLine
Imports CHCCommonLibrary.AreaEngine.Communication






Namespace AreaCommon.Command

    ''' <summary>
    ''' This class manage the command Test Serve 
    ''' </summary>
    Public Class CommandTestServe : Implements CommandModel

        Private Property _Command As CommandStructure

        Private Property _ParameterService As String = ""
        Private Property _ParameterDataPath As String = ""
        Private Property _ParameterPassword As String = ""
        Private Property _ParameterAddress As String = ""
        Private Property _ParameterSecureChannel As Boolean = False
        Private Property _ParameterServicePort As Integer = 0
        Private Property _ParameterServiceID As String = ""


        Private Property CommandModel_command As CommandStructure Implements CommandModel.command
            Get
                Return _Command
            End Get
            Set(value As CommandStructure)
                _Command = value
            End Set
        End Property

        ''' <summary>
        ''' This method provide to read a parameters
        ''' </summary>
        ''' <returns></returns>
        Private Function readParameters() As Boolean
            Try
                If _Command.haveParameter("service") Then
                    _ParameterService = _Command.parameterValue("service")
                ElseIf (ApplicationCommon.defaultParameters.getParameter("service").Length > 0) Then
                    _ParameterService = ApplicationCommon.defaultParameters.getParameter("service")
                Else
                    Console.WriteLine("Service parameter not found!")

                    Return False
                End If
                If _Command.haveParameter("dataPath") Then
                    _ParameterDataPath = _Command.parameterValue("dataPath".ToLower())
                ElseIf (ApplicationCommon.defaultParameters.getParameter("dataPath").Length > 0) Then
                    _ParameterDataPath = ApplicationCommon.defaultParameters.getParameter("dataPath")
                Else
                    Console.WriteLine("DataPath parameter not found!")

                    Return False
                End If
                If _Command.haveParameter("password") Then
                    _ParameterPassword = _Command.parameterValue("password")
                ElseIf (ApplicationCommon.defaultParameters.getParameter("password").Length > 0) Then
                    _ParameterPassword = ApplicationCommon.defaultParameters.getParameter("password")
                End If
                If _Command.haveParameter("address") Then
                    _ParameterAddress = _Command.parameterValue("address")
                ElseIf (ApplicationCommon.defaultParameters.getParameter("address").Length > 0) Then
                    _ParameterAddress = ApplicationCommon.defaultParameters.getParameter("address")
                Else
                    _ParameterAddress = "localhost"
                End If

                Return True
            Catch ex As Exception
                Console.WriteLine("Problem during execute readParameters")

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to read a settings
        ''' </summary>
        ''' <returns></returns>
        Private Function readSettings() As Boolean
            Try
                Dim completeFileName As String = ""
                Dim engine As New CHCProtocolLibrary.AreaEngine.Settings.SettingsEngine

                engine.dataPath = _ParameterDataPath
                engine.serviceName = _ParameterService
                engine.password = _ParameterPassword

                Select Case engine.read()
                    Case CHCProtocolLibrary.AreaEngine.Settings.SettingsEngine.ResultReadSetting.fileNotFound
                        Console.WriteLine("Missing  setting's File ")

                        Return False
                    Case CHCProtocolLibrary.AreaEngine.Settings.SettingsEngine.ResultReadSetting.ReadError
                        Console.WriteLine("Error during read file")

                        Return False
                    Case CHCProtocolLibrary.AreaEngine.Settings.SettingsEngine.ResultReadSetting.Successfull
                        _ParameterSecureChannel = engine.data.secureChannel
                        _ParameterServicePort = engine.data.servicePort
                        _ParameterServiceID = engine.data.serviceID

                        If (engine.data.staticIP.Trim().Length > 0) Then
                            _ParameterAddress = engine.data.staticIP
                        End If

                        Return True
                End Select

                Return True
            Catch ex As Exception
                Console.WriteLine("Problem during execute readSettings")

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to build a URL
        ''' </summary>
        ''' <param name="api"></param>
        ''' <param name="ipAddress"></param>
        ''' <returns></returns>
        Private Function buildURL(ByVal api As String) As String
            Dim url As String = ""
            Try
                Dim proceed As Boolean = True

                If proceed Then
                    If _ParameterSecureChannel Then
                        url += "https"
                    Else
                        url += "http"
                    End If
                End If
                If proceed Then
                    If (_ParameterAddress.Length = 0) Then
                        _ParameterAddress += "localhost"
                    End If

                    _ParameterAddress += ":" & _ParameterServicePort
                End If
                If proceed Then
                    url += "://" & _ParameterAddress & "/api"
                End If
                If proceed Then
                    If (_ParameterServiceID.Length > 0) Then
                        url += "/" & _ParameterServiceID & api
                    Else
                        url += api
                    End If
                End If
            Catch ex As Exception
            End Try

            Return url
        End Function

        ''' <summary>
        ''' This method provide to test service found
        ''' </summary>
        ''' <returns></returns>
        Private Function serviceFound() As Boolean
            Try
                Dim remote As New ProxyWS(Of RemoteResponse)
                Dim proceed As Boolean = True

                If proceed Then
                    remote.url = buildURL("/service/test/")
                End If
                If proceed Then
                    proceed = (remote.getData() = "")
                End If
                If proceed Then
                    Return (remote.data.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete)
                Else
                    Console.WriteLine("Error during getData")
                End If

                Return proceed
            Catch exFile As system.io.FileLoadException
                IntegrityApplication.executeRepairNewton(exFile.FileName)

                Return False
            Catch ex As Exception
                Console.WriteLine("Error during serviceFound - " & ex.Message)

                Return False
            End Try
        End Function

        Private Function CommandModel_run() As Boolean Implements CommandModel.run
            Try
                Dim accessKey As String = ""
                Dim proceed As Boolean = True

                If proceed Then
                    proceed = readParameters()
                End If
                If proceed Then
                    proceed = readSettings()
                End If
                If proceed Then
                    If Not serviceFound() Then
                        Console.WriteLine("Problem during test service")

                        proceed = False
                    Else
                        Console.WriteLine(Chr(34) & _ParameterService & Chr(34) & " tested OK")
                    End If
                End If

                Return proceed
            Catch ex As Exception
                Return False
            End Try
        End Function

    End Class

End Namespace
