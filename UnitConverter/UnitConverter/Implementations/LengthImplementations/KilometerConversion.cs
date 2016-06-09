using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitConverter.CoversionResults;
using UnitConverter.UnitTypes;

namespace UnitConverter.Implementations.LengthImplementations
{
    public class KilometerConversion : IConvertor<LengthUnits>
    {
        public double? ConvertUnit(LengthUnits targetUnit, double valueToConvert)
        {
            var result = new LengthConversionResult()
            {
                CurrentUnit = LengthUnits.Kilometer,
                TargetUnit = targetUnit
            };            

            //Console.WriteLine($"Kilometer : {valueToConvert}");

            switch (targetUnit)
            {
                case LengthUnits.Kilometer:
                    //Console.WriteLine($"{targetUnit} : {valueToConvert}");
                    return valueToConvert;                   
                case LengthUnits.Inch:
                    //Console.WriteLine($"{targetUnit} : {valueToConvert / 0.0000254}");
                    return valueToConvert / 0.0000254;
                case LengthUnits.Foot:
                    //Console.WriteLine($"{targetUnit} : {valueToConvert / 0.0003048}");
                    return valueToConvert / 0.0003048;
                case LengthUnits.Mile:
                    return valueToConvert/1.609344;
                default:
                    return null;
            }
        }
    }
    
}
