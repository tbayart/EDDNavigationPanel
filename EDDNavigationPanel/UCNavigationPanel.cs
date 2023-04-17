using EDDNavigationPanel.ViewModels;
using QuickJSON;
using System;
using System.Drawing;
using System.Windows.Forms;
using static EDDDLLInterfaces.EDDDLLIF;

namespace EDDNavigationPanel
{
    public partial class UCNavigationPanel : UserControl, IEDDPanelExtension
    {
        #region fields
        private const string _helpAddress = @"https://github.com/tbayart/EDDNavigationPanel";
        private readonly EDEventHandlers _edEventHandlers;
        private EDDPanelCallbacks _panelCallbacks;
        #endregion fields

        #region ctor
        public UCNavigationPanel()
        {
            InitializeComponent();
            // prevent double resizing
            AutoScaleMode = AutoScaleMode.Inherit;
            _edEventHandlers = new EDEventHandlers();
            ViewModelManager.RegisterViewModelSetter(vm => _ucContentControl.DataContext = vm);
        }
        #endregion ctor

        #region IEDDPanelExtension
        public bool SupportTransparency => true;

        public bool DefaultTransparent => false;

        public void Initialise(EDDPanelCallbacks panelCallbacks, int displayid, string themeasjson, string configuration)
        {
            NavigationPanelEDDClass.DLLCallBack.WriteToLogHighlight("UCNavigationPanel initialising");
            _panelCallbacks = panelCallbacks;
            ThemeChanged(themeasjson);
            NavigationPanelEDDClass.DLLCallBack.WriteToLogHighlight("UCNavigationPanel initialised");
        }

        public void SetTransparency(bool isEnabled, Color curcol)
        {
            BackColor = curcol;
        }

        public void LoadLayout() => _panelCallbacks.SetControlText("EDD Navigation Panel!");

        public void InitialDisplay()
        {
        }

        void IEDDPanelExtension.CursorChanged(JournalEntry je)
        {
        }

        public void Closing() { }

        public bool AllowClose() => true;

        public string HelpKeyOrAddress() => _helpAddress;

        public void ControlTextVisibleChange(bool on) { }

        public void HistoryChange(int count, string commander, bool beta, bool legacy)
        {
        }

        public void NewUnfilteredJournal(JournalEntry je)
        {
            try
            {
                var jData = JToken.Parse(je.json);
                _edEventHandlers.Invoke($"On{jData["event"].Str()}Event", this, jData, je);
            }
            catch (Exception ex)
            {
                ex.Log();
            }
        }

        public void NewFilteredJournal(JournalEntry je)
        {
        }

        public void NewUIEvent(string jsonui)
        {
        }

        public void NewTarget(Tuple<string, double, double, double> target)
        {
        }

        public void ScreenShotCaptured(string file, Size s)
        {
        }

        public void ThemeChanged(string themeasjson)
        {
        }
        #endregion IEDDPanelExtension
    }
}
