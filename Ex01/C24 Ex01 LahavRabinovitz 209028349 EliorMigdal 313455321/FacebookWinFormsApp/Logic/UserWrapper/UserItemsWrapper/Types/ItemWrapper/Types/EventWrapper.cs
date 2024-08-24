using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures.Logic.UserWrapper.UserItemsWrapper.Types.ItemWrapper.Types
{
    public class EventWrapper : IUserItemWrapper
    {
        public string Name { get; set; }
        public Event Event { get; set; }

        public EventWrapper(Event i_Event)
        {
            Event = i_Event;
            Name = i_Event.Name;
        }
    }
}
