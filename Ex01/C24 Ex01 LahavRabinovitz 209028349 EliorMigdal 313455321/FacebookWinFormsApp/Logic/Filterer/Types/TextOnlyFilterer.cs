using BasicFacebookFeatures.Logic.UserWrapper.UserItemsWrapper.Types.ItemWrapper.Types;
using System;

namespace BasicFacebookFeatures.Logic.Filterer.Types
{
    public class TextOnlyFilterer : IFilterer<PostWrapper>
    {
        public string Name => "Text Only";

        public bool Filter(PostWrapper i_Obj)
        {
            return i_Obj.PostType.Equals(PostWrapper.ePostType.Text);
        }
    }
}
