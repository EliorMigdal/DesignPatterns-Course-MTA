using FacebookWrapper.ObjectModel;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Windows.Forms;

namespace BasicFacebookFeatures.PanelDecorator.Types
{
    public class AlbumDecorator : IPanelDecorator
    {
        private Collection<Control> m_Controls = null;
        public Collection<Control> Controls
        {
            get
            {
                if (m_Controls == null)
                {
                    m_Controls = new Collection<Control>();

                    initializeControls();
                }

                return m_Controls;
            }
        }

        public Album Album { get; set; }

        public AlbumDecorator(Album i_Album)
        {
            Album = i_Album;
        }

        private void initializeControls()
        {
            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel
            {
                Size = new Size(800, 150),
                Location = new Point(10, 10),
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false,
                AutoScroll = true,
                Dock = DockStyle.Fill
            };

            foreach (Photo photo in Album.Photos)
            {
                PictureBox selectedPictureBox = new PictureBox
                {
                    ImageLocation = photo.PictureNormalURL,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Size = new Size(150, 150),
                    Margin = new Padding(5),
                };

                flowLayoutPanel.Controls.Add(selectedPictureBox);
            }

            m_Controls.Add(flowLayoutPanel);
        }
    }
}