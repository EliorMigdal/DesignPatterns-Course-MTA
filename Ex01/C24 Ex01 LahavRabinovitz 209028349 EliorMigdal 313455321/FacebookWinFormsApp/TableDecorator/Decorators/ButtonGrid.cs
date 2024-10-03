using System.Drawing;
using System.Windows.Forms;

namespace BasicFacebookFeatures.TableDecorator.Decorators
{
    public class ButtonGrid : GridDecorator
    {
        public ButtonGrid(IGrid i_Decorator, string i_ButtonText = "") : base(i_Decorator)
        {
            Grid.Controls.Add(new Button
            {
                AutoSize = true,
                Text = i_ButtonText,
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.ForestGreen,
                ImageAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill
            });
        }
    }
}
