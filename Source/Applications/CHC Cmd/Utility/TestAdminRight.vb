Option Explicit On
Option Compare Text

Imports System.Security.Principal





Public Class utility

    ''' <summary>
    ''' This method provide to test if the application have admin right 
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function isAdminRight() As Boolean
        Try
            Dim identity = WindowsIdentity.GetCurrent()
            Dim principal = New WindowsPrincipal(identity)

            Return principal.IsInRole(WindowsBuiltInRole.Administrator)
        Catch ex As Exception
            Return False
        End Try
    End Function

End Class
