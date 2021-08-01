Option Compare Text
Option Explicit On



Module CHCModule

    Public supportLogRotate As Support.LogRotateEngine




    Public Function executeLogRotate() As Boolean

        Return supportLogRotate.runExecuteWork()

    End Function

End Module