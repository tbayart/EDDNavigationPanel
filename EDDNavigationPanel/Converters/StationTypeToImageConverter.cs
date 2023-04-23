using EDDNavigationPanel.Models;
using System;
using System.Globalization;
using System.Windows.Data;

namespace EDDNavigationPanel.Converters
{
    internal class StationTypeToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not StationType)
                return Binding.DoNothing;

            return new Uri($"pack://application:,,,/EDDNavigationPanel;component/Resources/LandingPads{value}.png");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
