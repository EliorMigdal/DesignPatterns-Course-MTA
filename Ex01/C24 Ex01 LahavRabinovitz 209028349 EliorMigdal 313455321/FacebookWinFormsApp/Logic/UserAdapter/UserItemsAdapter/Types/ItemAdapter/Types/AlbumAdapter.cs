using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures.Logic.UserProxy.UserItemsAdapter.Types.ItemAdapter.Types
{
    public class AlbumAdapter : IUserItemAdapter
    {
        public string Name { get; set; }
        public Album Album { get; set; }
        public string Picture { get; set; }

        public AlbumAdapter(Album i_Album)
        {
            Name = i_Album.Name;
            Album = i_Album;
            Picture = i_Album.PictureAlbumURL;
        }
    }
}