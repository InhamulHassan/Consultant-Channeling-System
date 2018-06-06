using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;

namespace MediClinicChannelingSystem
{
    public partial class RegistrationForm : Form
    {
        SqlConnection con;
        public RegistrationForm()
        {
            InitializeComponent();
            DBConnection obj = new DBConnection();
            con = obj.getConnection(); 
        }

        private bool ValidateConsultantForm()
        {
            bool Success = false;
            if(string.IsNullOrEmpty(txtConsultantFirstName.Text) || string.IsNullOrEmpty(txtConsultantLastName.Text) || string.IsNullOrEmpty(txtConsultantEmail.Text))
            {
                errorProvider1.SetError(btnRegisterConsultant, "Please fill out all the fields in the form");
                Success = false;
            }
            if(dtPracticingFrom.Value >= DateTime.Today)
            {
                errorProvider1.SetError(dtPracticingFrom, "This value should not be from a future date");
                Success = false;
            }
            else
            {
                Success = true;
            }
            return Success;
        }

        private bool ValidateHospitalForm()
        {
            bool Success = false;
            if (string.IsNullOrEmpty(txtHospitalName.Text) || string.IsNullOrEmpty(txtHospitalAddress.Text) || string.IsNullOrEmpty(txtHospitalLocatedCity.Text))
            {
                errorProvider1.SetError(btnRegisterHospital, "Please fill out all the fields in the form");
                Success = false;
            }
            else
            {
                Success = true;
            }
            return Success;
        }

        private string GenerateConsultantID()
        {
            string ConsultantID = string.Empty;
            string CID = string.Empty;
            try
            {
                if (con.State == ConnectionState.Closed) //this selection will open the database connecion if it is not already opened
                {
                    con.Open();
                }

                using (SqlCommand cmd = new SqlCommand("SELECT ConsultantID FROM ConsultantTable", con))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    bool rowFound = reader.HasRows;
                    if (rowFound)
                    {
                        while (reader.Read())
                        {
                            CID = reader[0].ToString();//it gets the last rows value
                        }
                        string ConsultantIDString = CID.Substring(2, 4);//only the integer values

                        int ID = Int32.Parse(ConsultantIDString);
                        int NewID = 0;
                        if (ID >= 0 && ID < 9)
                        {
                            NewID = ID + 1;
                            ConsultantID = "DR000" + NewID;
                        }
                        else if (ID >= 9 && ID < 99)
                        {
                            NewID = ID + 1;
                            ConsultantID = "DR00" + NewID;
                        }
                        else if (ID >= 99 && ID < 999)
                        {
                            NewID = ID + 1;
                            ConsultantID = "DR0" + NewID;
                        }
                        else if (ID >= 999 && ID < 9999)
                        {
                            NewID = ID + 1;
                            ConsultantID = "DR" + NewID;
                        }
                    }
                    else
                    {
                        ConsultantID = "DR0001";
                    }
                }
            }
            catch (SqlException e)
            {
                MessageBox.Show("ConsltantID Generation Error\nError:" + e);
            }
            return ConsultantID;
        }

