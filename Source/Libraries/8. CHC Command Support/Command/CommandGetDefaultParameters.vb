Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.CommandLine




Namespace AreaCommon.Command

    ''' <summary>
    ''' This class manage the command Get Default Parameters
    ''' </summary>
    Public Class CommandGetDefaultParameters : Implements Models.CommandModel

        Private Property _Command As CommandStructure

        Public Event WriteLine(ByVal message As String) Implements Models.CommandModel.WriteLine
        Public Event Process(ByVal applicationName As String, ByVal commandLine As String) Implements Models.CommandModel.Process
        Public Event IntegrityApplication(ByVal fileName As String) Implements Models.CommandModel.IntegrityApplication
        Public Event RaiseError(ByVal message As String) Implements Models.CommandModel.RaiseError
        Public Event ReadKey() Implements Models.CommandModel.ReadKey


        Private Property CommandModel_command As CommandStructure Implements Models.CommandModel.command
            Get
                Return _Command
            End Get
            Set(value As CommandStructure)
                _Command = value
            End Set
        End Property

        Private Function printRow(ByVal colA As String, ByVal colB As String) As Boolean
            RaiseEvent WriteLine(colA.PadRight(30) & colB)

            Return True
        End Function

        Private Function CommandModel_run() As Boolean Implements Models.CommandModel.run
            Try
                Dim maxCar As Integer, numCar As Integer

                AreaEngine.ApplicationPathEngine.init()

                RaiseEvent WriteLine("Default parameters:")
                RaiseEvent WriteLine("")

                If (ApplicationCommon.defaultParameters.data.Count > 0) Then
                    printRow("Name", "Value")

                    For Each item In ApplicationCommon.defaultParameters.data
                        numCar = item.name.Length + item.value.Length

                        If (numCar > maxCar) Then
                            maxCar = numCar
                        End If
                    Next

                    RaiseEvent WriteLine((Space(30 + maxCar + 2)).ToString.Replace(" ", "-"))

                    For Each item In ApplicationCommon.defaultParameters.data
                        printRow(item.name, item.value)
                    Next

                    RaiseEvent WriteLine("")
                    RaiseEvent WriteLine(ApplicationCommon.defaultParameters.data.Count & " item(s)")
                Else
                    RaiseEvent WriteLine("No item found")
                End If

                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

    End Class

End Namespace
