Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.DataFileManagement.Json



Namespace AreaEngine

    Public Enum ApplicationID
        undefined
        sideChainServiceSettings
        showLog
        localWorkMachine
        sideChainService
    End Enum

    ''' <summary>
    ''' This class contain the information of a configuration of application
    ''' </summary>
    Public Class ApplicationPathData

        Public Property applicationReferement As ApplicationID = ApplicationID.undefined
        Public Property rootPath As String = ""
        Public Property directoryName As String = ""
        Public Property applicationName As String = ""

    End Class

    ''' <summary>
    ''' This class provide to manage a collection of a configuration 
    ''' </summary>
    Public Class ApplicationCollection

        Private Property index As New Dictionary(Of ApplicationID, ApplicationPathData)

        Public Property data As New List(Of ApplicationPathData)


        ''' <summary>
        ''' This method provide to add a new item into collection
        ''' </summary>
        ''' <param name="name"></param>
        ''' <param name="path"></param>
        ''' <returns></returns>
        Public Function addNew(ByVal applicationReferement As ApplicationID, ByVal rootPath As String, ByVal directoryName As String, ByVal applicationName As String) As Boolean
            Dim newItem As New ApplicationPathData

            newItem.applicationReferement = applicationReferement
            newItem.rootPath = rootPath
            newItem.directoryName = directoryName
            newItem.applicationName = applicationName

            data.Add(newItem)
            index.Add(applicationReferement, newItem)

            Return True
        End Function

        ''' <summary>
        ''' This method provide to create a collection to default application collection list
        ''' </summary>
        ''' <returns></returns>
        Public Function createDefault(ByVal rootPath As String) As Boolean
            Dim proceed As Boolean = True

            rootPath = IO.Directory.GetParent(rootPath).FullName

            If proceed Then
                proceed = addNew(ApplicationID.sideChainServiceSettings, rootPath, "CHC Sidechain Service Settings", "CHCSidechainServiceSettings.exe")
            End If
            If proceed Then
                proceed = addNew(ApplicationID.showLog, rootPath, "CHC Show Log", "CHCShowLog.exe")
            End If
            If proceed Then
                proceed = addNew(ApplicationID.localWorkMachine, rootPath, "CHC Local Work Machine", "CHCLocalWorkMachine.exe")
            End If
            If proceed Then
                proceed = addNew(ApplicationID.sideChainService, rootPath, "CHC Sidechain Service Runtime", "{value}.exe")
            End If

            Return proceed
        End Function

        ''' <summary>
        ''' This method provide to get an application data by Index 
        ''' </summary>
        ''' <param name="applicationReferement"></param>
        ''' <returns></returns>
        Public Function getApplicationData(ByVal applicationReferement As ApplicationID) As ApplicationPathData
            If index.ContainsKey(applicationReferement) Then
                Return index(applicationReferement)
            End If

            Return New ApplicationPathData
        End Function

        ''' <summary>
        ''' This method provide to rebuild index
        ''' </summary>
        ''' <returns></returns>
        Public Function rebuildIndex() As Boolean
            index.Clear()

            For Each item In data
                index.Add(item.applicationReferement, item)
            Next

            Return True
        End Function

    End Class

    ''' <summary>
    ''' This static class provide to manage an Environments list
    ''' </summary>
    Public Class ApplicationPathEngine

        Public Shared ReadOnly Property applicationPath As String
            Get
#If DEBUG Then
                Return "E:\CryptoHideCoinDTN\Binary\Applications\Console\CHC Cmd"
#Else
                return Environment.CurrentDirectory
#End If
            End Get
        End Property

        ''' <summary>
        ''' This method provide to initialize the component
        ''' </summary>
        ''' <returns></returns>
        Public Shared Function init() As Boolean
            Try
                Dim fileConfigurationPath As String = IO.Path.Combine(applicationPath, "Applications.path")

                If (ApplicationCommon.appConfigurations.data.Count = 0) Then
                    If IO.File.Exists(fileConfigurationPath) Then
                        ApplicationCommon.appConfigurations.data = IOFast(Of List(Of ApplicationPathData)).read(fileConfigurationPath)

                        Return ApplicationCommon.appConfigurations.rebuildIndex()
                    Else
                        ApplicationCommon.appConfigurations.createDefault(applicationPath)

                        Return IOFast(Of List(Of ApplicationPathData)).save(fileConfigurationPath, ApplicationCommon.appConfigurations.data)
                    End If
                End If

                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

    End Class

End Namespace

