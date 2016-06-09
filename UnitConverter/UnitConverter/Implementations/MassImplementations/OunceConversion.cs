using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitConverter.CoversionResults;
using UnitConverter.UnitTypes;


namespace UnitConverter.Implementations.MassImplementations
{
    public class OunceConversion : IConvertor<MassUnits>
    {
        public double? ConvertUnit(MassUnits targetUnit, double valueToConvert)
        {
            var result = new MassCoversionResult()
            {
                CurrentUnit = MassUnits.Ounce,
                TargetUnit = targetUnit
            };           

            switch (targetUnit)
            {
                case MassUnits.Ounce:
                    //Console.WriteLine($"{targetUnit} : {valueToConvert}");
                    return valueToConvert;
                case MassUnits.Kilogram:
                    //Console.WriteLine($"{targetUnit} : {valueToConvert * 0.02834952}");
                    return valueToConvert * 0.02834952;
                case MassUnits.Ton:
                    //Console.WriteLine($"{targetUnit} : {valueToConvert / 35273.9619}");
                    return valueToConvert / 35273.9619;
                case MassUnits.Pound:
                    return valueToConvert/16;
                default:
                    return null;
            }
        }
    }
}
