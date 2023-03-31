using System;
using System.Drawing;
using Bunifu.UI.WinForms;
using System.Reflection.Emit;
using System.Windows.Forms;
using static Bunifu.UI.WinForms.BunifuLabel;
using System.Data.SqlClient;
using System.Data;
using Microsoft.VisualBasic.ApplicationServices;


namespace EMS___SCNE.UserControls
{
    public partial class Dashboard_UC : UserControl
    {
        string connectionString = @"Server=.\SQLEXPRESS;Database=EMS-SCNE;User Id=lakshitha;Password=123456;";

        public Dashboard_UC()
        {
            InitializeComponent();
            this.Region = new System.Drawing.Region(
            new System.Drawing.RectangleF(
                this.ClientRectangle.X,
                this.ClientRectangle.Y,
                this.ClientRectangle.Width,
                this.ClientRectangle.Height

                )
            );
          
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (var brush = new System.Drawing.SolidBrush(this.BackColor))
            {
                e.Graphics.FillRegion(brush, this.Region);
            }
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

            //display absent employee
            SqlConnection connection = new SqlConnection(connectionString);


            connection.Open();
            DateTime currentDate = DateTime.Today;

            // Create a SQL query to get the absent employees for the current date
            string query = "SELECT UserID, Name, Position, Department FROM Absent_emp WHERE Date = @date";

            // Create a SqlCommand object with the query and parameter
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@date", currentDate);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

              
                bunifuDataGridView2.DataSource = dataTable;
            }
            
            connection.Close();


