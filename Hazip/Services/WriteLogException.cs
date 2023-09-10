using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hazip.Services
{
    public class WriteLogException
    {
        public WriteLogException() { }

        public static void LogException(Exception ex)
        {
            DateTime tanggal = DateTime.Now;
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string logFilePath =  $"{tanggal.ToString("ddMMyyyy")}LogError.log";

            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.WriteLine($"[{DateTime.Now}] Error: {ex.Message}");
                writer.WriteLine($"StackTrace: {ex.StackTrace}");
                writer.WriteLine("--------------------------------------------------");
            }
        }
    }


}
