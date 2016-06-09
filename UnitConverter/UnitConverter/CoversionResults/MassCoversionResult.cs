using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitConverter.Implementations;
using UnitConverter.UnitTypes;

namespace UnitConverter.CoversionResults
{
    public class MassCoversionResult
    {
        public MassUnits CurrentUnit { get; set; }
        public MassUnits TargetUnit { get; set; }
    }
}
