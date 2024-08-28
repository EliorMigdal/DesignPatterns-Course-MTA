using System;
using System.Windows.Forms;

namespace BasicFacebookFeatures
{
    public partial class TimedPostForm : Form
    {
        private DateTimePicker dateTimePicker;
        private Button btnOk;
        private Button btnCancel;

        public DateTime SelectedDateTime { get; private set; }

        public TimedPostForm()
        {
            InitializeComponent();
            // Initialize the DateTimePicker control
            dateTimePicker.Format = DateTimePickerFormat.Custom;
            dateTimePicker.CustomFormat = "MM/dd/yyyy hh:mm tt"; // Adjust the format as needed
            dateTimePicker.MinDate = DateTime.Now; // Disable past dates
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SelectedDateTime = dateTimePicker.Value;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void InitializeComponent()
        {
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(12, 12);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(305, 20);
            this.dateTimePicker.TabIndex = 0;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(161, 64);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(242, 64);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // TimedPostForm
            // 
            this.ClientSize = new System.Drawing.Size(329, 94);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.dateTimePicker);
            this.Name = "TimedPostForm";
            this.ResumeLayout(false);

        }
    }

}
