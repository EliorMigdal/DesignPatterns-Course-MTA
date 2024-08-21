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
using BasicFacebookFeatures.Logic;

namespace BasicFacebookFeatures
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            Clipboard.SetText("868047088601231");
            FacebookService.s_CollectionLimit = 25;
            initializeAppSettings();
            initializeConnectionOnStartup();
            initializeItemsListBox();
        }

        private LoginResult m_LoginResult;
        private Album m_ProfilePictures;
        private Album m_UserPictures;
        private AppSettings m_AppSettings;

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
                initializeAlbums();
                initializeTrackBar();
                initializeRememberMeCheckBox();
            }
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            FacebookService.LogoutWithUI();
            buttonLogin.Text = "Login";
            buttonLogin.BackColor = buttonLogout.BackColor;
            m_LoginResult = null;
            buttonLogin.Enabled = true;
            buttonLogout.Enabled = false;
        }

        private void initializeAlbums()
        {
            m_ProfilePictures = m_LoginResult.LoggedInUser.Albums.Find(album => album.Name.Equals("Profile pictures"));
        }

        private void initializeTrackBar()
        {
            profilePictureTrackBar.Minimum = 0;
            profilePictureTrackBar.Maximum = Math.Min(5, (int) m_ProfilePictures.Count);
            profilePictureTrackBar.Visible = true;
        }

        private void profilePictureTrackBar_ValueChanged(object sender, EventArgs e)
        {
            if (m_ProfilePictures != null)
            {
                pictureBoxProfile.ImageLocation = m_ProfilePictures.Photos[profilePictureTrackBar.Value].PictureNormalURL;
            }
        }

        private void rememberMeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (rememberMeCheckBox.Checked)
            {
                m_AppSettings.RememberUser = true;
                m_AppSettings.Token = m_LoginResult.FacebookOAuthResult.AccessToken;
            }

            else
            {
                m_AppSettings.RememberUser = false;
                m_AppSettings.Token = string.Empty;
            }

            m_AppSettings.SaveToFile();
        }

        private void initializeAppSettings()
        {
            m_AppSettings = AppSettings.LoadFromFile();
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

        private void initializeItemsListBox()
        {
            itemsListBox.Items.Clear();
            itemsListBox.Items.Add("Albums");
            itemsListBox.Items.Add("Events");
            itemsListBox.Items.Add("Friends");
            itemsListBox.Items.Add("Liked Pages");
        }

        private void itemsListBox_Click(object sender, EventArgs e)
        {
            string selected = itemsListBox.SelectedItem.ToString();
            List<string> items = new List<string>();

            if (selected.Equals("Albums"))
            {
                foreach (Album album in m_LoginResult.LoggedInUser.Albums)
                {
                    items.Add(album.Name);
                }
            }

            else if (selected.Equals("Events"))
            {
                foreach (Event userEvent in m_LoginResult.LoggedInUser.Events)
                {
                    items.Add(userEvent.Name);
                }
            }

            else if (selected.Equals("Friends"))
            {
                //hard-coded
            }

            else
            {
                foreach (Page userEvent in m_LoginResult.LoggedInUser.LikedPages)
                {
                    items.Add(userEvent.Name);
                }
            }

            elementsListBox.Items.Clear();

            foreach (string item in items)
            {
                elementsListBox.Items.Add(item);
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
    }
}
