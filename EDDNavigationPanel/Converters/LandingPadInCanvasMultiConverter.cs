using EDDNavigationPanel.Models;
using System;
using System.Globalization;
using System.Windows.Data;

namespace EDDNavigationPanel.Converters
{
    internal class LandingPadInCanvasMultiConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length != 4)
                return Binding.DoNothing;

            try
            {

                var rawCoord = (double)values[0];
                var imageSize = (double)values[1];
                var canvasSize = (double)values[2];
                var spinnerSize = (double)values[3];
                var spinnerCenter = spinnerSize * 0.5;
                var center = canvasSize * 0.5;
                return center + rawCoord * imageSize - spinnerCenter;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
            return Binding.DoNothing;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
