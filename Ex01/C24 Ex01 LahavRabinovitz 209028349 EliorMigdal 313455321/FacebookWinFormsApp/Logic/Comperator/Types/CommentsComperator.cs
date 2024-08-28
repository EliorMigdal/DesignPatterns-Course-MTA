using BasicFacebookFeatures.Logic.UserWrapper.UserItemsWrapper.Types.ItemWrapper.Types;

namespace BasicFacebookFeatures.Logic.Comperator.Types
{
    public class CommentsComperator : IComperator<PostWrapper>
    {
        public string Name => "Comments";

        public int Compare(PostWrapper i_ObjA, PostWrapper i_ObjB)
        {
            return i_ObjA.Comments.Count.CompareTo(i_ObjB.Comments.Count) * (-1);
        }
    }
}