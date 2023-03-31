using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace EMS___SCNE
{
    public partial class Leave_UC : UserControl
    {
        string connString = "Server=.\\SQLEXPRESS;Database=EMS-SCNE;User Id=lakshitha;Password=123456;";

        public Leave_UC()
        {
            InitializeComponent();


        }

        private void Leave_Load(object sender, EventArgs e)
        {
            // Populate the leave type dropdown
            bunifuDropdown1.Items.Add("short_leave");
            bunifuDropdown1.Items.Add("half_day");
            bunifuDropdown1.Items.Add("annual_leave");
            bunifuDropdown1.Items.Add("casual_leave");


            //populate the leave type for view
            bunifuDropdown3.Items.Add("Monthly Leaves");
            bunifuDropdown3.Items.Add("Annual Leaves");

            //change datepicker format
            bunifuDatePicker3.Format = DateTimePickerFormat.Custom;
            bunifuDatePicker3.CustomFormat = "MMMM yyyy";



        }

        private void bunifuPanel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel4_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel6_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {

            string userID = bunifuTextBox2.Text;    
            string year = bunifuTextBox3.Text;
            string reason = bunifuTextBox6.Text;
            string leaveCount = bunifuTextBox1.Text;
            DateTime deductedDate = DateTime.Now;

            if (bunifuDropdown1.SelectedItem == null)
            {
                MessageBox.Show("Please select a leave type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (bunifuTextBox1.Text == null)
            {
                MessageBox.Show("Please Enter a leave count.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string leaveType = bunifuDropdown1.SelectedItem.ToString();    

            try
            {
                if (string.IsNullOrWhiteSpace(userID) || string.IsNullOrWhiteSpace(year))
                {
                    throw new ArgumentException("One or more required fields are empty.");
                }

                if (leaveType == "short_leave" || leaveType == "half_day")
                {
                    string month = bunifuTextBox5.Text;    

                    if (string.IsNullOrWhiteSpace(month))
                    {
                        throw new ArgumentException("Month field is empty.");
                    }

                    // hardcoded value for monthly leaves
                    int leaveCountformonthly = 1;

                    DateTime date = bunifuDatePicker1.Value;        


                    string query = "EXEC deduct_leave @UserID = '" + userID + "', @year = '" + year + "', @month = '" + month + "', @leave_type = '" + leaveType + "', @leave_count = '" + leaveCountformonthly + "';";
                    string connectionString = "Server=.\\SQLEXPRESS;Database=EMS-SCNE;User Id=lakshitha;Password=123456;";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            connection.Open();
                            command.ExecuteNonQuery();
                            connection.Close();
                        }
                    }
                    
                    // Insert a new record into Leave_request_history table
                    string insertQuery = "INSERT INTO Leaverequest_history (UserID, Leave_Type, Year, Month, From_Date, To_Date, Leave_Count, Reason, Deducted_Date) VALUES ('" + userID + "', '" + leaveType + "', '" + year + "', '" + month + "', '" + date.ToString("yyyy-MM-dd") + "', NULL, '" + leaveCountformonthly + "', '" + reason + "', '" + deductedDate.ToString("yyyy-MM-dd HH:mm:ss") + "')";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        using (SqlCommand command = new SqlCommand(insertQuery, connection))
                        {
                            connection.Open();
                            command.ExecuteNonQuery();
                            connection.Close();
                        }
                    }


                    MessageBox.Show("Leave deduction successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (leaveType == "casual_leave" || leaveType == "annual_leave")
                {
                    DateTime fromDate = bunifuDatePicker1.Value;           
                    DateTime toDate = bunifuDatePicker2.Value;             
                    

                    string query = "EXEC deduct_annual_leave @UserID = '" + userID + "', @year = '" + year + "', @leave_type = '" + leaveType + "', @leave_count = '" + leaveCount + "';";
                    string connectionString = "Server=.\\SQLEXPRESS;Database=EMS-SCNE;User Id=lakshitha;Password=123456;";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            connection.Open();
                            command.ExecuteNonQuery();
                            connection.Close();
                        }
                    }

                    
                    // Insert a new record into Leave_request_history table
                    string insertQuery = "INSERT INTO Leaverequest_history (UserID, Leave_Type, Year, Month, From_Date, To_Date, Leave_Count, Reason, Deducted_Date) VALUES ('" + userID + "', '" + leaveType + "', '" + year + "', NULL , '" + fromDate.ToString("yyyy-MM-dd") + "', '" + toDate.ToString("yyyy-MM-dd") + "', '" + Convert.ToInt32(leaveCount) + "', '" + reason + "', '" + deductedDate.ToString("yyyy-MM-dd HH:mm:ss") + "')";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        using (SqlCommand command = new SqlCommand(insertQuery, connection))
                        {
                            connection.Open();
                            command.ExecuteNonQuery();
                            connection.Close();
                        }
                    }

                    MessageBox.Show("Leave deduction successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (ArgumentException ex)
            {
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
            catch (Exception ex)
            {
                MessageBox.Show("Leave deduction failed. Error message: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

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


        private void bunifuButton1_Click_1(object sender, EventArgs e)
        {

            int? userID = null;
            if (!string.IsNullOrEmpty(bunifuTextBox133.Text))
            {
                if (!int.TryParse(bunifuTextBox133.Text, out int result))
                {
                    MessageBox.Show("Invalid user ID entered.");
                    return;
                }
                userID = result;
            }

            if (bunifuDropdown3.SelectedItem == null)
            {
                MessageBox.Show("Please select a leave type.");
                return;
            }

            if (bunifuDropdown3.SelectedItem.ToString() == "Monthly Leaves")
            {
                if (bunifuDatePicker3.Value == null)
                {
                    MessageBox.Show("Please select a month.");
                    return;
                }
                int year = bunifuDatePicker3.Value.Year;
                int month = bunifuDatePicker3.Value.Month;

                DataTable table = new DataTable();
                string query = "SELECT * FROM Monthly_leave WHERE year = @year AND month = @month";
                if (userID.HasValue)
                {
                    query += " AND UserID = @UserID";
                }
                using (SqlConnection connection = new SqlConnection(connString))
                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    command.Parameters.AddWithValue("@year", year);
                    command.Parameters.AddWithValue("@month", month);
                    if (userID.HasValue)
                    {
                        command.Parameters.AddWithValue("@UserID", userID.Value);
                    }
                    adapter.Fill(table);
                }

                bunifuDataGridView2.DataSource = table;
            }
            else if (bunifuDropdown3.SelectedItem.ToString() == "Annual Leaves")
            {
                if (bunifuDatePicker3.Value == null)
                {
                    MessageBox.Show("Please select a year.");
                    return;
                }
                int year = bunifuDatePicker3.Value.Year;

                DataTable table = new DataTable();
                string query = "SELECT * FROM Annual_leave WHERE year = @year";
                if (userID.HasValue)
                {
                    query += " AND UserId = @UserID";
                }
                using (SqlConnection connection = new SqlConnection(connString))
                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    command.Parameters.AddWithValue("@year", year);
                    if (userID.HasValue)
                    {
                        command.Parameters.AddWithValue("@UserID", userID.Value);
                    }
                    adapter.Fill(table);
                }

                bunifuDataGridView2.DataSource = table;

            }
        }

            private void bunifuDataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bunifuDatePicker3_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void bunifuTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuDropdown1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected item of the Bunifu dropdown
            string selectedItem = bunifuDropdown1.SelectedItem.ToString();

            // Depending on the selected item, enable or disable text boxes and date picker
            if (selectedItem == "short_leave" || selectedItem == "half_day")
            {
                bunifuTextBox2.Enabled = true;
                bunifuTextBox5.Enabled = true;
                
                bunifuTextBox3.Enabled = true;
                bunifuDatePicker2.Enabled = false;
            }
            else if (selectedItem == "annual_leave" || selectedItem == "casual_leave")
            {
                bunifuTextBox2.Enabled = true;
                bunifuTextBox3.Enabled = true;

                bunifuTextBox5.Enabled = false;
                bunifuDatePicker2.Enabled = true;
            }
            else // if selectedItem is not any of the above options
            {
                bunifuTextBox2.Enabled = false;
                bunifuTextBox3.Enabled = false;
               
                bunifuTextBox5.Enabled = false;
                bunifuDatePicker2.Enabled = false;
            }

            if (bunifuDropdown1.SelectedItem.ToString() == "short_leave" || bunifuDropdown1.SelectedItem.ToString() == "half_day")
            {
                bunifuLabel6.Text = "Date";
            }


        }

        private void bunifuDatePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuDatePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {

            string userID = bunifuTextBox2.Text; // replace with the actual user ID
            string year = bunifuTextBox3.Text; // replace with the actual year
            string leaveType = bunifuDropdown1.SelectedItem.ToString();// replace with the actual leave type
            DateTime fromDate = bunifuDatePicker1.Value;
            DateTime toDate = bunifuDatePicker2.Value;
            string leaveCount = bunifuTextBox1.Text;

            try
            {

                // Check which leave type is selected and call the corresponding procedure
                if (leaveType == "short_leave" || leaveType == "half_day")
                {
                    string month = bunifuTextBox5.Text;
                    //EXEC undo_deduct_annual_leave @UserID = 1, @year = 2023, @leave_type = 'casual_leave', @leave_count = 1;

                    // Use a single date picker to get the leave count
                    int leaveCount1 = 1;

                    string query = "EXEC undo_deduct_monthly_leave @UserID = '" + userID + "', @year = '" + year + "', @month = '" + month + "', @leave_type = '" + leaveType + "', @leave_count = '" + leaveCount1 + "';";
                    string connectionString = "Server=.\\SQLEXPRESS;Database=EMS-SCNE;User Id=lakshitha;Password=123456;";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            connection.Open();
                            command.ExecuteNonQuery();
                            connection.Close();
                        }
                    }

                    MessageBox.Show("Latest deduction has been undone!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (leaveType == "casual_leave" || leaveType == "annual_leave")
                {
                    string query = "EXEC undo_deduct_annual_leave @UserID = '" + userID + "', @year = '" + year + "', @leave_type = '" + leaveType + "', @leave_count = '" + leaveCount + "';";
                    string connectionString = "Server=.\\SQLEXPRESS;Database=EMS-SCNE;User Id=lakshitha;Password=123456;";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            connection.Open();
                            command.ExecuteNonQuery();
                            connection.Close();
                        }
                    }

                    MessageBox.Show("Latest deduction has been undone!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Leave deduction failed. Error message: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

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

        private void bunifuDropdown3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox133_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuDataGridView2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuLabel8_Click(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
