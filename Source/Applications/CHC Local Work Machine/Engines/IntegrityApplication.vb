Option Compare Text
Option Explicit On



''' <summary>
''' This class contain all element of check integrity
''' </summary>
Friend Class IntegrityApplication

    ''' <summary>
    ''' This method provide to run a Repair Newtown utility
    ''' </summary>
    ''' <param name="fileName"></param>
    ''' <returns></returns>
    Public Shared Function executeRepairNewton(ByVal fileName As String) As Boolean
        Try
            If fileName.Contains("12.0.0") Then
                Process.Start(IO.Path.Combine(My.Application.Info.DirectoryPath, "CHCRepairNewtown.exe"), "-copy --repair:useNewer")
            Else
                Process.Start(IO.Path.Combine(My.Application.Info.DirectoryPath, "CHCRepairNewtown.exe"), "-copy --repair:useOlder")
            End If

            End

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

End Class
