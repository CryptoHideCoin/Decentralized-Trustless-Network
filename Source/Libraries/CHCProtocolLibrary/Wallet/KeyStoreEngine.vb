Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.DataFileManagement.XML






Namespace AreaWallet.Support

    Public Class KeyStoreEngine

        Inherits BaseFile(Of List(Of KeyStoreItem))

        Public Class KeyStoreItem
            Public Property name As String = ""
            Public Property uuid As String = ""
        End Class


        Public Sub addInto(ByVal name As String, ByVal uuid As String)
            Try
                Dim toSave As Boolean = False
                Dim found As Boolean = False

                For Each item In Data
                    If (item.uuid.CompareTo(uuid) = 0) Then
                        found = True

                        If (item.name.CompareTo(name) <> 0) Then
                            item.name = name
                            toSave = True
                        End If
                    End If
                Next

                If Not found Then
                    Dim newItem As New KeyStoreItem

                    newItem.name = name
                    newItem.uuid = uuid

                    Data.Add(newItem)

                    toSave = True
                End If

                If toSave Then
                    save()
                End If
            Catch ex As Exception
            End Try
        End Sub

        Public Sub remove(ByVal uuid As String)
            Try
                For Each item In Data
                    If (item.uuid.CompareTo(uuid) = 0) Then
                        Data.Remove(item)

                        save()
                        Return
                    End If
                Next
            Catch ex As Exception
            End Try
        End Sub

        Public Function getFileDetail(ByVal uuid As String) As String
            For Each item In Data
                If (item.uuid = uuid) Then
                    Return item.name
                End If
            Next

            Return ""
        End Function

    End Class

End Namespace
