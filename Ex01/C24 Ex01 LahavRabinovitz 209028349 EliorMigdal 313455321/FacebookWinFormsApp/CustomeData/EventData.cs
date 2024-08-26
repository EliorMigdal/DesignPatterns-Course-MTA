using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using System.IO;
using BasicFacebookFeatures.Logic.UserWrapper.UserItemsWrapper.Types.ItemWrapper;

namespace BasicFacebookFeatures.CustomeData
{
    public class EventData : IUserItemWrapper
    {
        public class Attendee
        {
            public string Name { get; set; }
            public bool IsAttending { get; set; }
        }

        public string Name { get; set; }
        public string Picture { get; set; }
        public string HostName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public List<Attendee> Attendees { get; set; }

        public class Root
        {
            public List<EventData> Events { get; set; }
        }

        public static List<EventData> LoadEventData()
        {
            Root eventData = new Root();

            string filePath = "\\\\Mac\\iCloud\\Windows Shared Directory\\DesignPatterns-Course-MTA\\Ex01\\C24 Ex01 LahavRabinovitz 209028349 EliorMigdal 313455321\\FacebookWinFormsApp\\Resources\\eventData.json";

            if (File.Exists(filePath))
            {
                using (StreamReader streamReader = new StreamReader(filePath))
                using (JsonTextReader jsonReader = new JsonTextReader(streamReader))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    eventData = serializer.Deserialize<Root>(jsonReader);
                }
            }

            return eventData.Events;
        }
    }
}