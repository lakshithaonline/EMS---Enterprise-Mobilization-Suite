using ComponentFactory.Krypton.Toolkit;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Windows.Forms;
using EMS___SCNE.UserControls;
using Bunifu.UI.WinForms;
using System.Data.SqlClient;
using System.IO;
using EMS___SCNE.UserControls___SuperAdmin;
using System.Diagnostics;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Xml.Linq;
using System.Drawing.Drawing2D;

namespace EMS___SCNE
{
    public partial class Dashboard : KryptonForm
    {
        


        string connectionString = @"Server=.\SQLEXPRESS;Database=EMS-SCNE;User Id=lakshitha;Password=123456;";
        public Dashboard()
        {
            InitializeComponent();
            timer1.Enabled = true;

        }

        //Display the current user's Name and Position top of Dashboard
        public Dashboard(string username) //the username variable called from Login form
        {
            InitializeComponent();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT Employees.Name, Employees.Position, Employees.Gender, Employees.ProfilePicture FROM LoginCredentials JOIN Employees ON LoginCredentials.UserID = Employees.UserID WHERE LoginCredentials.Username = @Username;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string employeeName = reader.GetString(0);
                        string employeePosition = reader.GetString(1);
                        string employeeGender = reader.GetString(2);
                        byte[] profilePictureBytes = reader["ProfilePicture"] as byte[];

                        // Set the label texts to the employee name and position
                        bunifuLabel3.Text = employeeName;
                        bunifuLabel4.Text = employeePosition;

                        // Display the profile picture in the bunifuPictureBox1
                        if (profilePictureBytes != null)
                        {
                            using (MemoryStream ms = new MemoryStream(profilePictureBytes))
                            {
                                bunifuPictureBox1.Image = Image.FromStream(ms);
                            }
                        }
                        else
                        {
                            // Set default profile picture for male or female employees
                            Bitmap defaultImage = null;
                            if (string.Equals(employeeGender, "Male", StringComparison.OrdinalIgnoreCase))
                            {
                                defaultImage = Properties.Resources.DefaultMaleImage;
                            }
                            else if (string.Equals(employeeGender, "Female", StringComparison.OrdinalIgnoreCase))
                            {
                                defaultImage = Properties.Resources.DefaultFemaleImage;
                            }

                            // Display the default profile picture
                            if (defaultImage != null)
                            {
                                bunifuPictureBox1.Image = defaultImage;
                            }
                        }
                    }
                    else
                    {
                        // Handle the case where the username is not found
                        bunifuLabel3.Text = "Error: Username not found";
                    }
                }
            }
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the '_EMS_SCNEDataSet.sp_GetTopEmployees' table. You can move, or remove it, as needed.
            this.sp_GetTopEmployeesTableAdapter.Fill(this._EMS_SCNEDataSet.sp_GetTopEmployees);
            // TODO: This line of code loads data into the '_EMS_SCNEDataSet.Absent_emp' table. You can move, or remove it, as needed.
            this.absent_empTableAdapter.Fill(this._EMS_SCNEDataSet.Absent_emp);

           
            Guna.UI2.WinForms.Guna2Elipse elipse = new Guna.UI2.WinForms.Guna2Elipse();
            elipse.BorderRadius = 10;
            elipse.TargetControl = gunaTransfarantPictureBox1;

            Guna.UI2.WinForms.Guna2Elipse elipse1 = new Guna.UI2.WinForms.Guna2Elipse();
            elipse1.BorderRadius = 10;
            elipse1.TargetControl = gunaTransfarantPictureBox2;

            Guna.UI2.WinForms.Guna2Elipse elipse2 = new Guna.UI2.WinForms.Guna2Elipse();
            elipse2.BorderRadius = 10;
            elipse2.TargetControl = gunaTransfarantPictureBox3;

            timer1.Start();

            /*
            // Set the border radius of the GunaTransfarantPictureBox2 control
            int cornerRadius = 10;
            GraphicsPath path = new GraphicsPath();
            Rectangle rect = new Rectangle(0, 0, gunaTransfarantPictureBox2.Width, gunaTransfarantPictureBox2.Height);
            path.AddArc(rect.X, rect.Y, cornerRadius, cornerRadius, 180, 90);
            path.AddArc(rect.X + rect.Width - cornerRadius, rect.Y, cornerRadius, cornerRadius, 270, 90);
            path.AddArc(rect.X + rect.Width - cornerRadius, rect.Y + rect.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90);
            path.AddArc(rect.X, rect.Y + rect.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90);
            path.CloseAllFigures();
            gunaTransfarantPictureBox2.Region = new Region(path);
            gunaTransfarantPictureBox1.Region = new Region(path);
            gunaTransfarantPictureBox3.Region = new Region(path);
            */

        }

        private void bunifuPanel1_Click(object sender, EventArgs e)
        {

        }

        private void kryptonPalette1_PalettePaint(object sender, PaletteLayoutEventArgs e)
        {

        }

        private void bunifuPanel2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bunifuLabel1.Text = DateTime.Now.ToString("hh:mm:ss tt");
            labledate.Text = DateTime.Now.ToString("MM/dd/yyyy");

            // Get the current time
            DateTime currentTime = DateTime.Now;

            // Check the time of day and set the label text accordingly
            if (currentTime.Hour >= 5 && currentTime.Hour < 12)
            {
                // Good morning
                //greatingslable.Text = "Good morning";
            }
            else if (currentTime.Hour >= 12 && currentTime.Hour < 18)
            {
                // Good afternoon
                //greatingslable.Text = "Good afternoon";
            }
            else
            {
                // Good evening
                //greatingslable.Text = "Good evening";
            }

        }

        private void bunifuLabel1_Click_2(object sender, EventArgs e)
        {

        }

        private void bunifuLabel2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuPanel5_Click(object sender, EventArgs e)
        {

        }

        private void kryptonPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuButton1_Click_2(object sender, EventArgs e)
        {
            Attendence_UC attendenceUC = new Attendence_UC(); // Create an instance of the Attendence_UC user control
            attendenceUC.Dock = DockStyle.Fill; // Dock the user control to fill the parent control
            bunifuPanel7.Controls.Clear(); // Clear any existing controls in the bunifuPanel7
            bunifuPanel7.Controls.Add(attendenceUC); // Add the Attendence_UC user control to the bunifuPanel7

        }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void bunifuButton5_Click_1(object sender, EventArgs e)
        {
            // Hide the current form
            this.Hide();

            // Create a new instance of the Preloader form
            Login Login = new Login();

            // Show the Preloader form
            Login.ShowDialog();

            // Close the current form after Preloader form is closed
            this.Close();
        }

        private void greatingslable_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void bunifuPanel2_Click_1(object sender, EventArgs e)
        {

        }

        private void bunifuButton4_Click_1(object sender, EventArgs e)
        {
            Dashboard_UC dashboardUC = new Dashboard_UC(); // Create an instance of the Attendence_UC user control
            dashboardUC.Dock = DockStyle.Fill; // Dock the user control to fill the parent control
            bunifuPanel7.Controls.Clear(); // Clear any existing controls in the bunifuPanel7
            bunifuPanel7.Controls.Add(dashboardUC); // Add the Attendence_UC user control to the bunifuPanel7
        }

        private void dashboard_UC1_Load(object sender, EventArgs e)
        {

        }

        private void dashboard_UC1_Load_1(object sender, EventArgs e)
        {

        }

        private void bunifuPanel7_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton2_Click_1(object sender, EventArgs e)
        {
            Leave_UC LeaveUC = new Leave_UC(); // Create an instance of the Attendence_UC user control
            LeaveUC.Dock = DockStyle.Fill; // Dock the user control to fill the parent control
            bunifuPanel7.Controls.Clear(); // Clear any existing controls in the bunifuPanel7
            bunifuPanel7.Controls.Add(LeaveUC); // Add the Attendence_UC user control to the bunifuPanel7
        }

        private void dashboard_UC1_Load_2(object sender, EventArgs e)
        {

        }

        private void bunifuButton3_Click_1(object sender, EventArgs e)
        {
            Profile_UC profileuc = new Profile_UC(); // Create an instance of the Attendence_UC user control
            profileuc.Dock = DockStyle.Fill; // Dock the user control to fill the parent control
            bunifuPanel7.Controls.Clear(); // Clear any existing controls in the bunifuPanel7
            bunifuPanel7.Controls.Add(profileuc); // Add the Attendence_UC user control to the bunifuPanel7
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuPanel2_Click_2(object sender, EventArgs e)
        {

        }

        private void bunifuPanel3_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void bunifuLabel5_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel6_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void bunifuDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dashboard_UC1_Load_3(object sender, EventArgs e)
        {

        }

        private void bunifuButton1_Click_1(object sender, EventArgs e)
        {

        }

        private void bunifuPanel1_Click_1(object sender, EventArgs e)
        {

        }

        private void dashboard_UC1_Load_4(object sender, EventArgs e)
        {
 
        }

        private void gunaTransfarantPictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void gunaTransfarantPictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void gunaTransfarantPictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel1_Click_1(object sender, EventArgs e)
        {

        }

        private void bunifuButton7_Click(object sender, EventArgs e)
        {
            LeaveHistory attendenceUC = new LeaveHistory(); // Create an instance of the Attendence_UC user control
            attendenceUC.Dock = DockStyle.Fill; // Dock the user control to fill the parent control
            bunifuPanel7.Controls.Clear(); // Clear any existing controls in the bunifuPanel7
            bunifuPanel7.Controls.Add(attendenceUC); // Add the Attendence_UC user control to the bunifuPanel7
        }

        private void bunifuLabel3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel4_Click(object sender, EventArgs e)
        {

        }

        private void labledate_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void bunifuPictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void gunaTransfarantPictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dashboard_UC1_Load_5(object sender, EventArgs e)
        {

        }

        private void bunifuButton9_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton6_Click(object sender, EventArgs e)
        {
            // Minimize the application
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
