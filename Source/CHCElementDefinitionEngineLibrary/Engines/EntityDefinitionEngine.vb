Option Compare Text
Option Explicit On





Namespace CHCEngines


    Public Class BaseContractOfValueDataEngine

        Inherits CHCCommonLibrary.CHCEngines.Common.BaseFileDB(Of Models.ContractOfValueModel)

        Public Class ValueContractSupportedItem

            Public fileName As String = ""
            Public identity As String = ""

        End Class

        Protected Class ServiceResponseToGetUsedList

            Public identity As String = ""
            Public isUsed As Boolean = False

        End Class

        Private _ActiveUsed As Boolean = False
        Private _Used As Dictionary(Of String, ValueContractSupportedItem)
        Private _Path As String




        Private Sub createFileName(ByVal path As String, ByVal fileName As String)

            MyBase.fileName = IO.Path.Combine(path, fileName)

        End Sub

        Private Function composeCompletePath(ByVal configurationName As String) As String

            Try

                Dim ext As String = System.IO.Path.GetExtension(configurationName)

                If (ext.Length = 0) Then

                    configurationName += ".eboe"

                End If

                Return System.IO.Path.Combine(_Path, configurationName)

            Catch ex As Exception

            End Try

            Return ""

        End Function

        Protected Function getServiceResponseToGetUsedList(ByVal singleFile As String) As BaseContractOfValueDataEngine.ServiceResponseToGetUsedList

            Dim tmp As New BaseContractOfValueDataEngine(_Path, False)
            Dim response As New BaseContractOfValueDataEngine.ServiceResponseToGetUsedList

            tmp.fileName = singleFile

            If tmp.read() Then

                If tmp.data.isUsed Then

                    response.identity = tmp.data.getHash()
                    response.isUsed = True

                End If

            End If

            Return response

        End Function

        Private Sub refreshUsedList()

            Dim tmp As ValueContractSupportedItem
            Dim dir As New System.IO.DirectoryInfo(_Path)

            _Used = New Dictionary(Of String, ValueContractSupportedItem)

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

        End Sub



        Public Function getList() As List(Of String)

            Dim listTmp As New List(Of String)
            Dim tmp As String

            Try

                If Not IsNothing(_Path) Then

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

            End Try

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


        Public Function addNew(ByVal value As Models.ContractOfValueRequestModel) As Boolean

            Try

                data = value.copyIntoBaseModel()

                fileName = composeCompletePath(value.configurationName)

                If save() Then

                    refreshUsedList()

                    Return True

                End If

            Catch ex As Exception

            End Try

            Return False

        End Function


        Public Function update(ByVal name As String, ByVal value As Models.ContractOfValueRequestModel) As Boolean

            data = value.copyIntoBaseModel()

            If (name.CompareTo(value.configurationName) = 0) Then

                fileName = composeCompletePath(name)

            Else

                System.IO.File.Delete(composeCompletePath(name))

                fileName = composeCompletePath(value.configurationName)

                value.configurationName = ""

            End If

            Return save()

        End Function


        Public Function delete(ByVal name As String) As Boolean

            fileName = composeCompletePath(name)

            If IO.File.Exists(fileName) Then

                IO.File.Delete(fileName)

            End If

            Return True

        End Function


        Public Function item(ByVal searchByName As Boolean, ByVal keyValue As String) As Models.ContractOfValueModel

            Try

                If Not searchByName Then

                    Dim tmp As ValueContractSupportedItem

                    tmp = _Used.Item(keyValue)

                    If IsNothing(tmp) Then

                        Return New Models.ContractOfValueModel

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
