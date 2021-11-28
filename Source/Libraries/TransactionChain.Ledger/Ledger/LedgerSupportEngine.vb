Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.DataFileManagement.Json
Imports CHCCommonLibrary.Support
Imports System.IO.Compression






Namespace AreaLedger

    ''' <summary>
    ''' This class contain all method relative of a support of a ledger
    ''' </summary>
    Public Class LedgerSupportEngine

        ''' <summary>
        ''' This class contain all information relative one block
        ''' </summary>
        Public Class HeaderBlock

            Public Property netWorkReferement As String = ""
            Public Property chainReferement As String = ""
            Public Property blockChainIdentity As String = ""
            Public Property blockIdentity As String = ""
            Public Property hashBlock As String = ""
            Public Property fromTimeStamp As Double = 0
            Public Property toTimeStamp As Double = 0

        End Class

        ''' <summary>
        ''' This class contain the zip archive data
        ''' </summary>
        Public Class FileZipArchive

            Public Property fullName As String = ""
            Public Property zipFileName As String = ""

        End Class

        Private Property daoLedger As New AreaCommon.DAO.DAOLedger

        Public Property headerData As New HeaderBlock
        Public Property mainPath As CHCProtocolLibrary.AreaSystem.VirtualPathEngine.LedgerBlockPath
        Public Property log As LogEngine

        ''' <summary>
        ''' This method provide to create header
        ''' </summary>
        ''' <returns></returns>
        Private Function createHeader() As Boolean
            Try
                Dim completeFileName As String = System.IO.Path.Combine(mainPath.path, "Block.Header")

                log.track("LedgerSupportEngine.createHeader", "Begin")

                daoLedger.log = log
                daoLedger.init(mainPath.path)

                headerData.fromTimeStamp = daoLedger.getFromTimeStampWithConnectionPersistent()
                headerData.toTimeStamp = daoLedger.getToTimeStampAndCloseConnection()

                Return IOFast(Of HeaderBlock).save(completeFileName, headerData)
            Catch ex As Exception
                log.track("LedgerSupportEngine.createHeader", ex.Message, "fatal")

                Return False
            Finally
                log.track("LedgerSupportEngine.createHeader", "Complete")
            End Try
        End Function

        ''' <summary>
        ''' This method provide to add folder to zip file
        ''' </summary>
        ''' <param name="folderName"></param>
        ''' <param name="completeZipFileName"></param>
        ''' <returns></returns>
        Private Function addFolderToList(ByVal folderName As String, ByVal intermediatePath As String, ByRef completeZipFileName As IO.FileStream, ByRef items As List(Of FileZipArchive)) As List(Of FileZipArchive)
            Try
                log.track("LedgerSupportEngine.addFolderToList", "Begin")

                Dim dirInfo As New IO.DirectoryInfo(folderName)
                Dim singleItem As FileZipArchive

                Dim fileInformation As IO.FileInfo() = dirInfo.GetFiles()

                For Each item As IO.FileInfo In fileInformation

                    singleItem = New FileZipArchive

                    singleItem.fullName = item.FullName

                    If (intermediatePath.Length > 0) Then
                        singleItem.zipFileName = intermediatePath & "\" & New IO.FileInfo(item.FullName).Name
                    Else
                        singleItem.zipFileName = New IO.FileInfo(item.FullName).Name
                    End If

                    items.Add(singleItem)
                Next

                log.track("LedgerSupportEngine.addFolderToList", "Complete")

                Return items
            Catch ex As Exception
                log.track("LedgerSupportEngine.addFolderToList", ex.Message, "fatal")

                Return New List(Of FileZipArchive)
            End Try
        End Function

        ''' <summary>
        ''' This method provide to add a file into list
        ''' </summary>
        ''' <param name="fullPathFile"></param>
        ''' <param name="fileInZip"></param>
        ''' <param name="items"></param>
        ''' <returns></returns>
        Private Function addFileToList(ByVal fullPathFile As String, ByVal fileInZip As String, ByRef items As List(Of FileZipArchive)) As List(Of FileZipArchive)
            Try
                Dim singleItem As New FileZipArchive

                log.track("LedgerSupportEngine.addFileToList", "Begin")

                singleItem.fullName = fullPathFile
                singleItem.zipFileName = fileInZip

                items.Add(singleItem)

                log.track("LedgerSupportEngine.addFileToList", "Complete")

                Return items
            Catch ex As Exception
                log.track("LedgerSupportEngine.addFileToList", ex.Message, "fatal")

                Return New List(Of FileZipArchive)
            End Try
        End Function

        ''' <summary>
        ''' This method provide to create a zip file
        ''' </summary>
        ''' <returns></returns>
        Private Function createZipFile(Optional ByVal completeFileName As String = "") As Boolean
            Try
                log.track("LedgerSupportEngine.createZipFile", "Begin")

                If (completeFileName.Length = 0) Then
                    completeFileName = IO.Path.Combine(mainPath.path, "Block.Compact")
                End If

                Dim completeZipFileName As IO.FileStream = System.IO.File.Create(completeFileName)
                Dim zipManager As New ZipArchive(completeZipFileName, ZipArchiveMode.Update)
                Dim items As New List(Of FileZipArchive)

                items = addFolderToList(mainPath.bulletines, "Bulletines", completeZipFileName, items)
                items = addFolderToList(mainPath.consensus, "Consensus", completeZipFileName, items)
                items = addFolderToList(mainPath.contents, "Contents", completeZipFileName, items)
                items = addFolderToList(mainPath.requests, "Requests", completeZipFileName, items)

                items = addFileToList(IO.Path.Combine(mainPath.path, "Block.Header"), "Block.Header", items)
                items = addFileToList(IO.Path.Combine(mainPath.path, "BlockData.Ledger"), "BlockData.Ledger", items)

                Using zipArchiveFileZip As New ZipArchive(completeZipFileName, ZipArchiveMode.Update)
                    For Each item As FileZipArchive In items
                        zipArchiveFileZip.CreateEntryFromFile(item.fullName, item.zipFileName)
                    Next
                End Using

                log.track("LedgerSupportEngine.createZipFile", "Complete")

                Return True
            Catch ex As Exception
                log.track("LedgerSupportEngine.createZipFile", ex.Message, "fatal")

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to delete file request
        ''' </summary>
        ''' <param name="mainPath"></param>
        ''' <param name="block"></param>
        ''' <returns></returns>
        Private Function deleteFiles(ByVal mainPath As String, ByVal intermediateFolder As String, ByVal block As String) As Boolean
            Try
                Dim directoryPath As String

                log.track("LedgerSupportEngine.deleteFiles", "Begin")

                directoryPath = System.IO.Path.Combine(mainPath, block)
                directoryPath = System.IO.Path.Combine(directoryPath, intermediateFolder)

                For Each filepath As String In IO.Directory.GetFiles(directoryPath)
                    System.IO.File.Delete(filepath)
                Next

                log.track("LedgerSupportEngine.deleteFiles", "Complete")

                Return True
            Catch ex As Exception
                log.track("LedgerSupportEngine.deleteFiles", ex.Message, "fatal")

                Return False
            End Try
        End Function


        ''' <summary>
        ''' This method provide to initialize the object
        ''' </summary>
        ''' <returns></returns>
        Public Function init() As Boolean
            Try
                Dim proceed As Boolean = True

                log.track("LedgerSupportEngine.init", "Begin")

                If proceed Then
                    proceed = createHeader()
                End If
                If proceed Then
                    proceed = createZipFile()
                End If

                log.track("LedgerSupportEngine.init", "Complete")

                Return proceed
            Catch ex As Exception
                log.track("LedgerSupportEngine.init", ex.Message, "fatal")

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to remove an old request
        ''' </summary>
        ''' <param name="mainPath"></param>
        ''' <param name="blockList"></param>
        ''' <returns></returns>
        Public Function removeOldFiles(ByVal mainPath As String, ByVal intermediatePath As String, ByRef blockList As List(Of String)) As Boolean
            Try
                Dim proceed As Boolean = True

                log.track("LedgerSupportEngine.removeOldFiles", "Begin")

                If proceed Then
                    For Each block In blockList
                        If Not deleteFiles(mainPath, intermediatePath, block) Then
                            Return False
                        End If
                    Next
                End If

                log.track("LedgerSupportEngine.removeOldFiles", "Complete")

                Return proceed
            Catch ex As Exception
                log.track("LedgerSupportEngine.removeOldFiles", ex.Message, "fatal")

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to delete a list of file
        ''' </summary>
        ''' <param name="requestPath"></param>
        ''' <param name="fileList"></param>
        ''' <returns></returns>
        Public Function removeOldTemporallyRequest(ByVal requestPath As String, ByRef fileList As List(Of String)) As Boolean
            Try
                Dim completeFileName As String
                log.track("LedgerSupportEngine.removeOldTemporallyRequest", "Begin")

                For Each singleFile In fileList
                    completeFileName = IO.Path.Combine(requestPath, singleFile)

                    If System.IO.File.Exists(completeFileName) Then
                        System.IO.File.Delete(completeFileName)
                    End If
                Next

                log.track("LedgerSupportEngine.removeOldTemporallyRequest", "Complete")

                Return True
            Catch ex As Exception
                log.track("LedgerSupportEngine.removeOldTemporallyRequest", ex.Message, "fatal")

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to finalize all single block in a list
        ''' </summary>
        ''' <param name="ledgerPath"></param>
        ''' <param name="blockList"></param>
        ''' <returns></returns>
        Public Function finalizeSingleBlock(ByVal ledgerPath As String, ByRef blockList As List(Of String)) As Boolean
            Try
                Dim completeFile As String

                For Each singleBlock In blockList
                    completeFile = System.IO.Path.Combine(ledgerPath, singleBlock)
                    completeFile = System.IO.Path.Combine(completeFile, "Block.Compact")

                    If System.IO.File.Exists(completeFile) Then
                        System.IO.File.Delete(completeFile)
                    End If

                    If Not createZipFile(completeFile) Then
                        Return False
                    End If
                Next

                Return True
            Catch ex As Exception
                log.track("LedgerSupportEngine.finalizeSingleBlock", ex.Message, "fatal")

                Return False
            End Try
        End Function

    End Class

End Namespace