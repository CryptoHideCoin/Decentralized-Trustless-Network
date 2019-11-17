Option Compare Text
Option Explicit On



Public Class entityEditor


    Private _Data As CHCElementDefinitionEngineLibrary.Models.EntityDefinitionModel
    Private _Engine As New CHCCommonLibrary.CHCEngines.Common.BaseFileDB(Of CHCElementDefinitionEngineLibrary.Models.EntityDefinitionModel)
    Private _NoSave As Boolean = False
    Private _CommandLineEngine As New CHCCommonLibrary.CHCEngines.Miscellaneous.CommandLineParameters




    Private Function readData() As Boolean

        Try

            Dim proceed As Boolean = False

            proceed = (completePathValue.Text.ToString().Length > 0)

            If proceed Then

                proceed = IO.File.Exists(completePathValue.Text.ToString())

            End If

            If proceed Then

                _Engine.fileName = completePathValue.Text

                If _Engine.read() Then

                    _Data = _Engine.data

                    Return True

                End If

            End If

        Catch ex As Exception

        End Try

        Return False

    End Function



    Private Sub completePathValue_TextChanged(sender As Object, e As EventArgs) Handles completePathValue.TextChanged

        Try

            If Not readData() Then

                _Data = New CHCElementDefinitionEngineLibrary.Models.EntityDefinitionModel

            End If

            CompileAllData()

        Catch ex As Exception

        End Try

    End Sub



    Private Sub browseButton_Click(sender As Object, e As EventArgs) Handles browseButton.Click

        Dim path As String = completePathValue.Text

        Dim dirName As String

        If (path.Trim().Length > 0) Then

            dirName = IO.Path.GetDirectoryName(completePathValue.Text)

        Else

            dirName = ""

        End If

        Dim fileName As String = IO.Path.GetFileName(completePathValue.Text)

        saveBrowser.InitialDirectory = dirName
        saveBrowser.FileName = fileName

        If (saveBrowser.ShowDialog() = DialogResult.OK) Then

            completePathValue.Text = saveBrowser.FileName
            readData()

        End If

    End Sub



    Private Function updateData() As Boolean

        Try

            If _NoSave Then Return True
            If (completePathValue.Text.ToString.Length = 0) Then

                identityValue.Text = "NO FILE"
                Return False

            End If

            If (identityValue.Text.ToString.Length = 64) Then

                _Engine.fileName = completePathValue.Text.ToString()

                If _Engine.save() Then

                    Return True

                End If

            End If

        Catch ex As Exception

            MessageBox.Show("Error " & ex.Message, "Error")

        End Try

        Return False

    End Function



    Private Sub typeValue_SelectedIndexChanged(sender As Object, e As EventArgs) Handles typeValue.SelectedIndexChanged

        If _NoSave Then Return

        If (typeValue.SelectedIndex = -1) Then

            _Data.type = CHCElementDefinitionEngineLibrary.Models.EntityDefinitionModel.EnumEntityType.notDefined

        ElseIf (typeValue.SelectedIndex = 0) Then

            _Data.type = CHCElementDefinitionEngineLibrary.Models.EntityDefinitionModel.EnumEntityType.coin

        Else

            _Data.type = CHCElementDefinitionEngineLibrary.Models.EntityDefinitionModel.EnumEntityType.token

        End If

        identityValue.Text = _Data.getHash()

    End Sub



    Private Sub typeValue_Leave(sender As Object, e As EventArgs) Handles typeValue.Leave

        updateData()

    End Sub



    Private Sub compileAllData()

        Try

            _NoSave = True

            identityValue.Text = _Data.getHash()

            If (_Data.type = CHCElementDefinitionEngineLibrary.Models.EntityDefinitionModel.EnumEntityType.coin) Then

                typeValue.SelectedIndex = 0

            ElseIf (_Data.type = CHCElementDefinitionEngineLibrary.Models.EntityDefinitionModel.EnumEntityType.token) Then

                typeValue.SelectedIndex = 1

            Else

                typeValue.SelectedIndex = -1

            End If

            coinNameValue.Text = _Data.name
            shortNameValue.Text = _Data.shortName
            symbolValue.Text = _Data.symbol

            burnableValue.Checked = _Data.burnable
            noTotalValue.Checked = _Data.limitless
            preminedValue.Text = _Data.preminedNumber
            totalCoinValue.Text = _Data.total
            numOfDecimalValue.Text = _Data.numberOfDecimal
            symbolLabel1.Text = _Data.symbol
            lblSymbol2.Text = _Data.symbol

            If _Data.limitless Then

                totalCoinLabel.Enabled = False

                totalCoinValue.Enabled = False
                totalCoinValue.Text = ""

                lblSymbol2.Enabled = False

            End If

            _NoSave = False

        Catch ex As Exception

            identityValue.Text = "ERROR"

        End Try

    End Sub



    Private Sub coinNameValue_TextChanged(sender As Object, e As EventArgs) Handles coinNameValue.TextChanged

        If _NoSave Then Return

        _Data.name = coinNameValue.Text
        identityValue.Text = _Data.getHash()

    End Sub

    Private Sub coinNameValue_Leave(sender As Object, e As EventArgs) Handles coinNameValue.Leave

        updateData()

    End Sub



    Private Sub shortNameValue_TextChanged(sender As Object, e As EventArgs) Handles shortNameValue.TextChanged

        If _NoSave Then Return

        _Data.shortName = shortNameValue.Text
        identityValue.Text = _Data.getHash()

    End Sub

    Private Sub shortNameValue_Leave(sender As Object, e As EventArgs) Handles shortNameValue.Leave

        updateData()

    End Sub



    Private Sub symbolValue_TextChanged(sender As Object, e As EventArgs) Handles symbolValue.TextChanged

        If _NoSave Then Return

        _Data.symbol = symbolValue.Text
        identityValue.Text = _Data.getHash()

    End Sub

    Private Sub symbolValue_Leave(sender As Object, e As EventArgs) Handles symbolValue.Leave

        updateData()

    End Sub



    Private Sub burnableValue_CheckedChanged(sender As Object, e As EventArgs) Handles burnableValue.CheckedChanged

        If _NoSave Then Return

        _Data.burnable = burnableValue.Checked
        identityValue.Text = _Data.getHash()

    End Sub

    Private Sub burnableValue_Leave(sender As Object, e As EventArgs) Handles burnableValue.Leave

        updateData()

    End Sub



    Private Sub mintableValue_CheckedChanged(sender As Object, e As EventArgs) Handles mintable.CheckedChanged

        If _NoSave Then Return

        _Data.mintable = mintable.Checked
        identityValue.Text = _Data.getHash()

    End Sub

    Private Sub mintableValue_Leave(sender As Object, e As EventArgs) Handles mintable.Leave

        updateData()

    End Sub



    Private Sub noTotalValue_CheckedChanged(sender As Object, e As EventArgs) Handles noTotalValue.CheckedChanged

        If _NoSave Then Return

        _Data.limitless = noTotalValue.Checked

        If _Data.limitless Then

            totalCoinLabel.Enabled = False

            totalCoinValue.Enabled = False
            totalCoinValue.Text = ""

            lblSymbol2.Enabled = False

        Else

            totalCoinLabel.Enabled = True

            totalCoinValue.Enabled = True
            totalCoinValue.Text = "0"

            lblSymbol2.Enabled = True

        End If

    End Sub

    Private Sub noTotalValue_Leave(sender As Object, e As EventArgs) Handles noTotalValue.Leave

        updateData()

    End Sub



    Private Sub numOfDecimalValue_TextChanged(sender As Object, e As EventArgs) Handles numOfDecimalValue.TextChanged

        Try

            If _NoSave Then Return

            _Data.numberOfDecimal = numOfDecimalValue.Text
            identityValue.Text = _Data.getHash()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub numOfDecimalValue_Leave(sender As Object, e As EventArgs) Handles numOfDecimalValue.Leave

        updateData()

    End Sub



    Private Sub preminedValue_TextChanged(sender As Object, e As EventArgs) Handles preminedValue.TextChanged

        If _NoSave Then Return

        _Data.preminedNumber = preminedValue.Text
        identityValue.Text = _Data.getHash()

    End Sub

    Private Sub preminedValue_Leave(sender As Object, e As EventArgs) Handles preminedValue.Leave

        updateData()

    End Sub



    Private Sub totalCoinValue_TextChanged(sender As Object, e As EventArgs) Handles totalCoinValue.TextChanged

        If _NoSave Then Return

        If totalCoinValue.Text.ToString.Length = 0 Then

            _Data.total = 0

        Else

            _Data.total = totalCoinValue.Text

        End If

        identityValue.Text = _Data.getHash()

    End Sub

    Private Sub totalCoinValue_Leave(sender As Object, e As EventArgs) Handles totalCoinValue.Leave

        updateData()

    End Sub



    Sub manageCommandLine()

        Try

            _CommandLineEngine.decode(Environment.CommandLine.Split("/"))

            If _CommandLineEngine.exist("ForceDataPath".ToLower()) Then

                completePathValue.Text = _CommandLineEngine.GetValue("ForceDataPath".ToLower())

                updateData()

            End If

        Catch ex As Exception

        End Try

    End Sub



    Private Sub editorEntity_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Text += " rel." & My.Application.Info.Version.ToString()

        manageCommandLine()

    End Sub




End Class
