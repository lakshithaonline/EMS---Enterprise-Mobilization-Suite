using Bunifu.UI.WinForms;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.ComponentModel.Design.ObjectSelectorEditor;


namespace EMS___SCNE
{
    public partial class OverviewPanel_superadmin : UserControl
    {

        string connectionString = "Server=.\\SQLEXPRESS;Database=EMS-SCNE;User Id=lakshitha;Password=123456;";
        
      

        public OverviewPanel_superadmin()
        {
            InitializeComponent();
        }

        private void OverviewPanel_superadmin_Load(object sender, EventArgs e)
        {
            timer1.Start();

            // Call the stored procedures and retrieve the data
            DataTable fullAttendanceData = GetAttendanceData("GetFullAttendanceCountsforDisplay");
            DataTable lowHoursAttendanceData = GetAttendanceData("GetLowHoursAttendanceCountDisplay");
            DataTable absentAttendanceData = GetAttendanceData("GetAbsentAttendanceCountDisplay");

            // Calculate employee count and working days count
            int employeeCount = GetEmployeeCount();
            int workingDays = GetWorkingDaysCount();

            // Prepare the chart
            chart1.Series.Clear();
            chart1.Titles.Add("Monthly Attendance");
            chart1.ChartAreas[0].AxisX.Title = "Month";
            chart1.ChartAreas[0].AxisY.Title = "Attendance Percentage";
            chart1.ChartAreas[0].AxisX.Maximum = 12;
            chart1.ChartAreas[0].AxisX.Maximum = DateTime.Now.Month;
            chart1.ChartAreas[0].AxisX.Minimum = 1; 
           //hart1.ChartAreas[0].AxisX.Interval = 1;

            // Display Full Attendance data
            Series fullAttendanceSeries = new Series("Full Attendance");
            fullAttendanceSeries.ChartType = SeriesChartType.Line;
            fullAttendanceSeries.BorderWidth = 3; // Set thicker line

            foreach (DataRow row in fullAttendanceData.Rows)
            {
                int monthNumber = Convert.ToInt32(row["MonthNumber"]);
                int attendanceCount = Convert.ToInt32(row["FullAttendanceCount"]);

                double attendancePercentage = (attendanceCount / (double)(employeeCount * workingDays)) * 100;
                fullAttendanceSeries.Points.AddXY(monthNumber, attendancePercentage);
            }

            // Display Low Hours Attendance data
            Series lowHoursAttendanceSeries = new Series("Low Hours Attendance");
            lowHoursAttendanceSeries.ChartType = SeriesChartType.Line;
            lowHoursAttendanceSeries.BorderWidth = 3; // Set thicker line

            foreach (DataRow row in lowHoursAttendanceData.Rows)
            {
                int monthNumber = Convert.ToInt32(row["MonthNumber"]);
                int attendanceCount = Convert.ToInt32(row["LowHoursAttendanceCount"]);

                double attendancePercentage = (attendanceCount / (double)(employeeCount * workingDays)) * 100;
                lowHoursAttendanceSeries.Points.AddXY(monthNumber, attendancePercentage);
            }

            // Display Absent Attendance data
            Series absentAttendanceSeries = new Series("Absent Attendance");
            absentAttendanceSeries.ChartType = SeriesChartType.Line;
            absentAttendanceSeries.BorderWidth = 3; // Set thicker line

            foreach (DataRow row in absentAttendanceData.Rows)
            {
                int monthNumber = Convert.ToInt32(row["MonthNumber"]);
                int attendanceCount = Convert.ToInt32(row["AbsentAttendanceCount"]);

                double attendancePercentage = (attendanceCount / (double)(employeeCount * workingDays)) * 100;
                absentAttendanceSeries.Points.AddXY(monthNumber, attendancePercentage);
            }

            // Add the series to the chart
            chart1.Series.Add(fullAttendanceSeries);
            chart1.Series.Add(lowHoursAttendanceSeries);
            chart1.Series.Add(absentAttendanceSeries);


            //chart 2 code
            {

                // Configure the chart
                chart2.Series.Clear();
                chart2.Series.Add("LeaveRequests");
                chart2.Series["LeaveRequests"].ChartType = SeriesChartType.Bar;
                chart2.Series["LeaveRequests"].XValueType = ChartValueType.String;
                chart2.ChartAreas[0].AxisX.Interval = 1;
                chart2.Legends.Clear();

                // Connect to the database and retrieve the leave request data
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT LeaveRID, Leave_Type, From_Date FROM LeaveRequest_HistoryDisplay";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    // Initialize month counters
                    double[] monthCounts = new double[12];

                    while (reader.Read())
                    {
                        // Get the month from the From_Date column
                        DateTime fromDate = (DateTime)reader["From_Date"];
                        int month = fromDate.Month - 1; // Months are 1-based, so subtract 1 to get zero-based index

                        // Count the leave requests based on the Leave_Type
                        string leaveType = (string)reader["Leave_Type"];
                        if (leaveType == "half_day")
                            monthCounts[month] += 0.5;
                        else if (leaveType == "short_leave")
                            monthCounts[month] += 0.5;
                        else
                            monthCounts[month] += 1;
                    }

                    reader.Close();

                    // Add the data points to the chart
                    string[] monthNames = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
                    for (int i = 0; i < 12; i++)
                    {
                        DataPoint dataPoint = new DataPoint(i, monthCounts[i]);
                        dataPoint.AxisLabel = monthNames[i];
                        chart2.Series["LeaveRequests"].Points.Add(dataPoint);

                        // Check if the data point count is zero for half-day and short leave types and add those as well
                        if (monthCounts[i] == 0 && (i == 6 || i == 7)) // Assuming June and July are the respective months for half-day and short leave types
                        {
                            DataPoint zeroDataPoint = new DataPoint(i, 0);
                            zeroDataPoint.AxisLabel = monthNames[i];
                            chart2.Series["LeaveRequests"].Points.Add(zeroDataPoint);
                        }

                    }
                }


            }

        }

