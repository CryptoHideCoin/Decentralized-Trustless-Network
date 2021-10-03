Option Compare Text
Option Explicit On

' ****************************************
' File: KeyStore Engine
' Release Engine: 1.0 
' 
' Date last successfully test: 03/10/2021
' ****************************************


Imports CHCCommonLibrary.AreaEngine.DataFileManagement.XML






Namespace AreaWallet.Support

    ''' <summary>
    ''' This class consent to manage a KeyStore 
    ''' </summary>
    Public Class KeyStoreEngine

        Inherits BaseFile(Of List(Of KeyStoreItem))

        ''' <summary>
        ''' This class contain the Key-Value (Name-UUID) of a Keystore
        ''' </summary>
        Public Class KeyStoreItem

            Public Property name As String = ""
            Public Property uuid As String = ""

        End Class


        ''' <summary>
        ''' This method provide to Add into KeyStore a new couple of keydata 
        ''' </summary>
        ''' <param name="name"></param>
        ''' <param name="uuid"></param>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Public Function addInto(ByVal name As String, ByVal uuid As String) As Boolean
            Try
                Dim toSave As Boolean = False
                Dim found As Boolean = False

                For Each item In data
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

                    data.Add(newItem)

                    toSave = True
                End If

                If toSave Then
                    save()
                End If

                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to remove an element into KeyStore
        ''' </summary>
        ''' <param name="uuid"></param>
        <DebuggerHiddenAttribute()> Public Function remove(ByVal uuid As String) As Boolean
            Try
                For Each item In data
                    If (item.uuid.CompareTo(uuid) = 0) Then
                        data.Remove(item)

                        Return save()
                    End If
                Next

                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to get a specific file detail
        ''' </summary>
        ''' <param name="uuid"></param>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Public Function getFileDetail(ByVal uuid As String) As String
            For Each item In data
                If (item.uuid = uuid) Then
                    Return item.name
                End If
            Next

            Return ""
        End Function

    End Class

End Namespace
