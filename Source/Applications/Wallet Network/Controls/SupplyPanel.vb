Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.Communication
Imports CHCCommonLibrary.AreaCommon.Models.General
Imports CHCProtocolLibrary.AreaCommon


Public Class SupplyPanel

    Private Property _Symbol As String = ""
    Private Property _ChainName As String = ""

    Public Event OpenConfiguration()
    Public Event CloseMe()




    ''' <summary>
    ''' This method provide to read an asset information
    ''' </summary>
    ''' <returns></returns>
    Private Function readAssetInformation() As Boolean
        Try
            Dim startTime As Double = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()
            Dim remote As New ProxyWS(Of Models.Network.InfoAssetModel)
            Dim proceed As Boolean = True

            If proceed Then
                remote.url = AreaCommon.buildURL("/network/primaryAsset/")
            End If
            If proceed Then
                proceed = (remote.getData() = "")
            End If
            If proceed Then
                proceed = (remote.data.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete)
            End If
            If proceed Then
                proceed = (remote.data.value.assetInformation.name.Length > 0)
            End If
            If proceed Then
                _Symbol = remote.data.value.assetInformation.symbol
            End If
            If Not proceed Then
                MessageBox.Show("Error during connection", "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)

                RaiseEvent OpenConfiguration()
            End If

            remote = Nothing

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    ''' <summary>
    ''' This method provide to read an info supply data
    ''' </summary>
    ''' <returns></returns>
    Private Function readInfoSupply() As Boolean
        Try
            Dim startTime As Double = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()
            Dim remote As New ProxyWS(Of Models.Supply.Response.SupplyResponseModel)
            Dim proceed As Boolean = True

            If proceed Then
                remote.url = AreaCommon.buildURL("/supply/supplyInformationBase/?name=" & _ChainName)
            End If
            If proceed Then
                proceed = (remote.getData() = "")
            End If
            If proceed Then
                proceed = (remote.data.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete)
            End If
            If proceed Then
                proceed = (remote.data.integrityTransactionChain.coordinate.Length > 0)
            Else
                MessageBox.Show("Error during connection", "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)

                RaiseEvent OpenConfiguration()

                Return False
            End If
            If proceed Then
                Return supplyDetailInformation.loadDataDisplay(remote.data, _Symbol)
            Else
                Return False
            End If

            Return proceed
        Catch ex As Exception
            Return False
        End Try
    End Function

    ''' <summary>
    ''' This method provide to read a currency symbol from remote if it's not in memory
    ''' </summary>
    ''' <returns></returns>
    Private Function readCurrencySymbol() As Boolean
        If (_Symbol.Length = 0) Then
            If Not readAssetInformation() Then
                Return False
            End If
        End If

        Return True
    End Function

    ''' <summary>
    ''' This method provide to run a panel
    ''' </summary>
    ''' <returns></returns>
    Public Function run() As Boolean
        Try
            titleControl.Text = "Power Information"

            readCurrencySymbol()

            Return readInfoSupply()
        Catch ex As Exception
            Return False
        End Try
    End Function

End Class
