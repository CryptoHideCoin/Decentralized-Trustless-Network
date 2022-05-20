Option Compare Text
Option Explicit On

' ****************************************
' Engine: Log Cache
' Release Engine: 1.0 
' 
' Date last successfully test: 24/04/2022
' ****************************************

Imports CHCModelsLibrary.AreaModel.Log



Namespace AreaEngine.Log

    ''' <summary>
    ''' This class contain all component to manage the block
    ''' </summary>
    Public Class LogBlockEngine

        Public logFilePath As String = ""
        Public logInstance As String = ""


        ''' <summary>
        ''' This method provide to remove from the index
        ''' </summary>
        ''' <param name="blockNumberValue"></param>
        ''' <returns></returns>
        Private Function removeFromList(ByVal blockNumberValue As String) As Boolean
            Try
                Dim completeFile As String
                Dim content As String = ""
                Dim newContent As String = ""
                Dim rows(), fields()

                If (logInstance.Length > 0) Then
                    completeFile = IO.Path.Combine(logFilePath, logInstance)
                Else
                    completeFile = logFilePath
                End If

                completeFile = IO.Path.Combine(completeFile, "index.dat")

                content = My.Computer.FileSystem.ReadAllText(completeFile)
                rows = Split(content, vbCrLf)

                For Each singleRow In rows
                    fields = Split(singleRow, "|")

                    If (fields(0).ToString.CompareTo(blockNumberValue) <> 0) Then
                        newContent += singleRow & vbCrLf
                    End If
                Next

                My.Computer.FileSystem.WriteAllText(completeFile, newContent, False)

                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function


        ''' <summary>
        ''' This method provide to read convert and return a specific log file
        ''' </summary>
        ''' <param name="blockNumberValue"></param>
        ''' <returns></returns>
        Public Function read(ByVal blockNumberValue As String) As List(Of SingleActionApplication)
            Try
                Dim completeFile As String
                Dim content As String
                Dim rows(), fields()
                Dim singleData As SingleActionApplication
                Dim result As New List(Of SingleActionApplication)

                If (logInstance.Length > 0) Then
                    completeFile = IO.Path.Combine(logFilePath, logInstance)
                Else
                    completeFile = logFilePath
                End If

                completeFile = IO.Path.Combine(completeFile, $"{blockNumberValue}.log")

                content = My.Computer.FileSystem.ReadAllText(completeFile)
                rows = Split(content, vbCrLf)

                For Each singleRow In rows
                    If (singleRow.ToString.Length > 0) Then
                        fields = Split(singleRow, "|")

                        singleData = New SingleActionApplication

                        singleData.instant = CDbl(fields(0))

                        Select Case fields(1)
                            Case 0 : singleData.action = ActionEnumeration.undefined
                            Case 1 : singleData.action = ActionEnumeration.printIntoConsole
                            Case 2 : singleData.action = ActionEnumeration.enterIntoMethod
                            Case 3 : singleData.action = ActionEnumeration.exitFromTheMethod
                            Case 4 : singleData.action = ActionEnumeration.genericTrack
                            Case 5 : singleData.action = ActionEnumeration.exception
                            Case 6 : singleData.action = ActionEnumeration.trackMarker
                        End Select

                        singleData.position = fields(2)
                        singleData.message = fields(3)

                        result.Add(singleData)
                    End If
                Next

                Return result
            Catch ex As Exception
                Return New List(Of SingleActionApplication)
            End Try
        End Function

        ''' <summary>
        ''' This method provide to return an list log file structures
        ''' </summary>
        ''' <returns></returns>
        Public Function readListLogFile() As LogListModel
            Dim result As New LogListModel
            Dim completeFile As String

            Try
                If (logInstance.Length > 0) Then
                    completeFile = IO.Path.Combine(logFilePath, logInstance)
                Else
                    completeFile = logFilePath
                End If

                Dim indexFile As String = IO.Path.Combine(completeFile, "index.dat")
                Dim content As String = My.Computer.FileSystem.ReadAllText(indexFile)
                Dim rows() = Split(content, vbCrLf)
                Dim field()

                For Each singleRow In rows
                    If (singleRow.Length > 0) Then
                        field = Split(singleRow, "|")

                        result.addNew(field(0), CDbl(field(1)))
                    End If
                Next

                Return result
            Catch ex As Exception
                Return New LogListModel
            End Try
        End Function

        ''' <summary>
        ''' This method provide to test if the block exist or not
        ''' </summary>
        ''' <param name="blockNumberValue"></param>
        ''' <returns></returns>
        Public Function exist(ByVal blockNumberValue As String) As Boolean
            Dim completeFile As String

            If (logInstance.Length > 0) Then
                completeFile = IO.Path.Combine(logFilePath, logInstance)
            Else
                completeFile = logFilePath
            End If

            completeFile = IO.Path.Combine(completeFile, $"{blockNumberValue}.log")

            Return IO.File.Exists(completeFile)
        End Function

        ''' <summary>
        ''' This method provide to delete a file from disk and update index file
        ''' </summary>
        ''' <param name="blockNumberValue"></param>
        ''' <returns></returns>
        Public Function delete(ByVal blockNumberValue As String) As Boolean
            Try
                Dim completeFile As String

                If (logInstance.Length > 0) Then
                    completeFile = IO.Path.Combine(logFilePath, logInstance)
                Else
                    completeFile = logFilePath
                End If

                completeFile = IO.Path.Combine(completeFile, $"{blockNumberValue}.log")

                IO.File.Delete(completeFile)

                If Not IO.File.Exists(completeFile) Then
                    Return removeFromList(blockNumberValue)
                Else
                    Return False
                End If
            Catch ex As Exception
                Return False
            End Try
        End Function

    End Class

End Namespace
