using BasicFacebookFeatures.Logic.UserWrapper.UserItemsWrapper.Types.ItemWrapper.Types;

namespace BasicFacebookFeatures.Logic.Filterer.Types
{
    public class ImagePostFilterer : IFilterer<PostWrapper>
    {
        public string Name => "Image Post";

        public bool Filter(PostWrapper i_Obj)
        {
            return i_Obj.PostType.Equals(PostWrapper.ePostType.Image);
        }
    }
}