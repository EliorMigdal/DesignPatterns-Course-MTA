using FacebookWrapper.ObjectModel;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Windows.Forms;

namespace BasicFacebookFeatures.Logic.UserWrapper.UserItemsWrapper.Types.ItemWrapper.Types
{
    public class AlbumWrapper : IUserItemWrapper, IPanelViewable
    {
        public string Name { get; set; }
        public Album Album { get; set; }
        public string Picture { get; set; }

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

        public AlbumWrapper(Album i_Album)
        {
            Album = i_Album;
            Name = i_Album.Name;
            Picture = i_Album.PictureAlbumURL;
        }

        public void initializeControls() 
        {
            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel
            {
                Size = new Size(800, 150),
                Location = new Point(10, 10),
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false,
                AutoScroll = true
            };

            foreach (Photo photo in Album.Photos)
            {
                PictureBox selectedPictureBox = new PictureBox
                {
                    ImageLocation = photo.PictureNormalURL,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Size = new Size(100, 100),
                    Margin = new Padding(5)
                };

                flowLayoutPanel.Controls.Add(selectedPictureBox);
            }

            m_Controls.Add(flowLayoutPanel);
        }
    }
}