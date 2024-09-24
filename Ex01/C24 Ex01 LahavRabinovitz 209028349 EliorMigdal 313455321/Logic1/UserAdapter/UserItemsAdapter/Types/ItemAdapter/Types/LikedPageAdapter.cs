using BasicFacebookFeatures.CustomeData;
using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures.Logic.UserProxy.UserItemsAdapter.Types.ItemAdapter.Types
{
    public class LikedPageAdapter : IUserItemAdapter
    {
        public string Name { get; set; }
        public LikedPageData LikedPageData { get; set; }
        public string Picture { get; set; }

        public LikedPageAdapter(LikedPageData i_Page)
        {
            Name = i_Page.Name;
            LikedPageData = i_Page;
            Picture = i_Page.Picture;
        }

        public LikedPageAdapter(Page i_Page)
        {
            Name = i_Page.Name;
            Picture = i_Page.PictureURL;
        }

    }
}