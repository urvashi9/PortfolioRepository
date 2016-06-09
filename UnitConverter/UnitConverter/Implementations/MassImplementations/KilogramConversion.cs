using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitConverter.CoversionResults;
using UnitConverter.UnitTypes;


namespace UnitConverter.Implementations.MassImplementations
{
    public class KilogramConversion : IConvertor<MassUnits>
    {
        public double? ConvertUnit(MassUnits targetUnit, double valueToConvert)
        {
            var result = new MassCoversionResult()
            {
                CurrentUnit = MassUnits.Kilogram,
                TargetUnit = targetUnit
            };

            //Console.WriteLine($"Kilogram : {valueToConvert}");

            switch (targetUnit)
            {
                case MassUnits.Kilogram:
                    //Console.WriteLine($"{targetUnit} : {valueToConvert}");
                    return valueToConvert;
                case MassUnits.Pound:
                    //Console.WriteLine($"{targetUnit} : {valueToConvert * 2.2046}");
                    return valueToConvert * 2.2046;
                case MassUnits.Ton:
                    //Console.WriteLine($"{targetUnit} : {valueToConvert / 1000}");
                    return valueToConvert / 1000;
                case MassUnits.Ounce:
                    return valueToConvert*35.2739;
                default:
                    return null;
            }
        }

        
    }
}
