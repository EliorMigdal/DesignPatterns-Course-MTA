using System.Collections.Generic;
using System.Windows.Forms;

namespace BasicFacebookFeatures.TableDecorator.Decorators
{
    public class ListBoxGrid : GridDecorator
    {
        public ListBoxGrid(IGrid i_Decorator, List<string> i_Items) : base(i_Decorator)
        {
            Grid.Controls.Add(new ListBox
            {
                SelectionMode = SelectionMode.None,
                Dock = DockStyle.Fill,
                DataSource = i_Items
            });
        }
    }
}
