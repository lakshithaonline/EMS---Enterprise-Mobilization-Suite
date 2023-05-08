using Bunifu.UI.WinForms;
using EMS___SCNE.Properties;
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


namespace EMS___SCNE.UserControls___SuperAdmin
{
    public partial class Employee_superadmin : UserControl
    {
        string connectionString = @"Server=.\SQLEXPRESS;Database=EMS-SCNE;User Id=lakshitha;Password=123456;";
       

        public Employee_superadmin()
        {
            InitializeComponent();
            //Dropdown list
            bunifuDropdown1.Items.Add("All");
            bunifuDropdown1.Items.Add("Male");
            bunifuDropdown1.Items.Add("Female");


            // Adding items to the department dropdown
            bunifuDropdown2.Items.Add("Sales");
            bunifuDropdown2.Items.Add("Marketing");
            bunifuDropdown2.Items.Add("HR");
            bunifuDropdown2.Items.Add("Finance");
            bunifuDropdown2.Items.Add("IT");

            // Adding items to the gender dropdown
            bunifuDropdown3.Items.Add("Male");
            bunifuDropdown3.Items.Add("Female");

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

            string genderFilter = "";
            if (bunifuDropdown1.SelectedItem != null)
            {
                string gender = bunifuDropdown1.SelectedItem.ToString();
                if (gender == "All")
                {
                    // Don't apply any gender filter
                }
                else if (gender == "Male")
                {
                    genderFilter = " AND Gender = 'M'";
                }
                else if (gender == "Female")
                {
                    genderFilter = " AND Gender = 'F'";
                }
            }

            DataTable table = new DataTable();
            string query = "SELECT * FROM Employees WHERE 1=1";
            if (userID.HasValue)
            {
                query += " AND UserID = @UserID";
            }
            if (!string.IsNullOrEmpty(genderFilter))
            {
                query += genderFilter;
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                if (userID.HasValue)
                {
                    command.Parameters.AddWithValue("@UserID", userID.Value);
                }
                adapter.Fill(table);
            }

            bunifuDataGridView1.DataSource = table;
        }

        private void bunifuLabel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = bunifuDataGridView1.Rows[e.RowIndex];

                //Delete Employee display
                bunifuTextBox10.Text = row.Cells[0].Value.ToString();
                bunifuTextBox9.Text = row.Cells[1].Value.ToString();
                bunifuTextBox8.Text = row.Cells[2].Value.ToString();

                //Edit Employee display
                bunifuTextBox2.Text = row.Cells[0].Value.ToString();
                bunifuTextBox3.Text = row.Cells[1].Value.ToString();
                bunifuTextBox5.Text = row.Cells[2].Value.ToString();
                bunifuDropdown2.SelectedItem = row.Cells[3].Value.ToString();
                bunifuDropdown3.SelectedItem = row.Cells[4].Value.ToString();

                if (row.Cells[5].Value != null && row.Cells[5].Value != DBNull.Value)
                {
                    byte[] imageData = (byte[])row.Cells[5].Value;
                    MemoryStream ms = new MemoryStream(imageData);
                    bunifuPictureBox2.Image = Image.FromStream(ms);
                }
                else
                {
                    bunifuPictureBox2.Image = null;
                }

                bunifuTextBox10.ReadOnly = true;
                bunifuTextBox9.ReadOnly = true;
                bunifuTextBox8.ReadOnly = true;


