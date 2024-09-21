using System.Collections.ObjectModel;
using System.Windows.Forms;

namespace BasicFacebookFeatures.PanelDecorator
{
    public interface IPanelDecorator
    {
        Collection<Control> Controls { get; }
    }
}