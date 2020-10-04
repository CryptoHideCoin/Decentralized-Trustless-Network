Option Compare Text
Option Explicit On

Imports CHCProtocolLibrary.AreaCommon.Models.Settings



Namespace AreaController

    Module ServiceUtility


        Public Function getValues(ByVal certificate As String, ByRef engine As Object) As IEnumerable(Of AreaCommon.Models.Define.ItemKeyDescriptionModel)

            Dim response As New List(Of AreaCommon.Models.Define.ItemKeyDescriptionModel)
            Dim item As New AreaCommon.Models.Define.ItemKeyDescriptionModel

            Try

                If (AreaCommon.state.currentApplication = EnumStateApplication.inRunning) Then

                    If AreaSecurity.checkClientCertification(certificate) Then
                        Return engine.cacheList
                    Else
                        item.response.unAuthorized = True
                    End If

                Else
                    item.response.offline = True
                End If

            Catch ex As Exception
                item.response.description = "503 - Internal Error"
            End Try

            item.response.error = True

            response.Add(item)

            Return response

        End Function

        Public Function getValue(ByVal certificate As String, ByVal id As String, ByRef engine As Object, ByRef singleItem As Object) As Object

            Try

                If (AreaCommon.state.currentApplication = EnumStateApplication.inRunning) Then

                    If AreaSecurity.checkClientCertification(certificate) Then
                        Return engine.getData(id)
                    Else
                        singleItem.response.unAuthorized = True
                    End If

                Else
                    singleItem.response.offline = True
                End If

            Catch ex As Exception
                singleItem.response.description = "503 - Internal Error"
            End Try

            singleItem.response.error = True

            Return singleItem

        End Function

        Public Function putValue(ByVal certificate As String, ByVal originalId As String, ByRef value As Object, ByRef engine As Object, ByRef singleItem As Object) As String

            Try
                If IsNothing(originalId) Then originalId = ""

                If IsNothing(value) Then
                    Return ""
                Else
                    Try
                        value.deCodeSymbol()
                    Catch ex As Exception
                    End Try
                End If

                If (AreaCommon.state.currentApplication = EnumStateApplication.inRunning) Then

                    If AreaSecurity.checkClientCertification(certificate) Then
                        engine.update(originalId, value)
                    Else
                        Return "Service Unauthorized"
                    End If

                Else
                    Return "Service Offline"
                End If

            Catch ex As Exception
                Return "Service Error"
            End Try

            Return ""

        End Function

        Public Function deleteValue(ByVal certificate As String, ByVal id As String, ByRef engine As Object) As String

            Try

                If (AreaCommon.state.currentApplication = EnumStateApplication.inRunning) Then

                    If AreaSecurity.checkClientCertification(certificate) Then
                        engine.delete(id)
                    Else
                        Return "Service Unauthorized"
                    End If
                Else
                    Return "Service Offline"
                End If

            Catch ex As Exception
                Return "Service Error"
            End Try

            Return ""

        End Function


    End Module

End Namespace
