using FacebookWrapper.ObjectModel;
using BasicFacebookFeatures.CustomeData;

namespace BasicFacebookFeatures.Logic.UserProxy.UserItemsAdapter.Types.ItemAdapter.Types
{
    public class EventAdapter : IUserItemAdapter
    {
        public string Name { get; set; }
        public Event Event { get; set; }
        public EventData EventData { get; set; }
        public string Picture { get; set; }

        public EventAdapter(Event i_Event)
        {
            Name = i_Event.Name;
            Event = i_Event;
            Picture = i_Event.PictureNormalURL;
        }

        public EventAdapter(EventData i_CustomeData)
        {
            Name = i_CustomeData.Name;
            EventData = i_CustomeData;
            Picture = i_CustomeData.Picture;
        }
    }
}