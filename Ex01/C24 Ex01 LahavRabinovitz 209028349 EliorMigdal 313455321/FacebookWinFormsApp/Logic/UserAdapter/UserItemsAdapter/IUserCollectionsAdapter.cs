using BasicFacebookFeatures.Logic.UserProxy.UserItemsAdapter.Types.ItemAdapter;
using System.Collections.ObjectModel;

namespace BasicFacebookFeatures.Logic.UserProxy.UserItemsAdapter
{
    public interface IUserCollectionsAdapter
    {
        string Name { get; }
        Collection<IUserItemAdapter> ItemAdapterCollection { get; }
    }
}