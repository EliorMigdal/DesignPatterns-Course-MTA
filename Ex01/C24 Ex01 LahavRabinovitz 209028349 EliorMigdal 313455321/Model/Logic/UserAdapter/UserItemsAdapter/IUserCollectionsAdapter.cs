using Model.Logic.UserProxy.UserItemsAdapter.Types.ItemAdapter;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Model.Logic.UserProxy.UserItemsAdapter
{
    public interface IUserCollectionsAdapter : INotifyPropertyChanged
    {
        string Name { get; }
        Collection<IUserItemAdapter> ItemAdapterCollection { get; }
    }
}