            //display the best employee in month
            {
                SqlCommand cmd = new SqlCommand("GetTopEmployees_PreviousMonth", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                bunifuDataGridView1.DataSource = dt;
            }

            //display employee count
            {
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Employees", connection);
                connection.Open();
                int employeeCount = (int)cmd.ExecuteScalar();
                connection.Close();

                bunifuLabel2.Text = employeeCount.ToString();
            }

            /*
            //display daily attendence (without absents)
            {
                SqlCommand cmd = new SqlCommand("sp_GetDailyAttendanceCount", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                connection.Open();

                int monthlyAttendanceCount = (int)cmd.ExecuteScalar();

                bunifuLabel8.Text = monthlyAttendanceCount.ToString();

                connection.Close();
            }*/

            //display daily attendance (without absents)
            {
                SqlCommand cmd = new SqlCommand("sp_GetDailyAttendanceCount", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                connection.Open();

                int dailyAttendanceCount = (int)cmd.ExecuteScalar();

                // Get total number of employees
                SqlCommand cmdTotalEmployees = new SqlCommand("SELECT COUNT(*) FROM Employees", connection);
                int totalEmployees = (int)cmdTotalEmployees.ExecuteScalar();

                // Calculate percentage
                double percentage = (double)dailyAttendanceCount / totalEmployees * 100;

                bunifuLabel8.Text = string.Format("{0:F0}%", percentage);

                connection.Close();
            }

            /*
            //display the daily late attendence
            {
                SqlCommand cmd = new SqlCommand("sp_GetDailyLateAttendanceCount", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                connection.Open();

                int lateAttendanceCount = (int)cmd.ExecuteScalar();

                bunifuLabel10.Text = lateAttendanceCount.ToString();

                connection.Close();
            }*/

            //display the daily late attendance
            {
                SqlCommand cmd = new SqlCommand("sp_GetDailyLateAttendanceCount", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                connection.Open();

                int lateAttendanceCount = (int)cmd.ExecuteScalar();

                // Get total number of employees
                SqlCommand cmdTotalEmployees = new SqlCommand("SELECT COUNT(*) FROM Employees", connection);
                int totalEmployees = (int)cmdTotalEmployees.ExecuteScalar();

                // Calculate percentage
                double percentage = (double)lateAttendanceCount / totalEmployees * 100;

                bunifuLabel10.Text = string.Format("{0:F0}%", percentage);

                connection.Close();
            }

            /*
            //display the daily Early Check out employees 
            {
                SqlCommand cmd = new SqlCommand("sp_GetDailyEarlyCheckOutCount", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                connection.Open();
                int absentEmployeeCount = (int)cmd.ExecuteScalar();
                

                bunifuLabel12.Text = absentEmployeeCount.ToString();

                connection.Close();
            }*/

            //display the daily Early Check out employees 
            {
                SqlCommand cmd = new SqlCommand("sp_GetDailyEarlyCheckOutCount", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                connection.Open();
                int earlyCheckOutCount = (int)cmd.ExecuteScalar();

                // Get total number of employees
                SqlCommand cmdTotalEmployees = new SqlCommand("SELECT COUNT(*) FROM Employees", connection);
                int totalEmployees = (int)cmdTotalEmployees.ExecuteScalar();

                // Calculate percentage
                double percentage = (double)earlyCheckOutCount / totalEmployees * 100;

                bunifuLabel12.Text = string.Format("{0:F0}%", percentage);

                connection.Close();
            }



            //display who has got the annual leave for current date
            string storedProcedureName = "GetDaily_Annuelleave_requests";

            using (SqlConnection connection1 = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(storedProcedureName, connection1))
            {
                command.CommandType = CommandType.StoredProcedure;

                connection1.Open();

                int annualdailyCount = (int)command.ExecuteScalar();

                bunifuLabel13.Text = annualdailyCount.ToString();
            }

            //display who has got the monthly leave for current date
            string storedProcedureName1 = "GetDaily_Monthlyleave_requests";

            using (SqlConnection connection1 = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(storedProcedureName1, connection1))
            {
                command.CommandType = CommandType.StoredProcedure;

                connection1.Open();

                int monthlydailyCount = (int)command.ExecuteScalar();

                bunifuLabel18.Text = monthlydailyCount.ToString();
            }

            //display the employees in gender vice
            string maleGender = "M";
            string femaleGender = "F";

            try
            {
                
                {
                    connection.Open();

                    SqlCommand cmdMale = new SqlCommand("SELECT dbo.GetGenderCount(@gender)", connection);
                    cmdMale.Parameters.AddWithValue("@gender", maleGender);
                    int maleCount = (int)cmdMale.ExecuteScalar();

                    SqlCommand cmdFemale = new SqlCommand("SELECT dbo.GetGenderCount(@gender)", connection);
                    cmdFemale.Parameters.AddWithValue("@gender", femaleGender);
                    int femaleCount = (int)cmdFemale.ExecuteScalar();

                    bunifuLabel4.Text = "Male: " + maleCount.ToString();
                    bunifuLabel3.Text = "Female: " + femaleCount.ToString();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);


                // log the error to the database
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO ErrorLog (ErrorMessage, ErrorDate, ErrorType) VALUES (@ErrorMessage, @ErrorDate, @ErrorType); SELECT SCOPE_IDENTITY();", conn))
                    {
                        cmd.Parameters.AddWithValue("@ErrorMessage", ex.Message);
                        cmd.Parameters.AddWithValue("@ErrorDate", DateTime.Now);
                        cmd.Parameters.AddWithValue("@ErrorType", ex.GetType().ToString());
                        int errorId = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
            }
            
           /*
            // Retrieve the daily attendance count of employees

            {
                SqlCommand command = new SqlCommand("sp_GetDailyAttendanceCount", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                int attendanceCount = (int)command.ExecuteScalar();
                connection.Close();

                // Retrieve the total number of employees
                command = new SqlCommand("SELECT COUNT(*) FROM Employees", connection);
                connection.Open();
                int employeeCount = (int)command.ExecuteScalar();
                connection.Close();


                // Calculate the percentage of attendance
                double attendancePercentage = (double)attendanceCount / employeeCount * 100;

                // Display the attendance percentage in BunifuCircleProgress control
                bunifuCircleProgress1.Value = (int)attendancePercentage;
                bunifuCircleProgress1.Text = attendancePercentage.ToString("0.00") + "%";
            }*/
       

            //absent table titel
            {
                string message = "Absents for: " + DateTime.Now.ToString("MM/dd/yyyy");
                bunifuLabel15.Text = message;
            }
            

            // Execute sp_GetDailyAttendanceCount_ByPlace for lobby
            {

                SqlCommand cmd1 = new SqlCommand("sp_GetDailyAttendanceCount_ByPlace", connection);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@Place", "lobby");

                connection.Open();
                int lobbyAttendanceCount = (int)cmd1.ExecuteScalar();
                connection.Close();

                bunifuLabel20.Text = "The SIX: " + lobbyAttendanceCount.ToString();

            }

            // Execute sp_GetDailyAttendanceCount_ByPlace for Main Office  (Use a copy of this same code to excecute another Place, Just mention the place whatever you want in @place, "enter hear")
            {
                SqlCommand cmd2 = new SqlCommand("sp_GetDailyAttendanceCount_ByPlace", connection);
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue("@Place", "Main Office");

                connection.Open();
                int mainOfficeAttendanceCount = (int)cmd2.ExecuteScalar();
                connection.Close();

                bunifuLabel21.Text = "Villa ANNA: " + mainOfficeAttendanceCount.ToString();

            }

        }

        private void bunifuSeparator1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuPanel3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel5_Click(object sender, EventArgs e)
        {

        }

        private void bunifuDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           

        }

        private void bunifuCircleProgress1_ProgressChanged(object sender, Bunifu.UI.WinForms.BunifuCircleProgress.ProgressChangedEventArgs e)
        {
            
           
        }

        private void greatingslable_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            {
                SqlCommand command = new SqlCommand("sp_GetDailyAttendanceCount", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                int attendanceCount = (int)command.ExecuteScalar();
                connection.Close();

                // Retrieve the total number of employees
                command = new SqlCommand("SELECT COUNT(*) FROM Employees", connection);
                connection.Open();
                int employeeCount = (int)command.ExecuteScalar();
                connection.Close();


                // Calculate the percentage of attendance
                double attendancePercentage = (double)attendanceCount / employeeCount * 100;

                // Display the attendance percentage in BunifuCircleProgress control
                bunifuCircleProgress1.Value = (int)attendancePercentage;
                bunifuCircleProgress1.Text = attendancePercentage.ToString("0.00") + "%";
            }


            DateTime currentTime = DateTime.Now;

            // Check the time of day and set the label text accordingly
            if (currentTime.Hour >= 5 && currentTime.Hour < 12)
            {
                // Good morning
                greatingslable.Text = "Good Morning";
            }
            else if (currentTime.Hour >= 12 && currentTime.Hour < 18)
            {
                // Good afternoon
                greatingslable.Text = "Good Afternoon";
            }
            else
            {
                // Good evening
                greatingslable.Text = "Good Evening";
            }
        }

        private void bunifuLabel8_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel15_Click(object sender, EventArgs e)
        {

        }

        private void bunifuPanel7_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel17_Load(object sender, EventArgs e)
        {
            
            
        }

        private void bunifuPanel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuDataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void bunifuLabel2_Click(object sender, EventArgs e)
        {
           
        }

        private void bunifuLabel10_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel12_Click(object sender, EventArgs e)
        {

        }

        private void bunifuDataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bunifuLabel13_Click(object sender, EventArgs e)
        {
        

        }

        private void bunifuPanel9_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel19_Click(object sender, EventArgs e)
        {

        }

        private void bunifuGradientPanel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuPanel13_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel20_Click(object sender, EventArgs e)
        {

        }

        private void gunaWinCircleProgressIndicator1_Load(object sender, EventArgs e)
        {

        }

        private void bunifuCircleProgress2_ProgressChanged(object sender, BunifuCircleProgress.ProgressChangedEventArgs e)
        {

        }
    }
}
