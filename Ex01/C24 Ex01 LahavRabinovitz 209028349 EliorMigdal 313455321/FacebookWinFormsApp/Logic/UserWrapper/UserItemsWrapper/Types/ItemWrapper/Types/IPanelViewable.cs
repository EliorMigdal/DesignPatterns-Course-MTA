using System.Collections.ObjectModel;
using System.Windows.Forms;

namespace BasicFacebookFeatures.Logic.UserWrapper.UserItemsWrapper.Types.ItemWrapper.Types
{
    public interface IPanelViewable
    {
        Collection<Control> Controls { get; }
    }
}