using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGFlooring.Data.Interfaces
{
    public interface ILogFile
    {
        void WriteAllErrors(DateTime date, string message);
    }
}
