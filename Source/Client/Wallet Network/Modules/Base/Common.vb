Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.Support



Namespace AreaCommon


    Module moduleMain

        Public Property paths As New AreaSystem.Paths
        Public Property log As New LogEngine
        Public Property settings As New AppSettings

        Public Property forceBaseURL As String = ""



        ''' <summary>
        ''' This method provide to build a URL
        ''' </summary>
        ''' <param name="api"></param>
        ''' <returns></returns>
        Public Function buildURL(ByVal api As String) As String
            Dim url As String = ""
            Try
                Dim proceed As Boolean = True

                If (forceBaseURL.Length > 0) Then
                    Return forceBaseURL & "/" & api
                End If
                If proceed Then
                    proceed = (settings.data.urlPublic.Length > 0)
                End If
                If proceed Then
                    If AreaCommon.settings.data.useServiceSecureProtocol Then
                        url = "https://"
                    Else
                        url = "http://"
                    End If

                    url += settings.data.urlPublic & "/api/" & settings.data.serviceId & api
                End If
            Catch ex As Exception
            End Try

            Return url
        End Function

    End Module


End Namespace