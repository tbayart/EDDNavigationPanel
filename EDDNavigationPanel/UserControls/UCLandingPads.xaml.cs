using EDDNavigationPanel.Models;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace EDDNavigationPanel.UserControls
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UCLandingPads : UserControl
    {
        private readonly Lazy<LandingPadsCoords> _landingPadsCoords;

        public UCLandingPads()
        {
            InitializeComponent();
            _landingPadsCoords = new Lazy<LandingPadsCoords>();
        }

        /// <summary>
        /// Initializes and show the landing pad for a station's type.
        /// </summary>
        /// <param name="stationType">The station's type.</param>
        /// <param name="padNumber">The pad number.</param>
        public void Update(StationType stationType, int padNumber)
        {
            if (padNumber < 1)
            {
                LandingPadIcon.Visibility = Visibility.Hidden;
                return;
            }

            // docking time = 10mn ?
            if (stationType == StationType.Ocellus || stationType == StationType.Orbis || stationType == StationType.AsteroidBase)
                stationType = StationType.Coriolis;
            else if (stationType == StationType.MegaShip)
                stationType = StationType.FleetCarrier;

            LandingPadsImage.Source = StationTypeImageSource(stationType);
            UpdateLayout();

            // resize LandingPadIcon relative to the background scale
            LandingPadIcon.Width = DesiredSize.Width * 0.08;
            LandingPadIcon.Height = DesiredSize.Height * 0.08;

            // get landing pad coordinates for the stationType
            var coords = _landingPadsCoords.Value.Get(stationType, padNumber);
            // calculate center
            var centerX = ActualWidth * 0.5;
            var centerY = ActualHeight * 0.5;
            // calculate left and top coordinates for LandingPadIcon
            coords.X = centerX + coords.X * DesiredSize.Width;
            coords.Y = centerY + coords.Y * DesiredSize.Height;
            var left = coords.X - LandingPadIcon.Width * 0.5;
            var top = coords.Y - LandingPadIcon.Height * 0.5;
            Canvas.SetLeft(LandingPadIcon, left);
            Canvas.SetTop(LandingPadIcon, top);

            // ensure icon is visible
            LandingPadIcon.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Load the image for the provided <see cref="StationType"/>.
        /// </summary>
        /// <param name="stationType">The station's type.</param>
        /// <returns>A <see cref="ImageSource"/> instance.</returns>
        private ImageSource StationTypeImageSource(StationType stationType)
        {
            var uri = new Uri($"pack://application:,,,/EDDNavigationPanel;component/Resources/LandingPads{stationType}.png");
            return new System.Windows.Media.Imaging.BitmapImage(uri);
        }

        private void Log(string message)
        {
            System.Diagnostics.Debug.WriteLine(message);
        }
    }
}
