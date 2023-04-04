using EDDDLLInterfaces;
using EDDNavigationPanel.Models;
using QuickJSON;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PanelTester
{
    public partial class NavigationPanelTester : Form
    {
        public NavigationPanelTester()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            listView.Items.Add("DockingGranted");
            listView.ItemSelectionChanged += ListView_ItemSelectionChanged;
        }

        private void ListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            var jsonString = new JObject
            {
                ["event"] = "DockingGranted",
                ["StationName"] = "station name",
                ["StationType"] = StationType.FleetCarrier.ToString(),
                ["LandingPad"] = new Random().Next(1, 16),
            }.ToString();

            //tabControl.SelectedTab.Text;
            ucNavigationPanel.NewUnfilteredJournal(new EDDDLLIF.JournalEntry { name = "Docking Granted", json = jsonString });
        }
    }
}
