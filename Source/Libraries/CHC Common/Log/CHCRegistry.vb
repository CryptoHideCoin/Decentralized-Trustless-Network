Option Explicit On
Option Compare Text

' ****************************************
' Engine: Registry Engine
' Release Engine: 1.0 
' 
' Date last successfully test: 02/10/2021
' ****************************************


Imports CHCCommonLibrary.AreaEngine.DataFileManagement.XML




Namespace Support

    ''' <summary>
    ''' This class write a registry file
    ''' </summary>
    Public Class RegistryEngine

        Inherits BaseFile(Of List(Of RegistryData))


        ''' <summary>
        ''' This class contain the data relative an a event
        ''' </summary>
        Public Class RegistryData

            Public Enum TypeEvent
                applicationStartUp
                applicationShutdown
                applicationError
                adminTokenReleased
                other
            End Enum

            Public istant As DateTime
            Public type As TypeEvent
            Public description As String
            Public fileDetail As String

        End Class

        Private _Path As String = ""
        Private _Day As String = ""

        Public noSave As Boolean = False



        ''' <summary>
        ''' This method provide to addNew event in the Registry
        ''' </summary>
        ''' <param name="type"></param>
        ''' <param name="description"></param>
        ''' <param name="fileDetail"></param>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Public Function addNew(ByVal type As RegistryData.TypeEvent, Optional ByVal description As String = "", Optional ByVal fileDetail As String = "") As Boolean
            Try
                Dim item As New RegistryData

                item.istant = Now
                item.type = type
                item.description = description
                item.fileDetail = fileDetail

                MyBase.data.Add(item)

                If Not noSave Then
                    MyBase.save()
                End If

                Return init()
            Catch ex As Exception
                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to create path into base directory
        ''' and set file name
        ''' </summary>
        ''' <param name="path"></param>
        ''' <returns></returns>
        Public Function init(Optional ByVal path As String = "") As Boolean
            Try
                If (_Day <> Now.ToUniversalTime().ToString("yyyy-MM-dd")) Then
                    _Path = path

                    If Not IO.Directory.Exists(path) Then
                        IO.Directory.CreateDirectory(path)
                    End If

                    _Day = Now.ToUniversalTime().ToString("yyyy-MM-dd")

                    MyBase.fileName = IO.Path.Combine(path, _Day & ".registry")

                    MyBase.read()
                End If

                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

    End Class


End Namespace
