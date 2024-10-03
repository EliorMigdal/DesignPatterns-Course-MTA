using BasicFacebookFeatures.CustomeData;
using BasicFacebookFeatures.Logic.UserProxy.UserItemsAdapter.Types.ItemAdapter;
using BasicFacebookFeatures.Logic.UserProxy.UserItemsAdapter.Types.ItemAdapter.Types;
using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace BasicFacebookFeatures.Logic.UserProxy.UserItemsAdapter.Types
{
    public class UserLikedPagesAdapter : IUserCollectionsAdapter
    {
        public string Name => "Liked Pages";
        private readonly User r_UserData;
        private readonly Collection<IUserItemAdapter> r_LikedPagesCollection = new Collection<IUserItemAdapter>();

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string i_PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(i_PropertyName));
        }

        public Collection<IUserItemAdapter> ItemAdapterCollection
        {
            get
            {
                if (r_LikedPagesCollection.Count == 0)
                {
                    addCustomData();
                }
                
                return r_LikedPagesCollection;
            }
        }

        public UserLikedPagesAdapter(User i_UserData)
        {
            r_UserData = i_UserData;
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