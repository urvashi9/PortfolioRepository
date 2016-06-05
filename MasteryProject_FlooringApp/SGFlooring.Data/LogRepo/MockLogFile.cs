using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGFlooring.Data.Interfaces;

namespace SGFlooring.Data.LogRepo
{
    public class MockLogFile : ILogFile
    {
        public void WriteAllErrors(DateTime date, string message)
        {
            throw new NotImplementedException();
        }
    }
}
