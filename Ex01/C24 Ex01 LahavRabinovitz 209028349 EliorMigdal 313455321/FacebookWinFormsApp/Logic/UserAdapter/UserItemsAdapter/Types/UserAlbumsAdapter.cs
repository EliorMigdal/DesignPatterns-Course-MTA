using BasicFacebookFeatures.Logic.UserProxy.UserItemsAdapter.Types.ItemAdapter;
using BasicFacebookFeatures.Logic.UserProxy.UserItemsAdapter.Types.ItemAdapter.Types;
using FacebookWrapper.ObjectModel;
using System.Collections.ObjectModel;

namespace BasicFacebookFeatures.Logic.UserProxy.UserItemsAdapter.Types
{
    public class UserAlbumsAdapter : IUserCollectionsAdapter
    {
        public string Name => "Albums";
        private readonly Collection<Album> r_Albums;
        private readonly Collection<IUserItemAdapter> r_AlbumsCollection = new Collection<IUserItemAdapter>();
        public Collection<IUserItemAdapter> ItemAdapterCollection 
        {
            get
            {
                if (r_AlbumsCollection.Count == 0)
                {
                    foreach (Album album in r_Albums)
                    {
                        r_AlbumsCollection.Add(new AlbumAdapter(album));
                    }
                }
                return r_AlbumsCollection;
            }
        }

        public UserAlbumsAdapter(Collection<Album> i_Albums)
        {
            r_Albums = i_Albums;
        }
    }
}