Option Compare Text
Option Explicit On

Imports System.ComponentModel
Imports System.Web
Imports System.IO
Imports CHCCommonLibrary.CHCEngines.Base.CHCStringExtensions
Imports CHCMasterNodeEngineLibrary


Public Class TransChainEditor

    Private Class ResultSearchCryptoAsset

        Public id As String
        Public [name] As String
        Public [type] As Models.CryptoAssetModel.EnumEntityType
        Public providesPremined As Boolean
        Public symbol As String

    End Class

    Private _Data As Models.TransChainDefinitionModel
    Private _Engine As New CHCCommonLibrary.CHCEngines.Common.BaseFileDB(Of Models.TransChainDefinitionModel)
    Private _CryptoAssetByName As New Dictionary(Of String, ResultSearchCryptoAsset)
    Private _CryptoAssetByID As New Dictionary(Of String, ResultSearchCryptoAsset)
    Private _TypeNameLoaded As String = ""
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

            Dim pws As New CHCCommonLibrary.CHCEngines.Communication.ProxyWS(Of Models.TransChainDefinitionModel)

            pws.url = urlValue.Text & "Configuration/TransChainDefinition/?name=" & HttpUtility.UrlEncode(completePathValue.Text)

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

                    _Data = New Models.TransChainDefinitionModel

                End If

            Else

                _Data = New Models.TransChainDefinitionModel

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

            Dim pws As New CHCCommonLibrary.CHCEngines.Communication.ProxyWS(Of Models.TransChainDefinitionRequestModel)

            pws.url = urlValue.Text & "Configuration/TransChainDefinition"

            pws.data = _Data.copyIntoBaseModel()

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

                pws.url = urlValue.Text & "Configuration/TransChainDefinition/?name=" & _OriginalName

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

                    _Engine.data = _Data

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



    Private Function getCryptoAssetInfo(ByVal path As String, ByVal fileName As String) As ResultSearchCryptoAsset

        Dim engine As New CHCEngines.CryptoAssetDefinitionEngine(path)
        Dim result As New ResultSearchCryptoAsset

        Try

            engine.fileName = IO.Path.Combine(path, fileName)

            If engine.read() Then

                result.name = engine.data.name
                result.type = engine.data.type
                result.symbol = engine.data.symbol
                result.id = engine.data.getHash()
                result.providesPremined = (engine.data.preminedNumber > 0)

                Return result

            End If

        Catch ex As Exception

        End Try

        Return result

    End Function


    Private Function getCryptoAssetDefinitions() As List(Of ResultSearchCryptoAsset)

        Dim pws As New CHCCommonLibrary.CHCEngines.Communication.ProxyWS(Of List(Of String))
        Dim detailpws As New CHCCommonLibrary.CHCEngines.Communication.ProxyWS(Of Models.CryptoAssetModel)
        Dim result As New List(Of ResultSearchCryptoAsset)
        Dim data As ResultSearchCryptoAsset

        pws.url = urlValue.Text & "Configuration/CryptoAssetDefinition/"

        If pws.getData() Then

            For Each nameCryptoAsset In pws.data

                detailpws.url = urlValue.Text & "Configuration/CryptoAssetDefinition/?name=" & HttpUtility.UrlEncode(nameCryptoAsset)

                If detailpws.getData() Then

                    data = New ResultSearchCryptoAsset

                    data.id = detailpws.data.getHash()
                    data.name = nameCryptoAsset
                    data.providesPremined = (detailpws.data.preminedNumber > 0)
                    data.symbol = detailpws.data.symbol
                    data.type = detailpws.data.type

                    result.Add(data)

                End If

            Next

        End If

        Return result

    End Function


    Private Sub loadCryptoAssetList()

        If (typeValue.SelectedIndex = -1) Then

            cryptoAssetLabel.Enabled = False
            cryptoAssetValue.Enabled = False
            cryptoAssetValue.Items.Clear()
            cryptoAssetValue.SelectedIndex = -1

            Return

        End If

        If (_TypeNameLoaded = typeValue.Text) Then

            Return

        End If

        If radioButtonLocal.Checked Then

            Dim path As String

            If (completePathValue.Text.Length = 0) Then

                path = Application.StartupPath()

            Else

                path = IO.Path.GetDirectoryName(completePathValue.Text)

            End If

            Dim dirInfo As New IO.DirectoryInfo(path)
            Dim filesResult As IO.FileInfo() = dirInfo.GetFiles("*.cryptoAssetDefinition")
            Dim fileInformation As IO.FileInfo
            Dim item As ResultSearchCryptoAsset

            cryptoAssetValue.Items.Clear()
            _CryptoAssetByID.Clear()
            _CryptoAssetByName.Clear()

            For Each fileInformation In filesResult

                item = getCryptoAssetInfo(path, fileInformation.Name)

                If (typeValue.SelectedIndex + 1 = Models.TransChainDefinitionModel.EnumTransChainType.mainPlatform) Then

                    If (item.type = Models.CryptoAssetModel.EnumEntityType.coin) Then

                        cryptoAssetValue.Items.Add(item.name)

                        _CryptoAssetByID.Add(item.id, item)
                        _CryptoAssetByName.Add(item.name, item)

                    End If

                ElseIf (typeValue.SelectedIndex + 1 = Models.TransChainDefinitionModel.EnumTransChainType.crowdfund) Then

                    If (item.type = Models.CryptoAssetModel.EnumEntityType.token) Then

                        cryptoAssetValue.Items.Add(item.name)

                        _CryptoAssetByID.Add(item.id, item)
                        _CryptoAssetByName.Add(item.name, item)

                    End If

                End If

            Next

        Else

            Dim result As List(Of ResultSearchCryptoAsset)

            result = getCryptoAssetDefinitions()

            If Not result Is Nothing Then

                cryptoAssetValue.Items.Clear()
                _CryptoAssetByID.Clear()
                _CryptoAssetByName.Clear()

                For Each item In result

                    If (typeValue.SelectedIndex + 1 = Models.TransChainDefinitionModel.EnumTransChainType.mainPlatform) Then

                        If (item.type = Models.CryptoAssetModel.EnumEntityType.coin) Then

                            cryptoAssetValue.Items.Add(item.name)

                            _CryptoAssetByID.Add(item.id, item)
                            _CryptoAssetByName.Add(item.name, item)

                        End If

                    ElseIf (typeValue.SelectedIndex + 1 = Models.TransChainDefinitionModel.EnumTransChainType.crowdfund) Then

                        If (item.type = Models.CryptoAssetModel.EnumEntityType.token) Then

                            cryptoAssetValue.Items.Add(item.name)

                            _CryptoAssetByID.Add(item.id, item)
                            _CryptoAssetByName.Add(item.name, item)

                        End If

                    End If

                Next

            End If

        End If

        _TypeNameLoaded = typeValue.Text

    End Sub



    Private Sub compileAllData()

        Try

            _NoSave = True

            identityValue.Text = _Data.getHash()

            If (_Data.mode = Models.TransChainDefinitionModel.EnumTransChainMode.official) Then

                modeValue.SelectedIndex = 0

            ElseIf (_Data.mode = Models.TransChainDefinitionModel.EnumTransChainMode.testNet) Then

                modeValue.SelectedIndex = 1

            Else

                modeValue.SelectedIndex = -1

            End If

            If (_Data.type = Models.TransChainDefinitionModel.EnumTransChainType.mainPlatform) Then

                typeValue.SelectedIndex = 0

            ElseIf (_Data.type = Models.TransChainDefinitionModel.EnumTransChainType.crowdfund) Then

                typeValue.SelectedIndex = 1

            Else

                typeValue.SelectedIndex = -1

            End If

            loadCryptoAssetList()

            If (_Data.cryptoAssetID.Length > 0) Then

                With _CryptoAssetByID(_Data.cryptoAssetID)

                    cryptoAssetValue.SelectedItem = .name
                    symbolLabel.Text = .symbol

                End With

            End If

            If (_Data.crowdFundConfigurationName.Length > 0) Then

                crowdFundValue.SelectedValue = _Data.crowdFundConfigurationName

            End If

            networkNameValue.Text = _Data.name

            scheduleValue.Checked = _Data.scheduleFirstStart

            If _Data.scheduleFirstStart Then

                startTransChainValue.Value = _Data.dateFirstStart.ToLocalTime()

            End If

            publicWalletPremined.Text = _Data.walletAddressPremined
            rewardPerDays.Text = CLng(_Data.rewardForDays)

            _NoSave = False

        Catch ex As Exception

            identityValue.Text = "ERROR"

        End Try

    End Sub



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

        pws.url = urlValue.Text & "Configuration/TransChainDefinition"

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

            _Data = New Models.TransChainDefinitionModel

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

        If (tabControlMain.SelectedIndex <> 0) Then

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



    Private Function verifyData() As Boolean

        If _CryptoAssetByName(cryptoAssetValue.Text).providesPremined Then

            If (publicWalletPremined.Text.Trim().Length = 0) Then

                If MessageBox.Show("the cryptoasset foresees the management of the premine but the public wallet is not specified." & vbNewLine & vbNewLine & "Continue anyway?", "Warning", MessageBoxButtons.YesNo) = DialogResult.No Then

                    Return False

                End If

            End If

        End If

        Return True

    End Function



    Private Sub confirmButton_Click(sender As Object, e As EventArgs) Handles confirmButton.Click

        If (completePathValue.Text.ToString().Length = 0) Then

            MessageBox.Show("Insert a complete name or configuration")

        Else

            If verifyData() Then

                updateData()

            End If

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

        modeValue.SelectedIndex = -1
        networkNameValue.Text = ""
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

                _Data = New Models.TransChainDefinitionModel

                compileAllData()

            End If

        End If

    End Sub

    Private Sub entityEditor_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

    End Sub

    Private Sub deleteButton_Click(sender As Object, e As EventArgs) Handles deleteButton.Click

        Try

            Dim pws As New CHCCommonLibrary.CHCEngines.Communication.ProxyWS(Of Models.TransChainDefinitionRequestModel)

            pws.url = urlValue.Text

            pws.data = _Data.copyIntoBaseModel()
            pws.data.configurationName = completePathValue.Text.ToString()

            pws.url = urlValue.Text & "Configuration/TransChainDefinition/?name=" & _OriginalName

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

    Private Sub tabPageEditor_Click(sender As Object, e As EventArgs) Handles tabPageEditor.Click

    End Sub

    Private Sub modeValue_SelectedIndexChanged(sender As Object, e As EventArgs) Handles modeValue.SelectedIndexChanged

        If _NoSave Then Return

        If (modeValue.SelectedIndex = -1) Then

            _Data.mode = Models.TransChainDefinitionModel.EnumTransChainMode.notDefined

        ElseIf (modeValue.SelectedIndex = 0) Then

            _Data.mode = Models.TransChainDefinitionModel.EnumTransChainMode.official

        Else

            _Data.mode = Models.TransChainDefinitionModel.EnumTransChainMode.testNet

        End If

        identityValue.Text = _Data.getHash()

    End Sub

    Private Sub crowdFundValue_SelectedIndexChanged(sender As Object, e As EventArgs) Handles crowdFundValue.SelectedIndexChanged

        If _NoSave Then Return

        _Data.crowdFundConfigurationName = crowdFundValue.Text

        identityValue.Text = _Data.getHash()

    End Sub

    Private Sub networkNameValue_TextChanged(sender As Object, e As EventArgs) Handles networkNameValue.TextChanged

        If _NoSave Then Return

        _Data.name = networkNameValue.Text

        identityValue.Text = _Data.getHash()

    End Sub

    Private Sub cryptoAssetValue_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cryptoAssetValue.SelectedIndexChanged

        If _NoSave Then Return

        With _CryptoAssetByName(cryptoAssetValue.Text)

            _Data.cryptoAssetID = .id

            symbolLabel.Text = .symbol

        End With

        identityValue.Text = _Data.getHash()

    End Sub

    Private Sub scheduleValue_CheckedChanged(sender As Object, e As EventArgs) Handles scheduleValue.CheckedChanged

        dateStartTransChainLabel.Enabled = scheduleValue.Checked
        helpNetworkNameLabel.Enabled = scheduleValue.Checked
        startTransChainValue.Enabled = scheduleValue.Checked

        If _NoSave Then Return

        startTransChainValue.Value = #01/01/2019#

        _Data.scheduleFirstStart = scheduleValue.Checked
        _Data.dateFirstStart = startTransChainValue.Value.ToUniversalTime()

    End Sub

    Private Sub publicWalletPremined_TextChanged(sender As Object, e As EventArgs) Handles publicWalletPremined.TextChanged

        If _NoSave Then Return

        _Data.walletAddressPremined = publicWalletPremined.Text

        identityValue.Text = _Data.getHash()

    End Sub

    Private Sub rewardPerDays_TextChanged(sender As Object, e As EventArgs) Handles rewardPerDays.TextChanged

        If _NoSave Then Return

        _Data.rewardForDays = rewardPerDays.Text

        identityValue.Text = _Data.getHash()

    End Sub

    Private Sub startTransChainValue_ValueChanged(sender As Object, e As EventArgs) Handles startTransChainValue.ValueChanged

        If _NoSave Then Return

        _Data.dateFirstStart = startTransChainValue.Value.ToUniversalTime

        identityValue.Text = _Data.getHash()

    End Sub

    Private Sub typeValue_SelectedIndexChanged(sender As Object, e As EventArgs) Handles typeValue.SelectedIndexChanged

        If _NoSave Then Return

        If (typeValue.SelectedIndex = -1) Then

            _Data.type = Models.CryptoAssetModel.EnumEntityType.notDefined

        ElseIf (typeValue.SelectedIndex = 0) Then

            _Data.type = Models.CryptoAssetModel.EnumEntityType.coin

        Else

            _Data.type = Models.CryptoAssetModel.EnumEntityType.token

        End If

        loadCryptoAssetList()

        identityValue.Text = _Data.getHash()

    End Sub

End Class