Option Compare Text
Option Explicit On




Namespace AreaCommon.Startup

    ''' <summary>
    ''' This static class run the application
    ''' </summary>
    Module Bootstrap

        Private Property _DataPath As String = ""
        Private Property _Password As String = ""
        Private Property _ParameterExist As Boolean = False

        ''' <summary>
        ''' This method provide to read a command line parameters
        ''' </summary>
        ''' <returns></returns>
        Private Function readCommandLine() As Boolean
            Try
                Dim commandManager As New CommandLine.CommandProcessor

                commandManager.command = (New CommandLine.CommandLineDecoder).run()

                If commandManager.execute() Then
                    _DataPath = commandManager.command.parameterValue("dataPath")
                    _Password = commandManager.command.parameterValue("password")

                    _ParameterExist = True

                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                MessageBox.Show("An error occurrent during moduleMain.bootstrap.readCommandLine " & Err.Description, "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to print a welcome message into console
        ''' </summary>
        ''' <returns></returns>
        Private Function printWelcome() As Boolean
            Log.trackIntoConsole("=== Welcome into ====")
            Log.trackIntoConsole("Crypto Hide Coin Decentralized Trustless Network")
            Log.trackIntoConsole("Template Chain Engine Service")
            Log.trackIntoConsole("Rel." & My.Application.Info.Version.ToString())
            Log.trackIntoConsole("System bootstrap " & atMomentGMT() & " (gmt)")
            Log.trackIntoConsole()

#If DEBUG Then
            Log.trackIntoConsole("Debug mode on")
            Log.trackIntoConsole()
#End If

            state.serviceInformation.currentStatus = CHCProtocolLibrary.AreaCommon.Models.Service.InternalServiceInformation.EnumInternalServiceState.starting
        End Function


        ''' <summary>
        ''' This method provide to prepare the application to the startup
        ''' </summary>
        ''' <returns></returns>
        Public Function run() As Boolean
            Try
                Dim proceed As Boolean = True

                If proceed Then
                    proceed = readCommandLine()
                End If
                If proceed Then
                    proceed = printWelcome()
                End If

                ' Print welcome

                ' Read the settings

                ' Build Path application

                ' Read a keyStore

                Return proceed
            Catch ex As Exception
                MessageBox.Show("An error occurrent during moduleMain.bootstrap " & Err.Description, "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)

                Return False
            End Try
        End Function

    End Module

End Namespace
