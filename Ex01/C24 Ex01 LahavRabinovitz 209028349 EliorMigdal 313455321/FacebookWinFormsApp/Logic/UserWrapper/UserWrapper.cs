using FacebookWrapper.ObjectModel;
using BasicFacebookFeatures.Logic.UserWrapper.UserItemsWrapper;
using BasicFacebookFeatures.Logic.UserWrapper.UserItemsWrapper.Types;
using System.Collections.Generic;

namespace BasicFacebookFeatures.Logic.UserWrapper
{
    public class UserWrapper
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
        public List<IUserCollectionsWrapper> UserItems { get; set; } = new List<IUserCollectionsWrapper>();
        public string ProfilePicture { get; set; }

        private void initializeUserData()
        {
            UserItems.Clear();
            UserItems.Add(new UserEventsWrapper(UserData.Events));
            UserItems.Add(new UserAlbumsWrapper(UserData.Albums));
            UserItems.Add(new UserLikedPagesWrapper(UserData.LikedPages));
        }
    }
}