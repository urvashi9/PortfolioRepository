using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter
{
    public interface IConvertor<T>
    {
        double? ConvertUnit(T unit, double valueToConvert);
    }
}
