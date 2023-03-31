using EDDNavigationPanel.Models;
using QuickJSON;
using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using static EDDDLLInterfaces.EDDDLLIF;

namespace EDDNavigationPanel
{
    public partial class UCNavigationPanel : UserControl, IEDDPanelExtension
    {
        private EDDPanelCallbacks _panelCallbacks;

        public UCNavigationPanel()
        {
            InitializeComponent();
            // prevent double resizing
            AutoScaleMode = AutoScaleMode.Inherit;
        }

        public bool SupportTransparency => true;

        public bool DefaultTransparent => false;

        public bool AllowClose() => true;

        public void Closing()
        {
        }

        public void ControlTextVisibleChange(bool on)
        {
        }

        public string HelpKeyOrAddress()
        {
            return @"https://github.com/tbayart/EDDNavigationPanel";
        }

        public void HistoryChange(int count, string commander, bool beta, bool legacy)
        {
        }

        public void InitialDisplay()
        {
        }

        public void Initialise(EDDPanelCallbacks panelCallbacks, int displayid, string themeasjson, string configuration)
        {
            NavigationPanelEDDClass.DLLCallBack.WriteToLogHighlight("UCNavigationPanel initialising");
            _panelCallbacks = panelCallbacks;
            ThemeChanged(themeasjson);
            NavigationPanelEDDClass.DLLCallBack.WriteToLogHighlight("UCNavigationPanel initialised");
        }

        public void LoadLayout()
        {
            _panelCallbacks.SetControlText("Ext Panel!");
        }

        public void NewFilteredJournal(JournalEntry je)
        {
        }

        public void NewTarget(Tuple<string, double, double, double> target)
        {
        }

        public void NewUIEvent(string jsonui)
        {
        }

        public void NewUnfilteredJournal(JournalEntry je)
        {
            try
            {
                if (je.name == "Docking Granted")
                {
                    var jData = JToken.Parse(je.json);
                    var StationName = jData["StationName"].Str();
                    var padNumber = jData["LandingPad"].Int();
                    var stationType = (StationType)Enum.Parse(typeof(StationType), jData["StationType"].Str());
                    ucLandingPads.Update(stationType, padNumber);

                }
            }
            catch (Exception ex)
            {
                Log(ex.ToString());
            }
        }

        public void ScreenShotCaptured(string file, Size s)
        {
        }

        public void SetTransparency(bool isEnabled, Color curcol)
        {
            BackColor = curcol;
        }

        public void ThemeChanged(string themeasjson)
        {
        }

        void IEDDPanelExtension.CursorChanged(JournalEntry je)
        {
        }

        private void Log(string message,
            [CallerLineNumber] int lineNumber = 0,
            [CallerMemberName] string caller = null)
        {
            System.Diagnostics.Debug.WriteLine($"{caller}({lineNumber}) {message}");
        }
    }
}
