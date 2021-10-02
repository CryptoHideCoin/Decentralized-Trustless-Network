Option Explicit On
Option Compare Text

Imports CHCCommonLibrary.Support
Imports CHCCommonLibrary.AreaEngine.DataFileManagement.XML
Imports CHCBasicCryptographyLibrary.AreaEngine.Encryption.Base58Signature
Imports CHCCommonLibrary.AreaEngine.Encryption
Imports CHCProtocolLibrary







Namespace AreaEngine.Ledger

    Namespace CurrentVolume

        Public Class CurrentIndexInformation

            Public Class BlockInformation

                Public Property blockName As String = ""
                Public Property MD5Value As String = ""
                Public Property MD5Zip As String = ""
                Public Property MD5ZipRequest As String = ""
                Public Property MD5ZipConsensus As String = ""
                Public Property hashData As String = ""

                Public Overrides Function toString() As String
                    Dim tmp As String = ""

                    tmp += blockName
                    tmp += MD5Value

                    Return tmp
                End Function

                Public Function getHash() As String
                    Return HashSHA.generateSHA256(Me.toString())
                End Function

            End Class

            Public Property networkName As String = ""
            Public Property chainName As String = ""
            Public Property dateLast As New DateTime
            Public Property blocks As New List(Of BlockInformation)
            Public Property hashData As String = ""
            Public Property signature As String = ""

            Public Overrides Function toString() As String
                Dim tmp As String = ""

                tmp += networkName
                tmp += chainName
                tmp += dateLast.ToString

                For Each item In blocks
                    tmp += item.getHash()
                Next

                Return tmp
            End Function

            Public Function getHash() As String
                Return HashSHA.generateSHA256(Me.toString())
            End Function

        End Class

        Public Class CurrentVolumeEngine

            Public Class BlockCheckResult

                Public Property fileBlockExist As Boolean = False
                Public Property fileBlockZipExist As Boolean = False
                Public Property fileBlockIntact As Boolean = False
                Public Property fileBlockZipIntact As Boolean = False

                Public Property fileRequestZipExist As Boolean = False
                Public Property fileRequestZipIntact As Boolean = False
                Public Property fileConsensusZipExist As Boolean = False
                Public Property fileConsensusZipIntact As Boolean = False
                Public Property fileRequestSingleExist As Boolean = False
                Public Property fileRequestSingleIntact As Boolean = False
                Public Property fileConsensusSingleExist As Boolean = False
                Public Property fileConsensusSingleIntact As Boolean = False

            End Class

            Public Class CurrentVolumesIndexEngine

                Inherits BaseFile(Of CurrentVolume.CurrentIndexInformation)

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
                Public ReadOnly Property filePreviousVolumesIndexCorrect() As Boolean
                    Get
                        Return (Not _fileCorrupted And Not _notSynchronized And Not _mismatchedSignature)
                    End Get
                End Property
                Public ReadOnly Property problemDescription() As String
                    Get
                        If _fileCorrupted Then
                            Return "File PreviousVolume.Index corrupted"
                        ElseIf _notSynchronized Then
                            Return "File PreviousVolume.Index is refer to another chain"
                        ElseIf _mismatchedSignature Then
                            Return "File PreviousVolume.Index mismatched signature"
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

                Public Sub init(ByRef networkReferement As Common.NetworkChain, ByVal walletIDOwner As String)
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

            Private Class RequestAtom
                Public requestHash As String = ""
            End Class

            Private Class CurrentVolumeFileEngine

                Inherits BaseFile(Of RequestAtom)



                Private _problemDescription As String = ""

                Public Property generalState As CHCProtocolLibrary.AreaCommon.Models.Administration.EnumDataPosition = CHCProtocolLibrary.AreaCommon.Models.Administration.EnumDataPosition.notChecked
                Public ReadOnly Property problemDescription As String
                    Get
                        Return _problemDescription
                    End Get
                End Property


                Private Function verifySingleData(ByVal pathCurrentVolume As String, ByVal completeFileName As String, ByVal item As CurrentVolume.CurrentIndexInformation.BlockInformation) As Boolean
                    Try

                        Dim blockContent As String = My.Computer.FileSystem.ReadAllText(completeFileName)
                        Dim transactions() = blockContent.Split(vbNewLine)
                        Dim fields()
                        Dim requestHash As String = ""
                        Dim basePathRequest As String = IO.Path.Combine(pathCurrentVolume, "Requests")
                        Dim basePathConsensus As String = IO.Path.Combine(pathCurrentVolume, "Consensus")

                        For Each transaction In transactions
                            fields = transaction.Split("|")

                            If (UBound(fields) > 6) Then
                                requestHash = fields(5)

                                If Not IO.File.Exists(IO.Path.Combine(basePathRequest, requestHash & ".request")) Then
                                    _problemDescription = "The request file " & requestHash & " is missing"

                                    Return False
                                Else
                                    Me.fileName = IO.Path.Combine(basePathRequest, requestHash & ".request")

                                    If Me.read() Then
                                        If (Me.data.requestHash.CompareTo(requestHash) <> 0) Then
                                            _problemDescription = "The file " & requestHash & ".request is corrupt"

                                            Return False
                                        End If
                                    End If
                                End If

                                If Not IO.File.Exists(IO.Path.Combine(basePathConsensus, requestHash & ".consensus")) Then
                                    _problemDescription = "The consensus file " & requestHash & " is missing"

                                    Return False
                                Else
                                    Me.fileName = IO.Path.Combine(basePathRequest, requestHash & ".consensus")

                                    If Me.read() Then
                                        If (Me.data.requestHash.CompareTo(requestHash) <> 0) Then
                                            _problemDescription = "The consensus file " & requestHash & ".consensus is corrupt"

                                            Return False
                                        End If
                                    End If
                                End If
                            End If
                        Next

                        Return True
                    Catch ex As Exception
                        Return False
                    End Try
                End Function

                Private Function verifyBlock(ByVal pathCurrentVolume As String, ByVal item As CurrentVolume.CurrentIndexInformation.BlockInformation) As BlockCheckResult
                    Try
                        Dim result As New BlockCheckResult

                        Dim fileName As String = "", fileLedger As String, md5Value As String = ""

                        fileName = IO.Path.Combine(pathCurrentVolume, "Ledger", item.blockName & ".block")
                        fileLedger = fileName

                        result.fileBlockExist = IO.File.Exists(fileName)
                        If result.fileBlockExist Then
                            md5Value = CHCCommonLibrary.AreaEngine.FileManagement.getMD5FromFile(fileName)

                            result.fileBlockIntact = (md5Value.CompareTo(item.MD5Value) = 0)

                            If Not result.fileBlockIntact Then
                                _problemDescription = "The file " & item.blockName & ".block is incorrect"

                                Return result
                            End If
                        Else
                            _problemDescription = "The file " & item.blockName & ".block is missing"

                            Return result
                        End If

                        fileName = IO.Path.Combine(pathCurrentVolume, "Ledger", item.blockName & ".zip")

                        result.fileBlockZipExist = IO.File.Exists(fileName)
                        If result.fileBlockZipExist Then
                            md5Value = CHCCommonLibrary.AreaEngine.FileManagement.getMD5FromFile(fileName)

                            result.fileBlockZipIntact = (md5Value.CompareTo(item.MD5Zip) = 0)

                            If Not result.fileBlockZipIntact Then
                                _problemDescription = "The file " & item.blockName & ".zip is incorrect"

                                Return result
                            End If
                        Else
                            _problemDescription = "The file " & item.blockName & ".zip is missing"

                            Return result
                        End If

                        fileName = IO.Path.Combine(pathCurrentVolume, "Requests", item.blockName & ".zip")

                        result.fileRequestZipExist = IO.File.Exists(fileName)
                        If result.fileRequestZipExist Then
                            md5Value = CHCCommonLibrary.AreaEngine.FileManagement.getMD5FromFile(fileName)

                            result.fileRequestZipIntact = (md5Value.CompareTo(item.MD5ZipRequest) = 0)

                            If Not result.fileRequestZipIntact Then
                                _problemDescription = "The file request collection " & item.blockName & ".zip is incorrect"

                                Return result
                            End If
                        Else
                            _problemDescription = "The file request collection " & item.blockName & ".zip is missing"

                            Return result
                        End If

                        fileName = IO.Path.Combine(pathCurrentVolume, "Consensus", item.blockName & ".zip")

                        result.fileConsensusZipExist = IO.File.Exists(fileName)
                        If result.fileConsensusZipExist Then
                            md5Value = CHCCommonLibrary.AreaEngine.FileManagement.getMD5FromFile(fileName)

                            result.fileConsensusZipIntact = (md5Value.CompareTo(item.MD5ZipConsensus))

                            If Not result.fileConsensusZipIntact Then
                                _problemDescription = "The file consensus collection " & item.blockName & ".zip is incorrect"

                                Return result
                            End If
                        Else
                            _problemDescription = "The file consensus collection " & item.blockName & ".zip is missing"

                            Return result
                        End If

                        If verifySingleData(pathCurrentVolume, fileLedger, item) Then
                            result.fileRequestSingleExist = True
                            result.fileRequestSingleIntact = True
                        End If

                        Return result
                    Catch ex As Exception
                        Return New BlockCheckResult
                    End Try
                End Function

                Public Sub init(ByVal pathCurrentVolume As String, ByVal currentVolumeIndex As CurrentVolumesIndexEngine)
                    Try
                        Dim result As New BlockCheckResult

                        For Each item In currentVolumeIndex.data.blocks
                            result = verifyBlock(pathCurrentVolume, item)

                            If Not result.fileBlockExist Or Not result.fileBlockIntact Then
                                generalState = CHCProtocolLibrary.AreaCommon.Models.Administration.EnumDataPosition.checkControlNotPassed

                                Return
                            End If
                        Next
                    Catch ex As Exception
                    End Try
                End Sub

            End Class


            Private _currentVolumesEngine As New CurrentVolumeFileEngine

            Public Property generalState As CHCProtocolLibrary.AreaCommon.Models.Administration.EnumDataPosition = CHCProtocolLibrary.AreaCommon.Models.Administration.EnumDataPosition.notChecked
            Public Property currentVolumesIndex As New CurrentVolumesIndexEngine
            Public Property log As LogEngine
            Public Property serviceState As CHCProtocolLibrary.AreaCommon.Models.Administration.ServiceStateResponse

            Public ReadOnly Property problemDescription As String
                Get
                    If Not currentVolumesIndex.filePreviousVolumesIndexCorrect Then
                        Return currentVolumesIndex.problemDescription
                    ElseIf (_currentVolumesEngine.generalState = CHCProtocolLibrary.AreaCommon.Models.Administration.EnumDataPosition.checkControlNotPassed) Then
                        Return _currentVolumesEngine.problemDescription
                    Else
                        Return ""
                    End If
                End Get
            End Property

            Public Function init(ByRef networkReferement As Common.NetworkChain, ByRef paths As AreaSystem.VirtualPathEngine, ByRef walletIDOwner As String) As Boolean
                Try
                    log.track("CurrentVolumeEngine.init", "Begin")

                    serviceState.currentAction.setAction("0x0003", "VerifyData - Current - Work")

                    currentVolumesIndex.fileName = IO.Path.Combine(paths.workData.currentVolume.path, "CurrentVolumes.Index")

                    If serviceState.requestCancelCurrentRunCommand Then Return False

                    currentVolumesIndex.init(networkReferement, walletIDOwner)

                    log.track("CurrentVolumeEngine.init", "CurrentVolumeEngine.init complete")

                    If currentVolumesIndex.fileCorrupted Or currentVolumesIndex.mismatchedSignature Then
                        If currentVolumesIndex.fileExist Then
                            generalState = CHCProtocolLibrary.AreaCommon.Models.Administration.EnumDataPosition.checkControlNotPassed
                        Else
                            generalState = CHCProtocolLibrary.AreaCommon.Models.Administration.EnumDataPosition.missing
                        End If
                    Else
                        log.track("CurrentVolumeEngine.init", "CurrentVolumeEngine exist")

                        _currentVolumesEngine.init(paths.workData.previousVolume.path, currentVolumesIndex)

                        generalState = _currentVolumesEngine.generalState
                    End If

                    Return generalState
                Catch ex As Exception
                    serviceState.currentAction.setError(Err.Number, ex.Message)

                    log.track("CurrentVolumeEngine.init", ex.Message, "fatal")

                    Return False
                End Try
            End Function

        End Class

    End Namespace

End Namespace
