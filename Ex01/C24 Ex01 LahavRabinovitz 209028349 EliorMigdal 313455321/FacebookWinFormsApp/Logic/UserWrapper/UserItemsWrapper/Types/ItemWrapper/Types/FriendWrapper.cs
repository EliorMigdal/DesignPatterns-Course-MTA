using BasicFacebookFeatures.CustomeData;

namespace BasicFacebookFeatures.Logic.UserWrapper.UserItemsWrapper.Types.ItemWrapper.Types
{
    public class FriendWrapper : IUserItemWrapper
    {
        public string Name { get; set; }

        public string Picture { get; set; }
        
        public Friend Friend { get; set; }

        public FriendWrapper(Friend i_Friend)
        {
            Friend = i_Friend;
            Name = i_Friend.Name;
            Picture = i_Friend.ProfilePicture;
        }
    }
}
