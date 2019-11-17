Option Compare Text
Option Explicit On





Namespace CHCEngines


    Public Class EntityDefinitionDataEngine

        Inherits CHCCommonLibrary.CHCEngines.Common.BaseEncryption(Of Models.EntityDefinitionModel)




        Public Sub createFileName(ByVal Path As String, ByVal FileName As String)

            MyBase.fileName = IO.Path.Combine(Path, FileName)

        End Sub


    End Class



End Namespace
