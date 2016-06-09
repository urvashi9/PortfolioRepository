using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitConverter.CoversionResults;
using UnitConverter.UnitTypes;


namespace UnitConverter.Implementations.TemperatureImplementations
{
    public class KelvinConversion : IConvertor<TemperatureUnits>
    {
        public double? ConvertUnit(TemperatureUnits targetUnit, double valueToConvert)
        {
            var result = new TempConversionResult
            {
                CurrentUnit = TemperatureUnits.Kelvin,
                TargetUnit = targetUnit
            };

            switch (targetUnit)
            {
                case TemperatureUnits.Kelvin:
                    //Console.WriteLine($"{targetUnit} : {valueToConvert}");
                    return valueToConvert;
                case TemperatureUnits.Celsius:
                    //Console.WriteLine($"{targetUnit} : {valueToConvert - 273.15}");
                    return valueToConvert - 273.15;
                case TemperatureUnits.Fahrenheit:
                    return (valueToConvert - 273.15)*1.8 + 32;
                default:
                    return null;
            }

        }
    }
}
