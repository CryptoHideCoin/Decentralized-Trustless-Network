using System;
using System.Linq;


namespace TbsExchangeGateway
{
    class Program
    {
        static string _ProcessPath, _ProcessedPath, _ProcessError, _InWorking;

        static bool inWorking(string fileName)
        {
            /*
             * Quello che devo fare è vedere se il file è presente all'interno della cartella InWorking
             */

            return true;
        }

        static bool moveFileToWorking(string fileName)
        {
            /*
             * Che faccio ?!?
             * 
             * Semplice, prendo il file che si trova nella cartella _ProcessPath e lo sposto nella working directory
             * no more!
             */
            return true;
        }

        static bool processFile(string fileName)
        {
            /*
             * Che faccio ?!?
             * 
             * Leggo il file e lo decodifico
             * 
             * Quindi eseguo il comando del file ...
             * 
             */
            return true;
        }

        static bool processRequests()
        {
            string fileName;

            do {
                fileName = System.IO.Directory.GetFiles(_ProcessPath, "*.order", System.IO.SearchOption.TopDirectoryOnly).First();

                if (fileName.Length > 0)
                {
                    if (inWorking(fileName) == false)
                    {
                        if (moveFileToWorking(fileName) == true)
                        {
                            processFile(fileName);
                        }
                    }
                }
            } while (System.IO.Directory.GetFiles(_ProcessPath, "*.order", System.IO.SearchOption.TopDirectoryOnly).Length > 0);

            return true;
        }

        static void Main(string[] args)
        {
            try
            {
                if (args == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: Work Path not set!");
                }

                string mainPath = "";

                foreach (string item in args)
                {
                    mainPath += " " + item;
                }
                mainPath = mainPath.Trim();
                _ProcessPath = String.Concat(mainPath, "ToProcesss");
                _ProcessedPath = String.Concat(mainPath, "Processed");
                _ProcessError = String.Concat(mainPath, "ProcessError");
                _InWorking = String.Concat(mainPath, "InWorking");

                if (System.IO.Directory.Exists(mainPath) == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: Main Path not found!");
                }
                if (System.IO.Directory.Exists(_ProcessPath) == false) System.IO.Directory.CreateDirectory(_ProcessPath);
                if (System.IO.Directory.Exists(_ProcessedPath) == false) System.IO.Directory.CreateDirectory(_ProcessedPath);
                if (System.IO.Directory.Exists(_ProcessError) == false) System.IO.Directory.CreateDirectory(_ProcessError);
                if (System.IO.Directory.Exists(_InWorking) == false) System.IO.Directory.CreateDirectory(_InWorking);

                do
                {
                    System.Threading.Thread.Sleep(100);
                } while (processRequests() == true);
            }
            catch
            {

            }
        }
    }
}
