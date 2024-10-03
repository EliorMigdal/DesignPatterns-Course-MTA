using System.Windows.Forms;

namespace BasicFacebookFeatures.TableDecorator
{
    public class CoreGrid : IGrid
    {
        public TableLayoutPanel Grid { get; }

        public CoreGrid(int i_Rows = 1, int i_Columns = 1)
        {
            Grid = new TableLayoutPanel
            {
                RowCount = i_Rows,
                ColumnCount = i_Columns,
                Dock = DockStyle.Fill,
            };
        }
    }
}