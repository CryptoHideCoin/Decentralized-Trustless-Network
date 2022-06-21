Option Explicit On
Option Compare Text




Namespace AreaEngine.Security

    ''' <summary>
    ''' This class manage the admin request token
    ''' </summary>
    Public Class AdminTokenEngine

        ''' <summary>
        ''' This class contain the element of a key
        ''' </summary>
        Private Class KeyValidity
            Public Property key As String = ""
            Public Property expireTimeStamp As Double = 0

            Public ReadOnly Property isExpired() As Boolean
                Get
                    Return (CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime > Me.expireTimeStamp)
                End Get
            End Property

            Public Sub New(ByVal valid As Double)
                key = Guid.NewGuid.ToString()
                expireTimeStamp = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime + valid
            End Sub
        End Class

        Private Property _CurrentAccessKey As KeyValidity
        Private Property _CurrentTokens As New Dictionary(Of String, KeyValidity)


        ''' <summary>
        ''' Thie method provide to create access key into memory
        ''' </summary>
        ''' <returns>New Access Key</returns>
        Public Function createAccessKey() As String
            Try
                _CurrentAccessKey = New KeyValidity(5000)

                Return _CurrentAccessKey.key
            Catch ex As Exception
                Return ""
            End Try
        End Function

        ''' <summary>
        ''' This method provide to create a new token into memory
        ''' </summary>
        ''' <returns></returns>
        Public Function createNewToken() As String
            Try
#If DEBUG Then
                Dim newToken As New KeyValidity(30 * 60000)
#Else
                Dim newToken As New KeyValidity(10 * 60000)
#End If

                _CurrentTokens.Add(newToken.key, newToken)

                Return newToken.key
            Catch ex As Exception
                Return ""
            End Try
        End Function

        ''' <summary>
        ''' This method provide to test if check token is successful
        ''' </summary>
        ''' <param name="value"></param>
        ''' <returns></returns>
        Public Function check(ByVal value As String) As String
            Try
                Dim expirationTime As Double = 0
                Dim key As KeyValidity

                If (_CurrentTokens.Count = 0) Then
                    Return "Token error"
                End If

                If Not _CurrentTokens.ContainsKey(value) Then
                    Return "Token expired"
                Else
                    key = _CurrentTokens(value)

                    If key.isExpired Then
                        _CurrentTokens.Remove(value)

                        Return "Token expired"
                    End If
                End If
            Catch ex As Exception
                Return "Token error"
            End Try

            Return ""
        End Function

        ''' <summary>
        ''' This method provide to get a current access key
        ''' </summary>
        ''' <returns></returns>
        Public Function getCurrentAccessKey() As String
            Try
                If (_CurrentAccessKey.key.Length = 0) Then
                    Return ""
                End If
                If (_CurrentAccessKey.isExpired) Then
                    Return ""
                End If

                Return _CurrentAccessKey.key
            Catch ex As Exception
                Return ""
            End Try
        End Function

        ''' <summary>
        ''' This method provide to close this service
        ''' </summary>
        ''' <returns></returns>
        Public Function close() As Boolean
            _CurrentAccessKey = Nothing
            _CurrentTokens = New Dictionary(Of String, KeyValidity)

            Return True
        End Function

    End Class

End Namespace
