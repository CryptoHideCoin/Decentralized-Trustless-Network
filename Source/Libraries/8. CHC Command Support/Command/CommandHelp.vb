Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.CommandLine




Namespace AreaCommon.Command

    ''' <summary>
    ''' This class manage the command help 
    ''' </summary>
    Public Class CommandHelp : Implements Models.CommandModel

        Private Property _Command As CommandStructure

        Public Event WriteLine(ByVal message As String) Implements Models.CommandModel.WriteLine
        Public Event Process(ByVal applicationName As String, ByVal commandLine As String) Implements Models.CommandModel.Process
        Public Event IntegrityApplication(ByVal fileName As String) Implements Models.CommandModel.IntegrityApplication
        Public Event RaiseError(ByVal message As String) Implements Models.CommandModel.RaiseError
        Public Event ReadKey() Implements Models.CommandModel.ReadKey


        Private Property CommandModel_command As CommandStructure Implements Models.CommandModel.command
            Get
                Return _Command
            End Get
            Set(value As CommandStructure)
                _Command = value
            End Set
        End Property

        Private Function CommandModel_run() As Boolean Implements Models.CommandModel.run
            RaiseEvent WriteLine("Help list command")
            RaiseEvent WriteLine("=================")
            RaiseEvent WriteLine("")
            RaiseEvent WriteLine("-help                                Show this list")
            RaiseEvent WriteLine("-info                                Show an info of this application")
            RaiseEvent WriteLine("-release                             Show a relase of this application")
            RaiseEvent WriteLine("-updateSystemDate                    Update the system date")
            RaiseEvent WriteLine("-currentTime                         Show the current time (current/GMT/Timestamp)")
            RaiseEvent WriteLine("-ipAddress                           Get the IP Address (public and private)")
            RaiseEvent WriteLine("-pause                               Wait until the user key press occurs")
            RaiseEvent WriteLine("-wait                                Wait a number of millisecond")
            RaiseEvent WriteLine("-sideChainServiceSettings            Open a Chain Settings Editor")
            RaiseEvent WriteLine("   --service:                        Set a service name")
            RaiseEvent WriteLine("   --dataPath:                       Set a data path")
            RaiseEvent WriteLine("   --showAsFile                      Show the content in a notepad")
            RaiseEvent WriteLine("   --password:                       Set a password to decode")
            RaiseEvent WriteLine("-showLog                             Show a log of a service")
            RaiseEvent WriteLine("   --service:                        Set a service name")
            RaiseEvent WriteLine("   --dataPath:                       Set a data path")
            RaiseEvent WriteLine("   --password:                       Set a password to decode settings file")
            RaiseEvent WriteLine("   --securityKey:                    Set a password of a security key")
            RaiseEvent WriteLine("   --address:                        Set an a complete address")
            RaiseEvent WriteLine("-showJournal                         Show a journal of a service")
            RaiseEvent WriteLine("   --service:                        Set a service name")
            RaiseEvent WriteLine("   --dataPath:                       Set a data path")
            RaiseEvent WriteLine("   --date:                           Set a date of a journal")
            RaiseEvent WriteLine("   --password:                       Set a password to decode settings file")
            RaiseEvent WriteLine("   --securityKey:                    Set a password of a security key")
            RaiseEvent WriteLine("   --address:                        Set an a complete address")
            RaiseEvent WriteLine("-startServe                          Start a service")
            RaiseEvent WriteLine("   --service:                        Set a service name")
            RaiseEvent WriteLine("   --dataPath:                       Set a data path")
            RaiseEvent WriteLine("   --password:                       Set a password to decode settings file")
            RaiseEvent WriteLine("-stopServe                           Stop a service")
            RaiseEvent WriteLine("   --service:                        Set a service name")
            RaiseEvent WriteLine("   --dataPath:                       Set a data path")
            RaiseEvent WriteLine("   --password:                       Set a password to decode settings file")
            RaiseEvent WriteLine("   --securityKey:                    Set a password of a security key")
            RaiseEvent WriteLine("-statusServe                         Check the status of a service")
            RaiseEvent WriteLine("   --service:                        Set a service name")
            RaiseEvent WriteLine("   --dataPath:                       Set a data path")
            RaiseEvent WriteLine("   --password:                       Set a password to decode settings file")
            RaiseEvent WriteLine("   --securityKey:                    Set a password of a security key")
            RaiseEvent WriteLine("-testServe                           Test a service")
            RaiseEvent WriteLine("   --service:                        Set a service name")
            RaiseEvent WriteLine("   --dataPath:                       Set a data path")
            RaiseEvent WriteLine("   --password:                       Set a password to decode settings file")
            RaiseEvent WriteLine("   --securityKey:                    Set a password of a security key")
            RaiseEvent WriteLine("-getPerformanceProfile               Get a performance profile")
            RaiseEvent WriteLine("   --service:                        Set a service name")
            RaiseEvent WriteLine("   --dataPath:                       Set a data path")
            RaiseEvent WriteLine("   --password:                       Set a password to decode settings file")
            RaiseEvent WriteLine("   --securityKey:                    Set a password of a security key")
            RaiseEvent WriteLine("-startPerformanceProfile             Start performance profile")
            RaiseEvent WriteLine("   --service:                        Set a service name")
            RaiseEvent WriteLine("   --dataPath:                       Set a data path")
            RaiseEvent WriteLine("   --password:                       Set a password to decode settings file")
            RaiseEvent WriteLine("   --securityKey:                    Set a password of a security key")
            RaiseEvent WriteLine("-testRAWServe                        Test a server response with RAW response")
            RaiseEvent WriteLine("   --address:                        Set the address")
            RaiseEvent WriteLine("-setEnvironmentRepository            Set the repository of all environment")
            RaiseEvent WriteLine("   --dataPath:                       Set a data path of repository")
            RaiseEvent WriteLine("-getEnvironmentRepository            Get the repository of all environment")
            RaiseEvent WriteLine("-createNewEnvironment                Add a new environment to the repository")
            RaiseEvent WriteLine("   --name:                           Set a name of environment")
            RaiseEvent WriteLine("   --dataPath:                       Set a data path of environment")
            RaiseEvent WriteLine("-removeEnvironment                   Remove an environment from the repository")
            RaiseEvent WriteLine("   --name:                           Set a name of environment to remove")
            RaiseEvent WriteLine("-getEnvironmentList                  List of environments")
            RaiseEvent WriteLine("-getCurrentEnvironment               Get a current environment")
            RaiseEvent WriteLine("-setCurrentEnvironment               Set a current environment")
            RaiseEvent WriteLine("   --name:                           Specify a name of environment that set as a current")
            RaiseEvent WriteLine("-getApplicationsPath                 List a path of a applications")
            RaiseEvent WriteLine("-setDefaultParameter                 Set a default parameter")
            RaiseEvent WriteLine("   --name:                           Specify a name of a default parameter to set")
            RaiseEvent WriteLine("   --value:                          Specify a value of a default parameter to set")
            RaiseEvent WriteLine("-getDefaultParameters                List a default parameters")
            RaiseEvent WriteLine("-write                               Print a message into console")
            RaiseEvent WriteLine("   --message:                        Contain a message into console")
            RaiseEvent WriteLine("-note                                Add a note to the script")
            RaiseEvent WriteLine("-buildPath                           Build a path of a platform")
            RaiseEvent WriteLine("-batch                               Process a file batch")
            RaiseEvent WriteLine("   --fileName:                       Specify the file name of a batch")
            RaiseEvent WriteLine("-if                                  Check and execute a batch file is case positive")
            RaiseEvent WriteLine("   --environmentRepositoryNotSet:    Test if environment repository not set")
            RaiseEvent WriteLine("   --environmentDefaultNotSet:       Test if default environment not set")
            RaiseEvent WriteLine("   --defaultParametersNotDefine:     Test if default parameters not define")
            RaiseEvent WriteLine("   --applicationsPathNotDefine:      Test if application's path not define")
            RaiseEvent WriteLine("-log                                 Log action")
            RaiseEvent WriteLine("   --getList:                        Return the list of log file")
            RaiseEvent WriteLine("   --blockExplorer:<value>           Show the block explorer data")
            RaiseEvent WriteLine("   --deleteBlock:<value>             Delete a block data (file and index)")
            RaiseEvent WriteLine("   --deleteOldLogInstance:           Delete all previous log instance")
            RaiseEvent WriteLine("   --logRotate:                      Start log rotate")
            RaiseEvent WriteLine("-showJournal                         Show journal action")
            RaiseEvent WriteLine("-registry                            Registry action")
            RaiseEvent WriteLine("   --getList                         Return the list of registry file")
            RaiseEvent WriteLine("   --clean                           Start registry rotate")
            RaiseEvent WriteLine("")
            RaiseEvent WriteLine("General switch:")
            RaiseEvent WriteLine("   --pause:                          Wait a key press to close a chc command")
            RaiseEvent WriteLine("   --wait:                           Wait a specific interval time (in millisecond) to close a chc command")

            Return True
        End Function

    End Class

End Namespace
