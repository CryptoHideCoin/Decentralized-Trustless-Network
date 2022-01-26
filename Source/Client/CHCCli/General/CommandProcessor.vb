Option Compare Text
Option Explicit On





Namespace AreaCommon

    Public Enum CommandEnumeration
        undefined
        info
        help
        release
        updateSystemDate
        currentTime
        chainSettings
    End Enum

    Public Class CommandProcessor

        Public command As New CommandArguments

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
            Console.WriteLine("Crypto Hide Coin Decentralized Trustless Network - CLI - Client Console")
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
            Console.WriteLine("-help                Show this list")
            Console.WriteLine("-info                Show an info of this application")
            Console.WriteLine("-release             Show a relase of this application")
            Console.WriteLine("-updateSystemDate    Show this list")
            Console.WriteLine("-currentTime         Show the current time")
            Console.WriteLine("-chainSettings       Open a Chain Settings Editor")

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

                path = Environment.CurrentDirectory
                path = IO.Directory.GetParent(path).FullName
                path = IO.Path.Combine(path, "Chain Settings")

                If IO.Directory.Exists(path) Then
                    path = IO.Path.Combine(path, "CHCChainSettings.exe")

                    If Not IO.File.Exists(path) Then
                        Console.WriteLine("Error: the application '" & path & "' is not exist")
                    Else
                        Process.Start(path, "-force --chain:" & command.parameters("chain").value & " --dataPath:" & command.parameters("dataPath").value)
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
            Select Case key.Trim()
                Case "release" : Return CommandEnumeration.release
                Case "info" : Return CommandEnumeration.info
                Case "help" : Return CommandEnumeration.help
                Case "updatesystemdate" : Return CommandEnumeration.updateSystemDate
                Case "currentTime" : Return CommandEnumeration.currentTime
                Case "chainSettings" : Return CommandEnumeration.chainSettings
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
                Case CommandEnumeration.chainSettings : response = executeChainSettings()
            End Select

            If response Then
                If command.havePauseParameter() Then
                    Console.WriteLine("")
                    Console.WriteLine("Press a key to continue")
                    Console.ReadKey()
                End If
            End If

            Return response
        End Function

    End Class

End Namespace
