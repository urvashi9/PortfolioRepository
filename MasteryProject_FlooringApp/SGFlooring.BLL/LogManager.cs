using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGFlooring.Data.Factories;
using SGFlooring.Data.Interfaces;

namespace SGFlooring.BLL
{
    public class LogManager
    {
        private ILogFile _file;
        public LogManager()
        {
            _file = LogFactory.GetLogFile();
        }

        public void ErrorLogs(DateTime date, string message)
        {
            _file.WriteAllErrors(date, message);
        }
    }
}
