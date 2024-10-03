using Model.Logic.UserProxy.UserItemsAdapter.Types.ItemAdapter.Types;

namespace Model.Logic.Comperator.Types
{
    public class LikesComperator : IComperator<PostAdapter>
    {
        public string Name => "Likes";

        public int Compare(PostAdapter i_ObjA, PostAdapter i_ObjB)
        {
            return i_ObjA.Likes.CompareTo(i_ObjB.Likes) *(-1);
        }
    }
}