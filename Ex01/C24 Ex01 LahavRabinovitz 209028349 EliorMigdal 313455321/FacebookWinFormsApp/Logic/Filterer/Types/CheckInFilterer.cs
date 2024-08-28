using BasicFacebookFeatures.Logic.UserWrapper.UserItemsWrapper.Types.ItemWrapper.Types;

namespace BasicFacebookFeatures.Logic.Filterer.Types
{
    public class CheckInFilterer : IFilterer<PostWrapper>
    {
        public string Name => "Check In";

        public bool Filter(PostWrapper i_Obj)
        {
            return i_Obj.PostType.Equals(PostWrapper.ePostType.CheckIn);
        }
    }
}
