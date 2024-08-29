using BasicFacebookFeatures.CustomeData;
using BasicFacebookFeatures.Logic.UserWrapper.UserItemsWrapper.Types.ItemWrapper;
using BasicFacebookFeatures.Logic.UserWrapper.UserItemsWrapper.Types.ItemWrapper.Types;
using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace BasicFacebookFeatures.Logic.UserWrapper.UserItemsWrapper.Types
{
    public class UserFriendsWrapper : IUserCollectionsWrapper
    {
        public string Name => "Friends";

        public Collection<IUserItemWrapper> ItemWrapperCollection {  get; set; } = new Collection<IUserItemWrapper>();

        public UserFriendsWrapper(List<Friend> i_Friends)
        {
            foreach (Friend friend in i_Friends)
            {
                ItemWrapperCollection.Add(new FriendWrapper(friend));
            }
        }
    }
}
