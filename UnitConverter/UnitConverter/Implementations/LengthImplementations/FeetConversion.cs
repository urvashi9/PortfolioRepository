using System;
using UnitConverter.CoversionResults;
using UnitConverter.UnitTypes;

namespace UnitConverter.Implementations.LengthImplementations
{
    public class FeetConversion : IConvertor<LengthUnits>
    {
        public double? ConvertUnit(LengthUnits unit, double valueToConvert)
        {
            var conversion = new LengthConversionResult()
            {
                CurrentUnit = LengthUnits.Foot,
                TargetUnit = unit
            };

            //double result;           

            //Console.WriteLine($"Foot : {valueToConvert}");

            switch (unit)
            {
                case LengthUnits.Foot:
                    //Console.WriteLine($"{unit} : {valueToConvert}");
                    return valueToConvert;
                case LengthUnits.Inch:
                    //Console.WriteLine($"{unit} : {valueToConvert * 12}");
                    return valueToConvert*12;
                case LengthUnits.Kilometer:
                    //Console.WriteLine($"{unit} : {valueToConvert * 0.0003048}");
                    return valueToConvert * 0.0003048;
                case LengthUnits.Mile:
                        return valueToConvert / 5280;
                default:
                    return null;
            }
        }
    }
}
