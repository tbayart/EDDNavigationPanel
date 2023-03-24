namespace EDDNavigationPanel
{
    public class NavigationPanelEDDClass
    {
        private const string _panelDescription = "Navigation Panel help CMDRs navigating the galaxy.";

        public NavigationPanelEDDClass()
        {
            System.Diagnostics.Debug.WriteLine("NavigationPanelEDDClass instanciated");
        }

        public static EDDDLLInterfaces.EDDDLLIF.EDDCallBacks DLLCallBack { get; private set; }

        public string EDDInitialise(string vstr, string dllfolder, EDDDLLInterfaces.EDDDLLIF.EDDCallBacks dllCallback)
        {
            DLLCallBack = dllCallback;
            System.Diagnostics.Debug.WriteLine("NavigationPanelEDDClass EDDInitialise " + vstr + " " + dllfolder);

            if (dllCallback.ver >= 3 && dllCallback.AddPanel != null)
            {
                dllCallback.AddPanel("NavigationPanel-0.1", typeof(UCNavigationPanel), "Navigation Panel", "NavigationPanel", _panelDescription, ResourcesManager.PanelIcon);
            }

            return "1.0.0.0";
        }

        public void EDDTerminate()
        {
            System.Diagnostics.Debug.WriteLine("EDDNavigationPanel EDDTerminate");
        }
    }
}