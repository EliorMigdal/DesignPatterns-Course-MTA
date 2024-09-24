using BasicFacebookFeatures.Logic.UserProxy.UserItemsAdapter.Types.ItemAdapter;
using BasicFacebookFeatures.Logic.UserProxy.UserItemsAdapter.Types.ItemAdapter.Types;
using BasicFacebookFeatures.PanelDecorator.Types;

namespace BasicFacebookFeatures.PanelDecorator
{
    public static class PanelDecoratorFactory
    {
        public static IPanelDecorator CreatePanelConvertor(IUserItemAdapter i_ItemAdapter)
        {
            IPanelDecorator panelDecorator;

            switch (i_ItemAdapter)
            {
                case EventAdapter eventAdapter:
                    panelDecorator = new EventDecorator(eventAdapter);
                    break;
                case AlbumAdapter albumAdapter:
                    panelDecorator = new AlbumDecorator(albumAdapter.Album);
                    break;
                case LikedPageAdapter pagesAdapter:
                    panelDecorator = new LikedPageDecorator(pagesAdapter);
                    break;
                case FriendAdapter friendAdapter:
                    panelDecorator = new FriendDecorator(friendAdapter);
                    break;
                default:
                    panelDecorator = null;
                    break;
            }

            return panelDecorator;
        }
    }
}