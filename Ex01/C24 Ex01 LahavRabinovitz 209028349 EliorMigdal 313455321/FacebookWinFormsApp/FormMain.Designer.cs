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
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.itemsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.setProfilePictureButton = new System.Windows.Forms.Button();
            this.selectedElementPictureBox = new System.Windows.Forms.PictureBox();
            this.elementsListBox = new System.Windows.Forms.ListBox();
            this.itemsListBox = new System.Windows.Forms.ListBox();
            this.rememberMeCheckBox = new System.Windows.Forms.CheckBox();
            this.profilePictureTrackBar = new System.Windows.Forms.TrackBar();
            this.pictureBoxProfile = new System.Windows.Forms.PictureBox();
            this.textBoxAppID = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.selectedElementPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.profilePictureTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonLogin
            // 
            this.buttonLogin.Location = new System.Drawing.Point(18, 17);
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
            this.buttonLogout.Location = new System.Drawing.Point(155, 17);
            this.buttonLogout.Margin = new System.Windows.Forms.Padding(4);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(130, 32);
            this.buttonLogout.TabIndex = 52;
            this.buttonLogout.Text = "Logout";
            this.buttonLogout.UseVisualStyleBackColor = true;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(314, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(241, 18);
            this.label1.TabIndex = 53;
            this.label1.Text = "Type here your own AppID to test it:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(835, 510);
            this.tabControl1.TabIndex = 54;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.itemsPanel);
            this.tabPage1.Controls.Add(this.setProfilePictureButton);
            this.tabPage1.Controls.Add(this.selectedElementPictureBox);
            this.tabPage1.Controls.Add(this.elementsListBox);
            this.tabPage1.Controls.Add(this.itemsListBox);
            this.tabPage1.Controls.Add(this.rememberMeCheckBox);
            this.tabPage1.Controls.Add(this.profilePictureTrackBar);
            this.tabPage1.Controls.Add(this.pictureBoxProfile);
            this.tabPage1.Controls.Add(this.textBoxAppID);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.buttonLogout);
            this.tabPage1.Controls.Add(this.buttonLogin);
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(827, 479);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // itemsPanel
            // 
            this.itemsPanel.AutoScroll = true;
            this.itemsPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.itemsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.itemsPanel.Location = new System.Drawing.Point(3, 314);
            this.itemsPanel.Name = "itemsPanel";
            this.itemsPanel.Size = new System.Drawing.Size(821, 162);
            this.itemsPanel.TabIndex = 62;
            this.itemsPanel.WrapContents = false;
            // 
            // setProfilePictureButton
            // 
            this.setProfilePictureButton.Location = new System.Drawing.Point(43, 228);
            this.setProfilePictureButton.Name = "setProfilePictureButton";
            this.setProfilePictureButton.Size = new System.Drawing.Size(142, 24);
            this.setProfilePictureButton.TabIndex = 61;
            this.setProfilePictureButton.Text = "Set Profile Picture";
            this.setProfilePictureButton.UseVisualStyleBackColor = true;
            this.setProfilePictureButton.Visible = false;
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
            this.itemsListBox.Location = new System.Drawing.Point(317, 68);
            this.itemsListBox.Name = "itemsListBox";
            this.itemsListBox.Size = new System.Drawing.Size(238, 130);
            this.itemsListBox.TabIndex = 58;
            this.itemsListBox.Visible = false;
            this.itemsListBox.Click += new System.EventHandler(this.itemsListBox_Click);
            // 
            // rememberMeCheckBox
            // 
            this.rememberMeCheckBox.AutoSize = true;
            this.rememberMeCheckBox.Location = new System.Drawing.Point(22, 56);
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
            this.profilePictureTrackBar.Location = new System.Drawing.Point(18, 258);
            this.profilePictureTrackBar.Name = "profilePictureTrackBar";
            this.profilePictureTrackBar.Size = new System.Drawing.Size(189, 45);
            this.profilePictureTrackBar.TabIndex = 56;
            this.profilePictureTrackBar.Visible = false;
            this.profilePictureTrackBar.ValueChanged += new System.EventHandler(this.profilePictureTrackBar_ValueChanged);
            // 
            // pictureBoxProfile
            // 
            this.pictureBoxProfile.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxProfile.Location = new System.Drawing.Point(18, 84);
            this.pictureBoxProfile.Name = "pictureBoxProfile";
            this.pictureBoxProfile.Size = new System.Drawing.Size(189, 168);
            this.pictureBoxProfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxProfile.TabIndex = 55;
            this.pictureBoxProfile.TabStop = false;
            // 
            // textBoxAppID
            // 
            this.textBoxAppID.Location = new System.Drawing.Point(317, 38);
            this.textBoxAppID.Name = "textBoxAppID";
            this.textBoxAppID.Size = new System.Drawing.Size(237, 24);
            this.textBoxAppID.TabIndex = 54;
            this.textBoxAppID.Text = "868047088601231";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(827, 479);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
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
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.selectedElementPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.profilePictureTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).EndInit();
            this.ResumeLayout(false);

        }

		#endregion

		private System.Windows.Forms.Button buttonLogin;
		private System.Windows.Forms.Button buttonLogout;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox textBoxAppID;
        private System.Windows.Forms.PictureBox pictureBoxProfile;
        private System.Windows.Forms.TrackBar profilePictureTrackBar;
        private System.Windows.Forms.CheckBox rememberMeCheckBox;
        private System.Windows.Forms.ListBox elementsListBox;
        private System.Windows.Forms.ListBox itemsListBox;
        private System.Windows.Forms.PictureBox selectedElementPictureBox;
        private System.Windows.Forms.Button setProfilePictureButton;
        private System.Windows.Forms.FlowLayoutPanel itemsPanel;
    }
}

