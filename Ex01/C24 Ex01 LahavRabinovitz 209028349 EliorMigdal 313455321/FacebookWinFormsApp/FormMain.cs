using System;
using System.Drawing;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;
using BasicFacebookFeatures.Logic.Settings;
using BasicFacebookFeatures.Logic.UserWrapper;
using BasicFacebookFeatures.Logic.UserWrapper.UserItemsWrapper;
using BasicFacebookFeatures.Logic.UserWrapper.UserItemsWrapper.Types.ItemWrapper;
using BasicFacebookFeatures.PanelConversion;
using BasicFacebookFeatures.Logic.UserWrapper.UserItemsWrapper.Types.ItemWrapper.Types;
using System.Collections.Generic;
using System.Linq;
using BasicFacebookFeatures.Logic.Comperator.Types;
using BasicFacebookFeatures.Logic.Comperator;
using BasicFacebookFeatures.Logic.Filterer.Types;
using BasicFacebookFeatures.Logic.Filterer;

namespace BasicFacebookFeatures
{
    public partial class FormMain : Form
    {
        private LoginResult m_LoginResult;
        private Album m_ProfilePictures;
        private AppSettings m_AppSettings;
        private readonly UserWrapper rm_UserWrapper = new UserWrapper();
        private readonly List<PostWrapper> rm_DisplayedPosts = new List<PostWrapper>();
        private readonly List<PostWrapper> rm_AllPosts = new List<PostWrapper>();
        private readonly string rm_AppID = "868047088601231";

        public FormMain()
        {
            InitializeComponent();
            FacebookService.s_CollectionLimit = 25;
            initializeAppSettings();
            initializeConnectionOnStartup();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);

            if (isUserLoggedIn())
            {
                handleUserToken();
            }

            try
            {
                m_AppSettings.SaveToFile();
            }

            catch (Exception)
            {
                MessageBox.Show("We were unable to store user preferences at the time.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (m_LoginResult == null)
            {
                login();
            }
        }

        private void login()
        {
            m_LoginResult = FacebookService.Login
            (
                rm_AppID,
                "email",
                "public_profile",
                "user_age_range",
                "user_birthday",
                "user_events",
                "user_friends",
                "user_gender",
                "user_hometown",
                "user_likes",
                "user_link",
                "user_location",
                "user_photos",
                "user_posts",
                "user_videos"
            );

            onLogin();
        }

        private void onLogin()
        {
            if (string.IsNullOrEmpty(m_LoginResult.ErrorMessage) && m_LoginResult.LoggedInUser != null)
            {
                buttonLogin.Text = "Logged in!";
                buttonLogin.BackColor = Color.LightGreen;
                pictureBoxProfile.ImageLocation = m_LoginResult.LoggedInUser.PictureNormalURL;
                buttonLogin.Enabled = false;
                buttonLogout.Enabled = true;

                initializeUserWrapper();
                initializeWallTab();
                initializeWelcomeLabel();
                initializeAlbums();
                initializeTrackBar();
                initializeSetPictureButton();
                initializeRememberMeCheckBox();
                initializeListBoxes();
            }
        }

        private void initializeWallTab()
        {
            wallListBox.Enabled = true;
            postButton.Enabled = true;
            postDataLayoutPanel.Enabled = true;
            postInfoLayoutPanel.Enabled = true;
            postToCloseFriendsCheckBox.Enabled = true;
            timedPostButton.Enabled = true;
            newPostTextBox.Enabled = true;
            commentsListBox.Enabled = true;

            initializeUserPosts();
            initializeSortComboBox();
            initializeFilterComboBox();
        }

        private void initializeUserPosts()
        {
            wallListBox.DisplayMember = "Message";
            commentsListBox.DisplayMember = "Message";

            foreach (Post post in rm_UserWrapper.UserData.Posts)
            {
                if (!string.IsNullOrEmpty(post.Message))
                {
                    PostWrapper postWrapper = new PostWrapper(post);
                    rm_AllPosts.Add(postWrapper);
                    wallListBox.Items.Add(postWrapper);
                }
            }

            rm_DisplayedPosts.AddRange(rm_AllPosts);
        }

        private void initializeSortComboBox()
        {
            sortWallComboBox.Enabled = true;
            sortWallComboBox.Items.Add(new LikesComperator());
            sortWallComboBox.Items.Add(new CommentsComperator());
            sortWallComboBox.DisplayMember = "Name";
        }

        private void initializeFilterComboBox()
        {
            filterWallComboBox.Enabled = true;
            filterWallComboBox.DisplayMember= "Name";
            filterWallComboBox.Items.Add(new DefaultFilterer());
            filterWallComboBox.Items.Add(new CheckInFilterer());
            filterWallComboBox.Items.Add(new TextOnlyFilterer());
            filterWallComboBox.Items.Add(new ImagePostFilterer());
            filterWallComboBox.Items.Add(new CloseFriendsFilterer());
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            onLogout();
        }

        private void onLogout()
        {
            if (m_LoginResult != null)
            {
                FacebookService.LogoutWithUI();
                buttonLogin.Text = "Login";
                buttonLogin.BackColor = buttonLogout.BackColor;
                handleUserToken();
                m_LoginResult = null;
                buttonLogin.Enabled = true;
                buttonLogout.Enabled = false;
            }
        }

        private void initializeAlbums()
        {
            m_ProfilePictures = m_LoginResult.LoggedInUser.Albums.Find(album => album.Name.Equals("Profile pictures"));
        }

        private void initializeTrackBar()
        {
            profilePictureTrackBar.Minimum = 0;
            profilePictureTrackBar.Maximum = Math.Min(5, (int) m_ProfilePictures?.Count);
            profilePictureTrackBar.Visible = true;
        }

        private void profilePictureTrackBar_ValueChanged(object sender, EventArgs e)
        {
            onProfilePictureTrackBarValueChanged();
        }

        private void onProfilePictureTrackBarValueChanged()
        {
            pictureBoxProfile.ImageLocation = m_ProfilePictures?.Photos[profilePictureTrackBar.Value].PictureNormalURL;
            handleSetProfilePictureState();
        }

        private void rememberMeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            onRemeberMeCheckBoxChanged();
        }

