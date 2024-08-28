using BasicFacebookFeatures.CustomeData;
using BasicFacebookFeatures.Logic.UserWrapper.UserItemsWrapper.Types.ItemWrapper.Types;
using FacebookWrapper.ObjectModel;
using System.Collections.ObjectModel;
using System.Windows.Forms;

namespace BasicFacebookFeatures.PanelConversion.Types
{
    public class LikedPageWrapperConverter : IPanelViewable
    {
        private LikedPageWrapper m_likedPageWrapper;
        private Page LikedPages {  get; set; }
        private LikedPageData LikedPagesData {  get; set; }
        private Collection<Control> m_Controls;
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

        public LikedPageWrapperConverter(LikedPageWrapper i_LikedPageWrapper)
        {
            LikedPagesData = i_LikedPageWrapper.LikedPageData;
        }

        private void initializeControls()
        {
            TableLayoutPanel tableLayoutPanel = initializeGrid();

            initializePicture(tableLayoutPanel);
            initializePosts(tableLayoutPanel);

            m_Controls.Add(tableLayoutPanel);
        }

        private void initializePicture(TableLayoutPanel io_tableLayoutPanel)
        {
            PictureBox pictureBox = new PictureBox
            {
                Image = Properties.Resources.tech,
                SizeMode = PictureBoxSizeMode.Zoom,
                Dock = DockStyle.Fill,
                Margin = new Padding(5),
            };

            io_tableLayoutPanel.Controls.Add(pictureBox, 0, 0);
        }


        private void initializePosts(TableLayoutPanel io_tableLayoutPanel)
        {
            ListBox posts = new ListBox
            {
                SelectionMode = SelectionMode.None,
                Dock = DockStyle.Fill
            };

            foreach (string post in LikedPagesData.Posts)
            {
                posts.Items.Add(post);
            }

            io_tableLayoutPanel.Controls.Add(posts, 1, 0);
        }

        private TableLayoutPanel initializeGrid()
        {
            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel
            {
                AutoSize = true,
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 1,
                ColumnStyles =
                {
                    new ColumnStyle(SizeType.Percent, 50F),
                    new ColumnStyle(SizeType.Percent, 50F),
                },
                AutoSizeMode = AutoSizeMode.GrowAndShrink
            };

            return tableLayoutPanel;
        }
    }
}