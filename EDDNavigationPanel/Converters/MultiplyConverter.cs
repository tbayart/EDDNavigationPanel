using System;
using System.Globalization;
using System.Windows.Data;

namespace EDDNavigationPanel.Converters
{
    internal class MultiplyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not double || parameter is not double)
                return Binding.DoNothing;

            return (double)value * (double)parameter;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
