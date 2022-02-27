Option Compare Text
Option Explicit On

Imports CHCModels.AreaModel.Network.Response
Imports CHCCommonLibrary.AreaEngine.Encryption




Namespace AreaCommon.Models.Ledger

    ''' <summary>
    ''' This enum contain the index of a field into string array of a single transaction data
    ''' </summary>
    Public Enum EnumPositionField
        id = 0
        registrationTimeStamp = 1
        [class] = 2
        ordererPublicAddress = 3
        validatorPublicAddress = 4
        orderHash = 5
        consensusHash = 6
        detailInformation = 7
        currentHash = 8
        progressiveHash = 9
    End Enum

    ''' <summary>
    ''' This class contain the summary information of the ledger
    ''' </summary>
    Public Class HeaderLedgerInformationModel

        Public Property identifyLedger As String = ""

        Public Property createLedgerTimeStamp As Double = 0
        Public Property lastUpdateTimeStamp As Double = 0
        Public Property numVolumes As Byte = 0
        Public Property numBlocks As Integer = 0
        Public Property numTransaction As Int64 = 0

        Public Property latestTransaction As String = ""


        ''' <summary>
        ''' This method provide to create a string summary of the member of a class
        ''' </summary>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Public Overrides Function toString() As String
            Dim tmp As String = ""

            tmp += identifyLedger
            tmp += createLedgerTimeStamp.ToString()
            tmp += lastUpdateTimeStamp.ToString()
            tmp += numVolumes.ToString()
            tmp += numBlocks.ToString()
            tmp += numTransaction.ToString()
            tmp += latestTransaction

            Return tmp
        End Function

        ''' <summary>
        ''' This method provide to get hash value from a string of a class
        ''' </summary>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Public Function getHash() As String
            Return HashSHA.generateSHA256(Me.toString())
        End Function

    End Class


    ''' <summary>
    ''' This class contain the chain count information
    ''' </summary>
    Public Class LedgerInformationResponseModel

        Inherits BaseRemoteResponse

        Public Property value As New HeaderLedgerInformationModel

        ''' <summary>
        ''' This method provide to create a string summary of the member of a class
        ''' </summary>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Public Overrides Function toString() As String
            Dim tmp As String = value.toString()

            Return tmp
        End Function

        ''' <summary>
        ''' This method provide to get hash value from a string of a class
        ''' </summary>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Public Function getHash() As String
            Return HashSHA.generateSHA256(Me.toString())
        End Function

    End Class

    ''' <summary>
    ''' This class contain all element relative an a single transaction
    ''' </summary>
    Public Class SingleTransactionLedger

        Public Property pathData As CHCProtocolLibrary.AreaSystem.VirtualPathEngine.LedgerBlockPath

        Public Property id As Integer = 0
        Public Property registrationTimeStamp As Double = 0
        Public Property [type] As String = ""
        Public Property requesterPublicAddress As String = ""
        Public Property approverPublicAddress As String = ""
        Public Property requestHash As String = ""
        Public Property consensusHash As String = ""
        Public Property detailInformation As String = ""
        Public Property currentHash As String = ""
        Public Property progressiveHash As String = ""

        ''' <summary>
        ''' This method provide to fill empty text with --- string
        ''' </summary>
        ''' <param name="value"></param>
        ''' <returns></returns>
        Private Function fillEmptyText(ByVal value As String) As String
            If (value.Trim.Length > 0) Then
                Return value
            Else
                Return "---"
            End If
        End Function

        ''' <summary>
        ''' This method provide to extract and load data from a string 
        ''' </summary>
        ''' <param name="value"></param>
        ''' <returns></returns>
        Public Function loadFromAString(ByVal value As String) As Boolean
            Try
                Dim elements = value.Split("|")

                If (UBound(elements) = EnumPositionField.progressiveHash) Then

                    If IsNumeric(elements(EnumPositionField.id)) Then
                        If Not Integer.TryParse(elements(EnumPositionField.id), id) Then
                            Return False
                        End If
                    Else
                        Return False
                    End If

                    If IsNumeric(elements(EnumPositionField.registrationTimeStamp)) Then
                        If Not Double.TryParse(elements(1), registrationTimeStamp) Then
                            Return False
                        End If
                    Else
                        Return False
                    End If

                    [type] = elements(EnumPositionField.[class])
                    requesterPublicAddress = elements(EnumPositionField.ordererPublicAddress)
                    approverPublicAddress = elements(EnumPositionField.validatorPublicAddress)
                    requestHash = elements(EnumPositionField.orderHash)
                    consensusHash = elements(EnumPositionField.consensusHash)
                    detailInformation = elements(EnumPositionField.detailInformation)
                    currentHash = elements(EnumPositionField.currentHash)
                    progressiveHash = elements(EnumPositionField.progressiveHash)

                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to return a string from a data to class
        ''' </summary>
        ''' <param name="separator"></param>
        ''' <param name="limited"></param>
        ''' <returns></returns>
        Public Function toStringFormatToFile(Optional ByVal separator As String = "|", Optional limited As Boolean = False) As String
            Dim tmp As String = ""

            tmp += id.ToString() & separator
            tmp += registrationTimeStamp.ToString() & separator
            tmp += [type] & separator
            tmp += requesterPublicAddress & separator
            tmp += approverPublicAddress & separator
            tmp += requestHash & separator
            tmp += detailInformation & separator
            tmp += fillEmptyText(consensusHash) & separator

            If Not limited Then
                tmp += currentHash & separator
                tmp += progressiveHash
            End If

            Return tmp
        End Function

        ''' <summary>
        ''' This method provide to return a limited string file from a data in memory
        ''' </summary>
        ''' <returns></returns>
        Public Overrides Function toString() As String
            Return toStringFormatToFile("", True)
        End Function

        ''' <summary>
        ''' This method provide to create an hash from a limited element 
        ''' </summary>
        ''' <returns></returns>
        Public Function getHash() As String
            Return HashSHA.generateSHA256(Me.toString())
        End Function

    End Class


End Namespace