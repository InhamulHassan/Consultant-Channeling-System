using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MediClinicChannelingSystem
{
    public partial class AppointmentCreator : Form
    {
        SqlConnection con;
        string[] AppointmentIdentifiers;
        string PatientFullName;
        string PatientFirstName;
        string PatientLastName;
        int PatientAge;
        DateTime DateOfAppointment;
        string ContactInfo;
        public AppointmentCreator()
        {
            InitializeComponent();
            DBConnection obj = new DBConnection();
            con = obj.getConnection();
        }

        private string GenerateRecordID()
        {
            string DBRecordID = string.Empty;
            string RecordID = string.Empty;

            try
            {
                //retrieving the data from the ConsultantTable and displaying them in the form
                if (con.State == ConnectionState.Closed) //this selection will open the database connecion if it is not already opened
                {
                    con.Open();
                }

                using (SqlCommand cmd = new SqlCommand("SELECT Record_ID FROM PatientRecordsTable", con))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    bool consultantFound = reader.HasRows;
                    if (consultantFound)
                    {
                        while (reader.Read())
                        {
                            DBRecordID = reader[0].ToString().Trim();
                        }
                        string RecordIDSubstring = DBRecordID.Substring(1);
                        int ID = Int32.Parse(RecordIDSubstring);
                        int NewID = ID + 1;
                        if (ID >= 0 && ID < 9)
                        {
                            RecordID = "P00000" + NewID;
                        }
                        else if (ID >= 9 && ID < 99)
                        {
                            RecordID = "P0000" + NewID;
                        }
                        else if (ID >= 99 && ID < 999)
                        {
                            RecordID = "P000" + NewID;
                        }
                        else if (ID >= 999 && ID < 9999)
                        {
                            RecordID = "P00" + NewID;
                        }
                        else if (ID >= 9999 && ID < 99999)
                        {
                            RecordID = "P0" + NewID;
                        }
                        else if (ID >= 99999 && ID < 999999)
                        {
                            RecordID = "P" + NewID;
                        }
                    }
                    else
                    {
                        RecordID = "P000001";
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(null, "An error occured when retreiving the Patient Records details\nError: " + ex, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            /*
             *This will create a new RecordID using last databse value
             * the substring is used to get the first four characters from the last characters (hence the 1 index)             
             */
            return RecordID;
        }

        private bool ValidationCheck()
        {
            bool Success = false;
            if((rdb1.Checked || rdb2.Checked || rdb3.Checked || rdb4.Checked || rdb5.Checked))
            {
                Success = true;
            }
            return Success;
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void FillPatientID()
        {
            btnConfirm.Text = "Update Appointment Status\nF5";
            pnlPatientFind.BringToFront();
            pnlPatientFind.Show();
            if (con.State != ConnectionState.Open) //this opens the connection if it already not opened
            {
                con.Open();
            }

            string SqlString = "SELECT AppointmentID, PatientName FROM AppointmentTable";
            try
            {
                using (SqlCommand cmd = new SqlCommand(SqlString, con))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    AutoCompleteStringCollection PatientNameCollection = new AutoCompleteStringCollection();
                    while(reader.Read())
                    {
                        PatientNameCollection.Add(reader[1].ToString() + " - " + reader[0].ToString());
                    }
                    reader.Close();
                    txtPatientFind.AutoCompleteCustomSource = PatientNameCollection;
                }
                con.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(null, "An error occured when filling the patient details to the text box search\nError: " + ex, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayPatientDetails(string AppointmentID)
        {
            if (con.State != ConnectionState.Open) //this opens the connection if it already not opened
            {
                con.Open();
            }

            string SqlString = @"SELECT AppointmentTable.PatientName, AppointmentTable.PatientAge, AppointmentTable.PatientContactInfo, AppointmentTable.AppointmentDate, ConsultantTable.FirstName + ' ' + ConsultantTable.LastName AS FullName,  ConsultantOfficeTable.OfficeName, ConsultantOfficeTable.LocatedCity, AppointmentTable.AppointmentStatusID
                                        FROM AppointmentTable
                                        INNER JOIN ConsultantOfficeTable ON  AppointmentTable.ConsultantOfficeID = ConsultantOfficeTable.ConsultantOfficeID
										INNER JOIN ConsultantTable ON AppointmentTable.ConsultantID = ConsultantTable.ConsultantID
                                        WHERE AppointmentTable.AppointmentID = @aid";
            try
            {
                using (SqlCommand cmd = new SqlCommand(SqlString, con))
                {
                    cmd.Parameters.AddWithValue("@aid", SqlDbType.VarChar).Value = AppointmentID;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string PatientName = reader[0].ToString();
                        string PatientAge = reader[1].ToString();
                        string PatientContactInfo = reader[2].ToString();
                        DateTime AppointmentDate = DateTime.ParseExact(reader[3].ToString().Trim(), "M/d/yyyy hh:mm:ss tt", CultureInfo.CurrentCulture);
                        string ConsultantName = reader[4].ToString();
                        string HospitalName = reader[5].ToString();
                        string HospitalLocatedCity = reader[6].ToString();
                        string AppointmentStatusID = reader[7].ToString();
                        lblPatientInfoShow.Text = string.Format("{0}         Age: {1}\n{2}\n{3}\nDr. {4}\n{5} - {6} ", PatientName, PatientAge, PatientContactInfo, AppointmentDate.ToString("ddd dd/MM/yyyy"), ConsultantName, HospitalName, HospitalLocatedCity);
                        switch(AppointmentStatusID)
                        {
                            case "1":
                                rdb1.Select();
                                break;
                            case "2":
                                rdb2.Select();
                                break;
                            case "3":
                                rdb3.Select();
                                break;
                            case "4":
                                rdb4.Select();
                                break;
                            case "5":
                                rdb5.Select();
                                break;
                            default:
                                break;
                        }
                    }
                    reader.Close();
                }
                con.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(null, "An error occured when filling the patient's information\nError: " + ex, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateAppointmentStatus()
        {
            try
            {
                string AppointmentID = txtPatientFind.Text.Substring((txtPatientFind.TextLength - 12), 12);
                int AppointmentStatusID = 0;
                if (rdb1.Checked)
                {
                    AppointmentStatusID = 1;
                }
                if (rdb2.Checked)
                {
                    AppointmentStatusID = 2;
                }
                if (rdb3.Checked)
                {
                    AppointmentStatusID = 3;
                }
                if (rdb4.Checked)
                {
                    AppointmentStatusID = 4;
                }
                if (rdb5.Checked)
                {
                    AppointmentStatusID = 5;
                }

                if (con.State != ConnectionState.Open) //this opens the connection if it already not opened
                {
                    con.Open();
                }

                string SqlString = "UPDATE AppointmentTable SET AppointmentStatusID = @asid WHERE AppointmentID = @aid";
                try
                {
                    using (SqlCommand cmd = new SqlCommand(SqlString, con))
                    {
                        cmd.Parameters.AddWithValue("@asid", SqlDbType.Int).Value = AppointmentStatusID;
                        cmd.Parameters.AddWithValue("@aid", SqlDbType.VarChar).Value = AppointmentID;
                        int row = cmd.ExecuteNonQuery();
                        if (row > 0)
                        {
                            lblPatientInfoShow.ForeColor = Color.Green;
                            lblPatientInfoShow.Text = "Appointment Status Succesfully Updated";
                        }
                    }
                    con.Close();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(null, "An error occured when adding appointment details to the database\nError: " + ex, "Label Genration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(ArgumentOutOfRangeException)
            {
                lblPatientInfoShow.Text = "Enter the correct search criteria, the search box only accepts the Patient's Name as its search criteria";
            }
        }

        public void AssignDetails(List<Tuple<string, string, int, string>> PatientDetails, string ButtonName, DateTime AppointmentDate)
        {
            pnlPatientShow.BringToFront();
            pnlPatientShow.Show();
            pnlPatientFind.Hide();
            DateOfAppointment = AppointmentDate;
            AppointmentIdentifiers = ButtonName.Split('/');
            PatientFirstName = PatientDetails[0].Item1;
            PatientLastName = PatientDetails[0].Item2;
            PatientFullName = PatientDetails[0].Item1 + " " + PatientDetails[0].Item2;
            PatientAge = PatientDetails[0].Item3;
            ContactInfo = PatientDetails[0].Item4;
            lblNewPatientInfo.Text = @"Appointment Date: " + AppointmentDate.ToString("ddd dd/MM/yyyy") +
                                        "\nFull Name: " + PatientFullName + "\nAge: " + PatientAge + "\nContact Info - " + ContactInfo;
        }

        private void AddAppointmentToDatabase()
        {
            int AppointmentStatusID = 0;
            if(rdb1.Checked)
            {
                AppointmentStatusID = 1;
            }
            if (rdb2.Checked)
            {
                AppointmentStatusID = 2;
            }
            if (rdb3.Checked)
            {
                AppointmentStatusID = 3;
            }
            if (rdb4.Checked)
            {
                AppointmentStatusID = 4;
            }
            if (rdb5.Checked)
            {
                AppointmentStatusID = 5;
            }


            if (con.State != ConnectionState.Open) //this opens the connection if it already not opened
            {
                con.Open();
            }

            string SqlString = @"INSERT INTO AppointmentTable
                                (AppointmentID, ConsultantID, AppointmentScheduleID, ConsultantOfficeID, PatientName, PatientAge, PatientContactInfo, AppointmentDate, AppointmentStatusID)
                                VALUES (@aid, @cid, @asid, @coid, @pname, @page, @pcontact, @adate, @astatus)";
            try
            {
                using (SqlCommand cmd = new SqlCommand(SqlString, con))
                {
                    cmd.Parameters.AddWithValue("@aid", SqlDbType.VarChar).Value = AppointmentIdentifiers[0];
                    cmd.Parameters.AddWithValue("@cid", SqlDbType.VarChar).Value = AppointmentIdentifiers[1];
                    cmd.Parameters.AddWithValue("@asid", SqlDbType.VarChar).Value = AppointmentIdentifiers[2];
                    cmd.Parameters.AddWithValue("@coid", SqlDbType.VarChar).Value = AppointmentIdentifiers[3];
                    cmd.Parameters.AddWithValue("@pname", SqlDbType.VarChar).Value = PatientFullName;
                    cmd.Parameters.AddWithValue("@page", SqlDbType.Int).Value = PatientAge;
                    cmd.Parameters.AddWithValue("@pcontact", SqlDbType.VarChar).Value = ContactInfo;
                    cmd.Parameters.AddWithValue("@adate", SqlDbType.Date).Value = DateOfAppointment;
                    cmd.Parameters.AddWithValue("@astatus", SqlDbType.Int).Value = AppointmentStatusID;
                    int row = cmd.ExecuteNonQuery();
                    if(row>0)
                    {
                        lblNewPatientInfo.ForeColor = Color.Green;
                        lblNewPatientInfo.Text = "Appointment Succesfully added to the database";
                    }
                }
                con.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(null, "An error occured when adding appointment details to the database\nError: " + ex, "Label Genration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddPatientToDatabase()
        {
            if (con.State != ConnectionState.Open) //this opens the connection if it already not opened
            {
                con.Open();
            }

            string SqlString = @"INSERT INTO PatientRecordsTable
                                (Record_ID, ConsultantID, AppointmentID, PatientFirstName, PatientLastName, PatientAge, ContactNumber)
                                VALUES (@rid, @cid, @aid, @pfname, @plname, @page, @pcontact)";
            try
            {
                using (SqlCommand cmd = new SqlCommand(SqlString, con))
                {
                    cmd.Parameters.AddWithValue("@rid", SqlDbType.VarChar).Value = GenerateRecordID();
                    cmd.Parameters.AddWithValue("@cid", SqlDbType.VarChar).Value = AppointmentIdentifiers[1];
                    cmd.Parameters.AddWithValue("@aid", SqlDbType.VarChar).Value = AppointmentIdentifiers[0];
                    cmd.Parameters.AddWithValue("@pfname", SqlDbType.VarChar).Value = PatientFirstName;
                    cmd.Parameters.AddWithValue("@plname", SqlDbType.VarChar).Value = PatientLastName;
                    cmd.Parameters.AddWithValue("@page", SqlDbType.Int).Value = PatientAge;
                    cmd.Parameters.AddWithValue("@pcontact", SqlDbType.VarChar).Value = ContactInfo;
                    int row = cmd.ExecuteNonQuery();
                    if (row > 0)
                    {
                        lblNewPatientInfo.ForeColor = Color.Green;
                        lblNewPatientInfo.Text += "\nPatient Succesfully added to the database";
                    }
                }
                con.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(null, "An error occured when adding appointment details to the database\nError: " + ex, "Label Genration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AppointmentCreator_KeyDown(object sender, KeyEventArgs e)
        {
            //this event gives the form the ability to listen to key down events
            switch (e.KeyCode)
            {
                case Keys.D1:
                    e.Handled = true;
                    rdb1.Select();
                    break;
                case Keys.D2:
                    e.Handled = true;
                    rdb2.Select();
                    break;
                case Keys.D3:
                    e.Handled = true;
                    rdb3.Select();
                    break;
                case Keys.D4:
                    e.Handled = true;
                    rdb4.Select();
                    break;
                case Keys.D5:
                    e.Handled = true;
                    rdb5.Select();
                    break;
                case Keys.NumPad1:
                    e.Handled = true;
                    rdb1.Select();
                    break;
                case Keys.NumPad2:
                    e.Handled = true;
                    rdb2.Select();
                    break;
                case Keys.NumPad3:
                    e.Handled = true;
                    rdb3.Select();
                    break;
                case Keys.NumPad4:
                    e.Handled = true;
                    rdb4.Select();
                    break;
                case Keys.NumPad5:
                    e.Handled = true;
                    rdb5.Select();
                    break;
                case Keys.F5:
                    e.Handled = true;
                    btnConfirm.PerformClick();
                    break;
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if(ValidationCheck())
            {
                if (pnlPatientFind.Visible)
                {
                    UpdateAppointmentStatus();
                }
                if (pnlPatientShow.Visible)
                {
                    AddAppointmentToDatabase();
                    AddPatientToDatabase();
                    btnConfirm.Hide();
                }
            }
            else
            {
                lblNewPatientInfo.Text += "\n\n\nSelect a suitable Appointment Status"; 
                lblPatientInfoShow.Text += "\n\n\nSelect a suitable Appointment Status";
            }
        }

        private void txtPatientFind_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.Enter)
                {
                    string AppointmentID = txtPatientFind.Text.Substring((txtPatientFind.TextLength - 12), 12);
                    DisplayPatientDetails(AppointmentID);
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                lblPatientInfoShow.Text = "Enter the correct search criteria, the search box only accepts the Patient's Name as its search criteria";
            }
        }
    }
}
