using Model.Logic.UserProxy.UserItemsAdapter.Types.ItemAdapter.Types;

namespace Model.Logic.Comperator.Types
{
    public class CommentsComperator : IComperator<PostAdapter>
    {
        public string Name => "Comments";

        public int Compare(PostAdapter i_ObjA, PostAdapter i_ObjB)
        {
            return i_ObjA.Comments.Count.CompareTo(i_ObjB.Comments.Count) * (-1);
        }
    }
}