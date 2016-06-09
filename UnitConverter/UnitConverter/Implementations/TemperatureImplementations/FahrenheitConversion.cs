using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitConverter.CoversionResults;
using UnitConverter.UnitTypes;


namespace UnitConverter.Implementations.TemperatureImplementations
{
    public class FahrenheitConversion : IConvertor<TemperatureUnits>
    {
        public double? ConvertUnit(TemperatureUnits targetUnit, double valueToConvert)
        {
            var result = new TempConversionResult
            {
                CurrentUnit = TemperatureUnits.Fahrenheit,
                TargetUnit = targetUnit
            };

            switch (targetUnit)
            {
                case TemperatureUnits.Fahrenheit:
                    //Console.WriteLine($"{targetUnit} : {valueToConvert}");
                    return valueToConvert;
                case TemperatureUnits.Kelvin:
                    //Console.WriteLine($"{targetUnit} : {(valueToConvert - 32) * 5 / 9 + 273.15}");
                    return (valueToConvert - 32) * 5 / 9 + 273.15;
                case TemperatureUnits.Celsius:
                    return (valueToConvert - 32)*5/9;
                default:
                    return null;
            }

        }
    }
}
