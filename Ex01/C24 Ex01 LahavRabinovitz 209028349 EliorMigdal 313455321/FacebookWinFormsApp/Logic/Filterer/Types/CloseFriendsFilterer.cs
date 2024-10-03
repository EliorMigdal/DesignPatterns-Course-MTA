using BasicFacebookFeatures.Logic.UserProxy.UserItemsAdapter.Types.ItemAdapter.Types;

namespace BasicFacebookFeatures.Logic.Filterer.Types
{
    public class CloseFriendsFilterer : IFilterer<PostAdapter>
    {
        public string Name => "Close Friends";

        public bool Filter(PostAdapter i_Obj)
        {
            return i_Obj.PostType.Equals(PostAdapter.ePostType.CloseFriends);
        }
    }
}