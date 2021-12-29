Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.Communication
Imports CHCCommonLibrary.AreaCommon.Models.General
Imports CHCProtocolLibrary.AreaCommon



Public Class ChainDetail

    ''' <summary>
    ''' This enumeration contain the type of chain
    ''' </summary>
    Public Enum ChainSectionType
        notDefined
        main
        lastBlock
        parameters
        protocol
        priceList
        policyPrivacy
        TermsAndCondition
    End Enum


    Private Property _Type As ChainSectionType

    ''' <summary>
    ''' This property set/get the type of chain section
    ''' </summary>
    ''' <returns></returns>
    Public Property type As ChainSectionType
        Get
            Return _Type
        End Get
        Set(value As ChainSectionType)
            mainDataChain.Visible = False
            lastBlockData.Visible = False
            parameterChainData.Visible = False
            setProtocolChain.Visible = False
            priceListPanel.Visible = False
            contentPanel.Visible = False

            Select Case value
                Case ChainSectionType.main : mainDataChain.Visible = True
                Case ChainSectionType.lastBlock : lastBlockData.Visible = True
                Case ChainSectionType.parameters : parameterChainData.Visible = True
                Case ChainSectionType.protocol
                    setProtocolChain.Visible = True
                    setProtocolChain.Dock = DockStyle.Fill
                Case ChainSectionType.priceList : priceListPanel.Visible = True
                Case ChainSectionType.policyPrivacy,
                     ChainSectionType.TermsAndCondition : contentPanel.Visible = True
            End Select
        End Set
    End Property

    ''' <summary>
    ''' This method provide to build a URL
    ''' </summary>
    ''' <param name="api"></param>
    ''' <returns></returns>
    Private Function buildURL(ByVal api As String) As String
        Dim url As String = ""
        Try
            Dim proceed As Boolean = True

            If proceed Then
                proceed = (AreaCommon.settings.data.urlPublic.Length > 0)
            End If
            If proceed Then
                If AreaCommon.settings.data.useServiceSecureProtocol Then
                    url = "https://"
                Else
                    url = "http://"
                End If

                url += AreaCommon.settings.data.urlPublic & "/api/" & AreaCommon.settings.data.serviceId & api
            End If
        Catch ex As Exception
        End Try

        Return url
    End Function

    ''' <summary>
    ''' This method provide to load a data integration into UI
    ''' </summary>
    ''' <returns></returns>
    Private Function loadDataIntegration(ByVal infoIntegrity As IdentifyLastTransaction, ByVal startTime As Double) As Boolean
        Try
            coordinate.Text = infoIntegrity.coordinate
            If (infoIntegrity.registrationTimeStamp = 0) Then
                registrationTimeStamp.Text = "---"
            Else
                registrationTimeStamp.Text = infoIntegrity.registrationTimeStamp
            End If
            hash.Text = infoIntegrity.hash
            progressiveHash.Text = infoIntegrity.progressiveHash
            responseTime.Text = Int(CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime() - CDec(startTime)) & " ms."

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function


    ''' <summary>
    ''' This method provide to load a main data of a chain
    ''' </summary>
    ''' <param name="name"></param>
    ''' <returns></returns>
    Public Function loadData(ByVal name As String) As Boolean
        Try
            Dim startTime As Double = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()
            Dim remote As New ProxyWS(Of Models.Chain.Queries.ChainDataModel)
            Dim proceed As Boolean = True

            If proceed Then
                remote.url = buildURL("/chain/chainData/?name=" & name)
            End If
            If proceed Then
                proceed = (remote.getData() = "")
            End If
            If proceed Then
                proceed = (remote.data.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete)
            End If
            If proceed Then
                proceed = (remote.data.information.name.Length > 0)
            Else
                MessageBox.Show("Error during connection", "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)

                Return False
            End If
            If proceed Then
                mainDataChain.description.Text = remote.data.information.description

                If remote.data.information.privateChain Then
                    mainDataChain.privateChain.Text = "YES"
                Else
                    mainDataChain.privateChain.Text = "NO"
                End If

                loadDataIntegration(remote.data.integrityTransactionChain, startTime)

                mainDataChain.Dock = DockStyle.Fill
            End If

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    ''' <summary>
    ''' This method provide to show a chain last block in the field
    ''' </summary>
    ''' <param name="data"></param>
    ''' <returns></returns>
    Public Function loadChainLastBlock(ByRef data As Models.Chain.Queries.ChainDataLastBlockModel, ByVal activeChain As Boolean) As Boolean
        Try
            Dim startTime As Double = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()

            lastBlockData.lastBlock.Text = CHCCommonLibrary.AreaEngine.Miscellaneous.dateTimeFromTimeStamp(data.integrityTransactionChain.registrationTimeStamp)
            lastBlockData.lastBlock.Text = CHCCommonLibrary.AreaEngine.Miscellaneous.formatDateTimeGMT(lastBlockData.lastBlock.Text)

            lastBlockData.activeChain.Checked = activeChain

            loadDataIntegration(data.integrityTransactionChain, startTime)

            lastBlockData.Dock = DockStyle.Fill

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    ''' <summary>
    ''' This method provide to load a chain parameter into field
    ''' </summary>
    ''' <param name="name"></param>
    ''' <returns></returns>
    Public Function loadChainParameter(ByVal name As String) As Boolean
        Try
            Dim startTime As Double = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()
            Dim remote As New ProxyWS(Of Models.Chain.Queries.ChainParameterDataModel)
            Dim proceed As Boolean = True

            If proceed Then
                remote.url = buildURL("/chain/chainParameter/?name=" & name)
            End If
            If proceed Then
                proceed = (remote.getData() = "")
            End If
            If proceed Then
                proceed = (remote.data.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete)
            End If
            If proceed Then
                proceed = (remote.data.value.blockSizeFrequency.Length > 0)
            Else
                MessageBox.Show("Error during connection", "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)

                Return False
            End If
            If proceed Then
                With remote.data.value
                    parameterChainData.blockSizeFrequency.Text = .blockSizeFrequency
                    parameterChainData.maxTimeOutNotEvaluateNode.Text = .maxTimeOutNotEvaluateNode
                    parameterChainData.maxTimeOutResponseNode.Text = .maxTimeOutNotRespondNode
                    parameterChainData.minimalMaintainBulletines.Text = .minimalMaintainBulletines
                    parameterChainData.minimalMaintainConsensus.Text = .minimalMaintainConsensus
                    parameterChainData.minimalMaintainInternal.Text = .minimalMaintainInternalRegistry
                    parameterChainData.minimalMaintainRejected.Text = .minimalMaintainRejected
                    parameterChainData.minimalMaintainRequest.Text = .minimalMaintainRequest
                    parameterChainData.minimalMaintainTrashed.Text = .minimalMaintainTrashed
                End With

                loadDataIntegration(remote.data.integrityTransactionChain, startTime)

                parameterChainData.Dock = DockStyle.Fill
            End If

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    ''' <summary>
    ''' This method provide to load a set protocol
    ''' </summary>
    ''' <param name="value"></param>
    ''' <returns></returns>
    Public Function loadSetProtocol(ByRef value As CHCProtocolLibrary.AreaCommon.Models.Chain.Queries.SingleSetProtocol) As Boolean
        Try
            Dim startTime As Double = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()

            setProtocolChain.setCode.Text = value.data.setCode
            setProtocolChain.protocol.Text = value.data.protocol
            setProtocolChain.documentation.Text = value.data.documentation

            loadDataIntegration(value.integrity, startTime)

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    ''' <summary>
    ''' This method provide to load a price list
    ''' </summary>
    ''' <param name="chainName"></param>
    ''' <returns></returns>
    Public Function loadPriceList(ByVal chainName As String) As Boolean
        Try
            Dim startTime As Double = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()
            Dim remote As New ProxyWS(Of Models.Chain.Queries.ChainPriceListDataModel)
            Dim proceed As Boolean = True

            If proceed Then
                remote.url = buildURL("/chain/chainPriceList/?name=" & chainName)
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
                priceListPanel.loadEntireData(remote.data.value)

                loadDataIntegration(remote.data.integrityTransactionChain, startTime)

                priceListPanel.Dock = DockStyle.Fill
            End If

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    ''' <summary>
    ''' This method provide to load a Privacy Content
    ''' </summary>
    ''' <param name="chainName"></param>
    ''' <returns></returns>
    Public Function loadPrivacyContent(ByVal chainName As String) As Boolean
        Try
            Dim startTime As Double = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()
            Dim remote As New ProxyWS(Of Models.Chain.Queries.ChainPrivacyPolicyModel)
            Dim proceed As Boolean = True

            If proceed Then
                remote.url = buildURL("/chain/chainPrivacyPolicy/?name=" & chainName)
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
                If (remote.data.value.content.Length > 0) Then
                    contentPanel.content.Text = remote.data.value.content
                Else
                    contentPanel.content.Text = "(not set)"
                End If

                loadDataIntegration(remote.data.integrityTransactionChain, startTime)

                contentPanel.Dock = DockStyle.Fill
            End If

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    ''' <summary>
    ''' This method provide to load Terms and Conditions
    ''' </summary>
    ''' <param name="chainName"></param>
    ''' <returns></returns>
    Public Function loadTermsAndConditions(ByVal chainName As String) As Boolean
        Try
            Dim startTime As Double = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()
            Dim remote As New ProxyWS(Of Models.Chain.Queries.ChainTermsAndConditionsModel)
            Dim proceed As Boolean = True

            If proceed Then
                remote.url = buildURL("/chain/chainTermsAndConditions/?name=" & chainName)
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
                If (remote.data.value.content.Length > 0) Then
                    contentPanel.content.Text = remote.data.value.content
                Else
                    contentPanel.content.Text = "(not set)"
                End If

                loadDataIntegration(remote.data.integrityTransactionChain, startTime)

                contentPanel.Dock = DockStyle.Fill
            End If

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub dataTab_Click(sender As Object, e As EventArgs) Handles dataTab.Click

    End Sub
End Class
