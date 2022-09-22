Option Compare Text
Option Explicit On


Namespace AreaCommon.Models.Bot

    Public Class BotAutomaticSettingsModel

        Public Enum BackConfigurationEnum
            undefined = -1
            restockAll = 0
            entireRestock = 1
            fixRestor = 2
            PercentageRestock = 3
        End Enum

        Public Property plafondOperation As Double = 0
        Public Property unitStep As Double = 0

        Public Property minDailyEarn As Double = 0
        Public Property maxDailyEarn As Double = 0
        Public Property dealAcquireOnPercentage As Double = 0
        Public Property dealIntervalMinute As Double = 0

        Public Property backConfiguration As BackConfigurationEnum = BackConfigurationEnum.undefined
        Public Property backValue As Double = 0

    End Class

    Public Class JournalReportDay

        Public Property day As Double = 0

        Public Property investment As Double = 0
        Public Property investmentOnNewResource As Double = 0
        Public Property investmentOnRestock As Double = 0

        Public Property minEarn As Double = 0
        Public Property maxEarn As Double = 0

        Public Property depositEarn As Double = 0

    End Class

    Public Class BotAutomatic

        Public Enum WorkStateEnumeration
            undefined
            completeRemoveActiveProducts
            checkBalance
            checkAllSellDailyProduct
            restockProducts
            reorderProducts
            investProducts
            checkAllBuyDailyProduct
            completeWork
        End Enum


        Public Property settings As New BotAutomaticSettingsModel
        Public Property journalData As New List(Of JournalReportDay)

        Public Property isActive As Boolean = False
        Public Property lastWorkAction As Double = 0
        Public Property workAction As WorkStateEnumeration = WorkStateEnumeration.undefined

        Public Function resetData() As Boolean
            journalData = New List(Of JournalReportDay)

            isActive = False

            Return True
        End Function

    End Class

End Namespace