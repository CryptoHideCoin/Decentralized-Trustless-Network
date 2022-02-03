Option Compare Text
Option Explicit On





Namespace CHCEngines


    Public Class TransChainDefinitionEngine

        Inherits CHCCommonLibrary.CHCEngines.Common.BaseFileDB(Of Models.TransChainDefinitionModel)

        Public Class TransChainDefinitionSupportedItem

            Public fileName As String = ""
            Public identity As String = ""

        End Class

        Protected Class ServiceResponseToGetUsedList

            Public identity As String = ""
            Public isUsed As Boolean = False

        End Class

        Private _logEngine As CHCServerSupport.Support.LogEngine
        Private _ActiveUsed As Boolean = False
        Private _Used As Dictionary(Of String, TransChainDefinitionSupportedItem)
        Private _Path As String




        Private Sub trackLog(ByVal position As String, ByVal content As String, Optional ByVal messageType As String = "info", Optional ByVal adapterLog As CHCServerSupport.Support.LogEngine = Nothing)

            If Not IsNothing(adapterLog) Then

                adapterLog.track(position, content, messageType)

            ElseIf Not IsNothing(_logEngine) Then

                _logEngine.track(position, content, messageType)

            End If

        End Sub

        Private Sub createFileName(ByVal path As String, ByVal fileName As String)

            MyBase.fileName = IO.Path.Combine(path, fileName)

        End Sub

        Private Function composeCompletePath(ByVal configurationName As String) As String

            Try

                Dim ext As String = System.IO.Path.GetExtension(configurationName)

                If (ext.Length = 0) Then

                    configurationName += ".transChainDefinition"

                End If

                Return System.IO.Path.Combine(_Path, configurationName)

            Catch ex As Exception

            End Try

            Return ""

        End Function

        Protected Function getServiceResponseToGetUsedList(ByVal singleFile As String) As ServiceResponseToGetUsedList

            Dim tmp As New TransChainDefinitionEngine(_Path, False)
            Dim response As New ServiceResponseToGetUsedList

            tmp.fileName = singleFile

            If tmp.read() Then

                If tmp.data.isUsed Then

                    response.identity = tmp.data.getHash()
                    response.isUsed = True

                End If

            End If

            Return response

        End Function

        Private Sub refreshUsedList(Optional ByVal useLogEngineAccess As Boolean = False, Optional adapterLog As CHCServerSupport.Support.LogEngine = Nothing)

            Try

                If useLogEngineAccess Then

                    adapterLog = _logEngine.createAccess()

                End If

                trackLog("TransChainDefinitionEngine.refreshUsedList", "Begin",, adapterLog)

                Dim tmp As TransChainDefinitionSupportedItem
                Dim dir As New System.IO.DirectoryInfo(_Path)

                _Used = New Dictionary(Of String, TransChainDefinitionSupportedItem)

                trackLog("TransChainDefinitionEngine.refreshUsedList", "set new _Used",, adapterLog)

                For Each singleFile In dir.GetFiles()

                    tmp = New TransChainDefinitionSupportedItem()

                    tmp.fileName = singleFile.ToString.Replace(System.IO.Path.GetExtension(IO.Path.GetFileName(singleFile.Name)), "")

                    With getServiceResponseToGetUsedList(singleFile.Name)

                        If .isUsed Then

                            tmp.identity = .identity

                            _Used.Add(tmp.identity, tmp)

                        End If

                    End With

                Next

            Catch ex As Exception

                trackLog("TransChainDefinitionEngine.refreshUsedList", "Error:" & ex.Message, "Fatal", adapterLog)

            Finally

                trackLog("TransChainDefinitionEngine.refreshUsedList", "Compoleted")

            End Try

        End Sub



        Public Function getList(Optional ByVal useLogEngineAccess As Boolean = False, Optional adapterLog As CHCServerSupport.Support.LogEngine = Nothing) As List(Of String)

            Dim listTmp As New List(Of String)
            Dim tmp As String

            If useLogEngineAccess Then

                adapterLog = _logEngine.createAccess()

            End If

            trackLog("TransChainDefinitionEngine.getList", "Begin", , adapterLog)

            Try

                If Not IsNothing(_Path) Then

                    trackLog("TransChainDefinitionEngine.getList", "_Path is set", , adapterLog)

                    For Each singleFile In IO.Directory.GetFiles(_Path)

                        Try

                            tmp = System.IO.Path.GetFileName(singleFile)

                            tmp = tmp.Replace(System.IO.Path.GetExtension(tmp), "")

                            listTmp.Add(tmp)

                        Catch ex As Exception

                        End Try

                    Next

                End If

            Catch ex As Exception

                trackLog("TransChainDefinitionEngine.getList", "Error:" & ex.Message, "Fatal", adapterLog)

            End Try

            trackLog("TransChainDefinitionEngine.getList", "completed", , adapterLog)

            Return listTmp

        End Function


        Public Function getUsedList() As List(Of String)

            Dim listID As New List(Of String)

            For Each itemUsed In _Used

                listID.Add(itemUsed.Value.identity)

            Next

            Return listID

        End Function


        Public Function getFileNameFromID(ByVal id As String) As String

            If _Used.ContainsKey(id) Then

                Return _Used.Item(id).fileName

            End If

            Return ""

        End Function


        Public Function addNew(ByVal value As Models.TransChainDefinitionRequestModel, Optional ByVal useLogEngineAccess As Boolean = False, Optional adapterLog As CHCServerSupport.Support.LogEngine = Nothing) As Boolean

            If useLogEngineAccess Then

                adapterLog = _logEngine.createAccess()

            End If

            trackLog("TransChainDefinitionEngine.addNew", "Enter with name = " & value.name,, adapterLog)

            Try

                data = value.copyIntoBaseModel()

                trackLog("TransChainDefinitionEngine.addNew", "copyIntoBaseModel executed",, adapterLog)

                fileName = composeCompletePath(value.configurationName)

                trackLog("TransChainDefinitionEngine.addNew", "fileName = " & fileName,, adapterLog)

                If save() Then

                    trackLog("TransChainDefinitionEngine.save", "After save()",, adapterLog)

                    refreshUsedList()

                    Return True

                End If

            Catch ex As Exception

                trackLog("TransChainDefinitionEngine.addNew", "Error:" & ex.Message, "Fatal", adapterLog)

            Finally

                trackLog("TransChainDefinitionEngine.addNew", "Completed")

            End Try

            Return False

        End Function


        Public Function update(ByVal name As String, ByVal value As Models.TransChainDefinitionRequestModel, Optional ByVal useLogEngineAccess As Boolean = False, Optional adapterLog As CHCServerSupport.Support.LogEngine = Nothing) As Boolean

            If useLogEngineAccess Then

                adapterLog = _logEngine.createAccess()

            End If

            trackLog("TransChainDefinitionEngine.update", "Enter with name = " & value.name,, adapterLog)

            Try

                data = value.copyIntoBaseModel()

                trackLog("TransChainDefinitionEngine.update", "set data",, adapterLog)

                If (name.CompareTo(value.configurationName) = 0) Then

                    fileName = composeCompletePath(name)

                    trackLog("TransChainDefinitionEngine.update", "set fileName = " & fileName,, adapterLog)

                Else

                    trackLog("TransChainDefinitionEngine.update", "try to delete a file = " & composeCompletePath(name),, adapterLog)

                    System.IO.File.Delete(composeCompletePath(name))

                    trackLog("TransChainDefinitionEngine.update", "file deleted",, adapterLog)

                    fileName = composeCompletePath(value.configurationName)

                    trackLog("TransChainDefinitionEngine.update", "set fileName = " & fileName,, adapterLog)

                    value.configurationName = ""

                End If

                Return save()

            Catch ex As Exception

                trackLog("TransChainDefinitionEngine.update", "Error:" & ex.Message, "Fatal", adapterLog)

            Finally

                trackLog("TransChainDefinitionEngine.update", "Completed")

            End Try

            Return False

        End Function


        Public Function delete(ByVal name As String, Optional ByVal useLogEngineAccess As Boolean = False, Optional adapterLog As CHCServerSupport.Support.LogEngine = Nothing) As Boolean

            If useLogEngineAccess Then

                adapterLog = _logEngine.createAccess()

            End If

            trackLog("TransChainDefinitionEngine.delete", "Enter with name = " & name,, adapterLog)

            Try

                fileName = composeCompletePath(name)

                trackLog("TransChainDefinitionEngine.delete", "set fileName = " & fileName,, adapterLog)

                If IO.File.Exists(fileName) Then

                    trackLog("TransChainDefinitionEngine.delete", "file exist",, adapterLog)

                    IO.File.Delete(fileName)

                End If

                Return True

            Catch ex As Exception

                trackLog("TransChainDefinitionEngine.delete", "Error:" & ex.Message, "Fatal", adapterLog)

            Finally

                trackLog("TransChainDefinitionEngine.delete", "Completed")

            End Try

            Return False

        End Function


        Public Function item(ByVal searchByName As Boolean, ByVal keyValue As String) As Models.TransChainDefinitionModel

            Try

                If Not searchByName Then

                    Dim tmp As TransChainDefinitionSupportedItem

                    tmp = _Used.Item(keyValue)

                    If IsNothing(tmp) Then

                        Return New Models.TransChainDefinitionModel

                    End If

                    keyValue = tmp.fileName

                End If

                fileName = composeCompletePath(keyValue)

                If read() Then

                    Return data

                End If

            Catch ex As Exception

            End Try

            Return Nothing

        End Function



        Public Sub New(ByVal path As String, Optional ByVal activeUsed As Boolean = True)

            _Path = path

            If activeUsed Then

                refreshUsedList()

                _ActiveUsed = True

            End If

        End Sub


    End Class




End Namespace



