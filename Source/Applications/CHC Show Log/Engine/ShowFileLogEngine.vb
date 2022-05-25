Option Compare Text
Option Explicit On






Namespace AreaCommon

    ''' <summary>
    ''' This class contain all element to show the file
    ''' </summary>
    Public Class ShowFileLogEngine

        Private Class ResultDecode
            Public Property action As CHCModelsLibrary.AreaModel.Log.ActionEnumeration
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

                result.formattedLineLog = CHCCommonLibrary.AreaEngine.Miscellaneous.formatDateTimeGMT(CHCCommonLibrary.AreaEngine.Miscellaneous.dateTimeFromTimeStamp(instant), True)
                result.formattedLineLog = result.formattedLineLog & Space(22 - result.formattedLineLog.Length)
            Else
                result.complete = False
            End If

            If (singleField.Count > 1) Then
                Dim methodType As String = singleField(2)

                If IsNumeric(methodType) Then
                    Select Case methodType.Trim()
                        Case "0"
                            result.complete = False
                            result.action = CHCModelsLibrary.AreaModel.Log.ActionEnumeration.undefined

                            Return result
                        Case "1"
                            result.formattedLineLog += "PrintInConsole"
                            result.action = CHCModelsLibrary.AreaModel.Log.ActionEnumeration.printIntoConsole
                        Case "2"
                            result.formattedLineLog += "EnterIntoMethod"
                            result.action = CHCModelsLibrary.AreaModel.Log.ActionEnumeration.enterIntoMethod
                        Case "3"
                            result.formattedLineLog += "ExitFromTheMethod"
                            result.action = CHCModelsLibrary.AreaModel.Log.ActionEnumeration.exitFromTheMethod
                        Case "4"
                            result.formattedLineLog += "GenericTrack"
                            result.action = CHCModelsLibrary.AreaModel.Log.ActionEnumeration.genericTrack
                        Case "5"
                            result.formattedLineLog += "Exception"
                            result.action = CHCModelsLibrary.AreaModel.Log.ActionEnumeration.exception
                        Case "6"
                            result.formattedLineLog += "Mark"
                            result.action = CHCModelsLibrary.AreaModel.Log.ActionEnumeration.trackMarker
                        Case Else
                            result.formattedLineLog += methodType
                    End Select
                End If

                result.formattedLineLog = result.formattedLineLog & Space(40 - result.formattedLineLog.Length)
            End If

            If (singleField.Count > 3) And (singleField(3).Length > 0) Then
                result.formattedLineLog += singleField(3) & "  "
            End If
            If (singleField.Count > 4) Then
                result.formattedLineLog += singleField(4)
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
                Dim numLine As Integer = 0, totalNumLines As Integer = 0
                Dim temp As String = $"File name:{completeFileName}"

                Console.WriteLine(temp)
                Console.WriteLine(Strings.StrDup(temp.Length, "="))
                Console.WriteLine("")

                Using reader As IO.StreamReader = New IO.StreamReader(completeFileName)
                    line = reader.ReadLine

                    Do While Not IsNothing(line)
                        With decode(previous, line)
                            If .complete Then
                                previous = .previousTimeStamp

                                If (.action = CHCModelsLibrary.AreaModel.Log.ActionEnumeration.exception) Then
                                    Console.ForegroundColor = ConsoleColor.Red
                                ElseIf (.action = CHCModelsLibrary.AreaModel.Log.ActionEnumeration.printIntoConsole) Then
                                    Console.ForegroundColor = ConsoleColor.Green
                                ElseIf (.action = CHCModelsLibrary.AreaModel.Log.ActionEnumeration.enterIntoMethod) Or
                                       (.action = CHCModelsLibrary.AreaModel.Log.ActionEnumeration.exitFromTheMethod) Then
                                    Console.ForegroundColor = ConsoleColor.Gray
                                Else
                                    Console.ForegroundColor = ConsoleColor.White
                                End If

                                Console.WriteLine(.formattedLineLog)
                            End If
                        End With

                        line = reader.ReadLine

                        numLine += 1
                        totalNumLines += 1

                        If (numLine = 20) Then
                            Console.ReadKey()

                            numLine = 0
                        End If
                    Loop
                End Using

                Console.WriteLine("")
                Console.WriteLine($"{totalNumLines} item(s)")

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
