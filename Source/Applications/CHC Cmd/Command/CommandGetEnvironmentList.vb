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

        Private Function CommandModel_run() As Boolean Implements CommandModel.run
            Try
                Dim path As String = AreaEngine.EnvironmentRepositoryEngine.searchUserEnvironmentPath()
                Dim environmentRepositoryPath As String = IO.Path.Combine(path, "environment.path")
                Dim environmentPath As String = ""
                Dim collection As List(Of AreaEngine.EnvironmentData)

                If IO.File.Exists(environmentRepositoryPath) Then
                    environmentPath = IO.File.ReadAllText(environmentRepositoryPath)

                    environmentPath = IO.Path.Combine(environmentPath, "Environments.list")

                    collection = AreaEngine.EnvironmentsEngine.getList(environmentPath)

                    Console.WriteLine("Environment list:")
                    Console.WriteLine()

                    If (collection.Count > 0) Then
                        For Each item In collection
                            Console.WriteLine("{0} - {1} - active:{2}", item.name, item.path, item.active)
                        Next
                        Console.WriteLine()
                        Console.WriteLine(collection.Count & " item(s)")
                    Else
                        Console.WriteLine("No items found")
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
