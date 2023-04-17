using EDDNavigationPanel.Models;
using EDDNavigationPanel.Mvvm;
using System.ComponentModel;
using System.Windows;

namespace EDDNavigationPanel.ViewModels
{
    internal class LandingPadsViewModel : ViewModelBase
    {
#if DEBUG
        public static object DesignInstance
        {
            get
            {
                var instance = new LandingPadsViewModel();
                instance.SelectedPad(StationType.CraterOutpost, 3);
                return instance;
            }
        }
#endif //DEBUG

        public StationType StationType
        {
            get => _stationType;
            private set => SetAndNotify(ref _stationType, value);
        }
        private StationType _stationType;

        public int PadNumber
        {
            get => _padNumber;
            private set => SetAndNotify(ref _padNumber, value);
        }
        private int _padNumber;

        public Vector PadLocation
        {
            get => _padLocation;
            set => SetAndNotify(ref _padLocation, value);
        }
        private Vector _padLocation;

        public void SelectedPad(StationType stationType, int padNumber)
        {
            StationType = stationType;
            PadNumber = padNumber;
            PadLocation = stationType.GetCoords(padNumber);
        }
    }
}
