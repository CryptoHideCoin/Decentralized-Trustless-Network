Option Compare Text
Option Explicit On

Imports CHCCmd.AreaCommon.Models
Imports CHCCommonLibrary.AreaEngine.CommandLine




Namespace AreaCommon.Command

    ''' <summary>
    ''' This class manage the command help 
    ''' </summary>
    Public Class CommandHelp : Implements CommandModel

        Private Property _Command As CommandStructure

        Private Property CommandModel_command As CommandStructure Implements CommandModel.command
            Get
                Return _Command
            End Get
            Set(value As CommandStructure)
                _Command = value
            End Set
        End Property

        Private Function CommandModel_run() As Boolean Implements CommandModel.run
            Console.WriteLine("Help list command")
            Console.WriteLine("=================")
            Console.WriteLine()
            Console.WriteLine("-help                                Show this list")
            Console.WriteLine("-info                                Show an info of this application")
            Console.WriteLine("-release                             Show a relase of this application")
            Console.WriteLine("-updateSystemDate                    Update the system date")
            Console.WriteLine("-currentTime                         Show the current time (current/GMT/Timestamp)")
            Console.WriteLine("-ipAddress                           Get the IP Address (public and private)")
            Console.WriteLine("-pause                               Wait until the user key press occurs")
            Console.WriteLine("-wait                                Wait a number of millisecond")
            Console.WriteLine("-sideChainServiceSettings            Open a Chain Settings Editor")
            Console.WriteLine("   --service:                        Set a service name")
            Console.WriteLine("   --dataPath:                       Set a data path")
            Console.WriteLine("   --showAsFile                      Show the content in a notepad")
            Console.WriteLine("   --password:                       Set a password to decode")
            Console.WriteLine("-showLog                             Show a log of a service")
            Console.WriteLine("   --service:                        Set a service name")
            Console.WriteLine("   --dataPath:                       Set a data path")
            Console.WriteLine("   --password:                       Set a password to decode settings file")
            Console.WriteLine("   --securityKey:                    Set a password of a security key")
            Console.WriteLine("-startServe                          Start a service")
            Console.WriteLine("   --service:                        Set a service name")
            Console.WriteLine("   --dataPath:                       Set a data path")
            Console.WriteLine("   --password:                       Set a password to decode settings file")
            Console.WriteLine("-stopServe                           Stop a service")
            Console.WriteLine("   --service:                        Set a service name")
            Console.WriteLine("   --dataPath:                       Set a data path")
            Console.WriteLine("   --password:                       Set a password to decode settings file")
            Console.WriteLine("   --securityKey:                    Set a password of a security key")
            Console.WriteLine("-statusServe                         Check the status of a service")
            Console.WriteLine("   --service:                        Set a service name")
            Console.WriteLine("   --dataPath:                       Set a data path")
            Console.WriteLine("   --password:                       Set a password to decode settings file")
            Console.WriteLine("   --securityKey:                    Set a password of a security key")
            Console.WriteLine("-testServe                           Test a service")
            Console.WriteLine("   --service:                        Set a service name")
            Console.WriteLine("   --dataPath:                       Set a data path")
            Console.WriteLine("   --password:                       Set a password to decode settings file")
            Console.WriteLine("   --securityKey:                    Set a password of a security key")
            Console.WriteLine("-setEnvironmentRepository            Set the repository of all environment")
            Console.WriteLine("   --dataPath:                       Set a data path of repository")
            Console.WriteLine("-getEnvironmentRepository            Get the repository of all environment")
            Console.WriteLine("-createNewEnvironment                Add a new environment to the repository")
            Console.WriteLine("   --name:                           Set a name of environment")
            Console.WriteLine("   --dataPath:                       Set a data path of environment")
            Console.WriteLine("-removeEnvironment                   Remove an environment from the repository")
            Console.WriteLine("   --name:                           Set a name of environment to remove")
            Console.WriteLine("-getEnvironmentList                  List of environments")
            Console.WriteLine("-getCurrentEnvironment               Get a current environment")
            Console.WriteLine("-setCurrentEnvironment               Set a current environment")
            Console.WriteLine("   --name:                           Specify a name of environment that set as a current")
            Console.WriteLine("-getApplicationsPath                 List a path of a applications")
            Console.WriteLine("-setDefaultParameter                 Set a default parameter")
            Console.WriteLine("   --name:                           Specify a name of a default parameter to set")
            Console.WriteLine("   --value:                          Specify a value of a default parameter to set")
            Console.WriteLine("-getDefaultParameters                List a default parameters")
            Console.WriteLine("-batch                               Process a file batch")
            Console.WriteLine("   --fileName:                       Specify the file name of a batch")
            Console.WriteLine("-if                                  Check and execute a batch file is case positive")
            Console.WriteLine("   --environmentRepositoryNotSet:    Test if environment repository not set")
            Console.WriteLine("   --environmentDefaultNotSet:       Test if default environment not set")
            Console.WriteLine("   --defaultParametersNotDefine:     Test if default parameters not define")
            Console.WriteLine("   --applicationsPathNotDefine:      Test if application's path not define")

            Console.WriteLine()
            Console.WriteLine("General switch:")
            Console.WriteLine("   --pause:                  Wait a key press to close a chc command")
            Console.WriteLine("   --wait:                  Wait a specific interval time (in millisecond) to close a chc command")
            Return True
        End Function

    End Class

End Namespace
