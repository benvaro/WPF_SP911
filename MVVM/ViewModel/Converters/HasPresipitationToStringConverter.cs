using System;
using System.Globalization;
using System.Windows.Data;

namespace MVVM.ViewModel.Converters
{
    public class HasPresipitationToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var boolData = System.Convert.ToBoolean(value);

            return boolData ? "Yes" : "No";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var data = value as string;
            return value == "Yes" ? true : false;
        }
    }
}
