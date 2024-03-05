using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Windows.Data;

namespace Emporium.Infrastructure.Extensions
{
    public class EnumDescriptionConverter : IValueConverter
    {
        private static string GetEnumDescription(Enum enumObj)
        {
            FieldInfo fi = enumObj.GetType().GetField(enumObj.ToString());

            if (fi == null)
                return string.Empty;

            var attr = fi.GetCustomAttributes(typeof(DescriptionAttribute), false)
                            .OfType<DescriptionAttribute>()
                            .FirstOrDefault();
            if (attr == null)
                return enumObj.ToString();
            else
                return attr.Description;
        }

        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Enum myEnum = (Enum)value;
            string description = GetEnumDescription(myEnum);
            return description;
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return string.Empty;
        }
    }
}
