using BasicFacebookFeatures.CustomeData;
using BasicFacebookFeatures.Logic.UserProxy.UserItemsAdapter.Types.ItemAdapter;
using BasicFacebookFeatures.Logic.UserProxy.UserItemsAdapter.Types.ItemAdapter.Types;
using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace BasicFacebookFeatures.Logic.UserProxy.UserItemsAdapter.Types
{
    public class UserFriendsAdapter : IUserCollectionsAdapter
    {
        public string Name => "Friends";
        private readonly List<Friend> r_Friends;
        private readonly Collection<IUserItemAdapter> r_FriendsCollection = new Collection<IUserItemAdapter>();

        public Collection<IUserItemAdapter> ItemAdapterCollection 
        {  
            get
            {
                if(r_Friends.Count == 0 && r_FriendsCollection.Count == 0)
                {
                    foreach (Friend friend in r_Friends)
                    {
                        r_FriendsCollection.Add(new FriendAdapter(friend));
                    }

                }

                return r_FriendsCollection;
            }
        }

        public UserFriendsAdapter(List<Friend> i_Friends)
        {
            r_Friends = i_Friends;
        }
    }
}
