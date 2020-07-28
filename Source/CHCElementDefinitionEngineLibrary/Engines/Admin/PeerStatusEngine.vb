Option Compare Text
Option Explicit On

Imports System.Threading






Namespace CHCEngines



    Public Class PeerStatusEngine

        Private _log As CHCServerSupport.Support.LogEngine
        Private _businessEngine As CHCCommonLibrary.StandardInterface

        Public Property currentStatus As Models.EnumPeerStatusDetail



        Public ReadOnly Property officialStatus As Models.EnumPeerStatus
            Get

                Select Case currentStatus

                    Case Models.EnumPeerStatusDetail.onLine : Return Models.EnumPeerStatus.onLine
                    Case Else : Return Models.EnumPeerStatus.offLine

                End Select

            End Get
        End Property



        Private Function startEngine() As Boolean

            Try

                _log.track("PeerStatusEngine.startEngine", "Begin")

                Dim objAsynch As New Thread(AddressOf _businessEngine.Start)

                objAsynch.Start()

                Return True

            Catch ex As Exception

                _log.track("PeerStatusEngine.startEngine", "Error:" & ex.Message, "Fatal")

                Return False

            End Try

        End Function


        Private Function shutdownEngine() As Boolean

            Try

                _log.track("PeerStatusEngine.shutdownEngine", "Begin")

                Dim objAsynch As New Thread(AddressOf _businessEngine.stop)

                objAsynch.Start()

                Return True

            Catch ex As Exception

                _log.track("PeerStatusEngine.shutdownEngine", "Error:" & ex.Message, "Fatal")

                Return False

            End Try

        End Function



        Private Function maintenanceEngine() As String

            Try

                _log.track("PeerStatusEngine.maintenanceEngine", "Begin")

                Dim objAsynch As New Thread(AddressOf _businessEngine.maintenance)

                objAsynch.Start()

                Return True

            Catch ex As Exception

                _log.track("PeerStatusEngine.maintenanceEngine", "Error:" & ex.Message, "Fatal")

                Return False

            End Try

        End Function



        Private Function changeToStart() As String

            _log.track("PeerStatusEngine.changeInStartSystem", "Begin")

            Select Case currentStatus

                Case Models.EnumPeerStatusDetail.duringStartUp, Models.EnumPeerStatusDetail.onLine

                    _log.track("PeerStatusEngine.changeInStartSystem", "from Online")

                    Return ""

                Case Models.EnumPeerStatusDetail.maintenanceStart, Models.EnumPeerStatusDetail.shutDownStart

                    _log.track("PeerStatusEngine.changeInStartSystem", "from Maintenance / in shutDownStart")

                    Return "State incompatible with startup"

                Case Models.EnumPeerStatusDetail.inPauseFromMaintenance

                    _log.track("PeerStatusEngine.changeInStartSystem", "from Pause to Maintenance")

                    currentStatus = Models.EnumPeerStatusDetail.onLine

                    Return ""

                Case Else

                    _log.track("PeerStatusEngine.changeInStartSystem", "from shutdown / in maintenance")

                    currentStatus = Models.EnumPeerStatusDetail.duringStartUp

                    startEngine()

                    Return ""

            End Select

            _log.track("PeerStatusEngine.changeInStartSystem", "Complete")

        End Function



        Private Function changeToStop() As String

            _log.track("PeerStatusEngine.changeToStop", "Begin")

            Select Case currentStatus

                Case Models.EnumPeerStatusDetail.duringStartUp, Models.EnumPeerStatusDetail.maintenanceStart

                    _log.track("PeerStatusEngine.changeToStop", "from During StartUp")

                    Return "State incompatible with stop"

                Case Models.EnumPeerStatusDetail.onLine, Models.EnumPeerStatusDetail.inMaintenance, Models.EnumPeerStatusDetail.inPauseFromMaintenance

                    _log.track("PeerStatusEngine.changeToStop", "from Online / in Maintenance")

                    currentStatus = Models.EnumPeerStatusDetail.shutDownStart

                    shutdownEngine()

                    Return ""

                Case Else

                    _log.track("PeerStatusEngine.changeToStop", "from shutDownStart / shutdown")

                    Return ""

            End Select

            _log.track("PeerStatusEngine.changeToStop", "Complete")

        End Function



        Private Function changeToMaintenance() As String

            _log.track("PeerStatusEngine.changeToMaintenance", "Begin")

            Select Case currentStatus

                Case Models.EnumPeerStatusDetail.duringStartUp, Models.EnumPeerStatusDetail.shutDownStart

                    _log.track("PeerStatusEngine.changeToMaintenance", "from During StartUp")

                    Return "State incompatible with stop"

                Case Models.EnumPeerStatusDetail.offLine, Models.EnumPeerStatusDetail.onLine

                    _log.track("PeerStatusEngine.changeToMaintenance", "from Offline / Online")

                    currentStatus = Models.EnumPeerStatusDetail.maintenanceStart

                    maintenanceEngine()

                    Return ""

                Case Else

                    _log.track("PeerStatusEngine.changeToMaintenance", "from shutDownStart / shutdown")

                    Return ""

            End Select

            _log.track("PeerStatusEngine.changeToMaintenance", "Complete")

        End Function



        Public Function setChangeStatus(ByVal newStatus As Models.EnumChangeStatus, ByVal secureKey As String) As String

            _log.track("PeerStatusEngine.setChangeStatus", "Begin")

            Select Case newStatus

                Case Models.EnumChangeStatus.toStart

                    _log.track("PeerStatusEngine.setChangeStatus", "try to change status in onLine")

                    Return changeToStart(secureKey)

                Case Models.EnumChangeStatus.toStop

                    _log.track("PeerStatusEngine.setChangeStatus", "try to change status in stop")

                    Return changeToStop()

                Case Models.EnumChangeStatus.toMaintenance

                    _log.track("PeerStatusEngine.setChangeStatus", "try to change status in maintenance")

                    Return changeToMaintenance()

            End Select

            _log.track("PeerStatusEngine.setChangeStatus", "Complete")

        End Function


        Public Function init(ByRef log As CHCServerSupport.Support.LogEngine, ByRef engine As CHCCommonLibrary.StandardInterface) As Boolean

            _log = log
            _businessEngine = engine

            Return True

        End Function

    End Class



End Namespace
