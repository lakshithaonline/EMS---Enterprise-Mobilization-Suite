using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.UI.WinForms;
using Microsoft.Reporting.WinForms;
using iTextSharp.text.pdf;
using iTextSharp.text;
using PdfSharp.Drawing;

namespace EMS___SCNE.UserControls___SuperAdmin
{
    public partial class Dashboard_superadmin : UserControl
    {
        string connString = "Server=.\\SQLEXPRESS;Database=EMS-SCNE;User Id=lakshitha;Password=123456;";

        public Dashboard_superadmin()
        {
            InitializeComponent();

        }

        private void bunifuPanel7_Click(object sender, EventArgs e)
        {

        }

        private void Dashboard_superadmin_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connString);

            DisplayRecordCount();

            //display employee count
            {
                SqlCommand cmdAdmin = new SqlCommand("SELECT COUNT(*) FROM LoginCredentials WHERE AccessLevel = 'HR Admin'", connection);
                connection.Open();
                int adminCount = Convert.ToInt32(cmdAdmin.ExecuteScalar());
                connection.Close();
                bunifuLabel9.Text = adminCount.ToString();

                SqlCommand cmdDO = new SqlCommand("SELECT COUNT(*) FROM LoginCredentials WHERE AccessLevel = 'HR DO'", connection);
                connection.Open();
                int doCount = Convert.ToInt32(cmdDO.ExecuteScalar());
                connection.Close();
                bunifuLabel11.Text = doCount.ToString();
            
            }

            //display Feadback and Complain count.
            {

                try
                {
                    // Open the connection
                    connection.Open();
                    
                    string query = "SELECT COUNT(*) FROM Feedback WHERE TypeofFeedback = 'Feedback' AND MONTH(CurrentDate) = MONTH(GETDATE())";
                    SqlCommand command = new SqlCommand(query, connection);
                    int feedbackCount = (int)command.ExecuteScalar();

                    bunifuLabel1.Text = "Feedbacks: " + feedbackCount.ToString();

                    query = "SELECT COUNT(*) FROM Feedback WHERE TypeofFeedback = 'Complain' AND MONTH(CurrentDate) = MONTH(GETDATE())";
                    command = new SqlCommand(query, connection);
                    int complainCount = (int)command.ExecuteScalar();

                    bunifuLabel2.Text = "Complains: " + complainCount.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }


            }

