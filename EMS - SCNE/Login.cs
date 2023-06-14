using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using Bunifu.UI.WinForms;
using ComponentFactory.Krypton.Toolkit;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;


namespace EMS___SCNE.UserControls___SuperAdmin
{
    public partial class Login : KryptonForm
    {
        public string logincount;

        string connectionString = @"Server=.\SQLEXPRESS;Database=EMS-SCNE;User Id=lakshitha;Password=123456;";

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            bunifuTextBox2.UseSystemPasswordChar = true;

            // Add items to the dropdown list
            bunifuDropdown1.Items.Add("SuperAdmin");
            bunifuDropdown1.Items.Add("EMS");

            // Read login attempts from file
            
            string path = "loginAttempts.txt";
            int loginAttempts = File.Exists(path) ? int.Parse(File.ReadAllText(path)) : 0;

            // Display login attempts on label
            logincount = $"Login Attempts: {loginAttempts}";


        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            try
            {

                string username = bunifuTextBox1.Text;
                string password = bunifuTextBox2.Text;

                if (bunifuDropdown1.SelectedIndex == 0 && username == "superadmin" && password == "123456")
                {
                    // Open the SuperAdmin form
                    new SuperAdmin().Show();
                    this.Hide();
                }
                else if (bunifuDropdown1.SelectedIndex == 1)
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        // Retrieve the user record based on the entered username
                        string query = "SELECT Username, Password FROM LoginCredentials WHERE Username = @Username";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@Username", username);
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            string storedUsername = reader.GetString(0);
                            string storedHash = reader.GetString(1);

                            // Hash the entered password
                            string enteredHash = GetMd5Hash(password);

                            // Compare the hashed password with the hash of the entered password
                            if (storedHash == enteredHash && storedUsername == username)
                            {
                                // Open the Dashboard form
                                Dashboard dashboard = new Dashboard(username); //username variable send to the Dashboard form
                                dashboard.Show();

                                // Close the Login form
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Login Failed");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Entered Username Not Valid");
                        }
                    }
                }
                else
                {
                    throw new Exception("Please select a valid option from the dropdown.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }

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
            }
        }

        private void bunifuTextBox2_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void bunifuLabel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

     

        private void bunifuCheckBox4_CheckedChanged(object sender, BunifuCheckBox.CheckedChangedEventArgs e)
        {
            if (bunifuCheckBox4.Checked)
            {
                bunifuTextBox2.UseSystemPasswordChar = false; // Show password characters
            }
            else
            {
                bunifuTextBox2.UseSystemPasswordChar = true; // Hide password characters
            }
        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuPictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void guna2ImageButton2_Click(object sender, EventArgs e)
        {
            // Minimize the application
            this.WindowState = FormWindowState.Minimized;
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
