Option Compare Text
Option Explicit On





Namespace AreaCommon

    Public Enum CommandEnumeration
        undefined
        info
        help
        release
        updateSystemDate
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
            Console.WriteLine("Crypto Hide Coin Decentralized Trustless Network - Console Client")
            Console.WriteLine("Free open source software")
            Console.WriteLine("(2022) Crypto Technology Alliances")

            Return "Rel. " & executeRelease()
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
            Console.WriteLine()

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
                Case Else : Return CommandEnumeration.undefined
            End Select
        End Function

        ''' <summary>
        ''' This method provide to execute a command
        ''' </summary>
        ''' <returns></returns>
        Public Function execute() As Boolean
            Select Case command.code
                Case CommandEnumeration.undefined : Console.WriteLine()
                Case CommandEnumeration.info : Return executeInfo()
                Case CommandEnumeration.help : Return executeHelp()
                Case CommandEnumeration.release : Return executeRelease()
                Case CommandEnumeration.updateSystemDate : Return executeUpdateSystemDate()
            End Select

            Return True
        End Function

    End Class

End Namespace
