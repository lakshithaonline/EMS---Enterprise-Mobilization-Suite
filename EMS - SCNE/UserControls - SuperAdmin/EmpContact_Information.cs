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
using Bunifu.Framework.UI;
using Bunifu.UI.WinForms;
using ComponentFactory.Krypton.Toolkit;

namespace EMS___SCNE
{
    public partial class EmpContact_Information : KryptonForm
    {
        string connectionString = @"Server=.\SQLEXPRESS;Database=EMS-SCNE;User Id=lakshitha;Password=123456;";

        public EmpContact_Information()
        {
            InitializeComponent();
        }

        private void EmpContact_Information_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the '_EMS_SCNEDataSet.Employee_Phone' table. You can move, or remove it, as needed.
            this.employee_PhoneTableAdapter.Fill(this._EMS_SCNEDataSet.Employee_Phone);

        }

        private void bunifuTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            int? userID = null;
            if (!string.IsNullOrEmpty(bunifuTextBox2.Text))
            {
                if (!int.TryParse(bunifuTextBox2.Text, out int result))
                {
                    MessageBox.Show("Invalid user ID entered.");
                    return;
                }
                userID = result;
            }
            string number = bunifuTextBox3.Text;
           

            string query = "INSERT INTO Employee_Phone (UserID, PhoneNumber) " +
                           "VALUES (@UserID, @PhoneNumber)";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", userID.HasValue ? (object)userID.Value : DBNull.Value);
                    command.Parameters.AddWithValue("@PhoneNumber", number);
                    
                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Employee added successfully!");
                    }
                    else
                    {
                        MessageBox.Show("Failed to add employee.");
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    MessageBox.Show("A user with that ID already exists in the database. Please enter a unique ID.");
                }
                else
                {
                    MessageBox.Show("An error occurred while adding the employee to the database. Error message: " + ex.Message);

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

        private void bunifuDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = bunifuDataGridView1.Rows[e.RowIndex];

                //Delete Employee display
                bunifuTextBox2.Text = row.Cells[0].Value.ToString();
                bunifuTextBox3.Text = row.Cells[1].Value.ToString();

                //Edit Employee display
                bunifuTextBox2.Text = row.Cells[0].Value.ToString();
                bunifuTextBox3.Text = row.Cells[1].Value.ToString();


                bunifuTextBox2.ReadOnly = true;
               


            }
        }

        private void bunifuButton5_Click(object sender, EventArgs e)
        {
            if (bunifuDataGridView1.SelectedRows.Count == 1)
            {
                DataGridViewRow row = bunifuDataGridView1.SelectedRows[0];
                int userID = Convert.ToInt32(row.Cells[0].Value);

                // Prompt the user to confirm the update
                DialogResult result = MessageBox.Show("Are you sure you want to update this record?",
                                                      "Confirmation",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Update the record in the database
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        string query = "UPDATE Employee_Phone SET PhoneNumber = @PhoneNumber WHERE UserID = @UserID";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@PhoneNumber", bunifuTextBox3.Text);
                            command.Parameters.AddWithValue("@UserID", userID);

                            connection.Open();
                            int rowsAffected = command.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                // Update the row in the DataGridView
                                row.Cells[1].Value = bunifuTextBox3.Text;

                                MessageBox.Show("Record updated successfully.");
                            }
                            else
                            {
                                MessageBox.Show("Error updating record.");
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a row to update.");
            }
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
                        string query = $"DELETE FROM Employee_Phone WHERE UserID = {userID}";
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

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            int? userID = null;
            if (!string.IsNullOrEmpty(bunifuTextBox1.Text))
            {
                if (!int.TryParse(bunifuTextBox1.Text, out int result))
                {
                    MessageBox.Show("Invalid user ID entered.");
                    return;
                }
                userID = result;
            }

            DataTable table = new DataTable();
            string query = "SELECT * FROM Employee_Phone";
            if (userID.HasValue)
            {
                query += " WHERE UserID = @UserID";
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                if (userID.HasValue)
                {
                    command.Parameters.AddWithValue("@UserID", userID.Value);
                }

                connection.Open();
                adapter.Fill(table);
            }

            bunifuDataGridView1.DataSource = table;
        }

        private void bunifuButton6_Click(object sender, EventArgs e)
        {
            bunifuTextBox2.Clear();
            bunifuTextBox3.Clear();
        }
    }
}
