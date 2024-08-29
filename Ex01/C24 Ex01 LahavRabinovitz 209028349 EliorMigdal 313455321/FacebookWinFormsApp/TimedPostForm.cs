using System;
using System.Windows.Forms;
using System.Drawing;

namespace BasicFacebookFeatures
{
    public partial class TimedPostForm : Form
    {
        private DateTimePicker dateTimePicker;
        private Button buttonOK;
        private Button buttonCancel;

        public DateTime SelectedDateTime { get; private set; }

        public TimedPostForm()
        {
            InitializeComponent();
            dateTimePicker.Format = DateTimePickerFormat.Custom;
            dateTimePicker.CustomFormat = "MM/dd/yyyy hh:mm tt";
            dateTimePicker.MinDate = DateTime.Now;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            handleOKClick();
        }

        private void handleOKClick()
        {
            SelectedDateTime = dateTimePicker.Value;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            handleCancelClick();
        }

        private void handleCancelClick()
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void InitializeComponent()
        {
            dateTimePicker = new DateTimePicker();
            buttonOK = new Button();
            buttonCancel = new Button();
            SuspendLayout();

            dateTimePicker.Location = new Point(12, 12);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.Size = new Size(305, 20);
            dateTimePicker.TabIndex = 0;

            buttonOK.Location = new Point(161, 64);
            buttonOK.Name = "btnOk";
            buttonOK.Size = new Size(75, 23);
            buttonOK.TabIndex = 1;
            buttonOK.Text = "OK";
            buttonOK.UseVisualStyleBackColor = true;
            buttonOK.Click += new EventHandler(buttonOK_Click);

            buttonCancel.Location = new Point(242, 64);
            buttonCancel.Name = "btnCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 2;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += new EventHandler(buttonCancel_Click);

            ClientSize = new Size(329, 94);
            Controls.Add(buttonCancel);
            Controls.Add(buttonOK);
            Controls.Add(dateTimePicker);
            Name = "TimedPostForm";
            ResumeLayout(false);
        }
    }
}