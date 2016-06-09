using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitConverter.CoversionResults;
using UnitConverter.UnitTypes;


namespace UnitConverter.Implementations.MassImplementations
{
    public class PoundConversion : IConvertor<MassUnits>
    {
        public double? ConvertUnit(MassUnits targetUnit, double valueToConvert)
        {
            var result = new MassCoversionResult()
            {
                CurrentUnit = MassUnits.Pound,
                TargetUnit = targetUnit
            };

            switch (targetUnit)
            {
                case MassUnits.Pound:
                    //Console.WriteLine($"{targetUnit} : {valueToConvert}");
                    return valueToConvert;
                case MassUnits.Kilogram:
                    //Console.WriteLine($"{targetUnit} : {valueToConvert / 2.2046}");
                    return valueToConvert / 2.2046;
                case MassUnits.Ton:
                    //Console.WriteLine($"{targetUnit} : {valueToConvert * 0.00045359237}");
                    return valueToConvert * 0.00045359237;
                case MassUnits.Ounce:
                    return valueToConvert*16;
                default:
                    return null;
            }
        }
    }
}
