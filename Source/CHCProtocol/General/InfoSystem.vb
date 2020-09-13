Option Compare Text
Option Explicit On



Namespace AreaBase


    Public Class InfoSystem


        Public Shared ReadOnly Property ApplicationRelease As String
            Get

                Try

                    Dim completeFileName As String = IO.Path.Combine(Application.ExecutablePath, "Package.release")

                    If IO.File.Exists(completeFileName) Then

                        Dim engine As New AreaUpdate.PackageReleaseEngine

                        engine.fileName = completeFileName

                        If engine.read() Then

                            For Each item In engine.data
                                If item.fileName.ToLower = "package" Then Return item.release
                            Next

                        End If

                    End If

                Catch ex As Exception

                End Try

                Return "0.1"

            End Get
        End Property
        Public Shared ReadOnly Property ProtocolRelease As String = "0.1"

    End Class


End Namespace