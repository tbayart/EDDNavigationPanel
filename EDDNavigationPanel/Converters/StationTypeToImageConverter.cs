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

            var stationType = (StationType)value;
            if (stationType == StationType.Ocellus || stationType == StationType.Orbis || stationType == StationType.AsteroidBase)
                stationType = StationType.Coriolis;
            else if (stationType == StationType.MegaShip)
                stationType = StationType.FleetCarrier;

            return new Uri($"pack://application:,,,/EDDNavigationPanel;component/Resources/LandingPads{stationType}.png");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
