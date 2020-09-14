Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.DataFileManagement
Imports CHCProtocolLibrary.AreaCommon.Models



Namespace AreaChain

    Public Class NodesEngine

        Public Class NodeInformation

            Public Enum EnumPeerServiceType
                notDefined
                [public]
                service
                thanksTo
                file
                dns
                exChange
                vote
            End Enum

            Public Class configurationPort
                Public [type] As EnumPeerServiceType = EnumPeerServiceType.notDefined
                Public port As String = ""
            End Class


            Public address As String = ""
            Public virtualName As String = ""
            Public associatedWalletAddress As String = ""

            Public serviceList As New List(Of configurationPort)

            Public configureTransactionDefinitionID As String = ""
            Public masternodeConnectedChainStartUp As Date = Date.MinValue
            Public transactionIDConnected As String = ""
            Public warrantyCoin As Double = 0

            Public response As New General.RemoteResponse

        End Class

        Public nodeList As New List(Of NodeInformation)
        Public nodeKeys As New Dictionary(Of String, NodeInformation)




        Public Function addNew(ByVal associatedWalletAddress As String) As NodeInformation

            Try

                Dim tmp As New NodeInformation

                tmp.associatedWalletAddress = associatedWalletAddress
                nodeKeys.Add(associatedWalletAddress, tmp)

                nodeList.Add(tmp)

                Return tmp

            Catch ex As Exception
                Return Nothing
            End Try

        End Function

        Public Function remove(ByVal associatedWalletAddress As String) As Boolean

            Try

                Dim tmp As NodeInformation = nodeKeys(associatedWalletAddress)

                nodeKeys.Remove(associatedWalletAddress)

                nodeList.Remove(tmp)

                Return True

            Catch ex As Exception
                Return False
            End Try

        End Function

        Public Function toChainServiceList() As List(Of NodeList.NodeAtom)

            Dim item As NodeList.NodeAtom
            Dim result As New List(Of NodeList.NodeAtom)

            Try

                For Each once In nodeList

                    For Each singleData In once.serviceList

                        If (singleData.type = NodeInformation.EnumPeerServiceType.service) Then

                            item = New NodeList.NodeAtom

                            item.address = once.address
                            item.chainServicePort = singleData.port

                            result.Add(item)

                        End If

                    Next

                Next

            Catch ex As Exception
            End Try

            Return result

        End Function

    End Class


    Public Class NodeList

        Inherits BaseEncryption(Of List(Of NodeAtom))

        Public Class NodeAtom

            Public address As String = ""
            Public chainServicePort As String = ""

        End Class


    End Class


End Namespace