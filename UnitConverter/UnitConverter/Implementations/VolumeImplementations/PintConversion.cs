using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitConverter.CoversionResults;
using UnitConverter.UnitTypes;


namespace UnitConverter.Implementations.VolumeImplementations
{
    public class PintConversion : IConvertor<VolumeUnits>
    {
        public double? ConvertUnit(VolumeUnits targetUnit, double valueToConvert)
        {
            var result = new VolumeConversionResult()
            {
                CurrentUnit = VolumeUnits.Pint,
                TargetUnit = targetUnit
            };
                       
            switch (targetUnit)
            {
                case VolumeUnits.Pint:
                    //Console.WriteLine($"{targetUnit} : {valueToConvert}");
                    return valueToConvert;
                case VolumeUnits.Gallon:
                    //Console.WriteLine($"{targetUnit} : {valueToConvert / 8}");
                    return valueToConvert / 8;
                case VolumeUnits.Liter:
                    return valueToConvert*0.473176473;
                default:
                    return null;
            }
        }
    }
}
