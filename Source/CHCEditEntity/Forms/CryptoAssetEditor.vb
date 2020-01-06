Option Compare Text
Option Explicit On

Imports System.ComponentModel
Imports System.Web
Imports CHCCommonLibrary.CHCEngines.Base.CHCStringExtensions



Public Class CryptoAssetEditor


    Private _Data As CHCDefinitionEngineLibrary.Models.CryptoAssetModel
    Private _Engine As New CHCCommonLibrary.CHCEngines.Common.BaseFileDB(Of CHCDefinitionEngineLibrary.Models.CryptoAssetModel)
    Private _NoSave As Boolean = True
    Private _NoChangeTab As Boolean = True
    Private _OriginalName As String = ""

    Private _InsertMode As Boolean = False
    Private _NoRecourse As Boolean = False


    Public forceDataPath As String = ""






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



    Private Function readRemoteData() As Boolean

        Try

            Dim pws As New CHCCommonLibrary.CHCEngines.Communication.ProxyWS(Of CHCDefinitionEngineLibrary.Models.CryptoAssetModel)

            pws.url = urlValue.Text & "/?name=" & HttpUtility.UrlEncode(completePathValue.Text)

            If pws.getData() Then

                _Data = pws.data

                _OriginalName = completePathValue.Text

                compileAllData()

            Else

                MessageBox.Show("No connection available or wrong address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End If

        Catch ex As Exception

        End Try

        Return False

    End Function



    Private Sub completePathValue_TextChanged(sender As Object, e As EventArgs) Handles completePathValue.TextChanged

        Try

            If radioButtonLocal.Checked Then

                If Not readData() Then

                    _Data = New CHCDefinitionEngineLibrary.Models.CryptoAssetModel

                End If

            Else

                _Data = New CHCDefinitionEngineLibrary.Models.CryptoAssetModel

            End If

            compileAllData()

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


    Private Sub setUpdateMode()

        If radioButtonRemote.Checked Then

            Dim currentName As String = completePathValue.Text.ToString()

            completePathValue.DropDownStyle = ComboBoxStyle.DropDownList

            connectToRemote()

            _InsertMode = False

            If (completePathValue.Items.Count > 0) Then

                For Each item In completePathValue.Items

                    If (item = currentName) Then

                        completePathValue.SelectedItem = item

                    End If

                Next

            End If

            addNewButton.Enabled = True
            renameButton.Enabled = True
            deleteButton.Enabled = True

        End If

    End Sub



    Private Sub updateDataRemote(Optional ByVal forceNewName As String = "")

        Try

            Dim pws As New CHCCommonLibrary.CHCEngines.Communication.ProxyWS(Of CHCDefinitionEngineLibrary.Models.CryptoAssetRequestModel)

            pws.url = urlValue.Text

            pws.data = _Data.copyIntoBaseModel()
            pws.data.symbol.codeSymbol()

            If (forceNewName.Length = 0) Then

                pws.data.configurationName = completePathValue.Text.ToString()

            Else

                pws.data.configurationName = forceNewName

            End If

            If _InsertMode Then

                If pws.sendData("POST") Then

                    MessageBox.Show("Data insert successful", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    setUpdateMode()

                Else

                    MessageBox.Show("No connection available or wrong address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                End If

            Else

                pws.url = urlValue.Text & "/?name=" & _OriginalName

                If pws.sendData("PUT") Then

                    MessageBox.Show("Data update successful", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Else

                    MessageBox.Show("No connection available or wrong address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                End If

            End If

        Catch ex As Exception

        End Try

    End Sub



    Private Function updateData() As Boolean

        Try

            If _NoSave Then Return True
            If (completePathValue.Text.ToString.Length = 0) Then

                identityValue.Text = "NO FILE"
                Return False

            End If

            If (identityValue.Text.ToString.Length = 64) Then

                If radioButtonLocal.Checked Then

                    _Engine.fileName = completePathValue.Text.ToString()

                    If _Engine.save() Then

                        MessageBox.Show("Data insert successful", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        Return True

                    End If

                Else

                    updateDataRemote()

                End If

            End If

        Catch ex As Exception

            MessageBox.Show("Error " & ex.Message, "Error")

        End Try

        Return False

    End Function



    Private Sub compileAllData()

        Try

            _NoSave = True

            identityValue.Text = _Data.getHash()

            If (_Data.type = CHCDefinitionEngineLibrary.Models.CryptoAssetModel.EnumEntityType.coin) Then

                typeValue.SelectedIndex = 0

            ElseIf (_Data.type = CHCDefinitionEngineLibrary.Models.CryptoAssetModel.EnumEntityType.token) Then

                typeValue.SelectedIndex = 1

            Else

                typeValue.SelectedIndex = -1

            End If

            coinNameValue.Text = _Data.name
            shortNameValue.Text = _Data.shortName
            symbolValue.Text = _Data.symbol

            burnableValue.Checked = _Data.burnable
            noTotalValue.Checked = _Data.limitless
            preminedValue.Text = CLng(_Data.preminedNumber)
            totalCoinValue.Text = CLng(_Data.total)
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



    'Private Sub coinNameValue_Leave(sender As Object, e As EventArgs)

    '    updateData()

    'End Sub



    Private Sub shortNameValue_TextChanged(sender As Object, e As EventArgs) Handles shortNameValue.TextChanged

        If _NoSave Then Return

        _Data.shortName = shortNameValue.Text
        identityValue.Text = _Data.getHash()

    End Sub



    'Private Sub shortNameValue_Leave(sender As Object, e As EventArgs)

    '    updateData()

    'End Sub



    Private Sub symbolValue_TextChanged(sender As Object, e As EventArgs) Handles symbolValue.TextChanged

        If _NoSave Then Return

        _Data.symbol = symbolValue.Text
        identityValue.Text = _Data.getHash()

    End Sub



    'Private Sub symbolValue_Leave(sender As Object, e As EventArgs)

    '    updateData()

    'End Sub



    Private Sub burnableValue_CheckedChanged(sender As Object, e As EventArgs) Handles burnableValue.TextChanged

        If _NoSave Then Return

        _Data.burnable = burnableValue.Checked
        identityValue.Text = _Data.getHash()

    End Sub



    'Private Sub burnableValue_Leave(sender As Object, e As EventArgs)

    '    updateData()

    'End Sub



    Private Sub mintableValue_CheckedChanged(sender As Object, e As EventArgs) Handles mintable.TextChanged

        If _NoSave Then Return

        _Data.mintable = mintable.Checked
        identityValue.Text = _Data.getHash()

    End Sub



    'Private Sub mintableValue_Leave(sender As Object, e As EventArgs)

    '    updateData()

    'End Sub



    Private Sub noTotalValue_CheckedChanged(sender As Object, e As EventArgs) Handles noTotalValue.TextChanged

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



    'Private Sub noTotalValue_Leave(sender As Object, e As EventArgs)

    '    updateData()

    'End Sub



    Private Sub numOfDecimalValue_TextChanged(sender As Object, e As EventArgs) Handles numOfDecimalValue.TextChanged

        Try

            If _NoSave Then Return

            If IsNumeric(numOfDecimalValue.Text.ToString) Then

                _Data.numberOfDecimal = numOfDecimalValue.Text

            Else

                _Data.numberOfDecimal = 0

            End If

            identityValue.Text = _Data.getHash()

        Catch ex As Exception

        End Try

    End Sub



    'Private Sub numOfDecimalValue_Leave(sender As Object, e As EventArgs)

    '    updateData()

    'End Sub



    Private Sub preminedValue_TextChanged(sender As Object, e As EventArgs) Handles preminedValue.TextChanged

        If _NoSave Then Return

        If IsNumeric(preminedValue.Text.ToString) Then

            _Data.preminedNumber = preminedValue.Text

        Else

            _Data.preminedNumber = 0

        End If

        identityValue.Text = _Data.getHash()

    End Sub



    'Private Sub preminedValue_Leave(sender As Object, e As EventArgs)

    '    updateData()

    'End Sub



    Private Sub totalCoinValue_TextChanged(sender As Object, e As EventArgs) Handles totalCoinValue.TextChanged

        If _NoSave Then Return

        If IsNumeric(totalCoinValue.Text.ToString) Then

            _Data.total = totalCoinValue.Text

        Else

            _Data.total = 0

        End If

        identityValue.Text = _Data.getHash()

    End Sub



    'Private Sub totalCoinValue_Leave(sender As Object, e As EventArgs)

    '    updateData()

    'End Sub







    Private Sub editorEntity_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Text += " rel." & My.Application.Info.Version.ToString()

        completePathValue.Text = forceDataPath

        If (completePathValue.Text.Length > 0) Then

            updateData()

        End If

    End Sub

    Private Sub tabControlMain_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tabControlMain.SelectedIndexChanged

        confirmButton.Enabled = (tabControlMain.SelectedIndex <> 0)

    End Sub


    Private Sub insertNewContract()

        completePathValue.DropDownStyle = ComboBoxStyle.Simple
        addNewButton.Enabled = False

        _InsertMode = True

    End Sub


    Private Sub connectToRemote()

        Dim pws As New CHCCommonLibrary.CHCEngines.Communication.ProxyWS(Of List(Of String))

        pws.url = urlValue.Text

        If pws.getData() Then

            completePathValue.Items.Clear()

            renameButton.Enabled = False
            deleteButton.Enabled = False

            If (pws.data.Count = 0) Then

                insertNewContract()

            Else

                addNewButton.Enabled = True

                For Each item In pws.data

                    completePathValue.Items.Add(item)

                Next

            End If

            _NoChangeTab = False

            tabControlMain.SelectedIndex = 1

            browseButton.Enabled = False
            confirmButton.Enabled = True

        Else

            MessageBox.Show("No connection available or wrong address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End If

    End Sub


    Private Sub buttonNext_Click(sender As Object, e As EventArgs) Handles buttonNext.Click

        If radioButtonLocal.Checked Then

            _NoChangeTab = False

            tabControlMain.SelectedIndex = 1

            pathLabel.Text = "Complete file path"

            browseButton.Enabled = True

            completePathValue.DropDownStyle = ComboBoxStyle.Simple
            completePathValue.Items.Clear()

            _Data = New CHCDefinitionEngineLibrary.Models.CryptoAssetModel

            compileAllData()

        Else

            pathLabel.Text = "Configuration Name"

            completePathValue.DropDownStyle = ComboBoxStyle.DropDownList

            If (urlValue.Text.ToString.Trim.Length <> 0) Then

                connectToRemote()

                If (completePathValue.Items.Count > 0) Then

                    completePathValue.SelectedIndex = 0

                End If

            Else

                MessageBox.Show("Insert an address URL", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End If

        End If

    End Sub


    Private Sub tabControlMain_Selecting(sender As Object, e As TabControlCancelEventArgs) Handles tabControlMain.Selecting

        If (tabControlMain.SelectedIndex = 1) Then

            If _NoChangeTab Then

                e.Cancel = True

            End If

        End If

    End Sub

    Private Sub radioButtonRemote_CheckedChanged(sender As Object, e As EventArgs) Handles radioButtonRemote.CheckedChanged

        labelURL.Enabled = True
        urlValue.Enabled = True
        labelKeyword.Enabled = True
        keyWordValue.Enabled = True
        showKeywordValue.Enabled = True

        _NoChangeTab = True

    End Sub

    Private Sub radioButtonLocal_CheckedChanged(sender As Object, e As EventArgs) Handles radioButtonLocal.CheckedChanged

        labelURL.Enabled = False
        urlValue.Enabled = False
        labelKeyword.Enabled = False
        keyWordValue.Enabled = False
        showKeywordValue.Enabled = False
        urlValue.Text = ""
        keyWordValue.Text = ""
        keyWordValue.PasswordChar = "*"
        showKeywordValue.Checked = False

    End Sub

    Private Sub showKeywordValue_CheckedChanged(sender As Object, e As EventArgs) Handles showKeywordValue.CheckedChanged

        If showKeywordValue.Checked Then

            keyWordValue.PasswordChar = ""

        Else

            keyWordValue.PasswordChar = "*"

        End If

    End Sub



    Private Sub confirmButton_Click(sender As Object, e As EventArgs) Handles confirmButton.Click

        If (completePathValue.Text.ToString().Length = 0) Then

            MessageBox.Show("Insert a complete name or configuration")

        Else

            updateData()

        End If

    End Sub

    Private Sub tabPageConnection_Click(sender As Object, e As EventArgs) Handles tabPageConnection.Click

    End Sub

    Private Sub completePathValue_SelectedIndexChanged(sender As Object, e As EventArgs) Handles completePathValue.SelectedIndexChanged

        If _NoRecourse Then Return

        If completePathValue.SelectedIndex <> -1 Then

            If Not _InsertMode Then

                _NoRecourse = True

                setUpdateMode()
                readRemoteData()

                _NoRecourse = False

            End If

        End If

    End Sub

    Private Sub clearAllFields()

        _NoSave = True

        typeValue.SelectedIndex = -1
        coinNameValue.Text = ""
        shortNameValue.Text = ""
        symbolValue.Text = ""
        burnableValue.Checked = False
        mintable.Checked = False
        noTotalValue.Checked = False
        numOfDecimalValue.Text = ""
        preminedValue.Text = ""
        totalCoinValue.Text = ""
        identityValue.Text = ""

        _NoSave = False

    End Sub


    Private Sub addNewButton_Click(sender As Object, e As EventArgs) Handles addNewButton.Click

        completePathValue.DropDownStyle = ComboBoxStyle.Simple
        completePathValue.Text = ""

        clearAllFields()

        completePathValue.Select()

        _InsertMode = True

    End Sub

    Private Sub coinNameValue_TextChanged_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub completePathValue_Validating(sender As Object, e As CancelEventArgs) Handles completePathValue.Validating

        If _InsertMode Then

            If (completePathValue.DropDownStyle = ComboBoxStyle.Simple) Then

                For Each item In completePathValue.Items

                    If completePathValue.Text.ToString.CompareTo(item) = 0 Then

                        MessageBox.Show("This name is also used")

                        e.Cancel = True

                        Return

                    End If

                Next

                completePathValue.Items.Add(completePathValue.Text)

                For Each item In completePathValue.Items

                    If (item.ToString.CompareTo(completePathValue.Text) = 0) Then

                        completePathValue.SelectedItem = item

                        Exit For

                    End If

                Next

                completePathValue.DropDownStyle = ComboBoxStyle.DropDownList

                _Data = New CHCDefinitionEngineLibrary.Models.CryptoAssetModel

                compileAllData()

            End If

        End If

    End Sub

    Private Sub entityEditor_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

    End Sub

    Private Sub deleteButton_Click(sender As Object, e As EventArgs) Handles deleteButton.Click

        Try

            Dim pws As New CHCCommonLibrary.CHCEngines.Communication.ProxyWS(Of CHCDefinitionEngineLibrary.Models.CryptoAssetRequestModel)

            pws.url = urlValue.Text

            pws.data = _Data.copyIntoBaseModel()
            pws.data.symbol.codeSymbol()
            pws.data.configurationName = completePathValue.Text.ToString()

            pws.url = urlValue.Text & "/?name=" & _OriginalName

            If pws.sendData("DELETE") Then

                MessageBox.Show("Data delete successful", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)

                connectToRemote()

            Else

                MessageBox.Show("No connection available or wrong address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End If

        Catch ex As Exception

        End Try

    End Sub



    Private Sub renameButton_Click(sender As Object, e As EventArgs) Handles renameButton.Click

        Dim newName As String = InputBox("Insert a new name", "Request date")
        Dim found As Boolean = False

        For Each item In completePathValue.Items

            If newName.CompareTo(item) = 0 Then

                found = True

                Exit For

            End If

        Next

        If found Then

            MessageBox.Show("This name is already exist")

        Else

            _InsertMode = False
            _OriginalName = completePathValue.Text

            updateDataRemote(newName)
            connectToRemote()

            For Each item In completePathValue.Items

                If (item.ToString.CompareTo(newName) = 0) Then

                    completePathValue.SelectedItem = item

                    Return

                End If

            Next

        End If

    End Sub


End Class
