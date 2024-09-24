using System;
using System.Windows.Forms;
using System.Drawing;

namespace BasicFacebookFeatures
{
    public partial class TimedPostForm : Form
    {
        private DateTimePicker m_DateTimePicker;
        private Button m_ButtonOk;
        private Button m_ButtonCancel;

        public DateTime SelectedDateTime { get; private set; }

        public TimedPostForm()
        {
            InitializeComponent();
            m_DateTimePicker.Format = DateTimePickerFormat.Custom;
            m_DateTimePicker.CustomFormat = "MM/dd/yyyy hh:mm tt";
            m_DateTimePicker.MinDate = DateTime.Now;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            handleOKClick();
        }

        private void handleOKClick()
        {
            SelectedDateTime = m_DateTimePicker.Value;
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
            m_DateTimePicker = new DateTimePicker();
            m_ButtonOk = new Button();
            m_ButtonCancel = new Button();
            SuspendLayout();

            m_DateTimePicker.Location = new Point(12, 12);
            m_DateTimePicker.Name = "dateTimePicker";
            m_DateTimePicker.Size = new Size(305, 20);
            m_DateTimePicker.TabIndex = 0;

            m_ButtonOk.Location = new Point(161, 64);
            m_ButtonOk.Name = "btnOk";
            m_ButtonOk.Size = new Size(75, 23);
            m_ButtonOk.TabIndex = 1;
            m_ButtonOk.Text = "OK";
            m_ButtonOk.UseVisualStyleBackColor = true;
            m_ButtonOk.Click += new EventHandler(buttonOK_Click);

            m_ButtonCancel.Location = new Point(242, 64);
            m_ButtonCancel.Name = "btnCancel";
            m_ButtonCancel.Size = new Size(75, 23);
            m_ButtonCancel.TabIndex = 2;
            m_ButtonCancel.Text = "Cancel";
            m_ButtonCancel.UseVisualStyleBackColor = true;
            m_ButtonCancel.Click += new EventHandler(buttonCancel_Click);

            ClientSize = new Size(329, 94);
            Controls.Add(m_ButtonCancel);
            Controls.Add(m_ButtonOk);
            Controls.Add(m_DateTimePicker);
            Name = "TimedPostForm";
            ResumeLayout(false);
        }
    }
}