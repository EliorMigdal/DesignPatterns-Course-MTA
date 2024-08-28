using BasicFacebookFeatures.Logic.UserWrapper.UserItemsWrapper.Types.ItemWrapper;
using BasicFacebookFeatures.Logic.UserWrapper.UserItemsWrapper.Types.ItemWrapper.Types;
using FacebookWrapper.ObjectModel;
using System.Collections.ObjectModel;

namespace BasicFacebookFeatures.Logic.UserWrapper.UserItemsWrapper.Types
{
    public class UserPostsWrapper : IUserCollectionsWrapper
    {
        public string Name => "Posts";

        public Collection<IUserItemWrapper> ItemWrapperCollection => new Collection<IUserItemWrapper>();

        public UserPostsWrapper(Collection<Post> i_Posts)
        {
            foreach (Post post in i_Posts)
            {
                ItemWrapperCollection.Add(new PostWrapper(post));
            }
        }
    }
}