using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGFlooring.Data.Interfaces;
using SGFlooring.Data.LogRepo;

namespace SGFlooring.Data.Factories
{
    public class LogFactory
    {
        public static ILogFile GetLogFile()
        {
            var mode = ConfigurationManager.AppSettings["Mode"];
            switch (mode)
            {
                case "Test":
                    return new MockLogFile();
                default:
                    return new LogFile();
            }
        }
    }
}
