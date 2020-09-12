Option Compare Text
Option Explicit On



Namespace AreaBootstrap


    Module Bootstrap

        Public initialNodeStart As New AreaChain.NodeList



        Private Function haveNodeList() As Boolean

            Try

                AreaCommon.log.track("bootStrap.haveNodeList", "Begin")

                If IO.Directory.Exists(AreaCommon.paths.pathTransactionChain) Then

                    Return IO.File.Exists(AreaCommon.paths.completePathNodeLinked)

                Else

                    Return False

                End If

                Return True

            Catch ex As Exception

                AreaCommon.log.track("bootStrap.haveNodeList", "Error:" & ex.Message, "fatal")

                AreaCommon.closeApplication()

                Return False

            Finally

                AreaCommon.log.track("bootStrap.haveNodeList", "Completed")

            End Try

        End Function


        Private Function haveTransactionChain() As Boolean

            Try

                AreaCommon.log.track("bootStrap.haveTransactionChain", "Begin")

                If IO.Directory.Exists(AreaCommon.paths.pathLedger) Then

                    Return IO.File.Exists(AreaCommon.paths.completePathPositionChecked)

                Else

                    Return False

                End If

            Catch ex As Exception

                AreaCommon.log.track("bootStrap.haveTransactionChain", "Error:" & ex.Message, "fatal")

                AreaCommon.closeApplication()

                Return False

            Finally

                AreaCommon.log.track("bootStrap.haveTransactionChain", "Completed")

            End Try

        End Function


        Private Function testConnectNode(ByVal singleNode As AreaChain.NodeList.NodeAtom) As Boolean

            Try

                AreaCommon.log.track("bootStrap.testConnectNode", "Begin")

                Dim webReader As New CHCCommonLibrary.CHCEngines.Communication.ProxySimplyWS(Of AreaCommon.Models.General.BooleanModel)
                Dim result As AreaCommon.Models.General.BooleanModel

                webReader.url = singleNode.address & ":" & singleNode.chainServicePort & "/api/v1.0/system/testService"

                If webReader.getData() Then

                    result = webReader.data

                    Return True

                End If

                Return False

            Catch ex As Exception

                AreaCommon.log.track("bootStrap.testConnectNode", "Error:" & ex.Message, "fatal")

                AreaCommon.closeApplication()

                Return False

            Finally

                AreaCommon.log.track("bootStrap.testConnectNode", "Completed")

            End Try

        End Function


        Private Sub rebuildNodes(ByVal nodes As List(Of AreaChain.NodeList.NodeAtom))

            Try

                AreaCommon.log.track("bootStrap.rebuildNodes", "Begin")

                Dim webReader As New CHCCommonLibrary.CHCEngines.Communication.ProxyWS(Of List(Of AreaChain.NodeList.NodeAtom))

                For Each item In nodes

                    webReader.url = item.address & ":" & item.chainServicePort & "/api/v1.0/chain/currentMasternodeList"

                    If webReader.getData() Then

                        rebuildNodes(webReader.data)

                    End If

                Next

            Catch ex As Exception

                AreaCommon.log.track("bootStrap.rebuildNodes", "Error:" & ex.Message, "fatal")

                AreaCommon.closeApplication()

            Finally

                AreaCommon.log.track("bootStrap.rebuildNodes", "Completed")

            End Try

        End Sub


        Private Function downloadNodeList(ByVal singleNode As AreaChain.NodeList.NodeAtom) As Boolean

            Try

                AreaCommon.log.track("bootStrap.downloadNodeList", "Begin")

                Dim webReader As New CHCCommonLibrary.CHCEngines.Communication.ProxyWS(Of List(Of AreaChain.NodeList.NodeAtom))

                webReader.url = singleNode.address & ":" & singleNode.chainServicePort

                If webReader.getData() Then

                    rebuildNodes(webReader.data)

                    Return True

                End If

                Return False

            Catch ex As Exception

                AreaCommon.log.track("bootStrap.downloadNodeList", "Error:" & ex.Message, "fatal")

                AreaCommon.closeApplication()

                Return False

            Finally

                AreaCommon.log.track("bootStrap.downloadNodeList", "Completed")

            End Try

        End Function


        Private Function tryToConnectToFirstNode() As Boolean

            Try

                AreaCommon.log.track("bootStrap.tryToConnectToNode", "Begin")

                For Each singleNode In initialNodeStart.data

                    If testConnectNode(singleNode) Then

                        If downloadNodeList(singleNode) Then

                            Return True

                        End If

                    End If

                Next

                Return False

            Catch ex As Exception

                AreaCommon.log.track("bootStrap.tryToConnectToNode", "Error:" & ex.Message, "fatal")

                AreaCommon.closeApplication()

                Return False

            Finally

                AreaCommon.log.track("bootStrap.tryToConnectToNode", "Completed")

            End Try

        End Function


        Private Function updateTransactionChain() As Boolean

            Try

                AreaCommon.log.track("bootStrap.updateTransactionChain", "Begin")

                For Each singleNode In initialNodeStart.data

                    If testConnectNode(singleNode) Then

                        If downloadNodeList(singleNode) Then

                            Return True

                        End If

                    End If

                Next

                Return False

            Catch ex As Exception

                AreaCommon.log.track("bootStrap.updateTransactionChain", "Error:" & ex.Message, "fatal")

                AreaCommon.closeApplication()

                Return False

            Finally

                AreaCommon.log.track("bootStrap.updateTransactionChain", "Completed")

            End Try

        End Function


        Private Function connectToTransactionChain() As Boolean

        End Function


        Private Sub manageStartupTransactionChain()

            If updateTransactionChain() Then

                If connectToTransactionChain() Then

                    ' finalmente ci siamo

                Else

                    ' segnalo il problema all'amministratore

                End If

            Else

                ' segnalo il problema all'amministratore
                ' che non sono riuscito ad aggiornare la
                ' transaction chain

            End If

        End Sub


        Private Sub readNodeList()

            Try

                AreaCommon.log.track("bootStrap.readNodeList", "Begin")

                initialNodeStart.fileName = AreaCommon.paths.completePathNodeLinked

                If Not initialNodeStart.read() Then

                    ' non ho letto il file e quindi esco per errore

                End If

            Catch ex As Exception

                AreaCommon.log.track("bootStrap.readNodeList", "Error:" & ex.Message, "fatal")

                AreaCommon.closeApplication()

            Finally

                AreaCommon.log.track("bootStrap.readNodeList", "Completed")

            End Try

        End Sub


        Private Sub manageProblemConnectionTransactionChain()

        End Sub


        Private Sub manageExistenceTransactionChainAndNodeList()

            Try

                AreaCommon.log.track("bootStrap.manageExistenceTransactionChainAndNodeList", "Begin")

                readNodeList()

                If tryToConnectToFirstNode() Then

                    manageStartupTransactionChain()

                Else

                    manageProblemConnectionTransactionChain()

                End If

            Catch ex As Exception

                AreaCommon.log.track("bootStrap.manageExistenceTransactionChainAndNodeList", "Error:" & ex.Message, "fatal")

                AreaCommon.closeApplication()

            Finally

                AreaCommon.log.track("bootStrap.manageExistenceTransactionChainAndNodeList", "Completed")

            End Try

        End Sub


        Private Sub manageExistenceTransactionChainMissingNodeList()

        End Sub


        Private Sub manageExistenceTransactionChain()

            Try

                AreaCommon.log.track("bootStrap.manageExistenceTransactionChain", "Begin")

                If haveNodeList() Then

                    manageExistenceTransactionChainAndNodeList()

                Else

                    manageExistenceTransactionChainMissingNodeList()

                End If

            Catch ex As Exception

                AreaCommon.log.track("bootStrap.manageExistenceTransactionChain", "Error:" & ex.Message, "fatal")

                AreaCommon.closeApplication()

            Finally

                AreaCommon.log.track("bootStrap.manageExistenceTransactionChain", "Completed")

            End Try

        End Sub


        Private Sub manageAbsenceTransactionChain()

            Try

                AreaCommon.log.track("bootStrap.manageAbsenceTransactionChain", "Begin")

                ' Non ho alcun file della transaction chain e quindi

                ' le cose sono due:

                ' A. O devo dare luogo alla transaction chain creandola

                ' B. Devo collegarmi ad un nodo per scaricare il file e iniziare i controlli da capo

            Catch ex As Exception

                AreaCommon.log.track("bootStrap.manageAbsenceTransactionChain", "Error:" & ex.Message, "fatal")

                AreaCommon.closeApplication()

            Finally

                AreaCommon.log.track("bootStrap.manageAbsenceTransactionChain", "Completed")

            End Try

        End Sub



        Sub startTransactionChain()

            Try

                AreaCommon.log.track("bootStrap.startTransactionChain", "Begin")

                If haveTransactionChain() Then

                    manageExistenceTransactionChain()

                Else

                    manageAbsenceTransactionChain()

                End If

            Catch ex As Exception

                AreaCommon.log.track("bootStrap.startTransactionChain", "Error:" & ex.Message, "fatal")

                AreaCommon.closeApplication()

            Finally

                AreaCommon.log.track("bootStrap.startTransactionChain", "Completed")

            End Try



            ' Possiedo una copia della Transaction Chain ?

            ' 1... SI
            '      A questo punto vedo se ho la lista dei nodi ?
            '
            ' 2... NO... a questo punto vedo se ho la lista dei nodi
            '


            ' 1.1....... SI 
            '            A questo punto cerco il collegamento ad almeno uno dei nodi (se qualcuno mi risponde)

            ' 1.1.1........ SONO RIUSCITO AD AGGANCIARMI AD ALMENO UN NODO
            ' 1.1.1.1......... MI SCARICO LA NUOVA LISTA DEI NODI ATTIVI
            ' 1.1.1.2......... NON SONO RIUSCITO A SCARICARE LA LISTA DEI NODI ATTIVI
            '                  Potrei essere l'unico nodo della transaction chain ? Vedo se l'amministrazione mi ha dato apposite istruzioni
            '                  Caso mai restituisco apposito errore all'amministratore
            '                  Altrimenti parto come unico nodo 

            ' 1.1.2........ NON SONO RIUSCITO AD AGGANCIARMI AD UN NODO
            '                  Potrei essere l'unico nodo della transaction chain ? Vedo se l'amministrazione mi ha dato apposite istruzioni
            '                  Caso mai restituisco apposito errore all'amministratore
            '                  Altrimenti parto come unico nodo 

            ' 1.2....... NO a questo punto potrei essere sempre stato l'unico nodo presente. Quindi vedo se c'è il parametro per la forzatura di riavvio
            '

            ' 2.1....... SI a questo provo il collegamento ad almeno uno dei nodi
            '
            ' 
            'a questo punto vedo se possiedo il parametro per forzare la creazione della transaction chain (creazione della 

        End Sub

    End Module


End Namespace