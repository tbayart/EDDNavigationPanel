using EDDDLLInterfaces;
using EDDNavigationPanel.Models;
using QuickJSON;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PanelTester
{
    public partial class DockingTester : Form
    {
        public DockingTester()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            // fill StationType ComboBox control
            stationType.Items.Clear();
            foreach (var value in Enum.GetValues(typeof(StationType)))
                stationType.Items.Add((StationType)value);
            // default to first StationType in the control
            stationType.SelectedItem = stationType.Items[0];
        }

        public override Size GetPreferredSize(Size proposedSize)
        {
            return base.GetPreferredSize(proposedSize);
        }

        private StationType StationType { get => (StationType)stationType.SelectedItem; }

        private void padNumber_ValueChanged(object sender, EventArgs e) => UpdateControl();

        private void stationType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (StationType)
            {
                case StationType.Coriolis:
                case StationType.Ocellus:
                case StationType.Orbis:
                case StationType.AsteroidBase:
                    padNumber.Maximum = 45;
                    break;
                case StationType.Outpost:
                    padNumber.Maximum = 5;
                    break;
                case StationType.CraterOutpost:
                    padNumber.Maximum = 12;
                    break;
                case StationType.MegaShip:
                case StationType.CraterPort:
                case StationType.FleetCarrier:
                    padNumber.Maximum = 16;
                    break;
            }
            padNumber.Value = Math.Min(padNumber.Value, padNumber.Maximum);
            UpdateControl();
        }

        private EDDDLLIF.JournalEntry DockingGranted(StationType stationType, string stationName, int padNumber)
        {
            var jsonString = new JObject
                {
                    ["event"] = "DockingGranted",
                    ["StationName"] = stationName,
                    ["StationType"] = stationType.ToString(),
                    ["LandingPad"] = padNumber,
                }
                .ToString();
            return new EDDDLLIF.JournalEntry
            {
                name = "Docking Granted",
                json = jsonString
            };
        }

        private void UpdateControl()
        {
            var je = DockingGranted(StationType, "Fake Station", (int)padNumber.Value);
            ucNavigationPanel.NewUnfilteredJournal(je);
        }

        private void buttonRefresh_Click(object sender, EventArgs e) => UpdateControl();
    }
}
