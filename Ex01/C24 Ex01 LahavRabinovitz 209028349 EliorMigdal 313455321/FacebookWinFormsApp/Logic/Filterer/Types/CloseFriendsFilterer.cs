using BasicFacebookFeatures.Logic.UserWrapper.UserItemsWrapper.Types.ItemWrapper.Types;
using System;

namespace BasicFacebookFeatures.Logic.Filterer.Types
{
    public class CloseFriendsFilterer : IFilterer<PostWrapper>
    {
        public string Name => "Close Friends";

        public bool Filter(PostWrapper i_Obj)
        {
            return i_Obj.PostType.Equals(PostWrapper.ePostType.CloseFriends);
        }
    }
}
