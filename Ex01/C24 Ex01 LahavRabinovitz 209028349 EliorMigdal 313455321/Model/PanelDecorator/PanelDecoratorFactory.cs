using Model.Logic.UserProxy.UserItemsAdapter.Types.ItemAdapter;
using Model.Logic.UserProxy.UserItemsAdapter.Types.ItemAdapter.Types;
using Model.PanelDecorator.Types;

namespace Model.PanelDecorator
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