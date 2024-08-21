using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BasicFacebookFeatures.Logic
{
    public class AppSettings
    {
        public bool RememberUser { get; set; } = false;
        public string Token { get; set; } = string.Empty;

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
