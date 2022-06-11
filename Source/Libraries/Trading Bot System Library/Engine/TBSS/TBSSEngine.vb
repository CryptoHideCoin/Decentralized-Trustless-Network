Option Compare Text
Option Explicit On







Namespace AreaEngine

    Public Class TradingBotSystemServiceEngine

        Private Property _EngineDB As New CHCDataAccess.AreaCommon.Database.DatabaseGeneric
        Private Property _DBStateFileName As String = "EvaluationState.Db"



        Private Property _Initialize As Boolean = False
        Private Property _OwnerId As String = ""
        Private Property _ServiceActive As Boolean = False




        ''' <summary>
        ''' This property get/set the service active
        ''' </summary>
        ''' <returns></returns>
        Public Property serviceActive As Boolean
            Get
                Return _ServiceActive
            End Get
            Set(value As Boolean)
                _ServiceActive = value
            End Set
        End Property

        ''' <summary>
        ''' This methdo provide to initialize the main engine
        ''' </summary>
        ''' <returns></returns>
        Public Function init(ByVal state As AreaService.Runtime.Models.ServiceState) As Boolean
            Try
                _OwnerId = "EvalutationStateEngine"

                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackEnter("EvaluationEngine.init", _OwnerId)

                AreaCommon.state = state

                _EngineDB.path = CHCSidechainServiceLibrary.AreaCommon.Main.environment.paths.workData.state.path
                _EngineDB.fileName = _DBStateFileName
                _EngineDB.logInstance = CHCSidechainServiceLibrary.AreaCommon.Main.environment.log

                If Not IO.Directory.Exists(_EngineDB.path) Then
                    IO.Directory.CreateDirectory(_EngineDB.path)
                End If

                If _EngineDB.init("Evaluation", "Custom") Then
                    AreaCommon.state.exchangesEngine.useCache = True

                    If Not AreaCommon.state.exchangesEngine.init() Then
                        CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.track("EvaluationEngine.init", _OwnerId, "Problem during initialize Exchanges engine init")

                        Return False
                    End If
                    If Not AreaCommon.state.currenciesEngine.init() Then
                        CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.track("EvaluationEngine.init", _OwnerId, "Problem during initialize Currencies engine init")

                        Return False
                    End If
                    If Not AreaCommon.state.exchangeReferencesEngine.init() Then
                        CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.track("EvaluationEngine.init", _OwnerId, "Problem during initialize Exchange References engine init")

                        Return False
                    End If
                    If Not AreaCommon.state.currenciesDownloadEngine.init() Then
                        CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.track("EvaluationEngine.init", _OwnerId, "Problem during initialize Currencies Download engine init")

                        Return False
                    End If

                    _Initialize = True

                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackException("EvaluationEngine.init", _OwnerId, ex.Message)

                Return False
            Finally
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackExit("EvaluationEngine.init", _OwnerId)
            End Try
        End Function

    End Class

End Namespace
