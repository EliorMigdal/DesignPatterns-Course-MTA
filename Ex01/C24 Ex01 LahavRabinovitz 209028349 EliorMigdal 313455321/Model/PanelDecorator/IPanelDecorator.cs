using System.Collections.ObjectModel;
using System.Windows.Forms;

namespace Model.PanelDecorator
{
    public interface IPanelDecorator
    {
        Collection<Control> Controls { get; }
    }
}