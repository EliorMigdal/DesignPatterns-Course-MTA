using BasicFacebookFeatures.CustomeData;

namespace BasicFacebookFeatures.Logic.UserProxy.UserItemsAdapter.Types.ItemAdapter.Types
{
    public class FriendAdapter : IUserItemAdapter
    {
        public string Name { get; set; }

        public string Picture { get; set; }
        
        public Friend Friend { get; set; }

        public FriendAdapter(Friend i_Friend)
        {
            Friend = i_Friend;
            Name = i_Friend.Name;
            Picture = i_Friend.ProfilePicture;
        }
    }
}
