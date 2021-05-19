Option Explicit On
Option Compare Text


Namespace AreaEngine.Ledger

    Namespace Common

        Public Enum enumCheckResult

            notDefined
            checkControlPassed
            checkControlNotPassed

        End Enum

        Public Class NetworkChain

            Public Property networkName As String = ""
            Public Property chainName As String = ""

        End Class

    End Namespace

End Namespace
