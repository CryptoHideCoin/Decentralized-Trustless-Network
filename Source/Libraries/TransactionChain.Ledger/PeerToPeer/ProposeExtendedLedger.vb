Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.Encryption
Imports CHCCommonLibrary.AreaEngine.DataFileManagement


Namespace AreaP2P

    Public Class ProposeExtendedLedger

        Public Class PartialSingleRecordLedger

            Public Property id As Integer = 0
            Public Property approvedDate As Double = 0
            Public Property actionCode As String = ""
            Public Property requester As String = ""
            Public Property detailInformation As String = ""
            Public Property requestHash As String = ""
            Public Property approvedHash As String = ""
            Public Property currentHash As String = ""
            Public Property currentTotalHash As String = ""


            Private Function fillEmptyText(ByVal value As String) As String
                If (value.Trim.Length > 0) Then
                    Return value
                Else
                    Return "---"
                End If
            End Function

            Public Function toStringToFile(Optional ByVal separator As String = "|", Optional limited As Boolean = False) As String
                Dim tmp As String = ""

                tmp += id.ToString() & separator
                tmp += approvedDate.ToString() & separator
                tmp += actionCode & separator
                tmp += requester & separator
                tmp += detailInformation & separator
                tmp += requestHash & separator
                tmp += fillEmptyText(approvedHash) & separator

                If Not limited Then
                    tmp += currentHash & separator
                End If

                Return tmp
            End Function

            Public Overrides Function toString() As String
                Return toStringToFile("", True)
            End Function

            Public Function getHash() As String
                Return HashSHA.generateSHA256(Me.toString())
            End Function

        End Class

        Public Property data As PartialSingleRecordLedger

    End Class

End Namespace