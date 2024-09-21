using BasicFacebookFeatures.CustomeData;
using BasicFacebookFeatures.Logic.UserProxy.UserItemsAdapter.Types.ItemAdapter;
using BasicFacebookFeatures.Logic.UserProxy.UserItemsAdapter.Types.ItemAdapter.Types;
using FacebookWrapper.ObjectModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BasicFacebookFeatures.Logic.UserProxy.UserItemsAdapter.Types
{
    public class UserEventsAdapter : IUserCollectionsAdapter
    {
        public string Name => "Events";
        private readonly Collection<Event> r_Events;
        private readonly Collection<IUserItemAdapter> r_EventsCollection = new Collection<IUserItemAdapter>();

        public Collection<IUserItemAdapter> ItemAdapterCollection
        {
            get
            {
                if (r_Events.Count ==0 && r_EventsCollection.Count == 0)
                {
                    addCustomeData();
                }
                else
                {
                    foreach (Event userEvent in r_Events)
                    {
                        ItemAdapterCollection.Add(new EventAdapter(userEvent));
                    } 
                }

                return r_EventsCollection;
            }
        }

        public UserEventsAdapter(Collection<Event> i_Events)
        {
            r_Events = i_Events;
        }

        private void addCustomeData()
        {
            List<EventData> customeDataList = EventData.LoadEventData();

            foreach (EventData customeData in customeDataList)
            {
                ItemAdapterCollection.Add(new EventAdapter(customeData));
            }
        }
    }
}