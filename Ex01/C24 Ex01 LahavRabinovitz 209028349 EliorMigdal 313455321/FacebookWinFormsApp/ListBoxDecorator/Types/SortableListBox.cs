using BasicFacebookFeatures.Logic.Comperator;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BasicFacebookFeatures.ListBoxDecorator.Types
{
    public class SortableListBox<T> : ListBoxDecorator 
        where T : class
    {
        private readonly ComboBox r_SortItems = new ComboBox();
        private readonly List<IComperator<T>> r_SortMethods = new List<IComperator<T>>();

        public SortableListBox()
        {
            r_SortItems.Items.Clear();
            r_SortItems.DataSource = r_SortMethods;
            r_SortItems.DisplayMember = "Name";
        }
    }
}