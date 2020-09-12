Option Compare Text
Option Explicit On


Namespace AreaSystem


    Public Class VirtualPathEngine

        Public Enum EnumSystemType

            admin
            loader
            runTime

        End Enum

        Public Class SystemPath

            Public Property path As String = ""
            Public Property counters As String = ""
            Public Property events As String = ""
            Public Property logs As String = ""

        End Class

        Public Class DefinePath

            Public Property path As String = ""

            Public Property assets As String = ""
            Public Property TaransactionChain As String = ""
            Public Property pricesList As String = ""
            Public Property refundPlans As String = ""
            Public Property protocols As String = ""

        End Class

        Public Class TransactionChainPath

            Public Property path As String = ""

            Public Property sideChain As String = ""
            Public Property defines As New DefinePath
            Public Property ledger As String = ""
            Public Property messages As String = ""
            Public Property rejecteds As String = ""
            Public Property requests As String = ""
            Public Property state As String = ""
            Public Property temporally As String = ""

        End Class

        Public Const settingsFolderName As String = "Settings"

        Public Property settingFileName As String = ""

        Public Property mainData As String = ""
        Public Property system As String = ""
        Public Property settings As New SystemPath
        Public Property transactionChain As TransactionChainPath



        Private Function manageSinglePath(ByVal pathParent As String, ByVal pathDirectory As String, Optional ByVal pathOptional As String = "") As String

            Try

                If (pathOptional.Length = 0) Then
                    pathParent = IO.Path.Combine(pathParent, pathDirectory)
                Else
                    pathParent = IO.Path.Combine(pathParent, pathDirectory, pathOptional)
                End If

                If Not IO.Directory.Exists(pathParent) Then
                    IO.Directory.CreateDirectory(pathParent)
                End If

                Return pathParent

            Catch ex As Exception

                Return ""

            End Try

        End Function


        Public Function init(ByVal [type] As EnumSystemType, Optional ByVal sideChainName As String = "") As Boolean

            Try

                If (mainData.Trim.Length > 0) Then

                    Dim folderName As String

                    Select Case type
                        Case EnumSystemType.admin
                            settingFileName = "AdminService.Settings"
                            folderName = "Admin"
                        Case EnumSystemType.runTime
                            settingFileName = "RunTimeService.Settings"
                            folderName = "RunTime"
                        Case Else
                            settingFileName = "LoaderService.Settings"
                            folderName = "Loader"
                    End Select

                    system = manageSinglePath(mainData, "System")

                    With settings

                        .path = manageSinglePath(mainData, settingsFolderName)

                        .counters = manageSinglePath(system, "Counters", folderName)
                        .events = manageSinglePath(system, "Events", folderName)
                        .logs = manageSinglePath(system, "Logs", folderName)

                    End With

                    With transactionChain

                        .path = manageSinglePath(mainData, "TransactionChain")

                        With .defines

                            .path = manageSinglePath(transactionChain.path, "Define")
                            .assets = manageSinglePath(transactionChain.defines.path, "Assets")
                            .pricesList = manageSinglePath(transactionChain.defines.path, "PricesList")
                            .protocols = manageSinglePath(transactionChain.defines.path, "Protocols")
                            .refundPlans = manageSinglePath(transactionChain.defines.path, "refundPlans")
                            .TaransactionChain = manageSinglePath(transactionChain.defines.path, "TaransactionChain")

                        End With

                        .sideChain = manageSinglePath(transactionChain.path, sideChainName)

                        .ledger = manageSinglePath(transactionChain.sideChain, "Ledger")
                        .messages = manageSinglePath(transactionChain.sideChain, "Messages")
                        .rejecteds = manageSinglePath(transactionChain.sideChain, "Rejecteds")
                        .requests = manageSinglePath(transactionChain.sideChain, "Requests")
                        .state = manageSinglePath(transactionChain.sideChain, "State")
                        .temporally = manageSinglePath(transactionChain.sideChain, "Temporally")

                    End With

                End If

            Catch ex As Exception

            End Try

            Return True

        End Function


        Private Function trySettingsPath(ByVal path As String) As Boolean

            Try

                path = IO.Path.Combine(path, "define.path")

                Return IO.File.Exists(path)

            Catch ex As Exception

            End Try

            Return False

        End Function


        Private Function tryWritePath(ByVal path As String) As Boolean

            path = IO.Path.Combine(path, "define.path")

            Try

                IO.File.WriteAllText(path, "Test")

                If IO.File.Exists(path) Then

                    IO.File.Delete(path)

                    Return True

                End If

            Catch ex As Exception

            End Try

            Return False

        End Function


        Private Function testPath(ByVal found As Boolean, ByRef path As String, ByVal newPath As String, Optional ByVal trySettings As Boolean = False) As Boolean

            If Not found Then

                path = newPath

                If trySettings Then

                    Return trySettingsPath(path)

                Else

                    Return tryWritePath(path)

                End If

            End If

            Return found

        End Function


        Public Function searchDefinePath() As String

            Dim found As Boolean = False
            Dim path As String = ""

            Try

                found = testPath(found, path, Application.StartupPath, True)
                found = testPath(found, path, Application.LocalUserAppDataPath, True)
                found = testPath(found, path, Application.UserAppDataPath, True)

                If found Then

                    Return path

                End If

            Catch ex As Exception

            End Try

            Return ""

        End Function


        Public Function readDefinePath() As String

            Try

                Dim path As String = searchDefinePath()

                If (path.Length > 0) Then

                    Return IO.File.ReadAllText(IO.Path.Combine(searchDefinePath, "define.path"))

                End If

            Catch ex As Exception

            End Try

            Return ""

        End Function


        Public Sub updateRootPath(ByVal dataPath As String)

            Dim found As Boolean = False
            Dim path As String = ""

            Try

                found = testPath(found, path, Application.StartupPath, True)
                found = testPath(found, path, Application.LocalUserAppDataPath, True)
                found = testPath(found, path, Application.UserAppDataPath, True)
                found = testPath(found, path, Application.StartupPath)
                found = testPath(found, path, Application.LocalUserAppDataPath)
                found = testPath(found, path, Application.UserAppDataPath)

                If found Then

                    IO.File.WriteAllText(IO.Path.Combine(path, "define.path"), dataPath)

                End If

            Catch ex As Exception

            End Try

        End Sub


    End Class


End Namespace