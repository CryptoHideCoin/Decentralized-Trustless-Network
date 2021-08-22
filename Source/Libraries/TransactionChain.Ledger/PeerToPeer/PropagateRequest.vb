Option Compare Text
Option Explicit On


Namespace AreaP2P

    Public Class PropagateRequest(Of ClassType As {New})

        Public Class DeliveryReceipt
            Public Property publicAddress As String = ""
            Public Property ipAddress As String = ""
            Public Property requestHash As String = ""
            Public Property hash As String = ""
            Public Property signature As String = ""
        End Class

        Private Property unDelivered As New List(Of AreaEngine.Ledger.NodeList.NodeChainTrustedInformation.NodeListTrustedInformation.DeliveryNodeInformation)

        Public Property deliveryList As New List(Of AreaEngine.Ledger.NodeList.NodeChainTrustedInformation.NodeListTrustedInformation.DeliveryNodeInformation)
        Public Property messageData As ClassType


        Public Function init() As Boolean
            For Each item In deliveryList
                'If Not deliveryMessage(item) Then
                '    unDelivered.Add(item)
                'End If
            Next

            Return True
        End Function

    End Class


End Namespace