using System.IO;
using System.Xml.Serialization;

namespace Model.Logic.Settings
{
    public sealed class AppSettings
    {
        public bool RememberUser { get; set; } = false;
        public string Token { get; set; } = string.Empty;
        private static readonly string sr_FileName = "appSettings.xml";
        private static AppSettings s_Instance;

        private AppSettings() { }

        public void SaveToFile()
        {
            using (Stream stream = new FileStream(sr_FileName, FileMode.Create))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(AppSettings));
                xmlSerializer.Serialize(stream, this);
            }
        }

        public static AppSettings LoadAppSettings()
        {
            if (s_Instance == null)
            {
                if (File.Exists(sr_FileName))
                {
                    using (Stream stream = new FileStream(sr_FileName, FileMode.Open))
                    {
                        XmlSerializer xmlSerializer = new XmlSerializer(typeof(AppSettings));
                        s_Instance = xmlSerializer.Deserialize(stream) as AppSettings;
                    }
                }

                else
                {
                    s_Instance = new AppSettings();
                }
            }

            return s_Instance;
        }
    }
}