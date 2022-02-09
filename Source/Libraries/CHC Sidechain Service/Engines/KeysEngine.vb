Option Explicit On
Option Compare Text


Namespace AreaEngine.Keys

    ''' <summary>
    ''' This class contain the Keys engine
    ''' </summary>
    Public Class KeysEngine

        ''' <summary>
        ''' This class contain the KeyPair informations
        ''' </summary>
        Public Class KeyPair

            Public Enum enumWalletType
                undefined
                administration
                identity
            End Enum

            Public Property [public] As String = ""
            Public Property [private] As String = ""

        End Class

        Public Property administration As New KeyPair
        Public Property identity As New KeyPair

    End Class

End Namespace
