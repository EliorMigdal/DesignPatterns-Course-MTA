using Model.CustomeData;
using Model.Logic.UserProxy.UserItemsAdapter.Types.ItemAdapter;
using Model.Logic.UserProxy.UserItemsAdapter.Types.ItemAdapter.Types;
using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Model.Logic.UserProxy.UserItemsAdapter.Types
{
    public class UserFriendsAdapter : IUserCollectionsAdapter
    {
        public string Name => "Friends";
        private readonly User r_UserData;
        private readonly Collection<IUserItemAdapter> r_FriendsCollection = new Collection<IUserItemAdapter>();

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string i_PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(i_PropertyName));
        }

        public Collection<IUserItemAdapter> ItemAdapterCollection 
        {  
            get
            {
                if (r_FriendsCollection.Count == 0)
                {
                    addCustomData();
                }

                return r_FriendsCollection;
            }
        }

        public UserFriendsAdapter(User i_UserData)
        {
            r_UserData = i_UserData;
        }

        private void addCustomData() 
        {
            try
            {
                List<Friend> friends = Friend.LoadFriends();
            
                foreach(Friend friend in friends)
                {
                    r_FriendsCollection.Add(new FriendAdapter(friend));
                }
            }

            catch (Exception)
            {

            }
        }
    }
}