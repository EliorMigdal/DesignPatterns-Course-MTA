using System.Collections.Generic;
using System.Windows.Forms;

namespace BasicFacebookFeatures.TableDecorator.Decorators
{
    public class RatioGrid : GridDecorator
    {
        public RatioGrid(IGrid i_Decorator, List<(int, float)> i_RowsRatio = null,
            List<(int, float)> i_ColumnsRatio = null) : base(i_Decorator)
        {
            TableLayoutPanel baseGrid = i_Decorator.Grid;

            i_RowsRatio?.ForEach(((int row, float ratio) pair) => 
            baseGrid.RowStyles.Add(new RowStyle(SizeType.Percent, pair.ratio)));

            i_ColumnsRatio?.ForEach(((int column, float ratio) pair) =>
            baseGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, pair.ratio)));

            Grid = baseGrid;
        }
    }
}