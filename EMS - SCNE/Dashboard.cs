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

namespace EMS___SCNE
{
    public partial class Dashboard : KryptonForm
    {
        public Dashboard()
        {
            InitializeComponent();
            timer1.Enabled = true;

            //resize
          //  Resize += Form1_Resize;
          //  Load += Form1_Load;


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
            Application.Exit();
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
    }
}
