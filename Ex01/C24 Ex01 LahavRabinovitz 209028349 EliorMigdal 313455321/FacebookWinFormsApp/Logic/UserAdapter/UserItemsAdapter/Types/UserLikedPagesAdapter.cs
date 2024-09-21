using BasicFacebookFeatures.CustomeData;
using BasicFacebookFeatures.Logic.UserProxy.UserItemsAdapter.Types.ItemAdapter;
using BasicFacebookFeatures.Logic.UserProxy.UserItemsAdapter.Types.ItemAdapter.Types;
using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BasicFacebookFeatures.Logic.UserProxy.UserItemsAdapter.Types
{
    public class UserLikedPagesAdapter : IUserCollectionsAdapter
    {
        public string Name => "Liked Pages";
        private readonly Collection<IUserItemAdapter> r_LikedPagesCollection = new Collection<IUserItemAdapter>();
        private readonly Collection<Page> r_Pages;

        public Collection<IUserItemAdapter> ItemAdapterCollection
        {
            get
            {
                if (r_Pages.Count == 0 && r_LikedPagesCollection.Count == 0)
                {
                    addCustomData();
                }
                else
                {
                    foreach(Page page in r_Pages)
                    {
                        r_LikedPagesCollection.Add(new LikedPageAdapter(page));
                    }
                }
                
                return r_LikedPagesCollection;
            }
        }

        public UserLikedPagesAdapter(Collection<Page> i_Pages)
        {
            r_Pages = i_Pages;
        }

        private void addCustomData()
        {
            try
            {
                List<LikedPageData> customLikedPagesList = LikedPageData.LoadPagesData();

                foreach (LikedPageData customPageData in customLikedPagesList)
                {
                    r_LikedPagesCollection.Add(new LikedPageAdapter(customPageData));
                }
            }

            catch (Exception)
            {

            }
        }
    }
}