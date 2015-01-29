using System;
using System.ComponentModel;
using DemoCommon;

namespace _06bTypeConverters.Models
{
    [TypeConverter(typeof(DemoVector))]
    public class DemoVectorConverter : TypeConverter 
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return false;
        }

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof (string) || base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            var source = value as string;
            DemoVector vector;

            return DemoVector.TryParse(source, out vector) ? vector : 
                base.ConvertFrom(context, culture, value);
        }
    }
}