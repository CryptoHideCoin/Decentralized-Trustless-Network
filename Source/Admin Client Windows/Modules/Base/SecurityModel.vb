﻿Option Compare Text
Option Explicit On



Namespace AreaCommon.Models.Security


    Public Enum enumOfService

        admin
        start
        runTime
        client

    End Enum


    Public Class changeCertificate

        Public typeCommunication As enumOfService
        Public currentCertificate As String
        Public newCertificate As String
        Public signature As String

    End Class


End Namespace