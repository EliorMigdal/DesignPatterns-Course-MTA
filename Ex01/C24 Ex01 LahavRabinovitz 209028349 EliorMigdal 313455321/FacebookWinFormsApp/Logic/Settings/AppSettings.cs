using System.IO;
using System.Xml.Serialization;

namespace BasicFacebookFeatures.Logic.Settings
{
    public sealed class AppSettings
    {
        private static readonly object rm_CreationLockContext = new object();
        private static AppSettings m_Instance;
        public static AppSettings Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    lock (rm_CreationLockContext)
                    {
                        if (m_Instance == null)
                        {
                            m_Instance = new AppSettings();
                        }
                    }
                }

                return m_Instance;
            }
        }

        public bool RememberUser { get; set; } = false;
        public string Token { get; set; } = string.Empty;

        private AppSettings() { }

        public void SaveToFile()
        {
            using (Stream stream = new FileStream("appSettings.xml", FileMode.Create))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(AppSettings));
                xmlSerializer.Serialize(stream, this);
            }
        }

        public static AppSettings LoadFromFile()
        {
            AppSettings appSettings = new AppSettings();

            if (File.Exists("appSettings.xml"))
            {
                using (Stream stream = new FileStream("appSettings.xml", FileMode.Open))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(AppSettings));
                    appSettings = xmlSerializer.Deserialize(stream) as AppSettings;
                }
            }

            return appSettings;
        }
    }
}