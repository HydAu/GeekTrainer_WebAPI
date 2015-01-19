using System;
using System.ComponentModel;
using DemoCommon;

namespace _06bTypeConverters.Models
{
    [TypeConverter(typeof(DemoVector))]
    public class DemoVectorConverter : TypeConverter 
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof (string) || base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            var source = value as string;
            
            if (string.IsNullOrWhiteSpace(source))
            {
                return base.ConvertFrom(context, culture, value);
            }
            
            var coordinates = source.Split('|');
                
            if (coordinates.Length != 6)
            {
                return base.ConvertFrom(context, culture, value);
            }
                
            var coordinatesParsed = new double[6];
            var allGood = true;
            var x = 0;
            while (x < 6 && allGood)
            {
                double coordParsed;
                if (double.TryParse(coordinates[x], out coordParsed))
                {
                    coordinatesParsed[x] = coordParsed;
                    x++;
                }
                else
                {
                    allGood = false;
                }
            }
            if (allGood)
            {
                return new DemoVector
                {
                    Origin = new DemoPoint
                    {
                        X = coordinatesParsed[0],
                        Y = coordinatesParsed[1],
                        Z = coordinatesParsed[2]
                    },
                    Direction = new DemoPoint
                    {
                        X = coordinatesParsed[3],
                        Y = coordinatesParsed[4],
                        Z = coordinatesParsed[5]
                    }
                };
            }
            return base.ConvertFrom(context, culture, value);
        }
    }
}