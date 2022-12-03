Option Compare Text
Option Explicit On



Namespace AreaCommon.Models.Journal

    ''' <summary>
    ''' This class contain all data relative of a fund reservation
    ''' </summary>
    Public Class FundReservationModel

        Public Enum ModeReservationEnumeration
            undefined
            allNow
            urgent
            immediate
            booking
        End Enum

        Public Property mode As ModeReservationEnumeration = ModeReservationEnumeration.undefined

        Public Property targetDay As Integer = 0
        Public Property targetCurrency As String = ""
        Public Property targetValue As Double = 0

        Public Property nextTargetDay As Double = 0
        Public Property nextUserTargetDay As String = ""
        Public Property currentLockedFund As Double = 0
        Public Property targetLockedFund As Double = 0
        Public Property whenInEarn As Boolean = False

    End Class

End Namespace