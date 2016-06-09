using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitConverter.CoversionResults;
using UnitConverter.UnitTypes;


namespace UnitConverter.Implementations.VolumeImplementations
{
    public class LiterConversion : IConvertor<VolumeUnits>
    {
        public double? ConvertUnit(VolumeUnits targetUnit, double valueToConvert)
        {
            var result = new VolumeConversionResult()
            {
                CurrentUnit = VolumeUnits.Liter,
                TargetUnit = targetUnit
            };

            switch (targetUnit)
            {
                case VolumeUnits.Liter:
                    //Console.WriteLine($"{targetUnit} : {valueToConvert}");
                    return valueToConvert;
                case VolumeUnits.Pint:
                    //Console.WriteLine($"{targetUnit} : {valueToConvert * 2.11338}");
                    return valueToConvert * 2.11338;
                case VolumeUnits.Gallon:
                    return valueToConvert*0.264172;
                default:
                    return null;
            }
        }
    }
}
