Option Compare Text
Option Explicit On

Imports CHCModelsLibrary.AreaModel.Administration.Security
Imports CHCModelsLibrary.AreaModel.Administration.Settings
Imports CHCCommonLibrary.AreaEngine.Communication
Imports CHCModelsLibrary.AreaModel.Network.Response
Imports CHCProtocolLibrary.AreaWallet.Support





Namespace AreaCommon

    Module Network

        ''' <summary>
        ''' This method provide to build a URL
        ''' </summary>
        ''' <param name="api"></param>
        ''' <param name="ipAddress"></param>
        ''' <returns></returns>
        Public Function buildURL(ByVal api As String, ByRef config As SettingsSidechainServiceComplete) As String
            Dim ipAddress As String = "localhost:" & config.servicePort
            Dim url As String = ""
            Try
                Dim proceed As Boolean = True

                If proceed Then
                    If config.secureChannel Then
                        url += "https"
                    Else
                        url += "http"
                    End If
                End If
                If proceed Then
                    url += "://" & ipAddress & "/api"
                End If
                If proceed Then
                    If (config.serviceID.Length > 0) Then
                        url += "/" & config.serviceID & api
                    Else
                        url += api
                    End If
                End If
            Catch ex As Exception
            End Try

            Return url
        End Function

        ''' <summary>
        ''' This method provide to test service
        ''' </summary>
        ''' <param name="config"></param>
        ''' <returns></returns>
        Public Function testService(ByRef config As SettingsSidechainServiceComplete) As Boolean
            Try
                Dim remote As New ProxyWS(Of RemoteResponse)
                Dim proceed As Boolean = True

                If proceed Then
                    remote.url = buildURL("/service/test/", config)
                End If
                If proceed Then
                    proceed = (remote.getData() = "")
                End If
                If proceed Then
                    Return (remote.data.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete)
                End If

                Return proceed
            Catch exFile As System.IO.FileLoadException
                IntegrityApplication.executeRepairNewton(exFile.FileName)

                Return False
            Catch ex As Exception
                Console.WriteLine("Error during serviceFound - " & ex.Message)

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method sign a certificate with private key
        ''' </summary>
        ''' <returns></returns>
        Private Function signCertificate(ByVal item As GeneralModel.ServiceData) As String
            Try
                Dim privateKey As String = item.keys.private
                Dim certificate As String = item.configuration.clientCertificate

                Return WalletAddressEngine.createSignature(item.keys.private, certificate)
            Catch ex As Exception
                Console.WriteLine("Error during signCertificate:" & ex.Message)

                Return ""
            End Try
        End Function

        ''' <summary>
        ''' This method provide to sign an access key
        ''' </summary>
        ''' <returns></returns>
        Private Function signAccessKey(ByVal accessKey As String, ByVal item As GeneralModel.ServiceData) As String
            Try
                Dim privateKey As String = item.keys.private

                Return WalletAddressEngine.createSignature(privateKey, accessKey)
            Catch ex As Exception
                Console.WriteLine("Error during signAccessKey:" & ex.Message)

                Return ""
            End Try
        End Function

        ''' <summary>
        ''' This method provide to get an access key
        ''' </summary>
        ''' <returns></returns>
        Public Function getAccessKey(ByRef accessKey As String, ByVal item As GeneralModel.ServiceData) As Boolean
            Try
                Dim remote As New ProxyWS(Of ResponseRequestAccessKeyModel)
                Dim proceed As Boolean = True

                If proceed Then
                    remote.url = buildURL("/administration/security/requestAccessKey/?signature=" & signCertificate(item), item.configuration)
                End If
                If proceed Then
                    proceed = (remote.getData() = "")
                End If
                If proceed Then
                    proceed = (remote.data.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete)
                End If
                If proceed Then
                    accessKey = remote.data.accessKey

                    proceed = True
                End If

                Return proceed
            Catch ex As Exception
                Console.WriteLine("Error during getAccessKey - " & ex.Message)

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to get a security token
        ''' </summary>
        ''' <returns></returns>
        Public Function getSecurityToken(ByVal accessKey As String, ByVal item As GeneralModel.ServiceData) As Boolean
            Try
                Dim remote As New ProxyWS(Of ResponseRequestAdminSecurityTokenModel)
                Dim proceed As Boolean = True

                If proceed Then
                    remote.url = buildURL("/administration/security/requestAdminSecurityToken/?signature=" & signAccessKey(accessKey, item), item.configuration)
                End If
                If proceed Then
                    proceed = (remote.getData() = "")
                End If
                If proceed Then
                    proceed = (remote.data.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete)
                End If
                If proceed Then
                    item.securityToken = remote.data.tokenValue

                    proceed = True
                End If

                Return proceed
            Catch ex As Exception
                Console.WriteLine("Error during serviceFound - " & ex.Message)

                Return False
            End Try
        End Function

    End Module

End Namespace
