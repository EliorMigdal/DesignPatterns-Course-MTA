using System.IO;
using System.Xml.Serialization;

namespace BasicFacebookFeatures.Logic.Settings
{
    public sealed class AppSettings
    {
        public bool RememberUser { get; set; } = false;
        public string Token { get; set; } = string.Empty;
        private static readonly string rm_FileName = "appSettings.xml";

        private AppSettings() { }

        public void SaveToFile()
        {
            using (Stream stream = new FileStream(rm_FileName, FileMode.Create))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(AppSettings));
                xmlSerializer.Serialize(stream, this);
            }
        }

        public static AppSettings LoadFromFile()
        {
            AppSettings appSettings = new AppSettings();

            if (File.Exists(rm_FileName))
            {
                using (Stream stream = new FileStream(rm_FileName, FileMode.Open))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(AppSettings));
                    appSettings = xmlSerializer.Deserialize(stream) as AppSettings;
                }
            }

            return appSettings;
        }
    }
}