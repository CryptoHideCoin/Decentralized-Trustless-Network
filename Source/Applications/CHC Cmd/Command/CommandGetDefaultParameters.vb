Option Compare Text
Option Explicit On

Imports CHCCmd.AreaCommon.Models
Imports CHCCommonLibrary.AreaEngine.CommandLine




Namespace AreaCommon.Command

    ''' <summary>
    ''' This class manage the command Get Default Parameters
    ''' </summary>
    Public Class CommandGetDefaultParameters : Implements CommandModel

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

                Console.WriteLine("Default parameters:")
                Console.WriteLine()

                If (ApplicationCommon.defaultParameters.data.Count > 0) Then
                    printRow("Name", "Value")

                    For Each item In ApplicationCommon.defaultParameters.data
                        numCar = item.name.Length + item.value.Length

                        If (numCar > maxCar) Then
                            maxCar = numCar
                        End If
                    Next

                    Console.WriteLine((Space(30 + maxCar + 2)).ToString.Replace(" ", "-"))

                    For Each item In ApplicationCommon.defaultParameters.data
                        printRow(item.name, item.value)
                    Next

                    Console.WriteLine()
                    Console.WriteLine(ApplicationCommon.defaultParameters.data.Count & " item(s)")
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
