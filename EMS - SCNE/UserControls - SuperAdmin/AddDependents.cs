using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Bunifu.Framework.UI;
using Bunifu.UI.WinForms;
using ComponentFactory.Krypton.Toolkit;
using Microsoft.VisualBasic.ApplicationServices;

namespace EMS___SCNE
{
    public partial class AddDependents : KryptonForm
    {
        string connectionString = @"Server=.\SQLEXPRESS;Database=EMS-SCNE;User Id=lakshitha;Password=123456;";

        public AddDependents()
        {
            InitializeComponent();

        }

        private void AddDependents_Load(object sender, EventArgs e)
        {
            // Dropdown for Relationship
            bunifuDropdown2.Items.Add("Spouse");
            bunifuDropdown2.Items.Add("Child");
            bunifuDropdown2.Items.Add("Parent");
       

            // Dropdown for Gender
            bunifuDropdown3.Items.Add("Male");
            bunifuDropdown3.Items.Add("Female");
          

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
            string name = bunifuTextBox3.Text;
            string relationship = bunifuDropdown2.SelectedItem.ToString();
            string dob = bunifuDatePicker1.Value.ToString();
            string gender = bunifuDropdown3.SelectedItem.ToString();

            string query = "INSERT INTO Employee_Dependent (UserID, D_Name, D_DOB, Relationship, Gender) " +
                           "VALUES (@UserID, @D_Name, @D_DOB, @Relationship, @Gender)";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", userID.HasValue ? (object)userID.Value : DBNull.Value);
                    command.Parameters.AddWithValue("@D_Name", name);
                    command.Parameters.AddWithValue("@D_DOB", dob);
                    command.Parameters.AddWithValue("@Relationship", relationship);
                    command.Parameters.AddWithValue("@Gender", gender);
                 
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

        private void bunifuTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuButton5_Click(object sender, EventArgs e)
        {

            if (bunifuDataGridView1.SelectedRows.Count == 1)
            {
                DataGridViewRow row = bunifuDataGridView1.SelectedRows[0];
                int UserID = int.Parse(row.Cells[1].Value.ToString());

                // Prompt the user to confirm the update
                DialogResult result = MessageBox.Show("Are you sure you want to update this record?",
                                                      "Confirmation",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Update the record in the database
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {

                        conn.Open();
                        string query = "UPDATE Employee_Dependent SET " +
                                       "D_Name = @D_Name, " +
                                       "D_DOB = @D_DOB, " +
                                       "Relationship = @Relationship, " +
                                       "Gender = @Gender " +          
                                       "WHERE UserID = @UserID";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@UserID", UserID);
                        cmd.Parameters.AddWithValue("@D_Name", bunifuTextBox3.Text);
                        cmd.Parameters.AddWithValue("@D_DOB", bunifuDatePicker1.Value);
                        cmd.Parameters.AddWithValue("@Relationship", bunifuDropdown2.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@Gender", bunifuDropdown3.SelectedItem.ToString());
                       
                       
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            // Update the row in the DataGridView
                            row.Cells[2].Value = bunifuTextBox3.Text;
                            row.Cells[4].Value = bunifuDatePicker1.Value; 
                            row.Cells[3].Value = bunifuDropdown2.SelectedItem.ToString();
                            row.Cells[5].Value = bunifuDropdown3.SelectedItem.ToString();

                            MessageBox.Show("Record updated successfully.");
                        }
                        else
                        {
                            MessageBox.Show("Error updating record.");
                        }
                        conn.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a row to update.");
            }
        }

        private void bunifuDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = bunifuDataGridView1.Rows[e.RowIndex];

                //Delete Employee display
                bunifuTextBox9.Text = row.Cells[0].Value.ToString();
                bunifuTextBox10.Text = row.Cells[1].Value.ToString();
                bunifuTextBox8.Text = row.Cells[2].Value.ToString();

                //Edit Employee display
                bunifuTextBox2.Text = row.Cells[1].Value.ToString();
                bunifuTextBox3.Text = row.Cells[2].Value.ToString();
                bunifuDropdown2.SelectedItem = row.Cells[3].Value.ToString();
                bunifuDatePicker1.Value = Convert.ToDateTime(row.Cells[4].Value);
                bunifuDropdown3.SelectedItem = row.Cells[5].Value.ToString();

               bunifuTextBox10.ReadOnly = true;
               bunifuTextBox9.ReadOnly = true;
               bunifuTextBox8.ReadOnly = true;


               bunifuTextBox2.ReadOnly = true;


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

            int? dependentID = null;
            if (!string.IsNullOrEmpty(bunifuTextBox4.Text))
            {
                if (!int.TryParse(bunifuTextBox4.Text, out int result))
                {
                    MessageBox.Show("Invalid dependent ID entered.");
                    return;
                }
                dependentID = result;
            }

            DataTable table = new DataTable();
            string query = "SELECT * FROM Employee_Dependent WHERE 1=1";
            if (userID.HasValue)
            {
                query += " AND UserID = @UserID";
            }
            if (dependentID.HasValue)
            {
                query += " AND D_ID = @DependentID";
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                if (userID.HasValue)
                {
                    command.Parameters.AddWithValue("@UserID", userID.Value);
                }
                if (dependentID.HasValue)
                {
                    command.Parameters.AddWithValue("@DependentID", dependentID.Value);
                }

                adapter.Fill(table);
            }

            bunifuDataGridView1.DataSource = table;
        }

        private void bunifuDatePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuButton6_Click(object sender, EventArgs e)
        {
            bunifuTextBox2.Clear();
            bunifuTextBox3.Clear();
            //bunifuDatePicker1.Value = null;
            bunifuDropdown2.SelectedItem = null;
            bunifuDropdown3.SelectedItem = null;

        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            if (bunifuDataGridView1.SelectedRows.Count == 1)
            {
                DataGridViewRow row = bunifuDataGridView1.SelectedRows[0];
                //int userID = Convert.ToInt32(row.Cells["UserID"].Value);
                int userID = int.Parse(row.Cells[1].Value.ToString());

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
                        string query = $"DELETE FROM Employee_Dependent WHERE UserID = {userID}";
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

        private void bunifuButton7_Click(object sender, EventArgs e)
        {
            bunifuTextBox8.Clear();
            bunifuTextBox9.Clear();
            bunifuTextBox10.Clear();

        }
    }
}
