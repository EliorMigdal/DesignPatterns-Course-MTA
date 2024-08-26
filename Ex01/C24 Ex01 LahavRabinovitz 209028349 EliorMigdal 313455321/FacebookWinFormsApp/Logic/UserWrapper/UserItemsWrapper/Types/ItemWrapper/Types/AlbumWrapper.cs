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
            Name = i_Album.Name;
            Album = i_Album;
            Picture = i_Album.PictureAlbumURL;
        }
    }
}