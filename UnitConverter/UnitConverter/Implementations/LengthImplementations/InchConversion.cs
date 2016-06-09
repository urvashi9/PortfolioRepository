using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitConverter.CoversionResults;
using UnitConverter.UnitTypes;

namespace UnitConverter.Implementations.LengthImplementations
{
    public class InchConversion : IConvertor<LengthUnits>
    {
        public double? ConvertUnit(LengthUnits targetUnit, double valueToConvert )
        {
            var conversion = new LengthConversionResult()
            {
                CurrentUnit = LengthUnits.Inch,
                TargetUnit = targetUnit
            };           

            //Console.WriteLine($"Inch : {valueToConvert}");

            switch (targetUnit)
            {
                case LengthUnits.Inch:
                    Console.WriteLine($"{targetUnit} : {valueToConvert}");
                    return valueToConvert;
                case LengthUnits.Foot:
                    Console.WriteLine($"{targetUnit} : {valueToConvert / 12}");
                    return valueToConvert / 12;
                case LengthUnits.Kilometer:
                    Console.WriteLine($"{targetUnit} : {valueToConvert * 0.0000254}");
                    return valueToConvert * 0.0000254;
                case LengthUnits.Mile:
                    return valueToConvert/63360;
                default:
                    return null;
            }

        }
    }
}
