Option Compare Text
Option Explicit On

Imports CHC





Namespace CHCEngines


    Public Class CryptoAssetDefinitionEngine

        Inherits CHCCommonLibrary.CHCEngines.Common.BaseFileDB(Of Models.CryptoAssetModel)

        Public Class ValueContractSupportedItem

            Public fileName As String = ""
            Public identity As String = ""

        End Class

        Protected Class ServiceResponseToGetUsedList

            Public identity As String = ""
            Public isUsed As Boolean = False

        End Class

        Private _logEngine As CHCServerSupport.Support.LogEngine
        Private _ActiveUsed As Boolean = False
        Private _Used As Dictionary(Of String, ValueContractSupportedItem)
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

                    configurationName += ".CryptoAssetDefinition"

                End If

                Return System.IO.Path.Combine(_Path, configurationName)

            Catch ex As Exception

            End Try

            Return ""

        End Function

        Protected Function getServiceResponseToGetUsedList(ByVal singleFile As String) As ServiceResponseToGetUsedList

            Dim tmp As New CryptoAssetDefinitionEngine(_Path, False)
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

                trackLog("CryptoAssetDefinitionEngine.refreshUsedList", "Begin",, adapterLog)

                Dim tmp As ValueContractSupportedItem
                Dim dir As New System.IO.DirectoryInfo(_Path)

                _Used = New Dictionary(Of String, ValueContractSupportedItem)

                trackLog("CryptoAssetDefinitionEngine.refreshUsedList", "_Used created",, adapterLog)

                For Each singleFile In dir.GetFiles()

                    tmp = New ValueContractSupportedItem()

                    tmp.fileName = singleFile.ToString.Replace(System.IO.Path.GetExtension(IO.Path.GetFileName(singleFile.Name)), "")

                    With getServiceResponseToGetUsedList(singleFile.Name)

                        If .isUsed Then

                            tmp.identity = .identity

                            _Used.Add(tmp.identity, tmp)

                        End If

                    End With

                Next

                trackLog("CryptoAssetDefinitionEngine.refreshUsedList", "For....each completed",, adapterLog)

            Catch ex As Exception

                trackLog("CryptoAssetDefinitionEngine.refreshUsedList", "Error:" & ex.Message, "Fatal", adapterLog)

            Finally

                trackLog("CryptoAssetDefinitionEngine.refreshUsedList", "Compoleted")

            End Try

        End Sub




        Public Function getList(Optional ByVal useLogEngineAccess As Boolean = False, Optional adapterLog As CHCServerSupport.Support.LogEngine = Nothing) As List(Of String)

            Dim listTmp As New List(Of String)
            Dim tmp As String

            If useLogEngineAccess Then

                adapterLog = _logEngine.createAccess()

            End If

            trackLog("CryptoAssetDefinitionEngine.getList", "Begin", , adapterLog)

            Try

                If Not IsNothing(_Path) Then

                    trackLog("CryptoAssetDefinitionEngine.getList", "_Path is set", , adapterLog)

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

                trackLog("CryptoAssetDefinitionEngine.getList", "Error:" & ex.Message, "Fatal", adapterLog)

            End Try

            trackLog("CryptoAssetDefinitionEngine.getList", "completed", , adapterLog)

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


        Public Function addNew(ByVal value As Models.CryptoAssetRequestModel, Optional ByVal useLogEngineAccess As Boolean = False, Optional adapterLog As CHCServerSupport.Support.LogEngine = Nothing) As Boolean

            If useLogEngineAccess Then

                adapterLog = _logEngine.createAccess()

            End If

            trackLog("CryptoAssetDefinitionEngine.addNew", "Enter with name = " & value.name,, adapterLog)

            Try

                data = value.copyIntoBaseModel()

                trackLog("CryptoAssetDefinitionEngine.addNew", "copyIntoBaseModel executed",, adapterLog)

                fileName = composeCompletePath(value.configurationName)

                trackLog("CryptoAssetDefinitionEngine.addNew", "fileName = " & fileName,, adapterLog)

                If save() Then

                    trackLog("CryptoAssetDefinitionEngine.save", "After save()",, adapterLog)

                    refreshUsedList()

                    Return True

                End If

            Catch ex As Exception

                trackLog("CryptoAssetDefinitionEngine.addNew", "Error:" & ex.Message, "Fatal", adapterLog)

            Finally

                trackLog("CryptoAssetDefinitionEngine.addNew", "Completed")

            End Try

            Return False

        End Function


        Public Function update(ByVal name As String, ByVal value As Models.CryptoAssetRequestModel, Optional ByVal useLogEngineAccess As Boolean = False, Optional adapterLog As CHCServerSupport.Support.LogEngine = Nothing) As Boolean

            If useLogEngineAccess Then

                adapterLog = _logEngine.createAccess()

            End If

            trackLog("CryptoAssetDefinitionEngine.update", "Enter with name = " & value.name,, adapterLog)

            Try

                data = value.copyIntoBaseModel()

                trackLog("CryptoAssetDefinitionEngine.update", "set data",, adapterLog)

                If (name.CompareTo(value.configurationName) = 0) Then

                    fileName = composeCompletePath(name)

                    trackLog("CryptoAssetDefinitionEngine.update", "set fileName = " & fileName,, adapterLog)

                Else

                    trackLog("CryptoAssetDefinitionEngine.update", "try to delete a file = " & composeCompletePath(name),, adapterLog)

                    System.IO.File.Delete(composeCompletePath(name))

                    trackLog("CryptoAssetDefinitionEngine.update", "file deleted",, adapterLog)

                    fileName = composeCompletePath(value.configurationName)

                    trackLog("CryptoAssetDefinitionEngine.update", "set fileName = " & fileName,, adapterLog)

                    value.configurationName = ""

                End If

                Return save()

            Catch ex As Exception

                trackLog("CryptoAssetDefinitionEngine.update", "Error:" & ex.Message, "Fatal", adapterLog)

            Finally

                trackLog("CryptoAssetDefinitionEngine.update", "Completed")

            End Try

            Return False

        End Function



        Public Function delete(ByVal name As String, Optional ByVal useLogEngineAccess As Boolean = False, Optional adapterLog As CHCServerSupport.Support.LogEngine = Nothing) As Boolean

            If useLogEngineAccess Then

                adapterLog = _logEngine.createAccess()

            End If

            trackLog("CryptoAssetDefinitionEngine.delete", "Enter with name = " & name,, adapterLog)

            Try

                fileName = composeCompletePath(name)

                trackLog("CryptoAssetDefinitionEngine.delete", "set fileName = " & fileName,, adapterLog)

                If IO.File.Exists(fileName) Then

                    trackLog("CryptoAssetDefinitionEngine.delete", "file exist",, adapterLog)

                    IO.File.Delete(fileName)

                End If

                Return True

            Catch ex As Exception

                trackLog("CryptoAssetDefinitionEngine.delete", "Error:" & ex.Message, "Fatal", adapterLog)

            Finally

                trackLog("CryptoAssetDefinitionEngine.delete", "Completed")

            End Try

            Return False

        End Function


        Public Function item(ByVal searchByName As Boolean, ByVal keyValue As String, Optional ByVal useLogEngineAccess As Boolean = False, Optional adapterLog As CHCServerSupport.Support.LogEngine = Nothing) As Models.CryptoAssetModel

            If useLogEngineAccess Then

                adapterLog = _logEngine.createAccess()

            End If

            trackLog("CryptoAssetDefinitionEngine.item", "Begin",, adapterLog)

            Try

                If Not searchByName Then

                    trackLog("CryptoAssetDefinitionEngine.item", "not searchByName",, adapterLog)

                    Dim tmp As ValueContractSupportedItem

                    tmp = _Used.Item(keyValue)

                    If IsNothing(tmp) Then

                        Return New Models.CryptoAssetModel

                    End If

                    keyValue = tmp.fileName

                    trackLog("CryptoAssetDefinitionEngine.item", "keyValue = " & keyValue,, adapterLog)

                End If

                fileName = composeCompletePath(keyValue)

                trackLog("CryptoAssetDefinitionEngine.item", "fileName = " & fileName,, adapterLog)

                If read() Then

                    trackLog("CryptoAssetDefinitionEngine.item", "READ OK",, adapterLog)

                    Return data

                End If

            Catch ex As Exception

                trackLog("CryptoAssetDefinitionEngine.item", "Error:" & ex.Message, "Fatal", adapterLog)

            Finally

                trackLog("CryptoAssetDefinitionEngine.item", "Complete",, adapterLog)

            End Try

            Return Nothing

        End Function



        Public Sub New(ByVal path As String, Optional ByVal activeUsed As Boolean = True, Optional ByVal logAdapter As CHCServerSupport.Support.LogEngine = Nothing)

            Try

                _logEngine = logAdapter

                trackLog("CryptoAssetDefinitionEngine (constructor)", "Begin")

                _Path = path

                trackLog("CryptoAssetDefinitionEngine (constructor)", "Set _Path = " & _Path)

                If activeUsed Then

                    trackLog("CryptoAssetDefinitionEngine (constructor)", "activeUsed")

                    refreshUsedList()

                    trackLog("CryptoAssetDefinitionEngine (constructor)", "end refreshUsedList")

                    _ActiveUsed = True

                End If

            Catch ex As Exception

                trackLog("CryptoAssetDefinitionEngine (constructor)", "Error:" & ex.Message, "Fatal")

            Finally

                trackLog("CryptoAssetDefinitionEngine (constructor)", "Complete")

            End Try

        End Sub


    End Class




End Namespace
