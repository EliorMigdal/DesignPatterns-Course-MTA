using BasicFacebookFeatures.Logic.UserWrapper.UserItemsWrapper.Types.ItemWrapper;
using BasicFacebookFeatures.Logic.UserWrapper.UserItemsWrapper.Types.ItemWrapper.Types;
using BasicFacebookFeatures.PanelConversion.Types;

namespace BasicFacebookFeatures.PanelConversion
{
    public static class PanelConvertersFactory
    {
        public static IPanelViewable CreatePanelConvertor(IUserItemWrapper i_ItemWrapper)
        {
            IPanelViewable panelViewable;

            switch (i_ItemWrapper)
            {
                case EventWrapper eventWrapper:
                    panelViewable = new EventWrapperConverter(eventWrapper);
                    break;
                case AlbumWrapper albumWrapper:
                    panelViewable = new AlbumWrapperConverter(albumWrapper.Album);
                    break;
                case LikedPageWrapper pagesWrapper:
                    panelViewable = new LikedPageWrapperConverter(pagesWrapper);
                    break;
                case FriendWrapper friendWrapper:
                    panelViewable = new FriendWrapperConverter(friendWrapper);
                    break;
                default:
                    panelViewable = null;
                    break;
            }

            return panelViewable;
        }
    }
}