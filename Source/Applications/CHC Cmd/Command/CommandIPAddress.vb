Option Compare Text
Option Explicit On

Imports CHCCmd.AreaCommon.Models
Imports CHCCommonLibrary.AreaEngine.CommandLine
Imports CHCSidechainServiceLibrary.AreaNetwork




Namespace AreaCommon.Command

    ''' <summary>
    ''' This class manage the command IP Address 
    ''' </summary>
    Public Class CommandIPAddress : Implements CommandModel

        Private Property _Command As CommandStructure

        Private Property CommandModel_command As CommandStructure Implements CommandModel.command
            Get
                Return _Command
            End Get
            Set(value As CommandStructure)
                _Command = value
            End Set
        End Property

        Private Function CommandModel_run() As Boolean Implements CommandModel.run
            Dim localIP As String = Address.acquireLocalIP(False)
            Dim publicIP As String = Address.acquirePublicIP

            If (publicIP.Trim().Length = 0) Then
                If Not Address.isPrivateNetwork(localIP) Then
                    publicIP = localIP

                    localIP = Address.acquireLocalIP(True)

                    If Not Address.isPrivateNetwork(localIP) Then
                        localIP = "localhost"
                    End If
                Else
                    publicIP = "---"
                End If
            ElseIf Not Address.isPrivateNetwork(localIP) Then
                localIP = Address.acquireLocalIP(True)

                If Not Address.isPrivateNetwork(localIP) Then
                    localIP = "localhost"
                End If
            End If

            Console.WriteLine("Local IP Address = " & localIP)
            Console.WriteLine("Public IP Address = " & publicIP)

            Return True
        End Function

    End Class

End Namespace
