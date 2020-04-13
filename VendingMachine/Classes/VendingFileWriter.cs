using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace VendingMachine.Classes
{
    public class VendingFileWriter
    {
        static string directory = Directory.GetCurrentDirectory();
        static string path = Path.Combine(directory, "log.txt");
        
        public void WriteToLog(string message)
        {
            try
            {
                using (StreamWriter stw = new StreamWriter(path, true))
                {
                    stw.WriteLine(DateTime.Now + "  " + message);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Could not write to log: " + e.Message);
            }
        }


    }
}
