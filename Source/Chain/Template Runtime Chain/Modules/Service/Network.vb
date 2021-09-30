Option Compare Text
Option Explicit On

Imports System.Text.RegularExpressions




Namespace AreaNetwork


    Module Address


        ''' <summary>
        ''' This method provides to return a Public IP
        ''' </summary>
        ''' <returns></returns>
        Public Function acquirePublicIP(Optional ByVal writeOnConsole As Boolean = True) As String

            Dim ipEngine As New Net.WebClient
            Dim ipAddress As String = "", tmp As String = ""

            Try

                AreaCommon.log.track("Address.acquirePublicIP", "Begin")

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

                If (tmp.Trim.Length = 0) Then
                    AreaCommon.log.track("Address.acquirePublicIP", "Masternode Public IP: not found")
                Else
                    AreaCommon.log.track("Address.acquirePublicIP", "Masternode Public IP: " & tmp)
                End If

            Catch ex As Exception
                AreaCommon.log.track("Address.acquirePublicIP", ex.Message, "fatal")

                AreaCommon.closeApplication()
            Finally
                AreaCommon.log.track("Address.acquirePublicIP", "Completed")
            End Try

            Return tmp

        End Function



        ''' <summary>
        ''' This method provides to return a Local IP
        ''' </summary>
        ''' <returns></returns>
        Public Function acquireLocalIP() As String

            Try

                Dim hostName = Net.Dns.GetHostName()
                Dim first As String = ""

                For Each hostAdr In Net.Dns.GetHostEntry(hostName).AddressList()

                    first = hostAdr.ToString

                    If (hostAdr.AddressFamily = Net.Sockets.AddressFamily.InterNetwork) Then
                        Return hostAdr.ToString
                    End If

                Next

                If AreaCommon.settings.data.intranetMode Then
                    Return first
                End If

            Catch ex As Exception
            End Try

            Return ""

        End Function



    End Module



End Namespace