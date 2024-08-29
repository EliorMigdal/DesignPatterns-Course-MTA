using BasicFacebookFeatures.Logic.UserWrapper.UserItemsWrapper.Types.ItemWrapper;
using BasicFacebookFeatures.Logic.UserWrapper.UserItemsWrapper.Types.ItemWrapper.Types;
using BasicFacebookFeatures.PanelConversion.Types;

namespace BasicFacebookFeatures.PanelConversion
{
    public static class PanelConvertersFactory
    {
        public static IPanelViewable CreatePanelConvertor(IUserItemWrapper i_ItemWrapper)
        {
            IPanelViewable panelViewable = null;

            switch (i_ItemWrapper)
            {
                case EventWrapper eventWrapper:
                    return new EventWrapperConverter(eventWrapper);
                case AlbumWrapper albumWrapper:
                    return new AlbumWrapperConverter(albumWrapper.Album);
                case LikedPageWrapper pagesWrapper:
                    return new LikedPageWrapperConverter(pagesWrapper);
                    case FriendWrapper friendWrapper:
                    return new FriendWrapperConverter(friendWrapper);
                default:
                    return panelViewable;
            }
        }
    }
}