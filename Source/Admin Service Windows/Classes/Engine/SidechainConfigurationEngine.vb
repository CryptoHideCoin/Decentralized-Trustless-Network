Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.DataFileManagement



Namespace AreaEngine


    Public Class SidechainConfigurationEngine

        Public cacheList As New List(Of AreaCommon.Models.Define.ItemKeyDescriptionModel)

        Private _Keys As New Dictionary(Of String, String)



        Private Function copyDataIntoResponse(ByRef data As AreaCommon.Models.Define.ChainModel) As AreaCommon.Models.Define.ChainResponseModel

            Dim item As New AreaCommon.Models.Define.ChainResponseModel
            Dim newReward As AreaCommon.Models.Define.TiersOfRewards

            Try

                item.identity = data.identity
                item.name = data.name
                item.preminedCoin = data.preminedCoin
                item.assetId = data.assetId
                item.priceListId = data.priceListId
                item.privacyPaperId = data.privacyPaperId
                item.refundPlanId = data.refundPlanId
                item.termsAndConditionsId = data.termsAndConditionsId
                item.uniqueChainKey = data.uniqueChainKey
                item.visionPaperId = data.visionPaperId
                item.walletAddressPremined = data.walletAddressPremined
                item.whitePaperId = data.whitePaperId
                item.yellowPaperId = data.yellowPaperId

                For Each singleReward In data.rewardPlan

                    newReward = New AreaCommon.Models.Define.TiersOfRewards

                    newReward.from = singleReward.from
                    newReward.distribute = singleReward.distribute

                    item.rewardPlan.Add(newReward)

                Next

            Catch ex As Exception
            End Try

            Return item

        End Function


        Public Function init() As Boolean

            Try

                Dim engine As New BaseFileDB(Of AreaCommon.Models.Define.ChainModel)
                Dim singleItem As AreaCommon.Models.Define.ItemKeyDescriptionModel

                AreaCommon.log.track("SidechainConfigurationEngine.init", "Begin")

                cacheList.Clear()
                _Keys.Clear()

                For Each singleFile In IO.Directory.GetFiles(AreaCommon.paths.transactionChain.defines.sideChainContracts)

                    If (IO.Path.GetExtension(singleFile).ToLower.CompareTo(".definition") = 0) Then

                        engine.fileName = singleFile

                        If engine.read() Then

                            singleItem = New AreaCommon.Models.Define.ItemKeyDescriptionModel

                            singleItem.identity = engine.data.identity
                            singleItem.name = engine.data.name

                            cacheList.Add(singleItem)
                            _Keys.Add(singleItem.identity, singleItem.identity)

                        End If

                    End If

                Next
                Return True

            Catch ex As Exception
                AreaCommon.log.track("SidechainConfigurationEngine.init", "Error:" & ex.Message, "fatal")

                AreaCommon.closeApplication()

                Return False
            Finally
                AreaCommon.log.track("SidechainConfigurationEngine.init", "Complete")
            End Try

        End Function


        Public Function getData(ByVal id As String) As AreaCommon.Models.Define.ChainResponseModel

            Dim item As New AreaCommon.Models.Define.ChainResponseModel

            Try

                If _Keys.ContainsKey(id) Then

                    Dim pathFile As String
                    Dim engine As New BaseFileDB(Of AreaCommon.Models.Define.ChainModel)

                    AreaCommon.log.track("SidechainConfigurationEngine.getData", "Begin")

                    pathFile = IO.Path.Combine(AreaCommon.paths.transactionChain.defines.sideChainContracts, id & ".Definition")

                    engine.fileName = pathFile

                    If engine.read() Then
                        Return copyDataIntoResponse(engine.data)
                    Else
                        item.response.error = True
                        item.response.description = "503 - Internal Error"
                    End If

                Else
                    item.response.error = True
                    item.response.description = "Not found"
                End If

            Catch ex As Exception
                AreaCommon.log.track("SidechainConfigurationEngine.getData", "Error:" & ex.Message, "fatal")

                item.response.error = True
                item.response.description = "503 - Internal Error"
            Finally
                AreaCommon.log.track("SidechainConfigurationEngine.getData", "Complete")
            End Try

            Return item

        End Function


        Private Function compose(ByVal id As String, ByVal data As AreaCommon.Models.Define.ChainBaseModel) As AreaCommon.Models.Define.ChainModel

            Dim item As New AreaCommon.Models.Define.ChainModel
            Dim newReward As AreaCommon.Models.Define.TiersOfRewards

            Try

                item.identity = id
                item.name = data.name
                item.assetId = data.assetId
                item.preminedCoin = data.preminedCoin
                item.priceListId = data.priceListId
                item.privacyPaperId = data.privacyPaperId
                item.refundPlanId = data.refundPlanId
                item.termsAndConditionsId = data.termsAndConditionsId
                item.uniqueChainKey = data.uniqueChainKey
                item.visionPaperId = data.visionPaperId
                item.walletAddressPremined = data.walletAddressPremined
                item.whitePaperId = data.whitePaperId
                item.yellowPaperId = data.yellowPaperId

                For Each singleReward In data.rewardPlan

                    newReward = New AreaCommon.Models.Define.TiersOfRewards

                    newReward.from = singleReward.from
                    newReward.distribute = singleReward.distribute

                    item.rewardPlan.Add(newReward)

                Next

            Catch ex As Exception
            End Try

            Return item

        End Function


        Public Function createKeyDescription(ByVal id As String, ByVal name As String) As AreaCommon.Models.Define.ItemKeyDescriptionModel

            Dim tmp As New AreaCommon.Models.Define.ItemKeyDescriptionModel

            tmp.identity = id
            tmp.name = name

            Return tmp

        End Function


        Public Function update(ByVal originalId As String, ByVal value As AreaCommon.Models.Define.ChainBaseModel) As Boolean

            Dim item As New AreaCommon.Models.Define.ChainModel
            Dim id As String = ""
            Dim generateNewElement As Boolean = False

            Try

                Dim engine As New BaseFileDB(Of AreaCommon.Models.Define.ChainModel)
                Dim pathFile As String

                AreaCommon.log.track("SidechainConfigurationEngine.update", "Begin")

                id = value.getHash()

                If _Keys.ContainsKey(id) Then
                    Return True
                End If

                id = value.getHash()

                _Keys.Add(id, id)

                cacheList.Add(createKeyDescription(id, value.name))

                pathFile = IO.Path.Combine(AreaCommon.paths.transactionChain.defines.sideChainContracts, id & ".Definition")

                If Not IO.File.Exists(pathFile) Then

                    engine.fileName = pathFile

                    engine.data = compose(id, value)

                    If engine.save() Then

                        If originalId <> "" Then
                            Return delete(originalId)
                        Else
                            Return True
                        End If

                    Else
                        Return False
                    End If
                Else
                    If (originalId <> "") Then
                        Return delete(originalId)
                    Else
                        Return True
                    End If
                End If

            Catch ex As Exception
                AreaCommon.log.track("SidechainConfigurationEngine.update", "Error:" & ex.Message, "fatal")
                Return False
            Finally
                AreaCommon.log.track("SidechainConfigurationEngine.update", "Complete")
            End Try

        End Function


        Public Function delete(ByVal id As String) As Boolean

            Dim item As New AreaCommon.Models.Define.ChainModel

            Try

                Dim engine As New BaseFileDB(Of AreaCommon.Models.Define.ChainModel)
                Dim pathFile As String

                AreaCommon.log.track("SidechainConfigurationEngine.delete", "Begin")

                If _Keys.ContainsKey(id) Then

                    pathFile = IO.Path.Combine(AreaCommon.paths.transactionChain.defines.sideChainContracts, id & ".Definition")

                    Try
                        IO.File.Delete(pathFile)
                    Catch ex As Exception
                    End Try

                    _Keys.Remove(id)

                    For Each tmp In cacheList

                        If tmp.identity.CompareTo(id) = 0 Then
                            cacheList.Remove(tmp)
                            Return True
                        End If

                    Next

                End If

                Return True

            Catch ex As Exception
                AreaCommon.log.track("SidechainConfigurationEngine.delete", "Error:" & ex.Message, "fatal")
                Return False

            Finally
                AreaCommon.log.track("SidechainConfigurationEngine.delete", "Complete")
            End Try

        End Function


    End Class


End Namespace
