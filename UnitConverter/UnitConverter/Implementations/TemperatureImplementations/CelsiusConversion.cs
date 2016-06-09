using System;
using UnitConverter.CoversionResults;
using UnitConverter.UnitTypes;


namespace UnitConverter.Implementations.TemperatureImplementations
{
    public class CelsiusConversion : IConvertor<TemperatureUnits>
    {
        public double? ConvertUnit(TemperatureUnits targetUnit, double valueToConvert)
        {
            var result = new TempConversionResult
            {
                CurrentUnit = TemperatureUnits.Celsius,
                TargetUnit = targetUnit
            };

            switch (targetUnit)
            {
                case TemperatureUnits.Celsius:
                    //Console.WriteLine($"{targetUnit} : {valueToConvert}");
                    return valueToConvert;
                case TemperatureUnits.Kelvin:
                    //Console.WriteLine($"{targetUnit} : {valueToConvert+273.15}");
                    return valueToConvert + 273.15;
                case TemperatureUnits.Fahrenheit:
                    return (valueToConvert*1.8) + 32;
                default:
                    return null;
            }

        }
    }
}
