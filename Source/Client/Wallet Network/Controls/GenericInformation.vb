Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.Communication
Imports CHCCommonLibrary.AreaCommon.Models.General
Imports CHCProtocolLibrary.AreaCommon



Public Class GenericInformation

    Public Enum ManageType
        undefined
        netWorkInformation
        whitePaper
        yellowPaper
        assetInformation
        transactionChainParameters
        privacyPolicy
        generalConditions
        refundPlan
    End Enum

    Private Property _Type As ManageType = ManageType.undefined
    Private Property _Symbol As String = ""

    Public Event OpenConfiguration()


    ''' <summary>
    ''' This method provide to read a data information
    ''' </summary>
    Private Function readNetworkInformation() As Boolean
        Try
            Dim startTime As Double = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()
            Dim remote As New ProxyWS(Of Models.Network.InfoNetworkBaseModel)
            Dim proceed As Boolean = True

            If proceed Then
                remote.url += AreaCommon.buildURL("/network/informationBase/")
            End If
            If proceed Then
                proceed = (remote.getData() = "")
            End If
            If proceed Then
                proceed = (remote.data.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete)
            End If
            If proceed Then
                proceed = (remote.data.name.Length > 0)
            End If
            If proceed Then
                networkContent.networkName.Text = remote.data.name
                networkContent.specialEnvironment.Text = remote.data.specialEnvironment
                networkContent.netWorkID.Text = remote.data.integrityTransactionChain.progressiveHash
                networkContent.netWorkCreationDate.Text = remote.data.networkCreationDate
                networkContent.publicAddressCreator.Text = remote.data.genesisPublicAddress

                coordinate.Text = remote.data.integrityTransactionChain.coordinate
                registrationTimeStamp.Text = remote.data.integrityTransactionChain.registrationTimeStamp
                hash.Text = remote.data.integrityTransactionChain.hash
                progressiveHash.Text = remote.data.integrityTransactionChain.progressiveHash
                responseTime.Text = Int(CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime() - CDec(startTime)) & " ms."
            Else
                MessageBox.Show("Error during connection", "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)

                RaiseEvent OpenConfiguration()
            End If

            remote = Nothing

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    ''' <summary>
    ''' This method provide to get and display a Privacy Policy information
    ''' </summary>
    ''' <returns></returns>
    Private Function readContent(ByVal controllerName As String) As Boolean
        Try
            Dim startTime As Double = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()
            Dim remote As New ProxyWS(Of Models.Network.DocumentModel)
            Dim proceed As Boolean = True

            If proceed Then
                remote.url = AreaCommon.buildURL("/network/" & controllerName & "/")
            End If
            If proceed Then
                proceed = (remote.getData() = "")
            End If
            If proceed Then
                proceed = (remote.data.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete)
            End If
            If proceed Then
                proceed = (remote.data.value.Length > 0)
            End If
            If proceed Then
                documentContent.content.Text = remote.data.value

                coordinate.Text = remote.data.integrityTransactionChain.coordinate
                registrationTimeStamp.Text = remote.data.integrityTransactionChain.registrationTimeStamp
                hash.Text = remote.data.integrityTransactionChain.hash
                progressiveHash.Text = remote.data.integrityTransactionChain.progressiveHash
                responseTime.Text = Int(CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime() - CDec(startTime)) & " ms."
            Else
                MessageBox.Show("Error during connection", "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)

                RaiseEvent OpenConfiguration()
            End If

            remote = Nothing

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    ''' <summary>
    ''' This method provide to read an asset information
    ''' </summary>
    ''' <returns></returns>
    Private Function readAssetInformation(Optional ByVal onlySymbol As Boolean = False) As Boolean
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
            If proceed And Not onlySymbol Then
                assetContent.assetName.Text = remote.data.value.assetInformation.name
                assetContent.shortName.Text = remote.data.value.assetInformation.shortName
                assetContent.symbol.Text = remote.data.value.assetInformation.symbol
                assetContent.digit.Text = remote.data.value.assetInformation.digit
                assetContent.nameUnit.Text = remote.data.value.assetInformation.nameUnit

                If remote.data.value.assetInformation.type = Models.PrimaryChain.AssetModel.AssetTypeEnum.coin Then
                    assetContent.typeAsset.Text = "Coin"
                Else
                    assetContent.typeAsset.Text = "Token"
                End If

                assetContent.unLimited.Checked = remote.data.value.assetPolicyInformation.unlimited
                assetContent.burnable.Checked = remote.data.value.assetPolicyInformation.burnable
                assetContent.quantityTotal.Text = remote.data.value.assetPolicyInformation.qtaTotal
                assetContent.stakable.Checked = remote.data.value.assetPolicyInformation.stakeable
                assetContent.prestake.Checked = remote.data.value.assetPolicyInformation.preStake
                assetContent.initialStakeQuantity.Text = remote.data.value.assetPolicyInformation.qtaInitialStake

                coordinate.Text = remote.data.integrityTransactionChain.coordinate
                registrationTimeStamp.Text = remote.data.integrityTransactionChain.registrationTimeStamp
                hash.Text = remote.data.integrityTransactionChain.hash
                progressiveHash.Text = remote.data.integrityTransactionChain.progressiveHash
                responseTime.Text = Int(CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime() - CDec(startTime)) & " ms."
            End If
            If proceed And onlySymbol Then
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

    ''' <summary>
    ''' This method provide to read a transaction chain parameters
    ''' </summary>
    ''' <returns></returns>
    Private Function readTransactionChainParameters() As Boolean
        Try
            Dim startTime As Double = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()
            Dim remote As New ProxyWS(Of Models.Network.InfoTransactionChainSettingsModel)
            Dim proceed As Boolean = True

            If proceed Then
                remote.url = AreaCommon.buildURL("/network/transactionChainSettings/")
            End If
            If proceed Then
                proceed = (remote.getData() = "")
            End If
            If proceed Then
                proceed = (remote.data.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete)
            End If
            If proceed Then
                proceed = (remote.data.value.blockSizeFrequency.Length > 0)
            End If
            If proceed Then
                transactionChainContent.blockSizeFrequency.Text = remote.data.value.blockSizeFrequency
                transactionChainContent.numberBlockInVolume.Text = remote.data.value.numberBlockInVolume
                transactionChainContent.maxTimeOutResponseNode.Text = remote.data.value.maxTimeOutNotEvaluateNode
                transactionChainContent.maxTimeOutNotEvaluateNode.Text = remote.data.value.maxTimeOutNotEvaluateNode
                transactionChainContent.initialCoinReleaseBlock.Text = remote.data.value.initialCoinReleasePerBlock
                transactionChainContent.ruleFutureRelease.Text = remote.data.value.ruleFutureRelease
                transactionChainContent.reviewReleaseAlgorithm.Text = remote.data.value.reviewReleaseAlgorithm
                transactionChainContent.consensusMethod.Text = remote.data.value.consensusMethod
                transactionChainContent.minimalMaintainRequest.Text = remote.data.value.minimalMaintainRequest
                transactionChainContent.minimalMaintainConsensus.Text = remote.data.value.minimalMaintainConsensus
                transactionChainContent.minimalMaintainBulletines.Text = remote.data.value.minimalMaintainBulletines
                transactionChainContent.minimalMaintainRejected.Text = remote.data.value.minimalMaintainRejected
                transactionChainContent.minimalMaintainTrashed.Text = remote.data.value.minimalMaintainTrashed
                transactionChainContent.minimalMaintainInternal.Text = remote.data.value.minimalMaintainInternalRegistry

                coordinate.Text = remote.data.integrityTransactionChain.coordinate
                registrationTimeStamp.Text = remote.data.integrityTransactionChain.registrationTimeStamp
                hash.Text = remote.data.integrityTransactionChain.hash
                progressiveHash.Text = remote.data.integrityTransactionChain.progressiveHash
                responseTime.Text = Int(CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime() - CDec(startTime)) & " ms."
            Else
                MessageBox.Show("Error during connection", "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)

                RaiseEvent OpenConfiguration()
            End If

            remote = Nothing

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    ''' <summary>
    ''' This method provide to read a Refund Plan information
    ''' </summary>
    ''' <returns></returns>
    Private Function readRefundPlan() As Boolean
        Try
            Dim startTime As Double = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()
            Dim remote As New ProxyWS(Of Models.Network.InfoRefundPlanModel)
            Dim proceed As Boolean = True

            If proceed Then
                remote.url = AreaCommon.buildURL("/network/refundPlan/")
            End If
            If proceed Then
                proceed = (remote.getData() = "")
            End If
            If proceed Then
                proceed = (remote.data.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete)
            End If
            If proceed Then
                proceed = (remote.data.value.items.Count > 0)
            End If
            If proceed Then
                If (_Symbol.Length = 0) Then
                    readAssetInformation(True)
                End If

                refundPlanContent.symbolCurrency = _Symbol

                refundPlanContent.code.Text = remote.data.value.code

                For Each item In remote.data.value.items
                    refundPlanContent.loadDataIntoGrid(item)
                Next

                coordinate.Text = remote.data.integrityTransactionChain.coordinate
                registrationTimeStamp.Text = remote.data.integrityTransactionChain.registrationTimeStamp
                hash.Text = remote.data.integrityTransactionChain.hash
                progressiveHash.Text = remote.data.integrityTransactionChain.progressiveHash
                responseTime.Text = Int(CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime() - CDec(startTime)) & " ms."
            Else
                MessageBox.Show("Error during connection", "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)

                RaiseEvent OpenConfiguration()
            End If

            remote = Nothing

            Return True
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

            networkContent.Visible = False
            documentContent.Visible = False
            assetContent.Visible = False
            transactionChainContent.Visible = False
            refundPlanContent.Visible = False

            Select Case _Type
                Case ManageType.netWorkInformation
                    titlePage.Text = "Network Information"

                    controlObject = networkContent

                    readNetworkInformation()
                Case ManageType.whitePaper
                    titlePage.Text = "Whitepaper"

                    controlObject = documentContent

                    readContent("whitePaper")
                Case ManageType.yellowPaper
                    titlePage.Text = "Yellowpaper"

                    controlObject = documentContent

                    readContent("yellowPaper")
                Case ManageType.assetInformation
                    titlePage.Text = "Asset Information"

                    controlObject = assetContent

                    readAssetInformation()
                Case ManageType.transactionChainParameters
                    titlePage.Text = "Transaction Chain Parameters"

                    controlObject = transactionChainContent

                    readTransactionChainParameters()
                Case ManageType.privacyPolicy
                    titlePage.Text = "Privacy Policy"

                    controlObject = documentContent

                    readContent("privacyPolicy")
                Case ManageType.generalConditions
                    titlePage.Text = "General Conditions"

                    controlObject = documentContent

                    readContent("generalConditions")
                Case ManageType.refundPlan
                    titlePage.Text = "Refund Plan"

                    controlObject = refundPlanContent

                    readRefundPlan()
                Case Else
                    Return
            End Select

            controlObject.Visible = True
            controlObject.Location = New Point(0, 0)
            controlObject.Dock = DockStyle.Fill
        End Set
    End Property

    Private Sub NetworkInformation_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Try
            mainTab.Width = Me.Width - 21
        Catch ex As Exception
        End Try
        Try
            mainTab.Height = Me.Height - 59
        Catch ex As Exception
        End Try
    End Sub

End Class
