using Microsoft.VisualBasic.ApplicationServices;
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
using System.Security.Cryptography;
using Bunifu.Framework.UI;
using System.Net.Mail;
using System.Net;

namespace EMS___SCNE.UserControls___SuperAdmin
{
    public partial class EMSAccess_Superadmin : UserControl
    {
        string connectionString = @"Server=.\SQLEXPRESS;Database=EMS-SCNE;User Id=lakshitha;Password=123456;";

        public EMSAccess_Superadmin()
        {
            InitializeComponent();
        }

        private void Settings_Superadmin_Load(object sender, EventArgs e)
        {
            //dropdown-accesscontrol
            bunifuDropdown1.Items.AddRange(new string[] { "HR Admin", "HR DO", "View Only" });

            
        }

        private void bunifuLabel14_Click(object sender, EventArgs e)
        {

        }

        private bool CheckUserExists(string userId)
        {
            bool userExists = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Employees WHERE UserID=@UserID", connection);
                    command.Parameters.AddWithValue("@UserID", userId);
                    int count = (int)command.ExecuteScalar();
                    userExists = (count > 0);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("An error occurred while checking if the user exists: " + ex.Message);

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
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while checking if the user exists: " + ex.Message);

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
            return userExists;
        }

        private string GetMd5Hash(string input)
        {
            try
            {
                using (MD5 md5Hash = MD5.Create())
                {
                    byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
                    StringBuilder builder = new StringBuilder();
                    for (int i = 0; i < data.Length; i++)
                    {
                        builder.Append(data[i].ToString("x2"));
                    }
                    return builder.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred while hashing password: " + ex.Message);
                return "";


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
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            try
            {
                // Retrieve the values from the input fields
                string userId = bunifuTextBox1.Text;
                string accessLevel = bunifuDropdown1.Text;
                string username = bunifuTextBox2.Text;
                string password = bunifuTextBox3.Text;
                string email = bunifuTextBox4.Text;

                // Check if the user exists in the Employees table
                bool userExists = CheckUserExists(userId);

                if (!userExists)
                {
                    MessageBox.Show("The entered User ID does not exist in the Employees table.");
                    return;
                }

                // Hash the password using MD5
                string hashedPassword = GetMd5Hash(password);

                // Insert the data into the LoginCredentials table
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("INSERT INTO LoginCredentials(UserID, AccessLevel, Username, Password, Email) VALUES (@UserID, @AccessLevel, @Username, @Password, @Email)", connection);
                    command.Parameters.AddWithValue("@UserID", userId);
                    command.Parameters.AddWithValue("@AccessLevel", accessLevel);
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", hashedPassword);
                    command.Parameters.AddWithValue("@Email", email);
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        // Display confirmation message
                        MessageBox.Show("Record added successfully!");

                        // Send the email
                        SendEmail(email, username, password);
                       
                    }
                    else
                    {
                        MessageBox.Show("Failed to add record.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);

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
        }


        private void SendEmail(string recipientEmail, string username, string password)
        {
            try
            {
                // Construct the email message
                MailMessage message = new MailMessage();
                message.From = new MailAddress("ems.scne@gmail.com"); // Replace with the sender's email address
                message.To.Add(recipientEmail);
                message.Subject = "Login Credentials";
                message.Body = string.Format("Dear {0}, your login credentials are:\nUsername: {1}\nPassword: {2}", username, username, password);

                // Configure the SMTP client
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 465);
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential("ems.scne@gmail.com", "ems.scne##2023"); // Replace with the sender's email address and password
                smtpClient.EnableSsl = true;

                // Send the email
                smtpClient.Send(message);

                // Show success message
                MessageBox.Show("Email sent successfully.");
            }
            catch (Exception ex)
            {
                // Show error message
                MessageBox.Show("Error occurred while sending email: " + ex.Message);

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
        }


        // The CheckUserExists and GetMd5Hash methods remain the same as in the previous code snippet.



        private void bunifuLabel11_Click(object sender, EventArgs e)
        {

            
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            if (bunifuDataGridView1.SelectedRows.Count == 1)
            {
                DataGridViewRow row = bunifuDataGridView1.SelectedRows[0];
                //int userID = Convert.ToInt32(row.Cells["UserID"].Value);
                int userID = int.Parse(row.Cells[0].Value.ToString());

                // Prompt the user to confirm the deletion
                DialogResult result = MessageBox.Show("Are you sure you want to delete this record?",
                                                      "Confirmation",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Delete the record from the database
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = $"DELETE FROM LoginCredentials WHERE UserID = {userID}";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            // Remove the row from the DataGridView
                            bunifuDataGridView1.Rows.Remove(row);
                            MessageBox.Show("Record deleted successfully.");
                        }
                        else
                        {
                            MessageBox.Show("Error deleting record.");
                        }
                        conn.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a row to delete.");

            }
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            string query = "SELECT UserID, AccessLevel, Username, Email FROM LoginCredentials";

            // If a UserID is entered in the search textbox, filter the results
            if (!string.IsNullOrEmpty(bunifuTextBox10.Text))
            {
                int userId;
                if (!int.TryParse(bunifuTextBox10.Text, out userId))
                {
                    MessageBox.Show("Please enter a valid UserID");
                    return;
                }

                query += $" WHERE UserID = {userId}";
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);

                bunifuDataGridView1.DataSource = dataSet.Tables[0];
            }
        }

        private void bunifuDropdown1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
