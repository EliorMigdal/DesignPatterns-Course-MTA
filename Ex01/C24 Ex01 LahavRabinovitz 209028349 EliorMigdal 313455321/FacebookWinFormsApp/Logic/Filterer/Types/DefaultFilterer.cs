using BasicFacebookFeatures.Logic.UserWrapper.UserItemsWrapper.Types.ItemWrapper.Types;

namespace BasicFacebookFeatures.Logic.Filterer.Types
{
    public class DefaultFilterer : IFilterer<PostWrapper>
    {
        public string Name => "Default";

        public bool Filter(PostWrapper i_Obj)
        {
            return true;
        }
    }
}