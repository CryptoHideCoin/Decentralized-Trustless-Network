Option Explicit On
Option Compare Text

Imports CHCCommonLibrary.Support
Imports CHCCommonLibrary.AreaEngine.Encryption
Imports CHCBasicCryptographyLibrary.AreaEngine.Encryption.Base58Signature
Imports CHCCommonLibrary.AreaEngine.DataFileManagement
Imports CHCProtocolLibrary







Namespace AreaEngine.Ledger


    Namespace NodeList

        Public Class NodeChainTrustedInformation

            Public Class NodeListTrustedInformation

                Public Class DeliveryNodeInformation

                    Public Property walletID As String = ""
                    Public Property addressIP As String = ""
                    Public Property errorConnection As String = ""

                End Class

                Public Class SingleNodeInformation

                    Public Property walletID As String = ""
                    Public Property addressIP As String = ""
                    Public Property warrantyCoinOffered As Decimal = 0
                    Public Property dayConnectionDuration As Integer = 0
                    Public Property hiSpeedMode As Boolean = False
                    Public Property ledgerTransactionID As String = ""

                    Public Property dateLastConnection As New DateTime
                    Public Property errorConnection As String = ""

                    Public Overrides Function toString() As String
                        Dim tmp As String = ""

                        tmp += walletID
                        tmp += warrantyCoinOffered.ToString()
                        tmp += dayConnectionDuration.ToString()

                        If hiSpeedMode Then
                            tmp += "1"
                        Else
                            tmp += "0"
                        End If

                        tmp += ledgerTransactionID

                        Return tmp
                    End Function

                    Public Function getHash() As String
                        Return HashSHA.generateSHA256(Me.toString())
                    End Function

                End Class

                Public Property networkName As String = ""
                Public Property chainName As String = ""
                Public Property chainLedgerCloseBlock As String = ""

                Public Property nodeList As New List(Of singleNodeInformation)

                Public Function extractDeliveryList() As List(Of DeliveryNodeInformation)
                    Dim result As New List(Of DeliveryNodeInformation)
                    Dim itemLight As DeliveryNodeInformation

                    For Each item In nodeList
                        itemLight = New DeliveryNodeInformation

                        itemLight.addressIP = item.addressIP
                        itemLight.errorConnection = item.errorConnection
                        itemLight.walletID = item.walletID

                        result.Add(itemLight)
                    Next

                    Return result
                End Function

                Public Overrides Function toString() As String
                    Dim tmp As String = ""

                    tmp += networkName
                    tmp += chainName
                    tmp += chainLedgerCloseBlock

                    For Each item In nodeList
                        tmp += item.toString()
                    Next

                    Return tmp
                End Function

                Public Function getHash() As String
                    Return HashSHA.generateSHA256(Me.toString())
                End Function

            End Class

            Public Property networkName As String = ""
            Public Property walletIDTrasmitter As String = ""
            Public Property chainList As New List(Of NodeListTrustedInformation)

            Public Overrides Function toString() As String
                Dim tmp As String = ""

                tmp += networkName
                tmp += walletIDTrasmitter

                For Each item In chainList
                    tmp += item.toString()
                Next

                Return tmp
            End Function

            Public Function getHash() As String
                Return HashSHA.generateSHA256(Me.toString())
            End Function

            Public Property hashMessage As String = ""
            Public Property signatureTrasmitter As String = ""

            Public Property signatureChecker As String = ""

        End Class

        Public Class NodeListTrustedEngine

            Public Class NodeChainTrustedEngine

                Inherits BaseFileDB(Of NodeChainTrustedInformation)

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
                Public ReadOnly Property problemDescription() As String
                    Get
                        If _fileCorrupted Then
                            Return "File NodeChain.Trusted corrupted"
                        ElseIf _notSynchronized Then
                            Return "File NodeChain.Trusted is refer to another chain"
                        ElseIf _mismatchedSignature Then
                            Return "File NodeChain.Trusted mismatched signature"
                        Else
                            Return ""
                        End If
                    End Get
                End Property

                Private Function checkSignature() As Boolean
                    Try
                        Return verifySignature(data.hashMessage, data.walletIDTrasmitter, data.signatureTrasmitter) And verifySignature(data.hashMessage, _walletIDOwner, data.signatureChecker)
                    Catch ex As Exception
                        Return False
                    End Try
                End Function
                Private Function checkChain(ByRef networkReferement As Common.NetworkChain) As Boolean
                    Try
                        For Each chain In data.chainList
                            If (networkReferement.chainName.CompareTo(chain.chainName) = 0) Then
                                Return True
                            End If
                        Next
                        Return False
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
                            _notSynchronized = (data.networkName.CompareTo(networkReferement.networkName) = 0) And (checkChain(networkReferement))
                        End If
                        If Not _fileCorrupted And Not _notSynchronized Then
                            _mismatchedSignature = Not checkSignature()
                        End If
                    Catch ex As Exception
                    End Try
                End Sub

            End Class


            Public Property generalState As CHCProtocolLibrary.AreaCommon.Models.Administration.EnumDataPosition = CHCProtocolLibrary.AreaCommon.Models.Administration.EnumDataPosition.notChecked
            Public Property nodeChainEngine As New NodeChainTrustedEngine
            Public Property log As LogEngine
            Public Property serviceState As CHCProtocolLibrary.AreaCommon.Models.Administration.ServiceStateResponse

            Public ReadOnly Property problemDescription As String
                Get
                    If nodeChainEngine.fileCorrupted Or nodeChainEngine.fileNotSynchronized Or nodeChainEngine.mismatchedSignature Then
                        Return nodeChainEngine.problemDescription
                    Else
                        Return ""
                    End If
                End Get
            End Property


            Public Function init(ByRef networkReferement As Common.NetworkChain, ByRef paths As AreaSystem.VirtualPathEngine, ByRef walletIDOwner As String) As Boolean
                Try
                    log.track("NodesEngine.init", "Begin")

                    serviceState.currentAction.setAction("0x0005", "VerifyData - Nodelist")

                    nodeChainEngine.fileName = IO.Path.Combine(paths.workData.state.db, "NodeChain.Trusted")

                    If serviceState.requestCancelCurrentRunCommand Then Return False

                    If nodeChainEngine.fileCorrupted Or nodeChainEngine.mismatchedSignature Then

                        generalState = AreaCommon.Models.Administration.EnumDataPosition.checkControlNotPassed
                    Else
                        If nodeChainEngine.fileExist() Then
                            generalState = AreaCommon.Models.Administration.EnumDataPosition.checkControlPassed
                        Else
                            generalState = AreaCommon.Models.Administration.EnumDataPosition.missing
                        End If
                    End If

                    log.track("NodesEngine.init", "NodesEngine.init complete")

                    Return True
                Catch ex As Exception
                    serviceState.currentAction.setError(Err.Number, ex.Message)

                    log.track("NodesEngine.init", "Error:" & ex.Message, "fatal")

                    Return False
                End Try
            End Function

        End Class


        Public Class NetGetLocalResponse

            Inherits AreaTransactionChain.Models.NetModel

            Public Enum EnumResponseGetFile

                notTest
                fileNotFound
                signatureFail
                fileReadCorrectly

            End Enum

            Public response As EnumResponseGetFile = EnumResponseGetFile.notTest

        End Class

        Public Class NetDownloadResponse

            Inherits AreaTransactionChain.Models.NetModel

            Public Enum EnumResponseDownload

                notDo
                downloadFailed
                signatureFail
                fileDownloadCorrectly

            End Enum

            Public response As EnumResponseDownload = EnumResponseDownload.notDo

        End Class


        'Public Function getLocal(ByVal path As String) As NetGetLocalResponse

        '    ' è necessario recuperare il file nodemap.trusted

        '    ' il percorso da dove cercarlo è .\Data\Work\Chain-"x"\State\

        '    ' il percorso in ogni caso è definito nel VirtualPath del CHCProtocolLibrary

        '    ' Se il file è presente bisogna controllare che il file sia originale 
        '    ' (che corrisponda il checksum e che la firma apposta sia corretta)

        '    ' Questa funzione può restituire:

        '    ' - Tutto a posto, file letto, firma consona al file acquisito

        '    ' - Il file indicato non corrisponde alla firma

        '    ' - Il file non è esistente

        '    Return New NetGetLocalResponse

        'End Function

        'Public Function createNew() As AreaTransactionChain.Models.NetModel
        '    Return New AreaTransactionChain.Models.NetModel
        'End Function

        'Public Function duplicateMain() As AreaTransactionChain.Models.NetModel

        'End Function

        'Public Function downloadNodeList(ByVal addressIP As String) As NetDownloadResponse

        'End Function

        'Public Function testNodeList(ByRef nodeList As AreaTransactionChain.Models.NetModel) As Boolean

        'End Function

        'Public Function updateNodeList(ByRef nodeList As AreaTransactionChain.Models.NetModel) As Boolean

        'End Function




    End Namespace

End Namespace