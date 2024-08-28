using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using BasicFacebookFeatures.Logic.UserWrapper.UserItemsWrapper.Types.ItemWrapper;

namespace BasicFacebookFeatures.CustomeData
{
    public class EventData
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
            string fileNameContent = Properties.Resources.eventData;
            Root eventData = JsonConvert.DeserializeObject<Root>(fileNameContent);

            return eventData.Events;
        }
    }
}