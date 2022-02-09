Option Compare Text
Option Explicit On

' ****************************************
' File: Key Store Manager
' Release Engine: 1.0 
' 
' Date last successfully test: 03/10/2021
' ****************************************










Public Class KeyStoreManager

    ''' <summary>
    ''' This property get/let the address value
    ''' </summary>
    ''' <returns></returns>
    Public Property addressValue As String
    ''' <summary>
    ''' This property get/let the Data Path
    ''' </summary>
    ''' <returns></returns>
    Public Property dataPath() As String
        Get
            Return listAddress.dataPath
        End Get
        Set(value As String)
            listAddress.dataPath = value
        End Set
    End Property

    Private Sub listAddress_RequestAddNew() Handles listAddress.RequestAddNew
        Dim tmp As New KeyPairDetail
        Try
            Dim result As String = ""

            tmp.pathData = dataPath

            If (tmp.ShowDialog = DialogResult.OK) Then
                addressValue = "keystoreid:" & tmp.uuid

                DialogResult = DialogResult.OK
            End If
        Catch ex As Exception
        End Try

        tmp.Close()
        tmp.Dispose()

        tmp = Nothing
    End Sub

    Private Sub listAddress_UseAddress(value As String) Handles listAddress.UseAddress
        addressValue = value

        DialogResult = DialogResult.OK
    End Sub

    Private Sub listAddress_RequestUpdate(UUID As String) Handles listAddress.RequestUpdate
        Dim form As New KeyPairDetail
        Try
            form.pathData = dataPath

            form.loadData(UUID)

            If Not form.closeMe Then
                form.ShowDialog(Me)
            End If
        Catch ex As Exception
        End Try

        form.Close()
        form.Dispose()

        form = Nothing
    End Sub

End Class