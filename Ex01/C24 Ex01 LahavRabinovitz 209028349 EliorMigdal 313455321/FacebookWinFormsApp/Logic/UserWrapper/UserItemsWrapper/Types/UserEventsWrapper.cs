using BasicFacebookFeatures.CustomeData;
using BasicFacebookFeatures.Logic.UserWrapper.UserItemsWrapper.Types.ItemWrapper;
using BasicFacebookFeatures.Logic.UserWrapper.UserItemsWrapper.Types.ItemWrapper.Types;
using FacebookWrapper.ObjectModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BasicFacebookFeatures.Logic.UserWrapper.UserItemsWrapper.Types
{
    public class UserEventsWrapper : IUserCollectionsWrapper
    {
        public string Name => "Events";
        public Collection<IUserItemWrapper> ItemWrapperCollection { get; set; } = new Collection<IUserItemWrapper>();

        public UserEventsWrapper(Collection<Event> i_Events)
        {
            foreach (Event userEvent in i_Events)
            {
                ItemWrapperCollection.Add(new EventWrapper(userEvent));
            }

            if (ItemWrapperCollection.Count == 0)
            {
                addCustomeData();
            }
        }

        private void addCustomeData()
        {
            List<EventData> customeDataList = EventData.LoadEventData();

            foreach (EventData customeData in customeDataList)
            {
                ItemWrapperCollection.Add(new EventWrapper(customeData));
            }
        }
    }
}