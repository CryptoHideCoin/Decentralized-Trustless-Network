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
        Private Function createZipFile() As Boolean
            Try
                log.track("LedgerSupportEngine.createZipFile", "Begin")

                Dim completeZipFileName As IO.FileStream = System.IO.File.Create(IO.Path.Combine(mainPath.path, "Block.Compact"))
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

    End Class

End Namespace