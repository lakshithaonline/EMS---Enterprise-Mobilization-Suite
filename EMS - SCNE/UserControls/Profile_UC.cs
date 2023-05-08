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
using System.IO;
using Bunifu.UI.WinForms;

namespace EMS___SCNE
{
    public partial class Profile_UC : UserControl
    {

        string connString = "Server=.\\SQLEXPRESS;Database=EMS-SCNE;User Id=lakshitha;Password=123456;";

        public Profile_UC()
        {
            InitializeComponent();
        }

        private void Profile_UC_Load(object sender, EventArgs e)
        {
            // Populate bunifuDropdown2 with options
            string[] feedbackOptions = { "Feedback", "Complain", "Monitoring Notification" };
            bunifuDropdown1.Items.AddRange(feedbackOptions);

            // Populate bunifuDropdown3 with options
            string[] sectorOptions = { "Attendance", "Leave", "Other" };
            bunifuDropdown2.Items.AddRange(sectorOptions);

         //   SuggestEmployeeNames(bunifuTextBox3.Text);

        }

        private void bunifuLabel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel8_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel13_Click(object sender, EventArgs e)
        {

        }

        private void bunifuPanel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuPanel2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel22_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel32_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel31_Click(object sender, EventArgs e)
        {


        }

        private void bunifuLabel35_Click(object sender, EventArgs e)
        {

        }

        private void guna2Separator1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(bunifuTextBox1.Text, out int userID))
            {
                MessageBox.Show("Invalid user ID entered.");
                return;
            }

            string phoneNumber = GetPhoneNumber(userID);

            if (phoneNumber != null)
            {
                bunifuLabel15.Text = phoneNumber;
            } else
            {
                bunifuLabel15.Text =" ";
            }

            using (SqlConnection connection = new SqlConnection(connString))
            using (SqlCommand command = new SqlCommand("SELECT Name, Department, Position, UserID, ProfilePicture, Gender, DOB, Address, Marital_Status FROM Employees WHERE UserID = @userID", connection))
            {
                command.Parameters.AddWithValue("@userID", userID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        string fullName = reader.GetString(0); // Assuming the name is retrieved from the first column (index 0)

                        // Get the first word of the name
                        string[] nameParts = fullName.Split(' ');
                        string firstName = nameParts[0];

                        bunifuLabel2.Text = firstName;
                        bunifuLabel3.Text = reader.GetString(1); // Display Department
                        bunifuLabel4.Text = reader.GetString(2); // Display Position
                        bunifuLabel38.Text = reader.GetInt32(3).ToString(); // Display UserID
                        bunifuLabel10.Text = reader.GetString(0); // Display full name
                        bunifuLabel13.Text = reader.GetString(5); // Display Gender
                        DateTime dateValue = reader.GetDateTime(6);
                        bunifuLabel12.Text = dateValue.ToShortDateString(); // Display DOB 
                        bunifuLabel11.Text = reader.GetString(7);
                        bunifuLabel20.Text = reader.GetString(8);

                        // Display Profile Picture in bunifuPictureBox1
                        if (!reader.IsDBNull(4))
                        {
                            byte[] data = (byte[])reader["ProfilePicture"];
                            using (MemoryStream ms = new MemoryStream(data))
                            {
                                bunifuPictureBox1.Image = Image.FromStream(ms);
                            }
                        }
                        else
                        {
                            // Display default image
                            bunifuPictureBox1.Image = Properties.Resources.user;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error: UserID does not exist in the database.");
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("SQL Server Error: " + ex.Message);
                    
                    // log the error to the database
                    using (SqlConnection conn = new SqlConnection(connString))
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
                    MessageBox.Show("Error: " + ex.Message);

                    // log the error to the database
                    using (SqlConnection conn = new SqlConnection(connString))
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
        }

        private string GetPhoneNumber(int userID)
        {
            string phoneNumber = null;
            using (SqlConnection connection = new SqlConnection(connString))
            {
                string query = "SELECT PhoneNumber FROM Employee_Phone WHERE UserID = @UserID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", userID);
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        phoneNumber = result.ToString();
                    }
                }
            }
            return phoneNumber;
        }


        private void bunifuLabel21_Click(object sender, EventArgs e)
        {

        }

        private void bunifuDropdown1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bunifuDropdown2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if UserID is not empty
                if (string.IsNullOrWhiteSpace(bunifuTextBox3.Text))
                {
                    throw new Exception("UserID cannot be empty.");
                }

                // Check if TypeofFeedback is selected
                if (bunifuDropdown1.SelectedItem == null)
                {
                    throw new Exception("Please select a Type of Feedback.");
                }

                // Check if RelatedSector is selected
                if (bunifuDropdown2.SelectedItem == null)
                {
                    throw new Exception("Please select a Related Sector.");
                }

                // Check if Description is not empty
                if (string.IsNullOrWhiteSpace(bunifuTextBox5.Text))
                {
                    throw new Exception("Description cannot be empty.");
                }

                // Set up connection string
                string connString = "Server=.\\SQLEXPRESS;Database=EMS-SCNE;User Id=lakshitha;Password=123456;";

                // Set up SQL query with parameter placeholders
                string sql = "INSERT INTO Feedback (UserID, TypeofFeedback, RelatedSector, Description, CurrentDate) " +
                             "VALUES (@UserID, @TypeofFeedback, @RelatedSector, @Description, @CurrentDate); " +
                             "SELECT SCOPE_IDENTITY();";

                // Set up connection and command objects
                using (SqlConnection conn = new SqlConnection(connString))
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    // Set parameter values
                    cmd.Parameters.AddWithValue("@UserID", bunifuTextBox3.Text);
                    cmd.Parameters.AddWithValue("@TypeofFeedback", bunifuDropdown1.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@RelatedSector", bunifuDropdown2.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Description", bunifuTextBox5.Text);
                    cmd.Parameters.AddWithValue("@CurrentDate", DateTime.Now);

                    // Open connection and execute query
                    conn.Open();
                    int feedbackID = Convert.ToInt32(cmd.ExecuteScalar());
                    conn.Close();

                    // Display success message to user
                    MessageBox.Show("Feedback submitted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                // Display error message to user
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // log the error to the database
                using (SqlConnection conn = new SqlConnection(connString))
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

        private void bunifuLabel10_Click(object sender, EventArgs e)
        {

        }

        /*  //////suggest names in textbox
         *  
         *  
        private void SuggestEmployeeNames(string search)
        {
            DataTable dt = new DataTable();
            string connString = "Server=.\\SQLEXPRESS;Database=EMS-SCNE;User Id=lakshitha;Password=123456;";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string sql = "SELECT Name FROM Employees WHERE UserID LIKE @search";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@search", "%" + search + "%");
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            if (dt.Rows.Count > 0)
            {
                AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
                foreach (DataRow row in dt.Rows)
                {
                    collection.Add(row["Name"].ToString());
                }
                bunifuTextBox3.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                bunifuTextBox3.AutoCompleteSource = AutoCompleteSource.CustomSource;
                bunifuTextBox3.AutoCompleteCustomSource = collection;
            }
        }*/


    }
}
