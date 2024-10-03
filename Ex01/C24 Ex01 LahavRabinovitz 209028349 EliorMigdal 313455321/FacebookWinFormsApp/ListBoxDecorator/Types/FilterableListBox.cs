using BasicFacebookFeatures.Logic.Filterer;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BasicFacebookFeatures.ListBoxDecorator.Types
{
    public class FilterableListBox<T> : ListBoxDecorator
        where T : class
    {
        private readonly ComboBox r_FilterItems = new ComboBox();
        private readonly List<IFilterer<T>> r_FilterMethods = new List<IFilterer<T>>();

        public FilterableListBox()
        {
            r_FilterItems.Items.Clear();
            r_FilterItems.DataSource = r_FilterMethods;
            r_FilterItems.DisplayMember = "Name";
        }
    }
}