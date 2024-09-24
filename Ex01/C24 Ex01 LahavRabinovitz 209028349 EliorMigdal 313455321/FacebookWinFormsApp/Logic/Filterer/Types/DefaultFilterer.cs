using BasicFacebookFeatures.Logic.UserProxy.UserItemsAdapter.Types.ItemAdapter.Types;

namespace BasicFacebookFeatures.Logic.Filterer.Types
{
    public class DefaultFilterer : IFilterer<PostAdapter>
    {
        public string Name => "Default";

        public bool Filter(PostAdapter i_Obj)
        {
            return true;
        }
    }
}