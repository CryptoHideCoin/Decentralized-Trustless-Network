Option Explicit On
Option Compare Text


Namespace AreaCommon.Engines.Watch

    Public Class InternalList

        Private Property _List As New List(Of AreaCommon.Models.Products.ProductModel)



        Public Function add(ByRef product As Models.Products.ProductModel, ByVal descriptionName As String) As Boolean
            addLogOperation($"{descriptionName}.add - {product.header.key} ")

            For Each singleProduct In _List
                If (singleProduct.header.key.CompareTo(product.header.key) = 0) Then
                    Return True
                End If
            Next

            _List.Add(product)

            Return True
        End Function

        Public ReadOnly Property getData(ByVal index As Integer) As Models.Products.ProductModel
            Get
                If (_List.Count >= index) Then
                    Return _List.ElementAt(index)
                Else
                    Return New Models.Products.ProductModel
                End If
            End Get
        End Property

        Public ReadOnly Property count() As Integer
            Get
                Return _List.Count
            End Get
        End Property

        Public Function remove(ByRef product As Models.Products.ProductModel, ByVal descriptionName As String) As Boolean
            Try
                addLogOperation($"{descriptionName}.remove - {product.header.key} ")

                For Each singleOrder In _List
                    If (singleOrder.header.key.CompareTo(product.header.key) = 0) Then
                        _List.Remove(singleOrder)

                        Return True
                    End If
                Next
            Catch ex As Exception
            End Try

            Return True
        End Function

    End Class

End Namespace
