using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace CommandPrompter.Resources
{
    public class WidthToActualPageWidth : BaseValueConverter<WidthToActualPageWidth>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (double)value - 5;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
