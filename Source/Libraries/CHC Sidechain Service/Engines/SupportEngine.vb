Option Compare Text
Option Explicit On





Namespace AreaCommon.Engine


    ''' <summary>
    ''' This class contain all element to support the chain
    ''' </summary>
    Public Class SupportEngine

        Private _LastIdIdle As Boolean = True
        Private _LastActionOccurs As Double = 0

        Public Property inIdle As Boolean = True


        ''' <summary>
        ''' This property return the time of sleep
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property timeSleep As Integer
            Get
                Dim change As Boolean = False

                If (_LastIdIdle <> inIdle) Then
                    change = True

                    _LastIdIdle = inIdle
                End If
                If inIdle Then
                    If change Then
#If DEBUG Then
#Else
                        Console.WriteLine("In low consuption mode")
#End If
                    End If

                    Return 100
                Else
                    If change Then
#If DEBUG Then
#Else
                        Console.WriteLine("In work mode")
#End If
                    End If

                    Return 1
                End If
            End Get
        End Property

        ''' <summary>
        ''' This method provide to check last time that this method is invoke. If it is major of two second the node enter in the protection mode
        ''' </summary>
        ''' <returns></returns>
        Public Function checkLastTime() As Boolean
            Try
                Dim currentTimeStamp = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()

                If (_LastActionOccurs = 0) Then
                    _LastActionOccurs = currentTimeStamp

                    Return True
                ElseIf ((_LastActionOccurs + 10000) > currentTimeStamp) Then
                    _LastActionOccurs = currentTimeStamp

                    Return True
                Else
#If DEBUG Then
                    Return True
#End If
                    'flow.workerOn = False

                    Return False
                End If
            Catch ex As Exception
                Return False
            End Try
        End Function

    End Class

End Namespace
