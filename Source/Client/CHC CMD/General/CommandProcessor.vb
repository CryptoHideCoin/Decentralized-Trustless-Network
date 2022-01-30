Option Compare Text
Option Explicit On





Namespace AreaCommon

    ''' <summary>
    ''' This enumeration contain the command of this application
    ''' </summary>
    Public Enum CommandEnumeration
        undefined
        info
        help
        release
        updateSystemDate
        currentTime
        chainServiceSettings
    End Enum

    ''' <summary>
    ''' This class contain the processor of a command line
    ''' </summary>
    Public Class CommandProcessor

        Public Property command As New CommandArguments

        ''' <summary>
        ''' This method provide to execute a release command
        ''' </summary>
        ''' <returns></returns>
        Private Function executeRelease() As Boolean
            Console.WriteLine(My.Application.Info.Version.ToString())

            Return True
        End Function

        ''' <summary>
        ''' This method provide to execute an info of this application
        ''' </summary>
        ''' <returns></returns>
        Private Function executeInfo() As Boolean
            Console.WriteLine("Crypto Hide Coin Decentralized Trustless Network - Command Line Executor")
            Console.WriteLine("Free open source software")
            Console.WriteLine("(2022) Crypto Technology Alliances")
            Console.WriteLine("Release " & My.Application.Info.Version.ToString())

            Return True
        End Function

        ''' <summary>
        ''' This method provide to execute a help command
        ''' </summary>
        ''' <returns></returns>
        Private Function executeHelp() As Boolean
            Console.WriteLine("Help list command")
            Console.WriteLine("=================")
            Console.WriteLine()
            Console.WriteLine("-help                    Show this list")
            Console.WriteLine("-info                    Show an info of this application")
            Console.WriteLine("-release                 Show a relase of this application")
            Console.WriteLine("-updateSystemDate        Show this list")
            Console.WriteLine("-currentTime             Show the current time")
            Console.WriteLine("-chainServiceSettings    Open a Chain Settings Editor")
            Console.WriteLine("   --service:            Set a service name")
            Console.WriteLine("   --dataPath:           Set a data path")
            Console.WriteLine("   --showAsFile          Show the content in a notepad")
            Console.WriteLine("   --password:           Set a password to decode")

            Return True
        End Function

        ''' <summary>
        ''' This method provide to execute update system date
        ''' </summary>
        ''' <returns></returns>
        Private Function executeUpdateSystemDate() As Boolean
            Try
                Process.Start("CMD", "/C net start w32time & w32tm /resync /force")
                Console.WriteLine("System date updated")

                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to execute a current time
        ''' </summary>
        ''' <returns></returns>
        Private Function executeCurrentTime() As Boolean
            Try
                Console.WriteLine("Local time = " & Now.ToString())
                Console.WriteLine("GMT time   = " & CHCCommonLibrary.AreaEngine.Miscellaneous.atMomentGMT)
                Console.WriteLine("Timestamp  = " & CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime)

                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to execute a chain settings
        ''' </summary>
        ''' <returns></returns>
        Private Function executeChainSettings() As Boolean
            Try
                Dim path As String = ""
                Dim parameterService As String = ""
                Dim parameterDataPath As String = ""
                Dim parameterPassword As String = ""

                If command.haveParameter("service") Then
                    parameterService = "--service:" & command.parameters("service").value
                End If
                If command.haveParameter("dataPath") Then
                    parameterDataPath = "--dataPath:" & command.parameters("dataPath").value
                End If
                If command.haveParameter("password") Then
                    parameterPassword = "--password:" & command.parameters("password").value
                End If
                If command.haveParameter("showAsFile") Then
                    If (parameterService.Length = 0) Or (parameterDataPath.Length = 0) Then
                        Console.WriteLine("Error: insufficient parameters")
                    End If

                    path = IO.Path.Combine(command.parameters("dataPath").value, "Settings")
                    path = IO.Path.Combine(path, command.parameters("service").value & ".Settings")

                    If Not IO.File.Exists(path) Then Return False
                    Process.Start("notepad.exe", path)

                    Return True
                End If

                path = Environment.CurrentDirectory
                path = IO.Directory.GetParent(path).FullName
                path = IO.Path.Combine(path, "Chain Settings")

                If IO.Directory.Exists(path) Then
                    path = IO.Path.Combine(path, "CHCChainSettings.exe")

                    If Not IO.File.Exists(path) Then
                        Console.WriteLine("Error: the application '" & path & "' is not exist")
                    Else
                        Process.Start(path, "-force " & parameterService & " " & parameterDataPath)
                    End If
                Else
                    Console.WriteLine("Error: the directory '" & path & "' is not exist")
                End If

                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function


        ''' <summary>
        ''' This method provide to decode into command enumeration
        ''' </summary>
        ''' <param name="key"></param>
        ''' <returns></returns>
        Public Shared Function getCommandCode(ByVal key As String) As CommandEnumeration
            Select Case key.ToLower.Trim()
                Case "release" : Return CommandEnumeration.release
                Case "info" : Return CommandEnumeration.info
                Case "help" : Return CommandEnumeration.help
                Case "updatesystemdate" : Return CommandEnumeration.updateSystemDate
                Case "currenttime" : Return CommandEnumeration.currentTime
                Case "chainservicesettings" : Return CommandEnumeration.chainServiceSettings
                Case Else : Return CommandEnumeration.undefined
            End Select
        End Function

        ''' <summary>
        ''' This method provide to execute a command
        ''' </summary>
        ''' <returns></returns>
        Public Function execute() As Boolean
            Dim response As Boolean = False

            Select Case command.code
                Case CommandEnumeration.undefined : Console.WriteLine()
                Case CommandEnumeration.info : response = executeInfo()
                Case CommandEnumeration.help : response = executeHelp()
                Case CommandEnumeration.release : response = executeRelease()
                Case CommandEnumeration.updateSystemDate : response = executeUpdateSystemDate()
                Case CommandEnumeration.currentTime : response = executeCurrentTime()
                Case CommandEnumeration.chainServiceSettings : response = executeChainSettings()
            End Select

            If response Then
                If command.haveParameter("pause") Then
                    Console.WriteLine("")
                    Console.WriteLine("Press a key to continue")
                    Console.ReadKey()
                End If
            End If

            Return response
        End Function

    End Class

End Namespace
