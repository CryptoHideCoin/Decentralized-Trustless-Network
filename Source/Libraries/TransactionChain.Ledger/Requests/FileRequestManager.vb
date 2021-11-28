Option Compare Text
Option Explicit On

Imports System.Data.SQLite







Namespace AreaEngine.Requests

    ''' <summary>
    ''' This class contain a request manager element
    ''' </summary>
    Public Class RequestManager

        ''' <summary>
        ''' This class contain request position
        ''' </summary>
        Public Class RequestData

            Public Enum stateRequest

                undefined
                unknown
                toDownload
                received
                trashed
                rejected
                toVerify
                accepted
                stored

            End Enum

            Public Property acquire As Double = 0
            Public Property hash As String = ""
            Public Property [type] As String = ""
            Public Property state As stateRequest = stateRequest.undefined
            Public Property block As String = ""

        End Class


        Private _DAORequest As New AreaCommon.DAO.DAORequest


        Public Property logIstance As CHCCommonLibrary.Support.LogEngine


        ''' <summary>
        ''' This method provide to initialize the component
        ''' </summary>
        ''' <returns></returns>
        Public Function init(ByVal basePath As String) As Boolean
            Try
                logIstance.track("RequestManager.init", "Begin")

                _DAORequest.logIstance = logIstance

                _DAORequest.init(basePath)

                logIstance.track("RequestManager.init", "Complete")

                Return True
            Catch ex As Exception
                logIstance.track("RequestManager.init", ex.Message, "fatal")

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to add a new request
        ''' </summary>
        ''' <param name="hash"></param>
        ''' <returns></returns>
        Public Function addNewRequest(ByVal hash As String, ByVal [type] As String) As Boolean
            Try
                Dim item As New RequestData

                logIstance.track("RequestManager.addNewRequest", "Begin")

                item.acquire = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()
                item.block = ""
                item.hash = hash
                item.state = RequestData.stateRequest.received

                logIstance.track("RequestManager.addNewRequest", "Complete")

                If Not _DAORequest.addNewRequest(item, [type]) Then
                    With _DAORequest.getRequest(item.hash)
                        If (.hash.Length > 0) Then
                            item.state = .state
                        End If
                    End With
                Else
                    item.state = RequestData.stateRequest.received
                End If

                Return (item.state = RequestData.stateRequest.received)
            Catch ex As Exception
                logIstance.track("RequestManager.addNewRequest", ex.Message, "fatal")

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to return a data request into db
        ''' </summary>
        ''' <param name="hash"></param>
        ''' <returns></returns>
        Public Function getRequest(ByVal hash As String) As RequestData
            Return _DAORequest.getRequest(hash)
        End Function

        ''' <summary>
        ''' This method provide to get a request a block position
        ''' </summary>
        ''' <param name="hash"></param>
        ''' <returns></returns>
        Public Function getRequestBlockPosition(ByVal hash As String) As String
            Return _DAORequest.getRequest(hash).block
        End Function

        ''' <summary>
        ''' This method provide to complete a request into db
        ''' </summary>
        ''' <param name="hash"></param>
        ''' <param name="currentState"></param>
        ''' <param name="block"></param>
        ''' <returns></returns>
        Public Function completedRequest(ByVal hash As String, ByVal currentState As RequestData.stateRequest, ByVal block As String) As Boolean
            Try
                Return _DAORequest.updateState(hash, currentState, block)
            Catch ex As Exception
                logIstance.track("RequestManager.completedRequest", ex.Message, "fatal")

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to delete an old request
        ''' </summary>
        ''' <param name="minimalMaintainanceRequestBlock"></param>
        ''' <returns></returns>
        Public Function deleteOldRequest(ByVal minimalMaintainanceRequestBlock As Integer) As Boolean
            Try
                logIstance.track("RequestManager.extractAndDeleteOldRequestBlock", "Begin")

                Return _DAORequest.deleteOldRequest(minimalMaintainanceRequestBlock)
            Catch ex As Exception
                logIstance.track("RequestManager.deleteOldRequest", ex.Message, "fatal")

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to delete old request rejected and trashed request
        ''' </summary>
        ''' <param name="minimalMaintenanceRequestFile"></param>
        ''' <returns></returns>
        Public Function deleteOldRequestRejectedAndTrashed(ByVal minimalMaintenanceRequestFile As Integer) As Boolean
            Try
                logIstance.track("RequestManager.deleteOldRequestRejectedAndTrashed", "Begin")

                Return _DAORequest.deleteOldRequest(minimalMaintenanceRequestFile)
            Catch ex As Exception
                logIstance.track("RequestManager.deleteOldRequestRejectedAndTrashed", ex.Message, "fatal")

                Return False
            Finally
                logIstance.track("RequestManager.deleteOldRequestRejectedAndTrashed", "Complete")
            End Try
        End Function

        ''' <summary>
        ''' This method provide to extract old request block
        ''' </summary>
        ''' <param name="minimalMantainRequestBlock"></param>
        ''' <returns></returns>
        Public Function extractOldRequestBlock(ByVal minimalMaintenanceRequestBlock As Integer) As List(Of String)
            Try
                logIstance.track("RequestManager.extractOldRequestBlock", "Begin")

                Return _DAORequest.getOldBlock(minimalMaintenanceRequestBlock)
            Catch ex As Exception
                logIstance.track("RequestManager.extractOldRequestBlock", ex.Message, "fatal")

                Return New List(Of String)
            Finally
                logIstance.track("RequestManager.extractOldRequestBlock", "Complete")
            End Try
        End Function

        ''' <summary>
        ''' This method provide to extract the maintenance request file
        ''' </summary>
        ''' <param name="minimalMaintenanceRequestFile"></param>
        ''' <returns></returns>
        Public Function extractOldRequestRejectOrTrashedFile(ByVal minimalMaintenanceRequestFile As Integer, ByVal state As RequestData.stateRequest) As List(Of String)
            Try
                logIstance.track("RequestManager.extractOldRequestRejectFile", "Begin")

                Return _DAORequest.getOldFile(minimalMaintenanceRequestFile, state)
            Catch ex As Exception
                logIstance.track("RequestManager.extractOldRequestRejectFile", ex.Message, "fatal")

                Return New List(Of String)
            Finally
                logIstance.track("RequestManager.extractOldRequestRejectFile", "Complete")
            End Try
        End Function

    End Class

End Namespace