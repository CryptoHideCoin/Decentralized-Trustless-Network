Option Compare Text
Option Explicit On





Namespace AreaCommon.Startup

    ''' <summary>
    ''' This class contain the response of a IO Operation
    ''' </summary>
    Public Class ResponseIOOperation
        Public Property successful As Boolean = False
        Public Property problemDescription As String = ""
    End Class


    ''' <summary>
    ''' This static class run the application
    ''' </summary>
    Module Bootstrap

        Private Property _Bootstrap As New CHCSidechainServiceLibrary.AreaCommon.Startup.Bootstrap





        ''' <summary>
        ''' This method provide to prepare the application to the startup
        ''' </summary>
        ''' <returns></returns>
        Public Function run() As Boolean
            Try
                Dim problemDescription As String = ""
                Dim proceed As Boolean = True

                If proceed Then
                    If Not _Bootstrap.readParameters() Then
                        MessageBox.Show("Problem during read a parameters", "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)

                        proceed = False
                    End If
                End If
                If proceed Then
                    If Not _Bootstrap.managePath(problemDescription) Then
                        MessageBox.Show(problemDescription, "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)

                        proceed = False
                    End If
                End If
                If proceed Then
#Disable Warning BC42025
                    With CHCSidechainServiceLibrary.AreaCommon.Main.environment.readSettings(CUSTOM_ChainServiceName)
#Enable Warning BC42025
                        proceed = .successful

                        If Not proceed Then
                            MessageBox.Show(.problemDescription, "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)

                            proceed = False
                        End If
                    End With
                End If

                Return proceed
            Catch ex As Exception
                MessageBox.Show("An error occurrent during moduleMain.bootstrap " & Err.Description, "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)

                Return False
            End Try
        End Function

    End Module

End Namespace
