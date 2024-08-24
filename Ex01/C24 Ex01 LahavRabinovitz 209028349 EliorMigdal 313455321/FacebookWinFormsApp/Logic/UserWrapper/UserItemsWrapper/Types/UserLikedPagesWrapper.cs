using BasicFacebookFeatures.Logic.UserWrapper.UserItemsWrapper.Types.ItemWrapper;
using BasicFacebookFeatures.Logic.UserWrapper.UserItemsWrapper.Types.ItemWrapper.Types;
using FacebookWrapper.ObjectModel;
using System.Collections.ObjectModel;

namespace BasicFacebookFeatures.Logic.UserWrapper.UserItemsWrapper.Types
{
    public class UserLikedPagesWrapper : IUserCollectionsWrapper
    {
        public string Name => "Liked Pages";
        public Collection<IUserItemWrapper> ItemWrapperCollection { get; set; } = new Collection<IUserItemWrapper>();

        public UserLikedPagesWrapper(Collection<Page> i_Pages)
        {
            foreach (Page page in i_Pages)
            {
                ItemWrapperCollection.Add(new LikedPageWrapper(page));
            }
        }
    }
}