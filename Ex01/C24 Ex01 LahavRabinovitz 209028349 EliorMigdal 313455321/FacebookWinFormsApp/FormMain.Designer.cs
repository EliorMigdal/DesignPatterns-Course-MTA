namespace BasicFacebookFeatures
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonLogin = new System.Windows.Forms.Button();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.homeTab = new System.Windows.Forms.TabPage();
            this.welcomeLabel = new System.Windows.Forms.Label();
            this.itemsPanel = new System.Windows.Forms.TableLayoutPanel();
            this.setProfilePictureButton = new System.Windows.Forms.Button();
            this.selectedElementPictureBox = new System.Windows.Forms.PictureBox();
            this.elementsListBox = new System.Windows.Forms.ListBox();
            this.itemsListBox = new System.Windows.Forms.ListBox();
            this.rememberMeCheckBox = new System.Windows.Forms.CheckBox();
            this.profilePictureTrackBar = new System.Windows.Forms.TrackBar();
            this.pictureBoxProfile = new System.Windows.Forms.PictureBox();
            this.wallTab = new System.Windows.Forms.TabPage();
            this.postInfoLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.postDataLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.commentsListBox = new System.Windows.Forms.ListBox();
            this.timedPostButton = new System.Windows.Forms.Button();
            this.filterWallComboBox = new System.Windows.Forms.ComboBox();
            this.sortWallComboBox = new System.Windows.Forms.ComboBox();
            this.postToCloseFriendsCheckBox = new System.Windows.Forms.CheckBox();
            this.postButton = new System.Windows.Forms.Button();
            this.newPostTextBox = new System.Windows.Forms.TextBox();
            this.wallListBox = new System.Windows.Forms.ListBox();
            this.tabControl1.SuspendLayout();
            this.homeTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.selectedElementPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.profilePictureTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).BeginInit();
            this.wallTab.SuspendLayout();
            this.postInfoLayoutPanel.SuspendLayout();
            this.postDataLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonLogin
            // 
            this.buttonLogin.Location = new System.Drawing.Point(10, 17);
            this.buttonLogin.Margin = new System.Windows.Forms.Padding(4);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(130, 32);
            this.buttonLogin.TabIndex = 36;
            this.buttonLogin.Text = "Login";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // buttonLogout
            // 
            this.buttonLogout.Enabled = false;
            this.buttonLogout.Location = new System.Drawing.Point(148, 17);
            this.buttonLogout.Margin = new System.Windows.Forms.Padding(4);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(130, 32);
            this.buttonLogout.TabIndex = 52;
            this.buttonLogout.Text = "Logout";
            this.buttonLogout.UseVisualStyleBackColor = true;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.homeTab);
            this.tabControl1.Controls.Add(this.wallTab);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(835, 510);
            this.tabControl1.TabIndex = 54;
            // 
            // homeTab
            // 
            this.homeTab.Controls.Add(this.welcomeLabel);
            this.homeTab.Controls.Add(this.itemsPanel);
            this.homeTab.Controls.Add(this.setProfilePictureButton);
            this.homeTab.Controls.Add(this.selectedElementPictureBox);
            this.homeTab.Controls.Add(this.elementsListBox);
            this.homeTab.Controls.Add(this.itemsListBox);
            this.homeTab.Controls.Add(this.rememberMeCheckBox);
            this.homeTab.Controls.Add(this.profilePictureTrackBar);
            this.homeTab.Controls.Add(this.pictureBoxProfile);
            this.homeTab.Controls.Add(this.buttonLogout);
            this.homeTab.Controls.Add(this.buttonLogin);
            this.homeTab.Location = new System.Drawing.Point(4, 27);
            this.homeTab.Name = "homeTab";
            this.homeTab.Padding = new System.Windows.Forms.Padding(3);
            this.homeTab.Size = new System.Drawing.Size(827, 479);
            this.homeTab.TabIndex = 0;
            this.homeTab.Text = "Home";
            this.homeTab.UseVisualStyleBackColor = true;
            // 
            // welcomeLabel
            // 
            this.welcomeLabel.AutoSize = true;
            this.welcomeLabel.Location = new System.Drawing.Point(30, 56);
            this.welcomeLabel.Name = "welcomeLabel";
            this.welcomeLabel.Size = new System.Drawing.Size(85, 18);
            this.welcomeLabel.TabIndex = 63;
            this.welcomeLabel.Text = "Elior Migdal";
            this.welcomeLabel.Visible = false;
            // 
            // itemsPanel
            // 
            this.itemsPanel.AutoScroll = true;
            this.itemsPanel.BackColor = System.Drawing.Color.Gainsboro;
            this.itemsPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.itemsPanel.ColumnCount = 1;
            this.itemsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.itemsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.itemsPanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.itemsPanel.Location = new System.Drawing.Point(10, 283);
            this.itemsPanel.Name = "itemsPanel";
            this.itemsPanel.RowCount = 1;
            this.itemsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.itemsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.itemsPanel.Size = new System.Drawing.Size(809, 188);
            this.itemsPanel.TabIndex = 62;
            // 
            // setProfilePictureButton
            // 
            this.setProfilePictureButton.Location = new System.Drawing.Point(10, 202);
            this.setProfilePictureButton.Name = "setProfilePictureButton";
            this.setProfilePictureButton.Size = new System.Drawing.Size(130, 24);
            this.setProfilePictureButton.TabIndex = 61;
            this.setProfilePictureButton.Text = "Set Picture";
            this.setProfilePictureButton.UseVisualStyleBackColor = true;
            this.setProfilePictureButton.Visible = false;
            this.setProfilePictureButton.Click += new System.EventHandler(this.setProfilePictureButton_Click);
            // 
            // selectedElementPictureBox
            // 
            this.selectedElementPictureBox.Location = new System.Drawing.Point(754, 168);
            this.selectedElementPictureBox.Name = "selectedElementPictureBox";
            this.selectedElementPictureBox.Size = new System.Drawing.Size(67, 58);
            this.selectedElementPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.selectedElementPictureBox.TabIndex = 60;
            this.selectedElementPictureBox.TabStop = false;
            this.selectedElementPictureBox.Visible = false;
            // 
            // elementsListBox
            // 
            this.elementsListBox.FormattingEnabled = true;
            this.elementsListBox.ItemHeight = 18;
            this.elementsListBox.Location = new System.Drawing.Point(574, 17);
            this.elementsListBox.Name = "elementsListBox";
            this.elementsListBox.Size = new System.Drawing.Size(238, 184);
            this.elementsListBox.TabIndex = 59;
            this.elementsListBox.Visible = false;
            this.elementsListBox.Click += new System.EventHandler(this.elementsListBox_Click);
            // 
            // itemsListBox
            // 
            this.itemsListBox.FormattingEnabled = true;
            this.itemsListBox.ItemHeight = 18;
            this.itemsListBox.Location = new System.Drawing.Point(317, 17);
            this.itemsListBox.Name = "itemsListBox";
            this.itemsListBox.Size = new System.Drawing.Size(251, 184);
            this.itemsListBox.TabIndex = 58;
            this.itemsListBox.Visible = false;
            this.itemsListBox.Click += new System.EventHandler(this.itemsListBox_Click);
            // 
            // rememberMeCheckBox
            // 
            this.rememberMeCheckBox.AutoSize = true;
            this.rememberMeCheckBox.Location = new System.Drawing.Point(148, 56);
            this.rememberMeCheckBox.Name = "rememberMeCheckBox";
            this.rememberMeCheckBox.Size = new System.Drawing.Size(126, 22);
            this.rememberMeCheckBox.TabIndex = 57;
            this.rememberMeCheckBox.Text = "Remember Me";
            this.rememberMeCheckBox.UseVisualStyleBackColor = true;
            this.rememberMeCheckBox.Visible = false;
            this.rememberMeCheckBox.CheckedChanged += new System.EventHandler(this.rememberMeCheckBox_CheckedChanged);
            // 
            // profilePictureTrackBar
            // 
            this.profilePictureTrackBar.Location = new System.Drawing.Point(10, 232);
            this.profilePictureTrackBar.Name = "profilePictureTrackBar";
            this.profilePictureTrackBar.Size = new System.Drawing.Size(130, 45);
            this.profilePictureTrackBar.TabIndex = 56;
            this.profilePictureTrackBar.Visible = false;
            this.profilePictureTrackBar.ValueChanged += new System.EventHandler(this.profilePictureTrackBar_ValueChanged);
            // 
            // pictureBoxProfile
            // 
            this.pictureBoxProfile.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxProfile.Location = new System.Drawing.Point(10, 84);
            this.pictureBoxProfile.Name = "pictureBoxProfile";
            this.pictureBoxProfile.Size = new System.Drawing.Size(130, 117);
            this.pictureBoxProfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxProfile.TabIndex = 55;
            this.pictureBoxProfile.TabStop = false;
            // 
            // wallTab
            // 
            this.wallTab.Controls.Add(this.postInfoLayoutPanel);
            this.wallTab.Controls.Add(this.timedPostButton);
            this.wallTab.Controls.Add(this.filterWallComboBox);
            this.wallTab.Controls.Add(this.sortWallComboBox);
            this.wallTab.Controls.Add(this.postToCloseFriendsCheckBox);
            this.wallTab.Controls.Add(this.postButton);
            this.wallTab.Controls.Add(this.newPostTextBox);
            this.wallTab.Controls.Add(this.wallListBox);
            this.wallTab.Location = new System.Drawing.Point(4, 27);
            this.wallTab.Name = "wallTab";
            this.wallTab.Padding = new System.Windows.Forms.Padding(3);
            this.wallTab.Size = new System.Drawing.Size(827, 479);
            this.wallTab.TabIndex = 1;
            this.wallTab.Text = "Wall";
            this.wallTab.UseVisualStyleBackColor = true;
            // 
            // postInfoLayoutPanel
            // 
            this.postInfoLayoutPanel.BackColor = System.Drawing.Color.LightGray;
            this.postInfoLayoutPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.postInfoLayoutPanel.ColumnCount = 1;
            this.postInfoLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.postInfoLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.postInfoLayoutPanel.Controls.Add(this.postDataLayoutPanel, 0, 1);
            this.postInfoLayoutPanel.Enabled = false;
            this.postInfoLayoutPanel.Location = new System.Drawing.Point(448, 39);
            this.postInfoLayoutPanel.Name = "postInfoLayoutPanel";
            this.postInfoLayoutPanel.RowCount = 2;
            this.postInfoLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.postInfoLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.postInfoLayoutPanel.Size = new System.Drawing.Size(373, 282);
            this.postInfoLayoutPanel.TabIndex = 8;
            // 
            // postDataLayoutPanel
            // 
            this.postDataLayoutPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.postDataLayoutPanel.ColumnCount = 2;
            this.postDataLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.postDataLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.postDataLayoutPanel.Controls.Add(this.commentsListBox, 1, 0);
            this.postDataLayoutPanel.Enabled = false;
            this.postDataLayoutPanel.Location = new System.Drawing.Point(4, 144);
            this.postDataLayoutPanel.Name = "postDataLayoutPanel";
            this.postDataLayoutPanel.RowCount = 1;
            this.postDataLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.postDataLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.postDataLayoutPanel.Size = new System.Drawing.Size(365, 134);
            this.postDataLayoutPanel.TabIndex = 0;
            // 
            // commentsListBox
            // 
            this.commentsListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.commentsListBox.Enabled = false;
            this.commentsListBox.FormattingEnabled = true;
            this.commentsListBox.ItemHeight = 18;
            this.commentsListBox.Location = new System.Drawing.Point(186, 4);
            this.commentsListBox.Name = "commentsListBox";
            this.commentsListBox.Size = new System.Drawing.Size(175, 126);
            this.commentsListBox.TabIndex = 0;
            // 
            // timedPostButton
            // 
            this.timedPostButton.BackColor = System.Drawing.Color.LightYellow;
            this.timedPostButton.Enabled = false;
            this.timedPostButton.Location = new System.Drawing.Point(526, 452);
            this.timedPostButton.Name = "timedPostButton";
            this.timedPostButton.Size = new System.Drawing.Size(117, 23);
            this.timedPostButton.TabIndex = 7;
            this.timedPostButton.Text = "Timed Post";
            this.timedPostButton.UseVisualStyleBackColor = false;
            this.timedPostButton.Click += new System.EventHandler(this.timedPostButton_Click);
            // 
            // filterWallComboBox
            // 
            this.filterWallComboBox.Enabled = false;
            this.filterWallComboBox.FormattingEnabled = true;
            this.filterWallComboBox.Location = new System.Drawing.Point(321, 7);
            this.filterWallComboBox.Name = "filterWallComboBox";
            this.filterWallComboBox.Size = new System.Drawing.Size(121, 26);
            this.filterWallComboBox.TabIndex = 5;
            this.filterWallComboBox.Text = "Filter By";
            this.filterWallComboBox.SelectedIndexChanged += new System.EventHandler(this.filterWallComboBox_SelectedIndexChanged);
            // 
            // sortWallComboBox
            // 
            this.sortWallComboBox.Enabled = false;
            this.sortWallComboBox.FormattingEnabled = true;
            this.sortWallComboBox.Location = new System.Drawing.Point(3, 6);
            this.sortWallComboBox.Name = "sortWallComboBox";
            this.sortWallComboBox.Size = new System.Drawing.Size(121, 26);
            this.sortWallComboBox.Sorted = true;
            this.sortWallComboBox.TabIndex = 4;
            this.sortWallComboBox.Text = "Sort By";
            this.sortWallComboBox.SelectedIndexChanged += new System.EventHandler(this.sortWallComboBox_SelectedIndexChanged);
            // 
            // postToCloseFriendsCheckBox
            // 
            this.postToCloseFriendsCheckBox.AutoSize = true;
            this.postToCloseFriendsCheckBox.Enabled = false;
            this.postToCloseFriendsCheckBox.Location = new System.Drawing.Point(676, 452);
            this.postToCloseFriendsCheckBox.Name = "postToCloseFriendsCheckBox";
            this.postToCloseFriendsCheckBox.Size = new System.Drawing.Size(145, 22);
            this.postToCloseFriendsCheckBox.TabIndex = 3;
            this.postToCloseFriendsCheckBox.Text = "Close friends only";
            this.postToCloseFriendsCheckBox.UseVisualStyleBackColor = true;
            // 
            // postButton
            // 
            this.postButton.BackColor = System.Drawing.Color.LightGreen;
            this.postButton.Enabled = false;
            this.postButton.Location = new System.Drawing.Point(445, 452);
            this.postButton.Name = "postButton";
            this.postButton.Size = new System.Drawing.Size(75, 23);
            this.postButton.TabIndex = 2;
            this.postButton.Text = "Post";
            this.postButton.UseVisualStyleBackColor = false;
            this.postButton.Click += new System.EventHandler(this.postButton_Click);
            // 
            // newPostTextBox
            // 
            this.newPostTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.newPostTextBox.Enabled = false;
            this.newPostTextBox.Location = new System.Drawing.Point(445, 327);
            this.newPostTextBox.Multiline = true;
            this.newPostTextBox.Name = "newPostTextBox";
            this.newPostTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.newPostTextBox.Size = new System.Drawing.Size(376, 119);
            this.newPostTextBox.TabIndex = 1;
            // 
            // wallListBox
            // 
            this.wallListBox.Enabled = false;
            this.wallListBox.FormattingEnabled = true;
            this.wallListBox.ItemHeight = 18;
            this.wallListBox.Location = new System.Drawing.Point(3, 39);
            this.wallListBox.Name = "wallListBox";
            this.wallListBox.Size = new System.Drawing.Size(439, 436);
            this.wallListBox.TabIndex = 0;
            this.wallListBox.SelectedIndexChanged += new System.EventHandler(this.wallListBox_SelectedIndexChanged);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 510);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mini-Facebook";
            this.tabControl1.ResumeLayout(false);
            this.homeTab.ResumeLayout(false);
            this.homeTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.selectedElementPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.profilePictureTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).EndInit();
            this.wallTab.ResumeLayout(false);
            this.wallTab.PerformLayout();
            this.postInfoLayoutPanel.ResumeLayout(false);
            this.postDataLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

		#endregion

		private System.Windows.Forms.Button buttonLogin;
		private System.Windows.Forms.Button buttonLogout;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage homeTab;
		private System.Windows.Forms.TabPage wallTab;
        private System.Windows.Forms.PictureBox pictureBoxProfile;
        private System.Windows.Forms.TrackBar profilePictureTrackBar;
        private System.Windows.Forms.CheckBox rememberMeCheckBox;
        private System.Windows.Forms.ListBox elementsListBox;
        private System.Windows.Forms.ListBox itemsListBox;
        private System.Windows.Forms.PictureBox selectedElementPictureBox;
        private System.Windows.Forms.Button setProfilePictureButton;
        private System.Windows.Forms.TableLayoutPanel itemsPanel;
        private System.Windows.Forms.Label welcomeLabel;
        private System.Windows.Forms.TextBox newPostTextBox;
        private System.Windows.Forms.ListBox wallListBox;
        private System.Windows.Forms.Button postButton;
        private System.Windows.Forms.CheckBox postToCloseFriendsCheckBox;
        private System.Windows.Forms.ComboBox sortWallComboBox;
        private System.Windows.Forms.ComboBox filterWallComboBox;
        private System.Windows.Forms.Button timedPostButton;
        private System.Windows.Forms.TableLayoutPanel postInfoLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel postDataLayoutPanel;
        private System.Windows.Forms.ListBox commentsListBox;
    }
}

