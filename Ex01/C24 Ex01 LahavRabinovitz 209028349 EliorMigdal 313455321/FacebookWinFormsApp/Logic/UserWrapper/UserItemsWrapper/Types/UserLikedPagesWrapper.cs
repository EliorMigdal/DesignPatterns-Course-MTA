using BasicFacebookFeatures.CustomeData;
using BasicFacebookFeatures.Logic.UserWrapper.UserItemsWrapper.Types.ItemWrapper;
using BasicFacebookFeatures.Logic.UserWrapper.UserItemsWrapper.Types.ItemWrapper.Types;
using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BasicFacebookFeatures.Logic.UserWrapper.UserItemsWrapper.Types
{
    public class UserLikedPagesWrapper : IUserCollectionsWrapper
    {
        public string Name => "Liked Pages";
        public Collection<IUserItemWrapper> ItemWrapperCollection { get; set; } = new Collection<IUserItemWrapper>();

        public UserLikedPagesWrapper(Collection<Page> i_Pages)
        {
            addCustomData();
        }

        private void addCustomData()
        {
            try
            {
                List<LikedPageData> customLikedPagesList = LikedPageData.LoadPagesData();

                foreach (LikedPageData customPageData in customLikedPagesList)
                {
                    ItemWrapperCollection.Add(new LikedPageWrapper(customPageData));
                }
            }

            catch (Exception)
            {

            }
        }
    }
}