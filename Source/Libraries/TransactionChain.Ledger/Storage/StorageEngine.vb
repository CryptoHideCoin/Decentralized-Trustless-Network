Option Explicit On
Option Compare Text

Imports CHCCommonLibrary.AreaEngine.DataFileManagement
Imports CHCBasicCryptographyLibrary.AreaEngine.Encryption.Base58Signature
Imports CHCCommonLibrary.AreaEngine.Encryption
Imports CHCProtocolLibrary







Namespace AreaEngine.Ledger

    Namespace Storage

        Public Class VolumesIndexInformation

            Public Class VolumeInformation

                Public Property year As String = ""
                Public Property fileName As String = ""
                Public Property localFileName As Boolean = False
                Public Property pathCompressed As String = ""
                Public Property valueMD5Compressed As String = ""
                Public Property valueMD5Database As String = ""
                Public Property hashData As String = ""

                Public Overrides Function toString() As String
                    Dim tmp As String = ""

                    tmp += year
                    tmp += fileName
                    tmp += pathCompressed
                    tmp += valueMD5Compressed
                    tmp += valueMD5Database

                    If localFileName Then tmp += "1" Else tmp += "0"

                    Return tmp
                End Function

                Public Function getHash() As String
                    Return HashSHA.generateSHA256(Me.toString())
                End Function

            End Class

            Public Property networkName As String = ""
            Public Property chainName As String = ""
            Public Property dateLast As New DateTime
            Public Property volumes As New List(Of VolumeInformation)
            Public Property hashData As String = ""
            Public Property signature As String = ""

            Public Overrides Function toString() As String
                Dim tmp As String = ""

                tmp += networkName
                tmp += chainName
                tmp += dateLast.ToString

                For Each item In volumes
                    tmp += item.getHash()
                Next

                Return tmp
            End Function

            Public Function getHash() As String
                Return HashSHA.generateSHA256(Me.toString())
            End Function

        End Class

        Public Class StorageEngine

            Public Class VolumeDataExt

                Inherits VolumesIndexInformation.VolumeInformation

                Public Property compressedExist As Boolean = False
                Public Property databaseExist As Boolean = False

                Public Property completeFileNameCompressed As String = ""
                Public Property completeFileNameDB As String = ""

            End Class

            Public Class volumeCheckResult

                Public Property remoteZIPExist As Boolean = False
                Public Property fileZIPExist As Boolean = False
                Public Property fileDBExist As Boolean = False
                Public Property fileZIPIntact As Boolean = False
                Public Property fileDBIntact As Boolean = False

            End Class

            Public Class volumesIndexEngine

                Inherits BaseFileDB(Of Storage.VolumesIndexInformation)

                Private _fileCorrupted As Boolean = False
                Private _mismatchedSignature As Boolean = False
                Private _notSynchronized As Boolean = False
                Private _walletIDOwner As String = ""

                Private Function checkSignature() As Boolean
                    Try
                        Return verifySignature(data.hashData, _walletIDOwner, data.signature)
                    Catch ex As Exception
                        Return False
                    End Try
                End Function

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
                Public ReadOnly Property fileVolumeIndexCorrect() As Boolean
                    Get
                        Return (Not _fileCorrupted And Not _notSynchronized And Not _mismatchedSignature)
                    End Get
                End Property
                Public ReadOnly Property problemDescription() As String
                    Get
                        If _fileCorrupted Then
                            Return "File Volumes.Index corrupted"
                        ElseIf _notSynchronized Then
                            Return "File Volumes.Index is refer to another chain"
                        ElseIf _mismatchedSignature Then
                            Return "File Volumes.Index mismatched signature"
                        Else
                            Return ""
                        End If
                    End Get
                End Property

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

            Private Class volumesFileEngine

                Private _problemDescription As String = ""

                Public volumes As New Dictionary(Of String, StorageEngine.VolumeDataExt)
                Public Property generalState As CHCProtocolLibrary.AreaCommon.Models.Administration.EnumDataPosition = CHCProtocolLibrary.AreaCommon.Models.Administration.EnumDataPosition.notChecked
                Public ReadOnly Property problemDescription() As String
                    Get
                        Return _problemDescription
                    End Get
                End Property

                Private Function verifyVolume(ByVal pathStorage As String, ByVal pathTemporally As String, ByVal item As StorageEngine.VolumeDataExt) As volumeCheckResult
                    Try
                        Dim result As New volumeCheckResult

                        Dim fileName As String = "", md5Value As String = ""

                        item.completeFileNameCompressed = IO.Path.Combine(pathStorage, item.fileName & ".zip")
                        item.completeFileNameDB = IO.Path.Combine(pathStorage, item.fileName & ".db")

                        If item.localFileName Then
                            fileName = item.completeFileNameCompressed

                            result.fileZIPExist = IO.File.Exists(fileName)
                        Else

                            fileName = IO.Path.ChangeExtension(item.fileName, "zip")

                            Using client As New Net.WebClient()
                                client.DownloadFile(item.completeFileNameCompressed, IO.Path.Combine(pathTemporally, fileName))
                            End Using

                            result.remoteZIPExist = True
                            result.fileZIPExist = True
                        End If

                        md5Value = CHCCommonLibrary.AreaEngine.FileManagement.getMD5FromFile(fileName)
                        result.fileZIPIntact = (item.valueMD5Compressed <> md5Value)

                        result.fileDBExist = IO.File.Exists(item.completeFileNameDB)

                        If result.fileDBExist Then
                            md5Value = CHCCommonLibrary.AreaEngine.FileManagement.getMD5FromFile(item.completeFileNameDB)

                            result.fileDBIntact = (item.valueMD5Database <> md5Value)
                        End If

                        If Not item.localFileName Then
                            IO.File.Delete(IO.Path.Combine(pathTemporally, fileName))
                        End If

                        volumes.Add(item.fileName, item)

                        Return result
                    Catch ex As Exception
                        Return New volumeCheckResult
                    End Try
                End Function

                Public Sub init(ByVal pathStorage As String, ByVal pathTemporally As String, ByVal volumesIndex As volumesIndexEngine)
                    Try
                        Dim result As New volumeCheckResult

                        _problemDescription = ""

                        For Each item In volumesIndex.data.volumes
                            result = verifyVolume(pathStorage, pathTemporally, item)

                            If Not result.fileZIPExist Then
                                _problemDescription = "File " & item.fileName & " not exist a zip release."
                            ElseIf Not result.fileZIPIntact Then
                                _problemDescription = "File " & item.fileName & " not have MD5 intact"
                            ElseIf Not result.fileDBExist Then
                                _problemDescription = "File " & item.fileName & " not exist a db release"
                            ElseIf Not result.fileDBExist Then
                                _problemDescription = "File " & item.fileName & " not have MD5 intact"
                            End If

                            If Not result.fileDBIntact Or Not result.fileZIPIntact Or Not result.fileDBExist Or Not result.fileZIPExist Then
                                generalState = CHCProtocolLibrary.AreaCommon.Models.Administration.EnumDataPosition.checkControlNotPassed

                                Return
                            End If
                        Next

                        generalState = CHCProtocolLibrary.AreaCommon.Models.Administration.EnumDataPosition.checkControlPassed
                    Catch ex As Exception
                    End Try
                End Sub

            End Class

            Private _volumesEngine As New volumesFileEngine


            Public Property generalState As CHCProtocolLibrary.AreaCommon.Models.Administration.EnumDataPosition = CHCProtocolLibrary.AreaCommon.Models.Administration.EnumDataPosition.notChecked
            Public Property volumesIndex As New volumesIndexEngine
            Public Property volumesData As New Dictionary(Of String, VolumeDataExt)
            Public Property log As CHCServerSupportLibrary.Support.LogEngine
            Public Property serviceState As CHCProtocolLibrary.AreaCommon.Models.Administration.ServiceStateResponse

            Public ReadOnly Property problemDescription As String
                Get
                    If Not volumesIndex.fileVolumeIndexCorrect Then
                        Return volumesIndex.problemDescription
                    ElseIf (_volumesEngine.generalState = CHCProtocolLibrary.AreaCommon.Models.Administration.EnumDataPosition.checkControlNotPassed) Then
                        Return _volumesEngine.problemDescription
                    Else
                        Return ""
                    End If
                End Get
            End Property

            Public Function init(ByRef networkReferement As Common.NetworkChain, ByRef paths As AreaSystem.VirtualPathEngine, ByRef walletIDOwner As String) As Boolean
                Try
                    log.track("StorageEngine.init", "Begin")

                    serviceState.currentAction.setAction("0x0001", "VerifyData - Storage - Volumes")

                    volumesIndex.fileName = IO.Path.Combine(paths.storage, "Volumes.Index")

                    If serviceState.requestCancelCurrentRunCommand Then Return False

                    volumesIndex.init(networkReferement, walletIDOwner)

                    log.track("StorageEngine.init", "volumesIndex.init complete")

                    If Not volumesIndex.fileVolumeIndexCorrect Then
                        log.track("StorageEngine.init", "volumesIndex.init fileVolumeIndex not correct")

                        If volumesIndex.fileExist() Then
                            generalState = CHCProtocolLibrary.AreaCommon.Models.Administration.EnumDataPosition.checkControlNotPassed
                        Else
                            generalState = CHCProtocolLibrary.AreaCommon.Models.Administration.EnumDataPosition.missing
                        End If
                    Else
                        log.track("StorageEngine.init", "volumesIndex.init fileVolumeIndex exist")

                        If serviceState.requestCancelCurrentRunCommand Then Return False

                        _volumesEngine.init(paths.storage, paths.workData.temporally, volumesIndex)

                        log.track("StorageEngine.init", "Execute volumesEngine.init")

                        If _volumesEngine.generalState = CHCProtocolLibrary.AreaCommon.Models.Administration.EnumDataPosition.checkControlPassed Then
                            volumesData = _volumesEngine.volumes
                        End If

                        generalState = _volumesEngine.generalState
                    End If

                    Return True
                Catch ex As Exception
                    serviceState.currentAction.setError(Err.Number, ex.Message)

                    log.track("StorageEngine.init", "Error:" & ex.Message, "fatal")

                    Return False
                End Try
            End Function

        End Class

    End Namespace

End Namespace
