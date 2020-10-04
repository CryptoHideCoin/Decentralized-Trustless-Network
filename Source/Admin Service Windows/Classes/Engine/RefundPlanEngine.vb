Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.DataFileManagement



Namespace AreaEngine


    Public Class RefundPlanEngine

        Public cacheList As New List(Of AreaCommon.Models.Define.ItemKeyDescriptionModel)

        Private _Keys As New Dictionary(Of String, String)



        Private Function copyItemsIntoResponse(ByRef items As List(Of AreaCommon.Models.Define.RefundItem)) As List(Of AreaCommon.Models.Define.RefundItem)

            Dim newItem As AreaCommon.Models.Define.RefundItem
            Dim result As New List(Of AreaCommon.Models.Define.RefundItem)

            For Each item In items

                newItem = New AreaCommon.Models.Define.RefundItem

                newItem.fixValue = item.fixValue
                newItem.percentage = item.percentage
                newItem.recipient = item.recipient

                result.Add(newItem)

            Next

            Return result

        End Function


        Private Function copyDataIntoResponse(ByRef data As AreaCommon.Models.Define.RefundPlanModel) As AreaCommon.Models.Define.RefundPlanResponseModel

            Dim item As New AreaCommon.Models.Define.RefundPlanResponseModel
            Dim newElement As AreaCommon.Models.Define.RefundGroup

            Try

                item.effectiveDate = data.effectiveDate
                item.name = data.name
                item.identity = data.identity

                For Each singleData In data.groups

                    newElement = New AreaCommon.Models.Define.RefundGroup

                    newElement.name = singleData.name
                    newElement.percentage = singleData.percentage
                    newElement.fixValue = singleData.fixValue

                    newElement.items = copyItemsIntoResponse(newElement.items)

                    item.groups.Add(newElement)

                Next

            Catch ex As Exception
            End Try

            Return item

        End Function


        Public Function init() As Boolean

            Try

                Dim engine As New BaseFileDB(Of AreaCommon.Models.Define.RefundPlanModel)
                Dim singleItem As AreaCommon.Models.Define.ItemKeyDescriptionModel

                AreaCommon.log.track("RefundPlanEngine.init", "Begin")

                cacheList.Clear()
                _Keys.Clear()

                For Each singleFile In IO.Directory.GetFiles(AreaCommon.paths.transactionChain.defines.refundPlans)

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
                AreaCommon.log.track("RefundPlanEngine.init", "Error:" & ex.Message, "fatal")

                AreaCommon.closeApplication()

                Return False
            Finally
                AreaCommon.log.track("RefundPlanEngine.init", "Complete")
            End Try

        End Function


        Public Function getData(ByVal id As String) As AreaCommon.Models.Define.RefundPlanResponseModel

            Dim item As New AreaCommon.Models.Define.RefundPlanResponseModel

            Try

                If _Keys.ContainsKey(id) Then

                    Dim pathFile As String
                    Dim engine As New BaseFileDB(Of AreaCommon.Models.Define.RefundPlanModel)

                    AreaCommon.log.track("RefundPlanEngine.getData", "Begin")

                    pathFile = IO.Path.Combine(AreaCommon.paths.transactionChain.defines.refundPlans, id & ".Definition")

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
                AreaCommon.log.track("RefundPlanEngine.getData", "Error:" & ex.Message, "fatal")

                item.response.error = True
                item.response.description = "503 - Internal Error"
            Finally
                AreaCommon.log.track("RefundPlanEngine.getData", "Complete")
            End Try

            Return item

        End Function


        Private Function compose(ByVal id As String, ByVal data As AreaCommon.Models.Define.RefundPlanBaseModel) As AreaCommon.Models.Define.RefundPlanModel

            Dim item As New AreaCommon.Models.Define.RefundPlanModel
            Dim newElement As AreaCommon.Models.Define.RefundGroup

            Try

                item.effectiveDate = data.effectiveDate
                item.name = data.name
                item.identity = id

                For Each singleData In data.groups

                    newElement = New AreaCommon.Models.Define.RefundGroup

                    newElement.name = singleData.name
                    newElement.percentage = singleData.percentage
                    newElement.fixValue = singleData.fixValue

                    newElement.items = copyItemsIntoResponse(newElement.items)

                    item.groups.Add(newElement)

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


        Public Function update(ByVal originalId As String, ByVal value As AreaCommon.Models.Define.RefundPlanBaseModel) As Boolean

            Dim item As New AreaCommon.Models.Define.RefundPlanModel
            Dim id As String = ""
            Dim generateNewElement As Boolean = False

            Try

                Dim engine As New BaseFileDB(Of AreaCommon.Models.Define.RefundPlanModel)
                Dim pathFile As String

                AreaCommon.log.track("RefundPlanEngine.update", "Begin")

                id = value.getHash()

                If _Keys.ContainsKey(id) Then
                    Return True
                End If

                id = value.getHash()

                _Keys.Add(id, id)

                cacheList.Add(createKeyDescription(id, value.name))

                pathFile = IO.Path.Combine(AreaCommon.paths.transactionChain.defines.refundPlans, id & ".Definition")

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
                AreaCommon.log.track("RefundPlanEngine.update", "Error:" & ex.Message, "fatal")
                Return False
            Finally
                AreaCommon.log.track("RefundPlanEngine.update", "Complete")
            End Try

        End Function


        Public Function delete(ByVal id As String) As Boolean

            Dim item As New AreaCommon.Models.Define.RefundPlanModel

            Try

                Dim engine As New BaseFileDB(Of AreaCommon.Models.Define.RefundPlanModel)
                Dim pathFile As String

                AreaCommon.log.track("RefundPlanEngine.delete", "Begin")

                If _Keys.ContainsKey(id) Then

                    pathFile = IO.Path.Combine(AreaCommon.paths.transactionChain.defines.refundPlans, id & ".Definition")

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
                AreaCommon.log.track("RefundPlanEngine.delete", "Error:" & ex.Message, "fatal")
                Return False

            Finally
                AreaCommon.log.track("RefundPlanEngine.delete", "Complete")
            End Try

        End Function


    End Class


End Namespace
