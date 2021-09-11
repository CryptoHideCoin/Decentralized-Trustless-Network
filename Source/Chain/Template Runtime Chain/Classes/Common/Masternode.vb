Option Compare Text
Option Explicit On


Imports TransactionChainLibrary.AreaEngine.Ledger
Imports CHCProtocolLibrary.AreaCommon



Namespace AreaCommon.Masternode

    Public Class MasternodeSenders

        Public Class MasternodeSender

            Public publicAddress As String = ""
            Public publicAddressIP As String = ""

            Public deliveryTimeStamp As Double = 0
            Public lastTry As Double = 0
            Public tryNumber As Byte = 0

        End Class

        Public Property _Masternodes As New List(Of MasternodeSender)


        Public Shared Function createMasterNodeList() As MasternodeSenders
            Try
                Dim result As New MasternodeSenders
                Dim singleItem As MasternodeSender

                For Each item In state.runtimeState.activeMasterNode
                    singleItem = New MasternodeSender

                    singleItem.publicAddress = item.Value.identityPublicAddress
                    singleItem.publicAddressIP = item.Value.ipAddress

                    result.Add(singleItem)
                Next

                Return result
            Catch ex As Exception
                log.track("MasternodeSenders.createMasterNodeList", "Error:" & ex.Message, "error")

                Return New MasternodeSenders
            End Try
        End Function


        Public Function add(ByRef value As MasternodeSender) As Boolean
            Try
                _Masternodes.Add(value)

                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public ReadOnly Property count() As Integer
            Get
                Return _Masternodes.Count
            End Get
        End Property

        Public ReadOnly Property getFirst() As MasternodeSender
            Get
                If (_Masternodes.Count > 0) Then
                    Return _Masternodes(0)
                Else
                    Return Nothing
                End If
            End Get
        End Property

        Public Function removeFirst() As Boolean
            Try
                If (_Masternodes.Count > 0) Then
                    _Masternodes.RemoveAt(0)
                End If

                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

    End Class

End Namespace