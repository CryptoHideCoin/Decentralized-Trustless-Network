﻿Option Compare Text
Option Explicit On


Imports System.Web.Http
Imports CHCCommonLibrary.AreaCommon.Models.General
Imports CHCProtocolLibrary.AreaCommon





Namespace Controllers


    ' GET: api/{GUID service}/service/supportedProtocolsController
    <Route("ServiceApi")>
    Public Class supportedProtocolsController

        Inherits ApiController




        Public Function GetValue() As Models.Service.SupportedProtocolsResponseModel
            Dim result As New Models.Service.SupportedProtocolsResponseModel

            Try
                result.protocols.Add("SuperminimalAdmin")

                result.requestTime = Now
                result.responseTime = Now
            Catch ex As Exception
                result.responseStatus = RemoteResponse.EnumResponseStatus.inError
                result.errorDescription = "503 - Generic Error"
            End Try

            Return result
        End Function


    End Class


End Namespace