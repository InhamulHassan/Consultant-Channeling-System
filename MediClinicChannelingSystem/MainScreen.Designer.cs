namespace MediClinicChannelingSystem
{
    partial class MainScreen
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbConsultantName = new System.Windows.Forms.ComboBox();
            this.cmbSpeciality = new System.Windows.Forms.ComboBox();
            this.cmbHospitalName = new System.Windows.Forms.ComboBox();
            this.pnlScroll = new System.Windows.Forms.Panel();
            this.flwpnlConsultantInfo = new System.Windows.Forms.FlowLayoutPanel();
            this.gboxPatientDetails = new System.Windows.Forms.GroupBox();
            this.btnBookNow = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtContactNumber = new System.Windows.Forms.MaskedTextBox();
            this.txtPatientAge = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lnkAdminLogin = new System.Windows.Forms.LinkLabel();
            this.btnStatus = new System.Windows.Forms.Button();
            this.pnlScroll.SuspendLayout();
            this.gboxPatientDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bell MT", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(37, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Consultant Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bell MT", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(37, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(210, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Speciality - Description";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bell MT", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(37, 202);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Hospital";
            // 
            // cmbConsultantName
            // 
            this.cmbConsultantName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbConsultantName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbConsultantName.Font = new System.Drawing.Font("Century", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbConsultantName.FormattingEnabled = true;
            this.cmbConsultantName.Location = new System.Drawing.Point(312, 48);
            this.cmbConsultantName.Name = "cmbConsultantName";
            this.cmbConsultantName.Size = new System.Drawing.Size(363, 31);
            this.cmbConsultantName.TabIndex = 3;
            this.cmbConsultantName.SelectedIndexChanged += new System.EventHandler(this.cmbConsultantName_SelectedIndexChanged);
            this.cmbConsultantName.SelectionChangeCommitted += new System.EventHandler(this.cmbConsultantName_SelectionChangeCommitted);
            this.cmbConsultantName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbConsultantName_KeyPress);
            // 
            // cmbSpeciality
            // 
            this.cmbSpeciality.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbSpeciality.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSpeciality.Font = new System.Drawing.Font("Century", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSpeciality.FormattingEnabled = true;
            this.cmbSpeciality.Location = new System.Drawing.Point(312, 125);
            this.cmbSpeciality.Name = "cmbSpeciality";
            this.cmbSpeciality.Size = new System.Drawing.Size(363, 31);
            this.cmbSpeciality.TabIndex = 4;
            this.cmbSpeciality.SelectedIndexChanged += new System.EventHandler(this.cmbSpeciality_SelectedIndexChanged);
            this.cmbSpeciality.SelectionChangeCommitted += new System.EventHandler(this.cmbSpeciality_SelectionChangeCommitted);
            this.cmbSpeciality.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbSpeciality_KeyPress);
            // 
            // cmbHospitalName
            // 
            this.cmbHospitalName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbHospitalName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbHospitalName.Font = new System.Drawing.Font("Century", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbHospitalName.FormattingEnabled = true;
            this.cmbHospitalName.Location = new System.Drawing.Point(312, 199);
            this.cmbHospitalName.Name = "cmbHospitalName";
            this.cmbHospitalName.Size = new System.Drawing.Size(363, 31);
            this.cmbHospitalName.TabIndex = 5;
            this.cmbHospitalName.SelectedIndexChanged += new System.EventHandler(this.cmbHospitalName_SelectedIndexChanged);
            this.cmbHospitalName.SelectionChangeCommitted += new System.EventHandler(this.cmbHospitalName_SelectionChangeCommitted);
            this.cmbHospitalName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbHospitalName_KeyPress);
            // 
            // pnlScroll
            // 
            this.pnlScroll.AutoScroll = true;
            this.pnlScroll.Controls.Add(this.flwpnlConsultantInfo);
            this.pnlScroll.Location = new System.Drawing.Point(-2, 262);
            this.pnlScroll.Name = "pnlScroll";
            this.pnlScroll.Size = new System.Drawing.Size(1362, 465);
            this.pnlScroll.TabIndex = 6;
            // 
            // flwpnlConsultantInfo
            // 
            this.flwpnlConsultantInfo.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flwpnlConsultantInfo.Location = new System.Drawing.Point(14, 17);
            this.flwpnlConsultantInfo.Name = "flwpnlConsultantInfo";
            this.flwpnlConsultantInfo.Size = new System.Drawing.Size(1326, 445);
            this.flwpnlConsultantInfo.TabIndex = 0;
            // 
            // gboxPatientDetails
            // 
            this.gboxPatientDetails.Controls.Add(this.btnStatus);
            this.gboxPatientDetails.Controls.Add(this.btnBookNow);
            this.gboxPatientDetails.Controls.Add(this.label6);
            this.gboxPatientDetails.Controls.Add(this.label5);
            this.gboxPatientDetails.Controls.Add(this.label4);
            this.gboxPatientDetails.Controls.Add(this.txtContactNumber);
            this.gboxPatientDetails.Controls.Add(this.txtPatientAge);
            this.gboxPatientDetails.Controls.Add(this.txtLastName);
            this.gboxPatientDetails.Controls.Add(this.txtFirstName);
            this.gboxPatientDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gboxPatientDetails.Font = new System.Drawing.Font("Lucida Bright", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gboxPatientDetails.Location = new System.Drawing.Point(787, 12);
            this.gboxPatientDetails.Name = "gboxPatientDetails";
            this.gboxPatientDetails.Size = new System.Drawing.Size(573, 244);
            this.gboxPatientDetails.TabIndex = 7;
            this.gboxPatientDetails.TabStop = false;
            this.gboxPatientDetails.Text = "Patient Information";
            // 
            // btnBookNow
            // 
            this.btnBookNow.BackColor = System.Drawing.SystemColors.Control;
            this.btnBookNow.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnBookNow.FlatAppearance.BorderSize = 2;
            this.btnBookNow.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGreen;
            this.btnBookNow.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PaleGreen;
            this.btnBookNow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBookNow.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBookNow.ForeColor = System.Drawing.Color.Black;
            this.btnBookNow.Location = new System.Drawing.Point(343, 187);
            this.btnBookNow.Name = "btnBookNow";
            this.btnBookNow.Size = new System.Drawing.Size(202, 48);
            this.btnBookNow.TabIndex = 4;
            this.btnBookNow.Text = "Book Now";
            this.btnBookNow.UseVisualStyleBackColor = false;
            this.btnBookNow.Click += new System.EventHandler(this.btnBookNow_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(134, 20);
            this.label6.TabIndex = 3;
            this.label6.Text = "Contact Number";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 20);
            this.label5.TabIndex = 3;
            this.label5.Text = "Patient\'s Age";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Patient\'s Full Name";
            // 
            // txtContactNumber
            // 
            this.txtContactNumber.AllowPromptAsInput = false;
            this.txtContactNumber.BeepOnError = true;
            this.txtContactNumber.HidePromptOnLeave = true;
            this.txtContactNumber.Location = new System.Drawing.Point(190, 147);
            this.txtContactNumber.Mask = "(999) 000-0000";
            this.txtContactNumber.Name = "txtContactNumber";
            this.txtContactNumber.RejectInputOnFirstFailure = true;
            this.txtContactNumber.Size = new System.Drawing.Size(176, 26);
            this.txtContactNumber.TabIndex = 3;
            // 
            // txtPatientAge
            // 
            this.txtPatientAge.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPatientAge.Location = new System.Drawing.Point(190, 95);
            this.txtPatientAge.Name = "txtPatientAge";
            this.txtPatientAge.Size = new System.Drawing.Size(54, 29);
            this.txtPatientAge.TabIndex = 2;
            this.txtPatientAge.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPatientAge_KeyPress);
            // 
            // txtLastName
            // 
            this.txtLastName.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLastName.Location = new System.Drawing.Point(372, 41);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(173, 29);
            this.txtLastName.TabIndex = 1;
            this.txtLastName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLastName_KeyPress);
            // 
            // txtFirstName
            // 
            this.txtFirstName.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFirstName.Location = new System.Drawing.Point(190, 41);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(176, 29);
            this.txtFirstName.TabIndex = 0;
            this.txtFirstName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFirstName_KeyPress);
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkRate = 400;
            this.errorProvider1.ContainerControl = this;
            // 
            // lnkAdminLogin
            // 
            this.lnkAdminLogin.AutoSize = true;
            this.lnkAdminLogin.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkAdminLogin.Location = new System.Drawing.Point(12, 12);
            this.lnkAdminLogin.Name = "lnkAdminLogin";
            this.lnkAdminLogin.Size = new System.Drawing.Size(408, 18);
            this.lnkAdminLogin.TabIndex = 8;
            this.lnkAdminLogin.TabStop = true;
            this.lnkAdminLogin.Text = "Click here to login with Administrator Priviledges";
            this.lnkAdminLogin.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAdminLogin_LinkClicked);
            // 
            // btnStatus
            // 
            this.btnStatus.BackColor = System.Drawing.SystemColors.Control;
            this.btnStatus.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnStatus.FlatAppearance.BorderSize = 2;
            this.btnStatus.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGreen;
            this.btnStatus.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PaleGreen;
            this.btnStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStatus.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStatus.ForeColor = System.Drawing.Color.Black;
            this.btnStatus.Location = new System.Drawing.Point(10, 187);
            this.btnStatus.Name = "btnStatus";
            this.btnStatus.Size = new System.Drawing.Size(151, 48);
            this.btnStatus.TabIndex = 4;
            this.btnStatus.Text = "Edit Appointment\r\nStatus";
            this.btnStatus.UseVisualStyleBackColor = false;
            this.btnStatus.Click += new System.EventHandler(this.btnStatus_Click);
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.lnkAdminLogin);
            this.Controls.Add(this.gboxPatientDetails);
            this.Controls.Add(this.pnlScroll);
            this.Controls.Add(this.cmbHospitalName);
            this.Controls.Add(this.cmbSpeciality);
            this.Controls.Add(this.cmbConsultantName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "MainScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Channeling Page";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainScreen_Load);
            this.pnlScroll.ResumeLayout(false);
            this.gboxPatientDetails.ResumeLayout(false);
            this.gboxPatientDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbConsultantName;
        private System.Windows.Forms.ComboBox cmbSpeciality;
        private System.Windows.Forms.ComboBox cmbHospitalName;
        private System.Windows.Forms.Panel pnlScroll;
        private System.Windows.Forms.FlowLayoutPanel flwpnlConsultantInfo;
        private System.Windows.Forms.GroupBox gboxPatientDetails;
        private System.Windows.Forms.Button btnBookNow;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPatientAge;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.MaskedTextBox txtContactNumber;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.LinkLabel lnkAdminLogin;
        private System.Windows.Forms.Button btnStatus;
    }
}