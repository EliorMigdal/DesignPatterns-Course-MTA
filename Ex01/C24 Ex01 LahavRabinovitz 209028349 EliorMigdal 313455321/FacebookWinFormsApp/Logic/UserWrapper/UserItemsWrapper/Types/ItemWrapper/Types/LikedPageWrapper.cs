using BasicFacebookFeatures.CustomeData;
using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures.Logic.UserWrapper.UserItemsWrapper.Types.ItemWrapper.Types
{
    public class LikedPageWrapper : IUserItemWrapper
    {
        public string Name { get; set; }
        public Page Page { get; set; }  
        public LikedPageData LikedPageData { get; set; }
        public string Picture { get; set; }


        public LikedPageWrapper(Page i_Page)
        {
            Name = i_Page.Name;
            Page = i_Page;
            Picture = i_Page.PictureNormalURL;
        }

        public LikedPageWrapper(LikedPageData i_page)
        {
            Name = i_page.Name;
            LikedPageData = i_page;
            Picture = i_page.Picture;
        }
    }
}