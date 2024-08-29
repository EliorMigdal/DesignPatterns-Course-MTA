using BasicFacebookFeatures.Logic.UserWrapper.UserItemsWrapper.Types.ItemWrapper.Types;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using BasicFacebookFeatures.CustomeData;
using System.Drawing;
using BasicFacebookFeatures.Properties;
using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures.PanelConversion.Types
{
    public class FriendWrapperConverter : IPanelViewable
    {
        private Collection<Control> m_Controls;
        private Friend m_Friend;

        public FriendWrapperConverter(FriendWrapper i_Friend)
        {
            m_Friend = i_Friend.Friend;
        }

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

        private void initializeControls()
        {
            TableLayoutPanel tableLayoutPanel = initializeGrid();
            initializeLeftColumn(ref tableLayoutPanel);
            initializeCenterColumn(ref tableLayoutPanel);
            initializeRightColumn(ref tableLayoutPanel);

            m_Controls.Add(tableLayoutPanel);
        }

        private void initializeLeftColumn(ref TableLayoutPanel io_TableLayoutPanel)
        {
            TableLayoutPanel innerTableLayoutPanel = new TableLayoutPanel
            {
                RowCount = 3,
                ColumnCount = 1,
                Dock = DockStyle.Fill,
                RowStyles =
                {
                    new RowStyle(SizeType.Percent, 25f),
                    new RowStyle(SizeType.Percent, 50F),
                    new RowStyle(SizeType.Percent, 25f),
                },
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink
            };

            initializeName(ref innerTableLayoutPanel);
            initializeProfilePicture(ref innerTableLayoutPanel);
            initializeButton(ref innerTableLayoutPanel);

            io_TableLayoutPanel.Controls.Add(innerTableLayoutPanel, 0, 0);
        }

        private void initializeCenterColumn(ref TableLayoutPanel io_TableLayoutPanel)
        {
            ListBox posts = new ListBox
            {
                Dock = DockStyle.Fill,
                SelectionMode = SelectionMode.None,
            };

            foreach(string post in m_Friend.Posts)
            {
                posts.Items.Add(post);
            }

            io_TableLayoutPanel.Controls.Add(posts, 1, 0);
        }

        private void initializeRightColumn(ref TableLayoutPanel io_TableLayoutPanel)
        {
            FlowLayoutPanel picturesPanel = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false,
                AutoScroll = true,
                Dock = DockStyle.Fill
            };

            foreach (string photo in m_Friend.Pictures)
            {
                PictureBox selectedPictureBox = new PictureBox
                {
                    Image = Properties.Resources.summerbeach,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Size = new Size(50, 50),
                    Margin = new Padding(5),
                };

                picturesPanel.Controls.Add(selectedPictureBox);
            }

            io_TableLayoutPanel.Controls.Add(picturesPanel, 2, 0);
        }

        private void initializeButton(ref TableLayoutPanel io_TableLayoutPanel)
        {
            Button closeFriendButton = new Button
            {
                AutoSize = true,
                Text = "Close Friend",
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.ForestGreen,
                ImageAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill
            };

            io_TableLayoutPanel.Controls.Add(closeFriendButton, 0, 2);
        }

        private void initializeProfilePicture(ref TableLayoutPanel io_TableLayoutPanel)
        {
            PictureBox profilePicture = new PictureBox
            {
                Image = Resources.batman, //ImageLocation = Event.PictureNormalURL,
                SizeMode = PictureBoxSizeMode.Zoom,
                Dock = DockStyle.Fill,
                Size = new Size(60, 60),
                Margin = new Padding(5)
            };

            io_TableLayoutPanel.Controls.Add(profilePicture, 0, 1);
        }

        private void initializeName(ref TableLayoutPanel io_InnerTableLayoutPanel)
        {
            Label name = new Label
            {
                Dock = DockStyle.Fill,
                Text = $"Name: {m_Friend.Name}",
                TextAlign = ContentAlignment.MiddleCenter,
                AutoSize = true
            };

            io_InnerTableLayoutPanel.Controls.Add(name, 0, 0);
        }

        private TableLayoutPanel initializeGrid()
        {
            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 3,
                RowCount = 1,
                ColumnStyles =
                {
                    new ColumnStyle(SizeType.Percent, 25F),
                    new ColumnStyle(SizeType.Percent, 50F),
                    new ColumnStyle(SizeType.Percent, 25F),
                },
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink
            };

            return tableLayoutPanel;
        }
    }
}