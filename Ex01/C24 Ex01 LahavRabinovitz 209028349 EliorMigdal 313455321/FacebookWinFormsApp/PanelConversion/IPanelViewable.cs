using System.Collections.ObjectModel;
using System.Windows.Forms;

namespace BasicFacebookFeatures.PanelConversion
{
    public interface IPanelViewable
    {
        Collection<Control> Controls { get; }
    }
}