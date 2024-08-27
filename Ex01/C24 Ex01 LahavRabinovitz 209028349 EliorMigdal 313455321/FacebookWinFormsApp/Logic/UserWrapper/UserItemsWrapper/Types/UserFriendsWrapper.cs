using BasicFacebookFeatures.CustomeData;
using BasicFacebookFeatures.Logic.UserWrapper.UserItemsWrapper.Types.ItemWrapper;
using BasicFacebookFeatures.Logic.UserWrapper.UserItemsWrapper.Types.ItemWrapper.Types;
using System;
using System.Collections.ObjectModel;


namespace BasicFacebookFeatures.Logic.UserWrapper.UserItemsWrapper.Types
{
    public class UserFriendsWrapper : IUserCollectionsWrapper
    {
        public string Name => "Friends";

        public Collection<IUserItemWrapper> ItemWrapperCollection => throw new NotImplementedException();

        public UserFriendsWrapper(Collection<Friend> i_Friends)
        {
            foreach (Friend friend in i_Friends)
            {
                ItemWrapperCollection.Add(new FriendWrapper(friend));
            }
        }
    }
}
