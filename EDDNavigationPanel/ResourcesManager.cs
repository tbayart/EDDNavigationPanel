using System.Drawing;
using System.IO;

namespace EDDNavigationPanel
{
    public static class ResourcesManager
    {
        public static Image PanelIcon
        {
            get
            {
                using var stream = GetResourceStream("PanelIcon.png");
                return Image.FromStream(stream);
            }
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
