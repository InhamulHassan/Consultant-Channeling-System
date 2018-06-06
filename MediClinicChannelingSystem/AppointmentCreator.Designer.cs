namespace MediClinicChannelingSystem
{
    partial class AppointmentCreator
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.pnlPatientFind = new System.Windows.Forms.Panel();
            this.lblPatientInfoShow = new System.Windows.Forms.Label();
            this.txtPatientFind = new System.Windows.Forms.TextBox();
            this.pnlPatientShow = new System.Windows.Forms.Panel();
            this.lblNewPatientInfo = new System.Windows.Forms.Label();
            this.pnlStatus = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rdb5 = new System.Windows.Forms.RadioButton();
            this.rdb4 = new System.Windows.Forms.RadioButton();
            this.rdb3 = new System.Windows.Forms.RadioButton();
            this.rdb2 = new System.Windows.Forms.RadioButton();
            this.rdb1 = new System.Windows.Forms.RadioButton();
            this.btnGoBack = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.pnlPatientFind.SuspendLayout();
            this.pnlPatientShow.SuspendLayout();
            this.pnlStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.btnConfirm);
            this.panel1.Controls.Add(this.pnlPatientFind);
            this.panel1.Controls.Add(this.pnlPatientShow);
            this.panel1.Controls.Add(this.pnlStatus);
            this.panel1.Controls.Add(this.btnGoBack);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(546, 237);
            this.panel1.TabIndex = 0;
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnConfirm.Font = new System.Drawing.Font("Segoe WP", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.Location = new System.Drawing.Point(381, 188);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(162, 41);
            this.btnConfirm.TabIndex = 10;
            this.btnConfirm.Text = "Confirm Appointment\r\nF5";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // pnlPatientFind
            // 
            this.pnlPatientFind.Controls.Add(this.lblPatientInfoShow);
            this.pnlPatientFind.Controls.Add(this.txtPatientFind);
            this.pnlPatientFind.Location = new System.Drawing.Point(210, 3);
            this.pnlPatientFind.Name = "pnlPatientFind";
            this.pnlPatientFind.Size = new System.Drawing.Size(336, 100);
            this.pnlPatientFind.TabIndex = 1;
            // 
            // lblPatientInfoShow
            // 
            this.lblPatientInfoShow.Location = new System.Drawing.Point(3, 28);
            this.lblPatientInfoShow.Name = "lblPatientInfoShow";
            this.lblPatientInfoShow.Size = new System.Drawing.Size(330, 72);
            this.lblPatientInfoShow.TabIndex = 1;
            this.lblPatientInfoShow.Text = "Enter the patient\'s name in the search box above";
            // 
            // txtPatientFind
            // 
            this.txtPatientFind.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtPatientFind.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtPatientFind.Location = new System.Drawing.Point(3, 5);
            this.txtPatientFind.Name = "txtPatientFind";
            this.txtPatientFind.Size = new System.Drawing.Size(205, 20);
            this.txtPatientFind.TabIndex = 0;
            this.txtPatientFind.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPatientFind_KeyDown);
            // 
            // pnlPatientShow
            // 
            this.pnlPatientShow.Controls.Add(this.lblNewPatientInfo);
            this.pnlPatientShow.Location = new System.Drawing.Point(210, 4);
            this.pnlPatientShow.Name = "pnlPatientShow";
            this.pnlPatientShow.Size = new System.Drawing.Size(333, 100);
            this.pnlPatientShow.TabIndex = 9;
            this.pnlPatientShow.Visible = false;
            // 
            // lblNewPatientInfo
            // 
            this.lblNewPatientInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNewPatientInfo.Location = new System.Drawing.Point(0, 0);
            this.lblNewPatientInfo.Name = "lblNewPatientInfo";
            this.lblNewPatientInfo.Size = new System.Drawing.Size(333, 100);
            this.lblNewPatientInfo.TabIndex = 0;
            this.lblNewPatientInfo.Text = "label2";
            this.lblNewPatientInfo.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // pnlStatus
            // 
            this.pnlStatus.Controls.Add(this.label1);
            this.pnlStatus.Controls.Add(this.rdb5);
            this.pnlStatus.Controls.Add(this.rdb4);
            this.pnlStatus.Controls.Add(this.rdb3);
            this.pnlStatus.Controls.Add(this.rdb2);
            this.pnlStatus.Controls.Add(this.rdb1);
            this.pnlStatus.Font = new System.Drawing.Font("Segoe UI Symbol", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlStatus.Location = new System.Drawing.Point(4, 102);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Size = new System.Drawing.Size(200, 132);
            this.pnlStatus.TabIndex = 8;
            this.pnlStatus.TabStop = false;
            this.pnlStatus.Text = "Appointment Status";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI Symbol", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 118);
            this.label1.TabIndex = 1;
            this.label1.Text = "1.\r\n\r\n2.\r\n\r\n3.\r\n\r\n4.\r\n\r\n5.";
            // 
            // rdb5
            // 
            this.rdb5.AutoSize = true;
            this.rdb5.Font = new System.Drawing.Font("Segoe UI Symbol", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdb5.Location = new System.Drawing.Point(40, 110);
            this.rdb5.Name = "rdb5";
            this.rdb5.Size = new System.Drawing.Size(147, 17);
            this.rdb5.TabIndex = 0;
            this.rdb5.TabStop = true;
            this.rdb5.Text = "Patient Failed to Attend";
            this.rdb5.UseVisualStyleBackColor = true;
            // 
            // rdb4
            // 
            this.rdb4.AutoSize = true;
            this.rdb4.Font = new System.Drawing.Font("Segoe UI Symbol", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdb4.Location = new System.Drawing.Point(40, 86);
            this.rdb4.Name = "rdb4";
            this.rdb4.Size = new System.Drawing.Size(60, 17);
            this.rdb4.TabIndex = 0;
            this.rdb4.TabStop = true;
            this.rdb4.Text = "Visited";
            this.rdb4.UseVisualStyleBackColor = true;
            // 
            // rdb3
            // 
            this.rdb3.AutoSize = true;
            this.rdb3.Font = new System.Drawing.Font("Segoe UI Symbol", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdb3.Location = new System.Drawing.Point(40, 62);
            this.rdb3.Name = "rdb3";
            this.rdb3.Size = new System.Drawing.Size(129, 17);
            this.rdb3.TabIndex = 0;
            this.rdb3.TabStop = true;
            this.rdb3.Text = "Cancelled by Patient";
            this.rdb3.UseVisualStyleBackColor = true;
            // 
            // rdb2
            // 
            this.rdb2.AutoSize = true;
            this.rdb2.Font = new System.Drawing.Font("Segoe UI Symbol", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdb2.Location = new System.Drawing.Point(40, 39);
            this.rdb2.Name = "rdb2";
            this.rdb2.Size = new System.Drawing.Size(141, 17);
            this.rdb2.TabIndex = 0;
            this.rdb2.TabStop = true;
            this.rdb2.Text = "Approved and Booked";
            this.rdb2.UseVisualStyleBackColor = true;
            // 
            // rdb1
            // 
            this.rdb1.AutoSize = true;
            this.rdb1.Font = new System.Drawing.Font("Segoe UI Symbol", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdb1.Location = new System.Drawing.Point(40, 14);
            this.rdb1.Name = "rdb1";
            this.rdb1.Size = new System.Drawing.Size(135, 17);
            this.rdb1.TabIndex = 0;
            this.rdb1.TabStop = true;
            this.rdb1.Text = "Pending for Approval";
            this.rdb1.UseVisualStyleBackColor = true;
            // 
            // btnGoBack
            // 
            this.btnGoBack.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnGoBack.FlatAppearance.BorderSize = 0;
            this.btnGoBack.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnGoBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnGoBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGoBack.Font = new System.Drawing.Font("Moon", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGoBack.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnGoBack.Image = global::MediClinicChannelingSystem.Properties.Resources.icons8_Back16_16;
            this.btnGoBack.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGoBack.Location = new System.Drawing.Point(4, 4);
            this.btnGoBack.Name = "btnGoBack";
            this.btnGoBack.Size = new System.Drawing.Size(66, 24);
            this.btnGoBack.TabIndex = 7;
            this.btnGoBack.Text = "Back";
            this.btnGoBack.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnGoBack.UseVisualStyleBackColor = true;
            this.btnGoBack.Click += new System.EventHandler(this.btnGoBack_Click);
            // 
            // AppointmentCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(570, 261);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AppointmentCreator";
            this.Opacity = 0.95D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AppointmentCreator";
            this.TopMost = true;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AppointmentCreator_KeyDown);
            this.panel1.ResumeLayout(false);
            this.pnlPatientFind.ResumeLayout(false);
            this.pnlPatientFind.PerformLayout();
            this.pnlPatientShow.ResumeLayout(false);
            this.pnlStatus.ResumeLayout(false);
            this.pnlStatus.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnGoBack;
        private System.Windows.Forms.GroupBox pnlStatus;
        private System.Windows.Forms.RadioButton rdb5;
        private System.Windows.Forms.RadioButton rdb4;
        private System.Windows.Forms.RadioButton rdb3;
        private System.Windows.Forms.RadioButton rdb2;
        private System.Windows.Forms.RadioButton rdb1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Panel pnlPatientFind;
        private System.Windows.Forms.Label lblPatientInfoShow;
        private System.Windows.Forms.TextBox txtPatientFind;
        private System.Windows.Forms.Panel pnlPatientShow;
        private System.Windows.Forms.Label lblNewPatientInfo;
    }
}