Option Compare Text
Option Explicit On

' ****************************************
' Engine: Log Model
' Release Engine: 1.0 
' 
' Date last successfully test: 21/02/2022
' ****************************************



Namespace AreaModel.Network.Communication

    Public Enum Method
        [Get]
        Post
        Put
        Patch
        Delete
    End Enum

    ''' <summary>
    ''' Options for the given <see cref="System.Net.HttpWebRequest"/> 
    ''' </summary>
    Public Class Options

        Public Property Headers As New System.Net.WebHeaderCollection
        Public Property Credentials As System.Net.ICredentials = Nothing
        Public Property Connection As String = Nothing
        Public Property KeepAlive As Boolean = True
        Public Property Expect As String = Nothing
        Public Property IfModifiedSince As Date
        Public Property TransferEncoding As String
        Public Property Accept As String = Nothing
        Public Property AllowAutoRedirect As Boolean = True
        Public Property AllowReadStreamBuffering As Boolean = False
        Public Property AllowWriteStreamBuffering As Boolean = True
        Public Property MaximumAutomaticRedirections As Integer = 50
        Public Property MediaType As String = Nothing
        Public Property Pipelined As Boolean = True
        Public Property PreAuthenticate As Boolean = False
        Public Property Referer As String = Nothing
        Public Property SendChunked As Boolean = False
        Public Property UseDefaultCredentials As Boolean = False
        Public Property UserAgent As String = Nothing
        Public Property ContentType As String = Nothing
        Public Property Timeout As Integer = 100000
        Public Property ReadWriteTimeout As Integer = 300000

    End Class

    Public MustInherit Class ContentType

        Public Const ApplicationUrlEncoded As String = "application/x-www-form-urlencoded"
        Public Const ApplicationJson As String = "application/json"
        Public Const TextXml As String = "text/xml"

    End Class


End Namespace
