using EDDNavigationPanel.Models;
using System;
using System.Drawing;
using System.IO;
using System.Windows;

namespace EDDNavigationPanel
{
    public static class ResourcesManager
    {
        private readonly static Lazy<LandingPadsCoords> _landingPadsCoords;

        static ResourcesManager()
        {
            _landingPadsCoords = new Lazy<LandingPadsCoords>();
        }

        public static Image PanelIcon
        {
            get
            {
                using var stream = GetResourceStream("PanelIcon.png");
                return Image.FromStream(stream);
            }
        }

        public static Vector GetCoords(this StationType stationType, int padNumber)
        {
            return _landingPadsCoords.Value.Get(stationType, padNumber);
        }

        public static byte[] GetResourceData(string resourceName)
        {
            using (var resourceStream = GetResourceStream(resourceName))
            using (var memoryStream = new MemoryStream())
            {
                resourceStream.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }

        public static Stream GetResourceStream(string resourceName)
        {
            var type = typeof(NavigationPanelEDDClass);
            resourceName = string.Join(".", type.Namespace, "Resources", resourceName).Replace("\\", ".");
            return type.Assembly.GetManifestResourceStream(resourceName);
        }
    }
}
