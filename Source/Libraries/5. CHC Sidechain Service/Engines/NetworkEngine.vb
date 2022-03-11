Option Compare Text
Option Explicit On

Imports System.Text.RegularExpressions




Namespace AreaNetwork


    Public Class Address

        ''' <summary>
        ''' This method provides to return a Public IP
        ''' </summary>
        ''' <returns></returns>
        Public Shared Function acquirePublicIP(Optional ByRef log As CHCCommonLibrary.AreaEngine.Log.TrackEngine = Nothing) As String
            Dim ipEngine As New Net.WebClient
            Dim ipAddress As String = "", tmp As String = ""

            Try
                If Not IsNothing(log) Then
                    log.trackEnter("CHCSidechainServiceLibrary.AreaNetwork.Address.acquirePublicIP")
                End If
                Try
                    ipAddress = ipEngine.DownloadString("http://checkip.dyndns.org/")
                Catch ex As Exception
                End Try
                Try
                    If (ipAddress.Length = 0) Then
                        ipAddress = ipEngine.DownloadString("http://automation.whatismyip.com/n09230945.asp")
                    End If
                Catch ex As Exception
                End Try
                Try
                    If (ipAddress.Length = 0) Then
                        ipAddress = ipEngine.DownloadString("http://tools.feron.it/php/ip.php")
                    End If
                Catch ex As Exception
                End Try
                If Not IsNumeric(ipAddress.Replace(".", "")) Then
                    tmp = Regex.Match(ipAddress, "(?<=<h2>My IP address is: )[0-9.]*?(?=</h2>)", RegexOptions.Compiled).Value

                    If (tmp.Length = 0) Then
                        tmp = Regex.Match(ipAddress, "(?<=<body>Current IP Address: )[0-9.]*?(?=</body>)", RegexOptions.Compiled).Value
                    End If
                Else
                    tmp = ipAddress
                End If
                If Not IsNothing(log) Then
                    If (tmp.Trim.Length = 0) Then
                        log.track("CHCSidechainServiceLibrary.AreaNetwork.Address.acquirePublicIP", "Service Public IP: not found")
                    Else
                        log.track("CHCSidechainServiceLibrary.AreaNetwork.Address.acquirePublicIP", "Service Public IP: " & tmp)
                    End If
                End If
            Catch ex As Exception
                If Not IsNothing(log) Then
                    log.trackException("CHCSidechainServiceLibrary.AreaNetwork.Address.acquirePublicIP", ex.Message)
                End If
            Finally
                If Not IsNothing(log) Then
                    log.trackExit("CHCSidechainServiceLibrary.AreaNetwork.Address.acquirePublicIP")
                End If
            End Try

            Return tmp
        End Function

        ''' <summary>
        ''' This method provides to return a Local IP
        ''' </summary>
        ''' <returns></returns>
        Public Shared Function acquireLocalIP(ByVal intranetMode As Boolean, Optional ByRef log As CHCCommonLibrary.AreaEngine.Log.TrackEngine = Nothing) As String
            Try
                If Not IsNothing(log) Then
                    log.trackEnter("CHCSidechainServiceLibrary.AreaNetwork.Address.acquireLocalIP")
                End If

                Dim hostName = Net.Dns.GetHostName()
                Dim first As String = ""

                For Each hostAdr In Net.Dns.GetHostEntry(hostName).AddressList()
                    first = hostAdr.ToString

                    If (hostAdr.AddressFamily = Net.Sockets.AddressFamily.InterNetwork) Then
                        Return hostAdr.ToString
                    End If
                Next

                If intranetMode Then
                    Return first
                End If
            Catch ex As Exception
                If Not IsNothing(log) Then
                    log.trackException("CHCSidechainServiceLibrary.AreaNetwork.Address.acquireLocalIP", ex.Message)
                End If
            Finally
                If Not IsNothing(log) Then
                    log.trackExit("CHCSidechainServiceLibrary.AreaNetwork.Address.acquireLocalIP")
                End If
            End Try

            Return ""
        End Function

        ''' <summary>
        ''' This method provide to exam the address if is local or not
        ''' </summary>
        ''' <param name="addressIP"></param>
        ''' <returns></returns>
        Public Shared Function isPrivateNetwork(ByVal addressIP As String) As Boolean
            Try
                If (addressIP.Length > 3) Then
                    Dim firstClass As String = addressIP.Substring(0, 3)

                    Return ((firstClass = "10.") Or (firstClass = "172") Or (firstClass = "192"))
                End If
            Catch ex As Exception
            End Try

            Return False
        End Function

    End Class



End Namespace
