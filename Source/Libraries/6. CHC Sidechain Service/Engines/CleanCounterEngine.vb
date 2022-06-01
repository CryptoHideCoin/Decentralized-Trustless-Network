Option Explicit On
Option Compare Text

Imports CHCModelsLibrary.AreaModel.Log








Namespace AreaEngine

    '''' <summary>
    '''' This class contain all element of engine clean of counter's request
    '''' </summary>
    Public Class CleanCounterEngine

        Public Property ownerId As String = ""

        ''' <summary>
        ''' This method provide to delete all older counter events file
        ''' </summary>
        ''' <returns></returns>
        Public Function run() As Boolean
            Try
                AreaCommon.Main.environment.log.trackEnter("CleanCounterEngine.run", ownerId)

                If (AreaCommon.Main.serviceInformation.currentStatus <> CHCModelsLibrary.AreaModel.Information.InternalServiceInformation.EnumInternalServiceState.started) Then
                    Return False
                End If

                Dim limitTime As Double = CDbl(1000) * 60 * 60 * 24
                Dim listFile As New List(Of String)

                Select Case AreaCommon.Main.environment.settings.autoMaintenance.counterRotate.keepLast
                    Case KeepEnum.lastMonth : limitTime = CDbl(limitTime) * 30
                    Case KeepEnum.lastWeek : limitTime = CDbl(limitTime) * 7
                    Case KeepEnum.lastYear : limitTime = CDbl(limitTime) * 365
                End Select

#If DEBUG Then
                limitTime = 60000
#End If

                limitTime = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime() - limitTime

                AreaCommon.Main.environment.counter.removeOld(limitTime)

                AreaCommon.Main.environment.log.trackExit("CleanCounterEngine.run", ownerId)

                Return True
            Catch ex As Exception
                AreaCommon.Main.environment.log.trackException("CleanCounterEngine.run", ownerId, ex.Message)

                Return False
            End Try
        End Function

    End Class

End Namespace
