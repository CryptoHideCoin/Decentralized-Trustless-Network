Option Explicit On
Option Compare Text

Imports CHCCommonLibrary.AreaEngine.DataFileManagement
Imports CHCBasicCryptographyLibrary.AreaEngine.Encryption.Base58Signature
Imports CHCCommonLibrary.AreaEngine.Encryption
Imports CHCProtocolLibrary




Namespace AreaEngine.Ledger

    Namespace State

        Public Enum enumCheckResult

            notDefined
            checkControlPassed
            checkControlNotPassed

        End Enum

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


            Public Property generalState As enumCheckResult = enumCheckResult.notDefined
            Public Property stateIndex As New StateIndexEngine

            Public ReadOnly Property problemDescription As String
                Get
                    If Not stateIndex.fileWorkIndexCorrect Then
                        Return stateIndex.problemDescription
                    Else
                        Return ""
                    End If
                End Get
            End Property


            Public Sub init(ByVal networkReferement As Common.NetworkChain, ByRef paths As AreaSystem.VirtualPathEngine, ByRef walletIDOwner As String)
                stateIndex.fileName = IO.Path.Combine(paths.workData.state, "State.Index")

                stateIndex.init(networkReferement, walletIDOwner)

                If stateIndex.fileCorrupted Or stateIndex.mismatchedSignature Then
                    generalState = enumCheckResult.checkControlNotPassed
                ElseIf stateIndex.fileExist Then
                    generalState = enumCheckResult.checkControlPassed
                Else
                    If (CHCCommonLibrary.AreaEngine.FileManagement.getMD5FromFile(IO.Path.Combine(paths.workData.state, "State.Index")) = stateIndex.data.fileStateMD5) Then
                        generalState = enumCheckResult.checkControlPassed
                    Else
                        generalState = enumCheckResult.checkControlPassed
                    End If
                End If
            End Sub

        End Class

    End Namespace

End Namespace