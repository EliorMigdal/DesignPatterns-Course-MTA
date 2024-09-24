using BasicFacebookFeatures.Logic.UserProxy.UserItemsAdapter.Types.ItemAdapter;
using BasicFacebookFeatures.Logic.UserProxy.UserItemsAdapter.Types.ItemAdapter.Types;
using FacebookWrapper.ObjectModel;
using System.Collections.ObjectModel;
using System.Linq;

namespace BasicFacebookFeatures.Logic.UserProxy.UserItemsAdapter.Types
{
    public class UserAlbumsAdapter : IUserCollectionsAdapter
    {
        public string Name => "Albums";
        private readonly User r_UserData;
        private readonly Collection<IUserItemAdapter> r_AlbumsCollection = new Collection<IUserItemAdapter>();
        public Collection<IUserItemAdapter> ItemAdapterCollection 
        {
            get
            {
                if (r_AlbumsCollection.Count == 0)
                {
                    Collection<Album> albums = new Collection<Album>(r_UserData.Albums
                                              .Where(album => album.Count > 0).ToList());

                    foreach (Album album in albums)
                    {
                        r_AlbumsCollection.Add(new AlbumAdapter(album));
                    }
                }

                return r_AlbumsCollection;
            }
        }

        public UserAlbumsAdapter(User i_UserData)
        {
            r_UserData = i_UserData;
        }
    }
}