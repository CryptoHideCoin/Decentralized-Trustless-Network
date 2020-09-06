Option Compare Text
Option Explicit On



Namespace AreaSecurity


    Module authorization


        Public Function checkInAllCertification(ByVal value As String) As Boolean

            Try

                If (AreaCommon.settings.data.certificateClient.CompareTo(value) = 0) Then
                    Return True
                ElseIf (AreaCommon.settings.data.certificateMasternodeEngine.CompareTo(value) = 0) Then
                    Return True
                ElseIf (AreaCommon.settings.data.certificateMasternodeStart.CompareTo(value) = 0) Then
                    Return True
                Else
                    Return False
                End If

            Catch ex As Exception

                Return False

            End Try

        End Function

        Public Function checkClientCertification(ByVal value As String) As Boolean

            Try

                Return (AreaCommon.settings.data.certificateClient.CompareTo(value) = 0)

            Catch ex As Exception

                Return False

            End Try

        End Function

        Public Function changeCertificate(ByVal value As AreaCommon.Models.Security.changeCertificate) As Boolean

            Try

                Select Case value.typeCommunication

                    Case AreaCommon.Models.Security.enumOfService.start : AreaCommon.settings.data.certificateMasternodeStart = value.newCertificate
                    Case AreaCommon.Models.Security.enumOfService.runTime : AreaCommon.settings.data.certificateMasternodeEngine = value.newCertificate
                    Case AreaCommon.Models.Security.enumOfService.client : AreaCommon.settings.data.certificateClient = value.newCertificate

                End Select

                AreaCommon.settings.save()

                Return True

            Catch ex As Exception

                Return False

            End Try

        End Function


    End Module


End Namespace
