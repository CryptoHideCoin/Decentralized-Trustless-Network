Imports System.Web.Http



Namespace Controllers


    ' GET: api/v1.0/Definition/AssetController
    ''' <summary>
    ''' ...
    ''' </summary>
    <Route("DefinitionApi")>
    Public Class AssetsController

        Inherits ApiController


        ' GET api/values
        Public Function GetValues(ByVal certificate As String) As IEnumerable(Of AreaCommon.Models.Define.CryptoItemKeyDescriptionModel)

            Dim response As New List(Of AreaCommon.Models.Define.CryptoItemKeyDescriptionModel)
            Dim item As New AreaCommon.Models.Define.CryptoItemKeyDescriptionModel

            Try

                If (AreaCommon.state.currentApplication = AppState.enumStateApplication.inRunning) Then

                    If AreaSecurity.checkClientCertification(certificate) Then
                        Return AreaApplication.Application.assets.cacheList
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

            Return item

        End Function

        ' GET api/values/5
        Public Function GetValue(ByVal certificate As String, ByVal id As String) As AreaCommon.Models.Define.CryptoAssetResponseModel

            Dim singleItem As New AreaCommon.Models.Define.CryptoAssetResponseModel

            Try

                If (AreaCommon.state.currentApplication = AppState.enumStateApplication.inRunning) Then

                    If AreaSecurity.checkClientCertification(certificate) Then
                        Return AreaApplication.Application.assets.getData(id)
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


        ' PUT api/values/5
        Public Sub PutValue(ByVal certificate As String, ByVal id As String, <FromBody()> ByVal value As AreaCommon.Models.Define.CryptoAssetBaseModel)

            Dim singleItem As New AreaCommon.Models.Define.CryptoAssetModel

            Try

                If (AreaCommon.state.currentApplication = AppState.enumStateApplication.inRunning) Then

                    If AreaSecurity.checkClientCertification(certificate) Then

                        AreaApplication.Application.assets.update(id, value)

                    End If

                End If

            Catch ex As Exception

            End Try

        End Sub


        ' DELETE api/values/5
        Public Sub DeleteValue(ByVal certificate As String, ByVal id As String)

            Dim singleItem As New AreaCommon.Models.Define.CryptoAssetModel

            Try

                If (AreaCommon.state.currentApplication = AppState.enumStateApplication.inRunning) Then

                    If AreaSecurity.checkClientCertification(certificate) Then

                        AreaApplication.Application.assets.delete(id)

                    End If

                End If

            Catch ex As Exception

            End Try

        End Sub


    End Class


End Namespace

