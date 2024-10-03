using Model.Logic.UserProxy.UserItemsAdapter.Types.ItemAdapter.Types;

namespace Model.Logic.Filterer.Types
{
    public class TextOnlyFilterer : IFilterer<PostAdapter>
    {
        public string Name => "Text Only";

        public bool Filter(PostAdapter i_Obj)
        {
            return i_Obj.PostType.Equals(PostAdapter.ePostType.Text);
        }
    }
}