        private DataTable GetAttendanceData(string storedProcedureName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(storedProcedureName, connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                return dataTable;
            }
        }

        private int GetEmployeeCount()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Employees", connection);
                int employeeCount = (int)command.ExecuteScalar();

                return employeeCount;
            }
        }





        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCircleProgress3_ProgressChanged(object sender, Bunifu.UI.WinForms.BunifuCircleProgress.ProgressChangedEventArgs e)
        {

        }

        private void bunifuCircleProgress1_ProgressChanged(object sender, Bunifu.UI.WinForms.BunifuCircleProgress.ProgressChangedEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string placeName = "ANNA"; // Replace with the desired place name
            {
                // using (SqlConnection connection = new SqlConnection("YourConnectionString"))
                {
                    connection.Open();

                   
                    SqlCommand command = new SqlCommand("GetAttendanceByPlace_Display", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PlaceName", placeName);

                    int attendanceCount = (int)command.ExecuteScalar();

                  
                    command = new SqlCommand("SELECT COUNT(UserID) FROM Employees", connection);
                    int employeeCount = (int)command.ExecuteScalar();

                   
                    int workingDays = GetWorkingDaysCount();

                   
                    double attendancePercentage = (attendanceCount / (double)(3 * workingDays)) * 100;
                    //  (336 / (26 * 27)*100 = 47.9201.

                    
                    bunifuCircleProgress1.Value = (int)attendancePercentage;
                    bunifuCircleProgress1.Text = attendancePercentage.ToString("0.00") + "%";

                    connection.Close();
                }
            }


            string placeName1 = "SIX"; // Replace with the desired place name
            {
                {
                    connection.Open();

                   
                    SqlCommand command = new SqlCommand("GetAttendanceByPlace_Display", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PlaceName", placeName1);

                    int attendanceCount = (int)command.ExecuteScalar();

                    command = new SqlCommand("SELECT COUNT(UserID) FROM Employees", connection);
                    int employeeCount = (int)command.ExecuteScalar();

                    int workingDays = GetWorkingDaysCount();

                    double attendancePercentage = (attendanceCount / (double)(3 * workingDays)) * 100;
                    //  (280 / (26*27))*100 = 39.8004

                    bunifuCircleProgress2.Value = (int)attendancePercentage;
                    bunifuCircleProgress2.Text = attendancePercentage.ToString("0.00") + "%";

                    connection.Close();
                }
            }

            string placeName2 = "KAMATHA"; // Replace with the desired place name
            {
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("GetAttendanceByPlace_Display", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PlaceName", placeName2);

                    int attendanceCount = (int)command.ExecuteScalar();

                    command = new SqlCommand("SELECT COUNT(UserID) FROM Employees", connection);
                    int employeeCount = (int)command.ExecuteScalar();

                    int workingDays = GetWorkingDaysCount();

                    double attendancePercentage = (attendanceCount / (double)(4 * workingDays)) * 100;
                    //  (280 / (26*27))*100 = 39.8004

                    bunifuCircleProgress3.Value = (int)attendancePercentage;
                    bunifuCircleProgress3.Text = attendancePercentage.ToString("0.00") + "%";

                    connection.Close();
                }
            }

            string placeName3 = "THAMBURU"; 
            {
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("GetAttendanceByPlace_Display", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PlaceName", placeName3);

                    int attendanceCount = (int)command.ExecuteScalar();

                    command = new SqlCommand("SELECT COUNT(UserID) FROM Employees", connection);
                    int employeeCount = (int)command.ExecuteScalar();

                    int workingDays = GetWorkingDaysCount();

                    double attendancePercentage = (attendanceCount / (double)(4 * workingDays)) * 100;
                

                    bunifuCircleProgress4.Value = (int)attendancePercentage;
                    bunifuCircleProgress4.Text = attendancePercentage.ToString("0.00") + "%";

                    connection.Close();
                }
            }
 
        }


        private int GetWorkingDaysCount()
        {
            int totalDays = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
            int workingDays = 0;

            for (int day = 1; day <= totalDays; day++)
            {
                DateTime date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, day);

                // Skip Sundays and special holidays in Sri Lanka Buddhist calendar
                if (date.DayOfWeek != DayOfWeek.Sunday && !IsSpecialHoliday(date))
                {
                    workingDays++;
                }
            }

            return workingDays;
        }




        // Function to check if the given date is a special holiday in Sri Lanka Buddhist calendar
        bool IsSpecialHoliday(DateTime date)
        {
            // Add your logic to identify special holidays in Sri Lanka Buddhist calendar
            // Return true if the date is a special holiday, otherwise return false
            return false;
        }

        private void bunifuLabel2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel5_Click(object sender, EventArgs e)
        {

        }

        private void bunifuPanel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCircleProgress2_ProgressChanged(object sender, BunifuCircleProgress.ProgressChangedEventArgs e)
        {

        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuPanel3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel1_Click(object sender, EventArgs e)
        {

        }
    }

}
