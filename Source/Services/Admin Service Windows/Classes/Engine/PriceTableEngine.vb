Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.DataFileManagement



Namespace AreaEngine


    Public Class PriceTableEngine

        Public cacheList As New List(Of AreaCommon.Models.Define.ItemKeyDescriptionModel)

        Private _Keys As New Dictionary(Of String, String)




        Public Function copyDataIntoResponse(ByRef data As AreaCommon.Models.Define.PriceTableModel) As AreaCommon.Models.Define.PriceTableResponseModel

            Dim item As New AreaCommon.Models.Define.PriceTableResponseModel
            Dim newElement As AreaCommon.Models.Define.ItemPriceTableModel

            Try

                item.effectiveDate = data.effectiveDate
                item.name = data.name
                item.identity = data.identity

                For Each singleData In data.items

                    newElement = New AreaCommon.Models.Define.ItemPriceTableModel

                    newElement.code = singleData.code
                    newElement.contribute = singleData.contribute
                    newElement.description = singleData.description

                    item.items.Add(newElement)

                Next

                Return item

            Catch ex As Exception
            End Try

            Return item

        End Function


        Public Function init() As Boolean

            Try

                Dim engine As New BaseFileDB(Of AreaCommon.Models.Define.PriceTableModel)
                Dim singleItem As AreaCommon.Models.Define.ItemKeyDescriptionModel

                AreaCommon.log.track("PriceTableEngine.init", "Begin")

                cacheList.Clear()
                _Keys.Clear()

                For Each singleFile In IO.Directory.GetFiles(AreaCommon.paths.workDefine.pricesList)

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
                AreaCommon.log.track("PriceTableEngine.init", "Error:" & ex.Message, "fatal")

                AreaCommon.closeApplication()

                Return False
            Finally
                AreaCommon.log.track("PriceTableEngine.init", "Complete")
            End Try

        End Function


        Public Function getData(ByVal id As String) As AreaCommon.Models.Define.PriceTableResponseModel

            Dim item As New AreaCommon.Models.Define.PriceTableResponseModel

            Try

                If _Keys.ContainsKey(id) Then

                    Dim pathFile As String
                    Dim engine As New BaseFileDB(Of AreaCommon.Models.Define.PriceTableModel)

                    AreaCommon.log.track("PriceTableEngine.getData", "Begin")

                    pathFile = IO.Path.Combine(AreaCommon.paths.workDefine.pricesList, id & ".Definition")

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
                AreaCommon.log.track("PriceTableEngine.getData", "Error:" & ex.Message, "fatal")

                item.response.error = True
                item.response.description = "503 - Internal Error"
            Finally
                AreaCommon.log.track("PriceTableEngine.getData", "Complete")
            End Try

            Return item

        End Function


        Private Function compose(ByVal id As String, ByVal value As AreaCommon.Models.Define.PriceTableBaseModel) As AreaCommon.Models.Define.PriceTableModel

            Dim item As New AreaCommon.Models.Define.PriceTableModel
            Dim newElement As AreaCommon.Models.Define.ItemPriceTableModel

            Try

                item.identity = id
                item.name = value.name
                item.effectiveDate = value.effectiveDate

                For Each singleData In value.items

                    newElement = New AreaCommon.Models.Define.ItemPriceTableModel

                    newElement.code = singleData.code
                    newElement.contribute = singleData.contribute
                    newElement.description = singleData.description

                    item.items.Add(newElement)

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


        Private Sub standardizeContribute(ByVal value As AreaCommon.Models.Define.PriceTableBaseModel)

            Try
                For Each item In value.items
                    item.contribute = Decimal.Parse(item.contribute.ToString())
                Next
            Catch ex As Exception
            End Try

        End Sub


        Public Function update(ByVal originalId As String, ByVal value As AreaCommon.Models.Define.PriceTableBaseModel) As Boolean

            Dim item As New AreaCommon.Models.Define.PriceTableModel
            Dim id As String = ""
            Dim generateNewElement As Boolean = False

            Try

                Dim engine As New BaseFileDB(Of AreaCommon.Models.Define.PriceTableModel)
                Dim pathFile As String

                AreaCommon.log.track("PriceTableEngine.update", "Begin")

                'standardizeContribute(value)
                id = value.getHash()

                If _Keys.ContainsKey(id) Then
                    Return True
                End If

                id = value.getHash()

                _Keys.Add(id, id)

                cacheList.Add(createKeyDescription(id, value.name))

                pathFile = IO.Path.Combine(AreaCommon.paths.workDefine.pricesList, id & ".Definition")

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
                AreaCommon.log.track("PriceTableEngine.update", "Error:" & ex.Message, "fatal")
                Return False
            Finally
                AreaCommon.log.track("PriceTableEngine.update", "Complete")
            End Try

        End Function


        Public Function delete(ByVal id As String) As Boolean

            Dim item As New AreaCommon.Models.Define.PriceTableModel

            Try

                Dim engine As New BaseFileDB(Of AreaCommon.Models.Define.PriceTableModel)
                Dim pathFile As String

                AreaCommon.log.track("PriceTableEngine.delete", "Begin")

                If _Keys.ContainsKey(id) Then

                    pathFile = IO.Path.Combine(AreaCommon.paths.workDefine.pricesList, id & ".Definition")

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
                AreaCommon.log.track("PriceTableEngine.delete", "Error:" & ex.Message, "fatal")
                Return False

            Finally
                AreaCommon.log.track("PriceTableEngine.delete", "Complete")
            End Try

        End Function


    End Class


End Namespace