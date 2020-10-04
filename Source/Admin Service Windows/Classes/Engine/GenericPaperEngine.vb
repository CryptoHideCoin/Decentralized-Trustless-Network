Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.DataFileManagement



Namespace AreaEngine


    Public Class GenericPaperEngine

        Public cacheList As New List(Of AreaCommon.Models.Define.ItemKeyDescriptionModel)

        Private _Keys As New Dictionary(Of String, String)

        Private _documentPath As String = ""




        Public Function copyDataIntoResponse(ByRef data As AreaCommon.Models.Define.GenericPaperModel) As AreaCommon.Models.Define.GenericPaperResponseModel

            Dim item As New AreaCommon.Models.Define.GenericPaperResponseModel

            Try

                item.Identity = data.identity
                item.name = data.name
                item.content = data.content

            Catch ex As Exception
            End Try

            Return item

        End Function


        Public Function init(ByVal pathDocuments As String) As Boolean

            Try

                Dim engine As New BaseFileDB(Of AreaCommon.Models.Define.GenericPaperModel)
                Dim singleItem As AreaCommon.Models.Define.ItemKeyDescriptionModel

                AreaCommon.log.track("GenericPaperEngine.init", "Begin")

                cacheList.Clear()
                _Keys.Clear()

                _documentPath = pathDocuments

                For Each singleFile In IO.Directory.GetFiles(_documentPath)

                    If (IO.Path.GetExtension(singleFile).ToLower.CompareTo(".definition") = 0) Then

                        engine.fileName = singleFile

                        If engine.read() Then

                            singleItem = New AreaCommon.Models.Define.ItemKeyDescriptionModel

                            singleItem.identity = engine.data.Identity
                            singleItem.name = engine.data.name

                            cacheList.Add(singleItem)
                            _Keys.Add(singleItem.identity, singleItem.identity)

                        End If

                    End If

                Next
                Return True

            Catch ex As Exception
                AreaCommon.log.track("GenericPaperEngine.init", "Error:" & ex.Message, "fatal")

                AreaCommon.closeApplication()

                Return False
            Finally
                AreaCommon.log.track("GenericPaperEngine.init", "Complete")
            End Try

        End Function


        Public Function getData(ByVal id As String) As AreaCommon.Models.Define.GenericPaperResponseModel

            Dim item As New AreaCommon.Models.Define.GenericPaperResponseModel

            Try

                If _Keys.ContainsKey(id) Then

                    Dim pathFile As String
                    Dim engine As New BaseFileDB(Of AreaCommon.Models.Define.GenericPaperModel)

                    AreaCommon.log.track("GenericPaperEngine.getData", "Begin")

                    pathFile = IO.Path.Combine(_documentPath, id & ".Definition")

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
                AreaCommon.log.track("GenericPaperEngine.getData", "Error:" & ex.Message, "fatal")

                item.response.error = True
                item.response.description = "503 - Internal Error"
            Finally
                AreaCommon.log.track("GenericPaperEngine.getData", "Complete")
            End Try

            Return item

        End Function


        Private Function compose(ByVal id As String, ByVal value As AreaCommon.Models.Define.GenericPaperBaseModel) As AreaCommon.Models.Define.GenericPaperModel

            Dim item As New AreaCommon.Models.Define.GenericPaperModel

            Try

                item.identity = id
                item.name = value.name
                item.content = value.content

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


        Public Function update(ByVal originalId As String, ByVal value As AreaCommon.Models.Define.GenericPaperBaseModel) As Boolean

            Dim item As New AreaCommon.Models.Define.GenericPaperModel
            Dim id As String = ""
            Dim generateNewElement As Boolean = False

            Try

                Dim engine As New BaseFileDB(Of AreaCommon.Models.Define.GenericPaperModel)
                Dim pathFile As String

                AreaCommon.log.track("GenericPaperEngine.update", "Begin")

                id = value.getHash()

                If _Keys.ContainsKey(id) Then
                    Return True
                End If

                id = value.getHash()

                _Keys.Add(id, id)

                cacheList.Add(createKeyDescription(id, value.name))

                pathFile = IO.Path.Combine(_documentPath, id & ".Definition")

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
                AreaCommon.log.track("GenericPaperEngine.update", "Error:" & ex.Message, "fatal")
                Return False
            Finally
                AreaCommon.log.track("GenericPaperEngine.update", "Complete")
            End Try

        End Function


        Public Function delete(ByVal id As String) As Boolean

            Dim item As New AreaCommon.Models.Define.GenericPaperModel

            Try

                Dim engine As New BaseFileDB(Of AreaCommon.Models.Define.GenericPaperModel)
                Dim pathFile As String

                AreaCommon.log.track("GenericPaperEngine.delete", "Begin")

                If _Keys.ContainsKey(id) Then

                    pathFile = IO.Path.Combine(_documentPath, id & ".Definition")

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
                AreaCommon.log.track("GenericPaperEngine.delete", "Error:" & ex.Message, "fatal")
                Return False

            Finally
                AreaCommon.log.track("GenericPaperEngine.delete", "Complete")
            End Try

        End Function


    End Class


End Namespace
