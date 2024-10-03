using System;
using System.Drawing;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;
using BasicFacebookFeatures.Logic.Settings;
using BasicFacebookFeatures.Logic.UserProxy;
using BasicFacebookFeatures.Logic.UserProxy.UserItemsAdapter;
using BasicFacebookFeatures.Logic.UserProxy.UserItemsAdapter.Types.ItemAdapter;
using BasicFacebookFeatures.PanelDecorator;
using BasicFacebookFeatures.Logic.UserProxy.UserItemsAdapter.Types.ItemAdapter.Types;
using System.Collections.Generic;
using System.Linq;
using BasicFacebookFeatures.Logic.Comperator.Types;
using BasicFacebookFeatures.Logic.Comperator;
using BasicFacebookFeatures.Logic.Filterer.Types;
using BasicFacebookFeatures.Logic.Filterer;
using System.Threading;

namespace BasicFacebookFeatures
{
    public partial class FormMain : Form
    {
        public IUserCollectionsAdapter CollectionListBoxSelectedItem { get; set; }

        private LoginResult m_LoginResult;
        private Album m_ProfilePictures;
        private AppSettings m_AppSettings;

        private readonly UserProxy r_UserProxy = new UserProxy();
        private readonly List<PostAdapter> r_DisplayedPosts = new List<PostAdapter>();
        private readonly List<PostAdapter> r_AllPosts = new List<PostAdapter>();
        private readonly string r_AppID = "868047088601231";

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
            new Thread(() =>
            {
                m_LoginResult = FacebookService.Login(r_AppID, "email", "public_profile",
                    "user_age_range", "user_birthday", "user_events", "user_friends", "user_gender",
                    "user_hometown", "user_likes", "user_link", "user_location", "user_photos",
                    "user_posts", "user_videos");

                Invoke(new MethodInvoker(() => initializeUponLogin()));
            }).Start();
        }

        private void initializeUponLogin()
        {
            if (hasSuccessfullyLoggedIn())
            {
                buttonLogout.Enabled = true;
                pictureBoxProfile.ImageLocation = m_LoginResult.LoggedInUser.PictureNormalURL;
                setProfilePictureButton.Visible = true;
                initializeRememberMeCheckBox();
                initializeLoginButton();
                initializeUserAdapter();
                initializeListBoxes();
                initializeWallTab();
                initializeWelcomeLabel();
                initializeTrackBar();
            }
        }

        private bool hasSuccessfullyLoggedIn()
        {
            return string.IsNullOrEmpty(m_LoginResult.ErrorMessage) && m_LoginResult.LoggedInUser != null;
        }

        private void initializeLoginButton()
        {
            buttonLogin.Text = "Logged in!";
            buttonLogin.BackColor = Color.LightGreen;
            buttonLogin.Enabled = false;
        }

        private void initializeRememberMeCheckBox()
        {
            rememberMeCheckBox.Visible = true;
            rememberMeCheckBox.Checked = m_AppSettings.RememberUser;
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
            new Thread(() =>
            {
                foreach (Post post in r_UserProxy.UserData.Posts)
                {
                    if (!string.IsNullOrEmpty(post.Message))
                    {
                        PostAdapter postAdapter = new PostAdapter(post);
                        r_AllPosts.Add(postAdapter);
                        Invoke(new MethodInvoker(() => wallListBox.Items.Add(postAdapter)));
                    }
                }

                r_DisplayedPosts.AddRange(r_AllPosts);
            }).Start();
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
            filterWallComboBox.DisplayMember = "Name";
            filterWallComboBox.Items.Add(new DefaultFilterer());
            filterWallComboBox.Items.Add(new CheckInFilterer());
            filterWallComboBox.Items.Add(new TextOnlyFilterer());
            filterWallComboBox.Items.Add(new ImagePostFilterer());
            filterWallComboBox.Items.Add(new CloseFriendsFilterer());
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            performLogout();
        }

        private void performLogout()
        {
            if (m_LoginResult != null)
            {
                FacebookService.LogoutWithUI();
                resetLoginButton();
                handleUserToken();
                m_LoginResult = null;
                buttonLogout.Enabled = false;
            }
        }

        private void resetLoginButton()
        {
            buttonLogin.Text = "Login";
            buttonLogin.BackColor = buttonLogout.BackColor;
            buttonLogin.Enabled = true;
        }

        private void initializeTrackBar()
        {
            new Thread(() =>
            {
                m_ProfilePictures = m_LoginResult.LoggedInUser.Albums.Find(album => album.Name.Equals("Profile pictures"));
                Invoke(new MethodInvoker(() =>
                {
                    profilePictureTrackBar.Minimum = 0;
                    profilePictureTrackBar.Maximum = Math.Min(5, (int)m_ProfilePictures?.Count);
                    profilePictureTrackBar.Visible = true;
                }));
            }).Start();
        }

        private void profilePictureTrackBar_ValueChanged(object sender, EventArgs e)
        {
            switchProfilePictures();
        }

        private void switchProfilePictures()
        {
            pictureBoxProfile.ImageLocation = m_ProfilePictures?.Photos[profilePictureTrackBar.Value].PictureNormalURL;
            handleSetProfilePictureState();
        }