            //display Changes in tables
            {
                string connectionString = connString;
                string query = "SELECT * FROM Changes " +
                               "WHERE ChangeTime >= DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), 0) " +
                               "  AND ChangeTime < DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()) + 1, 0)";

                SqlDataAdapter adapter = new SqlDataAdapter(query, connectionString);
                DataTable table = new DataTable();
                adapter.Fill(table);

                bunifuDataGridView1.DataSource = table;
            }

        }

        private void bunifuLabel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            string connString = "Server=.\\SQLEXPRESS;Database=EMS-SCNE;User Id=lakshitha;Password=123456;";
            string query = "SELECT * FROM ErrorLog";

            using (SqlConnection conn = new SqlConnection(connString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                    saveFileDialog.Title = "Export Error Log Data";
                    saveFileDialog.FileName = "ErrorLog.csv";
                    DialogResult result = saveFileDialog.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                        {
                            // Write header row
                            writer.WriteLine("ErrorMessage,ErrorDate,ErrorType");

                            while (reader.Read())
                            {
                                string errorMessage = reader.GetString(reader.GetOrdinal("ErrorMessage"));
                                DateTime errorDate = reader.GetDateTime(reader.GetOrdinal("ErrorDate"));
                                string errorType = reader.GetString(reader.GetOrdinal("ErrorType"));

                                string line = $"{errorMessage},{errorDate},{errorType}";
                                writer.WriteLine(line);
                            }
                        }

                        MessageBox.Show($"Error log data exported to {saveFileDialog.FileName}");
                    }
                }
            }
        }



        private void bunifuLabel6_Click(object sender, EventArgs e)
        {

        }

        private void DisplayRecordCount()
        {
            //string connString = "Server=.\\SQLEXPRESS;Database=EMS-SCNE;User Id=lakshitha;Password=123456;";
            string query = "SELECT COUNT(*) FROM ErrorLog";
            int recordCount = 0;

            using (SqlConnection conn = new SqlConnection(connString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                recordCount = (int)cmd.ExecuteScalar();
            }

           // bunifuLabel6.Text = recordCount.ToString();
            bunifuLabel6.Text = "Catch Count: " + recordCount.ToString();
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = "ErrorLog.txt";
                string recipient = "ems.scne@gmail.com";

                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress("your-email-address-here");
                    mail.To.Add(recipient);
                    mail.Subject = "Error Log Report";
                    mail.Body = "Please find attached the Error Log report.";

                    Attachment attachment = new Attachment(filePath);
                    mail.Attachments.Add(attachment);

                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.Credentials = new NetworkCredential("your-email-address-here", "your-email-password-here");
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                    }
                }

                MessageBox.Show("Error log report sent to " + recipient, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sending email: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bunifuLabel21_Click(object sender, EventArgs e)
        {

        }

        private void bunifuPanel2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel9_Click(object sender, EventArgs e)
        {

        }

        private void gunaWinCircleProgressIndicator1_Load(object sender, EventArgs e)
        {

        }

        private void bunifuPanel6_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel14_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM Employees", conn);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet);

                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Create a CSV file and write the data from the dataset to it
                        using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                        {
                            foreach (DataTable table in dataSet.Tables)
                            {
                                foreach (DataRow row in table.Rows)
                                {
                                    string[] columns = row.ItemArray.Select(field => field.ToString()).ToArray();
                                    writer.WriteLine(string.Join(",", columns));
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM Attendance", conn);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet);

                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                        {
                            foreach (DataTable table in dataSet.Tables)
                            {
                                foreach (DataRow row in table.Rows)
                                {
                                    string[] columns = row.ItemArray.Select(field => field.ToString()).ToArray();
                                    writer.WriteLine(string.Join(",", columns));
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Display an error message box with the exception message
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bunifuButton5_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM LeaveRequest_HistoryDisplay", conn);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet);

                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                        {
                            foreach (DataTable table in dataSet.Tables)
                            {
                                foreach (DataRow row in table.Rows)
                                {
                                    string[] columns = row.ItemArray.Select(field => field.ToString()).ToArray();
                                    writer.WriteLine(string.Join(",", columns));
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bunifuButton6_Click(object sender, EventArgs e)
        {

            try
            {
  
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM LeaveRequest_History", conn);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet);

                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                        {
                            foreach (DataTable table in dataSet.Tables)
                            {
                                foreach (DataRow row in table.Rows)
                                {
                                    string[] columns = row.ItemArray.Select(field => field.ToString()).ToArray();
                                    writer.WriteLine(string.Join(",", columns));
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bunifuPanel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel7_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel16_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel1_Click_1(object sender, EventArgs e)
        {

        }

        private void bunifuLabel3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton8_Click(object sender, EventArgs e)
        {
            // Filter Feedback records
            DataTable feedbackTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Feedback WHERE TypeofFeedback = 'Feedback'", connection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(feedbackTable);
            }

            // Export Feedback records to CSV
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV file (*.csv)|*.csv";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StringBuilder sb = new StringBuilder();
                IEnumerable<string> columnNames = feedbackTable.Columns.Cast<DataColumn>().Select(column => column.ColumnName);
                sb.AppendLine(string.Join(",", columnNames));
                foreach (DataRow row in feedbackTable.Rows)
                {
                    IEnumerable<string> fields = row.ItemArray.Select(field => string.Concat("\"", field.ToString().Replace("\"", "\"\""), "\""));
                    sb.AppendLine(string.Join(",", fields));
                }
                File.WriteAllText(saveFileDialog.FileName, sb.ToString());
            }
        }

        private void bunifuButton7_Click(object sender, EventArgs e)
        {
            // Filter Complaints records
            DataTable complaintsTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Feedback WHERE TypeofFeedback = 'Complaint'", connection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(complaintsTable);
            }

            // Export Complaints records to CSV
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV file (*.csv)|*.csv";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StringBuilder sb = new StringBuilder();
                IEnumerable<string> columnNames = complaintsTable.Columns.Cast<DataColumn>().Select(column => column.ColumnName);
                sb.AppendLine(string.Join(",", columnNames));
                foreach (DataRow row in complaintsTable.Rows)
                {
                    IEnumerable<string> fields = row.ItemArray.Select(field => string.Concat("\"", field.ToString().Replace("\"", "\"\""), "\""));
                    sb.AppendLine(string.Join(",", fields));
                }
                File.WriteAllText(saveFileDialog.FileName, sb.ToString());
            }
        }

        private void gunaWinCircleProgressIndicator2_Load(object sender, EventArgs e)
        {

        }

        private void bunifuPanel8_Click(object sender, EventArgs e)
        {

        }

        private void bunifuDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bunifuButton11_Click(object sender, EventArgs e)
        {
            DateTime fromDate = bunifuDatePicker1.Value;
            DateTime toDate = bunifuDatePicker2.Value;

            DataTable attendanceData = GetAttendanceData(fromDate, toDate);

            int totalWorkingDays = 0;
            int totalEmployees = 0;
            int totalAbsentEmployees = 0;
            int totalLateArrivals = 0;

            StringBuilder reportBuilder = new StringBuilder();

            // Introduction
            reportBuilder.AppendLine("Introduction:");
            reportBuilder.AppendLine($"The following report provides a comprehensive overview of the employee attendance for the month of {fromDate.ToString("MMMM, yyyy")}. The data presented here will aid the top management in making informed decisions related to workforce management and performance evaluation.");
            reportBuilder.AppendLine();

            // Normal Attendance
            reportBuilder.AppendLine("Normal Attendance:");
            reportBuilder.AppendLine("The normal attendance section provides an overview of employee attendance during regular working hours. It includes the total number of working days in the month and the number of employees who attended work on each of those days. This data allows management to assess the overall workforce availability and identify any patterns or trends.");
            reportBuilder.AppendLine($"Month: {fromDate.ToString("MMMM, yyyy")}");

            reportBuilder.AppendLine("Date | Attendance Count");

            DateTime currentDate = fromDate;
            while (currentDate <= toDate)
            {
                int attendanceCount = GetAttendanceCountForDate(attendanceData, currentDate);
                reportBuilder.AppendLine($"{currentDate.ToShortDateString()} | {attendanceCount}");

                totalWorkingDays++;
                totalEmployees += attendanceCount;

                currentDate = currentDate.AddDays(1);
            }
            reportBuilder.AppendLine($"Total Working Days: {totalWorkingDays}");
            reportBuilder.AppendLine($"Total Employees: {totalEmployees}");
            reportBuilder.AppendLine();

            // Absent Employee Count
            reportBuilder.AppendLine("Absent Employee Count:");
            reportBuilder.AppendLine("The absent employee count section highlights the number of employees who were absent during the month. It provides a clear overview of the absenteeism rate and enables management to identify any potential issues or areas that require attention.");
            reportBuilder.AppendLine($"Month: {fromDate.ToString("MMMM, yyyy")}");

            int absentEmployees = GetAbsentEmployeeCount(attendanceData);
            reportBuilder.AppendLine($"Total Employees: {totalEmployees}");
            reportBuilder.AppendLine($"Total Absent Employees: {absentEmployees}");
            reportBuilder.AppendLine();
            totalAbsentEmployees = absentEmployees;

            // Late Attendance
            reportBuilder.AppendLine("Late Attendance:");
            reportBuilder.AppendLine("The late attendance section focuses on instances where employees arrived late to work during the month. It provides information on the frequency and extent of late arrivals, enabling management to address punctuality concerns and take appropriate measures if necessary.");
            reportBuilder.AppendLine($"Month: {fromDate.ToString("MMMM, yyyy")}");

            int lateArrivals = GetLateArrivalCount(attendanceData);
            reportBuilder.AppendLine($"Total Employees: {totalEmployees}");
            reportBuilder.AppendLine($"Total Late Arrivals: {lateArrivals}");
            reportBuilder.AppendLine();
            totalLateArrivals = lateArrivals;

            // Conclusion
            reportBuilder.AppendLine("Conclusion:");
            reportBuilder.AppendLine("The Monthly Employee Attendance Summary Report offers a concise overview of normal attendance, absent employee count, and late attendance for the given month. By analyzing this data, the top management can make informed decisions related to workforce planning, employee engagement, and performance evaluation. It is recommended to regularly review such reports to ensure optimal productivity and identify any areas that may require improvement.");

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files|*.txt";
            saveFileDialog.Title = "Save Attendance Report";
            saveFileDialog.FileName = "AttendanceReport.txt";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.Write(reportBuilder.ToString());
                }

                MessageBox.Show("Attendance report generated and saved successfully!");
            }
        }

        private DataTable GetAttendanceData(DateTime fromDate, DateTime toDate)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connString))
            {
                string query = "SELECT * FROM Attendance WHERE Date >= @FromDate AND Date <= @ToDate";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@FromDate", fromDate);
                command.Parameters.AddWithValue("@ToDate", toDate);

                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataTable);
            }

            return dataTable;
        }

        private int GetAttendanceCountForDate(DataTable attendanceData, DateTime date)
        {
            int attendanceCount = 0;

            foreach (DataRow row in attendanceData.Rows)
            {
                DateTime rowDate = Convert.ToDateTime(row["Date"]);

                if (rowDate.Date == date.Date)
                {
                    attendanceCount++;
                }
            }

            return attendanceCount;
        }

        private int GetAbsentEmployeeCount(DataTable attendanceData)
        {
            int absentEmployeeCount = 0;

            foreach (DataRow row in attendanceData.Rows)
            {
                int totalHoursWorked = Convert.ToInt32(row["Total_Hours_Worked"]);

                if (totalHoursWorked == 0)
                {
                    absentEmployeeCount++;
                }
            }

            return absentEmployeeCount;
        }

        private int GetLateArrivalCount(DataTable attendanceData)
        {
            int lateArrivalCount = 0;

            foreach (DataRow row in attendanceData.Rows)
            {
                int totalHoursWorked = Convert.ToInt32(row["Total_Hours_Worked"]);

                if (totalHoursWorked < 8 && totalHoursWorked > 2)
                {
                    lateArrivalCount++;
                }
            }

            return lateArrivalCount;
        }

        private void saveFileDialog_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}
