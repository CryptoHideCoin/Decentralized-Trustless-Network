Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.Communication
Imports CHCCommonLibrary.AreaCommon.Models



Namespace AreaCommon


    Module moduleUtility


        Public Function testService(ByVal protocolSecureService As Boolean, ByVal urlService As String) As Boolean

            If (urlService.Length > 0) Then

                Try

                    Dim testEngine As New ProxyWS(Of General.BooleanModel)

                    If protocolSecureService Then
                        testEngine.url = "https://" & urlService & "/api/v1.0/system/testService"
                    Else
                        testEngine.url = "http://" & urlService & "/api/v1.0/system/testService"
                    End If

                    If (testEngine.getData() = "") Then
                        Return testEngine.data.value
                    Else
                        Return False
                    End If

                Catch ex As Exception
                    MessageBox.Show("Test connection failed", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End Try

            Else
                Return False
            End If

        End Function


    End Module


End Namespace
