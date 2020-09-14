Option Compare Text
Option Explicit On

Imports System.IO.Compression
Imports CHCProtocolLibrary.AreaUpdate




Public Class Main

    Private _PackageFileName As String = ""
    Private _SilentMode As Boolean = False



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


    Private Function addSinglePackage(ByVal fileName As String, ByVal dirName As String, ByVal releaseValue As String) As PackageRelease

        Dim singleFile As New PackageRelease

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
        filePackage += ".Package"

        rootPath = IO.Path.Combine(rootPath, "Upgrades")

        Return IO.Path.Combine(rootPath, filePackage)

    End Function


    Private Sub processWork(ByVal rootPath As String)

        Dim package As New PackageReleaseEngine
        Dim packageList As New List(Of PackageRelease)
        Dim processDir As String, fileName As String, packageFileName As String = makePackageFile(rootPath)

        Try

            packageList.Add(addSinglePackage("package", "(exclude)", createCompleteRelease()))

            Using fileStreamCompact As IO.FileStream = IO.File.Create(packageFileName)

                Using zipArchive As New ZipArchive(fileStreamCompact, ZipArchiveMode.Create)

                    For Each itemDir In IO.Directory.GetDirectories(rootPath)

                        processDir = IO.Path.GetFileName(itemDir).ToLower

                        If ((processDir = "script") Or (processDir = "bin")) Then

                            For Each itemFile In IO.Directory.GetFiles(itemDir)

                                fileName = IO.Path.GetFileName(itemFile).ToLower()

                                If ((fileName.CompareTo("define.path") <> 0) And (fileName.CompareTo("package.release") <> 0)) Then

                                    With FileVersionInfo.GetVersionInfo(itemFile)
                                        packageList.Add(addSinglePackage(fileName, StrConv(processDir, VbStrConv.ProperCase), .FileVersion))

                                        zipArchive.CreateEntryFromFile(itemFile, processDir & "\" & IO.Path.GetFileName(itemFile))
                                    End With

                                End If

                            Next

                        End If

                    Next

                End Using

            End Using

            package.data = packageList
            package.fileName = IO.Path.Combine(rootPath, "Bin", "Package.release")

            If package.save() Then

                Application.DoEvents()

                Using fileStreamCompact As IO.FileStream = IO.File.Open(packageFileName, IO.FileMode.Open)
                    Using zipArchive As New ZipArchive(fileStreamCompact, ZipArchiveMode.Update)
                        zipArchive.CreateEntryFromFile(package.fileName, "bin\Package.release")
                    End Using
                End Using

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

            If (IO.Path.GetFileName(IO.Path.GetDirectoryName(Application.ExecutablePath)).ToLower() = "upgrades") Then
                rootPath = IO.Directory.GetParent(IO.Directory.GetParent(Application.ExecutablePath).FullName).FullName
            Else
                MessageBox.Show("The main path to process is missing", "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

        Else
            rootPath = mainPathToProcessValue.Text
        End If

        If IO.Directory.Exists(rootPath) Then
            processWork(rootPath)
            End
        End If

    End Sub


    Private Sub cancelButton_Click(sender As Object, e As EventArgs) Handles cancelButton.Click

        Me.Dispose()

    End Sub


    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If (IO.Path.GetFileName(IO.Path.GetDirectoryName(Application.ExecutablePath)).ToLower.CompareTo("upgrades") = 0) Then
            mainPathToProcessValue.Text = IO.Directory.GetParent(IO.Directory.GetParent(Application.ExecutablePath).FullName).FullName
        End If

    End Sub


    Private Sub extractTo(ByVal mainPath As String)

        Try
            Dim fileCompleteToExtract As String

            Using archive As ZipArchive = ZipFile.OpenRead(_PackageFileName)

                For Each entry As ZipArchiveEntry In archive.Entries

                    fileCompleteToExtract = IO.Path.Combine(mainPathToProcessValue.Text, entry.FullName)

                    If Not IO.Directory.Exists(IO.Path.GetDirectoryName(fileCompleteToExtract)) Then
                        IO.Directory.CreateDirectory(StrConv(IO.Path.GetDirectoryName(fileCompleteToExtract), VbStrConv.ProperCase))
                    End If

                    If IO.File.Exists(fileCompleteToExtract) Then

                        If _SilentMode Then
                            entry.ExtractToFile(fileCompleteToExtract, True)
                        Else
                            If (MessageBox.Show("Some file (example " & fileCompleteToExtract & ") exist in the directory." & vbNewLine & vbNewLine & "Overwrite all?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes) Then
                                _SilentMode = True
                            Else
                                End
                            End If
                            entry.ExtractToFile(fileCompleteToExtract, True)
                        End If

                    Else
                        entry.ExtractToFile(fileCompleteToExtract)
                    End If

                Next

            End Using

        Catch ex As Exception
            MessageBox.Show("An error occurrent during extractTo " & Err.Description, "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


    Private Sub Main_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        Try

            Dim parameter As String = ""

            If (Environment.GetCommandLineArgs.Count = 1) Then
                Me.Opacity = 100
            Else

                _PackageFileName = Environment.CommandLine
                _PackageFileName = _PackageFileName.Replace(Chr(34) & Environment.GetCommandLineArgs(0) & Chr(34), "").Trim()

                For numPar As Integer = 0 To Environment.GetCommandLineArgs.Count - 1

                    parameter = Environment.GetCommandLineArgs(numPar)

                    If (parameter = "/forceoverwrite") Then

                        _SilentMode = True
                        _PackageFileName = _PackageFileName.Replace(parameter, "")

                    End If

                Next

                _PackageFileName = _PackageFileName.Replace(Chr(34), "")

                If IO.File.Exists(_PackageFileName) Then

                    If (mainPathToProcessValue.Text.ToString.Length > 0) Then
                        extractTo(mainPathToProcessValue.Text)
                    End If

                End If

                End

            End If

        Catch ex As Exception
            MessageBox.Show("An error occurrent during Main_Shown " & Err.Description, "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub


End Class
