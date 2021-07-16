Option Explicit On
Option Compare Text

Imports CHCCommonLibrary.AreaEngine.DataFileManagement
Imports CHCBasicCryptographyLibrary.AreaEngine.Encryption.Base58Signature
Imports CHCCommonLibrary.AreaEngine.Encryption
Imports CHCProtocolLibrary




Namespace AreaEngine.Ledger

    Namespace State

        Public Class StateInformation

            Public Property networkName As String = ""
            Public Property chainName As String = ""
            Public Property dateLast As New DateTime
            Public Property fileStateMD5 As String = ""

            Public Property hashData As String = ""
            Public Property signature As String = ""

            Public Overrides Function toString() As String
                Dim tmp As String = ""

                tmp += networkName
                tmp += chainName
                tmp += dateLast.ToString
                tmp += fileStateMD5

                Return tmp
            End Function

            Public Function getHash() As String
                Return HashSHA.generateSHA256(Me.toString())
            End Function

        End Class

        Public Class StateEngine

            Public Shared Function readContentFromFile(ByVal statePath As String, ByVal contentHash As String) As String
                Try
                    Dim fileName As String = IO.Path.Combine(statePath, "Contents", contentHash & ".content")

                    Dim value As String = IO.File.ReadAllText(fileName)

                    Return value
                Catch ex As Exception
                    Return ""
                End Try
            End Function

            Public Shared Function writeDataContent(ByVal statePath As String, ByVal content As String, ByVal contentHash As String) As Boolean
                Try
                    Dim fileName As String = IO.Path.Combine(statePath, "Contents", contentHash & ".content")

                    If IO.File.Exists(fileName) Then
                        IO.File.WriteAllText(fileName, content)
                    End If

                    Return True
                Catch ex As Exception
                    Return False
                End Try
            End Function

            Public Class StateCheckResult

                Public Property fileExist As Boolean = False
                Public Property fileIntact As Boolean = False

            End Class

            Public Class StateIndexEngine

                Inherits BaseFileDB(Of StateInformation)

                Private _fileCorrupted As Boolean = False
                Private _mismatchedSignature As Boolean = False
                Private _notSynchronized As Boolean = False
                Private _walletIDOwner As String = ""

                Public ReadOnly Property fileExist As Boolean
                    Get
                        Return IO.File.Exists(fileName)
                    End Get
                End Property
                Public ReadOnly Property fileCorrupted As Boolean
                    Get
                        Return _fileCorrupted
                    End Get
                End Property
                Public ReadOnly Property fileNotSynchronized() As Boolean
                    Get
                        Return _notSynchronized
                    End Get
                End Property
                Public ReadOnly Property mismatchedSignature As Boolean
                    Get
                        Return _mismatchedSignature
                    End Get
                End Property
                Public ReadOnly Property fileWorkIndexCorrect() As Boolean
                    Get
                        Return (Not _fileCorrupted And Not _notSynchronized And Not _mismatchedSignature)
                    End Get
                End Property
                Public ReadOnly Property problemDescription() As String
                    Get
                        If _fileCorrupted Then
                            Return "File Work.db corrupted"
                        ElseIf _notSynchronized Then
                            Return "File Work.db is refer to another chain"
                        ElseIf _mismatchedSignature Then
                            Return "File Work.db mismatched signature"
                        Else
                            Return ""
                        End If
                    End Get
                End Property

                Private Function checkSignature() As Boolean
                    Try
                        Return verifySignature(data.hashData, _walletIDOwner, data.signature)
                    Catch ex As Exception
                        Return False
                    End Try
                End Function

                Public Sub init(ByVal networkReferement As Common.NetworkChain, ByVal walletIDOwner As String)
                    Try
                        If fileExist() Then
                            _fileCorrupted = Not read()
                        Else
                            _fileCorrupted = True
                        End If
                        If Not _fileCorrupted Then
                            _walletIDOwner = walletIDOwner
                            _notSynchronized = (data.chainName.CompareTo(networkReferement.chainName) = 0) And (data.networkName.CompareTo(networkReferement.networkName) = 0)
                        End If
                        If Not _fileCorrupted And Not _notSynchronized Then
                            _mismatchedSignature = Not checkSignature()
                        End If
                    Catch ex As Exception
                    End Try
                End Sub

            End Class


            Public Property generalState As CHCProtocolLibrary.AreaCommon.Models.Administration.EnumDataPosition = CHCProtocolLibrary.AreaCommon.Models.Administration.EnumDataPosition.notChecked
            Public Property stateIndex As New StateIndexEngine
            Public Property log As CHCServerSupportLibrary.Support.LogEngine
            Public Property serviceState As CHCProtocolLibrary.AreaCommon.Models.Administration.ServiceStateResponse


            Public ReadOnly Property problemDescription As String
                Get
                    If Not stateIndex.fileWorkIndexCorrect Then
                        Return stateIndex.problemDescription
                    Else
                        Return ""
                    End If
                End Get
            End Property


            Public Function init(ByVal networkReferement As Common.NetworkChain, ByRef paths As AreaSystem.VirtualPathEngine, ByRef walletIDOwner As String) As Boolean
                Try
                    log.track("StateEngine.init", "Begin")

                    serviceState.currentAction.setAction("0x0004", "VerifyData - State")

                    stateIndex.fileName = IO.Path.Combine(paths.workData.state, "State.Index")

                    If serviceState.requestCancelCurrentRunCommand Then Return False

                    stateIndex.init(networkReferement, walletIDOwner)

                    log.track("StateEngine.init", "StateEngine.init complete")

                    If stateIndex.fileCorrupted Or stateIndex.mismatchedSignature Then
                        If stateIndex.fileExist Then
                            generalState = CHCProtocolLibrary.AreaCommon.Models.Administration.EnumDataPosition.checkControlNotPassed
                        Else
                            generalState = CHCProtocolLibrary.AreaCommon.Models.Administration.EnumDataPosition.missing
                        End If

                    ElseIf stateIndex.fileExist Then
                        generalState = CHCProtocolLibrary.AreaCommon.Models.Administration.EnumDataPosition.checkControlPassed
                    Else
                        If (CHCCommonLibrary.AreaEngine.FileManagement.getMD5FromFile(IO.Path.Combine(paths.workData.state, "State.Index")) = stateIndex.data.fileStateMD5) Then
                            generalState = CHCProtocolLibrary.AreaCommon.Models.Administration.EnumDataPosition.checkControlNotPassed
                        Else
                            generalState = CHCProtocolLibrary.AreaCommon.Models.Administration.EnumDataPosition.checkControlPassed
                        End If
                    End If

                    Return True
                Catch ex As Exception
                    serviceState.currentAction.setError(Err.Number, ex.Message)

                    log.track("StateEngine.init", "Error:" & ex.Message, "fatal")

                    Return False
                End Try
            End Function

        End Class

    End Namespace

End Namespace