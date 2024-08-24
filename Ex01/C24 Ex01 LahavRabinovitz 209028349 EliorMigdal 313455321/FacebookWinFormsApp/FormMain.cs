using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;
using System.Threading;
using BasicFacebookFeatures.Logic.Settings;
using BasicFacebookFeatures.Logic.UserWrapper;
using BasicFacebookFeatures.Logic.UserWrapper.UserItemsWrapper.Types;
using BasicFacebookFeatures.Logic.UserWrapper.UserItemsWrapper;
using BasicFacebookFeatures.Logic.UserWrapper.UserItemsWrapper.Types.ItemWrapper;

namespace BasicFacebookFeatures
{
    public partial class FormMain : Form
    {
        private LoginResult m_LoginResult;
        private Album m_ProfilePictures;
        private Album m_UserPictures;
        private AppSettings m_AppSettings;
        private UserWrapper m_UserWrapper = new UserWrapper();

        public FormMain()
        {
            InitializeComponent();
            Clipboard.SetText("868047088601231");
            FacebookService.s_CollectionLimit = 25;
            initializeAppSettings();
            initializeConnectionOnStartup();
            initializeListBoxes();
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
                /// (This is Desig Patter's App ID. replace it with your own)
                textBoxAppID.Text,
                /// requested permissions:
                "email",
                "public_profile"
                /// add any relevant permissions
                );

            onLogin();
        }

        private void onLogin()
        {
            if (string.IsNullOrEmpty(m_LoginResult.ErrorMessage))
            {
                buttonLogin.Text = $"Logged in as {m_LoginResult.LoggedInUser.Name}";
                buttonLogin.BackColor = Color.LightGreen;
                pictureBoxProfile.ImageLocation = m_LoginResult.LoggedInUser.PictureNormalURL;
                buttonLogin.Enabled = false;
                buttonLogout.Enabled = true;

                initializeUserWrapper();
                initializeAlbums();
                initializeTrackBar();
                initializeRememberMeCheckBox();
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
        }

        private void rememberMeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            onRemeberMeCheckBoxChanged();

            m_AppSettings.SaveToFile();
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
            
            foreach (IUserCollectionsWrapper userItem in m_UserWrapper.UserItems)
            {
                itemsListBox.Items.Add(userItem);
            }
        }

        private void initializeElementsListBox()
        {
            elementsListBox.Visible = true;
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
            string selected = elementsListBox.SelectedItem.ToString();
            string selectedItemTypes = itemsListBox.SelectedItem.ToString();

            if (selectedItemTypes.Equals("Albums"))
            {
                foreach (Album album in m_LoginResult.LoggedInUser.Albums)
                {
                    if (album.Name.Equals(selected))
                    {
                        selectedElementPictureBox.ImageLocation = album.PictureAlbumURL;
                    }
                }
            }

            else if (selectedItemTypes.Equals("Events"))
            {
                foreach (Event userEvent in m_LoginResult.LoggedInUser.Events)
                {
                    if (userEvent.Name.Equals(selected))
                    {
                        selectedElementPictureBox.ImageLocation = userEvent.PictureNormalURL;
                    }
                }
            }

            else if (selectedItemTypes.Equals("Friends"))
            {
                //hard-coded
            }

            else
            {
                foreach (Page page in m_LoginResult.LoggedInUser.LikedPages)
                {
                    if (page.Name.Equals(selected))
                    {
                        selectedElementPictureBox.ImageLocation = page.PictureNormalURL;
                    }
                }
            }

        }

        private void initializeUserWrapper()
        {
            m_UserWrapper.UserData = m_LoginResult.LoggedInUser;
        }

        private bool isUserLoggedIn()
        {
            return m_LoginResult != null;
        }
    }
}