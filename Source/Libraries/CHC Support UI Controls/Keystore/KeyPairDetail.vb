Option Compare Text
Option Explicit On

' ****************************************
' File: KeyPair Detail
' Release Engine: 1.0 
' 
' Date last successfully test: 03/10/2021
' ****************************************









Public Class KeyPairDetail

    ''' <summary>
    ''' This property get/let if the form need to close
    ''' </summary>
    ''' <returns></returns>
    Public Property closeMe As Boolean = False
    ''' <summary>
    ''' This property get/let the Path Data
    ''' </summary>
    ''' <returns></returns>
    Public Property pathData As String
        Get
            Return mainCustomizeWalletAddress.pathData
        End Get
        Set(value As String)
            mainCustomizeWalletAddress.pathData = value
        End Set
    End Property
    ''' <summary>
    ''' This property get/let UUID of the wallet
    ''' </summary>
    ''' <returns></returns>
    Public Property uuid() As String
        Get
            Return mainCustomizeWalletAddress.uuid
        End Get
        Set(value As String)
            mainCustomizeWalletAddress.uuid = value
        End Set
    End Property



    Private Sub mainCustomizeWalletAddress_requestAccessSecurityKey(ByRef value As String, ByRef cancelValue As Boolean) Handles mainCustomizeWalletAddress.RequestAccessSecurityKey
        Try
            Dim tmp As New RequestPassword

            If (tmp.ShowDialog() = DialogResult.OK) Then
                value = tmp.passwordTextBox.Text
            Else
                cancelValue = True
            End If

            tmp.Close()

            tmp.Dispose()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub mainCustomizeWalletAddress_CloseMe() Handles mainCustomizeWalletAddress.CloseMe
        DialogResult = DialogResult.OK
        closeMe = True
    End Sub

    Public Sub loadData(ByVal UUID As String)
        mainCustomizeWalletAddress.uuid = UUID
    End Sub

End Class
