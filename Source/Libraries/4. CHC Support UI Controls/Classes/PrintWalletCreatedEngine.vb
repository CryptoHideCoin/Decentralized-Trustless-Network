Option Compare Text
Option Explicit On

' ****************************************
' File: Print Wallet Engine
' Release Engine: 1.0 
' 
' Date last successfully test: 03/10/2021
' ****************************************









Public Class PrintWalletCreatedEngine

    Public Property reportTitleFont As Font = New Font("Tahoma", 16)
    Public Property reportSupportFont As Font = New Font("Tahoma", 13, FontStyle.Bold)
    Public Property reportSupportFontTitle As Font = New Font("Tahoma", 12, FontStyle.Bold)
    Public Property reportSupportFontUltraMin As Font = New Font("Courier New", 8)
    Public Property reportSupportMinFont As Font = New Font("Tahoma", 9)

    Public Property seedPhrases As String = ""
    Public Property publicAddress As String = ""
    Public Property privateKey As String = ""
    Public Property qrCodePublic As Bitmap
    Public Property qrCodePrivate As Bitmap


    Public Class Page1

        ''' <summary>
        ''' This method provide to initialize class
        ''' </summary>
        ''' <param name="parent"></param>
        ''' <param name="e"></param>
        <DebuggerHiddenAttribute()> Public Sub New(ByRef parent As PrintWalletCreatedEngine, ByRef e As Printing.PrintPageEventArgs)
            Try
                With e.Graphics

                    .DrawImage(parent.qrCodePublic, New Rectangle(20, 40, 220, 220))

                    .DrawString("Print Date" & ": " & Now.ToString("dd MMM yyyy"), parent.reportSupportFontUltraMin, Brushes.Black, 550, 50)
                    .DrawString("Crypto Hide Coin Decentralize Trustless", parent.reportTitleFont, Brushes.Chocolate, 225, 75)
                    .DrawString("Paperwallet", parent.reportTitleFont, Brushes.Chocolate, 225, 105)

                    If (parent.seedPhrases.Length > 0) Then

                        .DrawString("Seed", parent.reportSupportFontTitle, Brushes.Black, 50, 280)
                        .DrawString(parent.seedPhrases, parent.reportSupportMinFont, Brushes.Black, 50, 300)

                    End If

                    .DrawString("Public Address", parent.reportSupportFontTitle, Brushes.Black, 50, 330)
                    .DrawString(parent.publicAddress, parent.reportSupportMinFont, Brushes.Black, 50, 350)

                    If (parent.privateKey.Length > 0) Then

                        .DrawString("Private Key", parent.reportSupportFontTitle, Brushes.Black, 50, 380)

                        If (parent.privateKey.Length > 100) Then
                            .DrawString(parent.privateKey.Substring(0, 89), parent.reportSupportMinFont, Brushes.Black, 50, 410)

                            If (parent.privateKey.Length > 200) Then
                                .DrawString(parent.privateKey.Substring(90, 89), parent.reportSupportMinFont, Brushes.Black, 50, 430)

                                .DrawString(parent.privateKey.Substring(180), parent.reportSupportMinFont, Brushes.Black, 50, 450)
                            Else
                                .DrawString(parent.privateKey.Substring(90), parent.reportSupportMinFont, Brushes.Black, 50, 430)
                            End If
                        Else
                            .DrawString(parent.privateKey, parent.reportSupportMinFont, Brushes.Black, 50, 410)
                        End If

                        .DrawImage(parent.qrCodePrivate, New Rectangle(200, 500, 400, 400))
                    End If

                End With

                e.HasMorePages = False
            Catch ex As Exception
            End Try
        End Sub

    End Class

    ''' <summary>
    ''' This method provuide to manage a Write Page
    ''' </summary>
    ''' <param name="Number"></param>
    ''' <param name="e"></param>
    <DebuggerHiddenAttribute()> Public Sub WritePage(ByVal Number As Byte, ByRef e As Printing.PrintPageEventArgs)

        Select Case Number
            Case 1
                Dim tmp As New Page1(Me, e)

                tmp = Nothing
        End Select

    End Sub

End Class
