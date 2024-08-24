using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures.Logic.UserWrapper.UserItemsWrapper.Types.ItemWrapper.Types
{
    public class LikedPageWrapper : IUserItemWrapper
    {
        public string Name { get; set; }
        public Page Page { get; set; }

        public LikedPageWrapper(Page i_Page)
        {
            Name = i_Page.Name;
            Page = i_Page;
        }
    }
}
