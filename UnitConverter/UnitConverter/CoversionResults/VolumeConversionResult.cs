using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitConverter.Implementations;
using UnitConverter.UnitTypes;

namespace UnitConverter.CoversionResults
{
    public class VolumeConversionResult
    {
        public VolumeUnits CurrentUnit { get; set; }
        public VolumeUnits TargetUnit { get; set; }
    }
}
