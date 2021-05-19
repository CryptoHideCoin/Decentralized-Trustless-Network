Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.DataFileManagement



Namespace AreaEngine


    Public Class ReferenceProtocolEngine

        Public cacheList As New List(Of AreaCommon.Models.Define.ItemKeyDescriptionModel)

        Private _Keys As New Dictionary(Of String, String)




        Public Function copyDataIntoResponse(ByRef data As AreaCommon.Models.Define.ReferenceProtocolModel) As AreaCommon.Models.Define.ReferenceProtocolResponseModel

            Dim item As New AreaCommon.Models.Define.ReferenceProtocolResponseModel
            Dim newElement As AreaCommon.Models.Define.ReferenceModel

            Try

                item.name = data.name
                item.releaseProtocol = data.releaseProtocol
                item.Identity = data.Identity

                For Each singleData In data.references

                    newElement = New AreaCommon.Models.Define.ReferenceModel

                    newElement.code = singleData.code
                    newElement.description = singleData.description

                    item.references.Add(newElement)

                Next

                Return item

            Catch ex As Exception
            End Try

            Return item

        End Function


        Public Function init() As Boolean

            Try

                Dim engine As New BaseFileDB(Of AreaCommon.Models.Define.ReferenceProtocolModel)
                Dim singleItem As AreaCommon.Models.Define.ItemKeyDescriptionModel

                AreaCommon.log.track("ReferenceProtocolEngine.init", "Begin")

                cacheList.Clear()
                _Keys.Clear()

                For Each singleFile In IO.Directory.GetFiles(AreaCommon.paths.workDefine.referenceProtocols)

                    If (IO.Path.GetExtension(singleFile).ToLower.CompareTo(".definition") = 0) Then

                        engine.fileName = singleFile

                        If engine.read() Then

                            singleItem = New AreaCommon.Models.Define.ItemKeyDescriptionModel

                            singleItem.identity = engine.data.Identity
                            singleItem.name = engine.data.name & " rel." & engine.data.releaseProtocol

                            cacheList.Add(singleItem)
                            _Keys.Add(singleItem.identity, singleItem.identity)

                        End If

                    End If

                Next
                Return True

            Catch ex As Exception
                AreaCommon.log.track("ReferenceProtocolEngine.init", "Error:" & ex.Message, "fatal")

                AreaCommon.closeApplication()

                Return False
            Finally
                AreaCommon.log.track("ReferenceProtocolEngine.init", "Complete")
            End Try

        End Function


        Public Function getData(ByVal id As String) As AreaCommon.Models.Define.ReferenceProtocolResponseModel

            Dim item As New AreaCommon.Models.Define.ReferenceProtocolResponseModel

            Try

                If _Keys.ContainsKey(id) Then

                    Dim pathFile As String
                    Dim engine As New BaseFileDB(Of AreaCommon.Models.Define.ReferenceProtocolModel)

                    AreaCommon.log.track("ReferenceProtocolEngine.getData", "Begin")

                    pathFile = IO.Path.Combine(AreaCommon.paths.workDefine.referenceProtocols, id & ".Definition")

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
                AreaCommon.log.track("ReferenceProtocolEngine.getData", "Error:" & ex.Message, "fatal")

                item.response.error = True
                item.response.description = "503 - Internal Error"
            Finally
                AreaCommon.log.track("ReferenceProtocolEngine.getData", "Complete")
            End Try

            Return item

        End Function


        Private Function compose(ByVal id As String, ByVal value As AreaCommon.Models.Define.ReferenceProtocolBaseModel) As AreaCommon.Models.Define.ReferenceProtocolModel

            Dim item As New AreaCommon.Models.Define.ReferenceProtocolModel
            Dim newElement As AreaCommon.Models.Define.ReferenceModel

            Try

                item.Identity = id
                item.name = value.name
                item.releaseProtocol = value.releaseProtocol

                For Each singleData In value.references

                    newElement = New AreaCommon.Models.Define.ReferenceModel

                    newElement.code = singleData.code
                    newElement.description = singleData.description

                    item.references.Add(newElement)

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


        Public Function update(ByVal originalId As String, ByVal value As AreaCommon.Models.Define.ReferenceProtocolBaseModel) As Boolean

            Dim item As New AreaCommon.Models.Define.ReferenceModel
            Dim id As String = ""
            Dim generateNewElement As Boolean = False

            Try

                Dim engine As New BaseFileDB(Of AreaCommon.Models.Define.ReferenceProtocolModel)
                Dim pathFile As String

                AreaCommon.log.track("ReferenceProtocolEngine.update", "Begin")

                id = value.getHash()

                If _Keys.ContainsKey(id) Then
                    Return True
                End If

                id = value.getHash()

                _Keys.Add(id, id)

                cacheList.Add(createKeyDescription(id, value.name & " rel." & value.releaseProtocol))

                pathFile = IO.Path.Combine(AreaCommon.paths.workDefine.referenceProtocols, id & ".Definition")

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
                AreaCommon.log.track("ReferenceProtocolEngine.update", "Error:" & ex.Message, "fatal")
                Return False
            Finally
                AreaCommon.log.track("ReferenceProtocolEngine.update", "Complete")
            End Try

        End Function


        Public Function delete(ByVal id As String) As Boolean

            Dim item As New AreaCommon.Models.Define.ReferenceProtocolModel

            Try

                Dim engine As New BaseFileDB(Of AreaCommon.Models.Define.ReferenceProtocolModel)
                Dim pathFile As String

                AreaCommon.log.track("ReferenceProtocolEngine.delete", "Begin")

                If _Keys.ContainsKey(id) Then

                    pathFile = IO.Path.Combine(AreaCommon.paths.workDefine.referenceProtocols, id & ".Definition")

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
                AreaCommon.log.track("ReferenceProtocolEngine.delete", "Error:" & ex.Message, "fatal")
                Return False

            Finally
                AreaCommon.log.track("ReferenceProtocolEngine.delete", "Complete")
            End Try

        End Function


    End Class


End Namespace
