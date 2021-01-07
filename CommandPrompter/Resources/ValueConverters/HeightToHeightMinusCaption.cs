using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace CommandPrompter.Resources
{
    public class HeightToHeightMinusCaption : BaseValueConverter<HeightToHeightMinusCaption>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var height = (double)value;
            return height - 100;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
