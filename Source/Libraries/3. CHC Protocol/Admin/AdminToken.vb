Option Explicit On
Option Compare Text




Namespace AreaEngine.Security

    ''' <summary>
    ''' This class manage the admin request token
    ''' </summary>
    Public Class AdminTokenEngine

        Private Property _CurrentToken As String = ""
        Private Property _CurrentAccessKey As String = ""
        Private Property _DateLastAccess As Double = 0
        Private Property _DateAccessKeyCreation As Double = 0

        ''' <summary>
        ''' This method provide to create a new token into memory
        ''' </summary>
        ''' <returns></returns>
        Public Function create() As String
            _CurrentToken = Guid.NewGuid.ToString()
            _DateLastAccess = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime

            Return _CurrentToken
        End Function

        ''' <summary>
        ''' Thie method provide to create access key into memory
        ''' </summary>
        ''' <returns></returns>
        Public Function createAccessKey() As String
            _CurrentAccessKey = Guid.NewGuid.ToString()
            _DateAccessKeyCreation = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime

            Return _CurrentAccessKey
        End Function

        ''' <summary>
        ''' This method provide to test if check token is successful
        ''' </summary>
        ''' <returns></returns>
        Public Function check(ByVal value As String) As String
            Try
                Dim expirationTime As Double = 0

                If (_CurrentToken.Length = 0) Then
                    Return "Missing token"
                End If

#If DEBUG Then
                expirationTime = (24 * 60 * 1000)
#Else
                expirationTime = (10 * 60 * 1000)
#End If

                If (CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime > _DateLastAccess + expirationTime) Then
                    _CurrentToken = ""

                    Return "Token expired"
                End If
                If (value.CompareTo(_CurrentToken) <> 0) Then
                    Return "Token mismatch"
                End If

                _DateLastAccess = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime
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
                If (_CurrentAccessKey.Length = 0) Then
                    Return ""
                End If
                If (CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime > _DateAccessKeyCreation + (5 * 1000)) Then
                    _CurrentAccessKey = ""
                    _DateAccessKeyCreation = 0

                    Return ""
                End If

                Return _CurrentAccessKey
            Catch ex As Exception
                Return ""
            End Try
        End Function

    End Class

End Namespace
