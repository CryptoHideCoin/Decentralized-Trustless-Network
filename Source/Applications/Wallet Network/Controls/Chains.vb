Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.Communication
Imports CHCCommonLibrary.AreaCommon.Models.General
Imports CHCProtocolLibrary.AreaCommon
Imports CHCProtocolLibrary.AreaCommon.Models.Chain.Response

Public Class Chains

    Public Enum ManageType
        undefined
        list
        lastBlock
        parameters
        setProtocol
        priceList
        privacyPolicy
        termsAndConditions
        tokens
        masterNodes
    End Enum

    Private Property _Type As ManageType = ManageType.undefined
    Private Property _Symbol As String = ""
    Private Property _ChainName As String = ""

    Public Event OpenConfiguration()
    Public Event OpenChainDetails()
    Public Event CloseMe()


    Private Sub Chains_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Try
            mainList.Width = Me.Width
            dataDetail.Width = Me.Width - 20
            chainSetProtocol.Width = Me.Width
            tokensDataChain.Width = Me.Width
        Catch ex As Exception
        End Try
        Try
            mainList.Height = Me.Height - 40
            dataDetail.Height = Me.Height - 78
            chainSetProtocol.Height = Me.Height - 40
            tokensDataChain.Height = Me.Height - 40
        Catch ex As Exception
        End Try
    End Sub

    ''' <summary>
    ''' This method provide to read a number of chain
    ''' </summary>
    ''' <returns></returns>
    Private Function readNumberOfChain() As Integer
        Try
            Dim startTime As Double = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()
            Dim remote As New ProxyWS(Of Models.Chain.Response.ChainCountModel)
            Dim proceed As Boolean = True

            If proceed Then
                remote.url = AreaCommon.buildURL("/chain/chainCount/")
            End If
            If proceed Then
                proceed = (remote.getData() = "")
            End If
            If proceed Then
                proceed = (remote.data.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete)
            End If
            If proceed Then
                proceed = (remote.data.value > 0)
            End If
            If Not proceed Then
                MessageBox.Show("Error during connection", "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)

                RaiseEvent OpenConfiguration()
            Else
                Return remote.data.value
            End If

            remote = Nothing

            Return 0
        Catch ex As Exception
            Return -1
        End Try
    End Function

    ''' <summary>
    ''' This method provide to read and print a chain list information
    ''' </summary>
    Private Function readChainList(ByVal pageNumber As String) As Boolean
        Try
            Dim startTime As Double = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()
            Dim remote As New ProxyWS(Of ChainListDataPageModel)
            Dim proceed As Boolean = True

            If proceed Then
                remote.url = AreaCommon.buildURL("/chain/chainPageData/?pageNumber=" & pageNumber)
            End If
            If proceed Then
                proceed = (remote.getData() = "")
            End If
            If proceed Then
                proceed = (remote.data.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete)
            End If
            If proceed Then
                proceed = (remote.data.value.pageDataList.Count > 0)
            Else
                MessageBox.Show("Error during connection", "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)

                RaiseEvent OpenConfiguration()

                Return False
            End If
            If proceed Then
                mainList.resetGrid()

                For Each item In remote.data.value.pageDataList
                    mainList.loadDataIntoGrid(item)
                Next
            End If

            Return proceed
        Catch ex As Exception
            Return False
        End Try
    End Function

    ''' <summary>
    ''' This method provide to load a chain protocol
    ''' </summary>
    ''' <returns></returns>
    Private Function loadChainProtocol() As Boolean
        Try
            Dim startTime As Double = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()
            Dim remote As New ProxyWS(Of Models.Chain.Response.ChainProtocolDataModel)
            Dim proceed As Boolean = True

            If proceed Then
                remote.url = AreaCommon.buildURL("/chain/chainProtocol/?name=" & _ChainName)
            End If
            If proceed Then
                proceed = (remote.getData() = "")
            End If
            If proceed Then
                proceed = (remote.data.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete)
            End If
            If proceed Then
                proceed = (remote.data.value.Count > 0)
            Else
                MessageBox.Show("Error during connection", "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)

                RaiseEvent OpenConfiguration()

                Return False
            End If
            If proceed Then
                chainSetProtocol.protocolData = remote.data.value

                chainSetProtocol.resetGrid()
                chainSetProtocol.loadDataIntoGrid()
            End If

            Return proceed
        Catch ex As Exception
            Return False
        End Try
    End Function

    ''' <summary>
    ''' This method provide to return if active chain or not
    ''' </summary>
    ''' <param name="chainName"></param>
    ''' <returns></returns>
    Private Function activeChain(ByVal chainName As String) As Boolean
        Try
            Dim startTime As Double = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()
            Dim remote As New ProxyWS(Of ChainActiveModel)
            Dim proceed As Boolean = True

            If proceed Then
                remote.url = AreaCommon.buildURL("/chain/chainActive/?name=" & chainName)
            End If
            If proceed Then
                proceed = (remote.getData() = "")
            End If
            If proceed Then
                proceed = (remote.data.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete)
            End If
            If Not proceed Then
                MessageBox.Show("Error during connection", "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)

                RaiseEvent OpenConfiguration()

                Return False
            End If
            If proceed Then
                Return remote.data.value
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    ''' <summary>
    ''' This method provide to read chain last block data
    ''' </summary>
    ''' <returns></returns>
    Private Function readChainLastBlock() As Boolean
        Try
            Dim startTime As Double = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()
            Dim remote As New ProxyWS(Of ChainDataLastBlockModel)
            Dim proceed As Boolean = True

            If proceed Then
                remote.url = AreaCommon.buildURL("/chain/chainDataLastBlock/?name=" & _ChainName)
            End If
            If proceed Then
                proceed = (remote.getData() = "")
            End If
            If proceed Then
                proceed = (remote.data.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete)
            End If
            If proceed Then
                proceed = (remote.data.integrityTransactionChain.coordinate.Length > 0)
            Else
                MessageBox.Show("Error during connection", "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)

                RaiseEvent OpenConfiguration()

                Return False
            End If
            If proceed Then
                Return dataDetail.loadChainLastBlock(remote.data, activeChain(_ChainName))
            Else
                Return False
            End If

            Return proceed
        Catch ex As Exception
            Return False
        End Try
    End Function

    ''' <summary>
    ''' This property get / let the type of interrogation
    ''' </summary>
    ''' <returns></returns>
    Public Property [type] As ManageType
        Get
            Return _Type
        End Get
        Set(value As ManageType)
            Dim controlObject As Object
            _Type = value

            mainList.Visible = False
            dataDetail.Visible = False
            chainSetProtocol.Visible = False
            tokensDataChain.Visible = False

            Select Case _Type
                Case ManageType.list
                    titleControl.Text = "Chain list"

                    If (mainList.numChains = 0) Then
                        mainList.numChains = readNumberOfChain()

                        mainList.pageNumber.Text = "1"
                    End If

                    controlObject = mainList

                    readChainList(mainList.pageNumber.Text)
                Case ManageType.lastBlock
                    titleControl.Text = "Data last block - Chain: " & _ChainName

                    controlObject = dataDetail

                    dataDetail.type = ChainDetail.ChainSectionType.lastBlock

                    readChainLastBlock()
                Case ManageType.parameters
                    titleControl.Text = "Parameters - Chain: " & _ChainName

                    controlObject = dataDetail

                    dataDetail.type = ChainDetail.ChainSectionType.parameters

                    dataDetail.loadChainParameter(_ChainName)
                Case ManageType.setProtocol
                    titleControl.Text = "Protocols - Chain: " & _ChainName

                    controlObject = chainSetProtocol

                    loadChainProtocol()
                Case ManageType.priceList
                    titleControl.Text = "Price List - Chain: " & _ChainName

                    controlObject = dataDetail

                    dataDetail.type = ChainDetail.ChainSectionType.priceList

                    dataDetail.loadPriceList(_ChainName)
                Case ManageType.privacyPolicy
                    titleControl.Text = "Privacy Policy - Chain: " & _ChainName

                    controlObject = dataDetail

                    dataDetail.type = ChainDetail.ChainSectionType.policyPrivacy

                    dataDetail.loadPrivacyContent(_ChainName)
                Case ManageType.termsAndConditions
                    titleControl.Text = "Terms and Conditions - Chain: " & _ChainName

                    controlObject = dataDetail

                    dataDetail.type = ChainDetail.ChainSectionType.termsAndCondition

                    dataDetail.loadTermsAndConditions(_ChainName)
                Case ManageType.tokens
                    titleControl.Text = "Tokens - Chain: " & _ChainName

                    controlObject = tokensDataChain

                    loadTokens(_ChainName)
                Case ManageType.masterNodes
                    titleControl.Text = "Masternodes - Chain: " & _ChainName

                    controlObject = dataDetail

                    dataDetail.type = ChainDetail.ChainSectionType.masterNodes

                    dataDetail.loadMasterNodes(_ChainName)
                Case Else
                    Return
            End Select

            controlObject.Visible = True
            controlObject.Location = New Point(0, 35)
            controlObject.width = Me.Width
            controlObject.height = Me.Height - 40
        End Set
    End Property

    Private Sub mainList_OpenChain(name As String) Handles mainList.OpenChain
        _ChainName = name

        titleControl.Text = "Chain: " & name

        mainList.Visible = False
        dataDetail.Visible = True

        dataDetail.type = ChainDetail.ChainSectionType.main
        dataDetail.loadData(name)

        RaiseEvent OpenChainDetails()
    End Sub

    Private Sub Chains_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dataDetail.Top = 62
        dataDetail.Left = 10
    End Sub


    ''' <summary>
    ''' This method provide to load a tokens into grid
    ''' </summary>
    ''' <param name="chainName"></param>
    ''' <returns></returns>
    Public Function loadTokens(ByVal chainName As String) As Boolean
        Try
            Dim startTime As Double = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()
            Dim remote As New ProxyWS(Of ChainTokenListModel)
            Dim proceed As Boolean = True

            If proceed Then
                remote.url = AreaCommon.buildURL("/chain/chainTokenConfiguration/?name=" & chainName)
            End If
            If proceed Then
                proceed = (remote.getData() = "")
            End If
            If proceed Then
                proceed = (remote.data.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete)
            End If
            If Not proceed Then
                MessageBox.Show("Error during connection", "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)

                Return False
            End If
            If proceed Then
                If (remote.data.value.Count > 0) Then
                    tokensDataChain.tokensData = remote.data.value

                    tokensDataChain.loadDataIntoGrid()
                End If
            End If

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub chainSetProtocol_OpenProtocolChain(ByRef value As SingleSetProtocol) Handles chainSetProtocol.OpenProtocolChain
        dataDetail.Visible = True
        chainSetProtocol.Visible = False

        titleControl.Text = "Set Protocol - Chain: " & _ChainName

        dataDetail.type = ChainDetail.ChainSectionType.protocol

        dataDetail.loadSetProtocol(value)
    End Sub


    ''' <summary>
    ''' This method provide to read an asset information
    ''' </summary>
    ''' <returns></returns>
    Private Function readAssetInformation() As Boolean
        Try
            Dim startTime As Double = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()
            Dim remote As New ProxyWS(Of Models.Network.InfoAssetModel)
            Dim proceed As Boolean = True

            If proceed Then
                remote.url = AreaCommon.buildURL("/network/primaryAsset/")
            End If
            If proceed Then
                proceed = (remote.getData() = "")
            End If
            If proceed Then
                proceed = (remote.data.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete)
            End If
            If proceed Then
                proceed = (remote.data.value.assetInformation.name.Length > 0)
            End If
            If proceed Then
                _Symbol = remote.data.value.assetInformation.symbol
            End If
            If Not proceed Then
                MessageBox.Show("Error during connection", "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)

                RaiseEvent OpenConfiguration()
            End If

            remote = Nothing

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub dataDetail_GetSymbol(ByRef value As String) Handles dataDetail.GetSymbol
        If (_Symbol.Length = 0) Then
            If Not readAssetInformation() Then
                Return
            End If
        End If

        value = _Symbol
    End Sub

    Private Sub dataDetail_Load(sender As Object, e As EventArgs) Handles dataDetail.Load

    End Sub

    Private Sub dataDetail_CloseMe() Handles dataDetail.CloseMe
        RaiseEvent CloseMe()
    End Sub

End Class
