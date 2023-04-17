using EDDNavigationPanel.Models;
using EDDNavigationPanel.Mvvm;
using System.ComponentModel;
using System.Windows;

namespace EDDNavigationPanel.ViewModels
{
    internal class LandingPadsViewModel : ViewModelBase
    {
        public StationType StationType
        {
            get => _stationType;
            private set => SetAndNotify(ref _stationType, value);
        }
        private StationType _stationType;

        public int PadNumber { get; private set; }

        public Vector PadLocation
        {
            get => _padLocation;
            set => SetAndNotify(ref _padLocation, value);
        }
        private Vector _padLocation;

        public void SelectedPad(StationType stationType,int padNumber)
        {
            StationType = stationType;
            PadLocation = stationType.GetCoords(padNumber);
        }
    }

    internal class LandingPadsDesignViewModel: LandingPadsViewModel
    {
        public static object Instance => new LandingPadsDesignViewModel();

        public LandingPadsDesignViewModel()
        {
            SelectedPad(StationType.CraterOutpost, 3);
        }
    }
}
