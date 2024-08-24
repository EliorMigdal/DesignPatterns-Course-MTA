using BasicFacebookFeatures.Logic.UserWrapper.UserItemsWrapper.Types.ItemWrapper;
using System.Collections.ObjectModel;

namespace BasicFacebookFeatures.Logic.UserWrapper.UserItemsWrapper
{
    public interface IUserCollectionsWrapper
    {
        string Name { get; }
        Collection<IUserItemWrapper> ItemWrapperCollection { get; }
    }
}