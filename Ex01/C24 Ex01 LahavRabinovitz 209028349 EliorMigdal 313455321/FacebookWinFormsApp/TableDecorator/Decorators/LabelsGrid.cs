using System.Collections.ObjectModel;
using System.Drawing;
using System.Windows.Forms;

namespace BasicFacebookFeatures.TableDecorator.Decorators
{
    public class LabelsGrid : GridDecorator
    {
        public LabelsGrid(IGrid i_Decorator, Collection<string> i_Text) : base(i_Decorator)
        {
            if (i_Text.Count > 1)
            {
                FlowLayoutPanel flowPanel = new FlowLayoutPanel
                {
                    FlowDirection = FlowDirection.TopDown,
                    WrapContents = false,
                    AutoScroll = true,
                    Dock = DockStyle.Fill
                };

                foreach (string text in i_Text)
                {
                    flowPanel.Controls.Add(new Label
                    {
                        Dock = DockStyle.Fill,
                        Text = text,
                        TextAlign = ContentAlignment.MiddleCenter,
                        AutoSize = true,
                    });
                }

                Grid.Controls.Add(flowPanel);
            }

            else
            {
                Grid.Controls.Add(new Label
                {
                    Dock = DockStyle.Fill,
                    Text = i_Text[0],
                    TextAlign = ContentAlignment.MiddleCenter,
                    AutoSize = true,
                });
            }
        }
    }
}