                bunifuTextBox2.ReadOnly = true;


            }
        }

        private void Employee_superadmin_Load(object sender, EventArgs e)
        {

        }

        private void bunifuSeparator1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel12_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            string connectionString1 = @"Server=.\SQLEXPRESS;Database=EMS-SCNE;User Id=lakshitha;Password=123456;";

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
                    using (SqlConnection conn = new SqlConnection(connectionString1))
                    {
                        conn.Open();
                        string query = $"DELETE FROM Employees WHERE UserID = {userID}";
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
            string position = bunifuTextBox5.Text;
            string department = bunifuDropdown2.SelectedItem.ToString();
            string gender = bunifuDropdown3.SelectedItem.ToString();

            byte[] image = null;
            if (bunifuPictureBox2.Image != null)
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    bunifuPictureBox2.Image.Save(memoryStream, ImageFormat.Jpeg);
                    image = memoryStream.ToArray();
                }
            }

            string query = "INSERT INTO Employees (UserID, Name, Department, Position, Gender, ProfilePicture) " +
                           "VALUES (@UserID, @Name, @Department, @Position, @Gender, @ProfilePicture)";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", userID.HasValue ? (object)userID.Value : DBNull.Value);
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Department", department);
                    command.Parameters.AddWithValue("@Position", position);
                    command.Parameters.AddWithValue("@Gender", gender);
                    command.Parameters.AddWithValue("@ProfilePicture", image ?? (object)DBNull.Value);
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

        private void bunifuTextBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                bunifuPictureBox2.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void bunifuButton5_Click(object sender, EventArgs e)
        {
            string connectionString1 = @"Server=.\SQLEXPRESS;Database=EMS-SCNE;User Id=lakshitha;Password=123456;";

            if (bunifuDataGridView1.SelectedRows.Count == 1)
            {
                DataGridViewRow row = bunifuDataGridView1.SelectedRows[0];
                int userID = int.Parse(row.Cells[0].Value.ToString());

                // Prompt the user to confirm the update
                DialogResult result = MessageBox.Show("Are you sure you want to update this record?",
                                                      "Confirmation",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Update the record in the database
                    using (SqlConnection conn = new SqlConnection(connectionString1))
                    {
                        conn.Open();
                        string query = "UPDATE Employees SET " +
                                       "Name = @name, " +
                                       "Position = @position, " +
                                       "Department = @department, " +
                                       "Gender = @gender, " +
                                       "ProfilePicture = @profilePicture " +
                                       "WHERE UserID = @userID";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@name", bunifuTextBox3.Text);
                        cmd.Parameters.AddWithValue("@position", bunifuTextBox5.Text);
                        cmd.Parameters.AddWithValue("@department", bunifuDropdown2.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@gender", bunifuDropdown3.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@userID", userID);

                        byte[] newProfilePicture = GetProfilePictureBytes(bunifuPictureBox2);
                        if (newProfilePicture != null)
                        {
                            cmd.Parameters.AddWithValue("@profilePicture", newProfilePicture);
                        }
                        else
                        {
                            SqlParameter param = new SqlParameter("@profilePicture", SqlDbType.VarBinary, -1);
                            param.Value = DBNull.Value;
                            cmd.Parameters.Add(param);
                        }


                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            // Update the row in the DataGridView
                            row.Cells[1].Value = bunifuTextBox3.Text;
                            row.Cells[2].Value = bunifuTextBox5.Text;
                            row.Cells[3].Value = bunifuDropdown2.SelectedItem.ToString();
                            row.Cells[4].Value = bunifuDropdown3.SelectedItem.ToString();

                            if (newProfilePicture != null)
                            {
                                bunifuPictureBox2.Image = Image.FromStream(new MemoryStream(newProfilePicture));
                            }
                            else
                            {
                                bunifuPictureBox2.Image = null;
                            }

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


        private byte[] GetProfilePictureBytes(BunifuPictureBox pictureBox)
        {
            if (pictureBox.Image == null)
            {
                return null;
            }
            using (MemoryStream memoryStream = new MemoryStream())
            {
                pictureBox.Image.Save(memoryStream, ImageFormat.Jpeg);
                return memoryStream.ToArray();
            }
        }

        private void bunifuButton6_Click(object sender, EventArgs e)
        {

            bunifuTextBox2.Clear();
            bunifuTextBox3.Clear();
            bunifuTextBox5.Clear();
            bunifuDropdown2.SelectedItem = null;
            bunifuDropdown3.SelectedItem = null;


        }

        private void bunifuButton7_Click(object sender, EventArgs e)
        {
            bunifuTextBox8.Clear();
            bunifuTextBox9.Clear();
            bunifuTextBox10.Clear();    
        }


        private void bunifuButton8_Click(object sender, EventArgs e)
        {
            AddDependents addDependentsForm = new AddDependents();
            addDependentsForm.Show();
        }

        private void bunifuButton9_Click(object sender, EventArgs e)
        {
            EmpContact_Information addempcontact = new EmpContact_Information();
            addempcontact.Show();
        }
    }
}
