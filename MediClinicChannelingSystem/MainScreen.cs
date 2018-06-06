using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace MediClinicChannelingSystem
{
    public partial class MainScreen : Form
    {
        SqlConnection con;
        public MainScreen()
        {
            InitializeComponent();
        }

        private void HospitalComboFill()
        {
            //this method will fill the cmbHospitalName with all the hospitals in the database
            //the value that is displayed is the hospital name, while the combo box value member is the hospital ID
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT HospitalID, HospitalName FROM HospitalTable ORDER BY HospitalName ASC",con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "HospitalTable");

                cmbHospitalName.DataSource = ds;
                cmbHospitalName.DisplayMember = "HospitalTable.HospitalName";
                cmbHospitalName.ValueMember = "HospitalTable.HospitalID";
            }
            catch(SqlException ex)
            {
                MessageBox.Show(null, "An error occured when filling the Hospital search box\nError: " + ex, "Hospital Data Fill Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            cmbHospitalName.SelectedItem = null;
            cmbHospitalName.SelectedText = "--SELECT HOSPITAL--";
        }

        private void ConsultantNameComboFill()
        {
            //this method will fill the cmbConsultantName with all the consultants in the database
            //the value that is displayed is the consultant name, while the combo box value member is the consultant ID
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT ConsultantID, (FirstName + ' ' + LastName) AS FullName FROM ConsultantTable ORDER BY FirstName ASC", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "ConsultantTable");

                cmbConsultantName.DataSource = ds;
                cmbConsultantName.DisplayMember = "ConsultantTable.FullName";
                cmbConsultantName.ValueMember = "ConsultantTable.ConsultantID";
            }
            catch(SqlException ex)
            {
                MessageBox.Show(null, "An error occured when filling the Consultant Name search box\nError: " + ex, "Consultant Data Fill Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            cmbConsultantName.SelectedItem = null;
            cmbConsultantName.SelectedText = "--SELECT CONSULTANT--";
        }

        private void SpecialitiesComboFill()
        {
            //this method will fill the cmbSpecialityName with all the consultant specilities in the database
            //the value that is displayed is the speciality name, while the combo box value member is the speciality ID
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT SpecialityID, SpecialityName FROM SpecialitiesListTable ORDER BY SpecialityName ASC", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "SpecialitiesListTable");

                cmbSpeciality.DataSource = ds;
                cmbSpeciality.DisplayMember = "SpecialitiesListTable.SpecialityName";
                cmbSpeciality.ValueMember = "SpecialitiesListTable.SpecialityID";
            }
            catch(SqlException ex)
            {
                MessageBox.Show(null, "An error occured when filling the Speciality search box\nError: " + ex, "Speciality Data Fill Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            cmbSpeciality.SelectedItem = null;
            cmbSpeciality.SelectedText = "--SELECT SPECIALITY--";
        }

        private void ConsultantPopulateLayoutPanel(List<string> ConsultantOfficeList, List<string> SpecialityList)
        {
            //this method is to used to populate the layout panel when the cmbConsultant name is used
            foreach(string SpecialityID in SpecialityList)
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }

                try
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT SpecialityName FROM SpecialitiesListTable WHERE SpecialityID = @sid", con))
                    {
                        cmd.Parameters.AddWithValue("@sid", SqlDbType.VarChar).Value = SpecialityID;
                        SqlDataReader reader = cmd.ExecuteReader();
                        if(reader.HasRows)
                        {
                            while(reader.Read())
                            {
                                string SpecialityName = reader[0].ToString().Trim();
                                Label Speciality = ConsultantSpecialitiesTag(SpecialityName, SpecialityID); //a label with the medical field that the consultant is specialised in
                                flwpnlConsultantInfo.Controls.Add(Speciality); //this adds that label to the layout panel for each speciality in the database
                            }
                        }
                        reader.Close();
                    }
                    con.Close();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(null, "An error occured when populating the layout panel with Consultant Specialities\nError: " + ex, "Conultant Speciality Label Fill Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            foreach(string ConsultantOfficeID in ConsultantOfficeList)
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }

                try
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT OfficeName, LocatedCity FROM ConsultantOfficeTable WHERE ConsultantOfficeID = @coid", con))
                    {
                        cmd.Parameters.AddWithValue("@coid", SqlDbType.VarChar).Value = ConsultantOfficeID;
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                string OfficeName = reader[0].ToString().Trim();
                                string LocatedCity = reader[1].ToString().Trim();
                                RadioButton OfficeDetails = ChooseConsultant(OfficeName, LocatedCity, ConsultantOfficeID); //this will create a button with the consultant's speciality and affliated hospital details
                                flwpnlConsultantInfo.Controls.Add(OfficeDetails); //this will add that button to the layout panel
                            }
                        }
                        reader.Close();
                    }
                    con.Close();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(null, "An error occured when populating the layout panel with Hospital Details\nError: " + ex, "Conultant Office Button Fill Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SpecialityPopulateLayoutPanel(List<string> SpecializedConsultantList)
        {
            //this method is to used to populate the layout panel when the cmbSpecialities is used
            string FirstName = string.Empty;
            string LastName = string.Empty;
            string FullName = string.Empty;
            string OfficeName = string.Empty;
            string LocatedCity = string.Empty;
            string ConsultantOfficeID = string.Empty;
            foreach (string ConsultantID in SpecializedConsultantList)
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }

                try
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT FirstName, LastName FROM ConsultantTable WHERE ConsultantID = @cid", con))
                    {
                        cmd.Parameters.AddWithValue("@cid", SqlDbType.VarChar).Value = ConsultantID;
                        SqlDataReader reader = cmd.ExecuteReader();
                        if(reader.HasRows)
                        {
                            while(reader.Read())
                            {
                                FirstName = reader[0].ToString().Trim();
                                LastName = reader[1].ToString().Trim();
                                FullName = FirstName + " " + LastName;
                            }
                        }
                        reader.Close();
                    }
                    using(SqlCommand cmd = new SqlCommand("SELECT ConsultantOfficeID, OfficeName, LocatedCity FROM ConsultantOfficeTable WHERE ConsultantID = @cid", con))
                    {
                        cmd.Parameters.AddWithValue("@cid", SqlDbType.VarChar).Value = ConsultantID;
                        SqlDataReader reader = cmd.ExecuteReader();
                        if(reader.HasRows)
                        {
                            while(reader.Read())
                            {
                                ConsultantOfficeID = reader[0].ToString().Trim();
                                OfficeName = reader[1].ToString().Trim();
                                LocatedCity = reader[2].ToString().Trim();
                            }
                        }
                        reader.Close();
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(null, "An error occured when populating the layout panel with Specialized Consultant Details\nError: " + ex, "Conultant Speciality Button Fill Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                RadioButton ChooseConsultant = ChooseSpeciality(FullName, OfficeName, LocatedCity, ConsultantOfficeID); //this will create a button with the speciality and consultant details
                flwpnlConsultantInfo.Controls.Add(ChooseConsultant); //this will  add that button to the layout panel
            }
        }

        private void HospitalsPopulateLayoutPanel(List<string> AffliatedConsultants)
        {
            //this method is to used to populate the layout panel when the cmbHospital name is used
            string FirstName = string.Empty;
            string LastName = string.Empty;
            string FullName = string.Empty;
            string HospitalName = string.Empty;
            string LocatedCity = string.Empty;
            string ConsultantOfficeID = string.Empty;

            foreach (string ConsultantID in AffliatedConsultants)
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }

                try
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT FirstName, LastName FROM ConsultantTable WHERE ConsultantID = @cid", con))
                    {
                        cmd.Parameters.AddWithValue("@cid", SqlDbType.VarChar).Value = ConsultantID;
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                FirstName = reader[0].ToString().Trim();
                                LastName = reader[1].ToString().Trim();
                                FullName = FirstName + " " + LastName;
                            }
                        }
                        reader.Close();
                    }
                    using (SqlCommand cmd = new SqlCommand("SELECT ConsultantOfficeID, OfficeName, LocatedCity FROM ConsultantOfficeTable WHERE ConsultantID = @cid", con))
                    {
                        cmd.Parameters.AddWithValue("@cid", SqlDbType.VarChar).Value = ConsultantID;
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                ConsultantOfficeID = reader[0].ToString().Trim();
                                HospitalName = reader[1].ToString().Trim();
                                LocatedCity = reader[2].ToString().Trim();
                            }
                        }
                        reader.Close();
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(null, "An error occured when populating the layout panel with the Affliated Doctors List\nError: " + ex, "Affliated Conultants Fill Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                RadioButton ChooseConsultant = ChooseSpeciality(FullName, HospitalName, LocatedCity, ConsultantOfficeID); //this will create a button with the speciality and consultant details
                flwpnlConsultantInfo.Controls.Add(ChooseConsultant); //this will add that button to the layout panel
            }
        }

        private bool FormValidation()
        {
            //this method is used as a form validation checker before moving on to the next form
            bool Success = false;

            if(String.IsNullOrEmpty(txtFirstName.Text) || String.IsNullOrEmpty(txtLastName.Text))//checks if the first name is empty
            {
                errorProvider1.SetError(txtLastName, "Enter the Patient's First Name, followed by their Last Name in the corresponding fields");
                Success = false;
            }
            else
            {
                errorProvider1.SetError(txtLastName, string.Empty);
                Success = true;
            }
            if(String.IsNullOrEmpty(txtPatientAge.Text)) //checks if patient age is empty
            {
                errorProvider1.SetError(txtPatientAge, "Enter the Patient's Age in the corresponding field");
                Success = false;
            }
            else
            {
                errorProvider1.SetError(txtPatientAge, string.Empty);
                Success = true;
            }
            if(txtContactNumber.Text.Length < 10) //checks if patient's contact info is correct is empty
            {
                errorProvider1.SetError(txtContactNumber, "Enter the proper Contact Number in the corresponding field");
                Success = false;
            }
            else
            {
                errorProvider1.SetError(txtContactNumber, string.Empty);
                Success = true;
            }

            bool ComboSelected = false;
            if (flwpnlConsultantInfo.Controls.Count == 0)//checks if the layout is populated by choosing any of the items in the drop down lists
            {
                ComboSelected = false;
                errorProvider1.SetError(cmbConsultantName, "Choose a valid Consultant from the drop down lists");
            }
            else
            {
                ComboSelected = true;
            }

            bool CheckErrorProvider = false;

            if(errorProvider1.GetError(txtLastName) == string.Empty && errorProvider1.GetError(txtPatientAge) == string.Empty && errorProvider1.GetError(txtContactNumber) == string.Empty)
            {
                CheckErrorProvider = true;
            }
            else
            {
                CheckErrorProvider = false;
            }

            bool ConsultantSelected = false;
            //this checks each control to ensure that it is checked before approving the validation check 
            foreach (Control c in flwpnlConsultantInfo.Controls)
            {
                if (c is RadioButton)
                {
                    RadioButton rb = c as RadioButton;
                    if (rb.Checked == true)
                    {
                        ConsultantSelected = true;
                        errorProvider1.SetError(rb, string.Empty);//clear the rb's error provider
                        break; //breaks from the foreach loop if the button is checked
                    }
                    else //this will run if the success bool is false (ie. no control is selecetd)
                    {
                        ConsultantSelected = false;
                        errorProvider1.SetError(rb, "Please choose the Consultant you wish to book");
                    }
                }
            }

            if(Success == true && ConsultantSelected == true && CheckErrorProvider == true && ComboSelected == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void MainScreen_Load(object sender, EventArgs e)
        {
            //initializes the Database connection
            DBConnection obj = new DBConnection();
            con = obj.getConnection();
            //calls the methods to fill the combo boxes
            txtContactNumber.AutoSize = false;
            txtContactNumber.Size = new Size(126, 29);
            HospitalComboFill();
            ConsultantNameComboFill();
            SpecialitiesComboFill();
            flwpnlConsultantInfo.Controls.Clear();//clears the flow layout panel
        }

        RadioButton ChooseConsultant(string HospitalName, string LocatedCity, string ConsultantOfficeID)
        {
            RadioButton btn = new RadioButton(); //this dynamically creates a new button control
            btn.Appearance = Appearance.Button;//sets the adio buttons appearance as a button 
            btn.AutoCheck = true; //enabling autocheck will ensure that the button is be able to be checked
            btn.CheckedChanged += new EventHandler(rdbutton_Check); //this creates a new event handler method for that button
            btn.Name = ConsultantOfficeID; //this sets the button control's name as the ConsultantOfficeID, so that it can be used to reference the seleceted office (or hospital)
            btn.FlatStyle = FlatStyle.Flat; //this sets the button's style as Flat             
            btn.Text = HospitalName + " - " + LocatedCity; //this defines the button's displayed text
            btn.Height = 110; //this sets the button height
            btn.Width = 610; //this sets the button width
            btn.ForeColor = Color.DarkSlateGray;//this sets the button's fore color
            Color backColor = Color.GhostWhite; //this defines the button back color 
            btn.BackColor = backColor;//this sets the button's back color
            btn.FlatAppearance.BorderColor = Color.Teal; //this sets the button's border color
            btn.FlatAppearance.BorderSize = 3;  //this sets the button's border size
            btn.FlatAppearance.CheckedBackColor = Color.Teal;
            btn.FlatAppearance.MouseDownBackColor = Color.Turquoise; //this sets the button's color when the mouse clicks it
            btn.FlatAppearance.MouseOverBackColor = Color.DarkTurquoise; //this sets the button's color when the mouse hovers over it
            btn.Font = new Font("Glacial Indifference", 14, FontStyle.Bold); //this sets the font of the button's displayed text
            btn.TextAlign = ContentAlignment.MiddleLeft; //this sets the text alignment of the button's displayed text
            btn.Padding = new Padding(5); //this sets the buttons paddings
            return btn;//this return the button's custome preferences to the calling method
        }

        Label ConsultantSpecialitiesTag(string SpecializedIn, string SpecialityID)
        {
            Label lbl = new Label(); //creates a new instance of the label
            lbl.Name = SpecialityID; //sets the label's control name
            lbl.FlatStyle = FlatStyle.Flat; //sets the label's style as a aflat style
            lbl.Text = SpecializedIn; //sets what the label will contain
            lbl.ForeColor = Color.White;//sets tthe fore color of the label
            lbl.BackColor = Color.DimGray; //sets the back color of the label
            lbl.Font = new Font("Century Gothic", 10, FontStyle.Regular); //sets the font style and sized
            lbl.TextAlign = ContentAlignment.MiddleLeft; //sets the label's text alignment
            return lbl;//returns the label's specifications 
        }

        RadioButton ChooseSpeciality(string ConsultantName, string OfficeName, string LocatedCity, string ConsultantOfficeID)
        {
            RadioButton btn = new RadioButton(); //this dynamically creates a new button control
            btn.Appearance = Appearance.Button;//sets the adio buttons appearance as a button 
            btn.AutoCheck = true; //enabling autocheck will ensure that the button is be able to be checked
            btn.CheckedChanged += new EventHandler(rdbutton_Check); //this creates a new event handler method for that button
            btn.Name = ConsultantOfficeID; //this sets the button control's name as the ConsultantOfficeID, so that it can be used to reference the seleceted office (or hospital)
            btn.FlatStyle = FlatStyle.Flat; //this sets the button's style as Flat             
            btn.Text = ConsultantName + "\n" + OfficeName + " - " + LocatedCity; //this defines the button's displayed text
            btn.Height = 110; //this sets the button height
            btn.Width = 610; //this sets the button width
            btn.ForeColor = Color.DarkSlateGray;//this sets the button's fore color
            Color backColor = Color.GhostWhite; //this defines the button back color 
            btn.BackColor = backColor;//this sets the button's back color
            btn.FlatAppearance.BorderColor = Color.Teal; //this sets the button's border color
            btn.FlatAppearance.BorderSize = 3;  //this sets the button's border size
            btn.FlatAppearance.CheckedBackColor = Color.Teal;//this color will be the button's color if it is the currently checked button
            btn.FlatAppearance.MouseDownBackColor = Color.Turquoise; //this sets the button's color when the mouse clicks it
            btn.FlatAppearance.MouseOverBackColor = Color.DarkTurquoise; //this sets the button's color when the mouse hovers over it
            btn.Font = new Font("Glacial Indifference", 14, FontStyle.Bold); //this sets the font of the button's displayed text
            btn.TextAlign = ContentAlignment.MiddleLeft; //this sets the text alignment of the button's displayed text
            btn.Padding = new Padding(5); //this sets the buttons paddings
            return btn;//this return the button's custome preferences to the calling method
        }

        protected void rdbutton_Check(object sender, EventArgs e)
        {
            //this event will handle the radio button's checked event
            //wat we try to achieve here is change the button's fore color according to it's checked property
            RadioButton SelectedButton = sender as RadioButton;
            if(SelectedButton.Checked)
            {
                SelectedButton.ForeColor = Color.White;
            }
            if(SelectedButton.Checked == false)
            {
                SelectedButton.ForeColor = Color.DarkSlateGray;
            }
        }

        private void cmbConsultantName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //this methods populate the layout panel with the specified controls when the consultant name combo box is used
            flwpnlConsultantInfo.Controls.Clear();
            string ConsultantID = cmbConsultantName.SelectedValue.ToString().Trim();
            List<string> ConsultantOfficeList = new List<string>(); //this list will contain all the details of the consultant's office
            List<string> ConsultantSpecializedIn = new List<string>(); //this list will contain all the field sthe consultant is specialized in
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }

                using (SqlCommand cmd = new SqlCommand("SELECT ConsultantOfficeID FROM ConsultantOfficeTable WHERE ConsultantID = @cid", con))
                {
                    cmd.Parameters.AddWithValue("@cid", SqlDbType.VarChar).Value = ConsultantID;
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ConsultantOfficeList.Add(reader[0].ToString().Trim()); //this fill the list with the consultant office's details
                        }
                    }
                    reader.Close();
                }

                using (SqlCommand cmd2 = new SqlCommand("SELECT SpecialityID FROM DoctorSpecialities WHERE ConsultantID = @cid", con))
                {
                    cmd2.Parameters.AddWithValue("@cid", SqlDbType.VarChar).Value = ConsultantID;
                    SqlDataReader reader2 = cmd2.ExecuteReader();
                    if (reader2.HasRows)
                    {
                        while (reader2.Read())
                        {
                            ConsultantSpecializedIn.Add(reader2[0].ToString().Trim()); //this fills the list with the consultant's specialized fields
                        }
                    }
                    reader2.Close();
                }
                con.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(null, "An error occured when finding the consultant\nError: " + ex, "Consultant Search Unsuccesful", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ConsultantPopulateLayoutPanel(ConsultantOfficeList, ConsultantSpecializedIn); //this fills the layout panel with the specified control buttons
        }

        private void cmbConsultantName_SelectedIndexChanged(object sender, EventArgs e)
        {
            //this method handles the index change event of the consultant name combo box
            //the if selection is used to ensure that the Selection change commited event only accepts the proper data member of the combo box (not the default set value) 
            if (cmbConsultantName.SelectedIndex >= 0)
            {
                cmbConsultantName_SelectionChangeCommitted(sender, e);
            }
        }

        private void txtPatientAge_KeyPress(object sender, KeyPressEventArgs e)
        {
            //this handles the patient age texbox's individual key press event
            if(!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))//to allow only digits and control characters in the textbox
            {
                e.Handled = true;
            }
            txtPatientAge.MaxLength = 3;
        }

        private void txtFirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            //this handles the first name text box's individual key press event
            if(txtFirstName.TextLength == 0)//to capitalize the first letter in the textbox
            {
                e.KeyChar = Char.ToUpper(e.KeyChar);
            }
        }

        private void txtLastName_KeyPress(object sender, KeyPressEventArgs e)
        {
            //this handles the last name text box's individual key press event
            if (txtLastName.TextLength == 0)//to capitalize the first letter in the textbox
            {
                e.KeyChar = Char.ToUpper(e.KeyChar);
            }
        }

        private void cmbConsultantName_KeyPress(object sender, KeyPressEventArgs e)
        {
            //this handles the consultant name combobox individual key press event
            if (cmbConsultantName.Text.Length < 1 || cmbConsultantName.SelectedText == "--SELECT CONSULTANT--")//to capitalize the first letter in the combobox
            {
                e.KeyChar = Char.ToUpper(e.KeyChar);
            }
        }

        private void cmbSpeciality_KeyPress(object sender, KeyPressEventArgs e)
        {
            //this handles the consultant name combobox individual key press event
            if (cmbSpeciality.Text.Length < 1 || cmbSpeciality.SelectedText == "--SELECT SPECIALITY--")//to capitalize the first letter in the combobox
            {
                e.KeyChar = Char.ToUpper(e.KeyChar);
            }
        }

        private void cmbHospitalName_KeyPress(object sender, KeyPressEventArgs e)
        {
            //this handles the consultant name combobox individual key press event
            if (cmbHospitalName.Text.Length < 1 || cmbHospitalName.SelectedText == "--SELECT HOSPITAL--")//to capitalize the first letter in the combobox
            {
                e.KeyChar = Char.ToUpper(e.KeyChar);
            }
        }

        private void cmbSpeciality_SelectedIndexChanged(object sender, EventArgs e)
        {
            //this method handles the index change event of the speciality name combo box
            //the if selection is used to ensure that the Selection change commited event only accepts the proper data member of the combo box (not the default set value) 
            if (cmbSpeciality.SelectedIndex >= 0)
            {
                cmbSpeciality_SelectionChangeCommitted(sender, e);
            }
        }

        private void cmbSpeciality_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //this methods populate the layout panel with the specified controls when the speciality name combo box is used
            flwpnlConsultantInfo.Controls.Clear();
            string SpecialityID = cmbSpeciality.SelectedValue.ToString().Trim();
            List<string> SpecializedDoctorsList = new List<string>(); //this list is used to store all the doctors that are specialized in a certain field

            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }

                using (SqlCommand cmd = new SqlCommand("SELECT ConsultantID FROM DoctorSpecialities WHERE SpecialityID = @sid", con))
                {
                    cmd.Parameters.AddWithValue("@sid", SqlDbType.VarChar).Value = SpecialityID;
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            SpecializedDoctorsList.Add(reader[0].ToString().Trim()); //this populates the list with the details of the consultants that are specialized in a certain field
                        }
                    }
                    reader.Close();
                }
                con.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(null, "An error occured when finding the Specialized Doctors\nError: " + ex, "Consultant Search Unsuccesful", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            SpecialityPopulateLayoutPanel(SpecializedDoctorsList); //this method populates the layout with the specialized consultant details using the above list 
        }

        private void cmbHospitalName_SelectedIndexChanged(object sender, EventArgs e)
        {
            //this method handles the index change event of the hospital name combo box
            //the if selection is used to ensure that the Selection change commited event only accepts the proper data member of the combo box (not the default set value) 
            if (cmbHospitalName.SelectedIndex >= 0)
            {
                cmbHospitalName_SelectionChangeCommitted(sender, e);
            }
        }

        private void cmbHospitalName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //this event handles the changes made to the combo box by the user
            flwpnlConsultantInfo.Controls.Clear();//this clears the layout panel so that it could be filled with the new buttons
            string HospitalID = cmbHospitalName.SelectedValue.ToString().Trim();
            List<string> DoctorsAffliatedWithList = new List<string>(); //this list contains all the consultants affliated with a certain hospital

            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }

                using (SqlCommand cmd = new SqlCommand("SELECT ConsultantID FROM HospitalAffliationsTable WHERE HospitalID = @hid", con))
                {
                    cmd.Parameters.AddWithValue("@hid", SqlDbType.VarChar).Value = HospitalID;
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            DoctorsAffliatedWithList.Add(reader[0].ToString().Trim());//this adds the details of the consultants taffliated with the hospital
                        }
                    }
                    reader.Close();
                }
                con.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(null, "An error occured when finding the Doctors Affliated with the Hospital\nError: " + ex, "Consultant Search Unsuccesful", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            SpecialityPopulateLayoutPanel(DoctorsAffliatedWithList); //this method populate the layout panel with the button using the details from the list from above
        }

        private void btnBookNow_Click(object sender, EventArgs e)
        {
            //this event handles the button click event of the btnBookNow
            string PhoneNumber = Regex.Replace(txtContactNumber.Text, @"\(|\)|\s|-", ""); //this is used to remove the masked text's literals, so that it only has numbers
            List<Tuple<string, string, int, string>> PatientDetails = new List<Tuple<string, string, int, string>>(); 
            /*
             * this list is used to store the details of the patient, that is being entered in this form
             * these details are then sent to the next form to so that they can be combined with some other 
             * details regarding the appointment, so that they can be inserted into the database
             */
            string ConsultantOfficeID = string.Empty;
            if(FormValidation()) //this is to ensure that the form has all the relevant data to continue to the next form
            {
                foreach (Control c in flwpnlConsultantInfo.Controls) //this forach loop goes through each of the dynamic controls in the layout panel
                {
                    if (c is RadioButton)
                    {
                        RadioButton rb = c as RadioButton;
                        if (rb.Checked == true)// and retrieves the data from the radio button that is checked
                        {
                            ConsultantOfficeID = rb.Name;
                        }
                    }
                }
                PatientDetails.Add(new Tuple<string, string, int, string>(txtFirstName.Text.ToString().Trim(), txtLastName.Text.ToString().Trim(), Int32.Parse(txtPatientAge.Text), PhoneNumber));
                AppointmentForm obj = new AppointmentForm();
                obj.ReceivePreviousFormDetails(PatientDetails, ConsultantOfficeID);
                obj.Show();
                this.Hide();
                /*
                 * the patient details entered in this form is added to a list<Tuple> and sent to the next form
                 * so that it can be used by the next form to be inserted into the database
                 * The consultantofficeID is sent along with the patient details list so that the next form can
                 * use the consultantofficeID for database related activities
                 */
                txtFirstName.Text = null;
                txtLastName.Text = null;
                txtPatientAge.Text = null;
                //the text boxes are cleared so that they will be clear the next time you come here
            }
        }

        private void lnkAdminLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegistrationForm obj = new RegistrationForm();
            obj.ShowDialog();
        }

        private void btnStatus_Click(object sender, EventArgs e)
        {
            AppointmentCreator obj = new AppointmentCreator();
            obj.FillPatientID();
            obj.ShowDialog();
        }
    }
}
