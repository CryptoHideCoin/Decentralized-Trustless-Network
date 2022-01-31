Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.Communication
Imports CHCCommonLibrary.AreaEngine.DataFileManagement.Encrypted





Namespace AreaCommon

    ''' <summary>
    ''' This static class run the application
    ''' </summary>
    Class ConsoleEngine

        Private Property _DataPath As String = ""
        Private Property _Service As String = ""
        Private Property _Password As String = ""
        Private Property _Address As String = ""
        Private Property _Mode As String = "console"

        Private Property _DataSettings As CHCChainServiceLibrary.AreaChain.Runtime.Models.SettingsChainService


        ''' <summary>
        ''' This method provide to read a settings
        ''' </summary>
        ''' <param name="value"></param>
        ''' <returns></returns>
        Private Function readSettings(ByVal value As CommandArguments) As Boolean
            Try
                Dim completeFileName As String = ""

                Dim engineFile As New BaseFile(Of CHCChainServiceLibrary.AreaChain.Runtime.Models.SettingsChainService)

                completeFileName = IO.Path.Combine(_DataPath, "Settings")
                completeFileName = IO.Path.Combine(completeFileName, _Service & ".Settings")

                If Not IO.File.Exists(completeFileName) Then Return False

                If (_Password.Length > 0) Then
                    engineFile.cryptoKEY = _Password
                Else
                    engineFile.noCrypt = True
                End If

                engineFile.fileName = completeFileName

                If engineFile.read() Then
                    _DataSettings = engineFile.data

                    Return True
                Else
                    Console.WriteLine("Error during readSettings")

                    Return False
                End If
            Catch ex As Exception
                Console.WriteLine("Error during readSettings - " & ex.Message)

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to test a settings
        ''' </summary>
        ''' <param name="value"></param>
        ''' <returns></returns>
        Private Function testSettings(ByRef value As CommandArguments) As Boolean
            Try
                If value.haveParameter("dataPath") Then
                    _DataPath = value.parameters("dataPath").value
                End If
                If value.haveParameter("service") Then
                    _Service = value.parameters("service").value
                End If
                If value.haveParameter("password") Then
                    _Password = value.parameters("password").value
                End If
                If value.haveParameter("mode") Then
                    _Mode = value.parameters("mode").value
                End If

                Return (_DataPath.Length > 0) And (_Service.Length > 0)
            Catch ex As Exception
                Console.WriteLine("Error during testSettings - " & ex.Message)

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to build a URL
        ''' </summary>
        ''' <param name="api"></param>
        ''' <returns></returns>
        Public Function buildURL(ByVal api As String) As String
            Dim url As String = ""
            Try
                Dim proceed As Boolean = True

                If proceed Then
                    url = _Address & "/api/" & _DataSettings.serviceID & api
                End If
            Catch ex As Exception
            End Try

            Return url
        End Function

        ''' <summary>
        ''' This method provide to read a remote log file
        ''' </summary>
        ''' <returns></returns>
        Private Function readLogFile() As Boolean
            Try
                'Dim remote As New ProxyWS(Of Models.Network.InfoAssetModel)
                Dim proceed As Boolean = True

                If proceed Then
                    'remote.url = buildURL("/system/currentLogStream/")
                End If
                If proceed Then
                    'proceed = (remote.getData() = "")
                End If
                If proceed Then
                    'proceed = (remote.data.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete)
                End If
                If proceed Then
                    'proceed = (remote.data.value.assetInformation.name.Length > 0)
                End If
                If Not proceed Then
                    Return False
                Else

                End If

                'remote = Nothing

                Return True
            Catch ex As Exception
                Console.WriteLine("Error during readLogFile - " & ex.Message)

                Return False
            End Try
        End Function


        ''' <summary>
        ''' This method provide to execute the code
        ''' </summary>
        ''' <param name="value"></param>
        ''' <returns></returns>
        Public Function execute(ByRef value As CommandArguments) As Boolean
            Dim proceed As Boolean = True

            If proceed Then
                proceed = testSettings(value)
            End If
            If proceed Then
                proceed = readSettings(value)
            End If
            If proceed Then
                Do While True
                    readLogFile()
                Loop

                Return True
            Else
                Return False
            End If
        End Function

    End Class

End Namespace
