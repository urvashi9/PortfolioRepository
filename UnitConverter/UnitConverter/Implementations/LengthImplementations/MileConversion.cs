using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitConverter.CoversionResults;
using UnitConverter.UnitTypes;


namespace UnitConverter.Implementations.LengthImplementations
{
    public class MileConversion : IConvertor<LengthUnits>
    {
        public double? ConvertUnit(LengthUnits targetUnit, double valueToConvert)
        {
            var result = new LengthConversionResult()
            {
                CurrentUnit = LengthUnits.Mile,
                TargetUnit = targetUnit
            };

            //Console.WriteLine($"Mile : {valueToConvert}");

            switch (targetUnit)
            {
                case LengthUnits.Mile:
                    //Console.WriteLine($"{targetUnit} : {valueToConvert}");
                    return valueToConvert;
                case LengthUnits.Inch:
                    //Console.WriteLine($"{targetUnit} : {valueToConvert * 63360}");
                    return valueToConvert * 63360;
                case LengthUnits.Foot:
                    //Console.WriteLine($"{targetUnit} : {valueToConvert * 5280}");
                    return valueToConvert*5280;                
                case LengthUnits.Kilometer:
                    return valueToConvert/1.609344;
                default:
                    return null;
            }

        }
    }
}
