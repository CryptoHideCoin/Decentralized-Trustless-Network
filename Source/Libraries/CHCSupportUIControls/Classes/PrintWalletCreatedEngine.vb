Option Compare Text
Option Explicit On


Public Class PrintWalletCreatedEngine

    Public reportTitleFont As Font = New Font("Tahoma", 16)
    Public reportSupportFont As Font = New Font("Tahoma", 13, FontStyle.Bold)
    Public reportSupportFontTitle As Font = New Font("Tahoma", 12, FontStyle.Bold)
    Public reportSupportFontUltraMin As Font = New Font("Courier New", 8)
    Public reportSupportMinFont As Font = New Font("Tahoma", 9)

    Public seedPhrases As String = ""
    Public publicAddress As String = ""
    Public privateKey As String = ""
    Public qrCodePublic As Bitmap
    Public qrCodePrivate As Bitmap


    Public Class Page1

        Public Sub New(ByRef parent As PrintWalletCreatedEngine, ByRef e As Printing.PrintPageEventArgs)

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




    Public Sub WritePage(ByVal Number As Byte, ByRef e As Printing.PrintPageEventArgs)

        Select Case Number

            Case 1

                Dim tmp As New Page1(Me, e)

                tmp = Nothing

        End Select

    End Sub


End Class
