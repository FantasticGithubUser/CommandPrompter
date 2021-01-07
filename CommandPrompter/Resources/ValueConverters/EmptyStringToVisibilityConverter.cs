using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;

namespace CommandPrompter.Resources
{
    public class EmptyStringToVisibilityConverter : BaseValueConverter<EmptyStringToVisibilityConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var str = (string)value;
            if (string.IsNullOrEmpty(str))
                return Visibility.Collapsed;
            return Visibility.Visible;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
