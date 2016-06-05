using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGFlooring.Data.Interfaces;

namespace SGFlooring.Data.LogRepo
{
    public class LogFile : ILogFile
    {
        public void WriteAllErrors(DateTime date, string message)
        {
            var _filePath = @"DataFiles\LogFile.txt";
            if (!File.Exists(_filePath))
            {
                using (StreamWriter sr = File.CreateText(_filePath))
                {
                    sr.WriteLine(
                    "Date,Error");
                    sr.WriteLine($"{date} : {message}");
                }
            }
            else
            {
                using (StreamWriter sr = File.AppendText(_filePath))
                {
                    sr.WriteLine($"{date} : {message}");
                }
            }

        }
    }
}
