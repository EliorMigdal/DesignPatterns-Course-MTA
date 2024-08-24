using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures.Logic.UserWrapper.UserItemsWrapper.Types.ItemWrapper.Types
{
    public class AlbumWrapper : IUserItemWrapper
    {
        public string Name { get; set; }
        public Album Album { get; set; }
        public string Picture { get; set; }

        public AlbumWrapper(Album i_Album)
        {
            Album = i_Album;
            Name = i_Album.Name;
            Picture = i_Album.PictureAlbumURL;
        }
    }
}