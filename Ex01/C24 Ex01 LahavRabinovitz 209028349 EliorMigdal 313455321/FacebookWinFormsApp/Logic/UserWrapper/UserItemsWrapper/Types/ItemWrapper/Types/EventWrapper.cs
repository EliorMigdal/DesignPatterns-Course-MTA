using FacebookWrapper.ObjectModel;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using BasicFacebookFeatures.CustomeData;
using System.Collections.Generic;
using BasicFacebookFeatures.Properties;

namespace BasicFacebookFeatures.Logic.UserWrapper.UserItemsWrapper.Types.ItemWrapper.Types
{
    public class EventWrapper : IUserItemWrapper
    {
        public string Name { get; set; }
        public Event Event { get; set; }
        public EventData EventData { get; set; }
        public string Picture { get; set; }

        public EventWrapper(Event i_Event)
        {
            Name = i_Event.Name;
            Event = i_Event;
            Picture = i_Event.PictureNormalURL;
        }

        public EventWrapper(EventData i_CustomeData)
        {
            Name = i_CustomeData.Name;
            EventData = i_CustomeData;
            Picture = i_CustomeData.Picture;
        }
    }
}