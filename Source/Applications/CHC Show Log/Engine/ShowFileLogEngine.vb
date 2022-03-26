Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.CommandLine
Imports CHCCommonLibrary.AreaEngine.Communication
Imports CHCModels.AreaModel.Network.Response
Imports CHCModels.AreaModel.Log





Namespace AreaCommon

    ''' <summary>
    ''' This class contain all element to show the file
    ''' </summary>
    Public Class ShowFileLogEngine

        Private Class ResultDecode
            Public Property previousTimeStamp As Double = 0
            Public Property formattedLineLog As String = ""
            Public Property complete As Boolean = False
        End Class

        ''' <summary>
        ''' This method provide to decode the log line
        ''' </summary>
        ''' <param name="line"></param>
        ''' <returns></returns>
        Private Shared Function decode(ByRef previous As Double, ByVal line As String) As ResultDecode
            Dim singleField As String() = line.Split("|")
            Dim result As New ResultDecode

            If (singleField.Count > 0) Then
                Dim instant As Double = 0
                Dim difference As Double

                If Not Double.TryParse(singleField(0), instant) Then
                    result.complete = False

                    Return result
                End If

                If (previous = 0) Then
                    previous = instant
                End If

                difference = instant - previous
                result.previousTimeStamp = instant

                result.formattedLineLog += CHCCommonLibrary.AreaEngine.Miscellaneous.dateTimeFromTimeStamp(instant)
                result.formattedLineLog += " (" & Math.Round(difference, 1, MidpointRounding.AwayFromZero) & " ms.) "
            Else
                result.complete = False
            End If

            If (singleField.Count > 1) Then
                Dim methodType As String = singleField(1)

                If IsNumeric(methodType) Then
                    Select Case methodType.Trim()
                        Case "0"
                            result.complete = False

                            Return result
                        Case "1" : result.formattedLineLog += "PrintInConsole - "
                        Case "2" : result.formattedLineLog += "EnterIntoMethod - "
                        Case "3" : result.formattedLineLog += "ExitFromTheMethod - "
                        Case "4" : result.formattedLineLog += "GenericTrack - "
                        Case "5" : result.formattedLineLog += "Exception - "
                        Case Else : result.formattedLineLog += methodType & " - "
                    End Select
                End If
            End If
            If (singleField.Count > 2) Then
                result.formattedLineLog += singleField(2)
            End If
            If (singleField.Count > 3) Then
                result.formattedLineLog += singleField(3)
            End If

            result.complete = True

            Return result
        End Function


        ''' <summary>
        ''' This method provide to execute the code
        ''' </summary>
        ''' <returns></returns>
        Public Shared Function execute(ByVal completeFileName As String) As Boolean
            Try
                Dim previous As Double = 0
                Dim line As String
                Dim numLine As Integer = 0

                Using reader As IO.StreamReader = New IO.StreamReader(completeFileName)
                    line = reader.ReadLine

                    Do While Not IsNothing(line)
                        With decode(previous, reader.ReadLine)
                            If .complete Then
                                previous = .previousTimeStamp

                                Console.WriteLine(.formattedLineLog)
                            End If
                        End With

                        line = reader.ReadLine

                        numLine += 1

                        If (numLine = 10) Then
                            Console.ReadKey()

                            numLine = 0
                        End If
                    Loop
                End Using

                Return True
            Catch ex As Exception
                Console.WriteLine("Error during sub main")

                Return False
            Finally
                Console.ReadKey()
            End Try
        End Function

    End Class

End Namespace
