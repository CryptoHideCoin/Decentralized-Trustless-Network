Option Compare Text
Option Explicit On



Namespace AreaEngine


    Public Class CryptoAssetEngine

        Public cacheList As New List(Of AreaCommon.Models.Define.CryptoItemKeyDescriptionModel)

        Private _Keys As New Dictionary(Of String, String)




        Public Function copyDataIntoResponse(ByRef data As AreaCommon.Models.Define.CryptoAssetModel) As AreaCommon.Models.Define.CryptoAssetResponseModel

            Dim item As New AreaCommon.Models.Define.CryptoAssetResponseModel

            Try

                item.burnable = data.burnable
                item.decimalDisplay = data.decimalDisplay
                item.identity = data.identity
                item.limitless = data.limitless
                item.mintable = data.mintable
                item.name = data.name
                item.shortName = data.shortName
                item.symbol = data.symbol
                item.totalCoin = data.totalCoin

            Catch ex As Exception

            End Try

            Return item

        End Function


        Public Function init() As Boolean

            Try

                Dim engine As New CHCCommonLibrary.CHCEngines.Common.BaseFileDB(Of AreaCommon.Models.Define.CryptoAssetModel)
                Dim singleItem As AreaCommon.Models.Define.CryptoItemKeyDescriptionModel

                AreaCommon.log.track("CryptoAssetEngine.init", "Begin")

                For Each singleFile In IO.Directory.GetFiles(AreaCommon.paths.pathTransactionChainDefineAssets)

                    If (IO.Path.GetExtension(singleFile).CompareTo("Definition") = 0) Then

                        engine.fileName = singleFile

                        If engine.read() Then

                            singleItem = New AreaCommon.Models.Define.CryptoItemKeyDescriptionModel

                            singleItem.identity = engine.data.identity
                            singleItem.name = engine.data.name

                            cacheList.Add(singleItem)
                            _Keys.Add(singleItem.identity, singleItem.identity)

                        End If

                    End If

                Next

                Return True

            Catch ex As Exception

                AreaCommon.log.track("CryptoAssetEngine.init", "Error:" & ex.Message, "fatal")

                AreaCommon.closeApplication()

                Return False

            Finally

                AreaCommon.log.track("CryptoAssetEngine.init", "Complete")

            End Try

        End Function


        Public Function getData(ByVal id As String) As AreaCommon.Models.Define.CryptoAssetResponseModel

            Dim item As New AreaCommon.Models.Define.CryptoAssetResponseModel

            Try

                If _Keys.ContainsKey(id) Then

                    Dim pathFile As String
                    Dim engine As New CHCCommonLibrary.CHCEngines.Common.BaseFileDB(Of AreaCommon.Models.Define.CryptoAssetModel)

                    AreaCommon.log.track("CryptoAssetEngine.getData", "Begin")

                    pathFile = IO.Path.Combine(AreaCommon.paths.pathBaseData, "TransactionChain", "Definition", "Assets", id & ".Definition")

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

                AreaCommon.log.track("CryptoAssetEngine.getData", "Error:" & ex.Message, "fatal")

                item.response.error = True
                item.response.description = "503 - Internal Error"

            Finally

                AreaCommon.log.track("CryptoAssetEngine.getData", "Complete")

            End Try

            Return item

        End Function


        Private Function compose(ByVal id As String, ByVal value As AreaCommon.Models.Define.CryptoAssetBaseModel) As AreaCommon.Models.Define.CryptoAssetModel

            Dim item As New AreaCommon.Models.Define.CryptoAssetModel

            Try

                item.identity = id
                item.burnable = value.burnable
                item.decimalDisplay = value.decimalDisplay
                item.limitless = value.limitless
                item.mintable = value.mintable
                item.name = value.name
                item.shortName = value.shortName
                item.symbol = value.symbol
                item.totalCoin = value.totalCoin

            Catch ex As Exception

            End Try

            Return item

        End Function


        Public Function createKeyDescription(ByVal id As String, ByVal name As String) As AreaCommon.Models.Define.CryptoItemKeyDescriptionModel

            Dim tmp As New AreaCommon.Models.Define.CryptoItemKeyDescriptionModel

            tmp.identity = id
            tmp.name = name

            Return tmp

        End Function


        Public Function update(ByVal id As String, ByVal value As AreaCommon.Models.Define.CryptoAssetBaseModel) As Boolean

            Dim item As New AreaCommon.Models.Define.CryptoAssetModel

            Try

                Dim engine As New CHCCommonLibrary.CHCEngines.Common.BaseFileDB(Of AreaCommon.Models.Define.CryptoAssetModel)
                Dim pathFile As String

                AreaCommon.log.track("CryptoAssetEngine.update", "Begin")

                If Not _Keys.ContainsKey(id) Then

                    id = value.getHash()

                    _Keys.Add(id, id)

                    cacheList.Add(createKeyDescription(id, value.name))

                End If

                pathFile = IO.Path.Combine(AreaCommon.paths.pathBaseData, "TransactionChain", "Definition", "Assets", id & ".Definition")

                engine.fileName = pathFile

                engine.data = compose(id, value)

                Return engine.save()

            Catch ex As Exception

                AreaCommon.log.track("CryptoAssetEngine.update", "Error:" & ex.Message, "fatal")

                Return False

            Finally

                AreaCommon.log.track("CryptoAssetEngine.update", "Complete")

            End Try

        End Function


        Public Function delete(ByVal id As String) As Boolean

            Dim item As New AreaCommon.Models.Define.CryptoAssetModel

            Try

                Dim engine As New CHCCommonLibrary.CHCEngines.Common.BaseFileDB(Of AreaCommon.Models.Define.CryptoAssetModel)
                Dim pathFile As String

                AreaCommon.log.track("CryptoAssetEngine.delete", "Begin")

                If _Keys.ContainsKey(id) Then

                    pathFile = IO.Path.Combine(AreaCommon.paths.pathBaseData, "TransactionChain", "Definition", "Assets", id & ".Definition")

                    Try

                        IO.File.Delete(pathFile)

                    Catch ex As Exception

                    End Try

                    _Keys.Remove(id)

                    For Each tmp In cacheList

                        If tmp.identity.CompareTo(id) = 0 Then

                            cacheList.Remove(tmp)

                        End If

                    Next

                End If

                Return True

            Catch ex As Exception

                AreaCommon.log.track("CryptoAssetEngine.delete", "Error:" & ex.Message, "fatal")

                Return False

            Finally

                AreaCommon.log.track("CryptoAssetEngine.delete", "Complete")

            End Try

        End Function


    End Class


End Namespace

