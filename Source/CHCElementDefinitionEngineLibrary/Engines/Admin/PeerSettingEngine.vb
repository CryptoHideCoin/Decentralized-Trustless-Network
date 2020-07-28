Option Compare Text
Option Explicit On






Namespace CHCEngines



    Public Class PeerSettingEngine

        Inherits CHCCommonLibrary.CHCEngines.Common.BaseEncryption(Of Models.Administration.SettingModel)

        Private _logEngine As CHCServerSupport.Support.LogEngine







        Private Sub trackLog(ByVal position As String, ByVal content As String, Optional ByVal messageType As String = "info", Optional ByVal adapterLog As CHCServerSupport.Support.LogEngine = Nothing)

            If Not IsNothing(adapterLog) Then

                adapterLog.track(position, content, messageType)

            ElseIf Not IsNothing(_logEngine) Then

                _logEngine.track(position, content, messageType)

            End If

        End Sub



        Public Sub New(ByVal path As String, Optional ByVal logAdapter As CHCServerSupport.Support.LogEngine = Nothing)

            Try

                _logEngine = logAdapter

                trackLog("PeerSettingEngine (constructor)", "Begin")

                MyBase.fileName = IO.Path.Combine(path, "System", "Data.settings")

                trackLog("PeerSettingEngine (constructor)", "Set fileName = " & MyBase.fileName)

                MyBase.read()

                trackLog("PeerSettingEngine (constructor)", "Read data")

            Catch ex As Exception

                trackLog("PeerSettingEngine (constructor)", "Error:" & ex.Message, "Fatal")

            Finally

                trackLog("PeerSettingEngine (constructor)", "Complete")

            End Try

        End Sub


    End Class



End Namespace
