using FacebookWrapper.ObjectModel;
using BasicFacebookFeatures.Logic.UserProxy.UserItemsAdapter;
using BasicFacebookFeatures.Logic.UserProxy.UserItemsAdapter.Types;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using BasicFacebookFeatures.CustomeData;

namespace BasicFacebookFeatures.Logic.UserProxy
{
    public class UserProxy
    {
        private User m_UserData;
        private readonly object r_UserItemsContext = new object();

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
                }
            }
        }

        public List<IUserCollectionsAdapter> UserItems { get; set; } = new List<IUserCollectionsAdapter>();
        public string ProfilePicture { get; set; }

        public void InitializeUserEvents()
        {
            UserEventsAdapter eventsData = new UserEventsAdapter(UserData.Events);
            lock (r_UserItemsContext)
            {
                UserItems.Add(eventsData);
            }
        }

        public void InitializeUserAlbums()
        {
            UserAlbumsAdapter albumsData = new UserAlbumsAdapter(new Collection<Album>(UserData.Albums
                                                                 .Where(album => album.Photos.Count > 0)
                                                                 .ToList()));
            lock (r_UserItemsContext)
            {
                UserItems.Add(albumsData);
            }
        }

        public void InitializeUserLikedPages()
        {
            UserLikedPagesAdapter likedPagesData = new UserLikedPagesAdapter(UserData.LikedPages);
            lock (r_UserItemsContext)
            {
                UserItems.Add(likedPagesData);
            }
        }

        public void InitializeUserFriends()
        {
            UserFriendsAdapter friendsData = new UserFriendsAdapter(Friend.LoadFriends());
            lock (r_UserItemsContext)
            { 
                UserItems.Add(friendsData);
            }
        }
    }
}