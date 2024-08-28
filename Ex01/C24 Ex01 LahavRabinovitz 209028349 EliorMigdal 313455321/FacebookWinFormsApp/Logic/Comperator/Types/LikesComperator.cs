using BasicFacebookFeatures.Logic.UserWrapper.UserItemsWrapper.Types.ItemWrapper.Types;

namespace BasicFacebookFeatures.Logic.Comperator.Types
{
    public class LikesComperator : IComperator<PostWrapper>
    {
        public string Name => "Likes";

        public int Compare(PostWrapper i_ObjA, PostWrapper i_ObjB)
        {
            return i_ObjA.Likes.CompareTo(i_ObjB.Likes) *(-1);
        }
    }
}