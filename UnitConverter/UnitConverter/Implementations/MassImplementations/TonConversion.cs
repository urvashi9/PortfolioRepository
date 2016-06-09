using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitConverter.CoversionResults;
using UnitConverter.UnitTypes;


namespace UnitConverter.Implementations.MassImplementations
{
    public class TonConversion : IConvertor<MassUnits>
    {
        public double? ConvertUnit(MassUnits targetUnit, double valueToConvert)
        {
            var result = new MassCoversionResult()
            {
                CurrentUnit = MassUnits.Ton,
                TargetUnit = targetUnit
            };

            switch (targetUnit)
            {
                case MassUnits.Ton:
                    //Console.WriteLine($"{targetUnit} : {valueToConvert}");
                    return valueToConvert;
                case MassUnits.Kilogram:
                    //Console.WriteLine($"{targetUnit} : {valueToConvert * 1000}");
                    return valueToConvert * 1000;
                case MassUnits.Pound:
                    //Console.WriteLine($"{targetUnit} : {valueToConvert * 2204.62262185}");
                    return valueToConvert * 2204.62262185;
                case MassUnits.Ounce:
                    return valueToConvert*35273.9619;
                default:
                    return null;
            }
        }
    }
}
