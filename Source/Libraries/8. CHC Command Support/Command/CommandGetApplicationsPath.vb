Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.CommandLine




Namespace AreaCommon.Command

    ''' <summary>
    ''' This class manage the command Get Applications Path
    ''' </summary>
    Public Class CommandGetApplicationsPath : Implements CommandModel

        Private Property _Command As CommandStructure

        Public Event WriteLine(ByVal message As String) Implements CommandModel.WriteLine
        Public Event Process(ByVal applicationName As String, ByVal commandLine As String) Implements CommandModel.Process
        Public Event IntegrityApplication(ByVal fileName As String) Implements CommandModel.IntegrityApplication
        Public Event RaiseError(ByVal message As String) Implements CommandModel.RaiseError
        Public Event ReadKey() Implements CommandModel.ReadKey



        Private Property CommandModel_command As CommandStructure Implements CommandModel.command
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

        Private Function CommandModel_run() As Boolean Implements CommandModel.run
            Try
                Dim maxCar As Integer, numCar As Integer

                AreaEngine.ApplicationPathEngine.init()

                RaiseEvent WriteLine("Applications path list:")
                RaiseEvent WriteLine("")

                If (ApplicationCommon.appConfigurations.data.Count > 0) Then
                    printRow("Application", "Complete file path")

                    For Each item In ApplicationCommon.appConfigurations.data
                        numCar = item.rootPath.Length + item.directoryName.Length + item.applicationName.Length

                        If (numCar > maxCar) Then
                            maxCar = numCar
                        End If
                    Next

                    RaiseEvent WriteLine((Space(30 + maxCar + 2)).ToString.Replace(" ", "-"))

                    For Each item In ApplicationCommon.appConfigurations.data
                        printRow(item.applicationReferement.ToString(), item.rootPath & "\" & item.directoryName & "\" & item.applicationName)
                    Next

                    RaiseEvent WriteLine("")
                    RaiseEvent WriteLine(ApplicationCommon.appConfigurations.data.Count & " item(s)")
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
