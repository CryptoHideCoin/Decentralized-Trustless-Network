Option Compare Text
Option Explicit On



Namespace AreaSecurity


    Module authorization


        Public Function checkAdminCertification(ByVal value As String) As Boolean

            Try
                Return (AreaCommon.settings.data.certificateMasternodeAdmin.CompareTo(value) = 0)
            Catch ex As Exception
                Return False
            End Try

        End Function


    End Module


End Namespace
