using System.Collections.Generic;
using System.Windows.Forms;

namespace BasicFacebookFeatures.TableDecorator
{
    public abstract class GridDecorator : IGrid
    {
        public TableLayoutPanel Grid { get; protected set; }

        public GridDecorator(IGrid i_Decorator)
        {
            Grid = i_Decorator.Grid;
        }
    }
}