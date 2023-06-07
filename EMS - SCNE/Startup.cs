using Bunifu.UI.WinForms;
using EMS___SCNE.UserControls___SuperAdmin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EMS___SCNE
{
    public partial class Startup : Form
    {
        private System.Windows.Forms.Timer timer;
        private int logIndex;
        private string[] loadingLogs = {
            "Loading resources...",
            "Initializing components...",
            "Connecting to the server...",
            "Preparing data...",
            "Performing security checks...",
            "Setting up employee profiles...",
            "Loading project data...",
            "Finalizing setup...",
            "Loading complete. Opening application..."
        };

        // Variables
        private int currentIndex = 0;
        // Image paths
        private string[] imagePaths = {
            "C:\\Users\\Lakshitha\\Documents\\GitHub\\EMS-SCNE\\EMS - SCNE\\Resources\\Untitled-1.png",
            "C:\\Users\\Lakshitha\\Documents\\GitHub\\EMS-SCNE\\EMS - SCNE\\Resources\\Untitled-2.png"
        };

        // Flag to keep track of whether the login form is already open
        private static bool isLoginFormOpen = false;

        public Startup()
        {
            InitializeComponent();
            timer = new System.Windows.Forms.Timer();
            logIndex = 0;
        }

        private void Startup_Load(object sender, EventArgs e)
        {
            //pictureslider timer
            timer.Tick += Timer_Tick;
            timer.Interval = 2000;
            timer.Start();

            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

            pictureBox1.Image = Image.FromFile(imagePaths[currentIndex]);

            //Loading log timer
            timer.Interval = 2000;
            timer.Tick += Timer_Tick;

            timer.Start();

            if (pictureBox1 != null)
            {
                // set the BorderRadius property to 10
                pictureBox1.BorderRadius = 30;
            }
        }

        private async void Timer_Tick(object sender, EventArgs e)
        {
            if (logIndex < loadingLogs.Length)
            {
                string log = loadingLogs[logIndex];
                lblLoadingLog.Text = log;

                logIndex++;
                await Task.Delay(4000); // Display each log for 2 seconds

                if (logIndex == loadingLogs.Length)
                {
                    timer.Stop();

                    // Check if the login form is already open
                    if (!isLoginFormOpen)
                    {
                        // Set the flag to true since the form is about to be opened
                        isLoginFormOpen = true;

                        this.Hide();
                        Login loginform = new Login();
                        loginform.FormClosed += LoginForm_FormClosed;
                        loginform.Show();
                    }
                }
            }

            currentIndex++;
            if (currentIndex >= imagePaths.Length)
                currentIndex = 0;

            pictureBox1.Image = Image.FromFile(imagePaths[currentIndex]);
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Exit the application when the login form is closed
            Application.Exit();
        }

        // Rest of the event handlers...
    



        private void Pnl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuPanel1_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel1_Click(object sender, EventArgs e)
        {

        }

        private void descriptionLabel_Click(object sender, EventArgs e)
        {

        }

        private void titleLabel_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel2_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuPanel1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_2(object sender, EventArgs e)
        {

        }

        private void bunifuLabel7_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel8_Click(object sender, EventArgs e)
        {

        }
    }
}
