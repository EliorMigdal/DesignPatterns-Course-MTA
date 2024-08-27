using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;
using BasicFacebookFeatures.Logic.Settings;
using BasicFacebookFeatures.Logic.UserWrapper;
using BasicFacebookFeatures.Logic.UserWrapper.UserItemsWrapper;
using BasicFacebookFeatures.Logic.UserWrapper.UserItemsWrapper.Types.ItemWrapper;
using BasicFacebookFeatures.Logic.UserWrapper.UserItemsWrapper.Types.ItemWrapper.Types;
using BasicFacebookFeatures.CustomeData;
using BasicFacebookFeatures.PanelConversion;

namespace BasicFacebookFeatures
{
    public partial class FormMain : Form
    {
        private LoginResult m_LoginResult;
        private Album m_ProfilePictures;
        private AppSettings m_AppSettings;
        private readonly UserWrapper rm_UserWrapper = new UserWrapper();
        private readonly PanelConvertorsFactory rm_ConverterFactory = new PanelConvertorsFactory();

        public FormMain()
        {
            InitializeComponent();
            //Clipboard.SetText("868047088601231");
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
            m_LoginResult = FacebookService.Login(
                textBoxAppID.Text,
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
                    "user_videos");

            onLogin();
        }

        private void onLogin()
        {
            if (string.IsNullOrEmpty(m_LoginResult.ErrorMessage))
            {
                buttonLogin.Text = "Logged in!";
                buttonLogin.BackColor = Color.LightGreen;
                pictureBoxProfile.ImageLocation = m_LoginResult.LoggedInUser.PictureNormalURL;
                buttonLogin.Enabled = false;
                buttonLogout.Enabled = true;

                initializeWelcomeLabel();
                initializeUserWrapper();
                initializeAlbums();
                initializeTrackBar();
                initializeSetPictureButton();
                initializeRememberMeCheckBox();
                initializeListBoxes();
            }
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
            elementsListBox.Visible = true;
            selectedElementPictureBox.Visible = true;
        }

        private void itemsListBox_Click(object sender, EventArgs e)
        {
            if (itemsListBox.SelectedItems.Count == 1)
            {
                IUserCollectionsWrapper selectedItem = itemsListBox.SelectedItem as IUserCollectionsWrapper;

                elementsListBox.Items.Clear();
                elementsListBox.DisplayMember = "Name";

                foreach (IUserItemWrapper userItem in selectedItem.ItemWrapperCollection)
                {
                    elementsListBox.Items.Add(userItem);
                }
            }
        }

        private void elementsListBox_Click(object sender, EventArgs e)
        {
            if (elementsListBox.SelectedItems.Count == 1)
            {
                IUserItemWrapper selectedItem = elementsListBox.SelectedItem as IUserItemWrapper;
                itemsPanel.Controls.Clear();

                selectedElementPictureBox.ImageLocation = selectedItem.Picture;
                IPanelViewable selectedViewable = rm_ConverterFactory.CreatePanelConvertor(selectedItem);

                if (selectedViewable != null)
                {
                    foreach (Control control in selectedViewable.Controls)
                    {
                        itemsPanel.Controls.Add(control);
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
    }
}