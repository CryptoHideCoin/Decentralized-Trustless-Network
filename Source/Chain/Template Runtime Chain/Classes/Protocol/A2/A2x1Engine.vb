Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.Support
Imports CHCCommonLibrary.AreaEngine.DataFileManagement
Imports CHCCommonLibrary.AreaEngine.Encryption




Namespace AreaProtocol

    Public Class A2x1

        Public Class RequestModel

            Public Property requestCode As String = "A2x1"

            Public Property netWorkHash As String = ""
            Public Property chainHash As String = ""

            Public Property publicAddressRequester As String = ""
            Public Property requestDateTimeStamp As Double = 0
            Public Property publicAddressAbsent As String = ""
            Public Property requestHash As String = ""
            Public Property requestSignature As String = ""

            Public Overrides Function toString() As String
                Dim tmp As String = ""

                tmp += requestCode
                tmp += netWorkHash
                tmp += chainHash
                tmp += publicAddressRequester
                tmp += requestDateTimeStamp.ToString()
                tmp += publicAddressAbsent

                Return tmp
            End Function

            Public Function getHash() As String
                Return HashSHA.generateSHA256(Me.toString())
            End Function
        End Class

        Public Class RequestResponseModel

            Inherits CHCCommonLibrary.AreaCommon.Models.General.RemoteResponse

            Public Property requestCode As String = "A2x1"

            Public Property netWorkHash As String = ""
            Public Property chainHash As String = ""

            Public Property publicAddressRequester As String = ""
            Public Property requestDateTimeStamp As Double = 0
            Public Property publicAddressAbsent As String = ""
            Public Property requestHash As String = ""
            Public Property requestSignature As String = ""

            Public Overrides Function toString() As String
                Dim tmp As String = ""

                tmp += requestCode
                tmp += netWorkHash
                tmp += chainHash
                tmp += publicAddressRequester
                tmp += requestDateTimeStamp.ToString()
                tmp += publicAddressAbsent

                Return tmp
            End Function

            Public Function getHash() As String
                Return HashSHA.generateSHA256(Me.toString())
            End Function
        End Class

        Public Class RecoveryState

            Public Shared Function fromRequest(ByRef value As RequestModel, ByRef transactionChainRecord As CHCCommonLibrary.AreaCommon.Models.General.IdentifyLastTransaction) As Boolean
                Dim proceed As Boolean = True

                Return proceed
            End Function

            Public Shared Function fromTransactionLedger(ByRef value As TransactionChainLibrary.AreaLedger.SingleTransactionLedger) As Boolean

                Return True
            End Function

        End Class

        Public Class FormalCheck

            Shared Function verify(ByVal requestHash As String) As Nullable(Of Boolean)
                Try
                    'Dim file As New IOFast(Of RequestModel)
                    'Dim proceed As Boolean = True

                    'file.fileName = IO.Path.Combine(AreaCommon.paths.workData.temporally, requestHash & ".request")

                    'If file.read() Then
                    '    If proceed Then
                    '        proceed = (file.data.requestDateTimeStamp <= CHCCommonLibrary.AreaEngine.Miscellaneous.timestampFromDateTime())
                    '    End If
                    '    If proceed Then
                    '        'proceed = file.data.
                    '    End If
                    'Else
                    '    proceed = False
                    'End If

                    'Return proceed
                Catch ex As Exception
                    Return Nothing
                End Try
            End Function

            Shared Function evaluate(ByRef value As AreaFlow.RequestExtended) As Nullable(Of Boolean)
                Try
                    'Dim file As New IOFast(Of RequestModel)
                    'Dim proceed As Boolean = True

                    'file.fileName = IO.Path.Combine(AreaCommon.paths.workData.temporally, value.requestHash & ".request")

                    'If file.read() Then

                    '    value.generalStatus = AreaFlow.EnumOperationPosition.completeWithPositiveResult
                    'Else
                    '    proceed = False

                    '    value.rejectedNote = "Masternode problem"
                    '    value.generalStatus = AreaFlow.EnumOperationPosition.completeWithPositiveResult
                    'End If

                    'Return proceed
                Catch ex As Exception
                    Return Nothing
                End Try
            End Function

        End Class

        Public Class Manager

            Private Property dateDeterminateApproved As Double
            Private Property approvedHash As String


            Private Function writeDataIntoLedger() As CHCCommonLibrary.AreaCommon.Models.General.IdentifyLastTransaction
                Try
                    If AreaCommon.state.currentBlockLedger.blockComplete() Then
                        Return AreaCommon.state.currentBlockLedger.saveAndClean()
                    End If
                Catch ex As Exception
                    AreaCommon.state.currentService.currentAction.setError(Err.Number, ex.Message)

                    AreaCommon.log.track("A0x0.Manager.init", ex.Message, "fatal")
                End Try

                Return New CHCCommonLibrary.AreaCommon.Models.General.IdentifyLastTransaction
            End Function


            ''' <summary>
            ''' This method provide to return an RequestModel from RequestResponseModel
            ''' </summary>
            ''' <param name="value"></param>
            ''' <returns></returns>
            Public Shared Function extractToRequest(ByRef value As RequestResponseModel) As RequestModel
                Dim result As New RequestModel
                Try
                    result.publicAddressAbsent = value.publicAddressAbsent
                    result.publicAddressRequester = value.publicAddressRequester
                    result.requestDateTimeStamp = value.requestDateTimeStamp
                    result.requestHash = value.requestHash
                    result.requestSignature = value.requestSignature
                Catch ex As Exception
                End Try

                Return result
            End Function

            ''' <summary>
            ''' This method provide to save a request into temporally position
            ''' </summary>
            ''' <param name="value"></param>
            ''' <returns></returns>
            Public Shared Function saveTemporallyRequest(ByRef value As RequestModel) As Boolean
                Try
                    'Dim requestFileEngine As New IOFast(Of RequestModel)

                    'requestFileEngine.data = value

                    'requestFileEngine.fileName = IO.Path.Combine(AreaCommon.paths.workData.temporally, value.requestHash & ".request")

                    'Return requestFileEngine.save()
                Catch ex As Exception
                    Return False
                End Try
            End Function

            ''' <summary>
            ''' This method provide to save a request into temporally position from RequestResponseModel
            ''' </summary>
            ''' <param name="value"></param>
            ''' <returns></returns>
            Public Shared Function saveTemporallyRequest(ByRef value As RequestResponseModel) As Boolean
                Return saveTemporallyRequest(extractToRequest(value))
            End Function

            ''' <summary>
            ''' This method provide to create a initial procedure A0x0
            ''' </summary>
            ''' <param name="publicAddressAbsent"></param>
            ''' <returns></returns>
            Public Shared Function createRequest(ByVal publicAddressAbsent As String) As Boolean
                Try
                    Dim data As New RequestModel

                    AreaCommon.log.track("A2x1Manager.init", "Begin")

                    AreaCommon.state.currentService.currentAction.setAction("2x0001", "BuildManager - A2x1 - A2x1Manager")

                    If AreaCommon.state.currentService.requestCancelCurrentRunCommand Then Return False

                    If (publicAddressAbsent.CompareTo(AreaCommon.state.internalInformation.networkName) <> 0) Then
                        AreaCommon.state.currentService.currentAction.setError("-1", "Network not compatible")
                        AreaCommon.state.currentService.currentAction.reset()

                        AreaCommon.log.track("A0x0Manager.init", "Error: Network not compatible", "fatal")

                        Return False
                    End If

                    With AreaCommon.state.keys.key(TransactionChainLibrary.AreaEngine.KeyPair.KeysEngine.KeyPair.enumWalletType.identity)
                        data.publicAddressAbsent = publicAddressAbsent
                        data.publicAddressRequester = .publicAddress
                        data.requestDateTimeStamp = AreaCommon.state.runtimeState.activeNetwork.networkCreationDate
                        data.requestHash = data.getHash
                        data.requestSignature = CHCProtocolLibrary.AreaWallet.Support.WalletAddressEngine.createSignature(.privateKey, data.requestHash)
                    End With

                    If saveTemporallyRequest(data) Then
                        AreaCommon.log.track("A0x0Manager.init", "request - Saved")

                        Return AreaCommon.flow.addNewRequestDirect(data)
                    End If
                Catch ex As Exception
                    AreaCommon.state.currentService.currentAction.setError(Err.Number, ex.Message)

                    AreaCommon.log.track("A0x0Manager.init", ex.Message, "fatal")
                Finally
                    AreaCommon.log.track("A0x0Manager.init", "Completed")
                End Try

                Return False
            End Function
        End Class

    End Class

End Namespace
