using Model.Logic.UserProxy.UserItemsAdapter.Types.ItemAdapter.Types;

namespace Model.Logic.Filterer.Types
{
    public class ImagePostFilterer : IFilterer<PostAdapter>
    {
        public string Name => "Image Post";

        public bool Filter(PostAdapter i_Obj)
        {
            return i_Obj.PostType.Equals(PostAdapter.ePostType.Image);
        }
    }
}