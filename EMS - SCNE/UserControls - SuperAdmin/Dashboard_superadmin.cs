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

                    string query = "SELECT COUNT(*) FROM Feedback WHERE TypeofFeedback IN ('Feedback', 'Complain') AND MONTH(CurrentDate) = MONTH(GETDATE())";
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
                    saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                    saveFileDialog.Title = "Export Error Log Data";
                    saveFileDialog.FileName = "ErrorLog.txt";
                    DialogResult result = saveFileDialog.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                        {
                            while (reader.Read())
                            {
                                string errorMessage = reader.GetString(reader.GetOrdinal("ErrorMessage"));
                                DateTime errorDate = reader.GetDateTime(reader.GetOrdinal("ErrorDate"));
                                string errorType = reader.GetString(reader.GetOrdinal("ErrorType"));

                                string line = $"{errorMessage}\t{errorDate}\t{errorType}";
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

    }
}
