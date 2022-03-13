Option Compare Text
Option Explicit On

Imports CHCCmd.AreaCommon.Models
Imports CHCCommonLibrary.AreaEngine.CommandLine




Namespace AreaCommon.Command

    ''' <summary>
    ''' This class manage the command Get Environment List
    ''' </summary>
    Public Class CommandGetEnvironmentList : Implements CommandModel

        Private Property _Command As CommandStructure


        Private Property CommandModel_command As CommandStructure Implements CommandModel.command
            Get
                Return _Command
            End Get
            Set(value As CommandStructure)
                _Command = value
            End Set
        End Property

        Private Function printRow(ByVal colA As String, ByVal colB As String, ByVal colC As String) As Boolean
            Console.WriteLine(colA.PadRight(20) & colB.PadRight(7) & colC)

            Return True
        End Function

        Private Function CommandModel_run() As Boolean Implements CommandModel.run
            Try
                Dim path As String = AreaEngine.EnvironmentRepositoryEngine.searchUserEnvironmentPath()
                Dim environmentRepositoryPath As String = IO.Path.Combine(path, "Environments.path")
                Dim environmentPath As String = ""
                Dim collection As List(Of AreaEngine.EnvironmentData)
                Dim maxCar As Integer, numCar As Integer

                If IO.File.Exists(environmentRepositoryPath) Then
                    environmentPath = IO.File.ReadAllText(environmentRepositoryPath)

                    environmentPath = IO.Path.Combine(environmentPath, "Environments.list")

                    collection = AreaEngine.EnvironmentsEngine.getList(environmentPath)

                    Console.WriteLine("Environment list:")
                    Console.WriteLine()

                    If (collection.Count > 0) Then
                        printRow("Name", "Active", "Path")

                        For Each item In collection
                            numCar = item.name.Length + item.path.Length + 7

                            If (numCar > maxCar) Then
                                maxCar = numCar
                            End If
                        Next

                        Console.WriteLine((Space(20 + maxCar + 7)).ToString.Replace(" ", "-"))

                        For Each item In collection
                            printRow(item.name, IIf(item.active, "X", " "), item.path)
                        Next
                        Console.WriteLine()
                        Console.WriteLine(collection.Count & " item(s)")
                    Else
                        Console.WriteLine("No item found")
                    End If
                Else
                    Console.WriteLine("Error: Environment Repository not set")
                End If

                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

    End Class

End Namespace
