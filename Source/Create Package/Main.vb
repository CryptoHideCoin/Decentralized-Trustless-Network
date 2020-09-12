Option Compare Text
Option Explicit On

Imports System.IO.Compression


Public Class Main


    Private Sub browseMainPathToProcess_Click(sender As Object, e As EventArgs) Handles browseMainPathToProcess.Click

        Try

            Dim path As String = mainPathToProcessValue.Text

            Dim dirName As String

            If (path.Trim().Length > 0) Then

                dirName = IO.Path.GetDirectoryName(mainPathToProcessValue.Text)

            Else

                dirName = ""

            End If

            Dim fileName As String = IO.Path.GetFileName(mainPathToProcessValue.Text)

            folderBrowserDialog.SelectedPath = dirName

            If (folderBrowserDialog.ShowDialog() = DialogResult.OK) Then

                mainPathToProcessValue.Text = folderBrowserDialog.SelectedPath

            End If

        Catch ex As Exception

            MessageBox.Show("An error occurrent during browseMainPathToProcess_Click " & Err.Description, "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub


    Private Function addSinglePackage(ByVal fileName As String, ByVal dirName As String, ByVal releaseValue As String) As CHCProtocol.AreaUpdate.PackageRelease

        Dim singleFile As New CHCProtocol.AreaUpdate.PackageRelease

        singleFile.fileName = fileName
        singleFile.relativePath = dirName
        singleFile.release = releaseValue

        Return singleFile

    End Function

    Private Function createCompleteRelease() As String

        Return packageReleaseMajorValue.Text & "." & packageReleaseMinorValue.Text & "." & packageReleaseBuildValue.Text & "." & packageReleaseRevisionValue.Text

    End Function


    Private Function makePackageFile(ByVal rootPath As String) As String

        Dim filePackage As String = packageNameValue.Text

        filePackage += createCompleteRelease()
        filePackage += "." & packageReleaseRevisionValue.Text
        filePackage += ".zip"

        rootPath = IO.Path.Combine(rootPath, "Upgrades")

        Return IO.Path.Combine(rootPath, filePackage)

    End Function


    Private Sub processWork(ByVal rootPath As String)

        Dim package As New CHCProtocol.AreaUpdate.PackageReleaseEngine
        Dim packageList As New List(Of CHCProtocol.AreaUpdate.PackageRelease)
        Dim processDir As String

        Try

            packageList.Add(addSinglePackage("Package", "(exclude)", createCompleteRelease()))

            Using fileStreamCompact As IO.FileStream = IO.File.Create(makePackageFile(rootPath))

                Using zipArchive As New ZipArchive(fileStreamCompact, ZipArchiveMode.Create)

                    For Each itemDir In IO.Directory.GetDirectories(rootPath)

                        processDir = IO.Path.GetFileName(itemDir).ToLower

                        If ((processDir = "script") Or (processDir = "bin")) Then

                            For Each itemFile In IO.Directory.GetFiles(itemDir)

                                With FileVersionInfo.GetVersionInfo(itemFile)
                                    packageList.Add(addSinglePackage(IO.Path.GetFileName(itemFile), processDir, .FileVersion))

                                    zipArchive.CreateEntryFromFile(itemFile, processDir & "\" & IO.Path.GetFileName(itemFile))
                                End With

                            Next

                        End If

                    Next

                End Using

            End Using

            package.data = packageList
            package.fileName = IO.Path.Combine(rootPath, "Bin", "Master.Package")

            If package.save() Then
                MessageBox.Show("Package file created", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("An error occurrent during package.save ", "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MessageBox.Show("An error occurrent during processWork " & Err.Description, "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


    Private Sub processButton_Click(sender As Object, e As EventArgs) Handles processButton.Click

        If (packageReleaseMajorValue.Text.ToString.Trim.Length = 0) Then

            MessageBox.Show("The release is missing", "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return

        ElseIf Not IsNumeric(packageReleaseMajorValue.Text.ToString) Then

            MessageBox.Show("The release is wrong", "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return

        End If

        Dim rootPath As String

        If (mainPathToProcessValue.Text.ToString.Trim.Length = 0) Then

            If (IO.Path.GetDirectoryName(Application.ExecutablePath).ToLower() = "upgrades") Then

                rootPath = IO.Directory.GetParent(Application.ExecutablePath).FullName

            Else

                MessageBox.Show("The main path to process is missing", "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return

            End If

        Else

            rootPath = mainPathToProcessValue.Text

        End If

        If IO.Directory.Exists(rootPath) Then

            processWork(rootPath)

        End If

    End Sub

    Private Sub cancelButton_Click(sender As Object, e As EventArgs) Handles cancelButton.Click

        Me.Dispose()

    End Sub



End Class