        private void rememberMeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            handleAppSettingsFlag();
        }

        private void handleAppSettingsFlag()
        {
            m_AppSettings.RememberUser = rememberMeCheckBox.Checked;
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
                m_AppSettings = AppSettings.LoadAppSettings();
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
                initializeUponLogin();
                initializeRememberMeCheckBox();
            }
        }
        
        private void initializeListBoxes()
        {
            initializeItemsListBox();
            initializeElementsListBox();
        }

        private void initializeItemsListBox()
        {
            itemsListBox.DataSource = r_UserProxy.UserItems;
            itemsListBox.DisplayMember = "Name";
            itemsListBox.DataBindings.Add(new Binding("SelectedItem", this,
                "CollectionListBoxSelectedItem", true, DataSourceUpdateMode.OnPropertyChanged));
            itemsListBox.Visible = true;
        }

        private void fetchItemsListBoxData()
        {
            foreach (IUserCollectionsAdapter userItem in r_UserProxy.UserItems)
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
            fetchAndDisplaySelectedItems();
        }

        private void fetchAndDisplaySelectedItems()
        {
            if (itemsListBox.SelectedItems.Count == 1)
            {
                IUserCollectionsAdapter selectedItem = itemsListBox.SelectedItem as IUserCollectionsAdapter;

                if (selectedItem != null)
                {
                    resetElementsListBox();
                    clearItemsPanel();

                    new Thread(() =>
                    {
                        foreach (IUserItemAdapter userItem in selectedItem.ItemAdapterCollection)
                        {
                            Invoke(new MethodInvoker(() => elementsListBox.Items.Add(userItem)));
                        }
                    }).Start();
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
            handleElementSelection();
        }

        private void handleElementSelection()
        {
            if (elementsListBox.SelectedItems.Count == 1)
            {
                IUserItemAdapter selectedItem = elementsListBox.SelectedItem as IUserItemAdapter;

                new Thread(() =>
                {
                    if (selectedItem != null)
                    {
                        IPanelDecorator selectedViewable = PanelDecoratorFactory.CreatePanelConvertor(selectedItem);
                        Invoke(new MethodInvoker(() => clearItemsPanel()));
                        selectedElementPictureBox.ImageLocation = selectedItem.Picture;

                        if (selectedViewable != null)
                        {
                            foreach (Control control in selectedViewable.Controls)
                            {
                                Invoke(new MethodInvoker(() => itemsPanel.Controls.Add(control)));
                            }
                        }
                    }
                }).Start();
            }
        }

        private void initializeUserAdapter()
        {
            try
            {
                r_UserProxy.UserData = m_LoginResult.LoggedInUser;
                r_UserProxy.ProfilePicture = pictureBoxProfile.ImageLocation;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error fetching user data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool isUserLoggedIn()
        {
            return m_LoginResult != null;
        }

        private void initializeWelcomeLabel()
        {
            welcomeLabel.Text = m_LoginResult.LoggedInUser.Name;
            welcomeLabel.Visible = true;
        }

        private void setProfilePictureButton_Click(object sender, EventArgs e)
        {
            setProfilePicture();
        }

        private void setProfilePicture()
        {
            r_UserProxy.ProfilePicture = pictureBoxProfile.ImageLocation;
            handleSetProfilePictureState();
        }

        private void handleSetProfilePictureState()
        {
            if (r_UserProxy.ProfilePicture.Equals(pictureBoxProfile.ImageLocation))
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
            displayPostData();
        }

        private void displayPostData()
        {
            if (wallListBox.SelectedItems.Count == 1)
            {
                PostAdapter selectedPost = wallListBox.SelectedItem as PostAdapter;

                clearPostInfoLayout();
                commentsListBox.Items.Clear();
                handlePostContent(selectedPost);
                handlePostComments(selectedPost);
                handlePostInfo(selectedPost);
            }
        }

        private void handlePostContent(PostAdapter i_PostWrapper)
        {
            Label postContents = new Label
            {
                Text = i_PostWrapper.Message,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };

            postInfoLayoutPanel.Controls.Add(postContents, 0, 0);
        }

        private void handlePostComments(PostAdapter i_PostWrapper)
        {
            foreach (string comment in i_PostWrapper.Comments)
            {
                commentsListBox.Items.Add(comment);
            }
        }

        private void handlePostInfo(PostAdapter i_PostWrapper)
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
            addNewPost();
        }

        private void addNewPost()
        {
            try
            {
                validatePostLength(newPostTextBox.Text);
                postItem(newPostTextBox.Text);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void postItem(string i_Post)
        {
            PostAdapter postObject = new PostAdapter(i_Post);

            wallListBox.Items.Add(postObject);
            r_AllPosts.Add(postObject);
            newPostTextBox.Clear();

            if (postToCloseFriendsCheckBox.Checked)
            {
                postObject.PostType = PostAdapter.ePostType.CloseFriends;
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
            sortWall();
        }

        private void sortWall()
        {
            if (sortWallComboBox.SelectedIndex >= 0)
            {
                IComperator<PostAdapter> comperator = sortWallComboBox.SelectedItem as IComperator<PostAdapter>;

                if (comperator != null)
                {
                    r_DisplayedPosts.Sort((x, y) => comperator.Compare(x, y));
                    reDisplayUserPosts();
                }
            }
        }

        private void reDisplayUserPosts()
        {
            wallListBox.Items.Clear();

            foreach (PostAdapter postWrapper in r_DisplayedPosts)
            {
                wallListBox.Items.Add(postWrapper);
            }
        }

        private void filterWallComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterWall();
        }

        private void filterWall()
        {
            if (filterWallComboBox.SelectedIndex >= 0)
            {
                IFilterer<PostAdapter> filterer = filterWallComboBox.SelectedItem as IFilterer<PostAdapter>;

                if (filterer != null)
                {
                    r_DisplayedPosts.Clear();
                    r_DisplayedPosts.AddRange(r_AllPosts.Where(x => filterer.Filter(x)));
                    reDisplayUserPosts();
                }
            }
        }

        private void timedPostButton_Click(object sender, EventArgs e)
        {
            timePost();
        }

        private void timePost()
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
                            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer
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