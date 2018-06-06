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
using System.Globalization;

namespace MediClinicChannelingSystem
{
    public partial class AppointmentForm : Form
    {
        string GlobalConsultantOfficeID; //the global variable is used to keep track of the current Consultant's Office that was selected from the previous form
        string GlobalConsultantID; //this global variable is used to keep track of the consultant of the current form, so that it can be used in database related activites 
        List<Tuple<string, string, int, string>> PatientDetails = new List<Tuple<string, string, int, string>>();
        DateTime SelectedDate;
        //these integers are used as counters to add the duplicate day values found in the database, so as to ensure that the calendar doesnt create duplicate day buttons
        SqlConnection con;
        public AppointmentForm()
        {
            InitializeComponent();
            DBConnection obj = new DBConnection(); //this creates an object of the connection class
            con = obj.getConnection(); //this gets the sqlconnection connection parameter from the DBConnection class and intantuates the con variable with the connection parameters 
        }

        public void ReceivePreviousFormDetails(List<Tuple<string, string, int, string>> PatientInformation, string ConsultantOfficeID)
        {
            GlobalConsultantOfficeID = ConsultantOfficeID; //this gets the ConsultantID from the previous form and initializes it to the Global ConsultantOfficeID variable
            PatientDetails = PatientInformation; //this gets the PatientInformation Tuple List from the previous form and initializes it to the Global PatientDetails Tuple List

            if (con.State != ConnectionState.Open) //this opens the connection if it already not opened
            {
                con.Open();
            }

            //we use a connection string and then include it in the sqlcommand along with the connection parameters
            //this sql command uses INNER JOIN command to join two table's data using the foreign key that links these two tables 
            string ConnectionString = @"SELECT ConsultantTable.ConsultantID, ConsultantTable.FirstName + ' ' + ConsultantTable.LastName AS FullName,  ConsultantOfficeTable.OfficeName, ConsultantOfficeTable.LocatedCity, ConsultantOfficeTable.FirstConsultationFee, ConsultantOfficeTable.FollowupConsulationFee
                                        FROM ConsultantTable
                                        INNER JOIN ConsultantOfficeTable ON ConsultantTable.ConsultantID = ConsultantOfficeTable.ConsultantID
                                        WHERE ConsultantOfficeTable.ConsultantOfficeID = @coid";

            try
            {
                using (SqlCommand cmd = new SqlCommand(ConnectionString, con))
                {
                    cmd.Parameters.AddWithValue("@coid", SqlDbType.VarChar).Value = ConsultantOfficeID;
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            GlobalConsultantID = reader[0].ToString().Trim(); //we set up the global consultantID so that it can be used by other methods for database related activites
                            //we then set up the label at the top with the currently selected consultant and their office details so that the user can ensure they are where they want to be
                            lblChosenConsultant.Text = "Dr. " + reader[1].ToString().Trim() + "\n" + reader[2].ToString().Trim() + " (" + reader[3].ToString().Trim() + ")\nInital Fee - LKR " + reader[4].ToString().Trim() + "       " + "Followup Fee - LKR " + reader[5].ToString().Trim();
                        }
                    }
                    reader.Close();
                }
                con.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(null, "An error occured when setting up the Information Label\nError: " + ex, "Label Genration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ChosenMonth(DateTime GivenDate)
        {
            tblpnlAppointmentCalendar.Controls.Clear(); //this clears the controls in the table layou panel
            string Month = GivenDate.ToString("MMMM - yyyy"); //this converts the date to a string of the month name
            lblSelectedMonth.Text = Month; //this sets the label to that month's name
            int DaysInMonth = Int32.Parse(DateTime.DaysInMonth(GivenDate.Year, GivenDate.Month).ToString()); //this sets the number of days in that specific month
            List<Tuple<string, string, string>> ScheduledDaysList = AppointmentScheduleAvailability(); //this is a List with multiple elements (called a Tuple)
            //this list is filled with the list inside the AppointmentScheduleAvailability() method, which has a list of all the appointment details (The scheduled days, schedule availability, AppoinmentScheduleID)
            for (int day = 1; day <= DaysInMonth; day++) // this for loop is used to loop through each day of the selected month (it uses the integer DaysInMonth as the loop condition)
            {
                bool CalendarAlreadyFilled = false; //this bool is used so that we can have a pointer to know if the calendar is already filled with a date button
                DateTime SelectedDates = new DateTime(GivenDate.Year, GivenDate.Month,day); //this makes a DateTime value using the Year and Month of the currently selected month
                //the day value of the DateTime SelecetedDates uses each element of the for loop integer value (so that the we can create buttons for each day in the selecetd month)
                string SelectedDay = SelectedDates.DayOfWeek.ToString(); //this string is used to get the Day Of Week of the SelectedDates Date (i.e. Monday/Tueday/Friday, etc) 

                foreach (Tuple<string, string, string> Element in ScheduledDaysList) //this foreach is to go through each element in the ScheduleDaysList
                {
                    //Item1 in the Tuple is the AppoinmentScheduleID
                    //Item2 in the Tuple is the Schedule Day(ie.Sunday, tuesday, etc) that the consultant has defined
                    //Item3 in the tuple is each individual schedule (or sessions) availability status
                    //this would create a button with the available symbol for the days that are in the consultant's schedule
                    if (Element.Item2 == SelectedDay && Element.Item3 == "Y")
                    {
                        CalendarAlreadyFilled = true; //this bool is set as true because the calendar is already filled with the instance of the schedule day
                        MakeCalendar(SelectedDates, SelectedDay, true, Element.Item1); //this method is used to create each individual buttons for the date in the schedule (the button Control's Name is set as the Appointment ScheduleID)
                    }
                }
                if(CalendarAlreadyFilled == false) //if this bool is false then that means that the current date's day in the for loop does not match with the schedule day
                {
                    // so we create a button for this day that is disabled so that the user does not click it
                    //The button's name is set to the selected day
                    MakeCalendar(SelectedDates, SelectedDay, false, SelectedDates.ToString("dd/mm/yyyy"));
                }
            }
           PopulateEmptyRows(); //this method is used to fill the empty cells in the calendar - because it looks blank without them
        }

        private void TokenCounter(List<Tuple<string, DateTime, DateTime>> TokenList, string AppointmentScheduleID)
        {
            /* this methods gets a List<Tuple> containing the auto-generated AppointmentIDs, their corresponding appointment start time and end time
             * then it uses a foreach loop to go through each element of the list, it checks the AppointmentID against the database (using the ApointmnetScheduleID)
             * to get the next available token number (it does this by analysing the last two characters of the AppointmentID which contain the token number, it the
             * increments it to get the next token number).
             * if no rows are found in the database for that AppointmentScheduleID then the method gets the first instance of the appointment(i.e. the first appointment
             * for that day, hence giving it the first token)
             * */
            string AppointmentID = string.Empty; //we create a variable to store the AppointmentId so that it can be used
            DateTime AppointmentStartTime; //we create a datetime variable to store the current appointment's start date
            DateTime AppointmentEstimatedEndTime; //we create a datetime variable to store the current appointment's estimated end date
            int TokenNumber = 0; //this integer variable is used to store the currently used token number
            bool TokenBooked= false; //this bool acts as a checker of each list element (AppointmentID) against the database value (of the AppointmentID in the AppointmentTabel)

            /*
             * The loop goes through the list of all the apoinments in a REVERSE order for a specic session,
             * the list is run in reverse so that the Token Number in the list's AppointmentID is gone through in a descending order
             * so that the AppointmentID matches with the last occuring token number (that is the AppointmentID) in the database
             * The reason for using a for loop is to run the list in reverse
             * We also check the token with the appointmentscheduleID, so that the system checks the day of the appointment
             */
            for (int Token = TokenList.Count - 1; Token >= 0; Token--)  
            {
                AppointmentID = TokenList[Token].Item1; //sets the appointmentID from the list's item1 
                AppointmentStartTime = TokenList[Token].Item2; //sets the appointment start time from the list's item2
                AppointmentEstimatedEndTime = TokenList[Token].Item3; //sets the appointment estimated end from the list's item3
                TokenBooked = false;

                if (con.State != ConnectionState.Open) //checks the connection state and opens it idf it is closed
                {
                    con.Open();
                }

                try
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM AppointmentTable WHERE AppointmentScheduleID = @asid AND AppointmentID = @aid", con))
                    {
                        cmd.Parameters.AddWithValue("@asid", SqlDbType.VarChar).Value = AppointmentScheduleID;
                        cmd.Parameters.AddWithValue("@aid", SqlDbType.VarChar).Value = AppointmentID;
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            TokenBooked = true; //this is set to true because the currently selected Tuple in the List has the AppoinmentID that corresponds with the latest AppointmentID (in the AppointmentTable) in the database
                            string TokenString = AppointmentID.Substring(10, 2); //we take the last two numbers of that AppointmentID (which is the token number of the appointment) 
                            TokenNumber = Int32.Parse(TokenString); //we parse the substring of the token number to get the integer value (so that it can be incremented and the next token number can be displayed)
                            lytpnlScheduledTimes.Controls.Add(TimeSelector((TokenList[Token+1].Item1 + "/" + GlobalConsultantID + "/" + AppointmentScheduleID + "/" + GlobalConsultantOfficeID), AppointmentStartTime.ToString("hh:mm tt") + "-" + AppointmentEstimatedEndTime.ToString("hh:mm tt") + "\nToken Number: " + (TokenNumber + 1)));
                            /* We are incrementing the AppointmentID's TokenListindex by one is to get the next appointmentID in the list because the current one is already present in the database
                             * we create and add a new radiobutton control into the scheduled times layout panel if the AppointmentID of the current element in the list matches the database value
                             * the new radiobutton will have the control name as a mixture of (appointmentID, consultantID, AppointmentScheduleID, ConsultantOfficeID) so that we can have an id for if the user clicks the button
                             * the text that is displayed in the button is the descriptive text of the appointment start time and the expected end time for an appointment
                             * along with the incremented token number displaying the next available token number
                             */
                            break; //the loop is broken when the list succesfully matches with the database to prevent having multiple buttons
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(null, "An error occured when checking up the token count\nError: " + ex, "Token Count Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            /*
             * this if selection will run if no appointment is found in the database for that specific consultant office
             * in which case it will create a radio button having the first instance of the appointment (i.e. the first token for that 
             * appointment)
             */

            if (!TokenBooked) 
            {
                TokenNumber = 0;
                lytpnlScheduledTimes.Controls.Add(TimeSelector((TokenList[0].Item1 + "/" + GlobalConsultantID + "/" + AppointmentScheduleID + "/" + GlobalConsultantOfficeID), TokenList[0].Item2.ToString("hh:mm tt") + "-" + TokenList[0].Item3.ToString("hh:mm tt") + "\nToken Number: " + (TokenNumber + 1)));
            }
        }

        private string GenerateAppointmentID(int TokenNumber)
        {
            string AppointmentID = string.Empty;
            string Token = null;
            if (TokenNumber >= 0 && TokenNumber < 10)
            {
                Token = "0" + TokenNumber;
            }
            else if (TokenNumber >= 10 && TokenNumber < 100)
            {
                Token = "" + TokenNumber;
            } 

            AppointmentID = string.Format("A{0}0{1}0{2}0{3}", SelectedDate.ToString("dd"), SelectedDate.ToString("MM"), SelectedDate.ToString("yy"), Token); 
            /*
             *This will create a new appointmentScheduleID using the ConsultantID, OfficeID and the token number
             * the substring is used to get the first four characters from the last characters (hence the 1 index)             
             */
            return AppointmentID;
        }

        public List<Tuple<string, string, string>> AppointmentScheduleAvailability()
        {
            //Thislist uses a Tuple to be able to store multiple values inside each element as Item1, Item2, Item3, etc.
            List<Tuple<string, string, string>> ScheduledDaysList = new List<Tuple<string, string, string>>();
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }

            try
            {
                using (SqlCommand cmd = new SqlCommand("SELECT AppointmentScheduleID, [DayOfWeek], ScheduleAvailability FROM AppointmentScheduleTable WHERE ConsultantOfficeID = @coid AND SessionNumber < 1", con))
                {
                    cmd.Parameters.AddWithValue("@coid", SqlDbType.VarChar).Value = GlobalConsultantOfficeID;
                    SqlDataReader reader = cmd.ExecuteReader();
                    if(reader.HasRows)
                    {
                        while(reader.Read())
                        {
                            //this check if there is a duplicate value for the dayOfWeek (this happens when the doctor has more than one session on each DayOfWeek), if that happens
                            //we have to ensure that a calendar date is not created for a duplicate value
                            //this adds each row of the database tabel to the List Tuple (Item1= AppointmentScheduleID, Item2 = DayOfWeek, Item3 = ScheduleAvailability)
                            ScheduledDaysList.Add(new Tuple<string, string, string>(reader[0].ToString().Trim(), reader[1].ToString().Trim(), reader[2].ToString().Trim()));
                        }
                    }
                    reader.Close();
                }
                con.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(null, "An error occured when setting up the Appointment Schedule with the Calendar\nError: " + ex, "Appointment Schedule Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //the list is returned to be used by the method
            return ScheduledDaysList;
        }

        public static int GetWeekOfMonth(DateTime date)
        {
            //this method is used to get the week number of each individual month using the date
            DateTime beginningOfMonth = new DateTime(date.Year, date.Month, 1); //this sets up a reference point for the beginning of that month

            //the while loop is used to go through each day of the month till it reaches the first day of the week(Sunday) where the loop breaks
            while (date.Date.AddDays(1).DayOfWeek != CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek) //while([the day of the given DateTime value date] != Sunday)
                date = date.AddDays(1); //for each iteration of the loop the date is increased by one day till the date value's Day of week equals the FirstDayOfWeek
            //once the loop breaks the last iteration of the loop will have the FirstDayOfWeek value's date (i.e the date of the the sundays of that month)

            return (int)Math.Truncate((double)date.Subtract(beginningOfMonth).TotalDays / 7f) + 1;
            //we return an integer value of the timespan (ie. the total number of days) between the begining of that month and the selected date of that month
            //this timespan value is divided by the float value of 7 (because each week has seven days)
            //this float value is truncated to get the whole number (whic is then incremented by one to get the week number where that date occurs
        }

        private void MakeCalendar(DateTime SelectedDate, string SelectedDayOfWeek, bool ScheduleAvailability, string ButtonName)
        {
            int ColumnPosition = 0; //the column position is used to set the dynamic button's column position in the calender
            int RowPosition = GetWeekOfMonth(SelectedDate); //the row position is determined using a method that uses the SelectedDate's Date to calculate which week that date occurs in a month
            //The column position is decided by checking the SelectedDate's DayOfWeek value and setting the column position using that (ie. Sunday one the first column so position is zero)
            switch(SelectedDayOfWeek)
            {
                case "Sunday":
                    ColumnPosition = 0;
                    break;
                case "Monday":
                    ColumnPosition = 1;
                    break;
                case "Tuesday":
                    ColumnPosition = 2;
                    break;
                case "Wednesday":
                    ColumnPosition = 3;
                    break;
                case "Thursday":
                    ColumnPosition = 4;
                    break;
                case "Friday":
                    ColumnPosition = 5;
                    break;
                case "Saturday":
                    ColumnPosition = 6;
                    break;
            }

            RadioButton DaySelector = DateSelector(SelectedDate, ScheduleAvailability, ButtonName);
            /*
             this is used to dynamically create the button (the parameters it takes are the DateTime of each date that is sent to the button, the ScheduleAvailability bool that
             determines whether the button will be enabled/active or not, and the ButtonName which is the AppointmentScheduleID or the DateTime of the date, it depends on the availability status
             
             */
            tblpnlAppointmentCalendar.Controls.Add(DaySelector, ColumnPosition, RowPosition-1); //this is used to add the newly created control to the calendar (we should specify the control's name, the column position, and the row position)
        }

        private void AppointmentForm_Load(object sender, EventArgs e)
        {
            DateTime DateToday = DateTime.Today; //this gets the today's date
            ChosenMonth(DateToday);//this sets the calndar to the current month once the form loads
        }

        RadioButton CalendarFiller()
        {
            RadioButton rdb = new RadioButton(); //creating a new instance of that button
            rdb.Text = null; //sets the text of the control to the current date number by converting it from the date
            rdb.Enabled = false;
            rdb.AutoCheck = false;
            rdb.Name = "cnt"; //setting the name of the control as the date
            rdb.Appearance = Appearance.Button; //this makes the radio button look like a button
            rdb.BackColor = SystemColors.ControlLight; //this sets the button's back color
            rdb.FlatStyle = FlatStyle.Flat; //this makes the button have the flat style appearence
            rdb.FlatAppearance.BorderColor = SystemColors.InactiveBorder; //this sets the border color of the flat button
            rdb.FlatAppearance.BorderSize = 1;  //this sets the border size of the flat button
            rdb.Width = 104; //this sets the button's width
            rdb.Height = 104; //this sets the button's height
            return rdb; //this returns the button pre-defined settings
        }

        RadioButton DateSelector(DateTime Date, bool AvailabilityOfSchedule, string ButtonName)
        {
            RadioButton rdb = new RadioButton(); //creating a new instance of that button
            rdb.Click += new EventHandler(rdbButton_clicked); //creates an event handler to handle the button_checked event
            rdb.Text = Date.ToString("dd"); //sets the text of the control to the current date number by converting it from the date
            rdb.Name = ButtonName; //setting the name of the control as the date
            rdb.AccessibleName = Date.ToString();
            if(AvailabilityOfSchedule)
            {
                rdb.Image = MediClinicChannelingSystem.Properties.Resources.Available; //this sets an image on the button
                rdb.ImageAlign = ContentAlignment.TopLeft; //this aligns the set image to the Top Left of the button
            }
            rdb.Appearance = Appearance.Button; //this makes the radio button look like a button
            rdb.BackColor = SystemColors.Control; //this sets the button's back color
            rdb.FlatStyle = FlatStyle.Flat; //this makes the button have the flat style appearence
            rdb.FlatAppearance.BorderColor = SystemColors.ActiveBorder; //this sets the border color of the flat button
            rdb.FlatAppearance.BorderSize = 2;  //this sets the border size of the flat button
            rdb.FlatAppearance.CheckedBackColor = SystemColors.ActiveCaption; //this sets the back color of the flat button when it is checked
            rdb.FlatAppearance.MouseDownBackColor = SystemColors.ActiveBorder; //this sets the back color of the flat button when a mouse is pressed down on it
            rdb.FlatAppearance.MouseOverBackColor = SystemColors.ButtonHighlight; //this sets the back color of the flat button when a mouse is hovered over it
            rdb.Font = new Font("Arial Narrow", 48, FontStyle.Bold); //this sets the font of the button
            rdb.AutoCheck = true; //this enables the button to be able to be checked
            rdb.Enabled = AvailabilityOfSchedule; //this makes the button available or unavailable according to a boolean
            rdb.Width = 104; //this sets the button's width
            rdb.Height = 104; //this sets the button's height
            return rdb; //this returns the button pre-defined settings
        }

        protected void rdbButton_clicked(object sender, EventArgs s)
        {
            //this is the event handler for the dynamically created RadioButton DateSelector
            RadioButton rdbButton = sender as RadioButton;
            string AppointmentScheduleID = rdbButton.Name;
            SelectedDate = DateTime.Parse(rdbButton.AccessibleName);
            lytpnlScheduledTimes.Controls.Clear();
            AppointmentScheduleTime(GlobalConsultantOfficeID, AppointmentScheduleID);
        }

        private void AppointmentScheduleTime(string ConsultantOfficeID, string AppointmentScheduleID)
        {
            /*
             * this method gets the appointmentscheduleID and gets the appointment start time, end time and the time slot
             * so that they could be used to calculate the individual appointment time sessions and then the time schedule 
             * radio buttons are created and dded to the time schedule layout panel
             */
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            string SQLQuery = @"  SELECT AppointmentScheduleTable.StartTime, AppointmentScheduleTable.EndTime, ConsultantOfficeTable.TimeSlotPerClient
                                    FROM AppointmentScheduleTable
                                    INNER JOIN ConsultantOfficeTable ON ConsultantOfficeTable.ConsultantOfficeID = AppointmentScheduleTable.ConsultantOfficeID
                                    WHERE AppointmentScheduleTable.AppointmentScheduleID = @asid";
            try
            {
                using (SqlCommand cmd = new SqlCommand(SQLQuery, con))
                {
                    cmd.Parameters.AddWithValue("@asid", SqlDbType.VarChar).Value = AppointmentScheduleID;
                    SqlDataReader reader = cmd.ExecuteReader();
                    if(reader.HasRows)
                    {
                        while(reader.Read())
                        {
                            //this method is called to create the time schedule button
                            //the button's ID is set
                            CreateTimeScheduleButton(ConsultantOfficeID, AppointmentScheduleID, DateTime.ParseExact(reader[0].ToString().Trim(), "HH:mm:ss", CultureInfo.CurrentCulture), DateTime.ParseExact(reader[1].ToString().Trim(), "HH:mm:ss", CultureInfo.CurrentCulture), Int32.Parse(reader[2].ToString().Trim()));
                        }
                    }
                    reader.Close();
                    con.Close(); 
                }
            }
            catch(SqlException ex)
            {
                MessageBox.Show(null, "An error occured when setting up the Appointment Schedule Time\nError: " + ex, "Appointment Time Schedule Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreateTimeScheduleButton(string ConsultantOfficeID, string AppointmentScheduleID, DateTime StartTime, DateTime EndTime, int TimeSlot)
        {
            List<Tuple<string, DateTime, DateTime>> TokenList = new List<Tuple<string, DateTime, DateTime>>(); //creating a list to store all individual token number and details
            double SessionSpan = EndTime.Subtract(StartTime).TotalMinutes; //getting the span of the whole session by subtracting the start time from the end time and getting the number of minutes 
            //we need to calculate how many tokens that each individual schedule can have, this is done using the start time, end time and the time slot 
            int TokenNumbers = (int)SessionSpan / TimeSlot; //we calculate the token number by dividing the session span(the full session's time in minutes) by the TimeSlot(the length of each individual session), we get the integer for good measure 
            DateTime AppointmentStartTime = StartTime;//assigning the appointment start time as a reference point
            for (int i = 1; i <= TokenNumbers; i++) //looping through each token number to get each individual sessions time
            {
                DateTime AppointmentEstimatedEndTime = StartTime.AddMinutes((double)TimeSlot * i); //getting each session's estimated end time by adding minutes to the start time we referenced outside the loop
                //the estimated end time is caculated by multiplying the loop increment value (which is each Token Number) with the time slot(the length of each session), so that the Estimated end time increase with each token number
                TokenList.Add(new Tuple<string, DateTime, DateTime>(GenerateAppointmentID(i), AppointmentStartTime, AppointmentEstimatedEndTime));
                //we are adding all the calculated values into the token list, this list has a record for each token number, along with its start time and estimated end time
                AppointmentStartTime = StartTime.AddMinutes((double)TimeSlot * i);//we are doing the same thing we did above, but after adding to the list so that during the next iteration the start time is the previous end time (i.e the end of one token is the beginning of the next number)
            }
            TokenCounter(TokenList, AppointmentScheduleID);
        }

        RadioButton TimeSelector(string ButtonName, string DisplayedText)
        {
            RadioButton rdb = new RadioButton();
            rdb.Click += new EventHandler(rdbTimeSchedule_Clicked);
            rdb.Text = DisplayedText; //sets the text of the control to the current date number by converting it from the date
            rdb.Name = ButtonName; //setting the name of the control as the date
            rdb.Appearance = Appearance.Button; //this makes the radio button look like a button
            rdb.BackColor = SystemColors.Control; //this sets the button's back color
            rdb.FlatStyle = FlatStyle.Flat; //this makes the button have the flat style appearence
            rdb.FlatAppearance.BorderColor = Color.Black; //this sets the border color of the flat button
            rdb.FlatAppearance.BorderSize = 3;  //this sets the border size of the flat button
            rdb.FlatAppearance.CheckedBackColor = Color.LightGray; //this sets the back color of the flat button when it is checked
            rdb.FlatAppearance.MouseDownBackColor = Color.Gray; //this sets the back color of the flat button when a mouse is pressed down on it
            rdb.FlatAppearance.MouseOverBackColor = Color.Gainsboro; //this sets the back color of the flat button when a mouse is hovered over it
            rdb.Font = new Font("Microsoft MHei", 16, FontStyle.Regular); //this sets the font of the button
            rdb.AutoCheck = true; //this enables the button to be able to be checked
            rdb.Width = 400; //this sets the button's width
            rdb.Height = 100; //this sets the button's height
            return rdb;
        }

        protected void rdbTimeSchedule_Clicked(object sender, EventArgs s)
        {
            RadioButton rdbTimeButton = sender as RadioButton;
            AppointmentCreator obj = new AppointmentCreator();
            obj.AssignDetails(PatientDetails, rdbTimeButton.Name, SelectedDate);
            obj.ShowDialog();
        }

        private void PopulateEmptyRows()
        {
            /*
             This method uses nested for loops to go through each cell in the TableLayoutPanel and checks
             if the tbllytAppoinmentSchedule has a control in that cell, if it does not have any controls in that cell
             the method creates a disabled button to fill that, so that it can act as an empty space filler in the calendar
             */
            for(int col = 0; col <tblpnlAppointmentCalendar.ColumnCount; col++)
            {
                for(int row = 0; row < tblpnlAppointmentCalendar.RowCount; row++)
                {
                    if(tblpnlAppointmentCalendar.GetControlFromPosition(col, row) == null)
                    {
                        RadioButton DayFiller = CalendarFiller(); //this creates a new disabled button to act as a calendar filler
                        tblpnlAppointmentCalendar.Controls.Add(DayFiller, col, row); //this fills that button on the empty cells of the table layout panel
                    }
                }
            }
        }

        private void btnMonthNext_Click(object sender, EventArgs e)
        {
            /*
             The two lines below are used to re-enable the btnMonthPrevious button that will be disable if the user tries to go to a month before the
             current month
             The lines following that is used to get the currently Selected month from the label and use it to parse a DateTime value
             so that it can be used to go to the next month using the AddMonths method
             Then we call the Chosen Month method to send the new month's details to populate a new calendar
             */
            btnMonthPrevious.Enabled = true;
            btnMonthPrevious.BackColor = Color.LightGray;

            string DisplayedMonth = lblSelectedMonth.Text;
            DateTime Month = DateTime.ParseExact(DisplayedMonth, "MMMM - yyyy", CultureInfo.InvariantCulture);
            DateTime NextMonth = Month.AddMonths(1);
            ChosenMonth(NextMonth);
        }

        private void btnMonthPrevious_Click(object sender, EventArgs e)
        {
            /*
             The lines below are used to get the currently Selected month from the label and use it to parse a DateTime value
             so that it can be used to go to the previous month using the AddMonths method (it uses a negative value to go back)
             Then we call the Chosen Month method to send the new month's details to populate a new calendar

            The if-else loop is used to ensure that the user does not go to a month before the current month
            in which case the btnPreviousMonth button will be disabled and only re-enable if the previous month is not before the current month 
             */
            string DisplayedMonth = lblSelectedMonth.Text;
            DateTime Month = DateTime.ParseExact(DisplayedMonth, "MMMM - yyyy", CultureInfo.InvariantCulture);
            if(Month >= DateTime.Today)
            {
                DateTime PreviousMonth = Month.AddMonths(-1);
                ChosenMonth(PreviousMonth);
            }
            else if(Month < DateTime.Today)
            {
                btnMonthPrevious.Enabled = false;
                btnMonthPrevious.BackColor = Color.LightGray;
            }
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            MainScreen obj = new MainScreen();
            obj.Show();
            this.Hide();
        }
    }
}
