using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitConverter.Implementations;
using UnitConverter.UnitTypes;

namespace UnitConverter.CoversionResults
{
    public class TempConversionResult
    {
        public TemperatureUnits CurrentUnit { get; set; }
        public TemperatureUnits TargetUnit { get; set; }
    }
}