        private void AddConsultantToDatabase(out string ConsultantID)
        {
            ConsultantID = GenerateConsultantID();
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO ConsultantTable(ConsultantID, FirstName, LastName, Practicing_From) VALUES (@cid, @fname, @lname, @from)", con);
                cmd.Parameters.AddWithValue("@cid", SqlDbType.VarChar).Value = ConsultantID;
                cmd.Parameters.AddWithValue("@fname", SqlDbType.VarChar).Value = txtConsultantFirstName.Text.ToString().Trim();
                cmd.Parameters.AddWithValue("@lname", SqlDbType.VarChar).Value = txtConsultantLastName.Text.ToString().Trim();
                cmd.Parameters.AddWithValue("@from", SqlDbType.Date).Value = dtPracticingFrom.Value;
                int row = cmd.ExecuteNonQuery();
                if (row > 0)
                {
                    toolStripStatusLabel.Text = "The Consultant has been successfully added to the database";
                    toolStripStatusLabel.ForeColor = Color.Green;
                }
                con.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(this, "An error occured when trying to insert consultant details into the system\nError" + ex, "Error adding values to database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GenerateConsultantLoginCredentials(string ConsultantID, out string ConsultantLoginID, out string ConsultantKeyCode)
        {
            string LoginID = string.Format("{0}{1}{2}", txtConsultantFirstName.Text.ToString().Trim().Substring(0, 1), txtConsultantLastName.Text.ToString().Trim().Substring(0, 1), ConsultantID.Substring(2, 4));
            ConsultantLoginID = LoginID;
            ConsultantKeyCode = GenerateRandomKeyCode();
        }

        private string GenerateRandomKeyCode()
        {
            string KeyCode = string.Empty;
            Random RandomNumber = new Random();
            do
            {
                int Number = RandomNumber.Next(0, 9);
                KeyCode = string.Concat(KeyCode, Number);
            } while (KeyCode.Length < 5);
            return KeyCode;
        }

        private void AddLoginCredentialsToDatabase(string ConsultantID, string LoginID, string KeyCode)
        {
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO ConsultantLoginTable(LoginID, PinCode, ConsultantID) VALUES (@lid, @pcode, @cid)", con);
                cmd.Parameters.AddWithValue("@lid", SqlDbType.VarChar).Value = LoginID;
                cmd.Parameters.AddWithValue("@pcode", SqlDbType.VarChar).Value = KeyCode;
                cmd.Parameters.AddWithValue("@cid", SqlDbType.VarChar).Value = ConsultantID;
                int row = cmd.ExecuteNonQuery();
                if (row > 0)
                {
                    SendEmailToConsultant(LoginID, KeyCode);
                }
                con.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(this, "An error occured when trying to insert consultant details into the system\nError" + ex, "Error adding values to database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GenerateHospitalID()
        {
            string HospitalID = string.Empty;
            string HID = string.Empty;
            try
            {
                if (con.State == ConnectionState.Closed) //this selection will open the database connecion if it is not already opened
                {
                    con.Open();
                }

                using (SqlCommand cmd = new SqlCommand("SELECT HospitalID FROM HospitalTable", con))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    bool rowFound = reader.HasRows;
                    if (rowFound)
                    {
                        while (reader.Read())
                        {
                            HID = reader[0].ToString();//it gets the last rows value
                        }
                        string HospitalIDString = HID.Substring(1, 5);//only the integer values

                        int ID = Int32.Parse(HospitalIDString);
                        int NewID = 0;
                        if (ID >= 0 && ID < 9)
                        {
                            NewID = ID + 1;
                            HospitalID = "H0000" + NewID;
                        }
                        else if (ID >= 9 && ID < 99)
                        {
                            NewID = ID + 1;
                            HospitalID = "H000" + NewID;
                        }
                        else if (ID >= 99 && ID < 999)
                        {
                            NewID = ID + 1;
                            HospitalID = "H00" + NewID;
                        }
                        else if (ID >= 999 && ID < 9999)
                        {
                            NewID = ID + 1;
                            HospitalID = "H0" + NewID;
                        }
                        else if (ID >= 9999 && ID < 99999)
                        {
                            NewID = ID + 1;
                            HospitalID = "H" + NewID;
                        }
                    }
                    else
                    {
                        HospitalID = "H00001";
                    }
                }
            }
            catch (SqlException e)
            {
                MessageBox.Show("HospitalID Generation Error\nError:" + e);
            }
            return HospitalID;
        }

        private void AddHospitalToDatabase()
        {
            string HospitalID = GenerateHospitalID();
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO HospitalTable(HospitalID, HospitalName, HospitalAddress, LocatedCity) VALUES (@hid, @hname, @haddress, @lcity)", con);
                cmd.Parameters.AddWithValue("@hid", SqlDbType.VarChar).Value = HospitalID;
                cmd.Parameters.AddWithValue("@hname", SqlDbType.VarChar).Value = txtHospitalName.Text.ToString().Trim();
                cmd.Parameters.AddWithValue("@haddress", SqlDbType.VarChar).Value = txtHospitalAddress.Text.ToString().Trim();
                cmd.Parameters.AddWithValue("@lcity", SqlDbType.Date).Value = txtHospitalLocatedCity.Text.ToString().Trim(); ;
                int row = cmd.ExecuteNonQuery();
                if (row > 0)
                {
                    toolStripStatusLabel.Text = "The Hospital has been successfully added to the database";
                    toolStripStatusLabel.ForeColor = Color.Green;
                }
                con.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(this, "An error occured when trying to insert hospital details into the system\nError" + ex, "Error adding values to database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SendEmailToConsultant(string LoginID, string KeyCode)
        {
            string ConsultantEmailAddress = txtConsultantEmail.Text.ToString().Trim();
            string ConsultantFullName = txtConsultantFirstName.Text.ToString().Trim() + " " + txtConsultantLastName.Text.ToString().Trim();

            string ResourcePath = System.AppDomain.CurrentDomain.BaseDirectory;
            string FilePath = string.Concat(ResourcePath, "\\NeerogaLogo.jpg");
            var inLineLogo = new LinkedResource(FilePath, System.Net.Mime.MediaTypeNames.Image.Jpeg);
            inLineLogo.ContentId = "companylogo";
            inLineLogo.ContentType = new System.Net.Mime.ContentType("image/jpeg");

            string htmlBody = string.Format(@"<!DOCTYPE HTML>
                                            <HTML><HEAD><META http-equiv=Content-Type content=""text/html; charset=utf-8"">
                                            </HEAD ><BODY><DIV style = 'height:100%; width:900px;'><div style = 'height:55px; width:900px; text-align:center; font-size:45px; margin:0px 0px 0px 0px; background-color:lightseagreen;'><font style = ""font-family:palatino"" color =#2071b2>Neeroga Channeling Service</font></div>
                                            <p align =""center""><b>Dear Dr. {0},</b></p>
                                            <p align =""center"">We at Neeroga Channeling Center would like to warmly welcome you <br>
                                            to join us in this new digital age.</p>
                                            <p align =""middle""><img src=cid:companylogo width=270 height=108></p>
                                            <p align =""center"">Neeroga Channeling Center provides each of it's partner consultants with their own personalized<br>
                                            Consultant Account. To set up your account, login through the Neeroga Consultant System using your <br>
                                            Login Credentials.</p>
                                            <p align =""center"">
                                            Login ID: {1}<br>
                                            Key Code: {2}<br>
                                            </p>
                                            <p align =""center"">If you have any questions, please feel free to call our <a href=""tel:+94758025492"" target=""_top"">Help Center</a> or mail us by <a href=""mailto:neerogachannelingcenter@gmail.com?cc=inhamulhassan.work@gmail.com&Subject=Neeroga%20Channeling%20Help%20Center"" target=""_top"">clicking here</a></p>
                                            <p align =""center"">Yours Sincerely,<br>
                                            <i>Neeroga Channeling Team</i></p></DIV></BODY></HTML>", ConsultantFullName, LoginID, KeyCode);


            NetworkCredential Credentials = new NetworkCredential("neerogachannelingcenter@gmail.com", "csharpiscool"); //Neeroga's medical's e-mail address
            SmtpClient SMTPCLIENT = new SmtpClient("smtp.gmail.com"); //Gmail's SMTP server's address
            SMTPCLIENT.Port = 587; //Gmail's transport layer socket port number (we can use port number-465 for SSL)
            SMTPCLIENT.EnableSsl = true; //we are securing the connection so that the email is secure, since we are sending the login credentials
            SMTPCLIENT.Credentials = Credentials; //we are assigning the credentials to login into the email account so that we could send it
            MailMessage Message = new MailMessage //we are creating a new instance of the message
            {
                From = new MailAddress("neerogachannelingcenter@gmail.com", "Neeroga Channeling Center", Encoding.UTF8)       //we ar including in the mail from where we are getting the email       
            };
            Message.To.Add(new MailAddress(ConsultantEmailAddress)); //we are assigning to whom the email is sent, in this case the registering consultant
            Message.To.Add(new MailAddress("inhamulhassan.work@gmail.com")); //we are CC'ing the email to the admin
            Message.Sender = new MailAddress("neerogachannelingcenter@gmail.com"); //we are including the sender's address in the mail
            Message.Subject = string.Format("Dr. {0}, welcome to your new Neeroga Consultant Account", ConsultantFullName);
            //we are writing the subject of the mail and the body of the mail below

            ContentType mimeType = new System.Net.Mime.ContentType("text/html");

            AlternateView alternate = AlternateView.CreateAlternateViewFromString(htmlBody, mimeType);
            alternate.LinkedResources.Add(inLineLogo);

            Message.AlternateViews.Add(alternate);

            Message.Body = htmlBody;
            Message.BodyEncoding = Encoding.UTF8;
            Message.IsBodyHtml = true;
            Message.Priority = MailPriority.High;
            Message.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            SMTPCLIENT.SendCompleted += new SendCompletedEventHandler(SendCompletedCallBack);
            SMTPCLIENT.Send(Message);
        }

        private void SendCompletedCallBack(object sender, AsyncCompletedEventArgs e)
        {
            if(e.Cancelled) //this will be displayed if the email is cancelled
            {
                toolStripStatusLabel.Text = "The E-mail has been successfully cancelled";
                toolStripStatusLabel.ForeColor = Color.Orange;
            }
            else if(e.Error != null) //this will be cancelled if the email has any error
            {
                toolStripStatusLabel.Text = "The E-mail could not be sent due to an error";
                toolStripStatusLabel.ForeColor = Color.Red;
            }
            //this means that the email has no problems and was sent successfully
            toolStripStatusLabel.Text = "The E-mail has been successfully sent to Dr. " + txtConsultantFirstName.Text.ToString().Trim() + " " + txtConsultantLastName.Text.ToString().Trim();
            toolStripStatusLabel.ForeColor = Color.Green;

        }

        private void txtConsultantFirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            //this handles the first name text box's individual key press event
            if (txtConsultantFirstName.TextLength < 1)//to capitalize the first letter in the textbox
            {
                e.KeyChar = Char.ToUpper(e.KeyChar);
            }
        }

        private void txtConsultantLastName_KeyPress(object sender, KeyPressEventArgs e)
        {
            //this handles the first name text box's individual key press event
            if (txtConsultantLastName.TextLength < 1)//to capitalize the first letter in the textbox
            {
                e.KeyChar = Char.ToUpper(e.KeyChar);
            }
        }

        private void txtHospitalName_KeyPress(object sender, KeyPressEventArgs e)
        {
            //this handles the first name text box's individual key press event
            if (txtHospitalName.TextLength == 0)//to capitalize the first letter in the textbox
            {
                e.KeyChar = Char.ToUpper(e.KeyChar);
            }
        }

        private void txtHospitalLocatedCity_KeyPress(object sender, KeyPressEventArgs e)
        {
            //this handles the first name text box's individual key press event
            if (txtHospitalLocatedCity.TextLength == 0)//to capitalize the first letter in the textbox
            {
                e.KeyChar = Char.ToUpper(e.KeyChar);
            }
        }

        private void dtPracticingFrom_ValueChanged(object sender, EventArgs e)
        {
            DateTime SelectedDate = DateTime.ParseExact(dtPracticingFrom.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            if (SelectedDate >= DateTime.Now)
            {
                errorProvider1.SetError(dtPracticingFrom, "The selected date is a future date, please choose a valid date");
            }
            else
            {
                errorProvider1.SetError(dtPracticingFrom, null);
            }
        }

        private void txtConsultantEmail_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtConsultantEmail, null);
        }

        private void txtConsultantEmail_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                string Email = new MailAddress(txtConsultantEmail.ToString()).Address;
                errorProvider1.SetError(txtConsultantEmail, null);
            }
            catch(FormatException)
            {
                e.Cancel = true; //cancelling the email validating event
                txtConsultantEmail.Select(0, txtConsultantEmail.TextLength); //selecting the tex so that it could be corrected by the user
                errorProvider1.SetError(txtConsultantEmail, "Enter a valid E-mail address\nExample: someone@example.com");
            }
        }

        private void btnNewConsultant_Click(object sender, EventArgs e)
        {
            tabControlForms.SelectTab(tabAddConsultant);
        }

        private void btnNewHospital_Click(object sender, EventArgs e)
        {
            tabControlForms.SelectTab(tabAddHospital);
        }

        private void btnRegisterConsultant_Click(object sender, EventArgs e)
        {
            string ConsultantID;
            string ConsultantLoginID;
            string ConsultantKeyCode;
            if(ValidateConsultantForm() && txtConsultantEmail.CausesValidation)
            {
                AddConsultantToDatabase(out ConsultantID);
                GenerateConsultantLoginCredentials(ConsultantID, out ConsultantLoginID, out ConsultantKeyCode);
                AddLoginCredentialsToDatabase(ConsultantID, ConsultantLoginID, ConsultantKeyCode);
            }
            else
            {
                toolStripStatusLabel.Text = "Fill the Consultant form with the necessary details to submit it.";
            }
        }

        private void btnRegisterHospital_Click(object sender, EventArgs e)
        {
            if(ValidateHospitalForm())
            {
                AddHospitalToDatabase();
            }
            else
            {
                toolStripStatusLabel.Text = "Fill the Hospital form with the necessary details to submit it.";
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(txtUsername.Text.Equals("admin") && txtPassword.Text.Equals("pass"))
            {
                pnlForm.BringToFront();
                pnlForm.Show();
                pnlLogin.Hide();
                toolStripStatusLabel.Text = null;
            }
            else if(string.IsNullOrEmpty(txtUsername.Text))
            {
                toolStripStatusLabel.Text = "Username field is empty, please provide a username to log in";
            }
            else if(string.IsNullOrEmpty(txtPassword.Text))
            {
                toolStripStatusLabel.Text = "Password field is empty, please provide a password to log in";
            }
            else
            {
                toolStripStatusLabel.Text = "Incorrect User Credentials, please type again.";
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RegistrationForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(pnlLogin.Visible)
            {
                switch(e.KeyCode)
                {
                    case Keys.F1:
                        btnLogin.PerformClick();
                        e.Handled = true;
                        break;
                    case Keys.F5:
                        btnExit.PerformClick();
                        e.Handled = true;
                        break;
                }
            }
        }

    }
}
