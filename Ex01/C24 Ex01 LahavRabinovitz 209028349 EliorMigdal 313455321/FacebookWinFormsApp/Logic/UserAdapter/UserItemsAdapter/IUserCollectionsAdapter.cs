using BasicFacebookFeatures.Logic.UserProxy.UserItemsAdapter.Types.ItemAdapter;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace BasicFacebookFeatures.Logic.UserProxy.UserItemsAdapter
{
    public interface IUserCollectionsAdapter : INotifyPropertyChanged
    {
        string Name { get; }
        Collection<IUserItemAdapter> ItemAdapterCollection { get; }
    }
}