        private void onRemeberMeCheckBoxChanged()
        {
            if (rememberMeCheckBox.Checked)
            {
                m_AppSettings.RememberUser = true;
            }

            else
            {
                m_AppSettings.RememberUser = false;
            }
        }

        private void handleUserToken()
        {
            if (m_AppSettings.RememberUser)
            {
                m_AppSettings.Token = m_LoginResult.AccessToken;
            }

            else
            {
                m_AppSettings.Token = string.Empty;
            }
        }

        private void initializeAppSettings()
        {
            try
            {
                m_AppSettings = AppSettings.LoadFromFile();
            }

            catch (Exception)
            {
                MessageBox.Show("We were unable to load user preferences at the time.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void initializeConnectionOnStartup()
        {
            if (m_AppSettings.RememberUser)
            {
                m_LoginResult = FacebookService.Connect(m_AppSettings.Token);
                onLogin();
                initializeRememberMeCheckBox();
                rememberMeCheckBox.Checked = true;
            }
        }

        private void initializeRememberMeCheckBox()
        {
            rememberMeCheckBox.Visible = true;
        }
        
        private void initializeListBoxes()
        {
            initializeItemsListBox();
            initializeElementsListBox();
        }

        private void initializeItemsListBox()
        {
            itemsListBox.Items.Clear();
            itemsListBox.DisplayMember = "Name";
            itemsListBox.Visible = true;
            
            foreach (IUserCollectionsWrapper userItem in rm_UserWrapper.UserItems)
            {
                itemsListBox.Items.Add(userItem);
            }
        }

        private void initializeElementsListBox()
        {
            selectedElementPictureBox.Visible = true;
            elementsListBox.Visible = true;
            elementsListBox.DisplayMember = "Name";
        }

        private void itemsListBox_Click(object sender, EventArgs e)
        {
            onItemSelection();
        }

        private void onItemSelection()
        {
            if (itemsListBox.SelectedItems.Count == 1)
            {
                IUserCollectionsWrapper selectedItem = itemsListBox.SelectedItem as IUserCollectionsWrapper;

                if (selectedItem != null)
                {
                    resetElementsListBox();
                    clearItemsPanel();

                    foreach (IUserItemWrapper userItem in selectedItem.ItemWrapperCollection)
                    {
                        elementsListBox.Items.Add(userItem);
                    }
                }
            }
        }

        private void resetElementsListBox()
        {
            elementsListBox.Items.Clear();
            selectedElementPictureBox.ImageLocation = string.Empty;
        }

        private void elementsListBox_Click(object sender, EventArgs e)
        {
            onElementSelection();
        }

        private void onElementSelection()
        {
            if (elementsListBox.SelectedItems.Count == 1)
            {
                IUserItemWrapper selectedItem = elementsListBox.SelectedItem as IUserItemWrapper;

                if (selectedItem != null)
                {
                    IPanelViewable selectedViewable = PanelConvertersFactory.CreatePanelConvertor(selectedItem);
                    clearItemsPanel();
                    selectedElementPictureBox.ImageLocation = selectedItem.Picture;

                    if (selectedViewable != null)
                    {
                        foreach (Control control in selectedViewable.Controls)
                        {
                            itemsPanel.Controls.Add(control);
                        }
                    }
                }
            }
        }

        private void initializeUserWrapper()
        {
            rm_UserWrapper.UserData = m_LoginResult.LoggedInUser;
            rm_UserWrapper.ProfilePicture = pictureBoxProfile.ImageLocation;
        }

        private bool isUserLoggedIn()
        {
            return m_LoginResult != null;
        }

        private void initializeSetPictureButton()
        {
            setProfilePictureButton.Visible = true;
        }

        private void initializeWelcomeLabel()
        {
            welcomeLabel.Text = m_LoginResult.LoggedInUser.Name;
            welcomeLabel.Visible = true;
        }

        private void setProfilePictureButton_Click(object sender, EventArgs e)
        {
            onSetProfilePicture();
        }

        private void onSetProfilePicture()
        {
            rm_UserWrapper.ProfilePicture = pictureBoxProfile.ImageLocation;
            handleSetProfilePictureState();
        }

        private void handleSetProfilePictureState()
        {
            if (rm_UserWrapper.ProfilePicture.Equals(pictureBoxProfile.ImageLocation))
            {
                setProfilePictureButton.Enabled = false;
            }

            else
            {
                setProfilePictureButton.Enabled = true;
            }
        }

        private void clearItemsPanel()
        {
            foreach (Control control in itemsPanel.Controls)
            {
                control.Dispose();
            }

            itemsPanel.Controls.Clear();
        }

        private void wallListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            onPostSelection();
        }

        private void onPostSelection()
        {
            if (wallListBox.SelectedItems.Count > 0)
            {
                PostWrapper selectedPost = wallListBox.SelectedItem as PostWrapper;
                clearPostInfoLayout();
                commentsListBox.Items.Clear();

                handlePostContent(selectedPost);
                handlePostComments(selectedPost);
                handlePostInfo(selectedPost);
            }
        }

        private void handlePostContent(PostWrapper i_PostWrapper)
        {
            Label postContents = new Label
            {
                Text = i_PostWrapper.Message,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };

            postInfoLayoutPanel.Controls.Add(postContents, 0, 0);
        }

        private void handlePostPicture(ref TableLayoutPanel io_TableLayout, PostWrapper i_PostWrapper)
        {
            PictureBox pictureBoxPicture = new PictureBox
            {
                ImageLocation = i_PostWrapper.Picture,
                Dock = DockStyle.Fill
            };

            io_TableLayout.Controls.Add(pictureBoxPicture, 1, 0);
        }

        private void handlePostComments(PostWrapper i_PostWrapper)
        {
            foreach (string comment in i_PostWrapper.Comments)
            {
                commentsListBox.Items.Add(comment);
            }
        }

        private void handlePostInfo(PostWrapper i_PostWrapper)
        {
            Label label = new Label
            {
                Text =
                $"Likes: {i_PostWrapper.Likes}{Environment.NewLine}" +
                $"Date: {i_PostWrapper.CreationDate}{Environment.NewLine}" +
                $"Close Friends Only: {i_PostWrapper.CloseFriendsOnly}",
                Dock = DockStyle.Fill,
                TextAlign= ContentAlignment.MiddleCenter
            };

            postDataLayoutPanel.Controls.Add(label, 0, 0);
        }

        private void clearPostInfoLayout()
        {
            foreach (Control control in postInfoLayoutPanel.Controls)
            {
                var position = postInfoLayoutPanel.GetCellPosition(control);

                if (position.Row.Equals(0))
                {
                    control.Dispose();
                    postInfoLayoutPanel.Controls.Remove(control);
                }

                clearPostDataLayout();
            }
        }

        private void clearPostDataLayout()
        {
            foreach (Control control in postDataLayoutPanel.Controls)
            {
                var position = postDataLayoutPanel.GetCellPosition(control);

                if (position.Column.Equals(0))
                {
                    control.Dispose();
                    postDataLayoutPanel.Controls.Remove(control);
                }
            }
        }

        private void postButton_Click(object sender, EventArgs e)
        {
            onPost();
        }

        private void onPost()
        {
            try
            {
                string post = newPostTextBox.Text;
                validatePostLength(post);
                postItem(post);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void postItem(string i_Post)
        {
            PostWrapper postObject = new PostWrapper(i_Post);
            wallListBox.Items.Add(postObject);
            rm_AllPosts.Add(postObject);
            newPostTextBox.Clear();

            if (postToCloseFriendsCheckBox.Checked)
            {
                postObject.PostType = PostWrapper.ePostType.CloseFriends;
            }
        }

        private void validatePostLength(string i_Post)
        {
            if (string.IsNullOrEmpty(i_Post) || i_Post.Length > 100)
            {
                throw new Exception("Cannot post empty posts or over 100 characters!");
            }
        }

        private void sortWallComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            onSortWall();
        }

        private void onSortWall()
        {
            if (sortWallComboBox.SelectedIndex >= 0)
            {
                IComperator<PostWrapper> comperator = sortWallComboBox.SelectedItem as IComperator<PostWrapper>;

                if (comperator != null)
                {
                    rm_DisplayedPosts.Sort((x, y) => comperator.Compare(x, y));
                    reDisplayUserPosts();
                }
            }
        }

        private void reDisplayUserPosts()
        {
            wallListBox.Items.Clear();

            foreach (PostWrapper postWrapper in rm_DisplayedPosts)
            {
                wallListBox.Items.Add(postWrapper);
            }
        }

        private void filterWallComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            onFilterWall();
        }

        private void onFilterWall()
        {
            if (filterWallComboBox.SelectedIndex >= 0)
            {
                IFilterer<PostWrapper> filterer = filterWallComboBox.SelectedItem as IFilterer<PostWrapper>;

                if (filterer != null)
                {
                    rm_DisplayedPosts.Clear();
                    rm_DisplayedPosts.AddRange(rm_AllPosts.Where(x => filterer.Filter(x)));
                    reDisplayUserPosts();
                }
            }
        }

        private void timedPostButton_Click(object sender, EventArgs e)
        {
            onTimedPost();
        }

        private void onTimedPost()
        {
            try
            {
                string post = newPostTextBox.Text;
                validatePostLength(post);

                using (TimedPostForm form = new TimedPostForm())
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        DateTime selectedDateTime = form.SelectedDateTime;

                        if (selectedDateTime > DateTime.Now)
                        {
                            TimeSpan timeUntilPost = selectedDateTime - DateTime.Now;
                            Timer timer = new Timer
                            {
                                Interval = (int)timeUntilPost.TotalMilliseconds
                            };

                            timer.Tick += (s, args) =>
                            {
                                timer.Stop();
                                postItem(post);
                            };

                            timer.Start();
                        }

                        else
                        {
                            MessageBox.Show("Please select a date and time in the future.", "Invalid Time", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    newPostTextBox.Clear();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}