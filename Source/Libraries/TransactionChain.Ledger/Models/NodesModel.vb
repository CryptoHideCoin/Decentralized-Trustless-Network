Option Explicit On
Option Compare Text

Imports CHCCommonLibrary.AreaEngine.Encryption




Namespace AreaTransactionChain.Models


    Public Class SingleNodeModel

        Public walletID As String = ""
        Public aliasName As String = ""
        Public addressIP As String = ""
        Public power As Double = 0
        Public dayOfAlive As Integer = 0
        Public highSpeed As Boolean = False
        Public ledgerTransactionID As String = ""
        Public dateLastConnection As New DateTime
        Public errorConnection As Boolean = False

        Public Overrides Function toString() As String
            Dim tmp As String = ""

            tmp += walletID
            tmp += addressIP
            tmp += power.ToString()
            tmp += dayOfAlive.ToString()
            tmp += ledgerTransactionID

            If highSpeed Then tmp += "1" Else tmp += "0"

            Return tmp
        End Function

        Public Function getHash() As String
            Return HashSHA.generateSHA256(Me.toString())
        End Function

    End Class


    Public Class ChainModel

        Public name As String = ""
        Public protocolValue As Integer = 0
        Public protocolName As String = ""

        Public nodes As New List(Of SingleNodeModel)

        Private _nodeKey As New Dictionary(Of String, SingleNodeModel)


        Public Overrides Function toString() As String
            Dim tmp As String = ""

            tmp += name
            tmp += protocolValue
            tmp += protocolName

            For Each singleItem In nodes
                tmp += singleItem.getHash()
            Next

            Return tmp
        End Function

        Public Function getHash() As String
            Return HashSHA.generateSHA256(Me.toString())
        End Function

        Public Function addNew(ByVal walletID As String) As SingleNodeModel

            Dim tmp As New SingleNodeModel

            Try
                tmp.walletID = walletID

                _nodeKey.Add(walletID, tmp)

                nodes.Add(tmp)
            Catch ex As Exception
            End Try

            Return tmp

        End Function

        Public Function remove(ByVal walletID As String) As Boolean

            Try
                Dim tmp As SingleNodeModel = _nodeKey(walletID)

                _nodeKey.Remove(walletID)

                nodes.Remove(tmp)

                Return True
            Catch ex As Exception
                Return False
            End Try

        End Function

        Public Function getNode(ByVal walletID As String) As SingleNodeModel

            Try
                Dim tmp As SingleNodeModel = _nodeKey(walletID)

                Return tmp
            Catch ex As Exception
                Return New SingleNodeModel
            End Try

        End Function

    End Class


    Public Class NetModel

        Public name As String = ""
        Public updateTime As New DateTime
        Public authorWalletID As String = ""

        Public chains As New List(Of ChainModel)

        Private _chainKey As New Dictionary(Of String, ChainModel)

        Public Overrides Function toString() As String
            Dim tmp As String = ""

            tmp += name
            tmp += updateTime.ToString()
            tmp += authorWalletID

            For Each singleItem In chains
                tmp += singleItem.getHash()
            Next

            Return tmp
        End Function

        Public Function getHash() As String
            Return HashSHA.generateSHA256(Me.toString())
        End Function

        Public Function AddNew(ByVal name As String) As ChainModel

            Dim tmp As New ChainModel

            Try
                tmp.name = name

                _chainKey.Add(name, tmp)

                chains.Add(tmp)
            Catch ex As Exception
            End Try

            Return tmp

        End Function

        Public Function AddItem(ByVal data As ChainModel) As Boolean

            If Not _chainKey.ContainsKey(data.name) Then

                Try
                    _chainKey.Add(data.name, data)

                    chains.Add(data)

                    Return True
                Catch ex As Exception
                    Return False
                End Try

            Else
                Return False
            End If

        End Function

        Public Function remove(ByVal name As String) As Boolean

            Try
                Dim tmp As ChainModel = _chainKey(name)

                _chainKey.Remove(name)

                chains.Remove(tmp)

                Return True
            Catch ex As Exception
                Return False
            End Try

        End Function

        Public Function getNode(ByVal name As String) As ChainModel

            Try
                Dim tmp As ChainModel = _chainKey(name)

                Return tmp
            Catch ex As Exception
                Return New ChainModel
            End Try

        End Function

        Public signature As String = ""

    End Class


End Namespace
