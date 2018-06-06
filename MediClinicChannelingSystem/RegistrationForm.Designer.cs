namespace MediClinicChannelingSystem
{
    partial class RegistrationForm
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
            this.pnlAddNewConsultant = new System.Windows.Forms.Panel();
            this.btnRegisterConsultant = new System.Windows.Forms.Button();
            this.dtPracticingFrom = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtConsultantEmail = new System.Windows.Forms.TextBox();
            this.txtConsultantLastName = new System.Windows.Forms.TextBox();
            this.txtConsultantFirstName = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRegisterHospital = new System.Windows.Forms.Button();
            this.txtHospitalLocatedCity = new System.Windows.Forms.TextBox();
            this.txtHospitalAddress = new System.Windows.Forms.TextBox();
            this.txtHospitalName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tabControlForms = new System.Windows.Forms.TabControl();
            this.tabBlankPage = new System.Windows.Forms.TabPage();
            this.tabAddConsultant = new System.Windows.Forms.TabPage();
            this.tabAddHospital = new System.Windows.Forms.TabPage();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnNewHospital = new System.Windows.Forms.Button();
            this.btnNewConsultant = new System.Windows.Forms.Button();
            this.pnlForm = new System.Windows.Forms.Panel();
            this.pnlLogin = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.pnlAddNewConsultant.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.tabControlForms.SuspendLayout();
            this.tabAddConsultant.SuspendLayout();
            this.tabAddHospital.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.pnlForm.SuspendLayout();
            this.pnlLogin.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlAddNewConsultant
            // 
            this.pnlAddNewConsultant.Controls.Add(this.btnRegisterConsultant);
            this.pnlAddNewConsultant.Controls.Add(this.dtPracticingFrom);
            this.pnlAddNewConsultant.Controls.Add(this.label9);
            this.pnlAddNewConsultant.Controls.Add(this.label4);
            this.pnlAddNewConsultant.Controls.Add(this.label3);
            this.pnlAddNewConsultant.Controls.Add(this.label2);
            this.pnlAddNewConsultant.Controls.Add(this.label1);
            this.pnlAddNewConsultant.Controls.Add(this.txtConsultantEmail);
            this.pnlAddNewConsultant.Controls.Add(this.txtConsultantLastName);
            this.pnlAddNewConsultant.Controls.Add(this.txtConsultantFirstName);
            this.pnlAddNewConsultant.Location = new System.Drawing.Point(7, 6);
            this.pnlAddNewConsultant.Name = "pnlAddNewConsultant";
            this.pnlAddNewConsultant.Size = new System.Drawing.Size(332, 250);
            this.pnlAddNewConsultant.TabIndex = 0;
            // 
            // btnRegisterConsultant
            // 
            this.btnRegisterConsultant.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegisterConsultant.Location = new System.Drawing.Point(173, 207);
            this.btnRegisterConsultant.Name = "btnRegisterConsultant";
            this.btnRegisterConsultant.Size = new System.Drawing.Size(128, 31);
            this.btnRegisterConsultant.TabIndex = 5;
            this.btnRegisterConsultant.Text = "Register Consultant";
            this.btnRegisterConsultant.UseVisualStyleBackColor = true;
            this.btnRegisterConsultant.Click += new System.EventHandler(this.btnRegisterConsultant_Click);
            // 
            // dtPracticingFrom
            // 
            this.dtPracticingFrom.CustomFormat = "dd-MM-yyyy";
            this.dtPracticingFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPracticingFrom.Location = new System.Drawing.Point(140, 123);
            this.dtPracticingFrom.Name = "dtPracticingFrom";
            this.dtPracticingFrom.Size = new System.Drawing.Size(103, 20);
            this.dtPracticingFrom.TabIndex = 3;
            this.dtPracticingFrom.ValueChanged += new System.EventHandler(this.dtPracticingFrom_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(18, 129);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Practicing from - ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "E-mail address";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Last Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "First Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Registering a new Consultant";
            // 
            // txtConsultantEmail
            // 
            this.txtConsultantEmail.Location = new System.Drawing.Point(140, 169);
            this.txtConsultantEmail.Name = "txtConsultantEmail";
            this.txtConsultantEmail.Size = new System.Drawing.Size(161, 20);
            this.txtConsultantEmail.TabIndex = 4;
            this.txtConsultantEmail.Validating += new System.ComponentModel.CancelEventHandler(this.txtConsultantEmail_Validating);
            this.txtConsultantEmail.Validated += new System.EventHandler(this.txtConsultantEmail_Validated);
            // 
            // txtConsultantLastName
            // 
            this.txtConsultantLastName.Location = new System.Drawing.Point(140, 84);
            this.txtConsultantLastName.Name = "txtConsultantLastName";
            this.txtConsultantLastName.Size = new System.Drawing.Size(161, 20);
            this.txtConsultantLastName.TabIndex = 2;
            this.txtConsultantLastName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtConsultantLastName_KeyPress);
            // 
            // txtConsultantFirstName
            // 
            this.txtConsultantFirstName.Location = new System.Drawing.Point(140, 42);
            this.txtConsultantFirstName.Name = "txtConsultantFirstName";
            this.txtConsultantFirstName.Size = new System.Drawing.Size(161, 20);
            this.txtConsultantFirstName.TabIndex = 1;
            this.txtConsultantFirstName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtConsultantFirstName_KeyPress);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnRegisterHospital);
            this.panel1.Controls.Add(this.txtHospitalLocatedCity);
            this.panel1.Controls.Add(this.txtHospitalAddress);
            this.panel1.Controls.Add(this.txtHospitalName);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(7, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(325, 225);
            this.panel1.TabIndex = 0;
            // 
            // btnRegisterHospital
            // 
            this.btnRegisterHospital.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegisterHospital.Location = new System.Drawing.Point(173, 183);
            this.btnRegisterHospital.Name = "btnRegisterHospital";
            this.btnRegisterHospital.Size = new System.Drawing.Size(128, 31);
            this.btnRegisterHospital.TabIndex = 4;
            this.btnRegisterHospital.Text = "Register Hospital";
            this.btnRegisterHospital.UseVisualStyleBackColor = true;
            this.btnRegisterHospital.Click += new System.EventHandler(this.btnRegisterHospital_Click);
            // 
            // txtHospitalLocatedCity
            // 
            this.txtHospitalLocatedCity.Location = new System.Drawing.Point(140, 127);
            this.txtHospitalLocatedCity.Name = "txtHospitalLocatedCity";
            this.txtHospitalLocatedCity.Size = new System.Drawing.Size(161, 20);
            this.txtHospitalLocatedCity.TabIndex = 3;
            this.txtHospitalLocatedCity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHospitalLocatedCity_KeyPress);
            // 
            // txtHospitalAddress
            // 
            this.txtHospitalAddress.Location = new System.Drawing.Point(140, 68);
            this.txtHospitalAddress.Multiline = true;
            this.txtHospitalAddress.Name = "txtHospitalAddress";
            this.txtHospitalAddress.Size = new System.Drawing.Size(161, 41);
            this.txtHospitalAddress.TabIndex = 2;
            // 
            // txtHospitalName
            // 
            this.txtHospitalName.Location = new System.Drawing.Point(140, 26);
            this.txtHospitalName.Name = "txtHospitalName";
            this.txtHospitalName.Size = new System.Drawing.Size(161, 20);
            this.txtHospitalName.TabIndex = 1;
            this.txtHospitalName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHospitalName_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 130);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Located City";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Address";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Hospital Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, -1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Registering a new Hospital";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // tabControlForms
            // 
            this.tabControlForms.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabControlForms.Controls.Add(this.tabBlankPage);
            this.tabControlForms.Controls.Add(this.tabAddConsultant);
            this.tabControlForms.Controls.Add(this.tabAddHospital);
            this.tabControlForms.ItemSize = new System.Drawing.Size(0, 1);
            this.tabControlForms.Location = new System.Drawing.Point(237, 69);
            this.tabControlForms.Name = "tabControlForms";
            this.tabControlForms.SelectedIndex = 0;
            this.tabControlForms.Size = new System.Drawing.Size(353, 270);
            this.tabControlForms.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControlForms.TabIndex = 1;
            // 
            // tabBlankPage
            // 
            this.tabBlankPage.Location = new System.Drawing.Point(4, 5);
            this.tabBlankPage.Name = "tabBlankPage";
            this.tabBlankPage.Padding = new System.Windows.Forms.Padding(3);
            this.tabBlankPage.Size = new System.Drawing.Size(345, 261);
            this.tabBlankPage.TabIndex = 2;
            this.tabBlankPage.UseVisualStyleBackColor = true;
            // 
            // tabAddConsultant
            // 
            this.tabAddConsultant.Controls.Add(this.pnlAddNewConsultant);
            this.tabAddConsultant.Location = new System.Drawing.Point(4, 5);
            this.tabAddConsultant.Name = "tabAddConsultant";
            this.tabAddConsultant.Padding = new System.Windows.Forms.Padding(3);
            this.tabAddConsultant.Size = new System.Drawing.Size(345, 261);
            this.tabAddConsultant.TabIndex = 0;
            this.tabAddConsultant.UseVisualStyleBackColor = true;
            // 
            // tabAddHospital
            // 
            this.tabAddHospital.Controls.Add(this.panel1);
            this.tabAddHospital.Location = new System.Drawing.Point(4, 5);
            this.tabAddHospital.Name = "tabAddHospital";
            this.tabAddHospital.Padding = new System.Windows.Forms.Padding(3);
            this.tabAddHospital.Size = new System.Drawing.Size(345, 261);
            this.tabAddHospital.TabIndex = 1;
            this.tabAddHospital.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 342);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(848, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.ActiveLinkColor = System.Drawing.Color.Red;
            this.toolStripStatusLabel.AutoSize = false;
            this.toolStripStatusLabel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStripStatusLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(833, 17);
            this.toolStripStatusLabel.Spring = true;
            this.toolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnNewHospital
            // 
            this.btnNewHospital.Location = new System.Drawing.Point(404, 12);
            this.btnNewHospital.Name = "btnNewHospital";
            this.btnNewHospital.Size = new System.Drawing.Size(157, 40);
            this.btnNewHospital.TabIndex = 2;
            this.btnNewHospital.Text = "Add a new Hospital";
            this.btnNewHospital.UseVisualStyleBackColor = true;
            this.btnNewHospital.Click += new System.EventHandler(this.btnNewHospital_Click);
            // 
            // btnNewConsultant
            // 
            this.btnNewConsultant.Location = new System.Drawing.Point(241, 12);
            this.btnNewConsultant.Name = "btnNewConsultant";
            this.btnNewConsultant.Size = new System.Drawing.Size(157, 40);
            this.btnNewConsultant.TabIndex = 2;
            this.btnNewConsultant.Text = "Add a new Consultant";
            this.btnNewConsultant.UseVisualStyleBackColor = true;
            this.btnNewConsultant.Click += new System.EventHandler(this.btnNewConsultant_Click);
            // 
            // pnlForm
            // 
            this.pnlForm.BackColor = System.Drawing.SystemColors.Control;
            this.pnlForm.Controls.Add(this.btnNewHospital);
            this.pnlForm.Controls.Add(this.btnNewConsultant);
            this.pnlForm.Controls.Add(this.tabControlForms);
            this.pnlForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlForm.Location = new System.Drawing.Point(0, 0);
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.Size = new System.Drawing.Size(848, 342);
            this.pnlForm.TabIndex = 4;
            this.pnlForm.Visible = false;
            // 
            // pnlLogin
            // 
            this.pnlLogin.Controls.Add(this.panel2);
            this.pnlLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLogin.Location = new System.Drawing.Point(0, 0);
            this.pnlLogin.Name = "pnlLogin";
            this.pnlLogin.Size = new System.Drawing.Size(848, 342);
            this.pnlLogin.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnExit);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.btnLogin);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.txtPassword);
            this.panel2.Controls.Add(this.txtUsername);
            this.panel2.Location = new System.Drawing.Point(174, 10);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(500, 325);
            this.panel2.TabIndex = 1;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnExit.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(382, 236);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(93, 64);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "F5\r\nExit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Lucida Sans", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(3, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(119, 22);
            this.label10.TabIndex = 5;
            this.label10.Text = "Login Here";
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnLogin.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.Location = new System.Drawing.Point(244, 236);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(93, 64);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "F1\r\nLogin";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(26, 152);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(78, 20);
            this.label11.TabIndex = 3;
            this.label11.Text = "Password";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(26, 70);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(83, 20);
            this.label12.TabIndex = 2;
            this.label12.Text = "Username";
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(271, 146);
            this.txtPassword.MaxLength = 50;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(204, 29);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // txtUsername
            // 
            this.txtUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.Location = new System.Drawing.Point(271, 64);
            this.txtUsername.MaxLength = 50;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtUsername.Size = new System.Drawing.Size(204, 29);
            this.txtUsername.TabIndex = 0;
            this.txtUsername.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // RegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 364);
            this.Controls.Add(this.pnlLogin);
            this.Controls.Add(this.pnlForm);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "RegistrationForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin Form";
            this.TopMost = true;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RegistrationForm_KeyDown);
            this.pnlAddNewConsultant.ResumeLayout(false);
            this.pnlAddNewConsultant.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.tabControlForms.ResumeLayout(false);
            this.tabAddConsultant.ResumeLayout(false);
            this.tabAddHospital.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.pnlForm.ResumeLayout(false);
            this.pnlLogin.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlAddNewConsultant;
        private System.Windows.Forms.TextBox txtConsultantLastName;
        private System.Windows.Forms.TextBox txtConsultantFirstName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtHospitalLocatedCity;
        private System.Windows.Forms.TextBox txtHospitalAddress;
        private System.Windows.Forms.TextBox txtHospitalName;
        private System.Windows.Forms.DateTimePicker dtPracticingFrom;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnRegisterConsultant;
        private System.Windows.Forms.TextBox txtConsultantEmail;
        private System.Windows.Forms.Button btnRegisterHospital;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnNewConsultant;
        private System.Windows.Forms.TabControl tabControlForms;
        private System.Windows.Forms.TabPage tabBlankPage;
        private System.Windows.Forms.TabPage tabAddConsultant;
        private System.Windows.Forms.TabPage tabAddHospital;
        private System.Windows.Forms.Button btnNewHospital;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.Panel pnlLogin;
        private System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
    }
}