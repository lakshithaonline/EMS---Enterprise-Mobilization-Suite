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
            int userID;
            if (!int.TryParse(bunifuTextBox1.Text, out userID))
            {
                MessageBox.Show("Error: Invalid UserID format.");
                return;
            }

            using (var connection = new SqlConnection(connString))
            using (var command = new SqlCommand("SELECT Name, Department, Position, UserID, ProfilePicture FROM Employees WHERE UserID = @userID", connection))
            {
                command.Parameters.AddWithValue("@userID", userID);

                try
                {
                    connection.Open();
                    var reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        bunifuLabel2.Text = reader.GetString(0); // Display Name in bunifuLabel2
                        bunifuLabel3.Text = reader.GetString(1); //Display Department
                        bunifuLabel4.Text = reader.GetString(2); //Display Position
                        bunifuLabel38.Text = reader.GetInt32(3).ToString();

                        // Display Profile Picture in bunifuPictureBox1
                        if (!reader.IsDBNull(4))
                        {
                            var data = (byte[])reader["ProfilePicture"];
                            using (var ms = new MemoryStream(data))
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
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
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
    }
}
