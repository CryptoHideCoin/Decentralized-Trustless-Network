Option Compare Text
Option Explicit On



Namespace AreaSecurity


    Module authorization


        Public Function checkClientCertification(ByVal value As String) As Boolean

            Try
                Return (AreaCommon.settings.data.clientCertificate.CompareTo(value) = 0)
            Catch ex As Exception
                Return False
            End Try

        End Function

        Public Function changeCertificate(ByVal value As AreaCommon.Models.Security.changeCertificate) As Boolean

            Try
                Select Case value.typeCommunication
                    Case AreaCommon.Models.Security.enumOfService.loader,
                         AreaCommon.Models.Security.enumOfService.runTime,
                         AreaCommon.Models.Security.enumOfService.client,
                         AreaCommon.Models.Security.enumOfService.administration

                        AreaCommon.settings.data.clientCertificate = value.newCertificate
                        AreaCommon.settings.save()

                End Select

                Return True
            Catch ex As Exception
                Return False
            End Try

        End Function


    End Module


End Namespace
