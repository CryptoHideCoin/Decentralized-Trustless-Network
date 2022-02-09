Option Compare Text
Option Explicit On

' ****************************************
' Engine: Info System
' Release Engine: 1.0 
' 
' Date last successfully test: 03/10/2021
' ****************************************





Namespace AreaBase

    ''' <summary>
    ''' This static class contain the function utils to create a package for install/upgrade
    ''' </summary>
    Public Class InfoSystem

        ''' <summary>
        ''' This method provide to get the package release from file
        ''' </summary>
        ''' <returns></returns>
        Public Shared ReadOnly Property applicationRelease As String
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

                Return "0.2"
            End Get
        End Property
        Public Shared ReadOnly Property protocolRelease As String = "0.2"

    End Class

End Namespace