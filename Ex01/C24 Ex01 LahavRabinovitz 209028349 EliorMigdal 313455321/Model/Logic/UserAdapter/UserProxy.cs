using FacebookWrapper.ObjectModel;
using Model.Logic.UserProxy.UserItemsAdapter;
using Model.Logic.UserProxy.UserItemsAdapter.Types;
using System.Collections.Generic;

namespace Model.Logic.UserProxy
{
    public class UserProxy
    {
        private User m_UserData;

        public User UserData 
        { 
            get
            {
                return m_UserData;
            }

            set
            {
                if (m_UserData != value)
                {
                    m_UserData = value;
                    initializeUserData();
                }
            }
        }

        public List<IUserCollectionsAdapter> UserItems { get; set; } = new List<IUserCollectionsAdapter>();
        public string ProfilePicture { get; set; }

        private void initializeUserData()
        {
            UserItems.Clear();

            UserItems.Add(new UserEventsAdapter(UserData));
            UserItems.Add(new UserAlbumsAdapter(UserData));
            UserItems.Add(new UserLikedPagesAdapter(UserData));
            UserItems.Add(new UserFriendsAdapter(UserData));
        }
    }
}