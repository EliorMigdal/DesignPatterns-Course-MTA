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
        private readonly User m_UserData;
        private readonly Collection<IUserItemAdapter> r_EventsCollection = new Collection<IUserItemAdapter>();

        public Collection<IUserItemAdapter> ItemAdapterCollection
        {
            get
            {
                if (r_EventsCollection.Count == 0)
                {
                    Collection<Event> userEvents = m_UserData.Events;

                    if (userEvents.Count == 0)
                    {
                        addCustomeData();
                    }

                    else
                    {
                        foreach(Event userEvent in userEvents)
                        {
                            r_EventsCollection.Add(new EventAdapter(userEvent));
                        }
                    }
                }

                return r_EventsCollection;
            }
        }

        public UserEventsAdapter(User i_UserData)
        {
            m_UserData = i_UserData;
        }

        private void addCustomeData()
        {
            List<EventData> customeDataList = EventData.LoadEventData();

            foreach (EventData customeData in customeDataList)
            {
                r_EventsCollection.Add(new EventAdapter(customeData));
            }
        }
    }
}