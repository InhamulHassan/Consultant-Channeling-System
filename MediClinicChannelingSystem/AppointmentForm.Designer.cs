namespace MediClinicChannelingSystem
{
    partial class AppointmentForm
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
            this.tblpnlAppointmentCalendar = new System.Windows.Forms.TableLayoutPanel();
            this.lblSelectedMonth = new System.Windows.Forms.Label();
            this.btnMonthPrevious = new System.Windows.Forms.Button();
            this.btnMonthNext = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lytpnlScheduledTimes = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlScroll = new System.Windows.Forms.Panel();
            this.lblChosenConsultant = new System.Windows.Forms.Label();
            this.btnGoBack = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnlScroll.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblpnlAppointmentCalendar
            // 
            this.tblpnlAppointmentCalendar.ColumnCount = 7;
            this.tblpnlAppointmentCalendar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tblpnlAppointmentCalendar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tblpnlAppointmentCalendar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tblpnlAppointmentCalendar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tblpnlAppointmentCalendar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tblpnlAppointmentCalendar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tblpnlAppointmentCalendar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tblpnlAppointmentCalendar.Location = new System.Drawing.Point(28, 133);
            this.tblpnlAppointmentCalendar.Name = "tblpnlAppointmentCalendar";
            this.tblpnlAppointmentCalendar.RowCount = 6;
            this.tblpnlAppointmentCalendar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tblpnlAppointmentCalendar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tblpnlAppointmentCalendar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tblpnlAppointmentCalendar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tblpnlAppointmentCalendar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tblpnlAppointmentCalendar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tblpnlAppointmentCalendar.Size = new System.Drawing.Size(776, 550);
            this.tblpnlAppointmentCalendar.TabIndex = 1;
            // 
            // lblSelectedMonth
            // 
            this.lblSelectedMonth.BackColor = System.Drawing.Color.LightGray;
            this.lblSelectedMonth.Font = new System.Drawing.Font("Glacial Indifference", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedMonth.Location = new System.Drawing.Point(28, 87);
            this.lblSelectedMonth.Name = "lblSelectedMonth";
            this.lblSelectedMonth.Size = new System.Drawing.Size(776, 41);
            this.lblSelectedMonth.TabIndex = 2;
            this.lblSelectedMonth.Text = "January";
            this.lblSelectedMonth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnMonthPrevious
            // 
            this.btnMonthPrevious.BackColor = System.Drawing.Color.LightGray;
            this.btnMonthPrevious.FlatAppearance.BorderSize = 0;
            this.btnMonthPrevious.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.btnMonthPrevious.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnMonthPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMonthPrevious.Font = new System.Drawing.Font("Lucida Console", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMonthPrevious.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnMonthPrevious.Location = new System.Drawing.Point(28, 87);
            this.btnMonthPrevious.Name = "btnMonthPrevious";
            this.btnMonthPrevious.Size = new System.Drawing.Size(83, 41);
            this.btnMonthPrevious.TabIndex = 3;
            this.btnMonthPrevious.Text = "<";
            this.btnMonthPrevious.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMonthPrevious.UseVisualStyleBackColor = false;
            this.btnMonthPrevious.Click += new System.EventHandler(this.btnMonthPrevious_Click);
            // 
            // btnMonthNext
            // 
            this.btnMonthNext.BackColor = System.Drawing.Color.LightGray;
            this.btnMonthNext.FlatAppearance.BorderSize = 0;
            this.btnMonthNext.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.btnMonthNext.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnMonthNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMonthNext.Font = new System.Drawing.Font("Lucida Console", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMonthNext.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnMonthNext.Location = new System.Drawing.Point(721, 87);
            this.btnMonthNext.Name = "btnMonthNext";
            this.btnMonthNext.Size = new System.Drawing.Size(83, 41);
            this.btnMonthNext.TabIndex = 3;
            this.btnMonthNext.Text = ">";
            this.btnMonthNext.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMonthNext.UseVisualStyleBackColor = false;
            this.btnMonthNext.Click += new System.EventHandler(this.btnMonthNext_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.label6, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.label7, 6, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(28, 680);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(776, 27);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Moon", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sunday";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Moon", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(113, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 27);
            this.label2.TabIndex = 0;
            this.label2.Text = "Monday";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Moon", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(223, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 27);
            this.label3.TabIndex = 0;
            this.label3.Text = "Tuesday";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Moon", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(333, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 27);
            this.label4.TabIndex = 0;
            this.label4.Text = "Wednesday";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Moon", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(443, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 27);
            this.label5.TabIndex = 0;
            this.label5.Text = "Thursday";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Moon", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(553, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 27);
            this.label6.TabIndex = 0;
            this.label6.Text = "Friday";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Moon", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(663, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 27);
            this.label7.TabIndex = 0;
            this.label7.Text = "Saturday";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lytpnlScheduledTimes
            // 
            this.lytpnlScheduledTimes.AutoScroll = true;
            this.lytpnlScheduledTimes.Location = new System.Drawing.Point(17, 28);
            this.lytpnlScheduledTimes.Name = "lytpnlScheduledTimes";
            this.lytpnlScheduledTimes.Size = new System.Drawing.Size(511, 582);
            this.lytpnlScheduledTimes.TabIndex = 4;
            // 
            // pnlScroll
            // 
            this.pnlScroll.AutoScroll = true;
            this.pnlScroll.Controls.Add(this.lytpnlScheduledTimes);
            this.pnlScroll.Location = new System.Drawing.Point(810, 0);
            this.pnlScroll.Name = "pnlScroll";
            this.pnlScroll.Size = new System.Drawing.Size(543, 707);
            this.pnlScroll.TabIndex = 5;
            // 
            // lblChosenConsultant
            // 
            this.lblChosenConsultant.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChosenConsultant.Location = new System.Drawing.Point(271, 0);
            this.lblChosenConsultant.Name = "lblChosenConsultant";
            this.lblChosenConsultant.Size = new System.Drawing.Size(530, 84);
            this.lblChosenConsultant.TabIndex = 0;
            this.lblChosenConsultant.Text = "label1";
            this.lblChosenConsultant.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnGoBack
            // 
            this.btnGoBack.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnGoBack.FlatAppearance.BorderSize = 0;
            this.btnGoBack.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnGoBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnGoBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGoBack.Font = new System.Drawing.Font("Moon", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGoBack.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnGoBack.Image = global::MediClinicChannelingSystem.Properties.Resources.icons8_Back;
            this.btnGoBack.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGoBack.Location = new System.Drawing.Point(0, 0);
            this.btnGoBack.Name = "btnGoBack";
            this.btnGoBack.Size = new System.Drawing.Size(135, 49);
            this.btnGoBack.TabIndex = 6;
            this.btnGoBack.Text = "Back";
            this.btnGoBack.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGoBack.UseVisualStyleBackColor = true;
            this.btnGoBack.Click += new System.EventHandler(this.btnGoBack_Click);
            // 
            // AppointmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.btnGoBack);
            this.Controls.Add(this.lblChosenConsultant);
            this.Controls.Add(this.pnlScroll);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btnMonthNext);
            this.Controls.Add(this.btnMonthPrevious);
            this.Controls.Add(this.lblSelectedMonth);
            this.Controls.Add(this.tblpnlAppointmentCalendar);
            this.Name = "AppointmentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AppointmentForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.AppointmentForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.pnlScroll.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tblpnlAppointmentCalendar;
        private System.Windows.Forms.Label lblSelectedMonth;
        private System.Windows.Forms.Button btnMonthPrevious;
        private System.Windows.Forms.Button btnMonthNext;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.FlowLayoutPanel lytpnlScheduledTimes;
        private System.Windows.Forms.Panel pnlScroll;
        private System.Windows.Forms.Label lblChosenConsultant;
        private System.Windows.Forms.Button btnGoBack;
    }
}