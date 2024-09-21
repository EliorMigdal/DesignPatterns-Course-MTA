using BasicFacebookFeatures.Logic.UserProxy.UserItemsAdapter.Types.ItemAdapter.Types;

namespace BasicFacebookFeatures.Logic.Filterer.Types
{
    public class CheckInFilterer : IFilterer<PostAdapter>
    {
        public string Name => "Check In";

        public bool Filter(PostAdapter i_Obj)
        {
            return i_Obj.PostType.Equals(PostAdapter.ePostType.CheckIn);
        }
    }
}
