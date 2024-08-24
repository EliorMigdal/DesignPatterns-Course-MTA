using BasicFacebookFeatures.Logic.UserWrapper.UserItemsWrapper.Types.ItemWrapper;
using BasicFacebookFeatures.Logic.UserWrapper.UserItemsWrapper.Types.ItemWrapper.Types;
using FacebookWrapper.ObjectModel;
using System.Collections.ObjectModel;

namespace BasicFacebookFeatures.Logic.UserWrapper.UserItemsWrapper.Types
{
    public class UserAlbumsWrapper : IUserCollectionsWrapper
    {
        public string Name => "Albums";
        public Collection<IUserItemWrapper> ItemWrapperCollection { get; set; } = new Collection<IUserItemWrapper>();

        public UserAlbumsWrapper(Collection<Album> i_Albums)
        {
            foreach (Album album in i_Albums)
            {
                ItemWrapperCollection.Add(new AlbumWrapper(album));
            }
        }
    }
}