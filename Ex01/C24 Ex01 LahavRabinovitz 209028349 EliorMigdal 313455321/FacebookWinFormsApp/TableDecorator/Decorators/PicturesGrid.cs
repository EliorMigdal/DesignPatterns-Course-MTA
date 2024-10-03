using BasicFacebookFeatures.Properties;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BasicFacebookFeatures.TableDecorator.Decorators
{
    public class PicturesGrid : GridDecorator
    {
        public PicturesGrid(IGrid i_Decorator, List<(Image i_Source, int i_Height, int i_Width)> i_Images)
            : base(i_Decorator)
        {
            if (i_Images.Count > 1)
            {
                FlowLayoutPanel flowPanel = new FlowLayoutPanel
                {
                    FlowDirection = FlowDirection.LeftToRight,
                    WrapContents = false,
                    AutoScroll = true,
                    Dock = DockStyle.Fill
                };

                foreach ((Image source, int height, int width) image in i_Images)
                {
                    flowPanel.Controls.Add(new PictureBox
                    {
                        Image = image.source,
                        SizeMode = PictureBoxSizeMode.Zoom,
                        Size = new Size(image.width, image.height),
                        Margin = new Padding(5),
                    });
                }

                Grid.Controls.Add(flowPanel);
            }

            else
            {
                Grid.Controls.Add(new PictureBox
                {
                    Image = i_Images[0].i_Source,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Dock = DockStyle.Fill,
                    Size = new Size(i_Images[0].i_Width, i_Images[0].i_Height),
                    Margin = new Padding(5)
                });
            }
        }
    }
}
