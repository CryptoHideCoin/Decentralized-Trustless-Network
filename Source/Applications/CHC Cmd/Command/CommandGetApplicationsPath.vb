Option Compare Text
Option Explicit On

Imports CHCCmd.AreaCommon.Models
Imports CHCCommonLibrary.AreaEngine.CommandLine




Namespace AreaCommon.Command

    ''' <summary>
    ''' This class manage the command Get Applications Path
    ''' </summary>
    Public Class CommandGetApplicationsPath : Implements CommandModel

        Private Property _Command As CommandStructure


        Private Property CommandModel_command As CommandStructure Implements CommandModel.command
            Get
                Return _Command
            End Get
            Set(value As CommandStructure)
                _Command = value
            End Set
        End Property

        Private Function printRow(ByVal colA As String, ByVal colB As String) As Boolean
            Console.WriteLine(colA.PadRight(30) & colB)

            Return True
        End Function

        Private Function CommandModel_run() As Boolean Implements CommandModel.run
            Try
                Dim maxCar As Integer, numCar As Integer

                AreaEngine.ApplicationPathEngine.init()

                Console.WriteLine("Applications path list:")
                Console.WriteLine()

                If (ApplicationCommon.appConfigurations.data.Count > 0) Then
                    printRow("Application", "Complete file path")

                    For Each item In ApplicationCommon.appConfigurations.data
                        numCar = item.rootPath.Length + item.directoryName.Length + item.applicationName.Length

                        If (numCar > maxCar) Then
                            maxCar = numCar
                        End If
                    Next

                    Console.WriteLine((Space(30 + maxCar + 2)).ToString.Replace(" ", "-"))

                    For Each item In ApplicationCommon.appConfigurations.data
                        printRow(item.applicationReferement.ToString(), item.rootPath & "\" & item.directoryName & "\" & item.applicationName)
                    Next

                    Console.WriteLine()
                    Console.WriteLine(ApplicationCommon.appConfigurations.data.Count & " item(s)")
                Else
                    Console.WriteLine("No item found")
                End If

                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

    End Class

End Namespace

Public Class CommandGetApplicationsPath

End Class
