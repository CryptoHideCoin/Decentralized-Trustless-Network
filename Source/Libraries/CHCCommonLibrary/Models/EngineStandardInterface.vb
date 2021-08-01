Option Explicit On
Option Compare Text



Namespace AreaCommon.Models


    Public Interface StandardInterface
        Function start() As Boolean
        Function [stop]() As Boolean
        Function maintenance() As Boolean
    End Interface


    Public Class CommunicationServiceInformation
        Public useSecure As Boolean = False
        Public url As String = ""
        Public certificate As String = ""


        Public Function secureToString() As String
            If useSecure Then
                Return "https://"
            Else
                Return "http://"
            End If
        End Function

        Public Function composeURL(ByVal intermediateValue As String, Optional ByVal useCertificate As Boolean = False) As String
            If useCertificate Then
                Return secureToString() & url & intermediateValue & "?certificate=" & certificate
            Else
                Return secureToString() & url & intermediateValue
            End If
        End Function

    End Class

End Namespace
