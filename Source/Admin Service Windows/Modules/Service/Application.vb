Option Compare Text
Option Explicit On



Namespace AreaApplication


    Module Application

        Public assets As New AreaEngine.CryptoAssetEngine
        Public visionPapers As New AreaEngine.GenericPaperEngine
        Public whitePapers As New AreaEngine.GenericPaperEngine
        Public yellowPapers As New AreaEngine.GenericPaperEngine
        Public privacyPapers As New AreaEngine.GenericPaperEngine
        Public termsAndConditionsPapers As New AreaEngine.GenericPaperEngine
        Public referenceProtocol As New AreaEngine.ReferenceProtocolEngine
        Public priceTables As New AreaEngine.PriceTableEngine
        Public refundPlans As New AreaEngine.RefundPlanEngine
        Public sideChainContracts As New AreaEngine.SidechainConfigurationEngine

    End Module


End Namespace


